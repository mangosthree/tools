#include "PatchEngine.h"

#include <QDir>
#include <QFile>
#include <QFileInfo>

namespace patcher {

const BuildDef *identifyBuild(qint64 fileSize, const QVector<BuildDef> &builds)
{
    for (const BuildDef &build : builds)
    {
        if (build.exeLength == fileSize)
        {
            return &build;
        }
    }
    return nullptr;
}

ValidateResult validate(const QByteArray &data, const BuildDef &def)
{
    if (data.size() != def.exeLength)
    {
        return {
            TargetState::Mismatch,
            QString("  length mismatch: expected %1 bytes, found %2\n")
                .arg(def.exeLength)
                .arg(data.size())
        };
    }

    bool allUnpatched = true;
    bool allPatched = true;
    bool hasMismatch = false;
    QString report;

    for (const PatchSite &site : def.sites)
    {
        if (site.offset < 0
            || site.unpatched.isEmpty()
            || site.unpatched.size() != site.patched.size()
            || site.offset > data.size() - site.unpatched.size())
        {
            hasMismatch = true;
            report += QString("  invalid patch definition at offset 0x%1\n")
                          .arg(site.offset, 0, 16);
            continue;
        }

        const QByteArray current = data.mid(site.offset, site.unpatched.size());

        if (site.mustRemainUnchanged)
        {
            if (current != site.unpatched)
            {
                hasMismatch = true;
                report += QString("  offset 0x%1 must remain unchanged at %2; found %3\n")
                              .arg(site.offset, 0, 16)
                              .arg(QString::fromLatin1(site.unpatched.toHex(' ')))
                              .arg(QString::fromLatin1(current.toHex(' ')));
            }
            continue;
        }

        const bool isUnpatched = (current == site.unpatched);
        const bool isPatched = (current == site.patched);
        allUnpatched = allUnpatched && isUnpatched;
        allPatched = allPatched && isPatched;

        if (!isUnpatched && !isPatched)
        {
            hasMismatch = true;
            report += QString("  offset 0x%1: expected %2 or %3, found %4\n")
                          .arg(site.offset, 0, 16)
                          .arg(QString::fromLatin1(site.unpatched.toHex(' ')))
                          .arg(QString::fromLatin1(site.patched.toHex(' ')))
                          .arg(QString::fromLatin1(current.toHex(' ')));
        }
    }

    if (hasMismatch)
    {
        return { TargetState::Mismatch, report };
    }
    if (allUnpatched)
    {
        return { TargetState::Unpatched, report };
    }
    if (allPatched)
    {
        return { TargetState::Patched, report };
    }
    return { TargetState::Mixed, report };
}

QByteArray buildCopy(const QByteArray &data, const BuildDef &def, bool wantPatched)
{
    if (data.size() != def.exeLength)
    {
        return {};
    }

    for (const PatchSite &site : def.sites)
    {
        if (site.offset < 0
            || site.unpatched.isEmpty()
            || site.unpatched.size() != site.patched.size()
            || site.offset > data.size() - site.unpatched.size())
        {
            return {};
        }
    }

    QByteArray output = data;
    for (const PatchSite &site : def.sites)
    {
        if (site.mustRemainUnchanged)
        {
            continue;
        }

        const QByteArray &source = wantPatched ? site.patched : site.unpatched;
        for (qsizetype i = 0; i < source.size(); ++i)
        {
            output[site.offset + i] = source[i];
        }
    }
    return output;
}

QVector<Target> discover(const QString &dir, const QVector<BuildDef> &builds)
{
    QVector<Target> targets;
    const QDir directory(dir);

    for (const BuildDef &def : builds)
    {
        const QString path = directory.filePath(def.fileName);
        const QFileInfo info(path);
        if (!info.exists())
        {
            const QFileInfo fileNameInfo(def.fileName);
            const QString backupFileName =
                fileNameInfo.completeBaseName() + "_backup." + fileNameInfo.suffix();
            if (QFileInfo::exists(directory.filePath(backupFileName)))
            {
                targets.append({
                    def.fileName,
                    &def,
                    TargetState::Mismatch,
                    QString("  %1 is missing, but recovery backup %2 exists\n")
                        .arg(def.fileName, backupFileName)
                });
            }
            continue;
        }

        if (info.size() != def.exeLength)
        {
            targets.append({
                def.fileName,
                nullptr,
                TargetState::Mismatch,
                QString("  %1: unsupported size %2 (expected %3)\n")
                    .arg(def.fileName)
                    .arg(info.size())
                    .arg(def.exeLength)
            });
            continue;
        }

        QFile file(path);
        if (!file.open(QIODevice::ReadOnly))
        {
            targets.append({
                def.fileName,
                &def,
                TargetState::Mismatch,
                QString("  %1: cannot open for reading: %2\n")
                    .arg(def.fileName, file.errorString())
            });
            continue;
        }

        const QByteArray data = file.readAll();
        file.close();
        const ValidateResult result = validate(data, def);
        targets.append({ def.fileName, &def, result.state, result.report });
    }

    return targets;
}

namespace {

QString backupName(const QString &fileName)
{
    const QFileInfo info(fileName);
    return info.completeBaseName() + "_backup." + info.suffix();
}

OpResult readCurrent(const QString &path, const Target &target,
                     TargetState requiredState, QByteArray &data)
{
    QFile file(path);
    if (!file.open(QIODevice::ReadOnly))
    {
        return {
            false,
            QString("  cannot read %1: %2\n").arg(target.fileName, file.errorString())
        };
    }

    data = file.readAll();
    file.close();
    const ValidateResult current = validate(data, *target.def);
    if (current.state != requiredState)
    {
        QString report =
            QString("  %1 changed since discovery; refusing operation\n").arg(target.fileName);
        report += current.report;
        return { false, report };
    }

    return { true, {} };
}

} // namespace

OpResult applyPatch(const QString &dir, const Target &target)
{
    if (!target.def)
    {
        return { false, "  no build definition\n" };
    }
    if (target.state != TargetState::Unpatched)
    {
        return { false, "  target state is not Unpatched; refusing to patch\n" };
    }
    if (target.fileName != target.def->fileName)
    {
        return { false, "  target filename does not match its build definition\n" };
    }

    const QDir directory(dir);
    const QString filePath = directory.filePath(target.fileName);
    const QString backupPath = directory.filePath(backupName(target.fileName));
    const QString patchTempPath = filePath + ".patch.tmp";

    QByteArray original;
    const OpResult current = readCurrent(
        filePath, target, TargetState::Unpatched, original);
    if (!current.ok)
    {
        return current;
    }

    const QByteArray patched = buildCopy(original, *target.def, true);
    if (patched.isEmpty())
    {
        return { false, QString("  invalid build definition for %1\n").arg(target.fileName) };
    }

    QFile::remove(patchTempPath);
    {
        QFile output(patchTempPath);
        bool prepared = output.open(QIODevice::WriteOnly);
        if (prepared)
        {
            prepared = output.write(patched) == patched.size()
                       && output.flush()
                       && output.error() == QFileDevice::NoError;
        }
        output.close();
        if (!prepared)
        {
            QFile::remove(patchTempPath);
            return {
                false,
                QString("  error preparing patched %1\n").arg(target.fileName)
            };
        }
        output.close();
    }

    if (QFile::exists(backupPath) && !QFile::remove(backupPath))
    {
        QFile::remove(patchTempPath);
        return {
            false,
            QString("  could not remove old %1 - is WoW running?\n")
                .arg(backupName(target.fileName))
        };
    }

    if (!QFile::rename(filePath, backupPath))
    {
        QFile::remove(patchTempPath);
        return {
            false,
            QString("  could not back up %1 - make sure WoW is closed\n")
                .arg(target.fileName)
        };
    }

    if (!QFile::rename(patchTempPath, filePath))
    {
        if (!QFile::rename(backupPath, filePath))
        {
            return {
                false,
                QString("  error installing patched %1; original remains as %2 and "
                        "prepared image remains as %3\n")
                    .arg(target.fileName,
                         backupName(target.fileName),
                         QFileInfo(patchTempPath).fileName())
            };
        }
        QFile::remove(patchTempPath);
        return {
            false,
            QString("  error installing patched %1; restored from backup\n")
                .arg(target.fileName)
        };
    }

    return {
        true,
        QString("  patched %1 (backup: %2)\n")
            .arg(target.fileName, backupName(target.fileName))
    };
}

OpResult applyUnpatch(const QString &dir, const Target &target)
{
    if (!target.def)
    {
        return { false, "  no build definition\n" };
    }
    if (target.state != TargetState::Patched)
    {
        return { false, "  target state is not Patched; refusing to unpatch\n" };
    }
    if (target.fileName != target.def->fileName)
    {
        return { false, "  target filename does not match its build definition\n" };
    }

    const QDir directory(dir);
    const QString filePath = directory.filePath(target.fileName);
    const QString backupPath = directory.filePath(backupName(target.fileName));
    const QString patchedTempPath = filePath + ".patched.tmp";

    QByteArray currentData;
    const OpResult current = readCurrent(
        filePath, target, TargetState::Patched, currentData);
    if (!current.ok)
    {
        return current;
    }

    QFile backupFile(backupPath);
    if (!backupFile.open(QIODevice::ReadOnly))
    {
        return {
            false,
            QString("  backup %1 not found - cannot restore %2\n")
                .arg(backupName(target.fileName), target.fileName)
        };
    }

    const QByteArray backupData = backupFile.readAll();
    backupFile.close();
    if (validate(backupData, *target.def).state != TargetState::Unpatched)
    {
        return {
            false,
            QString("  backup %1 is not a clean original of this build; refusing to restore\n")
                .arg(backupName(target.fileName))
        };
    }

    QFile::remove(patchedTempPath);
    if (!QFile::rename(filePath, patchedTempPath))
    {
        return {
            false,
            QString("  could not move %1 aside - make sure WoW is closed\n")
                .arg(target.fileName)
        };
    }

    if (!QFile::rename(backupPath, filePath))
    {
        if (!QFile::rename(patchedTempPath, filePath))
        {
            return {
                false,
                QString("  error restoring %1; patched copy preserved as %2\n")
                    .arg(target.fileName, QFileInfo(patchedTempPath).fileName())
            };
        }
        return {
            false,
            QString("  error restoring %1; rolled back\n").arg(target.fileName)
        };
    }

    QFile::remove(patchedTempPath);
    return {
        true,
        QString("  restored %1 from backup\n").arg(target.fileName)
    };
}

} // namespace patcher

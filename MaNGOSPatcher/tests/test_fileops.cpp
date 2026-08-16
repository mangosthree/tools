#include <QtTest>
#include <QDir>
#include <QFile>
#include <QTemporaryDir>
#include "PatchEngine.h"
#include "testhelpers.h"

using namespace patcher;
using namespace patcher::test;

class TestFileOps : public QObject
{
    Q_OBJECT
private slots:
    void discoverFindsUnpatched()
    {
        QTemporaryDir tmp;
        QVERIFY(tmp.isValid());
        const QVector<BuildDef> builds = fakeBuilds();
        writeFile(QDir(tmp.path()).filePath("Fake.exe"), unpatchedBuf());

        const QVector<Target> targets = discover(tmp.path(), builds);
        QCOMPARE(targets.size(), 1);
        QCOMPARE(targets[0].fileName, QString("Fake.exe"));
        QVERIFY(targets[0].def != nullptr);
        QCOMPARE(targets[0].state, TargetState::Unpatched);
    }

    void discoverReportsUnsupportedSize()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = fakeBuilds();
        writeFile(QDir(tmp.path()).filePath("Fake.exe"), QByteArray(8, '\0'));

        const QVector<Target> targets = discover(tmp.path(), builds);
        QCOMPARE(targets.size(), 1);
        QVERIFY(targets[0].def == nullptr);
        QCOMPARE(targets[0].state, TargetState::Mismatch);
        QVERIFY(targets[0].report.contains("unsupported size"));
    }

    void discoverIgnoresMissing()
    {
        QTemporaryDir tmp;
        QCOMPARE(discover(tmp.path(), fakeBuilds()).size(), 0);
    }

    void patchThenUnpatchRoundTrip()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = fakeBuilds();
        const QString exe = QDir(tmp.path()).filePath("Fake.exe");
        const QString backup = QDir(tmp.path()).filePath("Fake_backup.exe");
        writeFile(exe, unpatchedBuf());

        const Target unpatched = discover(tmp.path(), builds)[0];
        const OpResult patchResult = applyPatch(tmp.path(), unpatched);
        QVERIFY2(patchResult.ok, qPrintable(patchResult.report));
        QVERIFY(QFile::exists(backup));
        QCOMPARE(readFile(exe), buildCopy(unpatchedBuf(), builds[0], true));
        QCOMPARE(readFile(backup), unpatchedBuf());

        const Target patched = discover(tmp.path(), builds)[0];
        QCOMPARE(patched.state, TargetState::Patched);
        const OpResult unpatchResult = applyUnpatch(tmp.path(), patched);
        QVERIFY2(unpatchResult.ok, qPrintable(unpatchResult.report));
        QCOMPARE(readFile(exe), unpatchedBuf());
        QVERIFY(!QFile::exists(backup));
    }

    void patchRefusesWrongRecordedState()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = fakeBuilds();
        const QString exe = QDir(tmp.path()).filePath("Fake.exe");
        writeFile(exe, unpatchedBuf());

        Target target = discover(tmp.path(), builds)[0];
        target.state = TargetState::Patched;
        const OpResult result = applyPatch(tmp.path(), target);
        QVERIFY(!result.ok);
        QCOMPARE(readFile(exe), unpatchedBuf());
        QVERIFY(!QFile::exists(QDir(tmp.path()).filePath("Fake_backup.exe")));
    }

    void patchRefusesFileChangedAfterDiscovery()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = fakeBuilds();
        const QString exe = QDir(tmp.path()).filePath("Fake.exe");
        writeFile(exe, unpatchedBuf());

        const Target target = discover(tmp.path(), builds)[0];
        QByteArray changed = unpatchedBuf();
        changed[4] = '\x77';
        writeFile(exe, changed);

        const OpResult result = applyPatch(tmp.path(), target);
        QVERIFY(!result.ok);
        QVERIFY(result.report.contains("changed"));
        QCOMPARE(readFile(exe), changed);
        QVERIFY(!QFile::exists(QDir(tmp.path()).filePath("Fake_backup.exe")));
    }

    void patchReplacesStaleBackup()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = fakeBuilds();
        const QString exe = QDir(tmp.path()).filePath("Fake.exe");
        const QString backup = QDir(tmp.path()).filePath("Fake_backup.exe");
        writeFile(exe, unpatchedBuf());
        writeFile(backup, QByteArray(16, '\x55'));

        const OpResult result = applyPatch(tmp.path(), discover(tmp.path(), builds)[0]);
        QVERIFY2(result.ok, qPrintable(result.report));
        QCOMPARE(readFile(backup), unpatchedBuf());
    }

    void patchLeavesNoTempFile()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = fakeBuilds();
        const QString exe = QDir(tmp.path()).filePath("Fake.exe");
        writeFile(exe, unpatchedBuf());

        const OpResult result = applyPatch(tmp.path(), discover(tmp.path(), builds)[0]);
        QVERIFY2(result.ok, qPrintable(result.report));
        QVERIFY(!QFile::exists(exe + ".patch.tmp"));
    }

    void unpatchRefusesWrongRecordedState()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = fakeBuilds();
        const QString exe = QDir(tmp.path()).filePath("Fake.exe");
        writeFile(exe, unpatchedBuf());

        Target target = discover(tmp.path(), builds)[0];
        const OpResult result = applyUnpatch(tmp.path(), target);
        QVERIFY(!result.ok);
        QVERIFY(result.report.contains("state"));
        QCOMPARE(readFile(exe), unpatchedBuf());
    }

    void unpatchRefusesFileChangedAfterDiscovery()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = fakeBuilds();
        const QString exe = QDir(tmp.path()).filePath("Fake.exe");
        writeFile(exe, unpatchedBuf());
        QVERIFY(applyPatch(tmp.path(), discover(tmp.path(), builds)[0]).ok);

        const Target target = discover(tmp.path(), builds)[0];
        QByteArray changed = readFile(exe);
        changed[4] = '\x77';
        writeFile(exe, changed);

        const OpResult result = applyUnpatch(tmp.path(), target);
        QVERIFY(!result.ok);
        QVERIFY(result.report.contains("changed"));
        QCOMPARE(readFile(exe), changed);
        QVERIFY(QFile::exists(QDir(tmp.path()).filePath("Fake_backup.exe")));
    }

    void unpatchRestoresBackupNotCurrentFile()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = fakeBuilds();
        const QString exe = QDir(tmp.path()).filePath("Fake.exe");
        writeFile(exe, unpatchedBuf());
        QVERIFY(applyPatch(tmp.path(), discover(tmp.path(), builds)[0]).ok);

        QByteArray patched = readFile(exe);
        patched[0] = '\x77';
        writeFile(exe, patched);

        const Target target = discover(tmp.path(), builds)[0];
        QCOMPARE(target.state, TargetState::Patched);
        const OpResult result = applyUnpatch(tmp.path(), target);
        QVERIFY2(result.ok, qPrintable(result.report));
        QCOMPARE(readFile(exe), unpatchedBuf());
    }

    void unpatchRefusesWrongLengthBackup()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = fakeBuilds();
        const QString exe = QDir(tmp.path()).filePath("Fake.exe");
        const QString backup = QDir(tmp.path()).filePath("Fake_backup.exe");
        writeFile(exe, unpatchedBuf());
        QVERIFY(applyPatch(tmp.path(), discover(tmp.path(), builds)[0]).ok);

        QByteArray bad = unpatchedBuf();
        bad.append('\0');
        writeFile(backup, bad);

        const OpResult result = applyUnpatch(tmp.path(), discover(tmp.path(), builds)[0]);
        QVERIFY(!result.ok);
        QVERIFY(result.report.contains("refusing to restore"));
        QVERIFY(QFile::exists(exe));
    }
};

QTEST_GUILESS_MAIN(TestFileOps)
#include "test_fileops.moc"

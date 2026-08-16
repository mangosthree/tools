#pragma once

#include <QByteArray>
#include <QString>
#include <QVector>
#include "PatchTable.h"

namespace patcher {

enum class TargetState { Unpatched, Patched, Mixed, Mismatch };

const BuildDef *identifyBuild(qint64 fileSize,
                              const QVector<BuildDef> &builds = knownBuilds());

struct ValidateResult
{
    TargetState state;
    QString report;
};

ValidateResult validate(const QByteArray &data, const BuildDef &def);

QByteArray buildCopy(const QByteArray &data, const BuildDef &def, bool wantPatched);

struct Target
{
    QString fileName;
    const BuildDef *def;
    TargetState state;
    QString report;
};

QVector<Target> discover(const QString &dir,
                         const QVector<BuildDef> &builds = knownBuilds());

struct OpResult
{
    bool ok;
    QString report;
};

OpResult applyPatch(const QString &dir, const Target &t);
OpResult applyUnpatch(const QString &dir, const Target &t);

} // namespace patcher

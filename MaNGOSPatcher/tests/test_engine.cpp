#include <QtTest>
#include "PatchEngine.h"
#include "testhelpers.h"

using namespace patcher;
using namespace patcher::test;

class TestEngine : public QObject
{
    Q_OBJECT
private slots:
    void identifyKnownSize()
    {
        const QVector<BuildDef> builds = fakeBuilds();
        const BuildDef *d = identifyBuild(16, builds);
        QVERIFY(d != nullptr);
        QCOMPARE(d->fileName, QString("Fake.exe"));
    }

    void identifyUnknownSize()
    {
        const QVector<BuildDef> builds = fakeBuilds();
        QVERIFY(identifyBuild(99, builds) == nullptr);
    }

    void identifyRealSizes()
    {
        QVERIFY(identifyBuild(10474064) != nullptr);
        QVERIFY(identifyBuild(13592144) != nullptr);
    }

    void validateUnpatched()
    {
        const QVector<BuildDef> builds = fakeBuilds();
        const ValidateResult r = validate(unpatchedBuf(), builds[0]);
        QCOMPARE(r.state, TargetState::Unpatched);
        QVERIFY(r.report.isEmpty());
    }

    void validatePatched()
    {
        const QVector<BuildDef> builds = fakeBuilds();
        QByteArray data = unpatchedBuf();
        data[4] = '\x90';
        data[5] = '\x90';
        data[10] = '\x00';
        const ValidateResult r = validate(data, builds[0]);
        QCOMPARE(r.state, TargetState::Patched);
        QVERIFY(r.report.isEmpty());
    }

    void validateMixed()
    {
        const QVector<BuildDef> builds = fakeBuilds();
        QByteArray data = unpatchedBuf();
        data[4] = '\x90';
        data[5] = '\x90';
        QCOMPARE(validate(data, builds[0]).state, TargetState::Mixed);
    }

    void validateOrdinaryMismatch()
    {
        const QVector<BuildDef> builds = fakeBuilds();
        QByteArray data = unpatchedBuf();
        data[4] = '\x77';
        const ValidateResult r = validate(data, builds[0]);
        QCOMPARE(r.state, TargetState::Mismatch);
        QVERIFY(r.report.contains("expected"));
    }

    void validateInvariantMismatchHasSpecificReport()
    {
        const QVector<BuildDef> builds = fakeBuilds();
        const ValidateResult r = validate(legacyWrongInvariantBuf(), builds[0]);
        QCOMPARE(r.state, TargetState::Mismatch);
        QVERIFY(r.report.contains("must remain unchanged"));
        QVERIFY(r.report.contains("0xc"));
    }

    void buildCopyChangesOnlyOrdinarySites()
    {
        const QVector<BuildDef> builds = fakeBuilds();
        const QByteArray original = unpatchedBuf();
        const QByteArray patched = buildCopy(original, builds[0], true);
        QCOMPARE(patched.size(), original.size());
        QCOMPARE(patched.mid(4, 2), QByteArray::fromHex("9090"));
        QCOMPARE(patched.mid(10, 1), QByteArray::fromHex("00"));
        QCOMPARE(patched.mid(12, 2), QByteArray::fromHex("A1B2"));
        QCOMPARE(patched[0], original[0]);
        QCOMPARE(patched[6], original[6]);
    }

    void buildCopyNeverWritesInvariant()
    {
        const QVector<BuildDef> builds = fakeBuilds();
        const QByteArray wrong = legacyWrongInvariantBuf();
        const QByteArray patched = buildCopy(wrong, builds[0], true);
        QCOMPARE(patched.mid(12, 2), QByteArray::fromHex("EE10"));
    }

    void buildCopyRejectsWrongLength()
    {
        const QVector<BuildDef> builds = fakeBuilds();
        QVERIFY(buildCopy(QByteArray(8, '\0'), builds[0], true).isEmpty());
    }

    void buildCopyRejectsOutOfBoundsDefinition()
    {
        BuildDef bad = fakeBuilds()[0];
        bad.sites.append({ 15, QByteArray::fromHex("AABB"), QByteArray::fromHex("9090") });
        QVERIFY(buildCopy(unpatchedBuf(), bad, true).isEmpty());
    }

    void buildCopyRoundTrip()
    {
        const QVector<BuildDef> builds = fakeBuilds();
        const QByteArray original = unpatchedBuf();
        const QByteArray patched = buildCopy(original, builds[0], true);
        QVERIFY(patched != original);
        QCOMPARE(buildCopy(patched, builds[0], false), original);
    }
};

QTEST_APPLESS_MAIN(TestEngine)
#include "test_engine.moc"


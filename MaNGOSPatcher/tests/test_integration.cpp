#include <QtTest>
#include <QDir>
#include <QFile>
#include <QFileInfo>
#include "PatchEngine.h"

using namespace patcher;

namespace {

QString fixtureRoot()
{
    return qEnvironmentVariable("MANGOSPATCHER_CLIENT_FIXTURE_DIR");
}

bool fixturesRequired()
{
    return qEnvironmentVariable("MANGOSPATCHER_REQUIRE_FIXTURES") == "1";
}

QString fixturePath(const BuildDef &def)
{
    return QDir(fixtureRoot()).filePath(def.fileName);
}

QByteArray readFixture(const BuildDef &def)
{
    QFile file(fixturePath(def));
    if (!file.open(QIODevice::ReadOnly))
    {
        return {};
    }
    const QByteArray data = file.readAll();
    file.close();
    return data;
}

void addBuildRows()
{
    for (int i = 0; i < knownBuilds().size(); ++i)
    {
        QTest::newRow(qPrintable(knownBuilds()[i].fileName)) << i;
    }
}

bool requireOrSkipFixture(const BuildDef &def)
{
    const QString root = fixtureRoot();
    const QString path = fixturePath(def);
    if (!root.isEmpty() && QFileInfo::exists(path))
    {
        return true;
    }

    const QString message = root.isEmpty()
        ? QString("MANGOSPATCHER_CLIENT_FIXTURE_DIR is not set")
        : QString("fixture is missing: %1").arg(path);

    if (fixturesRequired())
    {
        QTest::qFail(qPrintable(message), __FILE__, __LINE__);
    }
    else
    {
        QTest::qSkip(qPrintable(message), __FILE__, __LINE__);
    }
    return false;
}

QVector<qint64> expectedChangedOffsets(const QString &fileName)
{
    if (fileName == "Wow.exe")
    {
        return {
            0x737A, 0x737B, 0x737C, 0x737D, 0x737E,
            0x883AE,
            0x889CA, 0x889CB, 0x889CC, 0x889CD, 0x889CE, 0x889CF, 0x889D0
        };
    }

    return {
        0xA9FAB,
        0xAAB6F, 0xAAB70,
        0xAAB71, 0xAAB72, 0xAAB73
    };
}

} // namespace

class TestIntegration : public QObject
{
    Q_OBJECT
private slots:
    void tableMatchesRealClient_data()
    {
        QTest::addColumn<int>("buildIndex");
        addBuildRows();
    }

    void tableMatchesRealClient()
    {
        QFETCH(int, buildIndex);
        const BuildDef &def = knownBuilds()[buildIndex];
        if (!requireOrSkipFixture(def))
        {
            return;
        }

        const QByteArray data = readFixture(def);
        QVERIFY2(!data.isEmpty(), qPrintable(def.fileName + ": fixture is unreadable"));
        QCOMPARE(qint64(data.size()), def.exeLength);
        QCOMPARE(identifyBuild(data.size()), &def);

        const ValidateResult result = validate(data, def);
        QVERIFY2(result.state == TargetState::Unpatched,
                 qPrintable(def.fileName + ": clean fixture did not validate as Unpatched\n"
                            + result.report));
    }

    void exactPatchDeltaAndRoundTrip_data()
    {
        QTest::addColumn<int>("buildIndex");
        addBuildRows();
    }

    void exactPatchDeltaAndRoundTrip()
    {
        QFETCH(int, buildIndex);
        const BuildDef &def = knownBuilds()[buildIndex];
        if (!requireOrSkipFixture(def))
        {
            return;
        }

        const QByteArray original = readFixture(def);
        QVERIFY(!original.isEmpty());

        const QByteArray patched = buildCopy(original, def, true);
        QCOMPARE(patched.size(), original.size());
        QCOMPARE(validate(patched, def).state, TargetState::Patched);

        QVector<qint64> actualChanges;
        for (qint64 offset = 0; offset < original.size(); ++offset)
        {
            if (original[offset] != patched[offset])
            {
                actualChanges.append(offset);
            }
        }
        QCOMPARE(actualChanges, expectedChangedOffsets(def.fileName));

        for (const PatchSite &site : def.sites)
        {
            if (site.mustRemainUnchanged)
            {
                QCOMPARE(patched.mid(site.offset, site.unpatched.size()), site.unpatched);
            }
            else
            {
                QCOMPARE(patched.mid(site.offset, site.patched.size()), site.patched);
            }
        }

        QCOMPARE(buildCopy(patched, def, false), original);
    }
};

QTEST_GUILESS_MAIN(TestIntegration)
#include "test_integration.moc"

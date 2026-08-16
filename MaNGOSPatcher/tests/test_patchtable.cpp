#include <QtTest>
#include "PatchTable.h"

using namespace patcher;

class TestPatchTable : public QObject
{
    Q_OBJECT
private slots:
    void hasTwoBuilds()
    {
        QCOMPARE(knownBuilds().size(), 2);
    }

    void x86DefinitionMatchesVerifiedClient()
    {
        const BuildDef &b = knownBuilds()[0];
        QCOMPARE(b.name, QString("Cata 4.3.4.15595 (x86)"));
        QCOMPARE(b.fileName, QString("Wow.exe"));
        QCOMPARE(b.exeLength, qint64(10474064));
        QCOMPARE(b.sites.size(), 3);

        QCOMPARE(b.sites[0].offset, qint64(0x737A));
        QCOMPARE(b.sites[0].unpatched, QByteArray::fromHex("E8B1EDFFFF"));
        QCOMPARE(b.sites[0].patched, QByteArray::fromHex("B801000000"));
        QCOMPARE(b.sites[1].offset, qint64(0x889CA));
        QCOMPARE(b.sites[1].unpatched, QByteArray::fromHex("8B550C83FA0275"));
        QCOMPARE(b.sites[1].patched, QByteArray::fromHex("BA0000000090EB"));
        QCOMPARE(b.sites[2].offset, qint64(0x883AE));
        QCOMPARE(b.sites[2].unpatched, QByteArray::fromHex("74"));
        QCOMPARE(b.sites[2].patched, QByteArray::fromHex("EB"));
    }

    void x64DefinitionMatchesVerifiedClient()
    {
        const BuildDef &b = knownBuilds()[1];
        QCOMPARE(b.name, QString("Cata 4.3.4.15595 (x64)"));
        QCOMPARE(b.fileName, QString("Wow-64.exe"));
        QCOMPARE(b.exeLength, qint64(13592144));
        QCOMPARE(b.sites.size(), 4);

        QCOMPARE(b.sites[0].offset, qint64(0xAAB6F));
        QCOMPARE(b.sites[0].unpatched, QByteArray::fromHex("7408"));
        QCOMPARE(b.sites[0].patched, QByteArray::fromHex("9090"));
        QCOMPARE(b.sites[1].offset, qint64(0xAAB71));
        QCOMPARE(b.sites[1].unpatched, QByteArray::fromHex("418BD5"));
        QCOMPARE(b.sites[1].patched, QByteArray::fromHex("31D290"));
        QCOMPARE(b.sites[2].offset, qint64(0xA9FAB));
        QCOMPARE(b.sites[2].unpatched, QByteArray::fromHex("741A"));
        QCOMPARE(b.sites[2].patched, QByteArray::fromHex("EB1A"));
        QCOMPARE(b.sites[3].offset, qint64(0xA9AD3));
        QCOMPARE(b.sites[3].unpatched, QByteArray::fromHex("7410"));
        QCOMPARE(b.sites[3].patched, QByteArray::fromHex("7410"));
        QVERIFY(b.sites[3].mustRemainUnchanged);
    }

    void everySiteIsWellFormedAndInBounds()
    {
        int invariantCount = 0;
        for (const BuildDef &b : knownBuilds())
        {
            for (const PatchSite &s : b.sites)
            {
                QVERIFY(s.offset >= 0);
                QVERIFY(!s.unpatched.isEmpty());
                QCOMPARE(s.unpatched.size(), s.patched.size());
                QVERIFY(s.offset + s.unpatched.size() <= b.exeLength);
                if (s.mustRemainUnchanged)
                {
                    ++invariantCount;
                    QCOMPARE(s.unpatched, s.patched);
                }
                else
                {
                    QVERIFY(s.unpatched != s.patched);
                }
            }
        }
        QCOMPARE(invariantCount, 1);
    }

    void sitesDoNotOverlap()
    {
        for (const BuildDef &b : knownBuilds())
        {
            for (int i = 0; i < b.sites.size(); ++i)
            {
                for (int j = i + 1; j < b.sites.size(); ++j)
                {
                    const PatchSite &a = b.sites[i];
                    const PatchSite &c = b.sites[j];
                    const bool disjoint = a.offset + a.unpatched.size() <= c.offset
                                          || c.offset + c.unpatched.size() <= a.offset;
                    QVERIFY2(disjoint, qPrintable(QString("%1: sites at 0x%2 and 0x%3 overlap")
                                                      .arg(b.fileName)
                                                      .arg(a.offset, 0, 16)
                                                      .arg(c.offset, 0, 16)));
                }
            }
        }
    }
};

QTEST_APPLESS_MAIN(TestPatchTable)
#include "test_patchtable.moc"


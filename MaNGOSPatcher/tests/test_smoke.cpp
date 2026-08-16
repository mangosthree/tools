#include <QtTest>

class TestSmoke : public QObject
{
    Q_OBJECT
private slots:
    void toolchainWorks()
    {
        QCOMPARE(1 + 1, 2);
    }
};

QTEST_APPLESS_MAIN(TestSmoke)
#include "test_smoke.moc"


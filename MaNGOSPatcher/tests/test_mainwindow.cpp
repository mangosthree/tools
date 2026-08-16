#include <QtTest>
#include <QDir>
#include <QFile>
#include <QLabel>
#include <QPlainTextEdit>
#include <QPushButton>
#include <QTemporaryDir>
#include "MainWindow.h"
#include "testhelpers.h"

using namespace patcher;
using namespace patcher::test;

namespace {

QVector<BuildDef> twoBuilds()
{
    BuildDef first = fakeBuilds()[0];
    first.name = "Fake x86";
    first.fileName = "Client32.exe";

    BuildDef second = fakeBuilds()[0];
    second.name = "Fake x64";
    second.fileName = "Client64.exe";
    return { first, second };
}

QPushButton *actionButton(MainWindow &window)
{
    return window.findChild<QPushButton *>();
}

QPlainTextEdit *logWidget(MainWindow &window)
{
    return window.findChild<QPlainTextEdit *>();
}

bool hasStatus(MainWindow &window, const QString &text)
{
    for (QLabel *label : window.findChildren<QLabel *>())
    {
        if (label->text() == text)
        {
            return true;
        }
    }
    return false;
}

} // namespace

class TestMainWindow : public QObject
{
    Q_OBJECT
private slots:
    void showsPatchWhenOnlyTargetIsUnpatched()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = fakeBuilds();
        writeFile(QDir(tmp.path()).filePath("Fake.exe"), unpatchedBuf());

        MainWindow window(tmp.path(), builds);
        QPushButton *button = actionButton(window);
        QVERIFY(button != nullptr);
        QCOMPARE(button->text(), QString("Patch"));
        QVERIFY(button->isEnabled());
    }

    void clickPatchesAndFlipsToUnpatch()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = fakeBuilds();
        writeFile(QDir(tmp.path()).filePath("Fake.exe"), unpatchedBuf());

        MainWindow window(tmp.path(), builds);
        QPushButton *button = actionButton(window);
        QTest::mouseClick(button, Qt::LeftButton);

        QVERIFY(QFile::exists(QDir(tmp.path()).filePath("Fake_backup.exe")));
        QCOMPARE(button->text(), QString("Unpatch"));
        QVERIFY(hasStatus(window, "Success!"));
    }

    void operationReportSurvivesRefresh()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = fakeBuilds();
        writeFile(QDir(tmp.path()).filePath("Fake.exe"), unpatchedBuf());

        MainWindow window(tmp.path(), builds);
        QTest::mouseClick(actionButton(window), Qt::LeftButton);

        QPlainTextEdit *log = logWidget(window);
        QVERIFY(log != nullptr);
        QVERIFY(log->toPlainText().contains("backup:"));
    }

    void unpatchedTargetCannotHideInvariantMismatch()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = twoBuilds();
        const QString validPath = QDir(tmp.path()).filePath("Client32.exe");
        writeFile(validPath, unpatchedBuf());
        writeFile(QDir(tmp.path()).filePath("Client64.exe"), legacyWrongInvariantBuf());

        MainWindow window(tmp.path(), builds);
        QPushButton *button = actionButton(window);
        QVERIFY(!button->isEnabled());
        QVERIFY(hasStatus(window, "Mismatch"));

        const QString text = logWidget(window)->toPlainText();
        QVERIFY(text.contains("blocked"));
        QVERIFY(text.contains("clean backup"));
        QVERIFY(!text.contains("Ready to patch"));

        // The slot independently enforces the block even if UI state is forced.
        button->setEnabled(true);
        QVERIFY(QMetaObject::invokeMethod(&window, "onActionClicked"));
        QCOMPARE(readFile(validPath), unpatchedBuf());
        QVERIFY(!QFile::exists(QDir(tmp.path()).filePath("Client32_backup.exe")));
    }

    void patchedTargetCannotHideInvariantMismatch()
    {
        QTemporaryDir tmp;
        const QVector<BuildDef> builds = twoBuilds();
        const QString validPath = QDir(tmp.path()).filePath("Client32.exe");
        const QString backupPath = QDir(tmp.path()).filePath("Client32_backup.exe");
        writeFile(validPath, buildCopy(unpatchedBuf(), builds[0], true));
        writeFile(backupPath, unpatchedBuf());
        writeFile(QDir(tmp.path()).filePath("Client64.exe"), legacyWrongInvariantBuf());

        MainWindow window(tmp.path(), builds);
        QPushButton *button = actionButton(window);
        QVERIFY(!button->isEnabled());
        QVERIFY(hasStatus(window, "Mismatch"));

        const QString text = logWidget(window)->toPlainText();
        QVERIFY(!text.contains("All binaries already patched"));
        QVERIFY(text.contains("clean backup"));

        button->setText("Unpatch");
        button->setEnabled(true);
        QVERIFY(QMetaObject::invokeMethod(&window, "onActionClicked"));
        QCOMPARE(readFile(validPath), buildCopy(unpatchedBuf(), builds[0], true));
        QVERIFY(QFile::exists(backupPath));
    }
};

QTEST_MAIN(TestMainWindow)
#include "test_mainwindow.moc"

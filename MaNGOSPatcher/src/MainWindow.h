#pragma once

#include <QMainWindow>
#include <QVector>
#include "PatchEngine.h"

class QPlainTextEdit;
class QLabel;
class QPushButton;

namespace patcher {

class MainWindow : public QMainWindow
{
    Q_OBJECT
public:
    explicit MainWindow(QWidget *parent = nullptr); // app dir + knownBuilds()
    MainWindow(const QString &dir, const QVector<BuildDef> &builds,
               QWidget *parent = nullptr);           // injected (tests)

private slots:
    void onActionClicked();

private:
    void buildUi();
    void refresh();
    void log(const QString &line);

    QPlainTextEdit *m_log = nullptr;
    QLabel *m_statusValue = nullptr;
    QPushButton *m_button = nullptr;

    QString m_dir;
    const QVector<BuildDef> *m_builds;
};

} // namespace patcher

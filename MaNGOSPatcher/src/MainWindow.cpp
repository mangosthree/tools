#include "MainWindow.h"

#include <QCoreApplication>
#include <QFileInfo>
#include <QGroupBox>
#include <QHBoxLayout>
#include <QLabel>
#include <QPlainTextEdit>
#include <QPushButton>
#include <QStringList>
#include <QVBoxLayout>
#include <QWidget>
#include <utility>

namespace patcher {
namespace {

bool hasBlockedTarget(const QVector<Target> &targets)
{
    for (const Target &target : targets)
    {
        if (target.state == TargetState::Mixed
            || target.state == TargetState::Mismatch)
        {
            return true;
        }
    }
    return false;
}

QString backupName(const QString &fileName)
{
    const QFileInfo info(fileName);
    return info.completeBaseName() + "_backup." + info.suffix();
}

} // namespace

MainWindow::MainWindow(QWidget *parent)
    : MainWindow(QCoreApplication::applicationDirPath(), knownBuilds(), parent)
{
}

MainWindow::MainWindow(const QString &dir, QVector<BuildDef> builds, QWidget *parent)
    : QMainWindow(parent), m_dir(dir), m_builds(std::move(builds))
{
    buildUi();
    refresh();
}

void MainWindow::buildUi()
{
    auto *central = new QWidget(this);
    auto *outer = new QVBoxLayout(central);

    auto *group = new QGroupBox(tr("Log"), central);
    auto *groupLayout = new QVBoxLayout(group);
    m_log = new QPlainTextEdit(group);
    m_log->setReadOnly(true);
    groupLayout->addWidget(m_log);
    outer->addWidget(group);

    auto *row = new QHBoxLayout();
    row->addWidget(new QLabel(tr("Status:"), central));
    m_statusValue = new QLabel(tr("Loading..."), central);
    row->addWidget(m_statusValue);
    row->addStretch();

    m_button = new QPushButton(tr("Patch"), central);
    m_button->setEnabled(false);
    m_button->setMinimumWidth(90);
    connect(m_button, &QPushButton::clicked, this, &MainWindow::onActionClicked);
    row->addWidget(m_button);
    outer->addLayout(row);

    setCentralWidget(central);
    setWindowTitle(tr("MaNGOS 4.3.4 Patcher"));
    resize(460, 280);
}

void MainWindow::log(const QString &line)
{
    m_log->appendPlainText(line);
}

void MainWindow::refresh()
{
    m_log->clear();
    const QVector<Target> targets = discover(m_dir, m_builds);

    if (targets.isEmpty())
    {
        log(tr("No Wow.exe / Wow-64.exe found in this folder."));
        log(tr("Place this program in your WoW directory and make sure WoW is closed."));
        m_statusValue->setText(tr("Error"));
        m_statusValue->setStyleSheet("color: red;");
        m_button->setEnabled(false);
        return;
    }

    bool anyUnpatched = false;
    bool anyPatched = false;
    bool anyBlocked = false;

    for (const Target &target : targets)
    {
        switch (target.state)
        {
            case TargetState::Unpatched:
                log(tr("Loaded %1 - ready to patch").arg(target.fileName));
                anyUnpatched = true;
                break;

            case TargetState::Patched:
                log(tr("Loaded %1 - already patched").arg(target.fileName));
                anyPatched = true;
                break;

            case TargetState::Mixed:
                anyBlocked = true;
                log(tr("%1 - blocked: partially patched or modified").arg(target.fileName));
                if (!target.report.trimmed().isEmpty())
                {
                    log(target.report.trimmed());
                }
                log(tr("Restore a clean backup (%1) or replace the executable with a verified clean copy.")
                        .arg(backupName(target.fileName)));
                break;

            case TargetState::Mismatch:
                anyBlocked = true;
                log(tr("%1 - blocked: unsupported, unreadable, or modified").arg(target.fileName));
                if (!target.report.trimmed().isEmpty())
                {
                    log(target.report.trimmed());
                }
                log(tr("Restore a clean backup (%1) or replace the executable with a verified clean copy.")
                        .arg(backupName(target.fileName)));
                break;
        }
    }

    if (anyBlocked)
    {
        log(tr("Operation blocked: no executable will be changed while any target is invalid."));
        m_statusValue->setText(tr("Mismatch"));
        m_statusValue->setStyleSheet("color: red;");
        m_button->setEnabled(false);
        return;
    }

    if (!anyUnpatched && !anyPatched)
    {
        m_statusValue->setText(tr("Mismatch"));
        m_statusValue->setStyleSheet("color: red;");
        m_button->setEnabled(false);
        return;
    }

    m_statusValue->setText(tr("Ready!"));
    m_statusValue->setStyleSheet("color: orange;");
    m_button->setEnabled(true);

    if (anyUnpatched)
    {
        m_button->setText(tr("Patch"));
        log(tr("Ready to patch."));
    }
    else
    {
        m_button->setText(tr("Unpatch"));
        log(tr("All binaries already patched. Click Unpatch to restore."));
    }
}

void MainWindow::onActionClicked()
{
    const QVector<Target> targets = discover(m_dir, m_builds);
    if (hasBlockedTarget(targets))
    {
        refresh();
        log(tr("Operation blocked before changes were made."));
        return;
    }

    const bool isPatch = (m_button->text() == tr("Patch"));
    bool ok = true;
    bool acted = false;
    QStringList reports;

    for (const Target &target : targets)
    {
        if (isPatch && target.state == TargetState::Unpatched)
        {
            const OpResult result = applyPatch(m_dir, target);
            reports << result.report.trimmed();
            ok = ok && result.ok;
            acted = true;
        }
        else if (!isPatch && target.state == TargetState::Patched)
        {
            const OpResult result = applyUnpatch(m_dir, target);
            reports << result.report.trimmed();
            ok = ok && result.ok;
            acted = true;
        }
    }

    refresh();
    for (const QString &report : reports)
    {
        if (!report.isEmpty())
        {
            log(report);
        }
    }

    if (acted)
    {
        const bool blockedAfter = hasBlockedTarget(discover(m_dir, m_builds));
        const bool success = ok && !blockedAfter;
        m_statusValue->setText(success ? tr("Success!") : tr("Error!"));
        m_statusValue->setStyleSheet(success ? "color: green;" : "color: red;");
    }
}

} // namespace patcher

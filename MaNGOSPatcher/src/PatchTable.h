#pragma once

#include <QByteArray>
#include <QString>
#include <QVector>

namespace patcher {

struct PatchSite
{
    qint64 offset;
    QByteArray unpatched;
    QByteArray patched;
    bool mustRemainUnchanged = false;
};

struct BuildDef
{
    QString name;
    QString fileName;
    qint64 exeLength;
    QVector<PatchSite> sites;
};

// Verified against clean Cata 4.3.4.15595 x86 and x64 executables on
// 2026-08-16. Offsets are file offsets, not virtual addresses.
//
// The three x86 ranges were also checked at instruction level:
//   0x737A  complete 5-byte call -> mov eax,1
//   0x889CA mov edx,[ebp+0xC]; cmp edx,2; conditional-branch opcode
//   0x883AE conditional-branch opcode
//
// The x64 inbound gate is 0xA9FAB. An earlier patcher incorrectly changed
// 0xA9AD3 instead. That obsolete location is represented as an invariant so a
// legacy-damaged executable is rejected and is never silently reconstructed.
inline const QVector<BuildDef> &knownBuilds()
{
    static const QVector<BuildDef> builds = {
        { "Cata 4.3.4.15595 (x86)", "Wow.exe", 10474064,
          {
              // Preserve the established launcher/manifest bypass.
              { 0x737A,  QByteArray::fromHex("E8B1EDFFFF"),
                         QByteArray::fromHex("B801000000") },

              // Force outbound traffic to connection slot zero.
              { 0x889CA, QByteArray::fromHex("8B550C83FA0275"),
                         QByteArray::fromHex("BA0000000090EB") },

              // Bypass the inbound connection-slot-one dispatch gate.
              { 0x883AE, QByteArray::fromHex("74"),
                         QByteArray::fromHex("EB") },
          } },
        { "Cata 4.3.4.15595 (x64)", "Wow-64.exe", 13592144,
          {
              // Enter the outbound type-zero path.
              { 0xAAB6F, QByteArray::fromHex("7408"),
                         QByteArray::fromHex("9090") },

              // Force the selected outbound slot to zero.
              { 0xAAB71, QByteArray::fromHex("418BD5"),
                         QByteArray::fromHex("31D290") },

              // Correct inbound connection-slot-one dispatch gate.
              { 0xA9FAB, QByteArray::fromHex("741A"),
                         QByteArray::fromHex("EB1A") },

              // Must remain clean. EB 10 here identifies the faulty legacy edit.
              { 0xA9AD3, QByteArray::fromHex("7410"),
                         QByteArray::fromHex("7410"), true },
          } },
    };
    return builds;
}

} // namespace patcher


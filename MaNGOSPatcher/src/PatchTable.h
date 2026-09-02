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
    bool legacyUsesPatched = false;
};

struct BuildDef
{
    QString name;
    QString fileName;
    qint64 exeLength;
    QVector<PatchSite> sites;
    bool supportsLegacyPatched = false;
};

// Verified against clean Cata 4.3.4.15595 x86 and x64 executables through
// 2026-09-02. Offsets are file offsets, not virtual addresses.
//
// The four mutable x86 ranges and adapter target were checked at instruction
// level:
//   0x737A  complete 5-byte call -> mov eax,1
//   0x889CA mov edx,[ebp+0xC]; cmp edx,2; conditional-branch opcode
//   0x883AE conditional-branch opcode
//   0x3BF388 five-argument stdcall adapter in executable alignment padding
//   0x3A5950 four-argument sequential archive-reader target prologue
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
                         QByteArray::fromHex("B801000000"), false, true },

              // Force outbound traffic to connection slot zero.
              { 0x889CA, QByteArray::fromHex("8B550C83FA0275"),
                         QByteArray::fromHex("BA0000000090EB"), false, true },

              // Bypass the inbound connection-slot-one dispatch gate.
              { 0x883AE, QByteArray::fromHex("74"),
                         QByteArray::fromHex("EB"), false, true },

              // Adapt the signed Warden module's five-argument file-read ABI
              // to the client's four-argument sequential archive reader.
              { 0x3BF388,
                         QByteArray::fromHex(
                             "CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC"),
                         QByteArray::fromHex(
                             "558BECFF7514FF7510FF750CFF7508E8B465FEFF5DC21400") },

              // The adapter above calls this exact archive-reader entry point.
              // Pin its prologue so the relative call is never installed into
              // a same-sized executable with a different text layout.
              { 0x3A5950,
                         QByteArray::fromHex("558BEC8B45148B4D0C8B5508"),
                         QByteArray::fromHex("558BEC8B45148B4D0C8B5508"),
                         true },
          }, true },
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

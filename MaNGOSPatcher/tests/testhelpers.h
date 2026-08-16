#pragma once

#include <QByteArray>
#include <QFile>
#include <QVector>
#include "PatchTable.h"

namespace patcher {
namespace test {

// A small synthetic build so core tests never touch a real client. The two
// ordinary sites are at 4 (2 bytes) and 10 (1 byte); offset 12 is an invariant.
inline QVector<BuildDef> fakeBuilds()
{
    return {
        { "Fake", "Fake.exe", 16,
          {
              { 4,  QByteArray::fromHex("AABB"), QByteArray::fromHex("9090") },
              { 10, QByteArray::fromHex("CC"),   QByteArray::fromHex("00") },
              { 12, QByteArray::fromHex("A1B2"), QByteArray::fromHex("A1B2"), true },
          } },
    };
}

inline QByteArray unpatchedBuf()
{
    QByteArray b(16, '\x11');
    b[4] = '\xAA';
    b[5] = '\xBB';
    b[10] = '\xCC';
    b[12] = '\xA1';
    b[13] = '\xB2';
    return b;
}

inline QByteArray legacyWrongInvariantBuf()
{
    QByteArray b = unpatchedBuf();
    b[12] = '\xEE';
    b[13] = '\x10';
    return b;
}

inline void writeFile(const QString &path, const QByteArray &data)
{
    QFile f(path);
    if (!f.open(QIODevice::WriteOnly))
    {
        qFatal("could not open test file for writing");
    }
    if (f.write(data) != data.size())
    {
        qFatal("could not write complete test file");
    }
    f.close();
}

inline QByteArray readFile(const QString &path)
{
    QFile f(path);
    if (!f.open(QIODevice::ReadOnly))
    {
        qFatal("could not open test file for reading");
    }
    const QByteArray data = f.readAll();
    f.close();
    return data;
}

} // namespace test
} // namespace patcher

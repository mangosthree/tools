# MaNGOS Three 4.3.4 Connection Patcher (Qt)

MaNGOSPatcher is a Qt 6 desktop tool for clean Windows executables from World
of Warcraft Cataclysm 4.3.4.15595:

- `Wow.exe` - 10,474,064 bytes
- `Wow-64.exe` - 13,592,144 bytes

It applies the verified client compatibility and connection-routing edits used
with MaNGOS Three. Both executable sizes and every patch site are checked
before a file is changed.

## File safety

Patching is transactional:

1. The complete patched image is prepared in a temporary file.
2. The original is moved to `Wow_backup.exe` or `Wow-64_backup.exe`.
3. The completed image is installed.
4. A failed install rolls the original back into place.

Unpatch restores the validated clean backup; it does not reconstruct an
original from the live executable. The executable is re-read and its state is
checked immediately before every patch or restore operation.

If either discovered executable is partially patched, modified, unreadable, or
an unsupported size, all actions are blocked. A valid 32-bit client can never
hide a bad 64-bit client.

### Earlier faulty 64-bit patch

An earlier patcher changed `Wow-64.exe` at file offset `0xA9AD3`. That byte
range must remain `74 10`; the corrected inbound patch is at `0xA9FAB`.

The Qt patcher deliberately refuses an executable containing the old edit. It
does not guess that the rest of the file is clean or silently repair Blizzard
binaries. Restore a verified clean `Wow-64_backup.exe`, or obtain a verified
clean 4.3.4.15595 executable, and then run the patcher again.

## Prerequisites

- Qt 6 (developed and packaged with 6.10.1, `msvc2022_64`)
- CMake 3.21 or newer
- Visual Studio 2026 or 2022 with the C++ toolset

The patcher application is built as x64, but ordinary file operations let it
patch both the x86 and x64 WoW executables.

## Build and test

From this directory:

```powershell
cmake -S . -B build -G "Visual Studio 18 2026" -A x64 `
  -DCMAKE_PREFIX_PATH=C:\Qt\6.10.1\msvc2022_64 `
  -DMANGOSPATCHER_BUILD_TESTS=ON
cmake --build build --config Release
ctest --test-dir build -C Release --output-on-failure
```

Use `Visual Studio 17 2022` when building with Visual Studio 2022. The test
targets stage their required Qt DLLs beside the executables, so CTest does not
require a manually modified `PATH`. The GUI suite runs with the offscreen Qt
platform.

A normal build automatically refreshes a deployable
`MaNGOSPatcher_install` folder beside the build directory. It contains
`MaNGOSPatcher.exe`, the trimmed Qt runtime, and
`platforms/qwindows.dll`. Copy the whole folder into the WoW directory.

## Real-client verification

The committed test suite never contains or modifies client executables.
Synthetic tests always run. Authorized clean fixtures are selected at runtime:

```powershell
$env:MANGOSPATCHER_CLIENT_FIXTURE_DIR = 'D:\path\to\clean-fixtures'
$env:MANGOSPATCHER_REQUIRE_FIXTURES = '1'
ctest --test-dir build -C Release -R test_integration --output-on-failure
```

The fixture directory must contain clean `Wow.exe` and `Wow-64.exe`.
When `MANGOSPATCHER_REQUIRE_FIXTURES=1`, either missing fixture fails the
release gate. Without that flag, proprietary fixtures are independently
skipped.

The integration suite verifies the clean sizes and bytes, compares the whole
patched buffer, confirms only the exact declared bytes changed, proves the
legacy x64 offset stayed untouched, and checks a byte-identical in-memory round
trip.

## Usage

1. Copy the complete installed folder into a clean 4.3.4.15595 client.
2. Close WoW.
3. Run `MaNGOSPatcher.exe`.
4. Review both detected executable states.
5. Click **Patch**, or **Unpatch** to restore validated backups.

Do not copy only the patcher executable: the Qt DLLs and `platforms` folder
are required. Blizzard executables and test fixtures are not distributed by
this project.

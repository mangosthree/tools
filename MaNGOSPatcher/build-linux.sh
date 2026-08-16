#!/usr/bin/env bash

set -Eeuo pipefail

source_dir="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd -P)"
build_dir="${MANGOSPATCHER_BUILD_DIR:-${source_dir}/build-linux}"
install_dir="${MANGOSPATCHER_INSTALL_DIR:-${source_dir}/install-linux}"
build_type="${MANGOSPATCHER_BUILD_TYPE:-Release}"

printf 'Configuring MaNGOSPatcher (%s)...\n' "${build_type}"
cmake \
    -S "${source_dir}" \
    -B "${build_dir}" \
    -G Ninja \
    "-DCMAKE_BUILD_TYPE=${build_type}" \
    "-DCMAKE_INSTALL_PREFIX=${install_dir}" \
    -DMANGOSPATCHER_BUILD_TESTS=ON

printf 'Building MaNGOSPatcher...\n'
cmake --build "${build_dir}" --parallel

printf 'Running MaNGOSPatcher tests...\n'
QT_QPA_PLATFORM=offscreen ctest \
    --test-dir "${build_dir}" \
    --no-tests=error \
    --output-on-failure

printf 'Installing MaNGOSPatcher to %s...\n' "${install_dir}"
cmake --install "${build_dir}"

printf 'Linux source build complete: %s\n' "${install_dir}"

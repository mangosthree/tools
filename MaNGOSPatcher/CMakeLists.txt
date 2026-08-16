cmake_minimum_required(VERSION 3.21)
project(MaNGOSPatcher LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

option(MANGOSPATCHER_BUILD_TESTS "Build the Qt Test suites" OFF)

set(_mp_qt_components Widgets)
if(MANGOSPATCHER_BUILD_TESTS)
    list(APPEND _mp_qt_components Test)
endif()
find_package(Qt6 REQUIRED COMPONENTS ${_mp_qt_components})
qt_standard_project_setup()

add_library(patchcore STATIC
    src/PatchEngine.cpp
    src/PatchEngine.h
    src/PatchTable.h)
target_include_directories(patchcore PUBLIC src)
target_link_libraries(patchcore PUBLIC Qt6::Core)

add_library(patchgui STATIC
    src/MainWindow.cpp
    src/MainWindow.h)
target_include_directories(patchgui PUBLIC src)
target_link_libraries(patchgui PUBLIC patchcore Qt6::Widgets)

qt_add_executable(MaNGOSPatcher WIN32 src/main.cpp)
target_link_libraries(MaNGOSPatcher PRIVATE patchgui)

if(WIN32)
    enable_language(RC)
    target_sources(MaNGOSPatcher PRIVATE src/MaNGOSPatcher.rc)
endif()

if(MANGOSPATCHER_BUILD_TESTS)
    enable_testing()
    add_subdirectory(tests)
endif()

find_program(WINDEPLOYQT_EXE windeployqt
    HINTS "${CMAKE_PREFIX_PATH}/bin" "${Qt6_DIR}/../../../bin")

# Keep a runnable copy in the build tree for local development.
if(WINDEPLOYQT_EXE)
    add_custom_command(TARGET MaNGOSPatcher POST_BUILD
        COMMAND "${WINDEPLOYQT_EXE}"
                --no-translations
                --no-compiler-runtime
                "$<TARGET_FILE:MaNGOSPatcher>"
        COMMENT "Deploying Qt runtime beside MaNGOSPatcher.exe"
        VERBATIM)
endif()

if(CMAKE_INSTALL_PREFIX_INITIALIZED_TO_DEFAULT)
    get_filename_component(_mp_build_parent "${CMAKE_BINARY_DIR}" DIRECTORY)
    set(CMAKE_INSTALL_PREFIX "${_mp_build_parent}/MaNGOSPatcher_install"
        CACHE PATH "Deployable MaNGOSPatcher directory" FORCE)
endif()

install(TARGETS MaNGOSPatcher RUNTIME DESTINATION .)

# Bundle the MSVC runtime explicitly. windeployqt cannot reliably find it from
# a Visual Studio POST_BUILD command because VCINSTALLDIR is not inherited.
if(MSVC)
    set(CMAKE_INSTALL_SYSTEM_RUNTIME_DESTINATION .)
    include(InstallRequiredSystemLibraries)
endif()

# The application uses Qt Core/Gui/Widgets only. Install the executable and a
# minimal Windows runtime that can be copied as one folder into the WoW client.
if(WINDEPLOYQT_EXE)
    install(CODE "
        message(STATUS \"Deploying Qt runtime into \${CMAKE_INSTALL_PREFIX}\")
        execute_process(
            COMMAND \"${WINDEPLOYQT_EXE}\"
                    --no-translations
                    --no-compiler-runtime
                    --no-opengl-sw
                    --no-system-d3d-compiler
                    --skip-plugin-types generic,iconengines,imageformats,networkinformation,tls,styles
                    \"\${CMAKE_INSTALL_PREFIX}/MaNGOSPatcher.exe\"
            RESULT_VARIABLE _mp_deploy_result)
        if(NOT _mp_deploy_result EQUAL 0)
            message(FATAL_ERROR \"windeployqt failed with exit code \${_mp_deploy_result}\")
        endif()
        file(REMOVE
            \"\${CMAKE_INSTALL_PREFIX}/dxcompiler.dll\"
            \"\${CMAKE_INSTALL_PREFIX}/dxil.dll\"
            \"\${CMAKE_INSTALL_PREFIX}/opengl32sw.dll\"
            \"\${CMAKE_INSTALL_PREFIX}/D3Dcompiler_47.dll\")
    ")
endif()

# Refresh the deployable folder whenever the application is built. An explicit
# cmake --install remains supported and is used again by AppVeyor before zipping.
set(_mp_install_command "${CMAKE_COMMAND}" --install "${CMAKE_BINARY_DIR}")
if(CMAKE_CONFIGURATION_TYPES)
    list(APPEND _mp_install_command --config $<CONFIG>)
endif()
add_custom_command(TARGET MaNGOSPatcher POST_BUILD
    COMMAND ${_mp_install_command}
    COMMENT "Installing MaNGOSPatcher to ${CMAKE_INSTALL_PREFIX}"
    VERBATIM)

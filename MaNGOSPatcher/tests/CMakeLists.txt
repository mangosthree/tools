function(stage_qt_test_runtime target)
    # Qt marks executables as GUI applications on Windows by default. Tests
    # need a console subsystem so CTest can capture Qt Test diagnostics rather
    # than losing them to the debugger output channel.
    set_target_properties(${target} PROPERTIES WIN32_EXECUTABLE FALSE)

    set(_qt_runtime_targets Qt6::Core Qt6::Test ${ARGN})
    foreach(_qt_target IN LISTS _qt_runtime_targets)
        add_custom_command(TARGET ${target} POST_BUILD
            COMMAND ${CMAKE_COMMAND} -E copy_if_different
                    "$<TARGET_FILE:${_qt_target}>"
                    "$<TARGET_FILE_DIR:${target}>/"
            VERBATIM)
    endforeach()
endfunction()

qt_add_executable(test_smoke test_smoke.cpp)
target_link_libraries(test_smoke PRIVATE Qt6::Test)
stage_qt_test_runtime(test_smoke)
add_test(NAME test_smoke COMMAND test_smoke -o -,txt)

qt_add_executable(test_patchtable test_patchtable.cpp)
target_link_libraries(test_patchtable PRIVATE patchcore Qt6::Test)
stage_qt_test_runtime(test_patchtable)
add_test(NAME test_patchtable COMMAND test_patchtable -o -,txt)

qt_add_executable(test_engine test_engine.cpp)
target_link_libraries(test_engine PRIVATE patchcore Qt6::Test)
stage_qt_test_runtime(test_engine)
add_test(NAME test_engine COMMAND test_engine -o -,txt)

qt_add_executable(test_fileops test_fileops.cpp)
target_link_libraries(test_fileops PRIVATE patchcore Qt6::Test)
stage_qt_test_runtime(test_fileops)
add_test(NAME test_fileops COMMAND test_fileops -o -,txt)

qt_add_executable(test_integration test_integration.cpp)
target_link_libraries(test_integration PRIVATE patchcore Qt6::Test)
stage_qt_test_runtime(test_integration)
add_test(NAME test_integration COMMAND test_integration -o -,txt)

qt_add_executable(test_mainwindow test_mainwindow.cpp)
target_link_libraries(test_mainwindow PRIVATE patchgui Qt6::Widgets Qt6::Test)
stage_qt_test_runtime(test_mainwindow Qt6::Gui Qt6::Widgets)
add_test(NAME test_mainwindow COMMAND test_mainwindow -o -,txt)
set_tests_properties(test_mainwindow PROPERTIES ENVIRONMENT "QT_QPA_PLATFORM=offscreen")

# The app deploy deliberately trims platforms/ down to qwindows.dll, but the line above
# asks Qt for the *offscreen* platform. Without qoffscreen.dll beside the test executable
# Qt cannot initialise, calls qFatal, and Windows reports __fastfail as 0xC0000409 -- a
# crash with no output that looks nothing like the missing-plugin problem it actually is.
# Stage the plugin from the Qt kit rather than hardcoding a path.
if(TARGET Qt6::QOffscreenIntegrationPlugin)
    add_custom_command(TARGET test_mainwindow POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E make_directory
                "$<TARGET_FILE_DIR:test_mainwindow>/platforms"
        COMMAND ${CMAKE_COMMAND} -E copy_if_different
                "$<TARGET_FILE:Qt6::QOffscreenIntegrationPlugin>"
                "$<TARGET_FILE_DIR:test_mainwindow>/platforms/"
        VERBATIM)
else()
    message(WARNING
        "Qt6::QOffscreenIntegrationPlugin not found; test_mainwindow will fail to start.")
endif()

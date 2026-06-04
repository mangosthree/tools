using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MaNGOSPatcher
{
    internal static class CrashReporter
    {
        private static int isReporting;

        public static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ReportException("Windows Forms thread exception", e.Exception);
        }

        public static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            if (exception == null)
                exception = new Exception("Unhandled non-Exception object: " + Convert.ToString(e.ExceptionObject));

            ReportException("AppDomain unhandled exception", exception);
        }

        public static void ReportException(string context, Exception exception)
        {
            if (Interlocked.Exchange(ref isReporting, 1) != 0)
                return;

            string logPath = null;
            try
            {
                logPath = WriteCrashLog(context, exception);
            }
            catch
            {
                // Crash reporting must never trigger a second fatal exception.
            }

            try
            {
                string message = "MaNGOSPatcher encountered an unexpected error.";
                if (!string.IsNullOrEmpty(logPath))
                    message += "\n\nCrash report written to:\n" + logPath;

                MessageBox.Show(message, "MaNGOSPatcher Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
            }
        }

        private static string WriteCrashLog(string context, Exception exception)
        {
            string directory = GetCrashLogDirectory();
            Directory.CreateDirectory(directory);

            string fileName = "crash-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".log";
            string path = Path.Combine(directory, fileName);

            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                writer.WriteLine("MaNGOSPatcher Crash Report");
                writer.WriteLine("==========================");
                writer.WriteLine("Time: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss zzz"));
                writer.WriteLine("Context: " + context);
                writer.WriteLine();

                writer.WriteLine("Environment");
                writer.WriteLine("-----------");
                writer.WriteLine("Executable: " + Application.ExecutablePath);
                writer.WriteLine("Current directory: " + Environment.CurrentDirectory);
                writer.WriteLine("Command line: " + Environment.CommandLine);
                writer.WriteLine(".NET version: " + Environment.Version);
                writer.WriteLine("OS version: " + Environment.OSVersion);
                writer.WriteLine("Machine name: " + Environment.MachineName);
                writer.WriteLine("User name: " + Environment.UserName);
                writer.WriteLine();

                writer.WriteLine("Expected files in current directory");
                writer.WriteLine("-----------------------------------");
                WriteFileState(writer, "Wow.exe");
                WriteFileState(writer, "Wow-64.exe");
                WriteFileState(writer, "World of Warcraft");
                writer.WriteLine();

                writer.WriteLine("Exception");
                writer.WriteLine("---------");
                WriteException(writer, exception, 0);
                writer.WriteLine();

                writer.WriteLine("Loaded assemblies");
                writer.WriteLine("-----------------");
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly assembly in assemblies)
                {
                    writer.WriteLine(assembly.FullName);
                    try
                    {
                        writer.WriteLine("  Location: " + assembly.Location);
                    }
                    catch
                    {
                        writer.WriteLine("  Location: <unavailable>");
                    }
                }
            }

            return path;
        }

        private static string GetCrashLogDirectory()
        {
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (!string.IsNullOrEmpty(localAppData))
                return Path.Combine(Path.Combine(localAppData, "MaNGOSPatcher"), "CrashLogs");

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CrashLogs");
        }

        private static void WriteFileState(StreamWriter writer, string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            if (!File.Exists(path))
            {
                writer.WriteLine(fileName + ": missing");
                return;
            }

            try
            {
                FileInfo info = new FileInfo(path);
                writer.WriteLine(fileName + ": present, " + info.Length + " bytes");
            }
            catch (Exception ex)
            {
                writer.WriteLine(fileName + ": present, could not read metadata: " + ex.Message);
            }
        }

        private static void WriteException(StreamWriter writer, Exception exception, int depth)
        {
            if (exception == null)
                return;

            string indent = new string(' ', depth * 2);
            writer.WriteLine(indent + "Type: " + exception.GetType().FullName);
            writer.WriteLine(indent + "Message: " + exception.Message);
            writer.WriteLine(indent + "Source: " + exception.Source);
            writer.WriteLine(indent + "Stack:");
            writer.WriteLine(exception.StackTrace);

            if (exception.InnerException != null)
            {
                writer.WriteLine();
                writer.WriteLine(indent + "Inner exception:");
                WriteException(writer, exception.InnerException, depth + 1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MaNGOSatcher;

namespace MaNGOSPatcher
{
    public partial class Form1 : Form
    {
        internal class PatchTarget
        {
            public string FileName;
            public string BackupFile;
            public byte[] Data;
            public List<PatchBytes> Patches;
            public bool Ready;
            public bool IsUnpatched;
            public bool IsPatched;
            public string MismatchReport;
        }

        Dictionary<int, List<PatchBytes>> Patches = new Dictionary<int, List<PatchBytes>>();
        List<PatchTarget> Targets = new List<PatchTarget>();

        const string FileWin = "Wow.exe";
        const string BackupWin = "Wow_backup.exe";
        const string FileWin64 = "Wow-64.exe";
        const string BackupWin64 = "Wow-64_backup.exe";
        const string FileMac = "World of Warcraft";
        const string BackupMac = "World of Warcraft backup";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.IsSubclassOf(typeof(PatchInfo)))
                {
                    PatchInfo pInfo = (PatchInfo)t.GetConstructor(new Type[] { }).Invoke(new Object[] { });
                    Patches.Add(pInfo.ExeLength, pInfo.Patches);
                }
            }

            RefreshState();
        }

        private void RefreshState()
        {
            Targets.Clear();

            TryLoadBinary(FileWin64, BackupWin64, "Windows 'Wow-64.exe'");
            TryLoadBinary(FileWin, BackupWin, "Windows 'Wow.exe'");
            TryLoadBinary(FileMac, BackupMac, "Mac 'World of Warcraft'");

            if (Targets.Count == 0)
            {
                richTextBox1.AppendText("Could not load Win 'Wow-64.exe', 'Wow.exe' or Mac 'World of Warcraft' into memory. Make sure this program is in your WoW directory and that WoW is closed.\n");
                label2.Text = "Error";
                label2.ForeColor = Color.Red;
                button1.Enabled = false;
                return;
            }

            bool anyReady = false;
            bool anyUnpatched = false;
            bool allPatched = true;
            StringBuilder summary = new StringBuilder();

            foreach (PatchTarget t in Targets)
            {
                ValidateTarget(t);
                if (t.Ready)
                {
                    anyReady = true;
                    if (t.IsUnpatched) anyUnpatched = true;
                    if (!t.IsPatched) allPatched = false;
                    summary.AppendFormat("  {0}: {1} patch sites {2}\n", t.FileName, t.Patches.Count,
                        t.IsPatched ? "already patched" : (t.IsUnpatched ? "ready to patch" : "mixed state"));
                }
                else
                {
                    summary.AppendFormat("  {0}: validation FAILED\n", t.FileName);
                    if (!string.IsNullOrEmpty(t.MismatchReport))
                        summary.Append(t.MismatchReport);
                }
            }

            richTextBox1.AppendText(summary.ToString());

            if (!anyReady)
            {
                richTextBox1.AppendText("No supported binaries passed validation. Patching disabled.\n");
                label2.Text = "Mismatch";
                label2.ForeColor = Color.Red;
                button1.Enabled = false;
                return;
            }

            label2.Text = "Ready!";
            label2.ForeColor = Color.Orange;
            button1.Enabled = true;

            if (anyUnpatched)
            {
                button1.Text = "Patch";
                richTextBox1.AppendText("Ready to patch all verified binaries.\n");
            }
            else if (allPatched)
            {
                button1.Text = "Unpatch";
                richTextBox1.AppendText("All verified binaries already patched. Click \"Unpatch\" to restore.\n");
            }
            else
            {
                button1.Text = "Patch";
                richTextBox1.AppendText("Some binaries are in a mixed state. Click \"Patch\" to synchronize.\n");
            }
        }

        private void TryLoadBinary(string fileName, string backupFile, string displayName)
        {
            try
            {
                byte[] data = ReadByteArrayFromFile(fileName);
                if (!Patches.ContainsKey(data.Length))
                {
                    richTextBox1.AppendText("This " + displayName + " version is not supported\n");
                    return;
                }
                richTextBox1.AppendText("Loaded " + displayName + " (" + data.Length + " bytes)\n");
                Targets.Add(new PatchTarget
                {
                    FileName = fileName,
                    BackupFile = backupFile,
                    Data = data,
                    Patches = Patches[data.Length],
                    Ready = false,
                    IsUnpatched = false,
                    IsPatched = false,
                    MismatchReport = ""
                });
            }
            catch
            {
                richTextBox1.AppendText(displayName + " not found.\n");
            }
        }

        private void ValidateTarget(PatchTarget t)
        {
            bool allUnpatched = true;
            bool allPatched = true;
            StringBuilder mismatchReport = new StringBuilder();

            foreach (PatchBytes p in t.Patches)
            {
                byte[] current = new byte[p.Unpatched.Length];
                System.Buffer.BlockCopy(t.Data, p.Offset, current, 0, p.Unpatched.Length);

                if (!current.SequenceEqual(p.Unpatched))
                    allUnpatched = false;
                if (!current.SequenceEqual(p.Patched))
                    allPatched = false;

                if (!current.SequenceEqual(p.Unpatched) && !current.SequenceEqual(p.Patched))
                {
                    string actual = BitConverter.ToString(current).Replace("-", " ");
                    string expectedUnpatched = BitConverter.ToString(p.Unpatched).Replace("-", " ");
                    string expectedPatched = BitConverter.ToString(p.Patched).Replace("-", " ");
                    mismatchReport.AppendFormat("    Offset 0x{0:X}: expected unpatched [{1}] or patched [{2}], found [{3}]\n",
                        p.Offset, expectedUnpatched, expectedPatched, actual);
                }
            }

            t.IsUnpatched = allUnpatched;
            t.IsPatched = allPatched;
            t.MismatchReport = mismatchReport.ToString();
            t.Ready = allUnpatched || allPatched;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isPatch = ((Button)sender).Text == "Patch";
            bool overallSuccess = true;
            StringBuilder report = new StringBuilder();

            foreach (PatchTarget t in Targets)
            {
                if (!t.Ready) continue;

                if (isPatch && t.IsUnpatched)
                {
                    if (!PatchTargetFile(t, report))
                        overallSuccess = false;
                }
                else if (!isPatch && t.IsPatched)
                {
                    if (!UnpatchTargetFile(t, report))
                        overallSuccess = false;
                }
            }

            richTextBox1.AppendText(report.ToString());
            if (overallSuccess)
            {
                label2.Text = "Success!";
                label2.ForeColor = Color.Green;
            }
            else
            {
                label2.Text = "Error!";
                label2.ForeColor = Color.Red;
            }
            richTextBox1.AppendText("Done.\n\n");
            RefreshState();
        }

        private bool PatchTargetFile(PatchTarget t, StringBuilder report)
        {
            if (!TryDeleteExistingFile(t.BackupFile, t.FileName, "old backup", report))
                return false;

            try
            {
                File.Move(t.FileName, t.BackupFile);
            }
            catch (Exception ex)
            {
                report.AppendFormat("SKIPPED {0}: could not create backup {1}: {2}\n",
                    t.FileName, t.BackupFile, ex.Message);
                return false;
            }

            byte[] patchedData = CreatePatchedCopy(t, true);
            if (WriteByteArrayToFile(patchedData, t.FileName))
            {
                report.AppendFormat("Patched {0} (backup: {1})\n", t.FileName, t.BackupFile);
                return true;
            }

            report.AppendFormat("ERROR writing {0}; backup remains at {1}\n", t.FileName, t.BackupFile);
            TryRestoreOriginalAfterPatchWriteFailure(t, report);
            return false;
        }

        private bool UnpatchTargetFile(PatchTarget t, StringBuilder report)
        {
            string restoreFile = t.FileName + ".restore.tmp";
            string patchedFile = t.FileName + ".patched.tmp";

            if (!TryDeleteExistingFile(restoreFile, t.FileName, "temporary restore file", report))
                return false;
            if (!TryDeleteExistingFile(patchedFile, t.FileName, "temporary patched file", report))
                return false;

            byte[] unpatchedData = CreatePatchedCopy(t, false);
            if (!WriteByteArrayToFile(unpatchedData, restoreFile))
            {
                report.AppendFormat("ERROR preparing restored copy for {0}\n", t.FileName);
                return false;
            }

            try
            {
                File.Move(t.FileName, patchedFile);
            }
            catch (Exception ex)
            {
                TryDeleteFile(restoreFile, report, t.FileName, "temporary restore file");
                report.AppendFormat("SKIPPED {0}: could not move patched file aside: {1}\n",
                    t.FileName, ex.Message);
                return false;
            }

            try
            {
                File.Move(restoreFile, t.FileName);
            }
            catch (Exception ex)
            {
                report.AppendFormat("ERROR restoring {0}: {1}\n", t.FileName, ex.Message);
                try
                {
                    File.Move(patchedFile, t.FileName);
                    report.AppendFormat("Restored patched copy of {0} after unpatch failure.\n", t.FileName);
                }
                catch (Exception rollbackEx)
                {
                    report.AppendFormat("ERROR restoring patched copy of {0}: {1}\n",
                        t.FileName, rollbackEx.Message);
                }
                return false;
            }

            TryDeleteFile(patchedFile, report, t.FileName, "temporary patched file");
            TryDeleteFile(t.BackupFile, report, t.FileName, "backup");
            report.AppendFormat("Restored {0}\n", t.FileName);
            return true;
        }

        private byte[] CreatePatchedCopy(PatchTarget t, bool usePatchedBytes)
        {
            byte[] data = (byte[])t.Data.Clone();
            foreach (PatchBytes p in t.Patches)
            {
                byte[] source = usePatchedBytes ? p.Patched : p.Unpatched;
                System.Buffer.BlockCopy(source, 0, data, p.Offset, source.Length);
            }
            return data;
        }

        private bool TryDeleteExistingFile(string fileName, string targetName, string description, StringBuilder report)
        {
            if (!File.Exists(fileName))
                return true;

            try
            {
                File.Delete(fileName);
                return true;
            }
            catch (Exception ex)
            {
                report.AppendFormat("SKIPPED {0}: could not delete {1} {2}: {3}\n",
                    targetName, description, fileName, ex.Message);
                return false;
            }
        }

        private void TryDeleteFile(string fileName, StringBuilder report, string targetName, string description)
        {
            if (!File.Exists(fileName))
                return;

            try
            {
                File.Delete(fileName);
            }
            catch (Exception ex)
            {
                report.AppendFormat("WARNING {0}: could not delete {1} {2}: {3}\n",
                    targetName, description, fileName, ex.Message);
            }
        }

        private void TryRestoreOriginalAfterPatchWriteFailure(PatchTarget t, StringBuilder report)
        {
            try
            {
                if (File.Exists(t.FileName))
                    File.Delete(t.FileName);
                File.Copy(t.BackupFile, t.FileName);
                report.AppendFormat("Restored original {0} from backup after write failure.\n", t.FileName);
            }
            catch (Exception ex)
            {
                report.AppendFormat("ERROR restoring original {0} from backup: {1}\n",
                    t.FileName, ex.Message);
            }
        }

        public byte[] ReadByteArrayFromFile(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            br.Close();
            return buff;
        }

        public bool WriteByteArrayToFile(byte[] buff, string fileName)
        {
            bool response = false;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(buff);
                bw.Close();
                response = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace EventAI_Creator
{
    public partial class SummonsEditor : Form
    {
        uint summon_id;

        public SummonsEditor()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void UpdateContent()
        {
            if (this.customlistBoxsummons.SelectedIndex != -1)
            {
                summons.map[summon_id].comment = box_comment.Text;
                summons.map[summon_id].orientation = float.Parse(box_orientation.Text);
                summons.map[summon_id].position_x = float.Parse(box_position_X.Text);
                summons.map[summon_id].position_y = float.Parse(box_position_Y.Text);
                summons.map[summon_id].position_z = float.Parse(box_position_Z.Text);
                summons.map[summon_id].spawntimesecs = System.Convert.ToInt32(box_spawntimesecs.Text);
            }
        }

        private void UpdateListBox(bool updateofficial)
        {
            customlistBoxsummons.Items.Clear();

            foreach (KeyValuePair<uint, summon> item in summons.map)
            {
                customlistBoxsummons.Items.Add(item.Key);
                customlistBoxsummons.SetItemChecked(customlistBoxsummons.Items.Count - 1, false);
            }
        }

        private void SummonsEditor_Load(object sender, EventArgs e)
        {
            UpdateListBox(true);

            if (customlistBoxsummons.Items.Count != 0)
                this.customlistBoxsummons.SelectedIndex = 0;
        }

        // Add new summon id to list
        private void buttonadd_Click(object sender, EventArgs e)
        {
            string str = textboxadd.Text.Trim();
            int value;
            bool isNum = int.TryParse(str, out value);
            if (!isNum)
            {
                MessageBox.Show("The id you entered is not valid. Please try again!");
                return;
            }

            if (this.textboxadd.Text.Length != 0)
            {
                if (summons.Add(System.Convert.ToUInt32(this.textboxadd.Text)))
                {
                    summon_id = System.Convert.ToUInt32(this.textboxadd.Text);
                    summonID.Text = this.textboxadd.Text;
                    UpdateListBox(false);
                    box_comment.Text = "";
                    box_orientation.Text = "0";
                    box_position_X.Text = "0";
                    box_position_Y.Text = "0";
                    box_position_Z.Text = "0";
                    box_spawntimesecs.Text = "0";

                    int i = 0;
                    foreach (uint item in customlistBoxsummons.Items)
                    {
                        if (item.ToString() == summonID.Text)
                        {
                            customlistBoxsummons.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
            }
        }

        private void listBoxsummons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customlistBoxsummons.SelectedIndex != -1)
            {
                summon_id = Convert.ToUInt32(customlistBoxsummons.Items[customlistBoxsummons.SelectedIndex]);
                summonID.Text = summon_id.ToString();
                box_spawntimesecs.Text = summons.map[summon_id].spawntimesecs.ToString();
                box_position_Z.Text = summons.map[summon_id].position_z.ToString();
                box_position_Y.Text = summons.map[summon_id].position_y.ToString();
                box_position_X.Text = summons.map[summon_id].position_x.ToString();
                box_orientation.Text = summons.map[summon_id].orientation.ToString();
                box_comment.Text = summons.map[summon_id].comment;
                summons.map[summon_id].changed = true;
            }
        }

        private void numberbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar)
            //    && !char.IsDigit(e.KeyChar)
            //    && e.KeyChar != '.')
            //    e.Handled = true;

            //// only allow one decimal point
            //if (e.KeyChar == '.'
            //    && (sender as TextBox).Text.IndexOf('.') > -1)
            //    e.Handled = true;
        }

        private void intnumberbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void stringbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nothing here
        }

        private void txtBox_Leave(object sender, EventArgs e)
        {
            string str = (sender as TextBox).Text.Trim();
            Int64 value;
            bool isNum = Int64.TryParse(str, out value);
            if (isNum)
                UpdateContent();
            else
                (sender as TextBox).Text = "0";
        }

        private void box_comment_Leave(object sender, EventArgs e)
        {
            UpdateContent();
        }

        private void summontextbox_TextChanged(object sender, EventArgs e)
        {
            // Nothing here
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            if (Datastores.dbused)
            {
                switch (MessageBox.Show("Are you sure you want to delete the selected text from the database?", "Remove from Database?", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        string query = SQLcreator.CreateDeleteQuery(summons.map[summon_id], "");
                        MySqlCommand c = new MySqlCommand(query, SQLConnection.conn);
                        try
                        {
                            c.ExecuteNonQuery();
                            summons.map.Remove(summon_id);
                            UpdateListBox(false);
                            if (customlistBoxsummons.Items.Count != 0)
                                customlistBoxsummons.SelectedIndex = 0;
                            else
                                customlistBoxsummons.SelectedIndex = -1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case DialogResult.No:
                        summons.map.Remove(summon_id);
                        UpdateListBox(false);
                        if (customlistBoxsummons.Items.Count != 0)
                            customlistBoxsummons.SelectedIndex = 0;
                        else
                            customlistBoxsummons.SelectedIndex = -1;
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            else
            {
                summons.map.Remove(summon_id);
                UpdateListBox(false);
                if (customlistBoxsummons.Items.Count != 0)
                    customlistBoxsummons.SelectedIndex = 0;
                else
                    customlistBoxsummons.SelectedIndex = -1;
            }
        }

        private void toDBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            menuStrip1.Focus();
            if (customlistBoxsummons.SelectedIndex != -1)
                SQLCommonExecutes.SaveOneItemTODB(summons.map[summon_id]);
            else
                MessageBox.Show("There are no scripts selected in the list.");
        }

        private void toDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Focus();
            if (customlistBoxsummons.SelectedIndex != -1)
                SQLCommonExecutes.SaveAllItemsToDB(summons.map);
            else
                MessageBox.Show("There are no scripts selected in the list.");
        }

        private void toSQLFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            menuStrip1.Focus();
            if (customlistBoxsummons.SelectedIndex != -1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "SQL Scriptdateien (*.sql)|*.sql|Alle Dateien (*.*)|*.*";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string FileName = saveFileDialog.FileName;
                    summons.PrintSummonToFile(summon_id, FileName);
                }
            }
            else
                MessageBox.Show("There are no scripts selected in the list.");
        }

        private void toSQLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Focus();
            if (customlistBoxsummons.SelectedIndex != -1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "SQL Scriptdateien (*.sql)|*.sql|Alle Dateien (*.*)|*.*";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string FileName = saveFileDialog.FileName;
                    summons.PrintALLSummonsToFile(FileName);
                }
            }
            else
                MessageBox.Show("There are no scripts selected in the list.");
        }

        private void customlistBoxsummons_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //if (customlistBoxsummons.SelectedIndex != -1)
            //{
            //    if (customlistBoxsummons.GetItemChecked(customlistBoxsummons.SelectedIndex))
            //    {
            //        SQLConnection.DoNONREADSD2Query("DELETE FROM info_summons WHERE entry = " + Convert.ToUInt32(customlistBoxsummons.SelectedItem) + ";", false);
            //    }
            //    else
            //    {
            //        SQLConnection.DoNONREADSD2Query("INSERT INTO info_summons VALUES(" + Convert.ToUInt32(customlistBoxsummons.SelectedItem) + ");", false);
            //    }
            //}
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://raw.github.com/mangos/mangos/master/doc/EventAI.txt");
        }

        private void toToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Focus();
            if (customlistBoxsummons.SelectedIndex != -1)
            {
                ScriptDisplay sd = new ScriptDisplay(summons.PrintToQueryWindow(summon_id));
                sd.ShowDialog();
            }
            else
                MessageBox.Show("There are no scripts selected in the list.");
        }
    }
}

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

namespace EventAI_Creator.GUI.General.localestext
{
    public partial class TEXTEditor : Form
    {
        int text_id;

        public TEXTEditor()
        {
            InitializeComponent();
            // init default values for boxes
            comboBox_type.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_type.SelectedIndex = 0;
            comboBox_language.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_language.SelectedIndex = 0;
            comboBox_emote.SelectedIndex = 0;

            this.WindowState = FormWindowState.Maximized;
        }

        private void UpdateListBox(bool updateofficial)
        {
            customlistBoxtexts.Items.Clear();

            foreach (KeyValuePair<int, localized_text> item in localized_texts.map)
            {
                customlistBoxtexts.Items.Add(item.Key);
                customlistBoxtexts.SetItemChecked(customlistBoxtexts.Items.Count - 1, false);
            }
        }

        private void TEXTEditor_Load(object sender, EventArgs e)
        {
            UpdateListBox(true);

            if (customlistBoxtexts.Items.Count != 0)
                this.customlistBoxtexts.SelectedIndex = 0;
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            if (this.textboxadd.Text.Length != 0)
            {
                string str = textboxadd.Text.Trim();
                Int64 value;
                bool isNum = Int64.TryParse(str, out value);
                if (isNum)
                {
                    if (value > 0)
                    {
                        MessageBox.Show("The id you entered is not valid. Please try again!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("The id you entered is not valid. Please try again!");
                    return;
                }

                if (localized_texts.Add(System.Convert.ToInt32(this.textboxadd.Text)))
                {
                    text_id = System.Convert.ToInt32(this.textboxadd.Text);
                    textlocalID.Text = this.textboxadd.Text;
                    UpdateListBox(false);
                    TextBoxlocal0.Text = ""; TextBoxlocal1.Text = ""; TextBoxlocal2.Text = ""; TextBoxlocal3.Text = "";
                    TextBoxlocal4.Text = ""; TextBoxlocal5.Text = ""; TextBoxlocal6.Text = ""; TextBoxlocal7.Text = "";
                    TextBoxlocal8.Text = ""; textboxcomment.Text = "";

                    int i = 0;
                    foreach (int item in customlistBoxtexts.Items)
                    {
                        if (item.ToString() == textlocalID.Text)
                        {
                            customlistBoxtexts.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
            }
        }

        private void customlistBoxtexts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
            {
                text_id = System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex]);
                textlocalID.Text = text_id.ToString();
                TextBoxlocal0.Text = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_0;
                TextBoxlocal1.Text = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_1;
                TextBoxlocal2.Text = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_2;
                TextBoxlocal3.Text = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_3;
                TextBoxlocal4.Text = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_4;
                TextBoxlocal5.Text = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_5;
                TextBoxlocal6.Text = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_6;
                TextBoxlocal7.Text = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_7;
                TextBoxlocal8.Text = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].locale_8;
                textBox_sound_id.Text = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].sound.ToString();

                int languageId = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].language;
                int indentCount = 0;
                if (languageId > 33)
                    indentCount = indentCount += 1;
                if (languageId > 14)
                    indentCount = indentCount += 18;
                if (languageId > 3)
                    indentCount = indentCount += 2;
                comboBox_language.SelectedIndex = languageId - indentCount;

                int emoteId = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].emote;
                indentCount = 0;
                if (emoteId > 7)
                    indentCount = indentCount += 2;
                if (emoteId > comboBox_emote.Items.Count)
                    comboBox_emote.Text = emoteId.ToString();
                comboBox_emote.SelectedIndex = emoteId - indentCount;
                comboBox_type.SelectedIndex = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].type;
                textboxcomment.Text = localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].comment;
                localized_texts.map[System.Convert.ToInt32(customlistBoxtexts.Items[customlistBoxtexts.SelectedIndex])].changed = true;
            }
        }

        private void numberbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '-')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '-'
                && (sender as TextBox).Text.IndexOf('-') > -1)
                e.Handled = true;
        }

        private void stringbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ("\"\'".IndexOf(e.KeyChar.ToString()) < 0)
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }

        private void localetextbox_TextChanged(object sender, EventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
            {
                if ((sender as RichTextBox) == TextBoxlocal0)
                    localized_texts.map[text_id].locale_0 = TextBoxlocal0.Text;
                if ((sender as RichTextBox) == TextBoxlocal1)
                    localized_texts.map[text_id].locale_1 = TextBoxlocal1.Text;
                if ((sender as RichTextBox) == TextBoxlocal2)
                    localized_texts.map[text_id].locale_2 = TextBoxlocal2.Text;
                if ((sender as RichTextBox) == TextBoxlocal3)
                    localized_texts.map[text_id].locale_3 = TextBoxlocal3.Text;
                if ((sender as RichTextBox) == TextBoxlocal4)
                    localized_texts.map[text_id].locale_4 = TextBoxlocal4.Text;
                if ((sender as RichTextBox) == TextBoxlocal5)
                    localized_texts.map[text_id].locale_5 = TextBoxlocal5.Text;
                if ((sender as RichTextBox) == TextBoxlocal6)
                    localized_texts.map[text_id].locale_6 = TextBoxlocal6.Text;
                if ((sender as RichTextBox) == TextBoxlocal7)
                    localized_texts.map[text_id].locale_7 = TextBoxlocal7.Text;
                if ((sender as RichTextBox) == TextBoxlocal8)
                    localized_texts.map[text_id].locale_8 = TextBoxlocal8.Text;
                if ((sender as TextBox) == textboxcomment)
                    localized_texts.map[text_id].comment = textboxcomment.Text;
                if ((sender as TextBox) == textBox_sound_id)
                    localized_texts.map[text_id].sound = Convert.ToInt32(textBox_sound_id.Text);
                if ((sender as ComboBox) == comboBox_emote)
                {
                    // If we have numeric then we take the number
                    try
                    {
                        if (Convert.ToInt32(comboBox_emote.Text) > 0)
                            localized_texts.map[text_id].emote = Convert.ToInt32(comboBox_emote.Text);
                    }
                    catch (Exception ex)
                    {
                        int emoteId = comboBox_emote.SelectedIndex;
                        int indentCount = 0;
                        if (emoteId > 7)
                            indentCount = indentCount += 2;

                        localized_texts.map[text_id].emote = emoteId + indentCount;
                    }
                }
                if ((sender as ComboBox) == comboBox_language)
                {
                    int languageId = comboBox_language.SelectedIndex;
                    int indentCount = 0;
                    if (languageId > 13)
                        indentCount = indentCount += 1;
                    if (languageId > 12)
                        indentCount = indentCount += 18;
                    if (languageId > 3)
                        indentCount = indentCount += 2;

                    localized_texts.map[text_id].language = languageId + indentCount;
                }
                if ((sender as ComboBox) == comboBox_type)
                    localized_texts.map[text_id].type = comboBox_type.SelectedIndex;
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (Datastores.dbused)
            {
                switch (MessageBox.Show("Are you sure you want to delete the selected text from the database?", "Remove from database?", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        string query = SQLcreator.CreateDeleteQuery(localized_texts.map[text_id], "");
                        MySqlCommand c = new MySqlCommand(query,SQLConnection.conn);
                        try
                        {
                            c.ExecuteNonQuery();
                            localized_texts.map.Remove(text_id);
                            UpdateListBox(false);
                            if (customlistBoxtexts.Items.Count != 0)
                                customlistBoxtexts.SelectedIndex = 0;
                            else
                                customlistBoxtexts.SelectedIndex = -1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case DialogResult.No:
                        localized_texts.map.Remove(text_id);
                        UpdateListBox(false);
                        if (customlistBoxtexts.Items.Count != 0)
                            customlistBoxtexts.SelectedIndex = 0;
                        else
                            customlistBoxtexts.SelectedIndex = -1;
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            else
            {
                localized_texts.map.Remove(text_id);
                UpdateListBox(false);
                if (customlistBoxtexts.Items.Count != 0)
                    customlistBoxtexts.SelectedIndex = 0;
                else
                    customlistBoxtexts.SelectedIndex = -1;
            }
        }

        private void toDBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
                SQLCommonExecutes.SaveOneItemTODB(localized_texts.map[text_id]);
            else
                MessageBox.Show("There are no scripts selected in the list.");
        }

        private void toDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
                SQLCommonExecutes.SaveAllItemsToDB(localized_texts.map);
            else
                MessageBox.Show("There are no scripts selected in the list.");
        }

        private void toFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "SQL Scriptdateien (*.sql)|*.sql|Alle Dateien (*.*)|*.*";

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string FileName = saveFileDialog.FileName;
                    localized_texts.PrintALLLocalsToFile(FileName);
                }
            }
            else
                MessageBox.Show("There are no scripts selected in the list.");
        }

        private void toFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "SQL Scriptdateien (*.sql)|*.sql|Alle Dateien (*.*)|*.*";

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string FileName = saveFileDialog.FileName;
                    localized_texts.PrintLocalToFile(text_id, FileName);
                }
            }
            else
                MessageBox.Show("There are no scripts selected in the list.");
        }

        // Change the visibility of the other local texts
        private void checkBox_use_locale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_use_locale.Checked)
            {
                tabControl_texts.Visible = true;
                localized_texts.map[text_id].useOtherLocale = true;
            }
            else
            {
                tabControl_texts.Visible = false;
                localized_texts.map[text_id].useOtherLocale = false;
            }
        }

        // View display window
        private void toWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customlistBoxtexts.SelectedIndex != -1)
            {
                ScriptDisplay sd = new ScriptDisplay(localized_texts.PrintToQueryWindow(text_id));
                sd.ShowDialog();
            }
            else
                MessageBox.Show("There are no scripts selected in the list.");
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://raw.github.com/mangos/mangos/master/doc/EventAI.txt");
        }
    }
}

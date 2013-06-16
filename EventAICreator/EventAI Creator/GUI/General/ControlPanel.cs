using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace EventAI_Creator.GUI.General
{
    public partial class ControlPanel : Form
    {
        public ControlPanel()
        {
            InitializeComponent();
        }

        private void updateofficialDB_Click(object sender, EventArgs e)
        {
            if (!Datastores.dbused)
            { MessageBox.Show("No DB Connection"); return; }
            string query = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "SQL Batchdateien (*.sql)|*.sql|Alle Dateien (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                query = File.ReadAllText(FileName);
                query = query.Replace("eventai_scripts", "eventai_scripts_official");
                query = query.Replace("eventai_summons", "eventai_summons_official");
                query = query.Replace("eventai_localized_texts", "eventai_localized_texts_official");
                query = query.Replace("eventai_texts", "eventai_texts_official");
                query = query.Replace("NN@EOF", "");

                MySqlCommand c = new MySqlCommand(query, SQLConnection.conn);

                try
                {
                    c.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void setallscriptnames_Click(object sender, EventArgs e)
        {
            foreach (Form item in MdiParent.MdiChildren)
            {
                if (item is NPCEditor)
                {
                    (item as NPCEditor).Controls.Find("setInCreaturetemplateToolStripMenuItem", true)[0].Text = "Remove scriptname";
                }
            }
            foreach (KeyValuePair<uint, creature> item in creatures.npcList)
            {
                SQLCommonExecutes.setScriptnameInCreature_template(item.Value.creature_id, false);
                item.Value.activectemplate = true;
            }
            foreach (KeyValuePair<uint, creature> item in creatures.npcList)
            {
                SQLCommonExecutes.setScriptnameInCreature_template(item.Value.creature_id, false);
                item.Value.activectemplate = true;
            }
        }

        private void removescriptnames_Click(object sender, EventArgs e)
        {
            foreach (Form item in MdiParent.MdiChildren)
            {
                if (item is NPCEditor)
                {
                    (item as NPCEditor).Controls.Find("setInCreaturetemplateToolStripMenuItem", true)[0].Text = "Set scriptname";
                }
            }
            foreach (KeyValuePair<uint,creature> item in creatures.npcList)
            {
                SQLCommonExecutes.setScriptnameInCreature_template(item.Value.creature_id, true);
                item.Value.activectemplate = false;
            }
            foreach (KeyValuePair<uint, creature> item in creatures.npcList)
            {
                SQLCommonExecutes.setScriptnameInCreature_template(item.Value.creature_id, true);
                item.Value.activectemplate = false;
            }
        }

        private void CompileCreatures_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will Save every Creature you touched to the DB and puts Official and your Content together. \n Continue?","Attempt to Compile", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (SQLCommonExecutes.SaveAllItemsToDB(creatures.npcList))
                {
                    SQLConnection.DoNONREADSD2Query("TRUNCATE `eventai_scripts`",false);
                    SQLConnection.DoNONREADSD2Query("INSERT INTO `eventai_scripts` SELECT  * FROM `eventai_scripts_official`",false);

                    SQLCommonExecutes.CompileQuery(creatures.npcList);
                }
            }
        }

        private void CompileTexts_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will Save every Localized Text you touched to the DB and puts Official and your Content together. \n Continue?", "Attempt to Compile", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (SQLCommonExecutes.SaveAllItemsToDB(localized_texts.map))
                {
                    SQLConnection.DoNONREADSD2Query("TRUNCATE `eventai_localized_texts`", false);
                    SQLConnection.DoNONREADSD2Query("INSERT INTO `eventai_localized_texts` SELECT  * FROM `eventai_localized_texts_official`", false);
                    SQLConnection.DoNONREADSD2Query("INSERT INTO `eventai_texts` SELECT  * FROM `eventai_texts_official`", false);

                    SQLCommonExecutes.CompileQuery(localized_texts.map);
                }
            }
        }

        private void CompileSummons_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will Save every Summon you touched to the DB and puts Official and your Content together. \n Continue?", "Attempt to Compile", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (SQLCommonExecutes.SaveAllItemsToDB(summons.map))
                {
                    SQLConnection.DoNONREADSD2Query("TRUNCATE `eventai_summons`", false);
                    SQLConnection.DoNONREADSD2Query("INSERT INTO `eventai_summons` SELECT  * FROM `eventai_summons_official`", false);

                    SQLCommonExecutes.CompileQuery(summons.map);
                }
            }
        }
    }
}

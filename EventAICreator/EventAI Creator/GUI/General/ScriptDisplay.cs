using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventAI_Creator
{
    public partial class ScriptDisplay : Form
    {
        public ScriptDisplay(string query)
        {
            InitializeComponent();
            textBox_query.ScrollBars = ScrollBars.Both;
            textBox_query.Text = query;

            if (Datastores.dbused)
                button_execute.Enabled = true;
        }

        private void button_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_copy_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(textBox_query.Text);
        }

        private void button_execute_Click(object sender, EventArgs e)
        {
            if (textBox_query.Text.Trim() == "")
            {
                MessageBox.Show("Your query is empty!");
                return;
            }

            if (SQLCommonExecutes.ExecuteDBScript(textBox_query.Text))
                MessageBox.Show("Script executed succesfully!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace EventAI_Creator.GUI.General
{
    public partial class eAICreator : Form
    {
        public eAICreator()
        {
            InitializeComponent();
        }

        private void connectbutton_Click(object sender, EventArgs e)
        {
            if (sshcheckbox.Checked)
            {
                if (SSHConnection.Connect(tboxsshhost.Text, tboxsshuser.Text, tboxsshpw.Text, tboxsshport.Text))
                {
                    if(SQLConnection.Connect(tboxmysqlhost.Text, tboxmysqlname.Text, tboxmysqlpw.Text, /*tboxmysqlsd2db.Text,*/ tboxmysqlwordldb.Text))
                    {
                        Datastores.dbused = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(SQLConnection.error.Message);
                    }
                }
                else
                {
                    MessageBox.Show(SSHConnection.error.Message);
                }
            }
            else
            {
                if(SQLConnection.Connect(tboxmysqlhost.Text, tboxmysqlname.Text, tboxmysqlpw.Text, /*tboxmysqlsd2db.Text,*/ tboxmysqlwordldb.Text))
                {
                    Datastores.dbused = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(SQLConnection.error.Message);
                }
            }
        }

        private void noDBconnection_Click(object sender, EventArgs e)
        {
            Datastores.dbused = false;
            this.Close();
        }

        private void eAICreator_Load(object sender, EventArgs e)
        {
            tboxmysqlhost.Text = Properties.Settings.Default.DBHost;
            tboxmysqlname.Text = Properties.Settings.Default.DBUSER ;
            tboxmysqlport.Text = Properties.Settings.Default.DBPort;
            tboxmysqlpw.Text = Properties.Settings.Default.DBPW;
            //tboxmysqlsd2db.Text = Properties.Settings.Default.DBSD;
            tboxmysqlwordldb.Text = Properties.Settings.Default.DBMANGOS;
            tboxsshhost.Text = Properties.Settings.Default.SSHHOST;
            tboxsshport.Text = Properties.Settings.Default.SSHPORT;
            tboxsshpw.Text = Properties.Settings.Default.SSHPW;
            tboxsshuser.Text = Properties.Settings.Default.SSHUSER;
            sshcheckbox.Checked = Properties.Settings.Default.SSHUSE;

            //Properties.Settings.Default;
        }

        private void eAICreator_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.DBHost = tboxmysqlhost.Text;
            Properties.Settings.Default.DBUSER = tboxmysqlname.Text;
            Properties.Settings.Default.DBPW =tboxmysqlpw.Text;
            Properties.Settings.Default.DBPort = tboxmysqlport.Text;
            Properties.Settings.Default.DBMANGOS =tboxmysqlwordldb.Text;
            //Properties.Settings.Default.DBSD = tboxmysqlsd2db.Text;
            Properties.Settings.Default.SSHHOST = tboxsshhost.Text;
            Properties.Settings.Default.SSHPORT =tboxsshport.Text;
            Properties.Settings.Default.SSHPW =tboxsshpw.Text;
            Properties.Settings.Default.SSHUSER =tboxsshuser.Text;
            Properties.Settings.Default.SSHUSE =sshcheckbox.Checked;
            Properties.Settings.Default.Save();

            //Properties.Settings.Default.SSHRPORT;
        }

        // Change the state of the ssh boxes when the checkbox is checked or unchecked
        private void sshcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (sshcheckbox.Checked)
            {
                tboxsshhost.ReadOnly = false;
                tboxsshport.ReadOnly = false;
                tboxsshpw.ReadOnly = false;
                tboxsshuser.ReadOnly = false;
            }
            else
            {
                tboxsshhost.ReadOnly = true;
                tboxsshport.ReadOnly = true;
                tboxsshpw.ReadOnly = true;
                tboxsshuser.ReadOnly = true;
            }
        }
    }
}

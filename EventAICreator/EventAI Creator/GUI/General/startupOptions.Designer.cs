namespace EventAI_Creator.GUI.General
{
    partial class eAICreator
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(eAICreator));
            this.noDBconnection = new System.Windows.Forms.Button();
            this.connectbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mysqlgroupbox = new System.Windows.Forms.GroupBox();
            this.tboxmysqlpw = new System.Windows.Forms.TextBox();
            this.tboxmysqlwordldb = new System.Windows.Forms.TextBox();
            this.tboxmysqlname = new System.Windows.Forms.TextBox();
            this.tboxmysqlport = new System.Windows.Forms.TextBox();
            this.tboxmysqlhost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sshgroupbox = new System.Windows.Forms.GroupBox();
            this.tboxsshpw = new System.Windows.Forms.TextBox();
            this.tboxsshuser = new System.Windows.Forms.TextBox();
            this.tboxsshport = new System.Windows.Forms.TextBox();
            this.tboxsshhost = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sshcheckbox = new System.Windows.Forms.CheckBox();
            this.mysqlgroupbox.SuspendLayout();
            this.sshgroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // noDBconnection
            // 
            this.noDBconnection.Location = new System.Drawing.Point(217, 210);
            this.noDBconnection.Name = "noDBconnection";
            this.noDBconnection.Size = new System.Drawing.Size(75, 23);
            this.noDBconnection.TabIndex = 0;
            this.noDBconnection.Text = "Work offline";
            this.noDBconnection.UseVisualStyleBackColor = true;
            this.noDBconnection.Click += new System.EventHandler(this.noDBconnection_Click);
            // 
            // connectbutton
            // 
            this.connectbutton.Location = new System.Drawing.Point(109, 210);
            this.connectbutton.Name = "connectbutton";
            this.connectbutton.Size = new System.Drawing.Size(75, 23);
            this.connectbutton.TabIndex = 1;
            this.connectbutton.Text = "Connect";
            this.connectbutton.UseVisualStyleBackColor = true;
            this.connectbutton.Click += new System.EventHandler(this.connectbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to MaNGOS scripting tool. Please set your Database Settings";
            // 
            // mysqlgroupbox
            // 
            this.mysqlgroupbox.Controls.Add(this.tboxmysqlpw);
            this.mysqlgroupbox.Controls.Add(this.tboxmysqlwordldb);
            this.mysqlgroupbox.Controls.Add(this.tboxmysqlname);
            this.mysqlgroupbox.Controls.Add(this.tboxmysqlport);
            this.mysqlgroupbox.Controls.Add(this.tboxmysqlhost);
            this.mysqlgroupbox.Controls.Add(this.label6);
            this.mysqlgroupbox.Controls.Add(this.label5);
            this.mysqlgroupbox.Controls.Add(this.label4);
            this.mysqlgroupbox.Controls.Add(this.label3);
            this.mysqlgroupbox.Controls.Add(this.label2);
            this.mysqlgroupbox.Location = new System.Drawing.Point(13, 30);
            this.mysqlgroupbox.Name = "mysqlgroupbox";
            this.mysqlgroupbox.Size = new System.Drawing.Size(360, 170);
            this.mysqlgroupbox.TabIndex = 3;
            this.mysqlgroupbox.TabStop = false;
            this.mysqlgroupbox.Text = "MySQL Connection Settings";
            // 
            // tboxmysqlpw
            // 
            this.tboxmysqlpw.Location = new System.Drawing.Point(154, 111);
            this.tboxmysqlpw.MaxLength = 255;
            this.tboxmysqlpw.Name = "tboxmysqlpw";
            this.tboxmysqlpw.PasswordChar = '*';
            this.tboxmysqlpw.Size = new System.Drawing.Size(200, 20);
            this.tboxmysqlpw.TabIndex = 4;
            // 
            // tboxmysqlwordldb
            // 
            this.tboxmysqlwordldb.Location = new System.Drawing.Point(154, 134);
            this.tboxmysqlwordldb.MaxLength = 255;
            this.tboxmysqlwordldb.Name = "tboxmysqlwordldb";
            this.tboxmysqlwordldb.Size = new System.Drawing.Size(200, 20);
            this.tboxmysqlwordldb.TabIndex = 5;
            // 
            // tboxmysqlname
            // 
            this.tboxmysqlname.Location = new System.Drawing.Point(154, 85);
            this.tboxmysqlname.MaxLength = 255;
            this.tboxmysqlname.Name = "tboxmysqlname";
            this.tboxmysqlname.Size = new System.Drawing.Size(200, 20);
            this.tboxmysqlname.TabIndex = 3;
            // 
            // tboxmysqlport
            // 
            this.tboxmysqlport.Location = new System.Drawing.Point(154, 59);
            this.tboxmysqlport.MaxLength = 255;
            this.tboxmysqlport.Name = "tboxmysqlport";
            this.tboxmysqlport.Size = new System.Drawing.Size(200, 20);
            this.tboxmysqlport.TabIndex = 2;
            // 
            // tboxmysqlhost
            // 
            this.tboxmysqlhost.Location = new System.Drawing.Point(154, 33);
            this.tboxmysqlhost.MaxLength = 255;
            this.tboxmysqlhost.Name = "tboxmysqlhost";
            this.tboxmysqlhost.Size = new System.Drawing.Size(200, 20);
            this.tboxmysqlhost.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Mangos World DB:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hostname/IP-Address:";
            // 
            // sshgroupbox
            // 
            this.sshgroupbox.Controls.Add(this.tboxsshpw);
            this.sshgroupbox.Controls.Add(this.tboxsshuser);
            this.sshgroupbox.Controls.Add(this.tboxsshport);
            this.sshgroupbox.Controls.Add(this.tboxsshhost);
            this.sshgroupbox.Controls.Add(this.label11);
            this.sshgroupbox.Controls.Add(this.label10);
            this.sshgroupbox.Controls.Add(this.label9);
            this.sshgroupbox.Controls.Add(this.label8);
            this.sshgroupbox.Controls.Add(this.sshcheckbox);
            this.sshgroupbox.Location = new System.Drawing.Point(379, 12);
            this.sshgroupbox.Name = "sshgroupbox";
            this.sshgroupbox.Size = new System.Drawing.Size(205, 221);
            this.sshgroupbox.TabIndex = 4;
            this.sshgroupbox.TabStop = false;
            this.sshgroupbox.Text = "SSH Connection";
            // 
            // tboxsshpw
            // 
            this.tboxsshpw.Location = new System.Drawing.Point(13, 191);
            this.tboxsshpw.MaxLength = 255;
            this.tboxsshpw.Name = "tboxsshpw";
            this.tboxsshpw.PasswordChar = '?';
            this.tboxsshpw.ReadOnly = true;
            this.tboxsshpw.Size = new System.Drawing.Size(186, 20);
            this.tboxsshpw.TabIndex = 10;
            // 
            // tboxsshuser
            // 
            this.tboxsshuser.Location = new System.Drawing.Point(13, 152);
            this.tboxsshuser.MaxLength = 255;
            this.tboxsshuser.Name = "tboxsshuser";
            this.tboxsshuser.ReadOnly = true;
            this.tboxsshuser.Size = new System.Drawing.Size(186, 20);
            this.tboxsshuser.TabIndex = 9;
            // 
            // tboxsshport
            // 
            this.tboxsshport.Location = new System.Drawing.Point(13, 106);
            this.tboxsshport.MaxLength = 255;
            this.tboxsshport.Name = "tboxsshport";
            this.tboxsshport.ReadOnly = true;
            this.tboxsshport.Size = new System.Drawing.Size(186, 20);
            this.tboxsshport.TabIndex = 8;
            // 
            // tboxsshhost
            // 
            this.tboxsshhost.Location = new System.Drawing.Point(13, 67);
            this.tboxsshhost.MaxLength = 255;
            this.tboxsshhost.Name = "tboxsshhost";
            this.tboxsshhost.ReadOnly = true;
            this.tboxsshhost.Size = new System.Drawing.Size(186, 20);
            this.tboxsshhost.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Port:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Username:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Hostname/IP-Address:";
            // 
            // sshcheckbox
            // 
            this.sshcheckbox.AutoSize = true;
            this.sshcheckbox.Location = new System.Drawing.Point(7, 20);
            this.sshcheckbox.Name = "sshcheckbox";
            this.sshcheckbox.Size = new System.Drawing.Size(127, 17);
            this.sshcheckbox.TabIndex = 0;
            this.sshcheckbox.Text = "Use SSH Connection";
            this.sshcheckbox.UseVisualStyleBackColor = true;
            this.sshcheckbox.CheckedChanged += new System.EventHandler(this.sshcheckbox_CheckedChanged);
            // 
            // eAICreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 243);
            this.Controls.Add(this.sshgroupbox);
            this.Controls.Add(this.mysqlgroupbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectbutton);
            this.Controls.Add(this.noDBconnection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "eAICreator";
            this.Text = "MaNGOS script development tool";
            this.Load += new System.EventHandler(this.eAICreator_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.eAICreator_FormClosing);
            this.mysqlgroupbox.ResumeLayout(false);
            this.mysqlgroupbox.PerformLayout();
            this.sshgroupbox.ResumeLayout(false);
            this.sshgroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button noDBconnection;
        private System.Windows.Forms.Button connectbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox mysqlgroupbox;
        private System.Windows.Forms.GroupBox sshgroupbox;
        private System.Windows.Forms.CheckBox sshcheckbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tboxmysqlwordldb;
        private System.Windows.Forms.TextBox tboxmysqlname;
        private System.Windows.Forms.TextBox tboxmysqlport;
        private System.Windows.Forms.TextBox tboxmysqlhost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tboxsshuser;
        private System.Windows.Forms.TextBox tboxsshport;
        private System.Windows.Forms.TextBox tboxsshhost;
        private System.Windows.Forms.TextBox tboxmysqlpw;
        private System.Windows.Forms.TextBox tboxsshpw;
    }
}
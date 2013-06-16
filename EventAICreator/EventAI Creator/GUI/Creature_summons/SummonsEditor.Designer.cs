namespace EventAI_Creator
{
    partial class SummonsEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummonsEditor));
            this.buttonadd = new System.Windows.Forms.Button();
            this.textboxadd = new System.Windows.Forms.TextBox();
            this.summonID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxsearch = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.box_position_X = new System.Windows.Forms.TextBox();
            this.box_position_Y = new System.Windows.Forms.TextBox();
            this.box_position_Z = new System.Windows.Forms.TextBox();
            this.box_orientation = new System.Windows.Forms.TextBox();
            this.box_spawntimesecs = new System.Windows.Forms.TextBox();
            this.box_comment = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveThisSummonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toDBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toSQLFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllSummonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toSQLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteThisSummonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customlistBoxsummons = new System.Windows.Forms.CheckedListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveAll_toolstrip_button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.save_DB_toolstrip_button = new System.Windows.Forms.ToolStripButton();
            this.save_all_db_toolstrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.preview_toolstrip_button = new System.Windows.Forms.ToolStripButton();
            this.delete_toolstrip_button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonadd
            // 
            this.buttonadd.Location = new System.Drawing.Point(394, 60);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(57, 22);
            this.buttonadd.TabIndex = 42;
            this.buttonadd.Text = "Add";
            this.buttonadd.UseVisualStyleBackColor = true;
            this.buttonadd.Click += new System.EventHandler(this.buttonadd_Click);
            // 
            // textboxadd
            // 
            this.textboxadd.Location = new System.Drawing.Point(331, 61);
            this.textboxadd.Name = "textboxadd";
            this.textboxadd.Size = new System.Drawing.Size(57, 20);
            this.textboxadd.TabIndex = 41;
            this.textboxadd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intnumberbox_KeyPress);
            // 
            // summonID
            // 
            this.summonID.AutoSize = true;
            this.summonID.Location = new System.Drawing.Point(39, 29);
            this.summonID.Name = "summonID";
            this.summonID.Size = new System.Drawing.Size(0, 13);
            this.summonID.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "ID:";
            // 
            // textboxsearch
            // 
            this.textboxsearch.Enabled = false;
            this.textboxsearch.Location = new System.Drawing.Point(205, 61);
            this.textboxsearch.Name = "textboxsearch";
            this.textboxsearch.Size = new System.Drawing.Size(57, 20);
            this.textboxsearch.TabIndex = 38;
            // 
            // Search
            // 
            this.Search.Enabled = false;
            this.Search.Location = new System.Drawing.Point(268, 60);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(57, 22);
            this.Search.TabIndex = 36;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "position_X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "position_Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "orientation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "position_Z";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "spawntimeSecs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(207, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Comment";
            // 
            // box_position_X
            // 
            this.box_position_X.Location = new System.Drawing.Point(264, 85);
            this.box_position_X.Name = "box_position_X";
            this.box_position_X.Size = new System.Drawing.Size(188, 20);
            this.box_position_X.TabIndex = 49;
            this.box_position_X.TextChanged += new System.EventHandler(this.summontextbox_TextChanged);
            this.box_position_X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberbox_KeyPress);
            this.box_position_X.Leave += new System.EventHandler(this.txtBox_Leave);
            // 
            // box_position_Y
            // 
            this.box_position_Y.Location = new System.Drawing.Point(264, 111);
            this.box_position_Y.Name = "box_position_Y";
            this.box_position_Y.Size = new System.Drawing.Size(188, 20);
            this.box_position_Y.TabIndex = 50;
            this.box_position_Y.TextChanged += new System.EventHandler(this.summontextbox_TextChanged);
            this.box_position_Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberbox_KeyPress);
            this.box_position_Y.Leave += new System.EventHandler(this.txtBox_Leave);
            // 
            // box_position_Z
            // 
            this.box_position_Z.Location = new System.Drawing.Point(264, 137);
            this.box_position_Z.Name = "box_position_Z";
            this.box_position_Z.Size = new System.Drawing.Size(188, 20);
            this.box_position_Z.TabIndex = 51;
            this.box_position_Z.TextChanged += new System.EventHandler(this.summontextbox_TextChanged);
            this.box_position_Z.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberbox_KeyPress);
            this.box_position_Z.Leave += new System.EventHandler(this.txtBox_Leave);
            // 
            // box_orientation
            // 
            this.box_orientation.Location = new System.Drawing.Point(264, 163);
            this.box_orientation.Name = "box_orientation";
            this.box_orientation.Size = new System.Drawing.Size(188, 20);
            this.box_orientation.TabIndex = 52;
            this.box_orientation.TextChanged += new System.EventHandler(this.summontextbox_TextChanged);
            this.box_orientation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberbox_KeyPress);
            this.box_orientation.Leave += new System.EventHandler(this.txtBox_Leave);
            // 
            // box_spawntimesecs
            // 
            this.box_spawntimesecs.Location = new System.Drawing.Point(264, 189);
            this.box_spawntimesecs.MaxLength = 11;
            this.box_spawntimesecs.Name = "box_spawntimesecs";
            this.box_spawntimesecs.Size = new System.Drawing.Size(188, 20);
            this.box_spawntimesecs.TabIndex = 53;
            this.box_spawntimesecs.TextChanged += new System.EventHandler(this.summontextbox_TextChanged);
            this.box_spawntimesecs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intnumberbox_KeyPress);
            this.box_spawntimesecs.Leave += new System.EventHandler(this.txtBox_Leave);
            // 
            // box_comment
            // 
            this.box_comment.Location = new System.Drawing.Point(264, 215);
            this.box_comment.Name = "box_comment";
            this.box_comment.Size = new System.Drawing.Size(188, 20);
            this.box_comment.TabIndex = 54;
            this.box_comment.TextChanged += new System.EventHandler(this.summontextbox_TextChanged);
            this.box_comment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stringbox_KeyPress);
            this.box_comment.Leave += new System.EventHandler(this.box_comment_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.deleteThisSummonToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(468, 24);
            this.menuStrip1.TabIndex = 56;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveThisSummonToolStripMenuItem,
            this.saveAllSummonsToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveThisSummonToolStripMenuItem
            // 
            this.saveThisSummonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toDBToolStripMenuItem1,
            this.toSQLFileToolStripMenuItem1,
            this.toToolStripMenuItem});
            this.saveThisSummonToolStripMenuItem.Name = "saveThisSummonToolStripMenuItem";
            this.saveThisSummonToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.saveThisSummonToolStripMenuItem.Text = "Save this Summon";
            // 
            // toDBToolStripMenuItem1
            // 
            this.toDBToolStripMenuItem1.Name = "toDBToolStripMenuItem1";
            this.toDBToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.toDBToolStripMenuItem1.Text = "To DB";
            this.toDBToolStripMenuItem1.Click += new System.EventHandler(this.toDBToolStripMenuItem1_Click);
            // 
            // toSQLFileToolStripMenuItem1
            // 
            this.toSQLFileToolStripMenuItem1.Name = "toSQLFileToolStripMenuItem1";
            this.toSQLFileToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.toSQLFileToolStripMenuItem1.Text = "To SQL File";
            this.toSQLFileToolStripMenuItem1.Click += new System.EventHandler(this.toSQLFileToolStripMenuItem1_Click);
            // 
            // toToolStripMenuItem
            // 
            this.toToolStripMenuItem.Name = "toToolStripMenuItem";
            this.toToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.toToolStripMenuItem.Text = "To Window";
            this.toToolStripMenuItem.Click += new System.EventHandler(this.toToolStripMenuItem_Click);
            // 
            // saveAllSummonsToolStripMenuItem
            // 
            this.saveAllSummonsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toDBToolStripMenuItem,
            this.toSQLFileToolStripMenuItem});
            this.saveAllSummonsToolStripMenuItem.Name = "saveAllSummonsToolStripMenuItem";
            this.saveAllSummonsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.saveAllSummonsToolStripMenuItem.Text = "Save all Summons";
            // 
            // toDBToolStripMenuItem
            // 
            this.toDBToolStripMenuItem.Name = "toDBToolStripMenuItem";
            this.toDBToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.toDBToolStripMenuItem.Text = "To DB";
            this.toDBToolStripMenuItem.Click += new System.EventHandler(this.toDBToolStripMenuItem_Click);
            // 
            // toSQLFileToolStripMenuItem
            // 
            this.toSQLFileToolStripMenuItem.Name = "toSQLFileToolStripMenuItem";
            this.toSQLFileToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.toSQLFileToolStripMenuItem.Text = "To SQL File";
            this.toSQLFileToolStripMenuItem.Click += new System.EventHandler(this.toSQLFileToolStripMenuItem_Click);
            // 
            // deleteThisSummonToolStripMenuItem
            // 
            this.deleteThisSummonToolStripMenuItem.Name = "deleteThisSummonToolStripMenuItem";
            this.deleteThisSummonToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.deleteThisSummonToolStripMenuItem.Text = "Delete this Summon";
            this.deleteThisSummonToolStripMenuItem.Click += new System.EventHandler(this.deletebutton_Click);
            // 
            // customlistBoxsummons
            // 
            this.customlistBoxsummons.FormattingEnabled = true;
            this.customlistBoxsummons.Location = new System.Drawing.Point(15, 58);
            this.customlistBoxsummons.Name = "customlistBoxsummons";
            this.customlistBoxsummons.Size = new System.Drawing.Size(157, 184);
            this.customlistBoxsummons.TabIndex = 57;
            this.customlistBoxsummons.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.customlistBoxsummons_ItemCheck);
            this.customlistBoxsummons.SelectedIndexChanged += new System.EventHandler(this.listBoxsummons_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.saveAll_toolstrip_button,
            this.toolStripSeparator2,
            this.save_DB_toolstrip_button,
            this.save_all_db_toolstrip,
            this.toolStripSeparator,
            this.preview_toolstrip_button,
            this.delete_toolstrip_button,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(468, 25);
            this.toolStrip1.TabIndex = 58;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.toSQLFileToolStripMenuItem1_Click);
            // 
            // saveAll_toolstrip_button
            // 
            this.saveAll_toolstrip_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAll_toolstrip_button.Image = ((System.Drawing.Image)(resources.GetObject("saveAll_toolstrip_button.Image")));
            this.saveAll_toolstrip_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAll_toolstrip_button.Name = "saveAll_toolstrip_button";
            this.saveAll_toolstrip_button.Size = new System.Drawing.Size(23, 22);
            this.saveAll_toolstrip_button.Text = "Save &All";
            this.saveAll_toolstrip_button.Click += new System.EventHandler(this.toSQLFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // save_DB_toolstrip_button
            // 
            this.save_DB_toolstrip_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save_DB_toolstrip_button.Image = ((System.Drawing.Image)(resources.GetObject("save_DB_toolstrip_button.Image")));
            this.save_DB_toolstrip_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save_DB_toolstrip_button.Name = "save_DB_toolstrip_button";
            this.save_DB_toolstrip_button.Size = new System.Drawing.Size(23, 22);
            this.save_DB_toolstrip_button.Text = "Save to &DB";
            this.save_DB_toolstrip_button.Click += new System.EventHandler(this.toDBToolStripMenuItem1_Click);
            // 
            // save_all_db_toolstrip
            // 
            this.save_all_db_toolstrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save_all_db_toolstrip.Image = ((System.Drawing.Image)(resources.GetObject("save_all_db_toolstrip.Image")));
            this.save_all_db_toolstrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save_all_db_toolstrip.Name = "save_all_db_toolstrip";
            this.save_all_db_toolstrip.Size = new System.Drawing.Size(23, 22);
            this.save_all_db_toolstrip.Text = "Save All to &DB";
            this.save_all_db_toolstrip.Click += new System.EventHandler(this.toDBToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // preview_toolstrip_button
            // 
            this.preview_toolstrip_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.preview_toolstrip_button.Image = ((System.Drawing.Image)(resources.GetObject("preview_toolstrip_button.Image")));
            this.preview_toolstrip_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.preview_toolstrip_button.Name = "preview_toolstrip_button";
            this.preview_toolstrip_button.Size = new System.Drawing.Size(23, 22);
            this.preview_toolstrip_button.Text = "&Preview";
            this.preview_toolstrip_button.Click += new System.EventHandler(this.toToolStripMenuItem_Click);
            // 
            // delete_toolstrip_button
            // 
            this.delete_toolstrip_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delete_toolstrip_button.Image = ((System.Drawing.Image)(resources.GetObject("delete_toolstrip_button.Image")));
            this.delete_toolstrip_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delete_toolstrip_button.Name = "delete_toolstrip_button";
            this.delete_toolstrip_button.Size = new System.Drawing.Size(23, 22);
            this.delete_toolstrip_button.Text = "&Delete";
            this.delete_toolstrip_button.Click += new System.EventHandler(this.deletebutton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // SummonsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 251);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.customlistBoxsummons);
            this.Controls.Add(this.box_comment);
            this.Controls.Add(this.box_spawntimesecs);
            this.Controls.Add(this.box_orientation);
            this.Controls.Add(this.box_position_Z);
            this.Controls.Add(this.box_position_Y);
            this.Controls.Add(this.box_position_X);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonadd);
            this.Controls.Add(this.textboxadd);
            this.Controls.Add(this.summonID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxsearch);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SummonsEditor";
            this.ShowIcon = false;
            this.Text = "Summon Table Editor";
            this.Load += new System.EventHandler(this.SummonsEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonadd;
        private System.Windows.Forms.TextBox textboxadd;
        private System.Windows.Forms.Label summonID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxsearch;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox box_position_X;
        private System.Windows.Forms.TextBox box_position_Y;
        private System.Windows.Forms.TextBox box_position_Z;
        private System.Windows.Forms.TextBox box_orientation;
        private System.Windows.Forms.TextBox box_spawntimesecs;
        private System.Windows.Forms.TextBox box_comment;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveThisSummonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toDBToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toSQLFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAllSummonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toSQLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteThisSummonToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox customlistBoxsummons;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton saveAll_toolstrip_button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton save_DB_toolstrip_button;
        private System.Windows.Forms.ToolStripButton save_all_db_toolstrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton preview_toolstrip_button;
        private System.Windows.Forms.ToolStripButton delete_toolstrip_button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem toToolStripMenuItem;
    }
}
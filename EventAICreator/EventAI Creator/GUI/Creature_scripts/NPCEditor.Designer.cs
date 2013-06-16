namespace EventAI_Creator
{
    partial class NPCEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NPCEditor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllNPCsToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setInCreaturetemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.new_event_toolstrip_button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
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
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newEventToolStripMenuItem,
            this.saveToToolStripMenuItem,
            this.saveAllNPCsToToolStripMenuItem,
            this.setInCreaturetemplateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(733, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newEventToolStripMenuItem
            // 
            this.newEventToolStripMenuItem.Name = "newEventToolStripMenuItem";
            this.newEventToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.newEventToolStripMenuItem.Text = "New Event";
            this.newEventToolStripMenuItem.Click += new System.EventHandler(this.AddNewEvent);
            // 
            // saveToToolStripMenuItem
            // 
            this.saveToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.sQLFileToolStripMenuItem,
            this.queryWindowToolStripMenuItem});
            this.saveToToolStripMenuItem.Name = "saveToToolStripMenuItem";
            this.saveToToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.saveToToolStripMenuItem.Text = "Save NPC  to";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // sQLFileToolStripMenuItem
            // 
            this.sQLFileToolStripMenuItem.Name = "sQLFileToolStripMenuItem";
            this.sQLFileToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.sQLFileToolStripMenuItem.Text = "SQL File";
            this.sQLFileToolStripMenuItem.Click += new System.EventHandler(this.sQLFileToolStripMenuItem_Click);
            // 
            // queryWindowToolStripMenuItem
            // 
            this.queryWindowToolStripMenuItem.Name = "queryWindowToolStripMenuItem";
            this.queryWindowToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.queryWindowToolStripMenuItem.Text = "Query Window";
            this.queryWindowToolStripMenuItem.Click += new System.EventHandler(this.queryWindowToolStripMenuItem_Click);
            // 
            // saveAllNPCsToToolStripMenuItem
            // 
            this.saveAllNPCsToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem1,
            this.sQLToolStripMenuItem1});
            this.saveAllNPCsToToolStripMenuItem.Name = "saveAllNPCsToToolStripMenuItem";
            this.saveAllNPCsToToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.saveAllNPCsToToolStripMenuItem.Text = "Save All NPCs to";
            // 
            // databaseToolStripMenuItem1
            // 
            this.databaseToolStripMenuItem1.Name = "databaseToolStripMenuItem1";
            this.databaseToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.databaseToolStripMenuItem1.Text = "Database";
            this.databaseToolStripMenuItem1.Click += new System.EventHandler(this.databaseToolStripMenuItem1_Click);
            // 
            // sQLToolStripMenuItem1
            // 
            this.sQLToolStripMenuItem1.Name = "sQLToolStripMenuItem1";
            this.sQLToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.sQLToolStripMenuItem1.Text = "SQL";
            this.sQLToolStripMenuItem1.Click += new System.EventHandler(this.sQLToolStripMenuItem1_Click);
            // 
            // setInCreaturetemplateToolStripMenuItem
            // 
            this.setInCreaturetemplateToolStripMenuItem.Enabled = false;
            this.setInCreaturetemplateToolStripMenuItem.Name = "setInCreaturetemplateToolStripMenuItem";
            this.setInCreaturetemplateToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.setInCreaturetemplateToolStripMenuItem.Text = "Remove Scriptname";
            this.setInCreaturetemplateToolStripMenuItem.Click += new System.EventHandler(this.setInCreaturetemplateToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 600);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Size = new System.Drawing.Size(733, 600);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.new_event_toolstrip_button,
            this.toolStripSeparator3,
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(733, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // new_event_toolstrip_button
            // 
            this.new_event_toolstrip_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.new_event_toolstrip_button.Image = ((System.Drawing.Image)(resources.GetObject("new_event_toolstrip_button.Image")));
            this.new_event_toolstrip_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.new_event_toolstrip_button.Name = "new_event_toolstrip_button";
            this.new_event_toolstrip_button.Size = new System.Drawing.Size(23, 22);
            this.new_event_toolstrip_button.Text = "New Event";
            this.new_event_toolstrip_button.Click += new System.EventHandler(this.AddNewEvent);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.sQLFileToolStripMenuItem_Click);
            // 
            // saveAll_toolstrip_button
            // 
            this.saveAll_toolstrip_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAll_toolstrip_button.Image = ((System.Drawing.Image)(resources.GetObject("saveAll_toolstrip_button.Image")));
            this.saveAll_toolstrip_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAll_toolstrip_button.Name = "saveAll_toolstrip_button";
            this.saveAll_toolstrip_button.Size = new System.Drawing.Size(23, 22);
            this.saveAll_toolstrip_button.Text = "Save &All";
            this.saveAll_toolstrip_button.Click += new System.EventHandler(this.sQLToolStripMenuItem1_Click);
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
            this.save_DB_toolstrip_button.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // save_all_db_toolstrip
            // 
            this.save_all_db_toolstrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save_all_db_toolstrip.Image = ((System.Drawing.Image)(resources.GetObject("save_all_db_toolstrip.Image")));
            this.save_all_db_toolstrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save_all_db_toolstrip.Name = "save_all_db_toolstrip";
            this.save_all_db_toolstrip.Size = new System.Drawing.Size(23, 22);
            this.save_all_db_toolstrip.Text = "Save All to &DB";
            this.save_all_db_toolstrip.Click += new System.EventHandler(this.databaseToolStripMenuItem1_Click);
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
            this.preview_toolstrip_button.Click += new System.EventHandler(this.queryWindowToolStripMenuItem_Click);
            // 
            // delete_toolstrip_button
            // 
            this.delete_toolstrip_button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delete_toolstrip_button.Image = ((System.Drawing.Image)(resources.GetObject("delete_toolstrip_button.Image")));
            this.delete_toolstrip_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delete_toolstrip_button.Name = "delete_toolstrip_button";
            this.delete_toolstrip_button.Size = new System.Drawing.Size(23, 22);
            this.delete_toolstrip_button.Text = "&Delete";
            this.delete_toolstrip_button.Click += new System.EventHandler(this.setInCreaturetemplateToolStripMenuItem_Click);
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
            // NPCEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(733, 624);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NPCEditor";
            this.ShowIcon = false;
            this.Text = "MaNGOS eventAI development tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.NPCEditor_ControlRemoved);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem newEventToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem saveToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllNPCsToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sQLToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setInCreaturetemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton new_event_toolstrip_button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
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
        private System.Windows.Forms.ToolStripMenuItem queryWindowToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}


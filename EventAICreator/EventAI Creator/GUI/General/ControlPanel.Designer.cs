namespace EventAI_Creator.GUI.General
{
    partial class ControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.setallscriptnames = new System.Windows.Forms.Button();
            this.removescriptnames = new System.Windows.Forms.Button();
            this.updateofficialDB = new System.Windows.Forms.Button();
            this.CompileCreatures = new System.Windows.Forms.Button();
            this.CompileSummons = new System.Windows.Forms.Button();
            this.CompileTexts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // setallscriptnames
            // 
            this.setallscriptnames.Enabled = false;
            this.setallscriptnames.Location = new System.Drawing.Point(12, 12);
            this.setallscriptnames.Name = "setallscriptnames";
            this.setallscriptnames.Size = new System.Drawing.Size(85, 40);
            this.setallscriptnames.TabIndex = 0;
            this.setallscriptnames.Text = "Rekord all Scriptnames";
            this.setallscriptnames.UseVisualStyleBackColor = true;
            this.setallscriptnames.Click += new System.EventHandler(this.setallscriptnames_Click);
            // 
            // removescriptnames
            // 
            this.removescriptnames.Enabled = false;
            this.removescriptnames.Location = new System.Drawing.Point(12, 58);
            this.removescriptnames.Name = "removescriptnames";
            this.removescriptnames.Size = new System.Drawing.Size(85, 45);
            this.removescriptnames.TabIndex = 1;
            this.removescriptnames.Text = "Remove all Scriptnames";
            this.removescriptnames.UseVisualStyleBackColor = true;
            this.removescriptnames.Click += new System.EventHandler(this.removescriptnames_Click);
            // 
            // updateofficialDB
            // 
            this.updateofficialDB.Enabled = false;
            this.updateofficialDB.Location = new System.Drawing.Point(103, 12);
            this.updateofficialDB.Name = "updateofficialDB";
            this.updateofficialDB.Size = new System.Drawing.Size(98, 53);
            this.updateofficialDB.TabIndex = 2;
            this.updateofficialDB.Text = "Update Official Database with SQL Batchfile";
            this.updateofficialDB.UseVisualStyleBackColor = true;
            this.updateofficialDB.Click += new System.EventHandler(this.updateofficialDB_Click);
            // 
            // CompileCreatures
            // 
            this.CompileCreatures.Enabled = false;
            this.CompileCreatures.Location = new System.Drawing.Point(408, 12);
            this.CompileCreatures.Name = "CompileCreatures";
            this.CompileCreatures.Size = new System.Drawing.Size(90, 53);
            this.CompileCreatures.TabIndex = 3;
            this.CompileCreatures.Text = "Compile Custom and Official Creatures";
            this.CompileCreatures.UseVisualStyleBackColor = true;
            this.CompileCreatures.Click += new System.EventHandler(this.CompileCreatures_Click);
            // 
            // CompileSummons
            // 
            this.CompileSummons.Enabled = false;
            this.CompileSummons.Location = new System.Drawing.Point(207, 12);
            this.CompileSummons.Name = "CompileSummons";
            this.CompileSummons.Size = new System.Drawing.Size(96, 53);
            this.CompileSummons.TabIndex = 4;
            this.CompileSummons.Text = "Compile Custom and Official Summons";
            this.CompileSummons.UseVisualStyleBackColor = true;
            this.CompileSummons.Click += new System.EventHandler(this.CompileSummons_Click);
            // 
            // CompileTexts
            // 
            this.CompileTexts.Enabled = false;
            this.CompileTexts.Location = new System.Drawing.Point(309, 12);
            this.CompileTexts.Name = "CompileTexts";
            this.CompileTexts.Size = new System.Drawing.Size(93, 53);
            this.CompileTexts.TabIndex = 5;
            this.CompileTexts.Text = "Compile Custom and Official localized Texts";
            this.CompileTexts.UseVisualStyleBackColor = true;
            this.CompileTexts.Click += new System.EventHandler(this.CompileTexts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "May the Power be with you";
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 112);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CompileTexts);
            this.Controls.Add(this.CompileSummons);
            this.Controls.Add(this.CompileCreatures);
            this.Controls.Add(this.updateofficialDB);
            this.Controls.Add(this.removescriptnames);
            this.Controls.Add(this.setallscriptnames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlPanel";
            this.ShowIcon = false;
            this.Text = "Control Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setallscriptnames;
        private System.Windows.Forms.Button removescriptnames;
        private System.Windows.Forms.Button updateofficialDB;
        private System.Windows.Forms.Button CompileCreatures;
        private System.Windows.Forms.Button CompileSummons;
        private System.Windows.Forms.Button CompileTexts;
        private System.Windows.Forms.Label label1;
    }
}
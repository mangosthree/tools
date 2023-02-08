namespace EventAI_Creator
{
    partial class ScriptDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptDisplay));
            this.button_copy = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.textBox_query = new System.Windows.Forms.TextBox();
            this.button_execute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(405, 377);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(75, 23);
            this.button_copy.TabIndex = 0;
            this.button_copy.Text = "Copy";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click_1);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(511, 377);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 23);
            this.button_close.TabIndex = 1;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click_1);
            // 
            // textBox_query
            // 
            this.textBox_query.Location = new System.Drawing.Point(13, 13);
            this.textBox_query.Multiline = true;
            this.textBox_query.Name = "textBox_query";
            this.textBox_query.ReadOnly = true;
            this.textBox_query.Size = new System.Drawing.Size(859, 358);
            this.textBox_query.TabIndex = 2;
            this.textBox_query.WordWrap = false;
            // 
            // button_execute
            // 
            this.button_execute.Enabled = false;
            this.button_execute.Location = new System.Drawing.Point(299, 377);
            this.button_execute.Name = "button_execute";
            this.button_execute.Size = new System.Drawing.Size(75, 23);
            this.button_execute.TabIndex = 3;
            this.button_execute.Text = "Execute";
            this.button_execute.UseVisualStyleBackColor = true;
            this.button_execute.Click += new System.EventHandler(this.button_execute_Click);
            // 
            // ScriptDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 412);
            this.Controls.Add(this.button_execute);
            this.Controls.Add(this.textBox_query);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_copy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScriptDisplay";
            this.ShowIcon = false;
            this.Text = "Script Display";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.TextBox textBox_query;
        private System.Windows.Forms.Button button_execute;
    }
}
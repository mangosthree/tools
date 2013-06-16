namespace EventAI_Creator
{
    partial class DbScriptControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.eventCheckbox = new System.Windows.Forms.CheckBox();
            this.commentTextbox = new System.Windows.Forms.TextBox();
            this.groupBoxEvent = new System.Windows.Forms.GroupBox();
            this.labelAction = new System.Windows.Forms.Label();
            this.labelDelay = new System.Windows.Forms.Label();
            this.comboBoxAction = new System.Windows.Forms.ComboBox();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.comboBox_datalong2 = new System.Windows.Forms.ComboBox();
            this.comboBox_datalong = new System.Windows.Forms.ComboBox();
            this.button_datalong = new System.Windows.Forms.Button();
            this.button_datalong2 = new System.Windows.Forms.Button();
            this.button_flags = new System.Windows.Forms.Button();
            this.label_flags = new System.Windows.Forms.Label();
            this.label_radius = new System.Windows.Forms.Label();
            this.label_buddy = new System.Windows.Forms.Label();
            this.label_datalong2 = new System.Windows.Forms.Label();
            this.textBox_datalong2 = new System.Windows.Forms.TextBox();
            this.textBox_flags = new System.Windows.Forms.TextBox();
            this.textBox_radius = new System.Windows.Forms.TextBox();
            this.textBox_buddy = new System.Windows.Forms.TextBox();
            this.label_datalong = new System.Windows.Forms.Label();
            this.textBox_datalong = new System.Windows.Forms.TextBox();
            this.groupBoxDataInt = new System.Windows.Forms.GroupBox();
            this.label_dataint4 = new System.Windows.Forms.Label();
            this.label_dataint3 = new System.Windows.Forms.Label();
            this.label_dataint2 = new System.Windows.Forms.Label();
            this.label_dataint1 = new System.Windows.Forms.Label();
            this.textBox_dataint4 = new System.Windows.Forms.TextBox();
            this.textBox_dataint3 = new System.Windows.Forms.TextBox();
            this.textBox_dataint2 = new System.Windows.Forms.TextBox();
            this.textBox_dataint1 = new System.Windows.Forms.TextBox();
            this.groupBoxPosition = new System.Windows.Forms.GroupBox();
            this.label_orientation = new System.Windows.Forms.Label();
            this.label_posZ = new System.Windows.Forms.Label();
            this.label_posY = new System.Windows.Forms.Label();
            this.label_posX = new System.Windows.Forms.Label();
            this.textBox_orientation = new System.Windows.Forms.TextBox();
            this.textBox_posZ = new System.Windows.Forms.TextBox();
            this.textBox_posY = new System.Windows.Forms.TextBox();
            this.textBox_posX = new System.Windows.Forms.TextBox();
            this.button_delete_event = new System.Windows.Forms.Button();
            this.groupBox_details = new System.Windows.Forms.GroupBox();
            this.label_details = new System.Windows.Forms.Label();
            this.label_extra = new System.Windows.Forms.Label();
            this.label_target = new System.Windows.Forms.Label();
            this.label_tar = new System.Windows.Forms.Label();
            this.label_source = new System.Windows.Forms.Label();
            this.label_src = new System.Windows.Forms.Label();
            this.groupBoxEvent.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            this.groupBoxDataInt.SuspendLayout();
            this.groupBoxPosition.SuspendLayout();
            this.groupBox_details.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventCheckbox
            // 
            this.eventCheckbox.AutoSize = true;
            this.eventCheckbox.Location = new System.Drawing.Point(4, 4);
            this.eventCheckbox.Name = "eventCheckbox";
            this.eventCheckbox.Size = new System.Drawing.Size(63, 17);
            this.eventCheckbox.TabIndex = 0;
            this.eventCheckbox.Text = "Event 1";
            this.eventCheckbox.UseVisualStyleBackColor = true;
            this.eventCheckbox.CheckedChanged += new System.EventHandler(this.eventCheckbox_CheckedChanged);
            // 
            // commentTextbox
            // 
            this.commentTextbox.Location = new System.Drawing.Point(166, 27);
            this.commentTextbox.Name = "commentTextbox";
            this.commentTextbox.Size = new System.Drawing.Size(372, 20);
            this.commentTextbox.TabIndex = 1;
            this.commentTextbox.Text = "Comment";
            this.commentTextbox.Leave += new System.EventHandler(this.txtBox_comment_leave);
            // 
            // groupBoxEvent
            // 
            this.groupBoxEvent.Controls.Add(this.labelAction);
            this.groupBoxEvent.Controls.Add(this.labelDelay);
            this.groupBoxEvent.Controls.Add(this.comboBoxAction);
            this.groupBoxEvent.Controls.Add(this.textBoxDelay);
            this.groupBoxEvent.Location = new System.Drawing.Point(16, 27);
            this.groupBoxEvent.Name = "groupBoxEvent";
            this.groupBoxEvent.Size = new System.Drawing.Size(129, 129);
            this.groupBoxEvent.TabIndex = 2;
            this.groupBoxEvent.TabStop = false;
            this.groupBoxEvent.Text = "Event Settings";
            // 
            // labelAction
            // 
            this.labelAction.AutoSize = true;
            this.labelAction.Location = new System.Drawing.Point(10, 82);
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(54, 13);
            this.labelAction.TabIndex = 3;
            this.labelAction.Text = "Command";
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(10, 25);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(94, 13);
            this.labelDelay.TabIndex = 2;
            this.labelDelay.Text = "Delay (in seconds)";
            // 
            // comboBoxAction
            // 
            this.comboBoxAction.FormattingEnabled = true;
            this.comboBoxAction.Location = new System.Drawing.Point(10, 100);
            this.comboBoxAction.Name = "comboBoxAction";
            this.comboBoxAction.Size = new System.Drawing.Size(100, 21);
            this.comboBoxAction.TabIndex = 1;
            this.comboBoxAction.SelectedIndexChanged += new System.EventHandler(this.comboBoxAction_SelectedIndexChanged);
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Location = new System.Drawing.Point(10, 49);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(100, 20);
            this.textBoxDelay.TabIndex = 0;
            this.textBoxDelay.Leave += new System.EventHandler(this.txtBox_leave);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.comboBox_datalong2);
            this.groupBoxMain.Controls.Add(this.comboBox_datalong);
            this.groupBoxMain.Controls.Add(this.button_datalong);
            this.groupBoxMain.Controls.Add(this.button_datalong2);
            this.groupBoxMain.Controls.Add(this.button_flags);
            this.groupBoxMain.Controls.Add(this.label_flags);
            this.groupBoxMain.Controls.Add(this.label_radius);
            this.groupBoxMain.Controls.Add(this.label_buddy);
            this.groupBoxMain.Controls.Add(this.label_datalong2);
            this.groupBoxMain.Controls.Add(this.textBox_datalong2);
            this.groupBoxMain.Controls.Add(this.textBox_flags);
            this.groupBoxMain.Controls.Add(this.textBox_radius);
            this.groupBoxMain.Controls.Add(this.textBox_buddy);
            this.groupBoxMain.Controls.Add(this.label_datalong);
            this.groupBoxMain.Controls.Add(this.textBox_datalong);
            this.groupBoxMain.Location = new System.Drawing.Point(166, 52);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(372, 104);
            this.groupBoxMain.TabIndex = 3;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "Main Flags";
            // 
            // comboBox_datalong2
            // 
            this.comboBox_datalong2.FormattingEnabled = true;
            this.comboBox_datalong2.Location = new System.Drawing.Point(6, 73);
            this.comboBox_datalong2.Name = "comboBox_datalong2";
            this.comboBox_datalong2.Size = new System.Drawing.Size(100, 21);
            this.comboBox_datalong2.TabIndex = 14;
            this.comboBox_datalong2.Visible = false;
            this.comboBox_datalong2.SelectedIndexChanged += new System.EventHandler(this.comboBox_datalong2_SelectedIndexChanged);
            // 
            // comboBox_datalong
            // 
            this.comboBox_datalong.FormattingEnabled = true;
            this.comboBox_datalong.Location = new System.Drawing.Point(6, 33);
            this.comboBox_datalong.Name = "comboBox_datalong";
            this.comboBox_datalong.Size = new System.Drawing.Size(100, 21);
            this.comboBox_datalong.TabIndex = 13;
            this.comboBox_datalong.Visible = false;
            this.comboBox_datalong.SelectedIndexChanged += new System.EventHandler(this.comboBox_datalong_SelectedIndexChanged);
            // 
            // button_datalong
            // 
            this.button_datalong.Location = new System.Drawing.Point(56, 33);
            this.button_datalong.Name = "button_datalong";
            this.button_datalong.Size = new System.Drawing.Size(50, 20);
            this.button_datalong.TabIndex = 12;
            this.button_datalong.Text = "Select";
            this.button_datalong.UseVisualStyleBackColor = true;
            this.button_datalong.Click += new System.EventHandler(this.button_datalong2_Click);
            // 
            // button_datalong2
            // 
            this.button_datalong2.Location = new System.Drawing.Point(56, 73);
            this.button_datalong2.Name = "button_datalong2";
            this.button_datalong2.Size = new System.Drawing.Size(50, 20);
            this.button_datalong2.TabIndex = 11;
            this.button_datalong2.Text = "Select";
            this.button_datalong2.UseVisualStyleBackColor = true;
            this.button_datalong2.Visible = false;
            this.button_datalong2.Click += new System.EventHandler(this.button_datalong2_Click);
            // 
            // button_flags
            // 
            this.button_flags.Location = new System.Drawing.Point(312, 66);
            this.button_flags.Name = "button_flags";
            this.button_flags.Size = new System.Drawing.Size(50, 20);
            this.button_flags.TabIndex = 10;
            this.button_flags.Text = "Select";
            this.button_flags.UseVisualStyleBackColor = true;
            this.button_flags.Click += new System.EventHandler(this.button_flags_Click);
            // 
            // label_flags
            // 
            this.label_flags.AutoSize = true;
            this.label_flags.Location = new System.Drawing.Point(112, 73);
            this.label_flags.Name = "label_flags";
            this.label_flags.Size = new System.Drawing.Size(58, 13);
            this.label_flags.TabIndex = 9;
            this.label_flags.Text = "Data Flags";
            // 
            // label_radius
            // 
            this.label_radius.AutoSize = true;
            this.label_radius.Location = new System.Drawing.Point(112, 46);
            this.label_radius.Name = "label_radius";
            this.label_radius.Size = new System.Drawing.Size(103, 13);
            this.label_radius.TabIndex = 8;
            this.label_radius.Text = "Buddy search radius";
            // 
            // label_buddy
            // 
            this.label_buddy.AutoSize = true;
            this.label_buddy.Location = new System.Drawing.Point(112, 19);
            this.label_buddy.Name = "label_buddy";
            this.label_buddy.Size = new System.Drawing.Size(144, 13);
            this.label_buddy.TabIndex = 7;
            this.label_buddy.Text = "Buddy Entry (Creature or GO)";
            // 
            // label_datalong2
            // 
            this.label_datalong2.AutoSize = true;
            this.label_datalong2.Location = new System.Drawing.Point(6, 57);
            this.label_datalong2.Name = "label_datalong2";
            this.label_datalong2.Size = new System.Drawing.Size(56, 13);
            this.label_datalong2.TabIndex = 6;
            this.label_datalong2.Text = "Datalong2";
            // 
            // textBox_datalong2
            // 
            this.textBox_datalong2.Location = new System.Drawing.Point(6, 73);
            this.textBox_datalong2.Name = "textBox_datalong2";
            this.textBox_datalong2.Size = new System.Drawing.Size(100, 20);
            this.textBox_datalong2.TabIndex = 5;
            this.textBox_datalong2.Leave += new System.EventHandler(this.txtBox_leave);
            // 
            // textBox_flags
            // 
            this.textBox_flags.Location = new System.Drawing.Point(262, 66);
            this.textBox_flags.Name = "textBox_flags";
            this.textBox_flags.Size = new System.Drawing.Size(50, 20);
            this.textBox_flags.TabIndex = 4;
            this.textBox_flags.Leave += new System.EventHandler(this.txtBox_leave);
            // 
            // textBox_radius
            // 
            this.textBox_radius.Location = new System.Drawing.Point(262, 41);
            this.textBox_radius.Name = "textBox_radius";
            this.textBox_radius.Size = new System.Drawing.Size(100, 20);
            this.textBox_radius.TabIndex = 3;
            this.textBox_radius.Leave += new System.EventHandler(this.txtBox_leave);
            // 
            // textBox_buddy
            // 
            this.textBox_buddy.Location = new System.Drawing.Point(262, 16);
            this.textBox_buddy.Name = "textBox_buddy";
            this.textBox_buddy.Size = new System.Drawing.Size(100, 20);
            this.textBox_buddy.TabIndex = 2;
            this.textBox_buddy.Leave += new System.EventHandler(this.txtBox_leave);
            // 
            // label_datalong
            // 
            this.label_datalong.AutoSize = true;
            this.label_datalong.Location = new System.Drawing.Point(6, 17);
            this.label_datalong.Name = "label_datalong";
            this.label_datalong.Size = new System.Drawing.Size(50, 13);
            this.label_datalong.TabIndex = 1;
            this.label_datalong.Text = "Datalong";
            // 
            // textBox_datalong
            // 
            this.textBox_datalong.Location = new System.Drawing.Point(6, 33);
            this.textBox_datalong.Name = "textBox_datalong";
            this.textBox_datalong.Size = new System.Drawing.Size(100, 20);
            this.textBox_datalong.TabIndex = 0;
            this.textBox_datalong.Leave += new System.EventHandler(this.txtBox_leave);
            // 
            // groupBoxDataInt
            // 
            this.groupBoxDataInt.Controls.Add(this.label_dataint4);
            this.groupBoxDataInt.Controls.Add(this.label_dataint3);
            this.groupBoxDataInt.Controls.Add(this.label_dataint2);
            this.groupBoxDataInt.Controls.Add(this.label_dataint1);
            this.groupBoxDataInt.Controls.Add(this.textBox_dataint4);
            this.groupBoxDataInt.Controls.Add(this.textBox_dataint3);
            this.groupBoxDataInt.Controls.Add(this.textBox_dataint2);
            this.groupBoxDataInt.Controls.Add(this.textBox_dataint1);
            this.groupBoxDataInt.Location = new System.Drawing.Point(16, 162);
            this.groupBoxDataInt.Name = "groupBoxDataInt";
            this.groupBoxDataInt.Size = new System.Drawing.Size(445, 60);
            this.groupBoxDataInt.TabIndex = 4;
            this.groupBoxDataInt.TabStop = false;
            this.groupBoxDataInt.Text = "Data Int Flags";
            // 
            // label_dataint4
            // 
            this.label_dataint4.AutoSize = true;
            this.label_dataint4.Location = new System.Drawing.Point(327, 16);
            this.label_dataint4.Name = "label_dataint4";
            this.label_dataint4.Size = new System.Drawing.Size(48, 13);
            this.label_dataint4.TabIndex = 8;
            this.label_dataint4.Text = "DataInt4";
            // 
            // label_dataint3
            // 
            this.label_dataint3.AutoSize = true;
            this.label_dataint3.Location = new System.Drawing.Point(221, 16);
            this.label_dataint3.Name = "label_dataint3";
            this.label_dataint3.Size = new System.Drawing.Size(48, 13);
            this.label_dataint3.TabIndex = 7;
            this.label_dataint3.Text = "DataInt3";
            // 
            // label_dataint2
            // 
            this.label_dataint2.AutoSize = true;
            this.label_dataint2.Location = new System.Drawing.Point(115, 16);
            this.label_dataint2.Name = "label_dataint2";
            this.label_dataint2.Size = new System.Drawing.Size(48, 13);
            this.label_dataint2.TabIndex = 5;
            this.label_dataint2.Text = "DataInt2";
            // 
            // label_dataint1
            // 
            this.label_dataint1.AutoSize = true;
            this.label_dataint1.Location = new System.Drawing.Point(7, 16);
            this.label_dataint1.Name = "label_dataint1";
            this.label_dataint1.Size = new System.Drawing.Size(48, 13);
            this.label_dataint1.TabIndex = 4;
            this.label_dataint1.Text = "DataInt1";
            // 
            // textBox_dataint4
            // 
            this.textBox_dataint4.Location = new System.Drawing.Point(330, 32);
            this.textBox_dataint4.Name = "textBox_dataint4";
            this.textBox_dataint4.ReadOnly = true;
            this.textBox_dataint4.Size = new System.Drawing.Size(100, 20);
            this.textBox_dataint4.TabIndex = 3;
            this.textBox_dataint4.Leave += new System.EventHandler(this.txtBox_leave);
            // 
            // textBox_dataint3
            // 
            this.textBox_dataint3.Location = new System.Drawing.Point(224, 32);
            this.textBox_dataint3.Name = "textBox_dataint3";
            this.textBox_dataint3.ReadOnly = true;
            this.textBox_dataint3.Size = new System.Drawing.Size(100, 20);
            this.textBox_dataint3.TabIndex = 2;
            this.textBox_dataint3.Leave += new System.EventHandler(this.txtBox_leave);
            // 
            // textBox_dataint2
            // 
            this.textBox_dataint2.Location = new System.Drawing.Point(118, 32);
            this.textBox_dataint2.Name = "textBox_dataint2";
            this.textBox_dataint2.ReadOnly = true;
            this.textBox_dataint2.Size = new System.Drawing.Size(100, 20);
            this.textBox_dataint2.TabIndex = 1;
            this.textBox_dataint2.Leave += new System.EventHandler(this.txtBox_leave);
            // 
            // textBox_dataint1
            // 
            this.textBox_dataint1.Location = new System.Drawing.Point(10, 32);
            this.textBox_dataint1.Name = "textBox_dataint1";
            this.textBox_dataint1.ReadOnly = true;
            this.textBox_dataint1.Size = new System.Drawing.Size(100, 20);
            this.textBox_dataint1.TabIndex = 0;
            this.textBox_dataint1.Leave += new System.EventHandler(this.txtBox_leave);
            // 
            // groupBoxPosition
            // 
            this.groupBoxPosition.Controls.Add(this.label_orientation);
            this.groupBoxPosition.Controls.Add(this.label_posZ);
            this.groupBoxPosition.Controls.Add(this.label_posY);
            this.groupBoxPosition.Controls.Add(this.label_posX);
            this.groupBoxPosition.Controls.Add(this.textBox_orientation);
            this.groupBoxPosition.Controls.Add(this.textBox_posZ);
            this.groupBoxPosition.Controls.Add(this.textBox_posY);
            this.groupBoxPosition.Controls.Add(this.textBox_posX);
            this.groupBoxPosition.Location = new System.Drawing.Point(16, 228);
            this.groupBoxPosition.Name = "groupBoxPosition";
            this.groupBoxPosition.Size = new System.Drawing.Size(445, 62);
            this.groupBoxPosition.TabIndex = 5;
            this.groupBoxPosition.TabStop = false;
            this.groupBoxPosition.Text = "Position";
            // 
            // label_orientation
            // 
            this.label_orientation.AutoSize = true;
            this.label_orientation.Location = new System.Drawing.Point(327, 20);
            this.label_orientation.Name = "label_orientation";
            this.label_orientation.Size = new System.Drawing.Size(58, 13);
            this.label_orientation.TabIndex = 7;
            this.label_orientation.Text = "Orientation";
            // 
            // label_posZ
            // 
            this.label_posZ.AutoSize = true;
            this.label_posZ.Location = new System.Drawing.Point(221, 20);
            this.label_posZ.Name = "label_posZ";
            this.label_posZ.Size = new System.Drawing.Size(54, 13);
            this.label_posZ.TabIndex = 6;
            this.label_posZ.Text = "Position Z";
            // 
            // label_posY
            // 
            this.label_posY.AutoSize = true;
            this.label_posY.Location = new System.Drawing.Point(115, 20);
            this.label_posY.Name = "label_posY";
            this.label_posY.Size = new System.Drawing.Size(54, 13);
            this.label_posY.TabIndex = 5;
            this.label_posY.Text = "Position Y";
            // 
            // label_posX
            // 
            this.label_posX.AutoSize = true;
            this.label_posX.Location = new System.Drawing.Point(10, 20);
            this.label_posX.Name = "label_posX";
            this.label_posX.Size = new System.Drawing.Size(54, 13);
            this.label_posX.TabIndex = 4;
            this.label_posX.Text = "Position X";
            // 
            // textBox_orientation
            // 
            this.textBox_orientation.Location = new System.Drawing.Point(328, 36);
            this.textBox_orientation.Name = "textBox_orientation";
            this.textBox_orientation.ReadOnly = true;
            this.textBox_orientation.Size = new System.Drawing.Size(100, 20);
            this.textBox_orientation.TabIndex = 3;
            this.textBox_orientation.Leave += new System.EventHandler(this.txtBox_leave_location);
            // 
            // textBox_posZ
            // 
            this.textBox_posZ.Location = new System.Drawing.Point(222, 36);
            this.textBox_posZ.Name = "textBox_posZ";
            this.textBox_posZ.ReadOnly = true;
            this.textBox_posZ.Size = new System.Drawing.Size(100, 20);
            this.textBox_posZ.TabIndex = 2;
            this.textBox_posZ.Leave += new System.EventHandler(this.txtBox_leave_location);
            // 
            // textBox_posY
            // 
            this.textBox_posY.Location = new System.Drawing.Point(116, 36);
            this.textBox_posY.Name = "textBox_posY";
            this.textBox_posY.ReadOnly = true;
            this.textBox_posY.Size = new System.Drawing.Size(100, 20);
            this.textBox_posY.TabIndex = 1;
            this.textBox_posY.Leave += new System.EventHandler(this.txtBox_leave_location);
            // 
            // textBox_posX
            // 
            this.textBox_posX.Location = new System.Drawing.Point(10, 36);
            this.textBox_posX.Name = "textBox_posX";
            this.textBox_posX.ReadOnly = true;
            this.textBox_posX.Size = new System.Drawing.Size(100, 20);
            this.textBox_posX.TabIndex = 0;
            this.textBox_posX.Leave += new System.EventHandler(this.txtBox_leave_location);
            // 
            // button_delete_event
            // 
            this.button_delete_event.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_delete_event.Location = new System.Drawing.Point(469, 0);
            this.button_delete_event.Name = "button_delete_event";
            this.button_delete_event.Size = new System.Drawing.Size(84, 20);
            this.button_delete_event.TabIndex = 6;
            this.button_delete_event.Text = "Delete Event";
            this.button_delete_event.UseVisualStyleBackColor = true;
            this.button_delete_event.Click += new System.EventHandler(this.button_delete_event_Click);
            // 
            // groupBox_details
            // 
            this.groupBox_details.Controls.Add(this.label_details);
            this.groupBox_details.Controls.Add(this.label_extra);
            this.groupBox_details.Controls.Add(this.label_target);
            this.groupBox_details.Controls.Add(this.label_tar);
            this.groupBox_details.Controls.Add(this.label_source);
            this.groupBox_details.Controls.Add(this.label_src);
            this.groupBox_details.Location = new System.Drawing.Point(469, 162);
            this.groupBox_details.Name = "groupBox_details";
            this.groupBox_details.Size = new System.Drawing.Size(69, 128);
            this.groupBox_details.TabIndex = 7;
            this.groupBox_details.TabStop = false;
            this.groupBox_details.Text = "Details";
            // 
            // label_details
            // 
            this.label_details.AutoSize = true;
            this.label_details.Location = new System.Drawing.Point(7, 102);
            this.label_details.Name = "label_details";
            this.label_details.Size = new System.Drawing.Size(37, 13);
            this.label_details.TabIndex = 5;
            this.label_details.Text = "details";
            // 
            // label_extra
            // 
            this.label_extra.AutoSize = true;
            this.label_extra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_extra.Location = new System.Drawing.Point(7, 86);
            this.label_extra.Name = "label_extra";
            this.label_extra.Size = new System.Drawing.Size(67, 13);
            this.label_extra.TabIndex = 4;
            this.label_extra.Text = "Additional:";
            // 
            // label_target
            // 
            this.label_target.AutoSize = true;
            this.label_target.Location = new System.Drawing.Point(6, 65);
            this.label_target.Name = "label_target";
            this.label_target.Size = new System.Drawing.Size(34, 13);
            this.label_target.TabIndex = 3;
            this.label_target.Text = "target";
            // 
            // label_tar
            // 
            this.label_tar.AutoSize = true;
            this.label_tar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tar.Location = new System.Drawing.Point(6, 52);
            this.label_tar.Name = "label_tar";
            this.label_tar.Size = new System.Drawing.Size(48, 13);
            this.label_tar.TabIndex = 2;
            this.label_tar.Text = "Target:";
            // 
            // label_source
            // 
            this.label_source.AutoSize = true;
            this.label_source.Location = new System.Drawing.Point(6, 29);
            this.label_source.Name = "label_source";
            this.label_source.Size = new System.Drawing.Size(39, 13);
            this.label_source.TabIndex = 1;
            this.label_source.Text = "source";
            // 
            // label_src
            // 
            this.label_src.AutoSize = true;
            this.label_src.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_src.Location = new System.Drawing.Point(6, 16);
            this.label_src.Name = "label_src";
            this.label_src.Size = new System.Drawing.Size(51, 13);
            this.label_src.TabIndex = 0;
            this.label_src.Text = "Source:";
            // 
            // DbScriptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_details);
            this.Controls.Add(this.button_delete_event);
            this.Controls.Add(this.groupBoxPosition);
            this.Controls.Add(this.groupBoxDataInt);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.groupBoxEvent);
            this.Controls.Add(this.commentTextbox);
            this.Controls.Add(this.eventCheckbox);
            this.Name = "DbScriptControl";
            this.Size = new System.Drawing.Size(553, 305);
            this.groupBoxEvent.ResumeLayout(false);
            this.groupBoxEvent.PerformLayout();
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.groupBoxDataInt.ResumeLayout(false);
            this.groupBoxDataInt.PerformLayout();
            this.groupBoxPosition.ResumeLayout(false);
            this.groupBoxPosition.PerformLayout();
            this.groupBox_details.ResumeLayout(false);
            this.groupBox_details.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox eventCheckbox;
        private System.Windows.Forms.TextBox commentTextbox;
        private System.Windows.Forms.GroupBox groupBoxEvent;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.GroupBox groupBoxDataInt;
        private System.Windows.Forms.GroupBox groupBoxPosition;
        private System.Windows.Forms.ComboBox comboBoxAction;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.Label labelAction;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.TextBox textBox_dataint1;
        private System.Windows.Forms.TextBox textBox_dataint4;
        private System.Windows.Forms.TextBox textBox_dataint3;
        private System.Windows.Forms.TextBox textBox_dataint2;
        private System.Windows.Forms.TextBox textBox_orientation;
        private System.Windows.Forms.TextBox textBox_posZ;
        private System.Windows.Forms.TextBox textBox_posY;
        private System.Windows.Forms.TextBox textBox_posX;
        private System.Windows.Forms.Label label_dataint2;
        private System.Windows.Forms.Label label_dataint1;
        private System.Windows.Forms.Label label_orientation;
        private System.Windows.Forms.Label label_posZ;
        private System.Windows.Forms.Label label_posY;
        private System.Windows.Forms.Label label_posX;
        private System.Windows.Forms.Label label_flags;
        private System.Windows.Forms.Label label_radius;
        private System.Windows.Forms.Label label_buddy;
        private System.Windows.Forms.Label label_datalong2;
        private System.Windows.Forms.TextBox textBox_datalong2;
        private System.Windows.Forms.TextBox textBox_flags;
        private System.Windows.Forms.TextBox textBox_radius;
        private System.Windows.Forms.TextBox textBox_buddy;
        private System.Windows.Forms.Label label_datalong;
        private System.Windows.Forms.TextBox textBox_datalong;
        private System.Windows.Forms.Label label_dataint4;
        private System.Windows.Forms.Label label_dataint3;
        private System.Windows.Forms.Button button_flags;
        private System.Windows.Forms.Button button_delete_event;
        private System.Windows.Forms.GroupBox groupBox_details;
        private System.Windows.Forms.Label label_source;
        private System.Windows.Forms.Label label_src;
        private System.Windows.Forms.Label label_tar;
        private System.Windows.Forms.Label label_details;
        private System.Windows.Forms.Label label_extra;
        private System.Windows.Forms.Label label_target;
        private System.Windows.Forms.Button button_datalong2;
        private System.Windows.Forms.Button button_datalong;
        private System.Windows.Forms.ComboBox comboBox_datalong;
        private System.Windows.Forms.ComboBox comboBox_datalong2;
    }
}

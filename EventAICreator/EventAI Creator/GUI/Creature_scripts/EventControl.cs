using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventAI_Creator
{
    public partial class EventControl : UserControl
    {
        int eventid;
        uint creature_id;
        bool locked = true;
        
        public EventControl(Event_dataset Data,Int32 ID,uint creatureid)
        {
            InitializeComponent();
            this.Name = ID.ToString();
            eventid = ID;
            creature_id = creatureid;
            this.eventnumber.Text = "Event: " + ID.ToString();

            this.expand.Checked = true;

            for(int n=0; n < Info.EventListInfo.GetLength(0);n++)
                this.EventTypeCBox.Items.Add(Info.EventListInfo[n,0]);

            // set width
            EventTypeCBox.DropDownWidth = DropDownWidth(EventTypeCBox);

            for (int n = 0; n < Info.ActionListInfo.GetLength(0); n++)
            {
                this.Action1TypeCBox.Items.Add(Info.ActionListInfo[n, 0]);
                this.Action2TypeCBox.Items.Add(Info.ActionListInfo[n, 0]);
                this.Action3TypeCBox.Items.Add(Info.ActionListInfo[n, 0]);
            }

            this.Action1TypeCBox.SelectedIndex      =       Data.action1_type;
            this.Action1Param1Tbox.Text             =       Data.action1_param1.ToString();
            this.Action1Param2Tbox.Text             =       Data.action1_param2.ToString();
            this.Action1Param3Tbox.Text             =       Data.action1_param3.ToString();

            this.Action2TypeCBox.SelectedIndex      =       Data.action2_type;
            this.Action2Param1Tbox.Text             =       Data.action2_param1.ToString();
            this.Action2Param2Tbox.Text             =       Data.action2_param2.ToString();
            this.Action2Param3Tbox.Text             =       Data.action2_param3.ToString();

            this.Action3TypeCBox.SelectedIndex      =       Data.action3_type;
            this.Action3Param1Tbox.Text             =       Data.action3_param1.ToString();
            this.Action3Param2Tbox.Text             =       Data.action3_param2.ToString();
            this.Action3Param3Tbox.Text             =       Data.action3_param3.ToString();

            this.EventTypeCBox.SelectedIndex        =       Data.event_type;
            this.EventParam1.Text                   =       Data.event_param1.ToString();
            this.EventParam2.Text                   =       Data.event_param2.ToString();
            this.EventParam3.Text                   =       Data.event_param3.ToString();
            this.EventParam4.Text                   =       Data.event_param4.ToString();

            this.EventChanceTBox.Text               =       Data.event_chance.ToString();
            this.EventFlagTBox.Text                 =       Data.event_flags.ToString();
            this.txtBoxComment.Text                 =       Data.comment;

            this.SetInversePhaseMask(Data.event_inverse_phase_mask);

            this.EventTypeCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Action1TypeCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Action2TypeCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Action3TypeCBox.DropDownStyle = ComboBoxStyle.DropDownList;

            // set width
            Action1TypeCBox.DropDownWidth = DropDownWidth(Action1TypeCBox);
            Action2TypeCBox.DropDownWidth = DropDownWidth(Action2TypeCBox);
            Action3TypeCBox.DropDownWidth = DropDownWidth(Action3TypeCBox);

            // load combo boxes
            switch (Action1TypeCBox.SelectedIndex)
            {
                case 11:            // Cast
                case 12:            // Summon
                case 13:            // Threat single
                case 15:            // Quest event
                case 18:            // Set unit flag
                case 19:            // Remove unit flag
                case 32:            // Summon
                case 33:            // Killed unit
                case 34:            // Set instance data
                case 35:            // Set instance data 64
                case 36:            // Update template
                    Action1Param2Combobox.SelectedIndex = Convert.ToInt32(Action1Param2Tbox.Text);
                    break;
                case 16:            // Cast creature/go
                case 17:            // Set unit field
                    Action1Param3Combobox.SelectedIndex = Convert.ToInt32(Action1Param3Tbox.Text);
                    break;
                case 20:            // Auto attack
                case 28:            // Remove aura
                case 40:            // Set Sheat
                case 42:            // Set invincibility level
                    Action1Param1Combobox.SelectedIndex = Convert.ToInt32(Action1Param1Tbox.Text);
                    break;
                case 21:            // Combat movement
                    Action1Param1Combobox.SelectedIndex = Convert.ToInt32(Action1Param1Tbox.Text);
                    Action1Param2Combobox.SelectedIndex = Convert.ToInt32(Action1Param2Tbox.Text);
                    break;
            }
            switch (Action2TypeCBox.SelectedIndex)
            {
                case 11:            // Cast
                case 12:            // Summon
                case 13:            // Threat single
                case 15:            // Quest event
                case 18:            // Set unit flag
                case 19:            // Remove unit flag
                case 32:            // Summon
                case 33:            // Killed unit
                case 34:            // Set instance data
                case 35:            // Set instance data 64
                case 36:            // Update template
                    Action2Param2Combobox.SelectedIndex = Convert.ToInt32(Action2Param2Tbox.Text);
                    break;
                case 16:            // Cast creature/go
                case 17:            // Set unit field
                    Action2Param3Combobox.SelectedIndex = Convert.ToInt32(Action2Param3Tbox.Text);
                    break;
                case 20:            // Auto attack
                case 28:            // Remove aura
                case 40:            // Set Sheat
                case 42:            // Set invincibility level
                    Action2Param1Combobox.SelectedIndex = Convert.ToInt32(Action2Param1Tbox.Text);
                    break;
                case 21:            // Combat movement
                    Action2Param1Combobox.SelectedIndex = Convert.ToInt32(Action2Param1Tbox.Text);
                    Action2Param2Combobox.SelectedIndex = Convert.ToInt32(Action2Param2Tbox.Text);
                    break;
            }
            switch (Action3TypeCBox.SelectedIndex)
            {
                case 11:            // Cast
                case 12:            // Summon
                case 13:            // Threat single
                case 15:            // Quest event
                case 18:            // Set unit flag
                case 19:            // Remove unit flag
                case 32:            // Summon
                case 33:            // Killed unit
                case 34:            // Set instance data
                case 35:            // Set instance data 64
                case 36:            // Update template
                    Action3Param2Combobox.SelectedIndex = Convert.ToInt32(Action3Param2Tbox.Text);
                    break;
                case 16:            // Cast creature/go
                case 17:            // Set unit field
                    Action3Param3Combobox.SelectedIndex = Convert.ToInt32(Action3Param3Tbox.Text);
                    break;
                case 20:            // Auto attack
                case 28:            // Remove aura
                case 40:            // Set Sheat
                case 42:            // Set invincibility level
                    Action3Param1Combobox.SelectedIndex = Convert.ToInt32(Action3Param1Tbox.Text);
                    break;
                case 21:            // Combat movement
                    Action3Param1Combobox.SelectedIndex = Convert.ToInt32(Action3Param1Tbox.Text);
                    Action3Param2Combobox.SelectedIndex = Convert.ToInt32(Action3Param2Tbox.Text);
                    break;
            }

            locked = false;
        }

        private void SetInversePhaseMask(uint map)
        {
            uint bla;
            for (int i = 32; i > 0; i--)
            {
                bla = 0;
                for (int ii = 0; ii < i; ii++)
                {
                    bla = bla * 2;
                    if (bla == 0)
                        bla++;
                }
                if (map >= bla)
                {
                    switch (bla)
                    {
                        case 1:
                            this.PhaseCheckBox01.Checked = true;
                            break;
                        case 2:
                            this.PhaseCheckBox02.Checked = true;
                            break;
                        case 4:
                            this.PhaseCheckBox03.Checked = true;
                            break;
                        case 8:
                            this.PhaseCheckBox04.Checked = true;
                            break;
                        case 16:
                            this.PhaseCheckBox05.Checked = true;
                            break;
                        case 32:
                            this.PhaseCheckBox06.Checked = true;
                            break;
                        case 64:
                            this.PhaseCheckBox07.Checked = true;
                            break;
                        case 128:
                            this.PhaseCheckBox08.Checked = true;
                            break;
                        case 256:
                            this.PhaseCheckBox09.Checked = true;
                            break;
                        case 512:
                            this.PhaseCheckBox10.Checked = true;
                            break;
                        case 1024:
                            this.PhaseCheckBox11.Checked = true;
                            break;
                        case 2048:
                            this.PhaseCheckBox12.Checked = true;
                            break;
                        case 4096:
                            this.PhaseCheckBox13.Checked = true;
                            break;
                        case 8192:
                            this.PhaseCheckBox14.Checked = true;
                            break;
                        case 16384:
                            this.PhaseCheckBox15.Checked = true;
                            break;
                        case 32768:
                            this.PhaseCheckBox16.Checked = true;
                            break;
                        case 65536:
                            this.PhaseCheckBox17.Checked = true;
                            break;
                        case 131072:
                            this.PhaseCheckBox18.Checked = true;
                            break;
                        case 262144:
                            this.PhaseCheckBox19.Checked = true;
                            break;
                        case 524288:
                            this.PhaseCheckBox20.Checked = true;
                            break;
                        case 1048576:
                            this.PhaseCheckBox21.Checked = true;
                            break;
                        case 2097152:
                            this.PhaseCheckBox22.Checked = true;
                            break;
                        case 4194304:
                            this.PhaseCheckBox23.Checked = true;
                            break;
                        case 8388608:
                            this.PhaseCheckBox24.Checked = true;
                            break;
                        case 16777216:
                            this.PhaseCheckBox25.Checked = true;
                            break;
                        case 33554432:
                            this.PhaseCheckBox26.Checked = true;
                            break;
                        case 67108864:
                            this.PhaseCheckBox27.Checked = true;
                            break;
                        case 134217728:
                            this.PhaseCheckBox28.Checked = true;
                            break;
                        case 268435456:
                            this.PhaseCheckBox29.Checked = true;
                            break;
                        case 536870912:
                            this.PhaseCheckBox30.Checked = true;
                            break;
                        case 1073741824:
                            this.PhaseCheckBox31.Checked = true;
                            break;
                        case 2147483648:
                            this.PhaseCheckBox32.Checked = true;
                            break;
                    }
                    map -= bla;
                }
            }
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public Event_dataset GetEventData()
        {
                Event_dataset Data = new Event_dataset();

                Data.action1_type = this.Action1TypeCBox.SelectedIndex;
                if (Action1Param1Tbox.Text.Length != 0 && Action1Param1Tbox.Text != "-") Data.action1_param1 = System.Convert.ToInt64(this.Action1Param1Tbox.Text);
                if (Action1Param2Tbox.Text.Length != 0 && Action1Param2Tbox.Text != "-") Data.action1_param2 = System.Convert.ToInt32(this.Action1Param2Tbox.Text);
                if (Action1Param3Tbox.Text.Length != 0 && Action1Param3Tbox.Text != "-") Data.action1_param3 = System.Convert.ToInt32(this.Action1Param3Tbox.Text);

                Data.action2_type = this.Action2TypeCBox.SelectedIndex;
                if (Action2Param1Tbox.Text.Length != 0 && Action2Param1Tbox.Text != "-") Data.action2_param1 = System.Convert.ToInt64(this.Action2Param1Tbox.Text);
                if (Action2Param2Tbox.Text.Length != 0 && Action2Param2Tbox.Text != "-") Data.action2_param2 = System.Convert.ToInt32(this.Action2Param2Tbox.Text);
                if (Action2Param3Tbox.Text.Length != 0 && Action2Param3Tbox.Text != "-") Data.action2_param3 = System.Convert.ToInt32(this.Action2Param3Tbox.Text);

                Data.action3_type = this.Action3TypeCBox.SelectedIndex;
                if (Action3Param1Tbox.Text.Length != 0 && Action3Param1Tbox.Text != "-") Data.action3_param1 = System.Convert.ToInt64(this.Action3Param1Tbox.Text);
                if (Action3Param2Tbox.Text.Length != 0 && Action3Param2Tbox.Text != "-") Data.action3_param2 = System.Convert.ToInt32(this.Action3Param2Tbox.Text);
                if (Action3Param3Tbox.Text.Length != 0 && Action3Param3Tbox.Text != "-") Data.action3_param3 = System.Convert.ToInt32(this.Action3Param3Tbox.Text);

                Data.event_type = this.EventTypeCBox.SelectedIndex;
                if (EventParam1.Text.Length != 0 && EventParam1.Text != "-") Data.event_param1 = System.Convert.ToInt32(this.EventParam1.Text);
                if (EventParam2.Text.Length != 0 && EventParam2.Text != "-") Data.event_param2 = System.Convert.ToInt32(this.EventParam2.Text);
                if (EventParam3.Text.Length != 0 && EventParam3.Text != "-") Data.event_param3 = System.Convert.ToInt32(this.EventParam3.Text);
                if (EventParam4.Text.Length != 0 && EventParam4.Text != "-") Data.event_param4 = System.Convert.ToInt32(this.EventParam4.Text);

                if (EventChanceTBox.Text.Length != 0 && EventChanceTBox.Text != "-") Data.event_chance = System.Convert.ToInt32(this.EventChanceTBox.Text);
                if (EventFlagTBox.Text.Length != 0 && EventFlagTBox.Text != "-") Data.event_flags = System.Convert.ToInt32(this.EventFlagTBox.Text);
                if (txtBoxComment.Text.Length != 0 && txtBoxComment.Text != "-") Data.comment = this.txtBoxComment.Text;

                Data.event_inverse_phase_mask = 0;

                if (this.PhaseCheckBox01.Checked) Data.event_inverse_phase_mask += 1;
                if (this.PhaseCheckBox02.Checked) Data.event_inverse_phase_mask += 2;
                if (this.PhaseCheckBox03.Checked) Data.event_inverse_phase_mask += 4;
                if (this.PhaseCheckBox04.Checked) Data.event_inverse_phase_mask += 8;
                if (this.PhaseCheckBox05.Checked) Data.event_inverse_phase_mask += 16;
                if (this.PhaseCheckBox06.Checked) Data.event_inverse_phase_mask += 32;
                if (this.PhaseCheckBox07.Checked) Data.event_inverse_phase_mask += 64;
                if (this.PhaseCheckBox08.Checked) Data.event_inverse_phase_mask += 128;
                if (this.PhaseCheckBox09.Checked) Data.event_inverse_phase_mask += 256;
                if (this.PhaseCheckBox10.Checked) Data.event_inverse_phase_mask += 512;
                if (this.PhaseCheckBox11.Checked) Data.event_inverse_phase_mask += 1024;
                if (this.PhaseCheckBox12.Checked) Data.event_inverse_phase_mask += 2048;
                if (this.PhaseCheckBox13.Checked) Data.event_inverse_phase_mask += 4096;
                if (this.PhaseCheckBox14.Checked) Data.event_inverse_phase_mask += 8192;
                if (this.PhaseCheckBox15.Checked) Data.event_inverse_phase_mask += 16384;
                if (this.PhaseCheckBox16.Checked) Data.event_inverse_phase_mask += 32768;
                if (this.PhaseCheckBox17.Checked) Data.event_inverse_phase_mask += 65536;
                if (this.PhaseCheckBox18.Checked) Data.event_inverse_phase_mask += 131072;
                if (this.PhaseCheckBox19.Checked) Data.event_inverse_phase_mask += 262144;
                if (this.PhaseCheckBox20.Checked) Data.event_inverse_phase_mask += 524288;
                if (this.PhaseCheckBox21.Checked) Data.event_inverse_phase_mask += 1048576;
                if (this.PhaseCheckBox22.Checked) Data.event_inverse_phase_mask += 2097152;
                if (this.PhaseCheckBox23.Checked) Data.event_inverse_phase_mask += 4194304;
                if (this.PhaseCheckBox24.Checked) Data.event_inverse_phase_mask += 8388608;
                if (this.PhaseCheckBox25.Checked) Data.event_inverse_phase_mask += 16777216;
                if (this.PhaseCheckBox26.Checked) Data.event_inverse_phase_mask += 33554432;
                if (this.PhaseCheckBox27.Checked) Data.event_inverse_phase_mask += 67108864;
                if (this.PhaseCheckBox28.Checked) Data.event_inverse_phase_mask += 134217728;
                if (this.PhaseCheckBox29.Checked) Data.event_inverse_phase_mask += 268435456;
                if (this.PhaseCheckBox30.Checked) Data.event_inverse_phase_mask += 536870912;
                if (this.PhaseCheckBox31.Checked) Data.event_inverse_phase_mask += 1073741824;
                if (this.PhaseCheckBox32.Checked) Data.event_inverse_phase_mask += 2147483648;

                creatures.npcList[creature_id].line[eventid] = Data;
                creatures.npcList[creature_id].changed = true;
                return Data;
        }

        private void EventTypeCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolTip.SetToolTip((sender as ComboBox),Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 5]);
            if(Info.EventListInfo[this.EventTypeCBox.SelectedIndex,1] == "")
            {
                this.lblevParam1.Text = "Param 1";
                this.EventParam1.Text = "0";
                this.EventParam1.Enabled = false;
            }
            else 
            {
                this.lblevParam1.Text = Info.EventListInfo[this.EventTypeCBox.SelectedIndex,1];
                this.EventParam1.Text = "0";
                this.EventParam1.Enabled = true;
            }
            if (Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 2] == "")
            {
                this.lblevParam2.Text = "Param 2";
                this.EventParam2.Text = "0";
                this.EventParam2.Enabled = false;
            }
            else
            {
                this.lblevParam2.Text = Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 2];
                this.EventParam2.Text = "0";
                this.EventParam2.Enabled = true;
            }
            if (Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 3] == "")
            {
                this.lblevParam3.Text = "Param 3";
                this.EventParam3.Text = "0";
                this.EventParam3.Enabled = false;
            }
            else
            {
                this.lblevParam3.Text = Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 3];
                this.EventParam3.Text = "0";
                this.EventParam3.Enabled = true;
            }
            if (Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 4] == "")
            {
                this.lblevParam4.Text = "Param 4";
                this.EventParam4.Text = "0";
                this.EventParam4.Enabled = false;
            }
            else
            {
                this.lblevParam4.Text = Info.EventListInfo[this.EventTypeCBox.SelectedIndex, 4];
                this.EventParam4.Text = "0";
                this.EventParam4.Enabled = true;
            }

            // Costumize Spell hit
            if (EventTypeCBox.SelectedIndex == 8)
            {
                this.EventParam2.Width = 50;
                this.button_spell_mask.Visible = true;
            }
            else
            {
                this.EventParam2.Width = 100;
                this.button_spell_mask.Visible = false;
            }

            if (!locked)
                GetEventData();
        }


        private void ActionTypeCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox Cbox = (sender as ComboBox);
            Label[] Labl = new Label[3];
            TextBox[] Tbox = new TextBox[3];
            if (Cbox == this.Action1TypeCBox)
            {
                Labl[0] = this.Action1Param1Lb;
                Labl[1] = this.Action1Param2Lb;
                Labl[2] = this.Action1Param3Lb;
                Tbox[0] = this.Action1Param1Tbox;
                Tbox[1] = this.Action1Param2Tbox;
                Tbox[2] = this.Action1Param3Tbox;

                // reset cast
                Action1Param3_button.Visible = false;
                Action1Param3Tbox.Width = 100;
                Action1Param2_button.Visible = false;
                Action1Param2Tbox.Width = 100;
                Action1Param1_button.Visible = false;
                Action1Param1Tbox.Width = 100;
                // reset combo box 1
                Action1Param1Combobox.Visible = false;
                Action1Param1Combobox.Items.Clear();
                Action1Param1Tbox.Visible = true;
                // reset combo box 2
                Action1Param2Combobox.Visible = false;
                Action1Param2Combobox.Items.Clear();
                Action1Param2Tbox.Visible = true;
                // reset combo box 3
                Action1Param3Combobox.Visible = false;
                Action1Param3Combobox.Items.Clear();
                Action1Param3Tbox.Visible = true;

                switch (Cbox.SelectedIndex)
                {
                    case 2:             // Set faction
                        Action1Param2_button.Visible = true;
                        Action1Param2Tbox.Width = 50;
                        break;
                    case 11:            // Cast
                        Action1Param3_button.Visible = true;
                        Action1Param3Tbox.Width = 50;
                        Action1Param2Combobox.Visible = true;
                        Action1Param2Combobox.Items.AddRange(Info.TargetType);
                        Action1Param2Combobox.SelectedIndex = 0;
                        Action1Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action1Param2Combobox.DropDownWidth = DropDownWidth(Action1Param2Combobox);
                        Action1Param2Tbox.Visible = false;
                        break;
                    case 12:            // Summon
                    case 13:            // Threat single
                    case 15:            // Quest event
                    case 32:            // Summon
                    case 33:            // Killed unit
                    case 35:            // Set instance data 64
                        Action1Param2Combobox.Visible = true;
                        Action1Param2Combobox.Items.AddRange(Info.TargetType);
                        Action1Param2Combobox.SelectedIndex = 0;
                        Action1Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action1Param2Combobox.DropDownWidth = DropDownWidth(Action1Param2Combobox);
                        Action1Param2Tbox.Visible = false;
                        break;
                    case 16:            // Cast creature/go
                    case 17:            // Set unit field
                        Action1Param3Combobox.Visible = true;
                        Action1Param3Combobox.Items.AddRange(Info.TargetType);
                        Action1Param3Combobox.SelectedIndex = 0;
                        Action1Param3Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action1Param3Combobox.DropDownWidth = DropDownWidth(Action1Param3Combobox);
                        Action1Param3Tbox.Visible = false;
                        break;
                    case 18:            // Set unit flag
                    case 19:            // Remove unit flag
                        Action1Param1_button.Visible = true;
                        Action1Param1Tbox.Width = 50;

                        Action1Param2Combobox.Visible = true;
                        Action1Param2Combobox.Items.AddRange(Info.TargetType);
                        Action1Param2Combobox.SelectedIndex = 0;
                        Action1Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action1Param2Combobox.DropDownWidth = DropDownWidth(Action1Param2Combobox);
                        Action1Param2Tbox.Visible = false;
                        break;
                    case 20:            // Auto attack
                        Action1Param1Combobox.Visible = true;
                        Action1Param1Combobox.Items.AddRange(Info.Boolean);
                        Action1Param1Combobox.SelectedIndex = 0;
                        Action1Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action1Param1Combobox.DropDownWidth = DropDownWidth(Action1Param1Combobox);
                        Action1Param1Tbox.Visible = false;
                        break;
                    case 21:            // Combat movement
                        Action1Param1Combobox.Visible = true;
                        Action1Param1Combobox.Items.AddRange(Info.Boolean);
                        Action1Param1Combobox.SelectedIndex = 0;
                        Action1Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action1Param1Combobox.DropDownWidth = DropDownWidth(Action1Param1Combobox);
                        Action1Param1Tbox.Visible = false;

                        Action1Param2Combobox.Visible = true;
                        Action1Param2Combobox.Items.AddRange(Info.Boolean);
                        Action1Param2Combobox.SelectedIndex = 0;
                        Action1Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action1Param2Combobox.DropDownWidth = DropDownWidth(Action1Param2Combobox);
                        Action1Param2Tbox.Visible = false;
                        break;
                    case 22:            // Set phase
                        Action1Param1_button.Visible = true;
                        Action1Param1Tbox.Width = 50;
                        break;
                    case 28:            // Remove aura
                        Action1Param1Combobox.Visible = true;
                        Action1Param1Combobox.Items.AddRange(Info.TargetType);
                        Action1Param1Combobox.SelectedIndex = 0;
                        Action1Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action1Param1Combobox.DropDownWidth = DropDownWidth(Action1Param1Combobox);
                        Action1Param1Tbox.Visible = false;
                        break;
                    case 30:            // Random phase
                        Action1Param1_button.Visible = true;
                        Action1Param1Tbox.Width = 50;
                        Action1Param2_button.Visible = true;
                        Action1Param2Tbox.Width = 50;
                        Action1Param3_button.Visible = true;
                        Action1Param3Tbox.Width = 50;
                        break;
                    case 31:            // Random phase range
                        Action1Param1_button.Visible = true;
                        Action1Param1Tbox.Width = 50;
                        Action1Param2_button.Visible = true;
                        Action1Param2Tbox.Width = 50;
                        break;
                    case 34:            // Set instance data
                        Action1Param2Combobox.Visible = true;
                        Action1Param2Combobox.Items.AddRange(Info.InstanceData);
                        Action1Param2Combobox.SelectedIndex = 0;
                        Action1Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action1Param2Combobox.DropDownWidth = DropDownWidth(Action1Param2Combobox);
                        Action1Param2Tbox.Visible = false;
                        break;
                    case 36:            // Update template
                        Action1Param2Combobox.Visible = true;
                        Action1Param2Combobox.Items.AddRange(Info.TeamTemplate);
                        Action1Param2Combobox.SelectedIndex = 0;
                        Action1Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action1Param2Combobox.DropDownWidth = DropDownWidth(Action1Param2Combobox);
                        Action1Param2Tbox.Visible = false;
                        break;
                    case 40:            // Set Sheat
                        Action1Param1Combobox.Visible = true;
                        Action1Param1Combobox.Items.AddRange(Info.SheathState);
                        Action1Param1Combobox.SelectedIndex = 0;
                        Action1Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action1Param1Combobox.DropDownWidth = DropDownWidth(Action1Param1Combobox);
                        Action1Param1Tbox.Visible = false;
                        break;
                    case 42:            // Set invincibility level
                        Action1Param1Combobox.Visible = true;
                        Action1Param1Combobox.Items.AddRange(Info.InvincibilityTemplate);
                        Action1Param1Combobox.SelectedIndex = 0;
                        Action1Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action1Param1Combobox.DropDownWidth = DropDownWidth(Action1Param1Combobox);
                        Action1Param1Tbox.Visible = false;
                        break;
                }
            }
            if (Cbox == this.Action2TypeCBox)
            {
                Labl[0] = this.Action2Param1Lb;
                Labl[1] = this.Action2Param2Lb;
                Labl[2] = this.Action2Param3Lb;
                Tbox[0] = this.Action2Param1Tbox;
                Tbox[1] = this.Action2Param2Tbox;
                Tbox[2] = this.Action2Param3Tbox;

                // reset cast
                Action2Param3_button.Visible = false;
                Action2Param3Tbox.Width = 100;
                Action2Param2_button.Visible = false;
                Action2Param2Tbox.Width = 100;
                Action2Param1_button.Visible = false;
                Action2Param1Tbox.Width = 100;
                // reset combo box 1
                Action2Param1Combobox.Visible = false;
                Action2Param1Combobox.Items.Clear();
                Action2Param1Tbox.Visible = true;
                // reset combo box 2
                Action2Param2Combobox.Visible = false;
                Action2Param2Combobox.Items.Clear();
                Action2Param2Tbox.Visible = true;
                // reset combo box 3
                Action2Param3Combobox.Visible = false;
                Action2Param3Combobox.Items.Clear();
                Action2Param3Tbox.Visible = true;

                switch (Cbox.SelectedIndex)
                {
                    case 2:             // Set faction
                        Action2Param2_button.Visible = true;
                        Action2Param2Tbox.Width = 50;
                        break;
                    case 11:            // Cast
                        Action2Param3_button.Visible = true;
                        Action2Param3Tbox.Width = 50;

                        Action2Param2Combobox.Visible = true;
                        Action2Param2Combobox.Items.AddRange(Info.TargetType);
                        Action2Param2Combobox.SelectedIndex = 0;
                        Action2Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action2Param2Combobox.DropDownWidth = DropDownWidth(Action2Param2Combobox);
                        Action2Param2Tbox.Visible = false;
                        break;
                    case 12:            // Summon
                    case 13:            // Threat single
                    case 15:            // Quest event
                    case 32:            // Summon
                    case 33:            // Killed unit
                    case 35:            // Set instance data 64
                        Action2Param2Combobox.Visible = true;
                        Action2Param2Combobox.Items.AddRange(Info.TargetType);
                        Action2Param2Combobox.SelectedIndex = 0;
                        Action2Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action2Param2Combobox.DropDownWidth = DropDownWidth(Action2Param2Combobox);
                        Action2Param2Tbox.Visible = false;
                        break;
                    case 16:            // Cast creature/go
                    case 17:            // Set unit field
                        Action2Param3Combobox.Visible = true;
                        Action2Param3Combobox.Items.AddRange(Info.TargetType);
                        Action2Param3Combobox.SelectedIndex = 0;
                        Action2Param3Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action2Param3Combobox.DropDownWidth = DropDownWidth(Action2Param3Combobox);
                        Action2Param3Tbox.Visible = false;
                        break;
                    case 18:            // Set unit flag
                    case 19:            // Remove unit flag
                        Action2Param1_button.Visible = true;
                        Action2Param1Tbox.Width = 50;

                        Action2Param2Combobox.Visible = true;
                        Action2Param2Combobox.Items.AddRange(Info.TargetType);
                        Action2Param2Combobox.SelectedIndex = 0;
                        Action2Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action2Param2Combobox.DropDownWidth = DropDownWidth(Action2Param2Combobox);
                        Action2Param2Tbox.Visible = false;
                        break;
                    case 20:            // Auto attack
                        Action2Param1Combobox.Visible = true;
                        Action2Param1Combobox.Items.AddRange(Info.Boolean);
                        Action2Param1Combobox.SelectedIndex = 0;
                        Action2Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action2Param1Combobox.DropDownWidth = DropDownWidth(Action2Param1Combobox);
                        Action2Param1Tbox.Visible = false;
                        break;
                    case 21:            // Combat movement
                        Action2Param1Combobox.Visible = true;
                        Action2Param1Combobox.Items.AddRange(Info.Boolean);
                        Action2Param1Combobox.SelectedIndex = 0;
                        Action2Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action2Param1Combobox.DropDownWidth = DropDownWidth(Action2Param1Combobox);
                        Action2Param1Tbox.Visible = false;

                        Action2Param2Combobox.Visible = true;
                        Action2Param2Combobox.Items.AddRange(Info.Boolean);
                        Action2Param2Combobox.SelectedIndex = 0;
                        Action2Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action2Param2Combobox.DropDownWidth = DropDownWidth(Action2Param2Combobox);
                        Action2Param2Tbox.Visible = false;
                        break;
                    case 22:            // Set phase
                        Action2Param1_button.Visible = true;
                        Action2Param1Tbox.Width = 50;
                        break;
                    case 28:            // Remove aura
                        Action2Param1Combobox.Visible = true;
                        Action2Param1Combobox.Items.AddRange(Info.TargetType);
                        Action2Param1Combobox.SelectedIndex = 0;
                        Action2Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action2Param1Combobox.DropDownWidth = DropDownWidth(Action2Param1Combobox);
                        Action2Param1Tbox.Visible = false;
                        break;
                    case 30:            // Random phase
                        Action2Param1_button.Visible = true;
                        Action2Param1Tbox.Width = 50;
                        Action2Param2_button.Visible = true;
                        Action2Param2Tbox.Width = 50;
                        Action2Param3_button.Visible = true;
                        Action2Param3Tbox.Width = 50;
                        break;
                    case 31:            // Random phase range
                        Action2Param1_button.Visible = true;
                        Action2Param1Tbox.Width = 50;
                        Action2Param2_button.Visible = true;
                        Action2Param2Tbox.Width = 50;
                        break;
                    case 34:            // Set instance data
                        Action2Param2Combobox.Visible = true;
                        Action2Param2Combobox.Items.AddRange(Info.InstanceData);
                        Action2Param2Combobox.SelectedIndex = 0;
                        Action2Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action2Param2Combobox.DropDownWidth = DropDownWidth(Action2Param2Combobox);
                        Action2Param2Tbox.Visible = false;
                        break;
                    case 36:            // Update template
                        Action2Param2Combobox.Visible = true;
                        Action2Param2Combobox.Items.AddRange(Info.TeamTemplate);
                        Action2Param2Combobox.SelectedIndex = 0;
                        Action2Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action2Param2Combobox.DropDownWidth = DropDownWidth(Action2Param2Combobox);
                        Action2Param2Tbox.Visible = false;
                        break;
                    case 40:            // Set Sheat
                        Action2Param1Combobox.Visible = true;
                        Action2Param1Combobox.Items.AddRange(Info.SheathState);
                        Action2Param1Combobox.SelectedIndex = 0;
                        Action2Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action2Param1Combobox.DropDownWidth = DropDownWidth(Action2Param1Combobox);
                        Action2Param1Tbox.Visible = false;
                        break;
                    case 42:            // Set invincibility level
                        Action2Param1Combobox.Visible = true;
                        Action2Param1Combobox.Items.AddRange(Info.InvincibilityTemplate);
                        Action2Param1Combobox.SelectedIndex = 0;
                        Action2Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action2Param1Combobox.DropDownWidth = DropDownWidth(Action2Param1Combobox);
                        Action2Param1Tbox.Visible = false;
                        break;
                }
            }
            if (Cbox == this.Action3TypeCBox)
            {
                Labl[0] = this.Action3Param1Lb;
                Labl[1] = this.Action3Param2Lb;
                Labl[2] = this.Action3Param3Lb;
                Tbox[0] = this.Action3Param1Tbox;
                Tbox[1] = this.Action3Param2Tbox;
                Tbox[2] = this.Action3Param3Tbox;

                // reset cast
                Action3Param3_button.Visible = false;
                Action3Param3Tbox.Width = 100;
                Action3Param2_button.Visible = false;
                Action3Param2Tbox.Width = 100;
                Action3Param1_button.Visible = false;
                Action3Param1Tbox.Width = 100;
                // reset combo box 1
                Action3Param1Combobox.Visible = false;
                Action3Param1Combobox.Items.Clear();
                Action3Param1Tbox.Visible = true;
                // reset combo box 2
                Action3Param2Combobox.Visible = false;
                Action3Param2Combobox.Items.Clear();
                Action3Param2Tbox.Visible = true;
                // reset combo box 3
                Action3Param3Combobox.Visible = false;
                Action3Param3Combobox.Items.Clear();
                Action3Param3Tbox.Visible = true;

                switch (Cbox.SelectedIndex)
                {
                    case 2:             // Set faction
                        Action3Param2_button.Visible = true;
                        Action3Param2Tbox.Width = 50;
                        break;
                    case 11:            // Cast
                        Action3Param3_button.Visible = true;
                        Action3Param3Tbox.Width = 50;

                        Action3Param2Combobox.Visible = true;
                        Action3Param2Combobox.Items.AddRange(Info.TargetType);
                        Action3Param2Combobox.SelectedIndex = 0;
                        Action3Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action3Param2Combobox.DropDownWidth = DropDownWidth(Action3Param2Combobox);
                        Action3Param2Tbox.Visible = false;
                        break;
                    case 12:            // Summon
                    case 13:            // Threat single
                    case 15:            // Quest event
                    case 32:            // Summon
                    case 33:            // Killed unit
                    case 35:            // Set instance data 64
                        Action3Param2Combobox.Visible = true;
                        Action3Param2Combobox.Items.AddRange(Info.TargetType);
                        Action3Param2Combobox.SelectedIndex = 0;
                        Action3Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action3Param2Combobox.DropDownWidth = DropDownWidth(Action3Param2Combobox);
                        Action3Param2Tbox.Visible = false;
                        break;
                    case 16:            // Cast creature/go
                    case 17:            // Set unit field
                        Action3Param3Combobox.Visible = true;
                        Action3Param3Combobox.Items.AddRange(Info.TargetType);
                        Action3Param3Combobox.SelectedIndex = 0;
                        Action3Param3Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action3Param3Combobox.DropDownWidth = DropDownWidth(Action3Param3Combobox);
                        Action3Param3Tbox.Visible = false;
                        break;
                    case 18:            // Set unit flag
                    case 19:            // Remove unit flag
                        Action3Param1_button.Visible = true;
                        Action3Param1Tbox.Width = 50;

                        Action3Param2Combobox.Visible = true;
                        Action3Param2Combobox.Items.AddRange(Info.TargetType);
                        Action3Param2Combobox.SelectedIndex = 0;
                        Action3Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action3Param2Combobox.DropDownWidth = DropDownWidth(Action3Param2Combobox);
                        Action3Param2Tbox.Visible = false;
                        break;
                    case 20:            // Auto attack
                        Action3Param1Combobox.Visible = true;
                        Action3Param1Combobox.Items.AddRange(Info.Boolean);
                        Action3Param1Combobox.SelectedIndex = 0;
                        Action3Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action3Param1Combobox.DropDownWidth = DropDownWidth(Action3Param1Combobox);
                        Action3Param1Tbox.Visible = false;
                        break;
                    case 21:            // Combat movement
                        Action3Param1Combobox.Visible = true;
                        Action3Param1Combobox.Items.AddRange(Info.Boolean);
                        Action3Param1Combobox.SelectedIndex = 0;
                        Action3Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action3Param1Combobox.DropDownWidth = DropDownWidth(Action3Param1Combobox);
                        Action3Param1Tbox.Visible = false;

                        Action3Param2Combobox.Visible = true;
                        Action3Param2Combobox.Items.AddRange(Info.Boolean);
                        Action3Param2Combobox.SelectedIndex = 0;
                        Action3Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action3Param2Combobox.DropDownWidth = DropDownWidth(Action3Param2Combobox);
                        Action3Param2Tbox.Visible = false;
                        break;
                    case 22:            // Set phase
                        Action3Param1_button.Visible = true;
                        Action3Param1Tbox.Width = 50;
                        break;
                    case 28:            // Remove aura
                        Action3Param1Combobox.Visible = true;
                        Action3Param1Combobox.Items.AddRange(Info.TargetType);
                        Action3Param1Combobox.SelectedIndex = 0;
                        Action3Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action3Param1Combobox.DropDownWidth = DropDownWidth(Action3Param1Combobox);
                        Action3Param1Tbox.Visible = false;
                        break;
                    case 30:            // Random phase
                        Action3Param1_button.Visible = true;
                        Action3Param1Tbox.Width = 50;
                        Action3Param2_button.Visible = true;
                        Action3Param2Tbox.Width = 50;
                        Action3Param3_button.Visible = true;
                        Action3Param3Tbox.Width = 50;
                        break;
                    case 31:            // Random phase range
                        Action3Param1_button.Visible = true;
                        Action3Param1Tbox.Width = 50;
                        Action3Param2_button.Visible = true;
                        Action3Param2Tbox.Width = 50;
                        break;
                    case 34:            // Set instance data
                        Action3Param2Combobox.Visible = true;
                        Action3Param2Combobox.Items.AddRange(Info.InstanceData);
                        Action3Param2Combobox.SelectedIndex = 0;
                        Action3Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action3Param2Combobox.DropDownWidth = DropDownWidth(Action3Param2Combobox);
                        Action3Param2Tbox.Visible = false;
                        break;
                    case 36:            // Update template
                        Action3Param2Combobox.Visible = true;
                        Action3Param2Combobox.Items.AddRange(Info.TeamTemplate);
                        Action3Param2Combobox.SelectedIndex = 0;
                        Action3Param2Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action3Param2Combobox.DropDownWidth = DropDownWidth(Action3Param2Combobox);
                        Action3Param2Tbox.Visible = false;
                        break;
                    case 40:            // Set Sheat
                        Action3Param1Combobox.Visible = true;
                        Action3Param1Combobox.Items.AddRange(Info.SheathState);
                        Action3Param1Combobox.SelectedIndex = 0;
                        Action3Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action3Param1Combobox.DropDownWidth = DropDownWidth(Action3Param1Combobox);
                        Action3Param1Tbox.Visible = false;
                        break;
                    case 42:            // Set invincibility level
                        Action3Param1Combobox.Visible = true;
                        Action3Param1Combobox.Items.AddRange(Info.InvincibilityTemplate);
                        Action3Param1Combobox.SelectedIndex = 0;
                        Action3Param1Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                        Action3Param1Combobox.DropDownWidth = DropDownWidth(Action3Param1Combobox);
                        Action3Param1Tbox.Visible = false;
                        break;
                }
            }

            toolTip.SetToolTip((sender as ComboBox), Info.ActionListInfo[Cbox.SelectedIndex, 4]);

            for (int n = 0; n < 3; n++)
            {
                if (Info.ActionListInfo[Cbox.SelectedIndex, n+1] != "")
                {
                    Labl[n].Text = Info.ActionListInfo[Cbox.SelectedIndex, n+1];
                    Tbox[n].Text = "0";

                    Tbox[n].Enabled = true;

                    //switch (Info.ActionListInfo[Cbox.SelectedIndex, n + 1])
                    //{
                    //    case "Target":
                    //        toolTip.SetToolTip(Tbox[n], "0    TARGET_T_SELF\n1    TARGET_T_HOSTILE \n2    TARGET_T_HOSTILE_SECOND_AGGRO\n3    TARGET_T_HOSTILE_LAST_AGGRO\n4    TARGET_T_HOSTILE_RANDOM\n5    TARGET_T_HOSTILE_RANDOM_NOT_TOP\n6    TARGET_T_ACTION_INVOKER");
                    //        break;
                    //    case "CastFlags":
                    //        toolTip.SetToolTip(Tbox[n], "1 :0       CAST_INTURRUPT_PREVIOUS\n2 :1       CAST_TRIGGERED\n4 :2       CAST_FORCE_CAST\n8 :3       CAST_NO_MELEE_IF_OOM\n16:4       CAST_FORCE_TARGET_SELF");
                    //        break;
                    //}
                }
                else
                {

                    Labl[n].Text = "Param "+n.ToString();
                    Tbox[n].Text = "0";
                    Tbox[n].Enabled = false;
                    toolTip.SetToolTip(Tbox[n], "");
                }
            }
            if (!locked)
                GetEventData();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nothing here
        }

        private void txtBoxComment_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nothing here
        }

        // Expand collapse events
        private void expand_CheckedChanged(object sender, EventArgs e)
        {
            if (this.expand.Checked)
                this.Height = 287;
            else
                this.Height = 20;
        }

        // Delete event
        private void deleteevent_Click(object sender, EventArgs e)
        {
            Form blaa = this.ParentForm;
            NPCEditor bla = blaa as NPCEditor;
            uint creature_id = bla.Id;
            creatures.npcList[creature_id].line.RemoveAt(eventid);
            bla.Redraw(creature_id);
        }

        private void control_changed(object sender, EventArgs e)
        {
            // Nothing heres
        }

        // Handle if the text is number
        private void txtBox_Leave(object sender, EventArgs e)
        {
            string str = (sender as TextBox).Text.Trim();
            Int64 value;
            bool isNum = Int64.TryParse(str, out value);
            if (isNum)
            {
                if (!locked)
                    GetEventData();
            }
            else
                (sender as TextBox).Text = "0";
        }

        // Handle the comment text leave
        private void txtBoxComment_Leave(object sender, EventArgs e)
        {
            if (!locked)
                GetEventData();
        }

        // Set combo box 1 value
        private void Action1Param1Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (sender as ComboBox);

            if (box == this.Action1Param1Combobox)
                Action1Param1Tbox.Text = Action1Param1Combobox.SelectedIndex.ToString();
            else if (box == this.Action2Param1Combobox)
                Action2Param1Tbox.Text = Action2Param1Combobox.SelectedIndex.ToString();
            else if (box == this.Action3Param1Combobox)
                Action3Param1Tbox.Text = Action3Param1Combobox.SelectedIndex.ToString();

            if (!locked)
                GetEventData();
        }

        // Set combo box 2 value
        private void Action1Param2Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (sender as ComboBox);

            if (box == this.Action1Param2Combobox)
                Action1Param2Tbox.Text = Action1Param2Combobox.SelectedIndex.ToString();
            else if (box == this.Action2Param2Combobox)
                Action2Param2Tbox.Text = Action2Param2Combobox.SelectedIndex.ToString();
            else if (box == this.Action3Param2Combobox)
                Action3Param2Tbox.Text = Action3Param2Combobox.SelectedIndex.ToString();

            if (!locked)
                GetEventData();
        }

        // Set combo box 3 value
        private void Action1Param3Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (sender as ComboBox);

            if (box == this.Action1Param3Combobox)
                Action1Param3Tbox.Text = Action1Param3Combobox.SelectedIndex.ToString();
            else if (box == this.Action2Param3Combobox)
                Action2Param3Tbox.Text = Action2Param3Combobox.SelectedIndex.ToString();
            else if (box == this.Action3Param3Combobox)
                Action3Param3Tbox.Text = Action3Param3Combobox.SelectedIndex.ToString();

            if (!locked)
                GetEventData();
        }

        // Load event flags selection
        private void button_flag_select_Click(object sender, EventArgs e)
        {
            EventFlag dialog = new EventFlag(this, Convert.ToInt32(this.EventFlagTBox.Text), Info.EventFlags, 0, 0);
            dialog.ShowDialog(this);
        }

        // Load spell mask selection
        private void button_spell_mask_Click(object sender, EventArgs e)
        {
            EventFlag dialog = new EventFlag(this, Convert.ToInt32(this.EventParam2.Text), Info.SpellSchoolMask, 1, 0);
            dialog.ShowDialog(this);
        }

        // Load param 3 flags
        private void Action1Param3_button_Click(object sender, EventArgs e)
        {
            Button but = (sender as Button);
            EventFlag dialog = null;

            if (but == this.Action1Param3_button)
            {
                if (Action1TypeCBox.SelectedIndex == 11)
                    dialog = new EventFlag(this, Convert.ToInt32(this.Action1Param3Tbox.Text), Info.CastFlags, 2, 1);
                else if (Action1TypeCBox.SelectedIndex == 22 || Action1TypeCBox.SelectedIndex == 30)
                    dialog = new EventFlag(this, Convert.ToInt64(this.Action1Param3Tbox.Text), Info.EventPhases, 2, 1);
            }
            else if (but == this.Action2Param3_button)
            {
                if (Action2TypeCBox.SelectedIndex == 11)
                    dialog = new EventFlag(this, Convert.ToInt32(this.Action2Param3Tbox.Text), Info.CastFlags, 2, 2);
                else if (Action2TypeCBox.SelectedIndex == 22 || Action2TypeCBox.SelectedIndex == 30)
                    dialog = new EventFlag(this, Convert.ToInt64(this.Action2Param3Tbox.Text), Info.EventPhases, 2, 2);
            }
            else if (but == this.Action3Param3_button)
            {
                if (Action3TypeCBox.SelectedIndex == 11)
                    dialog = new EventFlag(this, Convert.ToInt32(this.Action3Param3Tbox.Text), Info.CastFlags, 2, 3);
                else if (Action3TypeCBox.SelectedIndex == 22 || Action3TypeCBox.SelectedIndex == 30)
                    dialog = new EventFlag(this, Convert.ToInt64(this.Action3Param3Tbox.Text), Info.EventPhases, 2, 3);
            }

            dialog.ShowDialog(this);
        }

        // Load param 2 flags
        private void Action1Param2_button_Click(object sender, EventArgs e)
        {
            Button but = (sender as Button);
            EventFlag dialog = null;

            if (but == this.Action1Param2_button)
            {
                if (Action1TypeCBox.SelectedIndex == 2)
                    dialog = new EventFlag(this, Convert.ToInt32(this.Action1Param2Tbox.Text), Info.FactionFlag, 3, 1);
                else if (Action1TypeCBox.SelectedIndex == 22 || Action1TypeCBox.SelectedIndex == 30 || Action1TypeCBox.SelectedIndex == 31)
                    dialog = new EventFlag(this, Convert.ToInt64(this.Action1Param2Tbox.Text), Info.EventPhases, 3, 1);
            }
            else if (but == this.Action2Param2_button)
            {
                if (Action2TypeCBox.SelectedIndex == 2)
                    dialog = new EventFlag(this, Convert.ToInt32(this.Action2Param2Tbox.Text), Info.FactionFlag, 3, 2);
                else if (Action2TypeCBox.SelectedIndex == 22 || Action2TypeCBox.SelectedIndex == 30 || Action2TypeCBox.SelectedIndex == 31)
                    dialog = new EventFlag(this, Convert.ToInt64(this.Action2Param2Tbox.Text), Info.EventPhases, 3, 2);
            }
            else if (but == this.Action3Param2_button)
            {
                if (Action3TypeCBox.SelectedIndex == 2)
                    dialog = new EventFlag(this, Convert.ToInt32(this.Action3Param2Tbox.Text), Info.FactionFlag, 3, 3);
                else if (Action3TypeCBox.SelectedIndex == 22 || Action3TypeCBox.SelectedIndex == 30 || Action3TypeCBox.SelectedIndex == 31)
                    dialog = new EventFlag(this, Convert.ToInt64(this.Action3Param2Tbox.Text), Info.EventPhases, 3, 3);
            }

            dialog.ShowDialog(this);
        }

        // Load param 1 flags
        private void Action1Param1_button_Click(object sender, EventArgs e)
        {
            Button but = (sender as Button);
            EventFlag dialog = null;

            if (but == this.Action1Param1_button)
            {
                if (Action1TypeCBox.SelectedIndex == 18 || Action1TypeCBox.SelectedIndex == 19)
                    dialog = new EventFlag(this, Convert.ToInt64(this.Action1Param1Tbox.Text), Info.UnitFlags, 4, 1);
                else if (Action1TypeCBox.SelectedIndex == 22 || Action1TypeCBox.SelectedIndex == 30 || Action1TypeCBox.SelectedIndex == 31)
                    dialog = new EventFlag(this, Convert.ToInt64(this.Action1Param1Tbox.Text), Info.EventPhases, 4, 1);
            }
            else if (but == this.Action2Param1_button)
            {
                if (Action2TypeCBox.SelectedIndex == 18 || Action2TypeCBox.SelectedIndex == 19)
                    dialog = new EventFlag(this, Convert.ToInt64(this.Action2Param1Tbox.Text), Info.UnitFlags, 4, 2);
                else if (Action2TypeCBox.SelectedIndex == 22 || Action2TypeCBox.SelectedIndex == 30 || Action2TypeCBox.SelectedIndex == 31)
                    dialog = new EventFlag(this, Convert.ToInt64(this.Action2Param1Tbox.Text), Info.EventPhases, 4, 2);
            }
            else if (but == this.Action3Param1_button)
            {
                if (Action3TypeCBox.SelectedIndex == 18 || Action3TypeCBox.SelectedIndex == 19)
                    dialog = new EventFlag(this, Convert.ToInt64(this.Action3Param1Tbox.Text), Info.UnitFlags, 4, 3);
                else if (Action3TypeCBox.SelectedIndex == 22 || Action3TypeCBox.SelectedIndex == 30 || Action3TypeCBox.SelectedIndex == 31)
                    dialog = new EventFlag(this, Convert.ToInt64(this.Action3Param1Tbox.Text), Info.EventPhases, 4, 3);
            }

            dialog.ShowDialog(this);
        }

        // Set event flags
        public void set_event_flags(Int64 flag_value)
        {
            this.EventFlagTBox.Text = flag_value.ToString();

            if (!locked)
                GetEventData();
        }

        // Set spell masks
        public void set_spell_mask(Int64 flag_value)
        {
            this.EventParam2.Text = flag_value.ToString();

            if (EventParam1.Text != "0")
                MessageBox.Show("You already defined a SpellID. Please use '-1' for the SchoolMask or remove the SpellId!");

            if (!locked)
                GetEventData();
        }

        // Set cast flag
        public void set_cast_flag(Int64 flag_value, int action)
        {
            switch (action)
            {
                case 1:
                    Action1Param3Tbox.Text = flag_value.ToString();
                    break;
                case 2:
                    Action2Param3Tbox.Text = flag_value.ToString();
                    break;
                case 3:
                    Action3Param3Tbox.Text = flag_value.ToString();
                    break;
            }

            if (!locked)
                GetEventData();
        }

        // Set unit flag
        public void set_unit_flag(Int64 flag_value, int action)
        {
            switch (action)
            {
                case 1:
                    Action1Param1Tbox.Text = flag_value.ToString();
                    break;
                case 2:
                    Action2Param1Tbox.Text = flag_value.ToString();
                    break;
                case 3:
                    Action3Param1Tbox.Text = flag_value.ToString();
                    break;
            }

            if (!locked)
                GetEventData();
        }

        // Set param 2 flag
        public void set_param2_flag(Int64 flag_value, int action)
        {
            switch (action)
            {
                case 1:
                    Action1Param2Tbox.Text = flag_value.ToString();
                    break;
                case 2:
                    Action2Param2Tbox.Text = flag_value.ToString();
                    break;
                case 3:
                    Action3Param2Tbox.Text = flag_value.ToString();
                    break;
            }

            if (!locked)
                GetEventData();
        }

        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;
            int temp = 0;
            Label label1 = new Label();

            foreach (var obj in myCombo.Items)
            {
                label1.Text = obj.ToString();
                temp = label1.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            label1.Dispose();
            return maxWidth;
        }
    }
}

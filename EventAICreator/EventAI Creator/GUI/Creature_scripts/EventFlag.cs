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
    public partial class EventFlag : Form
    {
        private EventControl parent;
        private DbScriptControl scriptParent;
        private int flagType = 0;
        private int action = 0;

        public EventFlag(EventControl control, Int64 flag_value, string[] items, int type/*0=event_flag, 1=spell_hit, 2=cast_flag */, int action)
        {
            InitializeComponent();

            flagType = type;
            this.action = action;
            parent = control;

            LoadFlags(items, flag_value);
        }

        public EventFlag(DbScriptControl control, Int64 flag_value, string[] items, int type/*0=event_flag, 1=spell_hit, 2=cast_flag */, int action)
        {
            InitializeComponent();

            flagType = type;
            this.action = action;
            scriptParent = control;

            LoadFlags(items, flag_value);
        }

        private void button_flag_ok_Click(object sender, EventArgs e)
        {
            Int64 flag_value = 0;

            foreach (int indexChecked in checkedListBox_flags.CheckedIndices)
                flag_value += Convert.ToInt64(Math.Pow(2, indexChecked));

            switch (flagType)
            {
                case 0:
                    parent.set_event_flags(flag_value);
                    break;
                case 1:
                    parent.set_spell_mask(flag_value);
                    break;
                case 2:
                    parent.set_cast_flag(flag_value, action);
                    break;
                case 3:
                    parent.set_param2_flag(flag_value, action);
                    break;
                case 4:
                    parent.set_unit_flag(flag_value, action);
                    break;
                case 5:
                    scriptParent.SetDataFlags(flag_value);
                    break;
                case 6:
                    scriptParent.SetEventFlags(flag_value);
                    break;
            }

            this.Close();
        }

        private void LoadFlags(string[] items, Int64 flag_value)
        {
            for (int i = 0; i < items.Count(); i++)
                checkedListBox_flags.Items.Add(items[i]);

            // Check only the lists for the given event mask
            for (int i = checkedListBox_flags.Items.Count; i >= 0; i--)
            {
                if (Convert.ToInt64(Math.Pow(2, i)) <= flag_value)
                {
                    checkedListBox_flags.SetItemChecked(i, true);
                    flag_value -= Convert.ToInt64(Math.Pow(2, i));
                }
            }
        }
    }
}

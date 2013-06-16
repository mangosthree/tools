using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MySql.Data;

namespace EventAI_Creator
{
    public class  Event_dataset
    {
        public Event_dataset()
        {
            this.event_chance = 100;
            this.event_flags = 0;
            this.event_inverse_phase_mask = 0;
            comment = "";
        }

        public int script_id;

        public int event_type;
        public UInt32 event_inverse_phase_mask;
        public int event_chance;
        public int event_flags;
        public int event_param1;
        public int event_param2;
        public int event_param3;
        public int event_param4;

        public int action1_type;
        public Int64 action1_param1;
        public int action1_param2;
        public int action1_param3;

        public int action2_type;
        public Int64 action2_param1;
        public int action2_param2;
        public int action2_param3;

        public int action3_type;
        public Int64 action3_param1;
        public int action3_param2;
        public int action3_param3;

        public string comment;
    }

    class creature
    {
        public creature(uint id, string name)
        {
            this.creature_id = id;
            this.creature_name = name;
        }

        public void AddEvent()
        {
            Event_dataset temp = new Event_dataset();
            line.Add(temp);
        }

        public uint creature_id;
        public bool activectemplate = false;
        public string creature_name;
        public bool changed = false;
        public List<Event_dataset> line = new List<Event_dataset>();
    }

    static class creatures
    {
        public static bool AddCreature(creature npc)
        {
            if(npcList.ContainsKey(npc.creature_id))
                return false;
            npcList.Add(npc.creature_id,npc);
            return true;
        }

        public static void DelCreature(uint creature_id)
        {
            npcList.Remove(creature_id);
        }

        public static creature GetCreature(uint creature_id)
        {
            creature npc;
            npc = npcList[creature_id];
            return npc;
        }

        public static bool PrintCreatureToFile(uint creature_id,string file)
        {
            SQLcreator.WriteCreatureToFile(npcList[creature_id], file, false);
            return true;
        }

        public static string PrintCreatureToWindow(uint creature_id)
        {
            string value = "";
            value = SQLcreator.WriteCreatureToWindow(npcList[creature_id]);
            return value;
        }

        public static bool PrintALLCreaturesToFile(string file)
        {
            foreach (KeyValuePair<uint,creature> item in npcList)
                SQLcreator.WriteCreatureToFile(item.Value, file, true);
            return true;
        }

        public static SortedList<uint, creature> npcList = new SortedList<uint, creature>();
        public static List<uint> npcsAvailable = new List<uint>();
    }
}

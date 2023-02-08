using System.Collections.Generic;

namespace EventAI_Creator
{
    public class Event_dataset_script
    {
        public Event_dataset_script()
        {
        }

        public uint id;
        public uint delay = 0;
        public int command = 0;
        public uint datalong = 0;
        public uint datalong2 = 0;
        public uint buddy = 0;
        public uint radius = 0;
        public uint dataflags = 0;
        public uint dataint = 0;
        public uint dataint2 = 0;
        public uint dataint3 = 0;
        public uint dataint4 = 0;
        public float position_x = 0;
        public float position_y = 0;
        public float position_z = 0;
        public float orientation = 0;
        public string comment = "";
    }

    class db_script
    {
        public db_script(uint id)
        {
            this.id = id;
        }

        public void AddScriptLine()
        {
            Event_dataset_script temp = new Event_dataset_script();
            line.Add(temp);
        }

        public uint id;
        public bool activectemplate = false;
        public bool changed = false;
        public List<Event_dataset_script> line = new List<Event_dataset_script>();
    }

    static class db_scripts
    {
        public static bool AddScript(db_script script)
        {
            if (scriptList.ContainsKey(script.id))
                return false;

            scriptList.Add(script.id, script);
            return true;
        }

        public static void DelScript(uint id)
        {
            scriptList.Remove(id);
        }

        public static db_script GetDbScript(uint id)
        {
            db_script script;
            script = scriptList[id];
            return script;
        }

        public static bool PrintScriptToFile(uint id, string file, string table)
        {
            SQLcreator.WriteScriptToFile(scriptList[id], file, false, table);
            return true;
        }

        public static string PrintScriptToWindow(uint id, string table)
        {
            string value = "";
            value = SQLcreator.WriteScriptToWindow(scriptList[id], table);
            return value;
        }

        public static bool PrintALLScriptsToFile(string file, string table)
        {
            foreach (KeyValuePair<uint, db_script> item in scriptList)
                SQLcreator.WriteScriptToFile(item.Value, file, true, table);
            return true;
        }

        public static SortedList<uint, db_script> scriptList = new SortedList<uint, db_script>();
        public static List<uint> scriptsAvailable = new List<uint>();
    }
}

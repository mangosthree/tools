using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventAI_Creator
{
    static class localized_texts
    {
        public static bool Add(int id)
        {
            localized_text temp = new localized_text(id);
            if (!map.ContainsKey(id))
            {
                map.Add(id, temp);
                return true;
            }
            else
                return false;
        }

        public static SortedList<int, localized_text> map = new SortedList<int,localized_text>();

        public static bool PrintLocalToFile(int creature_id, string file)
        {
            SQLcreator.WriteLocalizedTextToFile(map[creature_id], file, false);
            return true;
        }

        public static bool PrintALLLocalsToFile(string file)
        {
            foreach (KeyValuePair<int, localized_text> item in map)
                SQLcreator.WriteLocalizedTextToFile(item.Value, file, true);

            return true;
        }

        public static string PrintToQueryWindow(int script_id)
        {
            string value = "";
            value = SQLcreator.WriteLocalizedTextToWindow(map[script_id]);

            return value;
        }
    }

    class localized_text
    {
        public localized_text(int idi)
        {
            id = idi;
        }

        public int id;
        public bool changed = false;
        public bool useOtherLocale = false;
        public string locale_0 = "";    // default = english
        public string locale_1 = "";    // korean
        public string locale_2 = "";    // french
        public string locale_3 = "";    // german
        public string locale_4 = "";    // chinese
        public string locale_5 = "";    // waiwanese
        public string locale_6 = "";    // spanish
        public string locale_7 = "";    // spanish mexico
        public string locale_8 = "";    // russian
        public int sound = 0;
        public int type = 0;
        public int language = 0;
        public int emote = 0;
        public string comment = "";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MySql.Data;

using System.Net;
using System.Net.Sockets;
using System.Globalization;
using Tamir.SharpSsh.jsch;
using Tamir.SharpSsh.jsch.jce;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace EventAI_Creator
{
    class Datastores
    {
        public static bool dbused = false;

        public static void ReloadDB()
        {
            if (!Datastores.dbused)
                return;

            MySqlDataReader reader = null;

            // Check for the creatureAI tables
            try
            {
                string sQuery = "SELECT information_schema.TABLES.table_name FROM information_schema.TABLES " +
                    "where information_schema.TABLES.table_name IN ('creature_ai_scripts','creature_ai_summons','creature_ai_texts') and information_schema.TABLES.Table_schema='" + Properties.Settings.Default.DBMANGOS + "'";
                MySqlCommand comm = new MySqlCommand(sQuery, SQLConnection.conn);
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Your database doesn't contain the eventAI tables. The application won't use the database anymore");
                        dbused = false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            reader.Close();

            if (Datastores.dbused)
            {
                // Select all creature scripts and creature names
                MySqlCommand c = new MySqlCommand("SELECT a.*, b.name FROM creature_ai_scripts a join creature_template b on a.creature_id = b.entry;", SQLConnection.conn);
                reader = c.ExecuteReader();

                creatures.npcList.Clear();
                summons.map.Clear();
                localized_texts.map.Clear();

                try
                {
                    while (reader.Read())
                    {
                        if (!creatures.npcList.ContainsKey(reader.GetUInt32("creature_id")))
                        {
                            creature temp = new creature(reader.GetUInt32("creature_id"), reader.GetString("name"));
                            creatures.npcList.Add(reader.GetUInt32("creature_id"), temp);
                        }

                        Event_dataset item = new Event_dataset();

                        item.script_id = reader.GetInt32("id");
                        item.event_type = reader.GetInt32("event_type");
                        item.event_inverse_phase_mask = reader.GetUInt32("event_inverse_phase_mask");
                        item.event_chance = reader.GetInt32("event_chance");
                        item.event_flags = reader.GetInt32("event_flags");
                        item.event_param1 = reader.GetInt32("event_param1");
                        item.event_param2 = reader.GetInt32("event_param2");
                        item.event_param3 = reader.GetInt32("event_param3");
                        item.event_param4 = reader.GetInt32("event_param4");
                        item.action1_type = reader.GetInt32("action1_type");
                        item.action1_param1 = reader.GetInt32("action1_param1");
                        item.action1_param2 = reader.GetInt32("action1_param2");
                        item.action1_param3 = reader.GetInt32("action1_param3");
                        item.action2_type = reader.GetInt32("action2_type");
                        item.action2_param1 = reader.GetInt32("action2_param1");
                        item.action2_param2 = reader.GetInt32("action2_param2");
                        item.action2_param3 = reader.GetInt32("action2_param3");
                        item.action3_type = reader.GetInt32("action3_type");
                        item.action3_param1 = reader.GetInt32("action3_param1");
                        item.action3_param2 = reader.GetInt32("action3_param2");
                        item.action3_param3 = reader.GetInt32("action3_param3");
                        item.comment = reader.GetString("comment");

                        creatures.npcList[reader.GetUInt32("creature_id")].line.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                reader.Close();

                // Select all creature AI summons
                c.CommandText = "SELECT * FROM creature_ai_summons";
                reader.Close();
                reader = c.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        summon item = new summon(reader.GetUInt32("id"));
                        item.comment = reader.GetString("comment");
                        item.orientation = reader.GetFloat("orientation");
                        item.position_x = reader.GetFloat("position_x");
                        item.position_y = reader.GetFloat("position_y");
                        item.position_z = reader.GetFloat("position_z");
                        item.spawntimesecs = reader.GetInt32("spawntimesecs");

                        summons.map.Add(reader.GetUInt32("id"), item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // Select all creature AI texts
                c.CommandText = "SELECT * FROM creature_ai_texts";
                reader.Close();

                reader = c.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        localized_text item = new localized_text(reader.GetInt32("entry"));
                        item.locale_0 = reader.GetString("content_default");

                        int colIndex = reader.GetOrdinal("content_loc1");
                        if (!reader.IsDBNull(colIndex))
                            item.locale_1 = reader.GetString("content_loc1");
                        else
                            item.locale_1 = string.Empty;

                        colIndex = reader.GetOrdinal("content_loc2");
                        if (!reader.IsDBNull(colIndex))
                            item.locale_2 = reader.GetString("content_loc2");
                        else
                            item.locale_2 = string.Empty;

                        colIndex = reader.GetOrdinal("content_loc3");
                        if (!reader.IsDBNull(colIndex))
                            item.locale_3 = reader.GetString("content_loc3");
                        else
                            item.locale_3 = string.Empty;

                        colIndex = reader.GetOrdinal("content_loc4");
                        if (!reader.IsDBNull(colIndex))
                            item.locale_4 = reader.GetString("content_loc4");
                        else
                            item.locale_4 = string.Empty;

                        colIndex = reader.GetOrdinal("content_loc5");
                        if (!reader.IsDBNull(colIndex))
                            item.locale_5 = reader.GetString("content_loc5");
                        else
                            item.locale_5 = string.Empty;

                        colIndex = reader.GetOrdinal("content_loc6");
                        if (!reader.IsDBNull(colIndex))
                            item.locale_6 = reader.GetString("content_loc6");
                        else
                            item.locale_6 = string.Empty;

                        colIndex = reader.GetOrdinal("content_loc7");
                        if (!reader.IsDBNull(colIndex))
                            item.locale_7 = reader.GetString("content_loc7");
                        else
                            item.locale_7 = string.Empty;

                        colIndex = reader.GetOrdinal("content_loc8");
                        if (!reader.IsDBNull(colIndex))
                            item.locale_8 = reader.GetString("content_loc8");
                        else
                            item.locale_8 = string.Empty;

                        item.sound = reader.GetInt32("sound");
                        item.type = reader.GetInt32("type");
                        item.language = reader.GetInt32("language");
                        item.emote = reader.GetInt32("emote");

                        colIndex = reader.GetOrdinal("comment");
                        if (!reader.IsDBNull(colIndex))
                            item.comment = reader.GetString("comment");
                        else
                            item.comment = string.Empty;

                        localized_texts.map.Add(reader.GetInt32("entry"), item);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                reader.Close();

                // Select creature entries
                SQLConnection.conn.ChangeDatabase(SQLConnection.dbworld);
                c.CommandText = "SELECT distinct entry FROM creature_template WHERE AIName='EventAI';";
                reader = c.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        if (creatures.npcList.ContainsKey(reader.GetUInt32("entry")))
                        {
                            creatures.npcList[reader.GetUInt32("entry")].activectemplate = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                reader.Close();

                c.CommandText = "SELECT distinct entry FROM creature_template;";
                reader = c.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        creatures.npcsAvailable.Add(reader.GetUInt32("entry"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                reader.Close();
            }
        }

        // Load DB scripts
        public static void LoadDBScripts(string sTable)
        {
            if (!Datastores.dbused)
                return;

            MySqlDataReader reader = null;

            // Check for the creatureAI tables
            try
            {
                string sQuery = "SELECT information_schema.TABLES.table_name FROM information_schema.TABLES " +
                    "where information_schema.TABLES.table_name IN ('creature_movement_scripts','event_script','gameobject_scripts','gossip_scripts','quest_end_scripts','quest_start_scripts','spell_scripts') and information_schema.TABLES.Table_schema='" + Properties.Settings.Default.DBMANGOS + "'";
                MySqlCommand comm = new MySqlCommand(sQuery, SQLConnection.conn);
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Your database doesn't contain the script tables. The application won't use the database anymore");
                        dbused = false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            reader.Close();

            if (Datastores.dbused)
            {
                // Select all creature scripts and creature names
                MySqlCommand c = new MySqlCommand("SELECT * FROM " + sTable, SQLConnection.conn);
                reader = c.ExecuteReader();

                // clear existing script first
                db_scripts.scriptList.Clear();

                try
                {
                    while (reader.Read())
                    {
                        if (!db_scripts.scriptList.ContainsKey(reader.GetUInt32("id")))
                        {
                            db_script temp = new db_script(reader.GetUInt32("id"));
                            db_scripts.scriptList.Add(reader.GetUInt32("id"), temp);
                        }

                        Event_dataset_script item = new Event_dataset_script();

                        item.id = reader.GetUInt32("id");
                        item.delay = reader.GetUInt32("delay");
                        item.command = reader.GetInt32("command");
                        item.datalong = reader.GetUInt32("datalong");
                        item.datalong2 = reader.GetUInt32("datalong2");
                        item.buddy = reader.GetUInt32("buddy_entry");
                        item.radius = reader.GetUInt32("search_radius");
                        item.dataint = reader.GetUInt32("dataint");
                        item.dataint2 = reader.GetUInt32("dataint2");
                        item.dataint3 = reader.GetUInt32("dataint3");
                        item.dataint4 = reader.GetUInt32("dataint4");
                        item.position_x = reader.GetFloat("x");
                        item.position_y = reader.GetFloat("y");
                        item.position_z = reader.GetFloat("z");
                        item.orientation = reader.GetFloat("o");
                        item.comment = reader.GetString("comments");

                        db_scripts.scriptList[reader.GetUInt32("id")].line.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                reader.Close();
            }
        }
    }

    static class SQLcreator
    {
        // Create creature script
        public static bool WriteCreatureToFile(creature npc, string file, bool reihe)
        {
            if (npc == null || npc.line.Count == 0)
                return false;

            StreamWriter sqlpatchfile = new StreamWriter(file, reihe);
            sqlpatchfile.WriteLine("-- Creature id: " + npc.creature_id);
            sqlpatchfile.WriteLine(SQLcreator.CreateDeleteQuery(npc, ""));
            sqlpatchfile.WriteLine(SQLcreator.CreateCreateQuery(npc, ""));
            sqlpatchfile.Close();
            return true;
        }

        // Preview creature scripts
        public static string WriteCreatureToWindow(creature script)
        {
            if (script == null)
                return "";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-- Creature id: " + script.creature_id);
            sb.AppendLine(CreateCreatureTemplateQuery(script, false));
            sb.AppendLine(SQLcreator.CreateDeleteQuery(script, ""));
            sb.AppendLine(SQLcreator.CreateCreateQuery(script, ""));

            return sb.ToString();
        }

        // Create DB script
        public static bool WriteScriptToFile(db_script script, string file, bool reihe, string table)
        {
            if (script == null || script.line.Count == 0)
                return false;

            StreamWriter sqlpatchfile = new StreamWriter(file, reihe);
            sqlpatchfile.WriteLine("-- Script id: " + script.id);

            if (table != "event_scripts" && table != "gameobject_scripts" && table != "spell_scripts")
                sqlpatchfile.WriteLine(CreateScriptTemplateQuery(script, false, table));

            sqlpatchfile.WriteLine(SQLcreator.CreateDeleteQuery(script, table));
            sqlpatchfile.WriteLine(SQLcreator.CreateCreateQuery(script, table));
            sqlpatchfile.Close();
            return true;
        }

        // Preview DB scripts
        public static string WriteScriptToWindow(db_script script, string table)
        {
            if (script == null)
                return "";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-- Script id: " + script.id);

            if (table != "event_scripts" && table != "gameobject_scripts" && table != "spell_scripts")
                sb.AppendLine(CreateScriptTemplateQuery(script, false, table));

            sb.AppendLine(SQLcreator.CreateDeleteQuery(script, table));
            sb.AppendLine(SQLcreator.CreateCreateQuery(script, table));

            return sb.ToString();
        }

        // Create summon script
        public static bool WriteSummonToFile(summon script, string file, bool reihe)
        {
            if (script == null)
                return false;

            StreamWriter sqlpatchfile = new StreamWriter(file, reihe);
            sqlpatchfile.WriteLine("-- Summon id: " + script.id);
            sqlpatchfile.WriteLine(SQLcreator.CreateDeleteQuery(script, ""));
            sqlpatchfile.WriteLine(SQLcreator.CreateCreateQuery(script, ""));
            sqlpatchfile.Close();
            return true;
        }

        // Preview summon scripts
        public static string WriteSummonToWindow(summon script)
        {
            if (script == null)
                return "";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-- Summon id: " + script.id);
            sb.AppendLine(SQLcreator.CreateDeleteQuery(script, ""));
            sb.AppendLine(SQLcreator.CreateCreateQuery(script, ""));

            return sb.ToString();
        }

        // Create text script
        public static bool WriteLocalizedTextToFile(localized_text script, string file, bool reihe)
        {
            if (script == null)
                return false;

            StreamWriter sqlpatchfile = new StreamWriter(file, reihe);
            sqlpatchfile.WriteLine("-- Text id: " + script.id);
            sqlpatchfile.WriteLine(SQLcreator.CreateDeleteQuery(script, ""));
            sqlpatchfile.WriteLine(SQLcreator.CreateCreateQuery(script, ""));
            sqlpatchfile.Close();
            return true;
        }

        // Preview text scripts
        public static string WriteLocalizedTextToWindow(localized_text script)
        {
            if (script == null)
                return "";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-- Text id: "  + script.id);
            sb.AppendLine(SQLcreator.CreateDeleteQuery(script, ""));
            sb.AppendLine(SQLcreator.CreateCreateQuery(script, ""));

            return sb.ToString();
        }

        public static string CreateDeleteQuery(object item, string sTable)
        {
            string table = "";
            string argument = "id < 0";
            string customquery = "";
            string table2 = "";

            // Creature
            if (item is creature)
            {
                creature copy = item as creature;
                table = "creature_ai_scripts";
                argument = "creature_id="+copy.creature_id;
            }

            if (item is List<creature>)
            {
                List<creature> copy = item as List<creature>;
                table = "creature_ai_scripts";
                argument = "creature_id IN (";

                foreach (creature itemf in copy)
                    argument = argument + itemf.creature_id+",";

                argument.Remove(argument.Length);
                argument = argument+")";
            }

            if (item is creatures)
            {
                SortedList<uint,creature> copy = creatures.npcList;
                table = "creature_ai_scripts";
                argument = "creature_id IN (";

                foreach(KeyValuePair<uint,creature> itemf in copy)
                    argument = argument + itemf.Key + ",";

                argument.Remove(argument.Length);
                argument = argument + ")";
            }

            // Summons
            if (item is summon)
            {
                summon copy = item as summon;
                table = "creature_ai_summons";
                argument = "id="+ copy.id;
            }

            if (item is List<summon>)
            {
                List<summon> copy = item as List<summon>;
                table = "creature_ai_summons";
                argument = "id IN (";

                foreach (summon itemf in copy)
                    argument = argument + itemf.id + ",";

                argument.Remove(argument.Length);
                argument = argument+")";
            }

            if (item is summons)
            {
                SortedList<uint, summon> copy = summons.map;
                table = "creature_ai_summons";
                argument = "id IN (";

                foreach (KeyValuePair<uint, summon> itemf in copy)
                    argument = argument + itemf.Key + ",";

                argument.Remove(argument.Length);
                argument = argument + ")";
            }

            // selete single text
            if (item is localized_text)
            {
                localized_text copy = item as localized_text;
                customquery = "DELETE FROM creature_ai_texts WHERE entry=" + copy.id + ";";
            }
            // not used
            if (item is List<localized_text>)
                MessageBox.Show("Error!");
            // delete all texts - currently not used
            if (item is localized_texts)
            {
                SortedList<int, localized_text> copy = localized_texts.map;
                foreach (KeyValuePair<int, localized_text> itemf in copy)
                    customquery = customquery + "DELETE FROM creature_ai_texts WHERE entry=" + itemf.Key + ";";
            }

            // DB scripts
            if (item is db_script)
            {
                db_script copy = item as db_script;
                table = sTable;
                argument = "id=" + copy.id;
            }

            string result = "";
            if (customquery.Length != 0)
                result = customquery;
            else
                result = "DELETE FROM " + table + " WHERE " + argument + ";";

            return result;
        }

        public static string CreateScriptTemplateQuery(object item, bool remove, string table)
        {
            string arguments = "";
            string column = "";

            if (item is db_script)
            {
                db_script copy = item as db_script;
                arguments = copy.id.ToString();
            }

            switch (table)
            {
                case "creature_movement_scripts":
                    table = "creature_movement_template";
                    column = "entry";
                    break;
                case "gossip_scripts":
                    table = "gossip_menu_option";
                    column = "menu_id";
                    break;
                case "quest_start_scripts":
                case "quest_end_scripts":
                    table = "quest_template";
                    column = "entry";
                    break;
            }

            string scriptname = arguments;
            if (remove)
                scriptname = "0";

            string result = "UPDATE " + table + " SET script_id=" + scriptname + " WHERE " + column + "=" + arguments + ";";

            return result;
        }

        public static string CreateCreatureTemplateQuery(object item, bool remove)
        {
            string arguments = "";

            if (item is creature)
            {
                creature copy = item as creature;
                arguments = copy.creature_id.ToString();
            }
            if (item is List<creature>)
            {
                List<creature> copy = item as List<creature>;
                bool first = true;

                foreach (creature itemf in copy)
                {
                    if (first)
                    { first = false; arguments = itemf.creature_id.ToString(); }
                    else arguments = arguments + "," + itemf.creature_id;
                }
            }
            if (item is creatures)
            {
                SortedList<uint, creature> copy = creatures.npcList;
                bool first = true;

                foreach (KeyValuePair<uint, creature> itemf in copy)
                {
                    if (first)
                    { first = false; arguments = itemf.Key.ToString(); }
                    else arguments = arguments + "," + itemf.Key;
                }
            }

            if (item is uint)
                arguments = item.ToString();

            string scriptname = "EventAI";
            if (remove)
                scriptname = "";

            string result = "UPDATE creature_template SET AIName='"+ scriptname +"' WHERE entry="+arguments+";";

            return result;
        }

        public static string CreateCreateQuery(object item, string scriptTable)
        {
            string table = "";
            string lines = "";
            string customquery = "";

            // Create single text query
            if (item is localized_text)
            {
                localized_text copy = item as localized_text;
                if (!copy.useOtherLocale)
                    customquery = "INSERT INTO `creature_ai_texts` (`entry`,`content_default`,`sound`,`type`,`language`,`comment`,`emote`) VALUES \r\n('" +
                        copy.id + "','" + MySqlHelper.EscapeString(copy.locale_0) + "','" +
                        copy.sound + "','" + copy.type + "','" + copy.language + "','" +
                        MySqlHelper.EscapeString(copy.comment) + "','" + copy.emote + "');";
                else
                    customquery = "INSERT INTO creature_ai_texts VALUES \r\n('"
                            + copy.id + "','" + MySqlHelper.EscapeString(copy.locale_0) + "','" + MySqlHelper.EscapeString(copy.locale_1) + "','"
                            + MySqlHelper.EscapeString(copy.locale_2) + "','" + MySqlHelper.EscapeString(copy.locale_3) + "','"
                            + MySqlHelper.EscapeString(copy.locale_4) + "','" + MySqlHelper.EscapeString(copy.locale_5) + "','"
                            + MySqlHelper.EscapeString(copy.locale_6) + "','" + MySqlHelper.EscapeString(copy.locale_7) + "','"
                            + MySqlHelper.EscapeString(copy.locale_8) + "','" + copy.sound + "','" + copy.type + "','" + copy.language + "','"
                            + copy.emote + "," + MySqlHelper.EscapeString(copy.comment) + "');";
             }
            // not used
            if (item is List<localized_text>)
                MessageBox.Show("Error!");
            // Create multi text query - currently not used
            if (item is localized_texts)
            {
                SortedList<int, localized_text> copy = localized_texts.map;
                foreach (KeyValuePair<int, localized_text> itemf in copy)
                {
                    if (!localized_texts.map[itemf.Key].useOtherLocale)
                        customquery = customquery + "INSERT INTO `creature_ai_texts` (`entry`,`content_default`,`sound`,`type`,`language`,`comment`,`emote`) VALUES \r\n('" +
                            localized_texts.map[itemf.Key].id + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_0) + "','" +
                            localized_texts.map[itemf.Key].sound + "','" + localized_texts.map[itemf.Key].type + "','" + localized_texts.map[itemf.Key].language + "','" +
                            MySqlHelper.EscapeString(localized_texts.map[itemf.Key].comment) + "','" + localized_texts.map[itemf.Key].emote + "');";
                    else
                        customquery = customquery + "INSERT INTO creature_ai_texts VALUES \r\n('"
                            + localized_texts.map[itemf.Key].id + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_0) + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_1) + "','"
                            + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_2) + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_3) + "','"
                            + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_4) + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_5) + "','"
                            + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_6) + "','" + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_7) + "','"
                            + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].locale_8) + "','" + localized_texts.map[itemf.Key].sound + "','" + localized_texts.map[itemf.Key].type + "','" + localized_texts.map[itemf.Key].language + "','"
                            + localized_texts.map[itemf.Key].emote + "," + MySqlHelper.EscapeString(localized_texts.map[itemf.Key].comment) + "');";
                }
            }

            // Summons
            if (item is summon)
            {
                table = "creature_ai_summons";
                summon copy = item as summon;
                lines = "('" + copy.id + "','" + copy.position_x.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + copy.position_y.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + copy.position_z.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + copy.orientation.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + copy.spawntimesecs + "','" + MySqlHelper.EscapeString(copy.comment) + "');";
            }

            if (item is List<summon>)
            {
                table = "creature_ai_summons";
                List<summon> copy = item as List<summon>;

                foreach (summon itemf in copy)
                    lines = "('" + itemf.id + "','" + itemf.position_x.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + itemf.position_y.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + itemf.position_z.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + itemf.orientation.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + itemf.spawntimesecs + "','" + MySqlHelper.EscapeString(itemf.comment) + "'),";

                lines.Remove(lines.Length);
                lines = lines + ";";
            }

            if (item is summons)
            {
                table = "creature_ai_summons";
                SortedList<uint, summon> copy = summons.map;

                foreach (KeyValuePair<uint, summon> itemf in copy)
                    lines = "('" + summons.map[itemf.Key].id + "','" + summons.map[itemf.Key].position_x.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + summons.map[itemf.Key].position_y.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + summons.map[itemf.Key].position_z.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + summons.map[itemf.Key].orientation.ToString(CultureInfo.GetCultureInfo("en-US")) + "','" + summons.map[itemf.Key].spawntimesecs + "','" + MySqlHelper.EscapeString(summons.map[itemf.Key].comment) + "'),";

                lines.Remove(lines.Length);
                lines = lines + ";";
            }

            // Creatures
            if (item is creature)
            {
                table = "creature_ai_scripts";
                creature copy = item as creature;

                for (int i = 0; i < copy.line.Count; i++)
                {
                    lines = lines + "('" + copy.creature_id + (i + 1).ToString("00") + "','" +
                    copy.creature_id + "','" +
                    copy.line[i].event_type + "','" +
                    copy.line[i].event_inverse_phase_mask + "','" +
                    copy.line[i].event_chance + "','" +
                    copy.line[i].event_flags + "','" +
                    copy.line[i].event_param1 + "','" +
                    copy.line[i].event_param2 + "','" +
                    copy.line[i].event_param3 + "','" +
                    copy.line[i].event_param4 + "','" +
                    copy.line[i].action1_type + "','" +
                    copy.line[i].action1_param1 + "','" +
                    copy.line[i].action1_param2 + "','" +
                    copy.line[i].action1_param3 + "','" +
                    copy.line[i].action2_type + "','" +
                    copy.line[i].action2_param1 + "','" +
                    copy.line[i].action2_param2 + "','" +
                    copy.line[i].action2_param3 + "','" +
                    copy.line[i].action3_type + "','" +
                    copy.line[i].action3_param1 + "','" +
                    copy.line[i].action3_param2 + "','" +
                    copy.line[i].action3_param3 + "','" +
                    MySqlHelper.EscapeString(copy.line[i].comment) + "')";
                    if (i + 1 < copy.line.Count)
                        lines =lines+",\r\n";
                    else
                        lines =lines+";";
                }
            }
            if (item is List<creature>)
            {
                table = "creature_ai_scripts";
                List<creature> copy = item as List<creature>;

                foreach (creature itemf in copy)
                {
                    for (int i = 0; i < itemf.line.Count; i++)
                    {
                        lines = lines + "('" + itemf.creature_id + (i + 1).ToString("00") + "','" +
                        itemf.creature_id + "','" +
                        itemf.line[i].event_type + "','" +
                        itemf.line[i].event_inverse_phase_mask + "','" +
                        itemf.line[i].event_chance + "','" +
                        itemf.line[i].event_flags + "','" +
                        itemf.line[i].event_param1 + "','" +
                        itemf.line[i].event_param2 + "','" +
                        itemf.line[i].event_param3 + "','" +
                        itemf.line[i].event_param4 + "','" +
                        itemf.line[i].action1_type + "','" +
                        itemf.line[i].action1_param1 + "','" +
                        itemf.line[i].action1_param2 + "','" +
                        itemf.line[i].action1_param3 + "','" +
                        itemf.line[i].action2_type + "','" +
                        itemf.line[i].action2_param1 + "','" +
                        itemf.line[i].action2_param2 + "','" +
                        itemf.line[i].action2_param3 + "','" +
                        itemf.line[i].action3_type + "','" +
                        itemf.line[i].action3_param1 + "','" +
                        itemf.line[i].action3_param2 + "','" +
                        itemf.line[i].action3_param3 + "','" +
                        MySqlHelper.EscapeString(itemf.line[i].comment) + "'),\r\n";
                    }
                }
                lines.Remove(lines.Length);
                lines = lines + ";";
            }
            if (item is creatures)
            {
                table = "creature_ai_scripts";
                SortedList<uint,creature> copy = creatures.npcList;

                foreach(KeyValuePair<uint,creature> itemf in copy)
                {
                    for (int i = 0; i < creatures.npcList[itemf.Key].line.Count; i++)
                    {
                        lines = lines + "('" + creatures.npcList[itemf.Key].creature_id + (i + 1).ToString("00") + "','" +
                        creatures.npcList[itemf.Key].creature_id + "','" +
                        creatures.npcList[itemf.Key].line[i].event_type + "','" +
                        creatures.npcList[itemf.Key].line[i].event_inverse_phase_mask + "','" +
                        creatures.npcList[itemf.Key].line[i].event_chance + "','" +
                        creatures.npcList[itemf.Key].line[i].event_flags + "','" +
                        creatures.npcList[itemf.Key].line[i].event_param1 + "','" +
                        creatures.npcList[itemf.Key].line[i].event_param2 + "','" +
                        creatures.npcList[itemf.Key].line[i].event_param3 + "','" +
                        creatures.npcList[itemf.Key].line[i].event_param4 + "','" +
                        creatures.npcList[itemf.Key].line[i].action1_type + "','" +
                        creatures.npcList[itemf.Key].line[i].action1_param1 + "','" +
                        creatures.npcList[itemf.Key].line[i].action1_param2 + "','" +
                        creatures.npcList[itemf.Key].line[i].action1_param3 + "','" +
                        creatures.npcList[itemf.Key].line[i].action2_type + "','" +
                        creatures.npcList[itemf.Key].line[i].action2_param1 + "','" +
                        creatures.npcList[itemf.Key].line[i].action2_param2 + "','" +
                        creatures.npcList[itemf.Key].line[i].action2_param3 + "','" +
                        creatures.npcList[itemf.Key].line[i].action3_type + "','" +
                        creatures.npcList[itemf.Key].line[i].action3_param1 + "','" +
                        creatures.npcList[itemf.Key].line[i].action3_param2 + "','" +
                        creatures.npcList[itemf.Key].line[i].action3_param3 + "','" +
                        MySqlHelper.EscapeString(creatures.npcList[itemf.Key].line[i].comment) + "'),\r\n";
                    }
                }
                lines.Remove(lines.Length);
                lines = lines + ";";
            }

            // Db script
            if (item is db_script)
            {
                table = scriptTable;
                db_script copy = item as db_script;

                for (int i = 0; i < copy.line.Count; i++)
                {
                    lines = lines + "(" + copy.id + "," +
                    copy.line[i].delay + "," +
                    copy.line[i].command + "," +
                    copy.line[i].datalong + "," +
                    copy.line[i].datalong2 + "," +
                    copy.line[i].buddy + "," +
                    copy.line[i].radius + "," +
                    copy.line[i].dataflags + "," +
                    copy.line[i].dataint + "," +
                    copy.line[i].dataint2 + "," +
                    copy.line[i].dataint3 + "," +
                    copy.line[i].dataint4 + "," +
                    copy.line[i].position_x + "," +
                    copy.line[i].position_y + "," +
                    copy.line[i].position_z + "," +
                    copy.line[i].orientation + ",'" +
                    MySqlHelper.EscapeString(copy.line[i].comment) + "')";
                    if (i + 1 < copy.line.Count)
                        lines = lines + ",\r\n";
                    else
                        lines = lines + ";";
                }
            }

            string result = "";

            if (customquery.Length != 0)
                result = customquery;
            else if (lines.Length != 0)
                result = "INSERT INTO " + table + " VALUES \r\n" + lines;

                return result;
        }
    }

    static class SQLConnection
    {
        public static bool Connect(string tdbhost,string tdbuser,string tdbpass, /*string tdbsd2,*/string tdbworld)
        {
            try
            {
                dbhost = tdbhost;
                dbuser = tdbuser;
                dbpass = tdbpass;
                dbworld = tdbworld;
                string connStr = String.Format("server={0};user id={1};password={2}; database={3}; pooling=false", dbhost, dbuser, dbpass, tdbworld);

                conn = new MySqlConnection(connStr);
                conn.Open();
                conn.ChangeDatabase(tdbworld);
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }
        public static void DisConnect()
        {
            if(!(conn == null))
            conn.Close();
        }

        public static void DoNONREADSD2Query(string query,bool showsucces)
        {
            if(!Datastores.dbused)
                return;
            SQLConnection.conn.ChangeDatabase(SQLConnection.dbworld);
            MySqlCommand c = new MySqlCommand(query, SQLConnection.conn);
            try
            {
                c.ExecuteNonQuery();
                if (showsucces)
                    MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string dbhost;
        public static string dbuser;
        public static string dbpass;
        public static string dbworld;
        public static Exception error;
        public static MySqlConnection conn;
    }

    static class SSHConnection
    {
        public static bool Connect(string thost,string tuser,string tpass,string tport)
        {
            try
            {
                JSch jsch = new JSch();
                host = thost;
                user = tuser;
                pass = tpass;
                sshPort = Convert.ToInt32(tport);

                session = jsch.getSession(user, host, sshPort);
                session.setHost(host);
                session.setPassword(pass);
                UserInfo ui = new MyUserInfo();
                session.setUserInfo(ui);
                session.connect();
                session.setPortForwardingL(lPort, "127.0.0.1", rPort);
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }
        public static void DisConnect()
        {
            if(!(session == null))
            session.disconnect();
        }

        public static string host;
        public static string user;
        public static string pass;
        public static int sshPort;
        public static int rPort = 3306;
        public static int lPort = 3306;
        public static Exception error;

        public static Session session;
    }

    static class SQLCommonExecutes
    {
        public static bool setScriptnameInCreature_template(uint id,bool setnow)
        {
            string query = SQLcreator.CreateCreatureTemplateQuery(id, setnow);
            MySqlCommand c = new MySqlCommand(query,SQLConnection.conn);

            try
            {
                SQLConnection.conn.ChangeDatabase(SQLConnection.dbworld);
                c.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        public static bool CompileQuery(object item)
        {
            if (!Datastores.dbused)
                return false;
            string query = "";
            if(item is SortedList<uint,creature>)
            {
                foreach (KeyValuePair<uint, creature> itemf in (item as SortedList<uint,creature>))
                {
                    if (creatures.npcList.ContainsKey(itemf.Key))
                    {
                            query = query + SQLcreator.CreateDeleteQuery(itemf.Value, "");
                            query = query + SQLcreator.CreateCreateQuery(itemf.Value, "");
                    }
                }
            }
            if (item is SortedList<uint, summon>)
            {
                foreach (KeyValuePair<uint, summon> itemf in (item as SortedList<uint,summon>))
                {
                    if (summons.map.ContainsKey(itemf.Key))
                    {
                            query = query + SQLcreator.CreateDeleteQuery(itemf.Value, "");
                            query = query + SQLcreator.CreateCreateQuery(itemf.Value, "");
                    }
                }
            }
            if (item is SortedList<uint, localized_text>)
            {
                foreach (KeyValuePair<int, localized_text> itemf in (item as SortedList<int,localized_text>))
                {
                    if (localized_texts.map.ContainsKey(itemf.Key))
                    {
                        query = query + SQLcreator.CreateDeleteQuery(itemf.Value, "");
                        query = query + SQLcreator.CreateCreateQuery(itemf.Value, "");
                    }
                }
            }
            if(query != "")
                SQLConnection.DoNONREADSD2Query(query,true);

            return true;
        }

        public static bool SaveOneItemTODB(object item)
        {
            if (Datastores.dbused)
            {
                string query = SQLcreator.CreateDeleteQuery(item, "");
                query = query + SQLcreator.CreateCreateQuery(item, "");
                MySqlCommand c = new MySqlCommand(query, SQLConnection.conn);
                try
                {
                    c.ExecuteNonQuery();
                    
                    MessageBox.Show("Successful");
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else {MessageBox.Show("No DB Connection");return false;}
        }

        public static bool SaveAllItemsToDB(object item)
        {
            if (Datastores.dbused)
            {
                string query = "";

                if (item.Equals(localized_texts.map))
                {
                    foreach (KeyValuePair<int, localized_text> itemf in localized_texts.map)
                    {
                        if (itemf.Value.changed)
                        {
                            query = query + SQLcreator.CreateDeleteQuery(itemf.Value, "");
                            query = query + SQLcreator.CreateCreateQuery(itemf.Value, "");
                        }
                    }
                }
                if (item.Equals(summons.map))
                {
                    foreach (KeyValuePair<uint, summon> itemf in summons.map)
                    {
                        if (itemf.Value.changed)
                        {
                            query = query + SQLcreator.CreateDeleteQuery(itemf.Value, "");
                            query = query + SQLcreator.CreateCreateQuery(itemf.Value, "");
                        }
                    }
                }
                if (item.Equals(creatures.npcList))
                {
                    foreach (KeyValuePair<uint, creature> itemf in creatures.npcList)
                    {
                        if (itemf.Value.changed)
                        {
                            query = query + SQLcreator.CreateDeleteQuery(itemf.Value, "");
                            query = query + SQLcreator.CreateCreateQuery(itemf.Value, "");
                        }
                    }
                }
                MySqlCommand c = new MySqlCommand(query, SQLConnection.conn);
                try
                {
                    if (query != "")
                    {
                        c.ExecuteNonQuery();
                        MessageBox.Show("Successful");
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else { MessageBox.Show("No DB Connection"); return false; }
        }

        public static bool ExecuteDBScript(string query)
        {
            if (!Datastores.dbused)
                return false;

            bool result = false;

            MySqlCommand c = new MySqlCommand(query, SQLConnection.conn);
            try
            {
                if (query != "")
                {
                    int res = c.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = false;
            }

            return result;
        }
    }

    public class MyUserInfo : UserInfo
    {
        /// &lt;summary&gt;
        /// Holds the user password
        /// &lt;/summary&gt;
        private String passwd;

        /// &lt;summary&gt;
        /// Returns the user password
        /// &lt;/summary&gt;
        public String getPassword() { return passwd; }

        /// &lt;summary&gt;
        /// Prompt the user for a Yes/No input
        /// &lt;/summary&gt;
        public bool promptYesNo(String str)
        {
            return true;
        }

        /// &lt;summary&gt;
        /// Returns the user passphrase (passwd for the private key file)
        /// &lt;/summary&gt;
        public String getPassphrase() { return null; }

        /// &lt;summary&gt;
        /// Prompt the user for a passphrase (passwd for the private key file)
        /// &lt;/summary&gt;
        public bool promptPassphrase(String message) { return true; }

        /// &lt;summary&gt;
        /// Prompt the user for a password
        /// &lt;/summary&gt;
        public bool promptPassword(String message) { return true; }

        /// &lt;summary&gt;
        /// Shows a message to the user
        /// &lt;/summary&gt;
        public void showMessage(String message) { }

    }

}

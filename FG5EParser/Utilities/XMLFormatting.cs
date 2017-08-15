using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FG5EParser.Utilities
{
    class XMLFormatting
    {
        public string returnFormattedString(string _toFormat, string _moduleName)
        {
            #region HEADER
            if (_toFormat.Contains("#h;"))
            {
                _toFormat = string.Format("{0}</h>", _toFormat.Replace("#h;", "<h>"));
            }
            else if (_toFormat.Contains("#bp;"))
            {
                _toFormat = _toFormat.Replace("#bp;", "");
                _toFormat = string.Format("<p><b>{0}</b></p>", _toFormat);
            }
            #endregion

            #region FRAME
            else if (_toFormat.Contains("#cf;"))
            {
                _toFormat = _toFormat.Replace("#cf;","");
                _toFormat = string.Format(string.Format("<frame>{0}</frame>",_toFormat));
            }
            #endregion

            #region TABLE
            else if (_toFormat.Contains("#ts;"))
            {
                _toFormat = string.Format("<table>");
            }
            else if (_toFormat.Contains("#th;"))
            {
                StringBuilder th = new StringBuilder();

                th.Append("<tr decoration=\"underline\">");

                List<string> _th = new List<string>(_toFormat.Split(';'));

                for (int i = 1; i < _th.Count(); i++)
                {
                    if (!string.IsNullOrEmpty(_th[i].ToString()))
                    {
                        th.Append("<td>");

                        th.Append(string.Format("<b>{0}</b>", _th[i].ToString().Trim()));

                        th.Append("</td>");
                    }
                }

                th.Append("</tr>");

                _toFormat = th.ToString();
            }
            else if (_toFormat.Contains("#tr;"))
            {
                StringBuilder th = new StringBuilder();

                th.Append("<tr>");

                List<string> _th = new List<string>(_toFormat.Split(';'));

                for (int i = 1; i < _th.Count(); i++)
                {
                    if (!string.IsNullOrEmpty(_th[i].ToString()))
                    {
                        th.Append("<td>");

                        th.Append(string.Format("{0}", _th[i].ToString().Trim()));

                        th.Append("</td>");
                    }
                }

                th.Append("</tr>");

                _toFormat = th.ToString();
            }
            else if (_toFormat.Contains("#te;"))
            {
                _toFormat = "</table>";
            }
            #endregion

            #region LIST
            else if (_toFormat.Contains("#ls;"))
            {
                return "<list>";
            }
            else if (_toFormat.Contains("#li;"))
            {
                _toFormat = _toFormat.Replace("#li;", "");
                return string.Format("<li>{0}</li>", _toFormat.Trim());
            }
            else if (_toFormat.Contains("#le;"))
            {
                return "</list>";
            }
            #endregion

            #region LINKED LIST
            else if (_toFormat.Contains("#zls;"))
            {
                return "<listlink>";
            }
            else if (_toFormat.Contains("#zle;"))
            {
                return "</listlink>";
            }
            #endregion

            #region LINK REFERENCE
            else if (_toFormat.Contains("#zal;"))
            { 
                // Remove the ZAL ref
                _toFormat = _toFormat.Replace("#zal;","");

                switch (_toFormat.Split(';')[0])
                {
                    //BL;*;Background List
                    case "BL": _toFormat = string.Format("<link class=\"reference_colindex\" recordname=\"reference.backgroundlists.byletter@{0}\">{1}</link>"
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //B;*;Aco Background;acolyte
                    case "B": _toFormat = string.Format("<link class=\"reference_background\" recordname=\"reference.backgrounddata.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ","")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //BF;*;Aco Background Feature;acolyte;Shelter of the Faithful
                    case "BF": _toFormat = string.Format("<link class=\"reference_backgroundfeature\" recordname=\"reference.backgrounddata.{0}.features.{1}@{2}\">{3}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[4].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //CL;*;Class List
                    case "CL": _toFormat = string.Format("<link class=\"reference_colindex\" recordname=\"reference.classlists.byletter@{0}\">{1}</link>"
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //C;*;Barbarian;Barbarian
                    case "C": _toFormat = string.Format("<link class=\"reference_class\" recordname=\"reference.classdata.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //CF;*;Rage Function;Barbarian;Rage1
                    case "CF": _toFormat = string.Format("<link class=\"reference_classfeature\" recordname=\"reference.classdata.{0}.features.{1}@{2}\">{3}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[4].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //CA;*;Path of the zerker;Barbarian;Path of the berserker
                    case "CA": _toFormat = string.Format("<link class=\"reference_classability\" recordname=\"reference.classdata.{0}.abilities.{1}@{2}\">{3}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[4].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //E;*;Equipment List
                    case "E": _toFormat = string.Format("<link class=\"referenceindex\" recordname=\"reference.equipmentlists.equipment@{0}\">{1}</link>"
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //EW;*;Weapon;Club
                    case "EW": _toFormat = string.Format("<link class=\"reference_weapon\" recordname=\"reference.equipmentdata.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //EL;*;Weapon List
                    case "EWL": _toFormat = string.Format("<link class=\"reference_weapontable\" recordname=\"reference.equipmentlists.weapontable@{0}\">{1}</link>"
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //EGL;*;Adventure Gear List
                    case "EGL": _toFormat = string.Format("<link class=\"reference_adventuringgeartable\" recordname=\"reference.equipmentlists.adventuringgeartable@{0}\">{1}</link>"
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //EG;*;Ammunition;Arrow
                    case "EG": _toFormat = string.Format("<link class=\"reference_equipment\" recordname=\"reference.equipmentdata.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //EAL;*;Armor List
                    case "EAL": _toFormat = string.Format("<link class=\"reference_armortable\" recordname=\"reference.equipmentlists.armortable@{0}\">{1}</link>"
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //EA;*;Armor;Padded Armor
                    case "EA": _toFormat = string.Format("<link class=\"reference_armor\" recordname=\"reference.equipmentdata.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //ETL;*;Tools List
                    case "ETL": _toFormat = string.Format("<link class=\"reference_adventuringgeartable\" recordname=\"reference.equipmentlists.toolstable@{0}\">{1}</link>"
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //ET;*;Tool;Alchemist Supplies
                    case "ET": _toFormat = string.Format("<link class=\"reference_equipment\" recordname=\"reference.equipmentdata.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //EML;*;Mounts List
                    case "EML": _toFormat = string.Format("<link class=\"reference_mountsandotheranimalstable\" recordname=\"reference.equipmentlists.mountsandotheranimalstable@{0}\">{1}</link>"
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //EM;*;Mount;Camel
                    case "EM": _toFormat = string.Format("<link class=\"reference_mountsandotheranimals\" recordname=\"reference.equipmentdata.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //EV;*;Vehicle;Wagon
                    case "EV": _toFormat = string.Format("<link class=\"reference_equipment\" recordname=\"reference.equipmentdata.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //EVL;*;Vehicle List
                    case "EVL": _toFormat = string.Format("<link class=\"reference_adventuringgeartable\" recordname=\"reference.equipmentlists.tack_harness_anddrawnvehiclestable@{0}\">{1}</link>"
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //EWV;*;Ship;Galley
                    case "EWV": _toFormat = string.Format("<link class=\"reference_waterbornevehicles\" recordname=\"reference.equipmentdata.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //EWVL;*;Water Vehicle List
                    case "EWVL": _toFormat = string.Format("<link class=\"reference_waterbornevehiclestable\" recordname=\"reference.equipmentlists.waterbornevehiclestable@{0}\">{1}</link>"
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //FL;*;Feat List
                    case "FL": _toFormat = string.Format("<link class=\"reference_featlist\" recordname=\"reference.featlists.byletter@{0}\">{1}</link>"
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //FL;*;Feat;grappler
                    case "F": _toFormat = string.Format("<link class=\"reference_feat\" recordname=\"reference.featdata.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //RL;*;Race List
                    case "RL": _toFormat = string.Format("<link class=\"reference_colindex\" recordname=\"reference.racelists.byletter@{0}\">{1}</link>"
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //R;*;Race;Dwarf
                    case "R": _toFormat = string.Format("<link class=\"reference_race\" recordname=\"reference.racedata.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //RT;*;Race Trait;Dwarf;Ability Scrore Increase
                    case "RT": _toFormat = string.Format("<link class=\"reference_racialtrait\" recordname=\"reference.racedata.{0}.traits.{1}@{2}\">{3}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[4].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //SRL;*;Subrace List;Dwarf
                    case "SRL": _toFormat = string.Format("<link class=\"reference_racialtrait\" recordname=\"reference.racedata.{0}.traits.subrace@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")        
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //SR;*;Subrace;Dwarf;Hill Dwarf
                    case "SR": _toFormat = string.Format("<link class=\"reference_subrace\" recordname=\"reference.racedata.{0}.subraces.{1}@{2}\">{3}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[4].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //SRT;*;Subrace Trait;Dwarf;Hill Dwarf;dwarventoughness
                    case "SRT": _toFormat = string.Format("<link class=\"reference_subracialtrait\" recordname=\"reference.racedata.{0}.subraces.{1}.traits.{2}@{3}\">{4}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[4].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[5].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //SL;*;Spell List
                    case "SL": _toFormat = string.Format("<link class=\"referenceindex\" recordname=\"reference.spelllists.spells@{0}\">{1}</link>"
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //SLL;*;Spell List Bard;Bard
                    case "SLL": _toFormat = string.Format("<link class=\"reference_colindex\" recordname=\"reference.spelllists.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //S;*;Spell;Magic Missile
                    case "S": _toFormat = string.Format("<link class=\"reference_spell\" recordname=\"reference.spelldata.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //T;*;Acolyte Traits;Acolyte Traits
                    case "T": _toFormat = string.Format("<link class=\"table\" recordname=\"tables.tab_{0}@{1}\">{2}</link>"
                        , formatXMLCharachters(_toFormat.Split(';')[3].ToLower().Trim().Replace(" ", ""),"IH")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //ST;*;Story Name;StoryRecord example {6.1.2 Nighttime Random Encounters In Barovia}
                    case "ST":
                        _toFormat = string.Format("<link class=\"encounter\" recordname=\"encounter.enc_{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //IMG;*;{Image Name};{Image Record Name}
                    case "IMG":
                        _toFormat = string.Format("<link class=\"imagewindow\" recordname=\"img{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    //NPC;*;{NPC Name};{NPC Record Name}
                    case "NPC":
                        _toFormat = string.Format("<link class=\"npc\" recordname=\"npc.{0}@{1}\">{2}</link>"
                        , _toFormat.Split(';')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(';')[1]
                        , _toFormat.Split(';')[2]
                        );
                        break;
                    default:
                        break;
                }
            }
            #endregion
            // When links need to be used in a table
            else if (_toFormat.Contains("#zal:"))
            {
                // Remove the ZAL ref
                _toFormat = _toFormat.Replace("#zal:", "").Replace(";","");

                switch (_toFormat.Split(':')[0])
                {
                    //ST:*:Story Name:StoryRecord example {6.1.2 Nighttime Random Encounters In Barovia}
                    case "ST":
                        _toFormat = string.Format("encounter.enc_{0}@{1}"
                        , _toFormat.Split(':')[3].ToLower().Trim().Replace(" ", "")
                        , _toFormat.Split(':')[1]
                        );
                        break;
                    //NPC:*:{NPC Name}:{NPC Record Name}
                    case "NPC":
                        _toFormat = string.Format("npc.{0}@{1}"
                        , formatXMLCharachters(_toFormat.Split(':')[3].ToLower().Trim().Replace(" ", ""),"IH")
                        , _toFormat.Split(':')[1]
                        );
                        break;
                    default:
                        break;
                }
            }
            else
            {
                _toFormat = string.Format("<p>{0}</p>", _toFormat);
            }

            return _toFormat;
        }

        public string formatXMLCharachters(string _toFormat, string type)
        {
            // Class Header
            if (type == "CH")
            {
                _toFormat = _toFormat.Replace(" ", "").ToLower().Trim();
                return _toFormat;
            }

            // Feature Header
            if (type == "FH")
            { 
                _toFormat = _toFormat.Replace(" ", "")
                                                    .Replace("-", "")
                                                    .Replace("&", "")
                                                    .Replace(":", "")
                                                    .Replace("'", "")
                                                    .Replace("’", "")
                                                    .ToLower().Trim();

                return _toFormat;
            }

            if (type == "IH")
            {
                _toFormat = _toFormat.Replace(" ","")
                                                    .Replace("-", "_")
                                                    .Replace("&", "_")
                                                    .Replace(":", "_")
                                                    .Replace("'", "_")
                                                    .Replace("’", "_")
                                                    .Replace("(", "_")
                                                    .Replace(")", "_")
                                                    .Replace(",", "_")
                                                    .Replace("+", "_")
                                                    .Replace("/", "_")
                                                    .Replace(".", "_")
                                                    .Replace(@"\", "_")
                                                    //.Replace("1", "_")
                                                    //.Replace("2", "_")
                                                    //.Replace("3", "_")
                                                    //.Replace("4", "_")
                                                    //.Replace("5", "_")
                                                    //.Replace("6", "_")
                                                    //.Replace("7", "_")
                                                    //.Replace("8", "_")
                                                    //.Replace("9", "_")
                                                    .ToLower().Trim();

                return _toFormat;
            }

            if (type == "ID")
            {
                _toFormat = _toFormat.Replace(" ", "")
                                        .Replace("&", "&amp;")
                                        .ToLower().Trim();
            }

            return _toFormat.Trim();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            #region ZL Discontinued
            //else if (_toFormat.Contains("#zl;"))
            //{
            //    _toFormat = _toFormat.Replace("#zl;","");

            //    // Format depending on what record set is required
            //    if (_toFormat.Contains("_ability"))
            //    {
            //        _toFormat = _toFormat.Replace("_ability", "");

            //        string _useName = string.Empty;

            //        if (!string.IsNullOrEmpty(_toFormat.Split(';')[2]))
            //        {
            //            _useName = _toFormat.Split(';')[2];
            //        }
            //        else
            //        {
            //            _useName = _toFormat.Split(';')[1];
            //        }

            //        _toFormat = string.Format("<link class=\"reference_classability\" recordname=\"reference.classdata.{0}.abilities.{1}@{2}\">{3}</link>",
            //            _toFormat.Split(';')[0].ToLower().Trim(),
            //            _toFormat.Split(';')[1].ToLower().Replace(" ", "").Trim(),
            //            _moduleName,
            //            _useName.Trim());
            //    }

            //}
            #endregion

            #region LINK REFERENCE
            else if (_toFormat.Contains("#zal;"))
            {
                #region OLD CODE
                //_toFormat = _toFormat.Replace("#zal;", "");

                //// Format depending on what record set is required
                //if (_toFormat.Contains("_ability"))
                //{
                //    _toFormat = _toFormat.Replace("_ability", "");

                //    string _useName = string.Empty;

                //    if (!string.IsNullOrEmpty(_toFormat.Split(';')[3]))
                //    {
                //        _useName = _toFormat.Split(';')[3];
                //    }
                //    else
                //    {
                //        _useName = _toFormat.Split(';')[1];
                //    }

                //    _toFormat = string.Format("<link class=\"reference_classability\" recordname=\"reference.classdata.{0}.abilities.{1}@{2}\">{3}</link>",
                //        _toFormat.Split(';')[0].ToLower().Trim(),
                //        _toFormat.Split(';')[1].ToLower().Replace(" ", "").Trim(),
                //        _toFormat.Split(';')[2].Trim(),
                //        _useName.Trim());
                //}

                ////<link class="reference_backgroundfeature" recordname="reference.backgrounddata.acolyte.features.shelterofthefaithful@DD5E SRD Data">TESTING</link>
                //else if (_toFormat.Contains("background_feature"))
                //{
                //    //background_feature;Acolyte;Shelter of the faithful;DD5E SRD Data;Background Feature Check

                //    _toFormat = _toFormat.Replace("background_feature;", "");

                //    //Acolyte;Shelter of the faithful;DD5E SRD Data;Background Feature Check

                //    string _useName = string.Empty;
                //    if (!string.IsNullOrEmpty(_toFormat.Split(';')[3]))
                //    {
                //        _useName = _toFormat.Split(';')[3];
                //    }
                //    else
                //    {
                //        _useName = _toFormat.Split(';')[1];
                //    }

                //    _toFormat = string.Format("<link class=\"reference_backgroundfeature\" recordname=\"reference.backgrounddata.{0}.features.{1}@{2}\">{3}</link>",
                //        _toFormat.Split(';')[0].ToLower().Replace(" ", "").Trim(),
                //        _toFormat.Split(';')[1].ToLower().Replace(" ", "").Trim(),
                //        _toFormat.Split(';')[2].Trim(),
                //        _useName
                //        );
                //}

                ////<link class="reference_background" recordname="reference.backgrounddata.acolyte@DD5E SRD Data">TESTING</link>
                //else if (_toFormat.Contains("background"))
                //{
                //    //background;Acolyte;DD5E SRD Data;Check this out

                //    _toFormat = _toFormat.Replace("background;", "");

                //    //Acolyte;DD5E SRD Data;Check this out

                //    string _useName = string.Empty;
                //    if (!string.IsNullOrEmpty(_toFormat.Split(';')[2]))
                //    {
                //        _useName = _toFormat.Split(';')[2];
                //    }
                //    else
                //    {
                //        _useName = _toFormat.Split(';')[0];
                //    }

                //    _toFormat = string.Format("<link class=\"reference_background\" recordname=\"reference.backgrounddata.{0}@{1}\">{2}</link>",
                //        _toFormat.Split(';')[0].ToLower().Replace(" ", "").Trim(),
                //        _toFormat.Split(';')[1].Trim(),
                //        _useName
                //        );
                //}

                ////<link class="reference_classfeature" recordname="reference.classdata.barbarian.features.rage1@Player Handbook">TESTING</link>
                //else if (_toFormat.Contains("_feature"))
                //{
                //    //#zal;barbarian_feature;Rage;Player Handbook;Feature Reference Test

                //    _toFormat = _toFormat.Replace("_feature", "");

                //    //barbarian;Rage;Player Handbook;Feature Reference Test

                //    string _useName = string.Empty;

                //    if (!string.IsNullOrEmpty(_toFormat.Split(';')[3]))
                //    {
                //        _useName = _toFormat.Split(';')[3];
                //    }
                //    else
                //    {
                //        _useName = _toFormat.Split(';')[1];
                //    }

                //    _toFormat = string.Format("<link class=\"reference_classfeature\" recordname=\"reference.classdata.{0}.features.{1}@{2}\">{3}</link>",
                //        _toFormat.Split(';')[0].ToLower().Trim(),
                //        _toFormat.Split(';')[1].ToLower().Replace(" ", "").Trim(),
                //        _toFormat.Split(';')[2].Trim(),
                //        _useName.Trim());
                //}

                ////<link class="imagewindow" recordname="image.img_clericfullaart_jpg@Player Handbook">TESTING</link>
                //else if (_toFormat.Contains("image"))
                //{
                //    //#zal;image;ClericFullAart.jpg;Player Handbook;Cleric Art

                //    _toFormat = _toFormat.Replace("image;", "");

                //    //ClericFullAart.jpg;Player Handbook;Cleric Art

                //    string _useName = string.Empty;
                //    if (!string.IsNullOrEmpty(_toFormat.Split(';')[2]))
                //    {
                //        _useName = _toFormat.Split(';')[2];
                //    }
                //    else
                //    {
                //        _useName = _toFormat.Split(';')[0];
                //    }

                //    _toFormat = string.Format("<link class=\"imagewindow\" recordname=\"image.{0}@{1}\">{2}</link>",
                //        string.Format("{0}", _toFormat.Split(';')[0].Replace(".", "_").ToLower().Trim()),
                //        _toFormat.Split(';')[1].Trim(),
                //        _useName
                //        );
                //}

                ////<link class="reference_colindex" recordname="reference.spelllists.thearchfey@Player Handbook">TESTING</link>
                //else if (_toFormat.Contains("spellslist"))
                //{
                //    //#zal;spellslist;Cleric;DD5E SRD Data;Spell List Test

                //    _toFormat = _toFormat.Replace("spellslist;", "");

                //    //Cleric;DD5E SRD Data;Spell List Test

                //    string _useName = string.Empty;
                //    if (!string.IsNullOrEmpty(_toFormat.Split(';')[2]))
                //    {
                //        _useName = _toFormat.Split(';')[2];
                //    }
                //    else
                //    {
                //        _useName = _toFormat.Split(';')[0];
                //    }

                //    _toFormat = string.Format("<link class=\"reference_colindex\" recordname=\"reference.spelllists.{0}@{1}\">{2}</link>",
                //        string.Format("{0}", _toFormat.Split(';')[0].Replace(" ", "").ToLower().Trim()),
                //        _toFormat.Split(';')[1].Trim(),
                //        _useName
                //        );
                //}

                ////<link class="reference_spell" recordname="reference.spelldata.guidance@DD5E SRD Data">TESTING</link>
                //else if (_toFormat.Contains("spell"))
                //{
                //    //#zal;spell;Guidance;DD5E SRD Data;Spell Test

                //    _toFormat = _toFormat.Replace("spell;", "");

                //    //Guidance;DD5E SRD Data;Spell Test

                //    string _useName = string.Empty;
                //    if (!string.IsNullOrEmpty(_toFormat.Split(';')[2]))
                //    {
                //        _useName = _toFormat.Split(';')[2];
                //    }
                //    else
                //    {
                //        _useName = _toFormat.Split(';')[0];
                //    }

                //    _toFormat = string.Format("<link class=\"reference_spell\" recordname=\"reference.spelldata.{0}@{1}\">{2}</link>",
                //        string.Format("{0}", _toFormat.Split(';')[0].Replace(" ", "").ToLower().Trim()),
                //        _toFormat.Split(';')[1].Trim(),
                //        _useName
                //        );
                //}
                #endregion
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

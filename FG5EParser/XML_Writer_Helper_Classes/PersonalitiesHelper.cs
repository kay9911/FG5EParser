using FG5EParser.Base_Classes;
using FG5EParser.Writer_Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class PersonalitiesHelper
    {
        public string returnPersonalitiesXML(
            string _npcTextPath,
            string _moduleName,
            bool isList = false
        )
        {
            StringBuilder xml = new StringBuilder();

            NPCWriter _npcWriter = new NPCWriter();
            List<Personalities> _Npcs = _npcWriter.compileNPCList(_npcTextPath,_moduleName);

            if (!isList)
            {
                #region Start NPC XML processing
                xml.Append("<npc>");
                xml.Append(string.Format("<category name=\"NPCs - {0}\" baseicon=\"2\" decalicon=\"1\">", _moduleName));

                foreach (Personalities _person in _Npcs)
                {
                    xml.Append(string.Format("{0}", generateNPCXML(_person)));
                }

                xml.Append("</category>");
                xml.Append("</npc>");
                #endregion
            }
            else
            {
                #region Creating The Lists

                xml.Append("<npc>");

                #region By Letter

                xml.Append("<byletter>");

                xml.Append("<description type=\"string\">NPCs</description>");

                xml.Append("<groups>");

                // Now we need to sort by letter
                xml.Append(string.Format("{0}", sortByLetter(_Npcs, _moduleName)));

                xml.Append("</groups>");

                xml.Append("</byletter>");

                #endregion

                xml.Append("</npc>");
            }            

            return xml.ToString();

            #endregion
        }

        private string generateNPCXML(Personalities _person)
        {
            StringBuilder _npc = new StringBuilder();

            _npc.Append(string.Format("<{0}>", _person.NPCName.Replace(" ", "").ToLower().Trim()));

            _npc.Append(string.Format("<locked type=\"number\">{0}</locked>", _person.LockType));

            _npc.Append(string.Format("<name type=\"string\">{0}</name>", _person.NPCName));

            _npc.Append(string.Format("<type type=\"string\">{0}</type>", _person.NPCType));

            _npc.Append(string.Format("<size type=\"string\">{0}</size>", _person.NPCSize));

            _npc.Append(string.Format("<ac type=\"number\">{0}</ac>", _person.NPCAc));

            if (!string.IsNullOrEmpty(_person.NPCAcText))
            {
                _npc.Append(string.Format("<actext type=\"string\">{0}</actext>", _person.NPCAcText));
            }
            else
            {
                _npc.Append("<actext type=\"string\" />");
            }

            _npc.Append(string.Format("<hp type=\"number\">{0}</hp>", _person.NPCHitPoints));

            _npc.Append(string.Format("<hd type=\"string\">{0}</hd>", _person.NPCHitDice));

            _npc.Append(string.Format("<speed type=\"string\">{0}</speed>", _person.NPCSpeed));

            _npc.Append(string.Format("<abilities>"));

            _npc.Append(string.Format("<strength>"));
            //< strength >

            _npc.Append(string.Format("<score type=\"number\">{0}</score>", _person.NPCStrength));
            //< score type = "number" > 26 </ score >

            _npc.Append(string.Format("<modifier type=\"string\">{0}</modifier>", _person.NPCStrengthModifier));
            //< modifier type = "string" > +8 </ modifier >

            _npc.Append(string.Format("</strength>"));
            //</ strength >

            _npc.Append(string.Format("<dexterity>"));
            //< dexterity >

            _npc.Append(string.Format("<score type=\"number\">{0}</score>", _person.NPCDexterity));
            //< score type = "number" > 22 </ score >

            _npc.Append(string.Format("<modifier type=\"string\">{0}</modifier>", _person.NPCDexterityModifier));
            //< modifier type = "string" > +6 </ modifier >

            _npc.Append(string.Format("</dexterity>"));
            //</ dexterity >

            _npc.Append(string.Format("<constitution>"));
            //< constitution >

            _npc.Append(string.Format("<score type=\"number\">{0}</score>", _person.NPCConstitution));
            //< score type = "number" > 26 </ score >

            _npc.Append(string.Format("<modifier type=\"string\">{0}</modifier>", _person.NPCConstitutionModifier));
            //< modifier type = "string" > +8 </ modifier >

            _npc.Append(string.Format("</constitution>"));
            //</ constitution >

            _npc.Append(string.Format("<intelligence>"));
            //< intelligence >

            _npc.Append(string.Format("<score type=\"number\">{0}</score>", _person.NPCIntelligence));
            //< score type = "number" > 25 </ score >

            _npc.Append(string.Format("<modifier type=\"string\">{0}</modifier>", _person.NPCIntelligenceModifier));
            //< modifier type = "string" > +7 </ modifier >

            _npc.Append(string.Format("</intelligence>"));
            //</ intelligence >

            _npc.Append(string.Format("<wisdom>"));
            //< wisdom >

            _npc.Append(string.Format("<score type=\"number\">{0}</score>", _person.NPCWisdom));
            //< score type = "number" > 25 </ score >

            _npc.Append(string.Format("<modifier type=\"string\">{0}</modifier>", _person.NPCWisdomModifier));
            //< modifier type = "string" > +7 </ modifier >

            _npc.Append(string.Format("</wisdom>"));
            //</ wisdom >

            _npc.Append(string.Format("<charisma>"));
            //< charisma >

            _npc.Append(string.Format("<score type=\"number\">{0}</score>", _person.NPCCharisma));
            //< score type = "number" > 30 </ score >

            _npc.Append(string.Format("<modifier type=\"string\">{0}</modifier>", _person.NPCCharismaModifier));
            //< modifier type = "string" > +10 </ modifier >

            _npc.Append(string.Format("</charisma>"));
            //</ charisma >

            _npc.Append(string.Format("</abilities>"));
            //</ abilities >

            if (!string.IsNullOrEmpty(_person.NPCSavingThrows))
            {
                _npc.Append(string.Format("<savingthrows type=\"string\">{0}</savingthrows>", _person.NPCSavingThrows));
                //< savingthrows type = "string" > Int + 14, Wis + 14, Cha + 17 </ savingthrows >
            }

            if (!string.IsNullOrEmpty(_person.NPCSkills))
            {
                _npc.Append(string.Format("<skills type=\"string\">{0}</skills>", _person.NPCSkills));
                //< skills type = "string" > Perception + 14 </ skills >
            }

            if (!string.IsNullOrEmpty(_person.NPCDmgVul))
            {
                _npc.Append(string.Format("<damagevulnerabilities type=\"string\">{0}</damagevulnerabilities>", _person.NPCDmgVul));
            }

            if (!string.IsNullOrEmpty(_person.NPCDmgRes))
            {
                _npc.Append(string.Format("<damageresistances type=\"string\">{0}</damageresistances>", _person.NPCDmgRes));
                //< damageresistances type = "string" > radiant; bludgeoning, piercing, and slashing from nonmagical weapons</ damageresistances >
            }

            if (!string.IsNullOrEmpty(_person.NPCDmgImm))
            {
                _npc.Append(string.Format("<damageimmunities type=\"string\">{0}</damageimmunities>", _person.NPCDmgImm));
                //< damageimmunities type = "string" > necrotic, poison </ damageimmunities >
            }

            if (!string.IsNullOrEmpty(_person.NPCCondImm))
            {
                _npc.Append(string.Format("<conditionimmunities type=\"string\">{0}</conditionimmunities>", _person.NPCCondImm));
                //< conditionimmunities type = "string" > charmed, exhaustion, frightened, poisoned </ conditionimmunities >
            }

            _npc.Append(string.Format("<senses type=\"string\">{0}</senses>", _person.NPCSenses));
            //< senses type = "string" > truesight 120ft., passive Perception 24 </ senses >

            //_npc.Append(string.Format(""));
            _npc.Append(string.Format("<alignment type=\"string\">{0}</alignment>", _person.NPCAlignment));
            //< alignment type = "string" > lawful good </ alignment >

            _npc.Append(string.Format("<languages type=\"string\">{0}</languages>", _person.NPCLanguages));
            //< languages type = "string" > all, telepathy 120ft.</ languages >

            _npc.Append(string.Format("<cr type=\"string\">{0}</cr>", _person.NPCCr));
            //< cr type = "string" > 21 </ cr >

            _npc.Append(string.Format("<xp type=\"number\">{0}</xp>", _person.NPCXp));
            //< xp type = "number" > 33000 </ xp >

            if (_person.NPCAbilities.Count != 0)
            {
                _npc.Append(string.Format("<traits>"));
                //< traits >

                StringBuilder _traits = new StringBuilder();

                for (int i = 0; i < _person.NPCAbilities.Count; i++)
                {
                    _traits.Append(string.Format("<id-0000{0}>", i + 1));
                    //< id - 00001 >
                    string _name = _person.NPCAbilities[i].Split('.')[0].Trim();
                    string _desc = _person.NPCAbilities[i].Replace(_name, "").Trim();
                    _desc = ReplaceFirst(_desc, ".", "").Trim();

                    _traits.Append(string.Format("<name type=\"string\">{0}</name>", _name));
                    //< name type = "string" > Angelic Weapons </ name >
                    if (_name == "Innate Spellcasting")
                    {
                        _traits.Append(string.Format("<desc type=\"string\">{0}</desc>", _desc));
                    }
                    else if (_name == "Spellcasting")
                    {
                        _traits.Append(string.Format("<desc type=\"string\">{0}</desc>", _desc));
                    }
                    else
                    {
                        _traits.Append(string.Format("<desc type=\"string\">{0}</desc>", _desc));
                    }
                    //< desc type = "string" > The solar's weapon attacks are magical. When the solar hits with any weapon, the weapon deal s an extra 6d8 radiant damage (included in the attack).</desc>
                    _traits.Append(string.Format("</id-0000{0}>", i + 1));
                    //</ id - 00001 >
                }
                _npc.Append(_traits.ToString());

                _npc.Append(string.Format("</traits>"));
                //</ traits >
            }

            if (_person.NPCReactions.Count != 0)
            {
                _npc.Append(string.Format("<reactions>"));

                StringBuilder _reaction = new StringBuilder();

                for (int i = 0; i < _person.NPCReactions.Count; i++)
                {
                    _reaction.Append(string.Format("<id-0000{0}>", i + 1));
                    string _name = _person.NPCReactions[i].Split('.')[0].Trim();
                    string _desc = _person.NPCReactions[i].Replace(_name, "").Trim();
                    _desc = ReplaceFirst(_desc, ".", "");

                    _reaction.Append(string.Format("<name type=\"string\">{0}</name>", _name));
                    _reaction.Append(string.Format("<desc type=\"string\">{0}</desc>", _desc));
                    _reaction.Append(string.Format("</id-0000{0}>", i + 1));
                }

                _npc.Append(_reaction.ToString());

                _npc.Append(string.Format("</reactions>"));
            }

            _npc.Append(string.Format("<actions>"));
            //< actions >

            StringBuilder _actions = new StringBuilder();

            for (int i = 0; i < _person.NPCActions.Count; i++)
            {
                _actions.Append(string.Format("<id-0000{0}>", i + 1));
                //< id - 00001 >
                string _name = _person.NPCActions[i].Split('.')[0].Trim();
                string _desc = _person.NPCActions[i].Replace(_name, "").Trim();
                _desc = ReplaceFirst(_desc, ".", "");

                _actions.Append(string.Format("<name type=\"string\">{0}</name>", _name));
                //< name type = "string" > Multiattack </ name >
                _actions.Append(string.Format("<desc type=\"string\">{0}</desc>", _desc));
                //< desc type = "string" > The solar makes two greatsword attacks.</ desc >
                _actions.Append(string.Format("</id-0000{0}>", i + 1));
                //</ id - 00001 >
            }

            _npc.Append(_actions.ToString());

            _npc.Append(string.Format("</actions>"));
            //</ actions >

            if (_person.NPCLegendActions.Count != 0)
            {
                _npc.Append(string.Format("<legendaryactions>"));
                //< legendaryactions >

                StringBuilder _legend = new StringBuilder();

                for (int i = 0; i < _person.NPCLegendActions.Count; i++)
                {
                    _legend.Append(string.Format("<id-0000{0}>", i + 1));
                    //< id - 00001 >
                    string _name = _person.NPCLegendActions[i].Split('.')[0].Trim();
                    string _desc = _person.NPCLegendActions[i].Replace(_name, "").Trim();
                    _desc = ReplaceFirst(_desc, ".", "");

                    _legend.Append(string.Format("<name type=\"string\">{0}</name>", _name));
                    //< name type = "string" > Option </ name >
                    _legend.Append(string.Format("<desc type=\"string\">{0}</desc>", _desc));
                    //< desc type = "string" > The solar can take 3 legendary actions, choosing from the options below.Only one legendary action option can be used at a time and only at the end of another creature's turn. The solar regains spent legendary actions at the start of its turn.</desc>
                    _legend.Append(string.Format("</id-0000{0}>", i + 1));
                    //</ id - 00001 >            
                }

                _npc.Append(_legend.ToString());

                _npc.Append(string.Format("</legendaryactions>"));
                //</ legendaryactions >
            }

            if (_person.NPCDetails.Count != 0)
            {
                _npc.Append("<text type =\"formattedtext\">");

                for (int i = 0; i < _person.NPCDetails.Count; i++)
                {
                    _npc.Append(string.Format("<p>{0}</p>",_person.NPCDetails[i].ToString()));
                }

                _npc.Append("</text>");

            }

            _npc.Append(string.Format("</{0}>", _person.NPCName.Replace(" ", "").ToLower().Trim()));

            return _npc.ToString();
        }

        public string returnNPCReferenceDetails(string _npcTextPath, string _moduleName)
        {
            StringBuilder xml = new StringBuilder();

            NPCWriter _npcWriter = new NPCWriter();
            List<Personalities> _Npcs = _npcWriter.compileNPCList(_npcTextPath,_moduleName);

            #region NPC DATA

            xml.Append("<npcdata>");

            foreach (Personalities _person in _Npcs)
            {
                xml.Append(string.Format("{0}", generateNPCXML(_person)));
            }

            xml.Append("</npcdata>");

            #endregion

            xml.Append("<npclists>");

            xml.Append("<npcs>");

            xml.Append("<name type=\"string\">NPCs</name>");

            xml.Append("<index>");

            xml.Append("<id-00001>");
            xml.Append("<name type=\"string\">NPCs - Alphabetical Index</name>");
            xml.Append("<listlink type=\"windowreference\">");
            xml.Append("<class>reference_colindex</class>");

            xml.Append(string.Format("<recordname>reference.npclists.byletter@{0}</recordname>", _moduleName));
            xml.Append("</listlink>");
            xml.Append("</id-00001>");

            xml.Append("<id-00002>");
            xml.Append("<name type=\"string\">NPCs - Challenge Rating Index</name>");
            xml.Append("<listlink type=\"windowreference\">");
            xml.Append("<class>reference_colindex</class>");

            xml.Append(string.Format("<recordname>reference.npclists.bylevel@{0}</recordname>", _moduleName));
            xml.Append("</listlink>");
            xml.Append("</id-00002>");

            xml.Append("<id-00003>");
            xml.Append("<name type=\"string\">NPCs - Class Index</name>");
            xml.Append("<listlink type=\"windowreference\">");
            xml.Append("<class>reference_colindex</class>");

            xml.Append(string.Format("<recordname>reference.npclists.bytype@{0}</recordname>", _moduleName));
            xml.Append("</listlink>");
            xml.Append("</id-00003>");

            xml.Append("</index>");

            xml.Append("</npcs>");

            xml.Append("<byletter>");

            xml.Append("<description type=\"string\">NPCs</description>");

            xml.Append("<groups>");

            // Sort by letter
            xml.Append(string.Format("{0}", sortByLetter(_Npcs, _moduleName)));

            xml.Append("</groups>");

            xml.Append("</byletter>");

            // Sort by level
            xml.Append(string.Format("{0}", sortByLevel(_Npcs, _moduleName)));

            // Sort by Type
            xml.Append(string.Format("{0}", sortByType(_Npcs, _moduleName)));

            xml.Append("</npclists>");

            return xml.ToString();
        }

        private string sortByLetter(List<Personalities> _Npcs, string _moduleName)
        {
            StringBuilder _npc = new StringBuilder();
            List<string> alphabets = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            foreach (string _s in alphabets)
            {
                Personalities _current = new Personalities();

                _current = _Npcs.Find(x => x.NPCName.StartsWith(_s) || x.NPCName.StartsWith(_s.ToLower()));

                if (_current != null)
                {
                    _npc.Append(string.Format("<typeletter{0}>", _s.ToLower()));

                    _npc.Append(string.Format("<description type=\"string\">{0}</description>", _s));

                    _npc.Append("<index>");

                    var _list = _Npcs.FindAll(x => x.NPCName.StartsWith(_s)).ToList();

                    // Start returning NPC's based on starting letter

                    while (_list.Count != 0)
                    {
                        _current = _list.First();

                        _npc.Append(string.Format("<{0}>", _current.NPCName.Replace(" ", "").ToLower().Trim()));

                        _npc.Append("<link type=\"windowreference\">");

                        _npc.Append("<class>npc</class>");

                        _npc.Append(string.Format("<recordname>npc.{0}@{1}</recordname>", _current.NPCName.Replace(" ", "").ToLower().Trim(), _moduleName));

                        _npc.Append("<description>");

                        _npc.Append("<field>name</field>");

                        _npc.Append("</description>");

                        _npc.Append("</link>");

                        _npc.Append("<source type=\"string\" />");

                        _npc.Append(string.Format("</{0}>", _current.NPCName.Replace(" ", "").ToLower().Trim()));

                        #region Example
                        //      < deathknight >
                        //  < link type = "windowreference" >

                        //     <class>npc</class>
                        //    <recordname>npc.deathknight @Monster Manual</recordname>
                        //    <description>
                        //      <field>name</field>
                        //    </description>
                        //  </link>
                        //  <source type = "string" />
                        //</ deathknight >
                        #endregion
                        // After processing get rid of it
                        _list.RemoveAt(0);
                    }

                    _npc.Append("</index>");

                    _npc.Append(string.Format("</typeletter{0}>", _s.ToLower()));

                } // end of (_current != null)

            } // end of foreach

            return _npc.ToString();
        }

        private string sortByLevel(List<Personalities> _Npcs, string _moduleName)
        {
            StringBuilder _npc = new StringBuilder();
            List<string> _npcLevelList = new List<string>();

            if (_Npcs.Count != 0)
            {
                _npc.Append("<bylevel>");
                _npc.Append("<description type=\"string\">NPCs</description>");

                _npc.Append("<groups>");

                // Get the first value
                for (int i = 0; i < _Npcs.Count; i++)
                {
                    string _currentLevelValue = _Npcs[i].NPCCr;

                    // Check to see if value has been processed
                    if (_npcLevelList.Count == 0 || !_npcLevelList.Contains(_currentLevelValue))
                    {
                        // Add the current value to the list
                        _npcLevelList.Add(_currentLevelValue);

                        _npc.Append(string.Format("<level{0}>", getLevelXMLTag(_currentLevelValue)));
                        _npc.Append(string.Format("<description type=\"string\">{0}</description>", _currentLevelValue));
                        _npc.Append("<index>");

                        // Bring up NPC's based on their CR rating
                        foreach (Personalities _this in _Npcs)
                        {
                            if (_this.NPCCr == _currentLevelValue)
                            {
                                _npc.Append(string.Format("<{0}>", _this.NPCName.Replace(" ", "").ToLower().Trim()));
                                _npc.Append("<link type=\"windowreference\">");
                                _npc.Append("<class>npc</class>");
                                _npc.Append(string.Format("<recordname>reference.npcdata.{0}@{1}</recordname>", _this.NPCName.Replace(" ", "").ToLower().Trim(), _moduleName));
                                _npc.Append("<description>");
                                _npc.Append("<field>name</field>");
                                _npc.Append("</description>");
                                _npc.Append("</link>");
                                _npc.Append("<source type=\"number\" />");
                                _npc.Append(string.Format("</{0}>", _this.NPCName.Replace(" ", "").ToLower()));
                            }
                        }

                        _npc.Append("</index>");
                        _npc.Append(string.Format("</level{0}>", getLevelXMLTag(_currentLevelValue)));

                    }
                }
                _npc.Append("</groups>");

                _npc.Append("</bylevel>");
            }

            return _npc.ToString();
        }

        private string sortByType(List<Personalities> _Npcs, string _moduleName)
        {
            StringBuilder _npc = new StringBuilder();
            List<string> _npcTypeList = new List<string>();

            if (_Npcs.Count != 0)
            {
                _npc.Append("<bytype>");
                _npc.Append("<description type=\"string\">NPCs</description>");
                _npc.Append("<groups>");

                // Get the first value
                for (int i = 0; i < _Npcs.Count; i++)
                {
                    string _currentTypeValue = _Npcs[i].NPCType;

                    // Check to see if value has been processed
                    if (_npcTypeList.Count == 0 || !_npcTypeList.Contains(_currentTypeValue))
                    {
                        // Add the value to the list
                        _npcTypeList.Add(_currentTypeValue);

                        _npc.Append(string.Format("<type{0}>", getXMLType(_currentTypeValue.Replace(",", "_"))));
                        _npc.Append(string.Format("<description type=\"string\">{0}</description>", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_currentTypeValue.ToLower())));
                        _npc.Append("<index>");

                        // Bring up the NPC's based on type
                        foreach (Personalities _this in _Npcs)
                        {
                            if (_this.NPCType == _currentTypeValue)
                            {
                                _npc.Append(string.Format("<{0}>", _this.NPCName.Replace(" ", "").ToLower().Trim()));
                                _npc.Append("<link type=\"windowreference\">");
                                _npc.Append("<class>npc</class>");
                                _npc.Append(string.Format("<recordname>reference.npcdata.{0}@{1}</recordname>", _this.NPCName.Replace(" ", "").ToLower().Trim(), _moduleName));
                                _npc.Append("<description>");
                                _npc.Append("<field>name</field>");
                                _npc.Append("</description>");
                                _npc.Append("</link>");
                                _npc.Append(string.Format("<source>{0}</source>", _currentTypeValue));
                                _npc.Append(string.Format("</{0}>", _this.NPCName.Replace(" ", "").ToLower()));
                            }
                        }

                        _npc.Append("</index>");
                        _npc.Append(string.Format("</type{0}>", getXMLType(_currentTypeValue.Replace(",", "_"))));
                    }
                }
                _npc.Append("</groups>");
                _npc.Append("</bytype>");
            }

            return _npc.ToString();
        }


        private string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text.Trim();
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length).Trim();
        }

        private string getLevelXMLTag(string _currentLevelValue)
        {
            if (!_currentLevelValue.Contains("/"))
            {
                int _val = Convert.ToInt32(_currentLevelValue);

                if (_val < 10 && _val >= 0)
                {
                    _currentLevelValue = string.Format("0{0}", _currentLevelValue);
                }
                return _currentLevelValue;
            }
            else
                return _currentLevelValue.Replace("/", "_").Trim();
        }

        private string getXMLType(string _currentTypeValue)
        {
            _currentTypeValue = _currentTypeValue.Replace(" ", "").Replace("(", "_").Replace(")", "_").Trim();

            return _currentTypeValue;
        }

    }
}

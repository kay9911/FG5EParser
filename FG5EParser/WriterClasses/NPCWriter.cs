using FG5EParser.Base_Classes;
using FG5eParserModels.DM_Modules;
using System;
using System.Collections.Generic;
using System.IO;

namespace FG5EParser.Writer_Classes
{
    class NPCWriter
    {
        #region OLD CODE
        public List<Personalities> compileNPCList(string _inputLocation, string moduleName)
        {
            try
            {
                var _lines = File.ReadLines(_inputLocation);
                List<string> _basic = new List<string>();
                List<Personalities> NPCS = new List<Personalities>();

                //BEGIN
                #region Process Lines
                foreach (var _line in _lines)
                {
                    if (!String.IsNullOrWhiteSpace(_line))
                    {
                        _basic.Add(_line);
                    }
                    else
                    {
                        // Send for processing
                        Personalities _personalities = new Personalities();
                        if (_basic.Count != 0)
                        {
                            _personalities = _personalities.BindValues(_basic, moduleName);
                            NPCS.Add(_personalities);
                        }
                        _basic.Clear();
                    }
                }

                // If there is just one entry or the last entry
                if (!string.IsNullOrEmpty(_basic.ToString()))
                {
                    Personalities _personalities = new Personalities();
                    if (_basic.Count != 0)
                    {
                        _personalities = _personalities.BindValues(_basic, moduleName);
                        NPCS.Add(_personalities);
                    }
                    _basic.Clear();
                }
                #endregion

                return NPCS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public List<Personalities> compileNPCListNew(string _inputLocation, string moduleName)
        {
            try
            {
                // Read the lines from the file
                var _lines = File.ReadLines(_inputLocation);

                // Convert to list
                List<string> _npcListDetails = new List<string>();
                List<Personalities> NPCList = new List<Personalities>();

                if (_lines != null)
                {
                    foreach (var line in _lines)
                    {
                        _npcListDetails.Add(line);
                    }

                    // The reuse object
                    Personalities _npc = new Personalities();

                    //BEGIN
                    #region Process Lines

                    for (int i = 0; i < _npcListDetails.Count; i++)
                    {
                        //Name
                        _npc.NPCName = _npcListDetails[i].Trim();
                        i++;

                        // Example: Medium Humanoid (Any Race), Any Alignment
                        //Size
                        _npc.NPCSize = _npcListDetails[i].Split(' ')[0].Trim();
                        //Race & Subrace
                        _npc.NPCType = _npcListDetails[i].Split(',')[0].Replace(_npc.NPCSize, "").Trim();
                        //Alignment
                        _npc.NPCAlignment = _npcListDetails[i].Split(',')[1].Trim();
                        i++;

                        if (_npcListDetails[i].Contains("("))
                        {
                            //Armor Text
                            _npc.NPCAcText = string.Format("({0}", _npcListDetails[i].Split('(')[1].Trim());
                            //Armor
                            _npc.NPCAc = Convert.ToInt32(_npcListDetails[i].Replace(_npc.NPCAcText, "").Replace("Armor Class", "").Trim());
                            i++;
                        }
                        else
                        {
                            //Armor ONLY
                            _npc.NPCAc = Convert.ToInt32(_npcListDetails[i].Replace("Armor Class", "").Trim());
                            i++;
                        }

                        //Hit Dice
                        _npc.NPCHitDice = string.Format("({0}", _npcListDetails[i].Split('(')[1].Trim());
                        //HP
                        _npc.NPCHitPoints = Convert.ToInt32(_npcListDetails[i].Replace(_npc.NPCHitDice,"").Replace("Hit Points", "").Trim());
                        i++;

                        //Speed
                        _npc.NPCSpeed = _npcListDetails[i].Replace("Speed","").Trim();
                        i++;

                        // Stats Example: STR DEX CON INT WIS CHA 10 (-0) 10 (-0) 10 (-0) 10 (-0) 10 (-0) 10 (-0)

                        // Number string 10 (-0) 10 (-0) 10 (-0) 10 (-0) 10 (-0) 10 (-0)
                        string _statNumbers = _npcListDetails[i].Split(new string[] { "CHA" }, StringSplitOptions.None)[1].Trim();
                        // Remove Brackets 10 -0 10 -0 10 -0 10 -0 10 -0 10 -0
                        _statNumbers = _statNumbers.Replace("(","").Replace(")","").Trim();

                        _npc.NPCStrength = Convert.ToInt32(_statNumbers.Split(' ')[0].Trim());
                        _npc.NPCStrengthModifier = _statNumbers.Split(' ')[1].Trim();

                        _npc.NPCDexterity = Convert.ToInt32(_statNumbers.Split(' ')[2].Trim());
                        _npc.NPCDexterityModifier = _statNumbers.Split(' ')[3].Trim();

                        _npc.NPCConstitution = Convert.ToInt32(_statNumbers.Split(' ')[4].Trim());
                        _npc.NPCConstitutionModifier = _statNumbers.Split(' ')[5].Trim();

                        _npc.NPCIntelligence = Convert.ToInt32(_statNumbers.Split(' ')[6].Trim());
                        _npc.NPCIntelligenceModifier = _statNumbers.Split(' ')[7].Trim();

                        _npc.NPCWisdom = Convert.ToInt32(_statNumbers.Split(' ')[8].Trim());
                        _npc.NPCWisdomModifier = _statNumbers.Split(' ')[9].Trim();

                        _npc.NPCCharisma = Convert.ToInt32(_statNumbers.Split(' ')[10].Trim());
                        _npc.NPCCharismaModifier = _statNumbers.Split(' ')[11].Trim();

                        i++;

                        // Saving thorws
                        if (_npcListDetails[i].Contains("Saving Throws"))
                        {
                            _npc.NPCSavingThrows = _npcListDetails[i].Replace("Saving Throws","").Trim();
                            i++;
                        }

                        // Skills
                        if (_npcListDetails[i].Contains("Skills"))
                        {
                            _npc.NPCSkills = _npcListDetails[i].Replace("Skills", "").Trim();
                            i++;
                        }

                        // Dmg Vul
                        if (_npcListDetails[i].Contains("Damage Vulnerabilities"))
                        {
                            _npc.NPCDmgVul = _npcListDetails[i].Replace("Damage Vulnerabilities", "").Trim();
                            i++;
                        }

                        // Dmg Vul
                        if (_npcListDetails[i].Contains("Damage Resistances"))
                        {
                            _npc.NPCDmgRes = _npcListDetails[i].Replace("Damage Resistances", "").Trim();
                            i++;
                        }

                        // Dmg Imm
                        if (_npcListDetails[i].Contains("Damage Immunities"))
                        {
                            _npc.NPCDmgImm = _npcListDetails[i].Replace("Damage Immunities", "").Trim();
                            i++;
                        }

                        // Dmg Imm
                        if (_npcListDetails[i].Contains("Condition Immunities"))
                        {
                            _npc.NPCCondImm = _npcListDetails[i].Replace("Condition Immunities", "").Trim();
                            i++;
                        }

                        // Senses
                        _npc.NPCSenses = _npcListDetails[i].Replace("Senses", "").Trim();
                        i++;

                        // Languages
                        _npc.NPCLanguages = _npcListDetails[i].Replace("Languages", "").Trim();
                        i++;

                        // XP
                        _npc.NPCXp = Convert.ToInt32(_npcListDetails[i].Split('(')[1].Replace(")","").Replace("XP","").Replace(",","").Trim());
                        // CR
                        _npc.NPCCr = _npcListDetails[i].Replace("Challenge", "").Split('(')[0].Trim();
                        i++;

                        // Abilities
                        while (!_npcListDetails[i].Contains("ACTIONS") && !_npcListDetails[i].Contains("REACTIONS") && !_npcListDetails[i].Contains("LEGENDARY ACTIONS") && !_npcListDetails[i].Contains("LAIR ACTIONS"))
                        {
                            _npc.NPCAbilities.Add(_npcListDetails[i]);
                            i++;
                        }

                        while (!_npcListDetails[i].Contains("REACTIONS") && !_npcListDetails[i].Contains("LEGENDARY ACTIONS") && !_npcListDetails[i].Contains("LAIR ACTIONS") && !string.IsNullOrEmpty(_npcListDetails[i]))
                        {
                            // Skip the header
                            if (_npcListDetails[i].Contains("ACTIONS"))
                            {
                                if (i + 1 != _npcListDetails.Count)
                                {
                                    i++;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(_npcListDetails[i]))
                                {
                                    _npc.NPCActions.Add(_npcListDetails[i]);
                                    if (i + 1 != _npcListDetails.Count)
                                    {
                                        i++;
                                    }
                                }
                            }
                        }

                        while (!_npcListDetails[i].Contains("LEGENDARY ACTIONS") && !_npcListDetails[i].Contains("LAIR ACTIONS") && !string.IsNullOrEmpty(_npcListDetails[i]))
                        {
                            // Skip the header
                            if (_npcListDetails[i].Contains("REACTIONS"))
                            {
                                if (i + 1 != _npcListDetails.Count)
                                {
                                    i++;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(_npcListDetails[i]))
                                {
                                    _npc.NPCReactions.Add(_npcListDetails[i]);
                                    if (i + 1 != _npcListDetails.Count)
                                    {
                                        i++;
                                    }
                                }
                            }
                        }

                        while (!_npcListDetails[i].Contains("LAIR ACTIONS") && !string.IsNullOrEmpty(_npcListDetails[i]))
                        {
                            // Skip the header
                            if (_npcListDetails[i].Contains("LEGENDARY ACTIONS"))
                            {
                                if (i + 1 != _npcListDetails.Count)
                                {
                                    i++;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(_npcListDetails[i]))
                                {
                                    _npc.NPCLegendActions.Add(_npcListDetails[i]);
                                    if (i + 1 != _npcListDetails.Count)
                                    {
                                        i++;
                                    }
                                }
                            }
                        }

                        while (!_npcListDetails[i].Contains("##;") && !string.IsNullOrEmpty(_npcListDetails[i]))
                        {
                            // Skip the header
                            if (_npcListDetails[i].Contains("LAIR ACTIONS"))
                            {
                                if (i + 1 != _npcListDetails.Count)
                                {
                                    i++;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(_npcListDetails[i]))
                                {
                                    //_npc.NPCLegendActions.Add(_npcListDetails[i]);
                                    if (i + 1 != _npcListDetails.Count)
                                    {
                                        i++;
                                    }
                                }
                            }
                        }

                        while (i != _npcListDetails.Count && !string.IsNullOrEmpty(_npcListDetails[i]))
                        {
                            if (!string.IsNullOrEmpty(_npcListDetails[i]))
                            {
                                _npc.NPCDetails.Add(_npcListDetails[i]);
                                if (i + 1 != _npcListDetails.Count)
                                {
                                    i++;
                                }
                            }
                        }

                        if (string.IsNullOrEmpty(_npcListDetails[i]))
                        {
                            // Add to list
                            NPCList.Add(_npc);
                            _npc = new Personalities();
                        }
                    }

                    #endregion
                }
                return NPCList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

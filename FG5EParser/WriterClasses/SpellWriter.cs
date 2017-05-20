using FG5EParser.Utilities;
using FG5eParserModels.Player_Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FG5EParser.WriterClasses
{
    class SpellWriter
    {
        public List<Spells> compileSpellList(string _inputLocation, string moduleName)
        {
            try
            {
                XMLFormatting _xmlFormatting = new XMLFormatting();

                // Read lines from file
                var _lines = File.ReadLines(_inputLocation);

                // Local Inits
                List<string> _basic = new List<string>();

                List<Spells> Spells = new List<Spells>();
                Spells _spell = new Spells();

                List<string> SpellList = new List<string>();
                List<string> SpellDetails = new List<string>();

                bool flg = false;

                // Seperate Spells from the spell lists
                foreach (var line in _lines)
                {
                    if (line == "##;") flg = true;

                    if (!flg)
                    {
                        SpellList.Add(line);
                    }
                    else
                    {
                        SpellDetails.Add(line);
                    }
                }

                // Create the Spell List                
                for (int i = 0; i < SpellDetails.Count; i++)
                {
                    if (SpellDetails[i] == "##;")
                    {
                        i++;
                    }

                    // Spell Name
                    _spell._Name = SpellDetails[i];
                    i++;

                    // School and Level
                    if (SpellDetails[i].Contains("cantrip"))
                    {
                        _spell._School = SpellDetails[i].Split(' ')[0];
                        _spell._Level = returnLevel(SpellDetails[i].Split(' ')[1].Trim());
                        i++;
                    }
                    else
                    {
                        _spell._School = SpellDetails[i].Split(' ')[1];
                        _spell._Level = returnLevel(SpellDetails[i].Split(' ')[0].Trim());
                        i++;
                    }

                    // Casting Time
                    _spell._CastingTime = SpellDetails[i].Replace("Casting Time:", "").Trim();
                    i++;

                    // Range
                    _spell._Range = SpellDetails[i].Replace("Range:", "").Trim();
                    i++;

                    // Components
                    _spell._IsVerbal = SpellDetails[i].Contains("V") ? "true" : "false";
                    _spell._IsSomatic = SpellDetails[i].Contains("S") ? "true" : "false";
                    _spell._Material = SpellDetails[i].Contains("M") ? SpellDetails[i].Split('M')[1].Trim() : string.Empty;
                    _spell._Components = SpellDetails[i].Replace("Components:","").Trim();
                    i++;

                    // Duration
                    _spell._Duration = SpellDetails[i].Replace("Duration:", "").Trim();
                    i++;

                    while (i != SpellDetails.Count && !string.IsNullOrEmpty(SpellDetails[i]))
                    {
                        _spell._Description = string.IsNullOrEmpty(_spell._Description) ? _spell._Description + _xmlFormatting.returnFormattedString(SpellDetails[i],moduleName) : _spell._Description + Environment.NewLine + _xmlFormatting.returnFormattedString(SpellDetails[i], moduleName);
                        i++;                      
                    }

                    Spells.Add(_spell);
                    _spell = new Spells();
                }

                // Adding in Sources

                string ListTitle = string.Empty;

                for (int i = 0; i < SpellList.Count; i++)
                {
                    if (SpellList[i] == "#@;")
                    {
                        i++;
                    }

                    // Select the spell title
                    ListTitle = SpellList[i];
                    i++;

                    while (i != SpellDetails.Count && !string.IsNullOrEmpty(SpellList[i]))
                    {
                        var spell = Spells.Where(x => x._Name == SpellList[i]).FirstOrDefault();
                        if (spell != null)
                        {
                            spell._Source = string.IsNullOrEmpty(spell._Source) ? ListTitle : spell._Source + ", " + ListTitle;
                        }
                        i++;
                    }

                }

                return Spells.OrderBy(x => x._Name).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string returnLevel(string _obj)
        {
            if (_obj.ToLower() == "cantrip") return "0";

            return _obj.Substring(0,1);
        }

    }
}

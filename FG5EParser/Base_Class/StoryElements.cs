using FG5EParser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.Base_Class
{
    class StoryElements
    {
        public int StoryIndex { get; set; } // Keep track of what needs to be linked where later
        public string StoryHeader { get; set; } // Specify what main tab all entries should fall under
        public string StoryTitle { get; set; }
        public string StoryDescription { get; set; } // Needs formatting options
        public string isLocked { get { return "1"; } set { isLocked = value; } }

        public StoryElements bindValues(List<string> _Basic, string Header, string _moduleName)
        {
            StoryElements _storyElement = new StoryElements();
            StringBuilder xml = new StringBuilder();
            StringBuilder _description = new StringBuilder();
            XMLFormatting _xmlFormatting = new XMLFormatting();

            // Variable that will be used in order to process fields that are not mandatory
            string line = _Basic.First();

            while (line != "Its done!")
            {
                if (line.Contains("#@;"))
                {
                    line = shiftUp(_Basic);
                }

                if (line.Contains("##;"))
                {
                    // Adding the page Name
                    _storyElement.StoryTitle = line.Replace("##;","").Trim();
                    line = shiftUp(_Basic);
                }

                if (line != "Its done!")
                {
                    _description.Append(_xmlFormatting.returnFormattedString(line,_moduleName));
                    line = shiftUp(_Basic);
                }

                // Add in the description details
                _storyElement.StoryDescription = _description.ToString();
            }

            if (!string.IsNullOrEmpty(Header))
            {
                _storyElement.StoryHeader = Header;
            }

            return _storyElement;
        }

        // Makes reading the list variable consistant
        private string shiftUp(List<string> _Basic)
        {
            _Basic.RemoveAt(0);
            if (_Basic.Count != 0)
            {
                return _Basic.First();
            }
            else
            {
                _Basic.Add("Its done!");
                return _Basic.First();
            }
        }
    }

    class Items
    {
        #region PROPERTIES
        // Mandatory
        public string Name { get; set; }
        public string isLocked { get { return "1"; } set { isLocked = value; } }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string Cost { get; set; }
        public string Weight { get; set; }

        // Armor Related
        public string AC { get; set; }
        public string DexBonus { get; set; }
        public string StrRequired { get; set; }
        public string StealthDisadvantage { get; set; }

        // Weapon Related
        public string Damage { get; set; }
        public string Properties { get; set; }

        // Mounts and Locomotives
        public string Speed { get; set; }
        public string CarryingCapacity { get; set; }

        // Magic Item Related
        public string ACBonus { get; set; }
        public string isIdentified { get; set; }
        public string Rarity { get; set; }
        public string UnidentifiedBaseType { get; set; }
        public string UnidentifiedDescription { get; set; }

        // Misc
        public string Description { get; set; } // Needs formatting options
        public int ItemIndex { get; set; } // Keep track of what needs to be linked where later
        private List<Subitems> _itemList = new List<Subitems>();
        public List<Subitems> Subitems { get { return _itemList; } set { _itemList = value; } }        
        public string isTemplate { get { return "0"; } set { isTemplate = value; } }
        
        #endregion

        public List<Items> bindValues(List<string> _Basic, string itemHeader, string _moduleName)
        {
            Items _item = new Items();
            List<Items> _itemList = new List<Items>();

            StringBuilder xml = new StringBuilder();
            XMLFormatting _xmlFormatting = new XMLFormatting();

            List<string> tableFields = new List<string>();

            // Variable that will be used in order to process fields that are not mandatory
            string line = _Basic.First();

            while (line != "Its done!" && !line.Contains("##;"))
            {
                // Clear heading line
                if (line.Contains("#@;"))
                {
                    line = shiftUp(_Basic);
                }

                // Obtain the possible fields
                if (line.Contains("#th;"))
                {
                    tableFields = line.Split(';').ToList();
                    tableFields.RemoveAt(0);
                    line = shiftUp(_Basic);
                }

                string subTypeName = string.Empty;

                // Obtain the subtype
                if (line.Contains("#st;"))
                {
                    subTypeName = line.Split(';')[1].Trim();
                    line = shiftUp(_Basic);
                }

                while (line != "Its done!" && !line.Contains("#st;") && !line.Contains("##;"))
                {
                    // Break up the line
                    List<string> _itemDetails = line.Split(';').ToList();

                    for (int i = 0; i < tableFields.Count; i++)
                    {
                        if (tableFields[i].Trim() == "Item" || tableFields[i].Trim() == "Armor" || tableFields[i].Trim() == "Name")
                        {
                            _item.Name = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Cost")
                        {
                            _item.Cost = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Speed")
                        {
                            _item.Speed = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Carrying Capacity")
                        {
                            _item.CarryingCapacity = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Damage")
                        {
                            _item.Damage = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Weight")
                        {
                            _item.Weight = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Properties")
                        {
                            _item.Properties = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Armor Class (AC)")
                        {
                            // Check for AC value
                            if (_itemDetails[i].Contains("+"))
                            {
                                _item.AC = _itemDetails[i].Split('+')[0].Trim();

                                if (_itemDetails[i].Split('+')[1].Trim() == "Dex modifier")
                                {
                                    _item.DexBonus = "Yes";
                                }
                                else if (_itemDetails[i].Split('+')[1].Trim() == "Dex modifier (max 2)")
                                {
                                    _item.DexBonus = "Yes (max 2)";
                                }
                                else if (_itemDetails[i].Split('+')[1].Trim() == "Dex modifier (max 3)")
                                {
                                    _item.DexBonus = "Yes (max 3)";
                                }
                                else
                                    _item.DexBonus = "-";
                            }
                            else // For shields
                            {
                                _item.AC = _itemDetails[i].Trim();
                                _item.DexBonus = "-";
                            }
                        }
                        if (tableFields[i].Trim() == "Strength")
                        {
                            _item.StrRequired = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Stealth")
                        {
                            _item.StealthDisadvantage = _itemDetails[i].Trim();
                        }
                    }

                    // Assign constants
                    _item.Type = itemHeader;
                    _item.Subtype = subTypeName;

                    // Add the item to the list
                    _itemList.Add(_item);
                    _item = new Items();

                    // Shift to next item
                    line = shiftUp(_Basic);
                }
            }

            return _itemList;
        }

        public List<Items> bindMagicalValues(List<string> _Basic, string itemHeader, string _moduleName)
        {
            Items _item = new Items();
            List<Items> _itemList = new List<Items>();

            StringBuilder xml = new StringBuilder();
            XMLFormatting _xmlFormatting = new XMLFormatting();

            List<string> tableFields = new List<string>();

            // Variable that will be used in order to process fields that are not mandatory
            string line = _Basic.First();

            while (line != "Its done!" && !line.Contains("##;"))
            {
                // Clear heading line
                if (line.Contains("#@;"))
                {
                    line = shiftUp(_Basic);
                }

                // Obtain the possible fields
                if (line.Contains("#th;"))
                {
                    tableFields = line.Split(';').ToList();
                    tableFields.RemoveAt(0);
                    line = shiftUp(_Basic);
                }

                string type = string.Empty;

                // Obtain the subtype
                if (line.Contains("#st;"))
                {
                    type = line.Split(';')[1].Trim();
                    line = shiftUp(_Basic);
                }

                while (line != "Its done!" && !line.Contains("#st;") && !line.Contains("##;"))
                {
                    // Break up the line
                    List<string> _itemDetails = line.Split(';').ToList();

                    for (int i = 0; i < tableFields.Count; i++)
                    {
                        if (tableFields[i].Trim() == "Item" && i < _itemDetails.Count)
                        {
                            _item.Name = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Rarity" && i < _itemDetails.Count)
                        {
                            _item.Rarity = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Cost" && i < _itemDetails.Count)
                        {
                            _item.Cost = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Weight" && i < _itemDetails.Count)
                        {
                            _item.Weight = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "AC" && i < _itemDetails.Count)
                        {
                            _item.AC = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "AC Bonus" && i < _itemDetails.Count)
                        {
                            _item.ACBonus = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Dex Bonus" && i < _itemDetails.Count)
                        {
                            _item.DexBonus = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Stealth" && i < _itemDetails.Count) 
                        {
                            _item.StealthDisadvantage = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Strength" && i < _itemDetails.Count)
                        {
                            _item.StrRequired = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Subtype" && i < _itemDetails.Count)
                        {
                            _item.Subtype = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Damage" && i < _itemDetails.Count)
                        {
                            _item.Damage = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Properties" && i < _itemDetails.Count)
                        {
                            _item.Properties = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Identified" && i < _itemDetails.Count)
                        {
                            if (_itemDetails[i].ToLower().Trim() == "no")
                            {
                                _item.UnidentifiedBaseType = "0";
                            }
                            else
                                _item.UnidentifiedBaseType = "1";
                        }
                        if (tableFields[i].Trim() == "Unidentified Type" && i < _itemDetails.Count)
                        {
                            _item.UnidentifiedBaseType = _itemDetails[i].Trim();
                        }
                        if (tableFields[i].Trim() == "Unidentified Description" && i < _itemDetails.Count)
                        {
                            _item.UnidentifiedDescription = _itemDetails[i].Trim();
                        }
                    }

                    // Assign constants
                    _item.Type = type;
                    //_item.Subtype = subTypeName;

                    // Add the item to the list
                    _itemList.Add(_item);
                    _item = new Items();

                    // Shift to next item
                    line = shiftUp(_Basic);
                }
            }

            return _itemList;
        }

        // Makes reading the list variable consistant
        private string shiftUp(List<string> _Basic)
        {
            _Basic.RemoveAt(0);
            if (_Basic.Count != 0)
            {
                return _Basic.First();
            }
            else
            {
                _Basic.Add("Its done!");
                return _Basic.First();
            }
        }
    }

    class Subitems
    {
        public string ItemName { get; set; }
        public string Count { get; set; }
    }

    class Parcles
    {
        public List<Coins> coinsList { get; set; }
        public List<Items> itemList { get; set; }
    }

    class Coins
    {
        public int CoinIndex { get; set; }
        public string CoinName { get; set; }
        public string CoinValue { get; set; }
    }

    class Encounters
    {
        #region PROPERTIES
        public string Category { get; set; }
        public string CR { get; set; }
        public string Exp { get; set; }
        public string isLocked { get { return "1"; } set { isLocked = value; } }
        public string Name { get; set; }
        private List<EncounterNPC> _npcList = new List<EncounterNPC>();
        public List<EncounterNPC> NPCList { get { return _npcList; } set { _npcList = value; } }
        #endregion

        public List<Encounters> bindValues(List<string> _Basic, string EncounterHeader, string _moduleName)
        {
            Encounters _encounter = new Encounters();
            List<Encounters> _encounterList = new List<Encounters>();
            // Init the NPC list
            List<EncounterNPC> _listNPC = new List<EncounterNPC>();

            StringBuilder xml = new StringBuilder();
            XMLFormatting _xmlFormatting = new XMLFormatting();

            // Variable that will be used in order to process fields that are not mandatory
            string line = _Basic.First();

            while (line != "Its done!")
            {
                // Clear heading line
                if (line.Contains("#@;"))
                {
                    line = shiftUp(_Basic);
                }

                // Get the Encounter Name
                if (line.Contains("##;"))
                {
                    _encounter = new Encounters();
                    _encounter.Name = line.Replace("##;","");
                    line = shiftUp(_Basic);
                    _listNPC = new List<EncounterNPC>();                    
                }

                while (line != "Its done!" && !line.Contains("##;"))
                {
                    // Get the CR and EXP rating of the encounter
                    if (line.Contains("XP"))
                    {
                        line = line.Replace("CR", ";").Replace("XP",";").Trim();
                        _encounter.CR = line.Split(';')[1];
                        _encounter.Exp = line.Split(';')[2];
                        line = shiftUp(_Basic);
                    }

                    // Get the NPC's in this encounter
                    while (line != "Its done!" && !line.Contains("##;"))
                    {
                        EncounterNPC _npc = new EncounterNPC();
                        if (line.Contains(";"))
                        {
                            _npc.Count = line.Split(';')[0].Trim();
                            _npc.Name = line.Split(';')[1].Trim();

                            // Add to the list
                            _listNPC.Add(_npc);

                            line = shiftUp(_Basic);
                        }                        
                    }

                    // Add the NPC list
                    _encounter.NPCList = _listNPC;
                }
                // Add the category
                _encounter.Category = EncounterHeader;
                // Add Encounter to main list
                _encounterList.Add(_encounter);
            }

            return _encounterList;
        }

        // Makes reading the list variable consistant
        private string shiftUp(List<string> _Basic)
        {
            _Basic.RemoveAt(0);
            if (_Basic.Count != 0)
            {
                return _Basic.First();
            }
            else
            {
                _Basic.Add("Its done!");
                return _Basic.First();
            }
        }
    }

    class EncounterNPC
    {
        public string Count { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}

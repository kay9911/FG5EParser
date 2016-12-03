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

        // Misc
        public string Description { get; set; } // Needs formatting options
        public int ItemIndex { get; set; } // Keep track of what needs to be linked where later
        private List<Subitems> _itemList = new List<Base_Class.Subitems>();
        public List<Subitems> Subitems { get { return _itemList; } set { _itemList = value; } }
        public bool isIdentified { get; set; }
        public bool isTemplate { get; set; }
        public string Rarity { get; set; }
        #endregion

        public List<Items> bindValues(List<string> _Basic, string itemHeader, string _moduleName)
        {
            Items _item = new Items();
            List<Items> _itemList = new List<Items>();

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

                List<string> tableFields = new List<string>();
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
                    subTypeName = line.Split(';')[1];
                    line = shiftUp(_Basic);
                }

                while (line != "Its done!" && !line.Contains("#st;"))
                {
                    // Break up the line
                    List<string> _itemDetails = line.Split(';').ToList();

                    for (int i = 0; i < tableFields.Count; i++)
                    {
                        if (tableFields[i] == "Item")
                        {
                            _item.Name = _itemDetails[i];
                        }
                        if (tableFields[i] == "Cost")
                        {
                            _item.Cost = _itemDetails[i];
                        }
                        if (tableFields[i] == "Weight")
                        {
                            _item.Weight = _itemDetails[i];
                        }
                    }

                    // Assign constants
                    _item.Type = itemHeader;
                    _item.Subtype = subTypeName;

                    // Add the item to the list
                    _itemList.Add(_item);

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
}

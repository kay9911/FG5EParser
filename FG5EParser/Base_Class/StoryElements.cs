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
        public int ItemIndex { get; set; } // Keep track of what needs to be linked where later
        public string AC { get; set; }
        public string Bonus { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; } // Needs formatting options
        public bool isIdentified { get; set; }
        public bool isTemplate { get; set; }
        public bool isLocked { get { return true; } set { isLocked = value; } }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Subtype { get; set; }
        public string Weight { get; set; }
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

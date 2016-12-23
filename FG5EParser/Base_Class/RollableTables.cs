using FG5EParser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.Base_Class
{
    class RollableTables
    {
        public string Category { get; set; }
        public string isLocked { get { return "1"; } set { isLocked = value; } }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string HideResults { get { return "0"; } set { isLocked = value; } }
        public string Mod { get { return "0"; } set { isLocked = value; } }
        public string Dice { get; set; }
        private List<string> _columnList = new List<string>();
        public List<string> ColumnLabel { get { return _columnList; } set { _columnList = value; } }
        private List<TableRows> _columnResultList = new List<TableRows>();
        public List<TableRows> ColumnResults { get { return _columnResultList; } set { _columnResultList = value; } }

        public List<RollableTables> bindValues(List<string> _Basic, string TableHeader, string _moduleName)
        {
            RollableTables _tables = new RollableTables();
            List<RollableTables> _tableList = new List<RollableTables>();
            // Init all the lists
            List<TableRows> _tableRows = new List<TableRows>();

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
                    _tables = new RollableTables();
                    _tables.Name = line.Replace("##;", "");
                    line = shiftUp(_Basic);
                    _tableRows = new List<TableRows>();
                }

                while (line != "Its done!" && !line.Contains("##;"))
                {
                    // Check for description
                    if (line.Contains("#!"))
                    {
                        StringBuilder _desc = new StringBuilder();

                        // Gather all the lines for the description
                        while (!line.Contains("dice"))
                        {
                            _desc.Append(line.Replace("#!;","").Trim());
                            line = shiftUp(_Basic);
                        }
                        // Append the description to the object
                        _tables.Description = _desc.ToString();
                    }

                    // Check for dice
                    if (line.Contains("dice"))
                    {
                        _tables.Dice = line.Split(';')[1].Trim();
                        line = shiftUp(_Basic);
                    }

                    // Check for column names
                    if (line.Contains("column"))
                    {
                        _tables.ColumnLabel = line.Replace("column;", "").Split(';').ToList();
                        line = shiftUp(_Basic);
                    }

                    // Get the individual table rows now
                    while (line != "Its done!" && !line.Contains("##;"))
                    {
                        TableRows _tableRow = new TableRows();
                        if (line.Contains("row"))
                        {
                            // Remove row
                            line = line.Replace("row;", "");
                            _tableRow.FromRange = line.Split(';')[0].Trim();
                            _tableRow.ToRange = line.Split(';')[1].Trim();

                            // Modify for description so as to get all rows
                            StringBuilder _rowResult = new StringBuilder();
                            for (int i = 2; i < line.Split(';').Count(); i++)
                            {
                                _rowResult.Append(string.Format("{0};", line.Split(';')[i]));
                            }
                            _tableRow.Result = _rowResult.ToString();
                        }

                        // Add to the list
                        _tableRows.Add(_tableRow);
                        line = shiftUp(_Basic);
                    }

                    // Add the NPC list
                    _tables.ColumnResults = _tableRows;
                }
                // Add the category
                _tables.Category = TableHeader;
                // Add Encounter to main list
                _tableList.Add(_tables);
            }

            return _tableList;
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

    class TableRows
    {
        public string FromRange { get; set; }
        public string ToRange { get; set; }
        public string Result { get; set; }
    }
}

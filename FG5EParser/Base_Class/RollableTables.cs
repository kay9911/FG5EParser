using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.Base_Class
{
    class RollableTables
    {
        public string Description { get; set; }
        public string Dice { get; set; }
        public bool hideRollResults { get; set; }
        public string ColumnNames { get; set; }
        public bool isLocked { get; set; }
        public string Mod { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string ResultCols { get; set; }
        public bool tableOffset { get; set; }
        public List<TableRows> tableRows { get; set; }
    }

    class TableRows
    {
        public string FromRange { get; set; }
        public string ToRange { get; set; }
    }
}

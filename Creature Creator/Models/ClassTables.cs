using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creature_Creator.Models
{
    class ClassTables
    {
        private List<TableSections> _sections = new List<TableSections>();
        public List<TableSections> sections { get { return _sections; } set { _sections = value; } }
    }
}

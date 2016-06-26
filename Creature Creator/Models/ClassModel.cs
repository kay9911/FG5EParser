using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creature_Creator.Models
{
    class ClassModel
    {
        public string className { get; set; }
        private List<ClassTables> _classTables = new List<ClassTables>();
        public List<ClassTables> classTables { get { return _classTables; } set { _classTables = value; } }
        public ClassFeatures classFeatures { get; set; }
        public ClassSkills classskills { get; set; }
        public ClassArchTypes archtypes { get; set; }
    }
}

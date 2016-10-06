using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creature_Creator.Models
{
    class ClassEquipment
    {
        public string description { get; set; }
        List<string> _equipment = new List<string>();
        public List<string> equipment { get { return _equipment; } set { _equipment = value; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creature_Creator.Models
{
    class ClassFeatures
    {
        public string description { get; set; }
        public ClassHitPoints hitpoints { get; set; }
        public ClassProficiencies proficiencies { get; set; }
        public ClassEquipment equipment { get; set; }
    }
}

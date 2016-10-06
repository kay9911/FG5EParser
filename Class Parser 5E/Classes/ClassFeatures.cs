using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Parser_5E.Classes
{
    class ClassFeatures
    {
        // This class holds all of the mandatory class features

        /* HIT POINTS */

        public string HitDice { get; set; }
        public string HitPointsAtFirstLevel { get; set; }
        public string HitPointsBeyondFirstLevel { get; set; }

        /* PROFICIENCIES */

        public string Armour { get; set; }
        public string Weapons { get; set; }
        public string Tools { get; set; }
        public string SavingThrows { get; set; }
        public string Skills { get; set; }

        /* EQUIPMENT */

        private List<string> Equipment = new List<string>();
        public List<string> EquipmentList { get { return Equipment; } set { Equipment = value; } }
    }
}

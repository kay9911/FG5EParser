using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Parser_5E.Classes
{
    class Ability
    {
        public string Levels { get; set; }
        public string AbilityName { get; set; }
        public string AbilityDescription { get; set; }

        /* ARCHTYPE HANDLING */

        public bool IsArchTypeHeading { get; set; }
        public bool ArchtypeFlag { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Parser_5E.Classes
{
    class Ability
    {
        public string Levels { get; set; } // Skill available at these levels
        public string AbilityName { get; set; } 
        public string AbilityDescription { get; set; } 

        /* ARCHTYPE HANDLING */

        public bool IsArchTypeHeading { get; set; } // THE ARCHTYPE FEATURE SKILL (JUST ONE CAN EXIST)
        public bool IsArchtype { get; set; } // INDICATES THIS IS A ABILITY FEATURE AND NOT THE SKIL

        public bool ArchtypeFeatureFlag { get; set; } // INDICATES THAT THE SKILL IS PART OF AN ARCHTYPE        L
        public string ArchtypeName { get; set; } // INDICATES WHAT ARCHTYPE THIS SKILL COMES UNDER
    }
}

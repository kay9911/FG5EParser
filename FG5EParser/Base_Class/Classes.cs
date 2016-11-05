using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.Base_Class
{
    class Classes
    {
        public string className { get; set; }
        public string classDescriptions { get; set; }

        public string hitDice { get; set; }
        public string hitPointsAtFirstLevel { get; set; }
        public string hitPointsAfterFirstLevel { get; set; }

        public string armour { get; set; }
        public string weapons { get; set; }
        public string tools { get; set; }
        public string savingThrows { get; set; }
        public string skills { get; set; }

        #region FEATURES AND ABILITIES

        private List<ClassFeatures> _featureList = new List<ClassFeatures>();
        public List<ClassFeatures> classFeatures {
            get { return _featureList; }
            set { _featureList = value; }
        }

        private List<ClassAbilities> _abilityList = new List<ClassAbilities>();
        public List<ClassAbilities> classAbilities {
            get { return _abilityList; }
            set { _abilityList = value; }
        }

        public string equipment { get; set; }

        #endregion
    }

    class ClassFeatures
    {
        public string FeatureName { get; set; }
        public string FeatureLevels { get; set; }
        public string FeatureDescription { get; set; }
        public bool isArchtypeHeader { get; set; } // True : If feature is defined as the archtype, False : If not
        public string UnderArchtype { get; set; } // What archtype does this feature belong too
    }

    class ClassAbilities
    {
        public string AbilityName { get; set; }
        public string AbilityLevels { get; set; }
        public string AbilityDescription { get; set; }
    }
}

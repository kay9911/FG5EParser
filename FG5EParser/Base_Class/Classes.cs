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

        public Classes bindValues(List<string> _Basic)
        {
            Classes _new = new Classes();

            

            StringBuilder _descriptions = new StringBuilder();
            StringBuilder _equipment = new StringBuilder();

            // Variable that will be used in order to process fields that are not mandatory
            string line = _Basic.First();

            // ##; --> Indication that its a new class

            while (line != "Its done!")
            {
                if (line.Contains("##;"))
                {
                    _new.className = line.Split(';')[1].Trim();
                    line = shiftUp(_Basic);
                }

                while (line != "Hit Points")
                {
                    _descriptions.Append(line);
                    line = shiftUp(_Basic);
                }

                #region HIT POINTS SECTION

                line = shiftUp(_Basic); // Remove the hit points line

                _new.hitDice = line.Split(':')[1].Trim();
                line = shiftUp(_Basic);

                _new.hitPointsAtFirstLevel = line.Split(':')[1].Trim();
                line = shiftUp(_Basic);

                _new.hitPointsAfterFirstLevel = line.Split(':')[1].Trim();
                line = shiftUp(_Basic);

                #endregion

                #region Proficiencies

                line = shiftUp(_Basic); // Remove the proficiencies line

                _new.armour = line.Split(':')[1].Trim();
                line = shiftUp(_Basic);

                _new.weapons = line.Split(':')[1].Trim();
                line = shiftUp(_Basic);

                _new.tools = line.Split(':')[1].Trim();
                line = shiftUp(_Basic);

                _new.savingThrows = line.Split(':')[1].Trim();
                line = shiftUp(_Basic);

                _new.skills = line.Split(':')[1].Trim();
                line = shiftUp(_Basic);

                #endregion

                if (line == "Equipment")
                {
                    line = shiftUp(_Basic);
                }

                while (!line.Contains("#fe;"))
                {
                    _equipment.Append(line);
                    line = shiftUp(_Basic);
                }

                StringBuilder featureDescription = new StringBuilder();
                ClassFeatures _feature = new ClassFeatures();

                while (!line.Contains("#abh;"))
                {
                    if (line.Contains("#fe;"))
                    {  
                        if (!string.IsNullOrEmpty(_feature.FeatureName))
                        {
                            _feature.FeatureDescription = featureDescription.ToString();
                            _new.classFeatures.Add(_feature);
                            _feature = new ClassFeatures(); // reset
                            featureDescription = new StringBuilder();
                        }
                        _feature.FeatureName = line.Split(';')[1].Trim();
                        _feature.FeatureLevels = line.Split(';')[2].Trim();
                        line = shiftUp(_Basic);
                    }
                    else
                    {
                        featureDescription.Append(line);
                        line = shiftUp(_Basic);
                    }
                }
                // Catch the last entry
                if (!string.IsNullOrEmpty(_feature.FeatureName))
                {
                    _feature.FeatureDescription = featureDescription.ToString();
                    _new.classFeatures.Add(_feature);
                    _feature = new ClassFeatures(); // reset
                    featureDescription = new StringBuilder();
                }

                while (!line.Contains("#ab;"))
                {
                    line = shiftUp(_Basic);
                }

                StringBuilder abilitiecsDescription = new StringBuilder();
                ClassAbilities _abilities = new ClassAbilities();

                while (line != "Its done!")
                {
                    if(line.Contains("#ab;"))
                    {
                        if (!string.IsNullOrEmpty(_abilities.AbilityName))
                        {
                            _abilities.AbilityDescription = abilitiecsDescription.ToString();
                            _new.classAbilities.Add(_abilities);
                            _abilities = new ClassAbilities();
                        }

                        _abilities.AbilityName = line.Split(';')[1].Trim();
                        line = shiftUp(_Basic);
                    }

                    while (!line.Contains("#abf;"))
                    {
                        abilitiecsDescription.Append(line);
                        line = shiftUp(_Basic);
                    }

                    if (line.Contains("#abf;"))
                    {
                        if (!string.IsNullOrEmpty(_feature.FeatureName))
                        {
                            _feature.FeatureDescription = featureDescription.ToString();
                            _new.classFeatures.Add(_feature);
                            _feature = new ClassFeatures(); // reset
                            featureDescription = new StringBuilder();
                        }
                        _feature.FeatureName = line.Split(';')[1].Trim();
                        _feature.FeatureLevels = line.Split(';')[2].Trim();
                        line = shiftUp(_Basic);

                        while (!line.Contains("#abf;") && !line.Contains("#ab;") && !line.Contains("Its done!"))
                        {
                            featureDescription.Append(line);
                            line = shiftUp(_Basic);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(_feature.FeatureName))
                {
                    _feature.FeatureDescription = featureDescription.ToString();
                    _new.classFeatures.Add(_feature);
                    _feature = new ClassFeatures(); // reset
                    featureDescription = new StringBuilder();
                }

                if (!string.IsNullOrEmpty(_abilities.AbilityName))
                {
                    _abilities.AbilityDescription = abilitiecsDescription.ToString();
                    _new.classAbilities.Add(_abilities);
                    _abilities = new ClassAbilities();
                }
            }

            return _new;
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

    #region SUBCLASSES
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
        public string AbilityDescription { get; set; }
        private List<string> _list = new List<string>();
        public List<string> AbilityList {
            get { return _list; }
            set { _list = value; }
        }
    }
    #endregion
}

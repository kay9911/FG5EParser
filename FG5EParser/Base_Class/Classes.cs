using FG5EParser.Utilities;
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

        public string FeatureArchtypeName { get; set; } // What the archtype section is called

        private List<ClassAbilities> _abilityList = new List<ClassAbilities>();
        public List<ClassAbilities> classAbilities {
            get { return _abilityList; }
            set { _abilityList = value; }
        }

        public string equipment { get; set; }

        #endregion

        public Classes bindValues(List<string> _Basic, string _moduleName = "")
        {
            Classes _new = new Classes();
            XMLFormatting _xmlFormatting = new XMLFormatting();           

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
                    _descriptions.Append(_xmlFormatting.returnFormattedString(line,_moduleName));
                    line = shiftUp(_Basic);
                }

                _new.classDescriptions = _descriptions.ToString();

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
                    line = shiftUp(_Basic); // Remove the equipment line
                }

                while (!line.Contains("#fe;"))
                {
                    _equipment.Append(_xmlFormatting.returnFormattedString(line,_moduleName));
                    line = shiftUp(_Basic);
                }

                _new.equipment = _equipment.ToString();

                StringBuilder featureDescription = new StringBuilder();
                ClassFeatures _feature = new ClassFeatures();

                while (!line.Contains("#abh;"))
                {
                    if (line.Contains("#fe;"))
                    {  
                        if (!string.IsNullOrEmpty(_feature.FeatureName))
                        {
                            _feature.FeatureDescription = featureDescription.ToString();
                            if (_feature.FeatureDescription.Contains("#archtype;"))
                            {
                                _feature.FeatureDescription = _feature.FeatureDescription.Replace("#archtype;", "");
                                _feature.isArchtypeHeader = true;
                            }
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
                        featureDescription.Append(_xmlFormatting.returnFormattedString(line,_moduleName));
                        line = shiftUp(_Basic);
                    }
                }
                // Catch the last entry
                if (!string.IsNullOrEmpty(_feature.FeatureName))
                {
                    _feature.FeatureDescription = featureDescription.ToString();
                    if (_feature.FeatureDescription.Contains("#archtype;"))
                    {
                        _feature.FeatureDescription = _feature.FeatureDescription.Replace("#archtype;", "");
                        _feature.isArchtypeHeader = true;
                    }
                    _new.classFeatures.Add(_feature);
                    _feature = new ClassFeatures(); // reset
                    featureDescription = new StringBuilder();
                }

                while (!line.Contains("#ab;"))
                {
                    if (line.Contains("#abh;"))
                    {
                        _new.FeatureArchtypeName = line.Split(';')[1].Trim();
                    }
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
                            abilitiecsDescription = new StringBuilder();
                        }

                        _abilities.AbilityName = line.Split(';')[1].Trim();
                        line = shiftUp(_Basic);
                    }

                    while (!line.Contains("#abf;"))
                    {
                        abilitiecsDescription.Append(_xmlFormatting.returnFormattedString(line,_moduleName));
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
                        _feature.UnderArchtype = _abilities.AbilityName;
                        _abilities.AbilityList.Add(string.Format("{0},{1}",_feature.FeatureName,_feature.FeatureLevels));
                        line = shiftUp(_Basic);

                        while (!line.Contains("#abf;") && !line.Contains("#ab;") && !line.Contains("Its done!"))
                        {
                            featureDescription.Append(_xmlFormatting.returnFormattedString(line,_moduleName));
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
                    abilitiecsDescription = new StringBuilder();
                }
            }

            // Append additional details

            _new.classDescriptions = _new.classDescriptions + appendAdditionalDetails(_new,_moduleName);

            return _new;
        }

        private string appendAdditionalDetails(Classes _class, string _moduleName)
        {
            StringBuilder _details = new StringBuilder();

            _details.Append("<h>Hit Points</h>");

            _details.Append(string.Format("<p><b>Hit Dice:</b>{0}</p>",_class.hitDice));
            _details.Append(string.Format("<p><b>Hit Points At 1st Level:</b>{0}</p>", _class.hitPointsAtFirstLevel));
            _details.Append(string.Format("<p><b>Hit Points At Higher Levels:</b>{0}</p>", _class.hitPointsAfterFirstLevel));

            _details.Append("<h>Proficiencies</h>");

            _details.Append(string.Format("<p><b>Armor:</b>{0}</p>", _class.armour));
            _details.Append(string.Format("<p><b>Weapons:</b>{0}</p>", _class.weapons));
            _details.Append(string.Format("<p><b>Tools:</b>{0}</p>", _class.tools));
            _details.Append(string.Format("<p><b>Saving Throws:</b>{0}</p>", _class.savingThrows));
            _details.Append(string.Format("<p><b>Skills:</b>{0}</p>", _class.skills));

            _details.Append("<h>Equipment</h>");
            _details.Append(_class.equipment);

            _details.Append("<h>Features</h>");

            _details.Append("<listlink>");

            for (int i = 0; i < _class._featureList.Count; i++)
            {
                if (string.IsNullOrEmpty(_class._featureList[i].UnderArchtype))
                {
                    string level = string.Empty;

                    if (_class._featureList[i].FeatureLevels.Contains(","))
                    {
                        level = _class._featureList[i].FeatureLevels.Split(',')[0];
                    }
                    else
                    {
                        level = _class._featureList[i].FeatureLevels;
                    }

                    _details.Append(string.Format("<link class=\"reference_classfeature\" recordname=\"reference.classdata.{0}.features.{1}{2}@{3}\">{4}</link>",
                        _class.className.ToLower().Trim(),
                        _class._featureList[i].FeatureName.Replace(" ", "").Replace("-", "").Replace("&", "").Replace(":", "").Replace("'", "").Replace("’", "").ToLower().Trim(),
                        level,
                        _moduleName,
                        _class._featureList[i].FeatureName));
                }
            }

            _details.Append("</listlink>");         

            _details.Append(string.Format("<h>{0}</h>",_class.FeatureArchtypeName));

            _details.Append("<listlink>");

            for (int i = 0; i < _class._abilityList.Count; i++)
            {
               _details.Append(string.Format("<link class=\"reference_classability\" recordname=\"reference.classdata.{0}.abilities.{1}@{2}\">{3}</link>",
                   _class.className.ToLower().Trim(),
                   _class._abilityList[i].AbilityName.Replace(" ", "").Replace("-", "").Replace("&", "").Replace(":", "").Replace("'", "").Replace("’", "").ToLower().Trim(),
                   _moduleName,
                   _class._abilityList[i].AbilityName));
            }

            _details.Append("</listlink>");

            return _details.ToString();
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

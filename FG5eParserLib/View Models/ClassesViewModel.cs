using FG5eParserModels.Player_Models;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace FG5eParserLib.View_Models
{
    public class ClassesViewModel : INotifyPropertyChanged
    {
        // Properties
        public string ClassesTextPath { get; set; }
        public ObservableCollection<string> AbilityHeaders { get; set; }

        // Output
        private string _Output { get; set; }
        public string Output { get { return _Output; } set { _Output = value; OnPropertyChanged("Output"); } }

        // Relay Commands
        public RelayCommand AddClass { get; set; } // Save Button
        public RelayCommand ResetFields { get; set; } // Reset Button

        public RelayCommand AddFeature { get; set; }
        public RelayCommand AddAbility { get; set; }
        public RelayCommand AddAbilityFeature { get; set; }

        // Class Objects
        private Classes _classObject { get; set; }
        private ClassFeatures _featuresObject { get; set; }
        private ClassAbilities _abilityObject { get; set; }
        private ClassFeatures _featuresAbilityObject { get; set; }

        // Constructor
        public ClassesViewModel()
        {
            // Property Inits
            AbilityHeaders = new ObservableCollection<string>();

            // Function inits
            AddClass = new RelayCommand(AddClasstoList, CanAdd);
            ResetFields = new RelayCommand(resetObject);
            AddFeature = new RelayCommand(AddFeaturetoObject, CanAddFeature);
            AddAbility = new RelayCommand(AddAbilitytoObject, CanAddAbility);
            AddAbilityFeature = new RelayCommand(AddFeatureAbilitytoObject, CanAddFeatureAbility);

            // Classes Objects
            _classObject = new Classes();
            _featuresObject = new ClassFeatures();
            _abilityObject = new ClassAbilities();
            _featuresAbilityObject = new ClassFeatures();
        }

        #region FUNCTIONS
        private void AddClasstoList(object obj)
        {
            // Chose the txt file that will hold the information
            if (string.IsNullOrEmpty(ClassesTextPath))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = false;

                if (choofdlog.ShowDialog() == true)
                {
                    // Adding to resources
                    ClassesTextPath = choofdlog.FileName;
                }
            }

            // Add the object to the file
            if (!string.IsNullOrEmpty(ClassesTextPath))
            {
                TextWriter tsw = new StreamWriter(ClassesTextPath, true);
                tsw.WriteLine(getOutput());
                tsw.Close();

                // Reset the object and refresh the screen
                Classes _classObj = new Classes();
                ClassObject = _classObj;
            }
        }

        private bool CanAdd(object obj)
        {
            // Validation logic can be implemented here
            return true;
        }

        private void resetObject(object obj)
        {
            // Reset the object and refresh the screen
            Classes _classObj = new Classes();
            ClassObject = _classObj;
        }

        private void AddFeaturetoObject(object obj)
        {
            ClassObject._featureList.Add(FeaturesObject);

            // Reset the object
            ClassFeatures _featureObj = new ClassFeatures();
            FeaturesObject = _featureObj;
        }

        private bool CanAddFeature(object obj)
        {
            // Validation logic can be implemented here
            return true;
        }

        private void AddAbilitytoObject(object obj)
        {
            ClassObject._abilityList.Add(_abilityObject);

            // Ability Dropdown
            AbilityHeaders.Add(_abilityObject._AbilityName);

            // Reset the object
            ClassAbilities _abilityObj = new ClassAbilities();
            AbilitiesObject = _abilityObj;
        }

        private bool CanAddAbility(object obj)
        {
            // Validation logic can be implemented here
            return true;
        }

        private void AddFeatureAbilitytoObject(object obj)
        {
            ClassObject._featureList.Add(FeaturesAbilityObject);

            // Reset the object
            ClassFeatures _featureObj = new ClassFeatures();
            FeaturesAbilityObject = _featureObj;
        }

        private bool CanAddFeatureAbility(object obj)
        {
            // Validation logic can be implemented here
            return true;
        }

        #endregion

        #region PROPERTY CHANGES
        // Declare the nterface event
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region EXPOSED PROPERTIES
        public Classes ClassObject
        {
            get
            {
                return _classObject;
            }
            set
            {
                _classObject = value;
                OnPropertyChanged(null);
            }
        }

        public ClassFeatures FeaturesObject
        {
            get
            {
                return _featuresObject;
            }
            set
            {
                _featuresObject = value;
                OnPropertyChanged(null);
            }
        }

        public ClassAbilities AbilitiesObject
        {
            get
            {
                return _abilityObject;
            }
            set
            {
                _abilityObject = value;
                OnPropertyChanged(null);
            }
        }

        public ClassFeatures FeaturesAbilityObject
        {
            get
            {
                return _featuresAbilityObject;
            }
            set
            {
                _featuresAbilityObject = value;
                OnPropertyChanged(null);
            }
        }
        #endregion

        //Functions
        private string formatEquipmentString(string obj)
        {
            StringBuilder _sb = new StringBuilder();

            //Split the lines
            string[] lines = obj.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                // First line
                if (i == 0)
                {
                    _sb.Append(lines[i].ToString());
                    _sb.Append(Environment.NewLine);
                }
                else
                {
                    if (i == 1)
                    {
                        // Start the list
                        _sb.Append("#ls;");
                        _sb.Append(Environment.NewLine);
                    }

                    _sb.Append(string.Format("#li;{0}", lines[i].ToString()));
                    _sb.Append(Environment.NewLine);
                }
            }
            // End the list
            _sb.Append("#le;");
            _sb.Append(Environment.NewLine);
            return _sb.ToString();
        }

        public string getOutput()
        {
            StringBuilder _build = new StringBuilder();

            // Header section
            _build.Append(string.Format("##;{0}", ClassObject._ClassName));
            _build.Append(Environment.NewLine);
            _build.Append(ClassObject._ClassDescription);
            _build.Append(Environment.NewLine);

            #region HIT POINT RELATED            
            _build.Append("Hit Points");
            _build.Append(Environment.NewLine);

            if (!string.IsNullOrEmpty(ClassObject._HitDice))
            {
                _build.Append(string.Format("Hit Dice: {0}", ClassObject._HitDice));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<HIT DICE REQUIRED>");
                _build.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(ClassObject._HitPointsAtFirstLevel))
            {
                _build.Append(string.Format("Hit Points at 1st Level: {0}", ClassObject._HitPointsAtFirstLevel));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<HIT POINTS AT FIRST LEVEL REQUIRED>");
                _build.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(ClassObject._HitPointsAtFirstLevel))
            {
                _build.Append(string.Format("Hit Points at Higher Levels: {0}", ClassObject._HitPointsAtFirstLevel));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<HIT POINTS AFTER FIRST LEVEL REQUIRED>");
                _build.Append(Environment.NewLine);
            }
            #endregion

            #region PROFICIENCIES SECTION            
            _build.Append("Proficiencies");
            _build.Append(Environment.NewLine);

            if (!string.IsNullOrEmpty(ClassObject._Armor))
            {
                _build.Append(string.Format("Armor: {0}", ClassObject._Armor));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<ARMOR REQUIRED>");
                _build.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(ClassObject._Weapons))
            {
                _build.Append(string.Format("Weapons: {0}", ClassObject._Weapons));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<ARMOR WEAPONS>");
                _build.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(ClassObject._Tools))
            {
                _build.Append(string.Format("Tools: {0}", ClassObject._Tools));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("Tools: None");
                _build.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(ClassObject._SavingThrows))
            {
                _build.Append(string.Format("Saving Throws: {0}", ClassObject._SavingThrows));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<SAVING THROWS REQUIRED>");
                _build.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(ClassObject._Skills))
            {
                _build.Append(string.Format("Skills: {0}", ClassObject._Skills));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<SKILLS REQUIRED>");
                _build.Append(Environment.NewLine);
            }

            _build.Append("Equipment");
            _build.Append(Environment.NewLine);

            if (!string.IsNullOrEmpty(ClassObject._Equipment))
            {
                _build.Append(formatEquipmentString(ClassObject._Equipment));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<EQUIPMENT REQUIRED>");
                _build.Append(Environment.NewLine);
            }
            #endregion

            // Features
            foreach (var _feature in ClassObject._featureList)
            {
                if (string.IsNullOrEmpty(_feature._UnderArchtype))
                {
                    string _formattedName = string.Format("#fe;{0};{1}"
                                                            , _feature._FeatureName
                                                            , _feature._FeatureLevels
                                                            );
                    _build.Append(_formattedName);
                    _build.Append(Environment.NewLine);

                    if (Convert.ToBoolean(_feature._isArchtypeHeader))
                    {
                        _feature._FeatureDescription = _feature._FeatureDescription + "#archtype;";
                    }
                    _build.Append(_feature._FeatureDescription);
                    _build.Append(Environment.NewLine);
                }
            }

            // Archtype Header Name
            _build.Append(string.Format("#abh;{0}", ClassObject._FeatureArchtypeName));
            _build.Append(Environment.NewLine);

            // Archtype and Ability Features Section
            foreach (var _ability in ClassObject._abilityList)
            {
                _build.Append(string.Format("#ab;{0}", _ability._AbilityName));
                _build.Append(Environment.NewLine);

                _build.Append(string.Format("{0}", _ability._AbilityDescription));
                _build.Append(Environment.NewLine);

                //Features
                foreach (var _feature in ClassObject._featureList)
                {
                    // Only features that are related to the archtype are required here
                    if (_feature._UnderArchtype == _ability._AbilityName)
                    {
                        string _formattedName = string.Format("#fe;{0};{1}"
                                                                , _feature._FeatureName
                                                                , _feature._FeatureLevels
                                                                );
                        _build.Append(_formattedName);
                        _build.Append(Environment.NewLine);

                        _build.Append(_feature._FeatureDescription);
                        _build.Append(Environment.NewLine);
                    }
                }
            }
            return _build.ToString();
        }
    }
}

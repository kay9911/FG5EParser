using FG5eParserModels.Player_Models;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace FG5eParserLib.View_Models
{
    public class ClassesViewModel : INotifyPropertyChanged
    {
        // Properties
        public string ClassesTextPath { get; set; }
        public ObservableCollection<string> AbilityHeaders { get; set; }

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
                tsw.WriteLine(ClassObject._Output);
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
        public Classes ClassObject {
            get {
                return _classObject;
            }
            set {
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
    }
}

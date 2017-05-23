using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FG5eParserModels.Player_Models
{
    public class Classes : INotifyPropertyChanged
    {
        private string ClassName { get; set; }
        private string ClassDescription { get; set; }

        private string HitDice { get; set; }
        private string HitPointsAtFirstLevel { get; set; }
        private string HitPointsAfterFirstLevel { get; set; }

        private string Armor { get; set; }
        private string Weapons { get; set; }
        private string Tools { get; set; }
        private string SavingThrows { get; set; }
        private string Skills { get; set; }
        private string Equipment { get; set; }
        
        public ObservableCollection<ClassFeatures> _featureList { get; set; }

        private string FeatureArchtypeName { get; set; } // What the archtype section is called
        public ObservableCollection<ClassAbilities> _abilityList { get; set; }

        //NOTE: Output was moved to the viewmodel to make gathering all the details easier

        #region PROPERTY CHANGES

        // Declare the interface event
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

        public string _ClassName
        {
            get{
                return ClassName;
            }
            set {
                ClassName = value;
                OnPropertyChanged("_ClassName");
            }
        }

        public string _ClassDescription
        {
            get
            {
                return ClassDescription;
            }
            set
            {
                ClassDescription = value;
                OnPropertyChanged("_ClassDescription");
            }
        }

        public string _HitDice
        {
            get
            {
                return HitDice;
            }
            set
            {
                HitDice = value;
                OnPropertyChanged("_HitDice");
            }
        }

        public string _HitPointsAtFirstLevel
        {
            get
            {
                return HitPointsAtFirstLevel;
            }
            set
            {
                HitPointsAtFirstLevel = value;
                OnPropertyChanged("_HitPointsAtFirstLevel");
            }
        }

        public string _HitPointsAfterFirstLevel
        {
            get
            {
                return HitPointsAfterFirstLevel;
            }
            set
            {
                HitPointsAfterFirstLevel = value;
                OnPropertyChanged("_HitPointsAfterFirstLevel");
            }
        }

        public string _Armor
        {
            get
            {
                return Armor;
            }
            set
            {
                Armor = value;
                OnPropertyChanged("_Armor");
            }
        }

        public string _Weapons
        {
            get
            {
                return Weapons;
            }
            set
            {
                Weapons = value;
                OnPropertyChanged("_Weapons");
            }
        }

        public string _Tools
        {
            get
            {
                return Tools;
            }
            set
            {
                Tools = value;
                OnPropertyChanged("_Tools");
            }
        }

        public string _SavingThrows
        {
            get
            {
                return SavingThrows;
            }
            set
            {
                SavingThrows = value;
                OnPropertyChanged("_SavingThrows");
            }
        }

        public string _Skills
        {
            get
            {
                return Skills;
            }
            set
            {
                Skills = value;
                OnPropertyChanged("_Skills");
            }
        }

        public string _Equipment
        {
            get
            {
                return Equipment;
            }
            set
            {
                Equipment = value;
                OnPropertyChanged("_Equipment");
            }
        }

        public string _FeatureArchtypeName
        {
            get
            {
                return FeatureArchtypeName;
            }
            set
            {
                FeatureArchtypeName = value;
                OnPropertyChanged("_FeatureArchtypeName");
            }
        }

        #endregion  

        // Constructors
        public Classes()
        {
            _featureList = new ObservableCollection<ClassFeatures>();
            _abilityList = new ObservableCollection<ClassAbilities>();
        }
    }

    public class ClassFeatures : INotifyPropertyChanged
    {
        private string FeatureName { get; set; }
        private string FeatureLevels { get; set; }
        private string FeatureDescription { get; set; }
        private bool isArchtypeHeader { get; set; } // True : If feature is defined as the archtype, False : If not
        private string UnderArchtype { get; set; } // What archtype does this feature belong too

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

        public string _FeatureLevels
        {
            get
            {
                return FeatureLevels;
            }
            set
            {
                FeatureLevels = value;
                OnPropertyChanged("_FeatureLevels");
            }
        }

        public string _FeatureDescription
        {
            get
            {
                return FeatureDescription;
            }
            set
            {
                FeatureDescription = value;
                OnPropertyChanged("_FeatureDescription");
            }
        }

        public string _FeatureName
        {
            get
            {
                return FeatureName;
            }
            set
            {
                FeatureName = value;
                OnPropertyChanged("_FeatureName");
            }
        }

        public string _isArchtypeHeader
        {
            get
            {
                return isArchtypeHeader.ToString();
            }
            set
            {
                isArchtypeHeader = Convert.ToBoolean(value);
                OnPropertyChanged("_isArchtypeHeader");
            }
        }

        public string _UnderArchtype
        {
            get
            {
                return UnderArchtype;
            }
            set
            {
                UnderArchtype = value;
                OnPropertyChanged("_UnderArchtype");
            }
        }
        #endregion
    }

    public class ClassAbilities : INotifyPropertyChanged
    {
        private string AbilityName { get; set; }
        private string AbilityDescription { get; set; }
        private ObservableCollection<string> _list { get; set; }

        public ClassAbilities()
        {
            _list = new ObservableCollection<string>();
        }

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

        public string _AbilityName
        {
            get
            {
                return AbilityName;
            }
            set
            {
                AbilityName = value;
                OnPropertyChanged("_AbilityName");
            }
        }

        public string _AbilityDescription
        {
            get
            {
                return AbilityDescription;
            }
            set
            {
                AbilityDescription = value;
                OnPropertyChanged("_AbilityDescription");
            }
        }

        #endregion
    }
}

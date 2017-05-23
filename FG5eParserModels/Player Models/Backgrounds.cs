using System;
using System.ComponentModel;
using System.Text;

namespace FG5eParserModels.Player_Models
{
    public class Backgrounds : INotifyPropertyChanged
    {
        private string Name { get; set; }
        private string Description { get; set; }
        private string Skills { get; set; }
        private string Tools { get; set; }
        private string Languages { get; set; }
        private string Equipment { get; set; }
        private string Feature { get; set; }
        private string FeatureDescription { get; set; }
        private string SuggestedCharachteristics { get; set; }
        private string PersonalityTraits { get; set; }
        private string Flaws { get; set; }
        private string Ideals { get; set; }
        private string Bonds { get; set; }

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

        public string _Name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("_Name");
            }
        }
        public string _Description
        {
            get
            {
                return Description;
            }
            set
            {
                Description = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("_Description");
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
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("_Skills");
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
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("_Tools");
            }
        }

        public string _Languages
        {
            get
            {
                return Languages;
            }
            set
            {
                Languages = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("_Languages");
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
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("_Equipment");
            }
        }
        public string _Feature
        {
            get
            {
                return Feature;
            }
            set
            {
                Feature = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("_Feature");
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
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("_FeatureDescription");
            }
        }
        public string _SuggestedCharachteristics
        {
            get
            {
                return SuggestedCharachteristics;
            }
            set
            {
                SuggestedCharachteristics = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("_SuggestedCharachteristics");
            }
        }

        public string _PersonalityTraits
        {
            get
            {
                return PersonalityTraits;
            }
            set
            {
                PersonalityTraits = value;
                OnPropertyChanged("_PersonalityTraits");
            }
        }
        public string _Bonds
        {
            get
            {
                return Bonds;
            }
            set
            {
                Bonds = value;
                OnPropertyChanged("_Bonds");
            }
        }
        public string _Ideals
        {
            get
            {
                return Ideals;
            }
            set
            {
                Ideals = value;
                OnPropertyChanged("_Ideals");
            }
        }
        public string _Flaws
        {
            get
            {
                return Flaws;
            }
            set
            {
                Flaws = value;
                OnPropertyChanged("_Flaws");
            }
        }
        #endregion        
    }
}

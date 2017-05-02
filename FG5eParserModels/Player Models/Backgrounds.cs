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

        // Output
        private string Output { get; set; }

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
                formatOutput();
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
                formatOutput();
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
                formatOutput();
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
                formatOutput();
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
                formatOutput();
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
                formatOutput();
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
                formatOutput();
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
                formatOutput();
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
                formatOutput();
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("_SuggestedCharachteristics");
            }
        }
        public string _Output
        {
            get
            {
                return Output;
            }
            set
            {
                Output = value;
                OnPropertyChanged("_Output");
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
                formatOutput();
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
                formatOutput();
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
                formatOutput();
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
                formatOutput();
                OnPropertyChanged("_Flaws");
            }
        }
        #endregion

        // _Output value is obtained from here
        private void formatOutput()
        {
            StringBuilder _sb = new StringBuilder();

            // Name
            _sb.Append(string.Format("##;{0}", _Name));
            _sb.Append(Environment.NewLine);

            // Desc
            _sb.Append(_Description);
            _sb.Append(Environment.NewLine);

            //Skill Proficiencies: Insight, Religion
            _sb.Append(string.Format("Skill Proficiencies: {0}", _Skills));
            _sb.Append(Environment.NewLine);

            //Tool Proficiencies: Insight, Religion
            _sb.Append(string.Format("Tool Proficiencies: {0}", _Tools));
            _sb.Append(Environment.NewLine);

            //Languages: Two of your choice 
            _sb.Append(string.Format("Languages: {0}", _Languages));
            _sb.Append(Environment.NewLine);

            //Equipment:
            _sb.Append(string.Format("Equipment: {0}", _Equipment));
            _sb.Append(Environment.NewLine);

            //Feature:
            _sb.Append(string.Format("Feature: {0}", _Feature));
            _sb.Append(Environment.NewLine);

            // Desc
            _sb.Append(_FeatureDescription);
            _sb.Append(Environment.NewLine);

            // Suggested
            _sb.Append(_SuggestedCharachteristics);
            _sb.Append(Environment.NewLine);

            // Tables
            _sb.Append("#zls;");
            _sb.Append(Environment.NewLine);

            //#zal;T;*;Acolyte Personality Traits;Acolyte Personality Traits
            _sb.Append(string.Format("#zal;T;*;{0};{0}",_PersonalityTraits));
            _sb.Append(Environment.NewLine);

            //#zal;T;*;Acolyte Ideals;Acolyte Ideals
            _sb.Append(string.Format("#zal;T;*;{0};{0}", _Ideals));
            _sb.Append(Environment.NewLine);

            //#zal;T;*;Acolyte Bonds;Acolyte Bonds
            _sb.Append(string.Format("#zal;T;*;{0};{0}", _Bonds));
            _sb.Append(Environment.NewLine);

            //#zal;T;*;Acolyte Flaws;Acolyte Flaws
            _sb.Append(string.Format("#zal;T;*;{0};{0}", _Flaws));
            _sb.Append(Environment.NewLine);

            _sb.Append("#zle;");
            _sb.Append(Environment.NewLine);

            _Output = _sb.ToString();
            OnPropertyChanged("_Output");
        }
    }
}

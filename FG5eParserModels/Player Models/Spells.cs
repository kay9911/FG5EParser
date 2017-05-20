using System;
using System.ComponentModel;

namespace FG5eParserModels.Player_Models
{
    public class Spells : INotifyPropertyChanged
    {
        private string Name { get; set; }
        private string School { get; set; }
        private bool IsVerbal { get; set; }
        private bool IsSomatic { get; set; }
        private string Material { get; set; }
        private string Level { get; set; }
        private string Description { get; set; }
        private string CastingTime { get; set; }
        private string Range { get; set; }
        private string Duration { get; set; }
        private string Source { get; set; }

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
                OnPropertyChanged("_Name");
            }
        }
        public string _School
        {
            get
            {
                return School;
            }
            set
            {
                School = value;
                OnPropertyChanged("_School");
            }
        }
        public string _IsVerbal
        {
            get
            {
                return IsVerbal.ToString();
            }
            set
            {
                IsVerbal = Convert.ToBoolean(value);
                OnPropertyChanged("_IsVerbal");
            }
        }
        public string _IsSomatic
        {
            get
            {
                return IsSomatic.ToString();
            }
            set
            {
                IsSomatic = Convert.ToBoolean(value);
                OnPropertyChanged("_IsSomatic");
            }
        }
        public string _Material
        {
            get
            {
                return Material;
            }
            set
            {
                Material = value;
                OnPropertyChanged("_Material");
            }
        }
        public string _Level
        {
            get
            {
                return Level;
            }
            set
            {
                Level = value;
                OnPropertyChanged("_Level");
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
                OnPropertyChanged("_Description");
            }
        }
        public string _CastingTime
        {
            get
            {
                return CastingTime;
            }
            set
            {
                CastingTime = value;
                OnPropertyChanged("_CastingTime");
            }
        }
        public string _Range
        {
            get
            {
                return Range;
            }
            set
            {
                Range = value;
                OnPropertyChanged("_Range");
            }
        }
        public string _Duration
        {
            get
            {
                return Duration;
            }
            set
            {
                Duration = value;
                OnPropertyChanged("_Duration");
            }
        }
        public string _Source
        {
            get
            {
                return Source;
            }
            set
            {
                Source = value;
                OnPropertyChanged("_Source");
            }
        }
        #endregion

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
    }
}

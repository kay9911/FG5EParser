using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FG5eParserModels.DM_Modules
{
    public class Encounter : INotifyPropertyChanged
    {
        private string Category { get; set; }
        private string Name { get; set; }
        private string CR { get; set; }
        private string XP { get; set; }
        private List<NPCList> NpcList { get; set; }

        #region EXPOSED PROPERTIES
        public string _Category
        {
            get
            {
                return Category;
            }
            set
            {
                Category = value;
                OnPropertyChanged("_Category");
            }
        }
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
        public int _CR
        {
            get
            {
                return Convert.ToInt32(CR);
            }
            set
            {
                CR = value.ToString();
                OnPropertyChanged("_CR");
            }
        }
        public int _XP
        {
            get
            {
                return Convert.ToInt32(XP);
            }
            set
            {
                XP = value.ToString();
                OnPropertyChanged("_XP");
            }
        }
        public List<NPCList> _NpcList
        {
            get { return NpcList; }
            set
            {
                NpcList = value;
                OnPropertyChanged("_NpcList");
            }
        }
        #endregion

        // Constructor
        public Encounter()
        {
            NpcList = new List<NPCList>();
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
    }

    public class NPCList : INotifyPropertyChanged
    {
        private string Name { get; set; }
        private string Count { get; set; }
        private string UniqueName { get; set; }
        private string Token { get; set; }

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
        public string _UniqueName
        {
            get
            {
                return UniqueName;
            }
            set
            {
                UniqueName = value;
                OnPropertyChanged("_UniqueName");
            }
        }
        public string _Token
        {
            get
            {
                return Token;
            }
            set
            {
                Token = value;
                OnPropertyChanged("_Token");
            }
        }
        public int _Count
        {
            get
            {
                return Convert.ToInt32(Count);
            }
            set
            {
                Count = value.ToString();
                OnPropertyChanged("_Count");
            }
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
    }
}

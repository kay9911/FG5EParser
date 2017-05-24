using System.ComponentModel;

namespace FG5eParserModels.Player_Models
{
    public class Feats : INotifyPropertyChanged
    {
        private string Name { get; set; }
        private string Description { get; set; }
        private string Prerequisit { get; set; }

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
        public string _Prerequisit
        {
            get
            {
                return Prerequisit;
            }
            set
            {
                Prerequisit = value;
                OnPropertyChanged("_Prerequisit");
            }
        }

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

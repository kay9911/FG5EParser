using System.Collections.Generic;
using System.ComponentModel;

namespace FG5eParserModels.Utility_Modules
{
    public class Tables : INotifyPropertyChanged
    {
        private string Category { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }       
        private string Dice { get; set; }
        private string Note { get; set; }
        private List<string> Columns { get; set; }
        private List<string> Rows { get; set; }

        #region EXPOSED PROPERTIES
        public string _Name
        {
            get { return Name; }
            set
            {
                Name = value;
                OnPropertyChanged("_Name");
            }
        }
        public string _Category
        {
            get { return Category; }
            set
            {
                Category = value;
                OnPropertyChanged("_Category");
            }
        }
        public string _Description
        {
            get { return Description; }
            set
            {
                Description = value;
                OnPropertyChanged("_Description");
            }
        }
        public string _Dice
        {
            get { return Dice; }
            set
            {
                Dice = value;
                OnPropertyChanged("_Dice");
            }
        }
        public string _Note
        {
            get { return Note; }
            set
            {
                Note = value;
                OnPropertyChanged("_Note");
            }
        }
        public List<string> _Columns
        {
            get { return Columns; }
            set
            {
                Columns = value;
                OnPropertyChanged("_Columns");
            }
        }
        public List<string> _Rows
        {
            get { return Rows; }
            set
            {
                Rows = value;
                OnPropertyChanged("_Rows");
            }
        }
        #endregion

        // Constructor
        public Tables()
        {
            Columns = new List<string>();
            Rows = new List<string>();
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
}

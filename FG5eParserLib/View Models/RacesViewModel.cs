using FG5eParserModels.Player_Models;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace FG5eParserLib.View_Models
{
    public class RacesViewModel : INotifyPropertyChanged
    {
        // Class Objects
        private Races _RacesObj { get; set; }
        public Races RacesObject
        {
            get
            {
                return _RacesObj;
            }
            set
            {
                _RacesObj = value;
                OnPropertyChanged(null);
            }
        }

        // Properties
        public string RacesTextPath { get; set; }
        public ObservableCollection<Races> _raceList { get; set;}

        // Relay Commands
        public RelayCommand AddRace { get; set; } // Save Button
        public RelayCommand ResetFields { get; set; } // Reset Button

        // Output
        private string _Output { get; set; }
        public string Output { get { return _Output; } set { _Output = value; OnPropertyChanged("Output"); } }

        public RacesViewModel()
        {
            // Object Inits
            _RacesObj = new Races();

            // Collection Inits
            _raceList = new ObservableCollection<Races>();

            // Relay Commands
            AddRace = new RelayCommand(addRace,canAddRace);
            ResetFields = new RelayCommand(resetFields);
        }

        // Functions
        private void addRace(object obj)
        {
            // Chose the txt file that will hold the information
            if (string.IsNullOrEmpty(RacesTextPath))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = false;

                if (choofdlog.ShowDialog() == true)
                {
                    // Adding to resources
                    RacesTextPath = choofdlog.FileName;
                }
            }

            // Add the object to the file
            if (!string.IsNullOrEmpty(RacesTextPath))
            {
                TextWriter tsw = new StreamWriter(RacesTextPath, true);
                tsw.WriteLine("Output goes here");
                tsw.Close();

                // Reset the object and refresh the screen
                Races _raceObj = new Races();
                RacesObject = _raceObj;
            }
        }

        private bool canAddRace(object obj)
        {
            // Validation logic goes here
            return true;
        }

        private void resetFields(object obj)
        {
            // Reset the object and refresh the screen
            Races _raceObj = new Races();
            RacesObject = _raceObj;
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

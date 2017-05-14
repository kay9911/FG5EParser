using FG5eParserModels.Player_Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

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

        private Races _SubRaceObj { get; set; }
        public Races SubRaceObject
        {
            get
            {
                return _SubRaceObj;
            }
            set
            {
                _SubRaceObj = value;
                OnPropertyChanged(null);
            }
        }

        // Properties
        public string RacesTextPath { get; set; }
        public ObservableCollection<Races> _raceList { get; set;}

        // Relay Commands
        public RelayCommand SaveRaces { get; set; } // Save Button
        public RelayCommand ResetFields { get; set; } // Reset Button
        public RelayCommand AddRace { get; set; } // Save Button
        public RelayCommand AddSubRace { get; set; } // Save Button

        // Output
        private string _Output { get; set; }
        public string Output { get { return _Output; } set { _Output = value; OnPropertyChanged("Output"); } }

        public RacesViewModel()
        {
            // Object Inits
            _RacesObj = new Races();
            _SubRaceObj = new Races();

            // Collection Inits
            _raceList = new ObservableCollection<Races>();

            // Relay Commands
            SaveRaces = new RelayCommand(saveRaces, canSaveAddRace);
            ResetFields = new RelayCommand(resetFields);
            AddRace = new RelayCommand(addRace,canAddRace);
            AddSubRace = new RelayCommand(addSubRace,canAddSubRace);
        }

        // Functions
        private void saveRaces(object obj)
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
                tsw.WriteLine(Output);
                tsw.Close();

                // Reset the object and refresh the screen
                Races _raceObj = new Races();
                RacesObject = _raceObj;
            }
        }

        private bool canSaveAddRace(object obj)
        {
            // Validation logic goes here
            return true;
        }

        private void addRace(object obj)
        {
            // Add the race to the list
            _raceList.Add(RacesObject);

            // Refresh the object
            RacesObject = new Races();

            // Show Output
            getOutput();
        }

        private bool canAddRace(object obj)
        {
            // Only if there is a race should this be an option
            if (!string.IsNullOrEmpty(RacesObject._Name) && !string.IsNullOrEmpty(RacesObject._TraitDetails))
            {
                return true;
            }
            else
                return false;
        }

        private void addSubRace(object obj)
        {
            // Subrace Off?
            SubRaceObject.SubRaceOff = RacesObject._Name;

            // Add the race to the list
            _raceList.Add(SubRaceObject);

            // Refresh the object
            SubRaceObject = new Races();

            // Show Output
            getOutput();
        }

        private bool canAddSubRace(object obj)
        {
            // Only if there is a race should this be an option
            if (!string.IsNullOrEmpty(RacesObject._Name) && !string.IsNullOrEmpty(SubRaceObject._Name) && !string.IsNullOrEmpty(SubRaceObject._TraitDetails))
            {
                return true;
            }
            else
                return false;
        }

        private void resetFields(object obj)
        {
            // Reset the object and refresh the screen
            RacesObject = new Races();
            SubRaceObject = new Races();
        }

        private void getOutput()
        {
            StringBuilder _sb = new StringBuilder();

            foreach (var race in _raceList)
            {
                // Race Header
                if (string.IsNullOrEmpty(race.SubRaceOff))
                {
                    _sb.Append(string.Format("##;{0}", race._Name));
                    _sb.Append(Environment.NewLine);
                    _sb.Append(string.Format("#h;{0}", race._Name));
                    _sb.Append(Environment.NewLine);

                    // Description
                    if (!string.IsNullOrEmpty(race._Description))
                    {
                        _sb.Append(race._Description);
                        _sb.Append(Environment.NewLine);
                    }

                    // Traits FORMAT
                    //#!;{Trait}
                    //#!;{Trait}
                    _sb.Append(formatRaceTraits(race._TraitDetails));

                    // SubRaces
                    List<Races> _subRaceList = _raceList.Where(x => x.SubRaceOff == race._Name).ToList();

                    if (_subRaceList.Count != 0)
                    {
                        foreach (var _subRace in _subRaceList)
                        {
                            _sb.Append(string.Format("#s;{0}", _subRace._Name));
                            _sb.Append(Environment.NewLine);
                            _sb.Append(_subRace._Description);
                            _sb.Append(Environment.NewLine);

                            // Traits
                            _sb.Append(formatRaceTraits(_subRace._TraitDetails));
                        }
                    }
                }
            }

            // Assign the output property so that it can be displayed on the screen as well
            Output = _sb.ToString();
        }

        private string formatRaceTraits(string obj)
        {
            string _sb = string.Empty;
            List<string> _items = new List<string>();

            //Split the lines
            string[] lines = obj.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                _sb = _sb + string.Format("#!;{0}{1}",lines[i],Environment.NewLine);                
            }
            return _sb.ToString();
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

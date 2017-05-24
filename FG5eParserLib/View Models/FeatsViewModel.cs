using FG5eParserModels.Player_Models;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace FG5eParserLib.View_Models
{
    public class FeatsViewModel : INotifyPropertyChanged
    {
        // Object Inits
        private Feats _FeatObject { get; set; }
        public Feats FeatObject
        {
            get
            {
                return _FeatObject;
            }
            set
            {
                _FeatObject = value;
                OnPropertyChanged(null);
            }
        }

        // Props and List
        public ObservableCollection<Feats> _featList { get; set; }
        public string FeatsTextPath { get; set; }

        // Relay Commands
        public RelayCommand SaveFeats { get; set; } // Save Button
        public RelayCommand ResetFields { get; set; } // Reset Button
        public RelayCommand AddFeattoList { get; set; } // Add Feat to list

        // Output
        private string _Output { get; set; }
        public string Output { get { return _Output; } set { _Output = value; OnPropertyChanged("Output"); } }

        public FeatsViewModel()
        {
            // Object Inits
            FeatObject = new Feats();

            // List Inits
            _featList = new ObservableCollection<Feats>();

            // Delegates
            SaveFeats = new RelayCommand(saveFeats, canSaveFeats);
            ResetFields = new RelayCommand(resetFields);
            AddFeattoList = new RelayCommand(addFeattoList, canAddFeat);
        }

        // Functions
        private void saveFeats(object obj)
        {
            // Chose the txt file that will hold the information
            if (string.IsNullOrEmpty(FeatsTextPath))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = false;

                if (choofdlog.ShowDialog() == true)
                {
                    // Adding to resources
                    FeatsTextPath = choofdlog.FileName;
                }
            }

            // Add the object to the file
            if (!string.IsNullOrEmpty(FeatsTextPath))
            {
                TextWriter tsw = new StreamWriter(FeatsTextPath, true);
                tsw.WriteLine(Output);
                tsw.Close();

                // Reset the object and refresh the screen
                FeatObject = new Feats();
            }
        }

        private bool canSaveFeats(object obj)
        {
            // Validation logic goes here
            return true;
        }

        private void resetFields(object obj)
        {
            // Reset the object and refresh the screen
            FeatObject = new Feats();
        }

        private void addFeattoList(object obj)
        {
            // Add the spell to the list
            _featList.Add(FeatObject);

            getOutput();

            // Reset the object and refresh the screen
            FeatObject = new Feats();
        }

        private bool canAddFeat(object obj)
        {
            // validation logic goes here
            return true;
        }

        // Output Function
        private void getOutput()
        {
            StringBuilder _sb = new StringBuilder();

            if (_featList.Count != 0)
            {
                foreach (var feat in _featList)
                {
                    // Name
                    _sb.Append(string.Format("##!{0}",feat._Name));
                    _sb.Append(Environment.NewLine);

                    //Prerequisite: Dexterity 13 or higher
                    _sb.Append(string.Format("Prerequisite: {0}", feat._Prerequisit));
                    _sb.Append(Environment.NewLine);
                    
                    // Desc
                    _sb.Append(string.Format("{0}", feat._Description));
                    _sb.Append(Environment.NewLine);
                }
            }

            Output = _sb.ToString();
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

using System.Collections.ObjectModel;
using System.ComponentModel;
using FG5eParserModels.Player_Models;
using System.IO;
using Microsoft.Win32;
using FG5eParserLib.Utility;

namespace FG5eParserLib.View_Mo.dels
{
    public class BackgroundViewModel : INotifyPropertyChanged
    {
        public string backgroundTextPath { get; set; }

        // Table pop up data
        private string tableTextPath { get; set; }
        public ObservableCollection<string> TableNames { get; set; }

        // Relay Commands
        public RelayCommand AddBackground { get; set; } // Save Button
        public RelayCommand ResetFields { get; set; } // Reset Button

        // Lists and Objects
        private Backgrounds BackgroundObj { get; set; }

        #region PROPERTY CHANGES
        public event PropertyChangedEventHandler PropertyChanged;
        public Backgrounds Background {
            get {
                return BackgroundObj;
            }
            set {
                BackgroundObj = value;
                OnPropertyChanged(null);
            }
        }
        public string _tableTextPath
        {
            set
            {
                TableNames = getTableList(value);
                OnPropertyChanged(null);
            }
        }

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

        // Constructors
        public BackgroundViewModel()
        {
            // Command Inits
            AddBackground = new RelayCommand(BackgroundAddToList, CanAdd);
            ResetFields = new RelayCommand(resetObject);

            //Inits
            BackgroundObj = new Backgrounds();
            TableNames = new ObservableCollection<string>();
        }

        // Functions
        private void BackgroundAddToList(object obj)
        {
            // Chose the txt file that will hold the information
            if (string.IsNullOrEmpty(backgroundTextPath))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = false;

                if (choofdlog.ShowDialog() == true)
                {
                    backgroundTextPath = choofdlog.FileName;
                }
            }

            // Add the object to the file
            if (!string.IsNullOrEmpty(backgroundTextPath))
            {                
                TextWriter tsw = new StreamWriter(backgroundTextPath, true);
                tsw.WriteLine(BackgroundObj._Output);
                tsw.Close();

                // Reset the object and refresh the screen
                Backgrounds _backObj = new Backgrounds();
                Background = _backObj;
            }
        }

        private bool CanAdd(object _obj)
        {
            // TO DO: Validation logic for add goes here
            return true;
        }

        private void resetObject(object obj)
        {
            // Reset the object and refresh the screen
            Backgrounds _backObj = new Backgrounds();
            Background = _backObj;
        }

        private ObservableCollection<string> getTableList(string path)
        {
            Readers _reader = new Readers();
            ObservableCollection<string> _tableList = _tableList = _reader.ReadTables(path);
            return _tableList;
        }
    }
}

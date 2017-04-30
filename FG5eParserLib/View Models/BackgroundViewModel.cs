using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FG5eParserModels.Player_Models;
using FG5eParserModels.Utility_Modules;
using System.IO;

namespace FG5eParserLib.View_Mo.dels
{
    public class BackgroundViewModel : INotifyPropertyChanged
    {
        public string backgroundTextPath { get; set; }

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
        }

        // Functions
        public void BackgroundAddToList(object obj)
        {
            // Add the object to the file
            TextWriter tsw = new StreamWriter(backgroundTextPath, true);
            tsw.WriteLine(BackgroundObj._Output);
            tsw.Close();

            // Reset the object
            Backgrounds _backObj = new Backgrounds();
            Background = _backObj;
        }

        public bool CanAdd(object _obj)
        {            
            if (!string.IsNullOrEmpty(backgroundTextPath))
            {
                return true;
            }
            // TO DO: Validation logic for add goes here
            return false;
        }

        private void resetObject(object obj)
        {
            Backgrounds _backObj = new Backgrounds();
            Background = _backObj;
        }
    }
}

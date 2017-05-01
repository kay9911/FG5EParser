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
using Microsoft.Win32;

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
            if (string.IsNullOrEmpty(backgroundTextPath))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = false;

                if (choofdlog.ShowDialog() == true)
                {
                    // Adding to resources
                    backgroundTextPath = choofdlog.FileName;
                }
            }

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
            // TO DO: Validation logic for add goes here
            return true;
        }

        private void resetObject(object obj)
        {
            Backgrounds _backObj = new Backgrounds();
            Background = _backObj;
        }
    }
}

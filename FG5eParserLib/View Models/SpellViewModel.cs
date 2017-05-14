using FG5eParserModels.Player_Models;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace FG5eParserLib.View_Models
{
    public class SpellViewModel : INotifyPropertyChanged
    {
        // Class Objects
        private Spells _SpellObj { get; set; }
        public Spells SpellObject
        {
            get
            {
                return _SpellObj;
            }
            set
            {
                _SpellObj = value;
                OnPropertyChanged(null);
            }
        }

        // Properties and Lists
        public string SpellsTextPath { get; set; }
        public ObservableCollection<Spells> _spellList { get; set; }
        public List<string> _LevelList { get; set; }
        public List<string> _SpellSchools { get; set; }

        // Relay Commands
        public RelayCommand SaveSpells { get; set; } // Save Button
        public RelayCommand ResetFields { get; set; } // Reset Button
        public RelayCommand AddSpell { get; set; } // Add Spell

        // Output
        private string _Output { get; set; }
        public string Output { get { return _Output; } set { _Output = value; OnPropertyChanged("Output"); } }

        // Constructor
        public SpellViewModel()
        {
            // Class Objects Inits
            _SpellObj = new Spells();

            // Lists Inits
            _spellList = new ObservableCollection<Spells>();
            _LevelList = new List<string>() {
                "",
                "1st Level",
                "2nd Level",
                "3rd Level",
                "4th Level",
                "5th Level",
                "6th Level",
                "7th Level",
                "8th Level",
                "9th Level",
            };

            _SpellSchools = new List<string>(){
                "",
                "Abjuration",
                "Conjuration",
                "Divination",
                "Enchantment",
                "Evocation",
                "Illusion",
                "Necromancy"
            };

            // Delegates
            SaveSpells = new RelayCommand(saveSpells, canSaveSpells);
            ResetFields = new RelayCommand(resetFields);
        }

        // Functions
        private void saveSpells(object obj)
        {
            // Chose the txt file that will hold the information
            if (string.IsNullOrEmpty(SpellsTextPath))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = false;

                if (choofdlog.ShowDialog() == true)
                {
                    // Adding to resources
                    SpellsTextPath = choofdlog.FileName;
                }
            }

            // Add the object to the file
            if (!string.IsNullOrEmpty(SpellsTextPath))
            {
                TextWriter tsw = new StreamWriter(SpellsTextPath, true);
                tsw.WriteLine(Output);
                tsw.Close();

                // Reset the object and refresh the screen
                SpellObject = new Spells();
            }
        }

        private bool canSaveSpells(object obj)
        {
            // Validation logic goes here
            return true;
        }

        private void resetFields(object obj)
        {
            // Reset the object and refresh the screen
            SpellObject = new Spells();
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

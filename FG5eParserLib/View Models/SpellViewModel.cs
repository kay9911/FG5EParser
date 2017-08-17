using FG5eParserLib.Utility;
using FG5eParserModels.Player_Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;

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
        private string _SpellListName { get; set; }
        public string SpellListName
        {
            get
            {
                return _SpellListName;
            }
            set
            {
                _SpellListName = value;
                OnPropertyChanged("SpellListName");
            }
        }
        private string _SpellsinList { get; set; }
        public string SpellsinList
        {
            get
            {
                return _SpellsinList;
            }
            set
            {
                _SpellsinList = value;
                OnPropertyChanged("SpellsinList");
            }
        }
        private bool _isRitual { get; set; }
        public bool isRitual
        {
            get
            {
                return _isRitual;
            }
            set
            {
                _isRitual = value;
                OnPropertyChanged("isRitual");
            }
        }
        // Revamped Table Changes
        private string ShowSpellTableFlg { get; set; }
        public bool _showSpellTableFlg
        {
            get
            {
                return Convert.ToBoolean(ShowSpellTableFlg);
            }
            set
            {
                ShowSpellTableFlg = value.ToString();
                OnPropertyChanged("_showSpellTableFlg");
            }
        }

        // Properties and Lists
        public string SpellsTextPath { get; set; }
        public ObservableCollection<Spells> _spellTempList { get; set; }
        public ObservableCollection<string> _LevelList { get; set; }
        public ObservableCollection<string> _SpellSchools { get; set; }
        public List<string> _SpellLists { get; set; }

        // Relay Commands
        public RelayCommand SaveSpells { get; set; } // Save Button
        public RelayCommand ResetFields { get; set; } // Reset Button
        public RelayCommand AddSpell { get; set; } // Add Spell
        public RelayCommand AddSpellList { get; set; } // Spell Lists

        // Revamped Table Changes
        public ObservableCollection<SpellRecord> SpellList { get; set; }
        public RelayCommand AddSelectedSpellItem { get; set; }
        public RelayCommand ShowSpellList { get; set; }
        private string ShowOutput { get; set; }
        public bool _showOutput
        {
            get
            {
                return Convert.ToBoolean(ShowOutput);
            }
            set
            {
                ShowOutput = value.ToString();
                OnPropertyChanged("_showOutput");
            }
        }

        // Output
        private string _Output { get; set; }
        public string Output { get { return _Output; } set { _Output = value; OnPropertyChanged("Output"); } }

        // Constructor
        public SpellViewModel()
        {
            // Class Objects Inits
            _SpellObj = new Spells() { _IsVerbal = "true" };

            // Lists Inits
            _spellTempList = new ObservableCollection<Spells>();
            _SpellLists = new List<string>();
            _LevelList = new ObservableCollection<string>() {
                "",
                "Cantrip",
                "1st-Level",
                "2nd-Level",
                "3rd-Level",
                "4th-Level",
                "5th-Level",
                "6th-Level",
                "7th-Level",
                "8th-Level",
                "9th-Level",
            };
            _SpellSchools = new ObservableCollection<string>(){
                "",
                "Abjuration",
                "Conjuration",
                "Divination",
                "Enchantment",
                "Evocation",
                "Illusion",
                "Necromancy",
                "Transmutation"
            };

            // Delegates
            SaveSpells = new RelayCommand(saveSpells, canSaveSpells);
            ResetFields = new RelayCommand(resetFields);
            AddSpell = new RelayCommand(addSpell, canAddSpell);
            AddSpellList = new RelayCommand(addSpellList, canAddSpellList);

            // Revamped Table Changes
            SpellList = new ObservableCollection<SpellRecord>();
            AddSelectedSpellItem = new RelayCommand(addSelectedSpellItem);
            ShowSpellList = new RelayCommand(showSpellList);
            _showOutput = true;
        }

        // Revamped Table Changes
        private void addSelectedSpellItem(object obj)
        {
            if (obj != null)
            {
                StringBuilder _sb = new StringBuilder();
                _sb.Append(SpellsinList);

                if (!string.IsNullOrEmpty(_sb.ToString()))
                {
                    _sb.Append(Environment.NewLine);
                }
                _sb.Append(((SpellRecord)obj).Name);

                SpellsinList = _sb.ToString();
            }
        }

        private void showSpellList(object obj)
        {
            // Save existing data, "Dummy" is just to pass a dummy so as to activate the save function
            saveSpells("Dummy");

            // Get the list of spells
            Readers _reader = new Readers();
            SpellList.Clear();
            foreach (SpellRecord item in _reader.getSpellRecords(SpellsTextPath))
            {
                SpellList.Add(item);
            }

            // Show/Hide Controls
            if (_showSpellTableFlg) _showSpellTableFlg = false; else _showSpellTableFlg = true;
            if (_showSpellTableFlg) _showOutput = false; else _showOutput = true;
        }

        // Functions
        private void saveSpells(object obj)
        {
            // Chose the txt file that will hold the information
            if (string.IsNullOrEmpty(SpellsTextPath))
            {
                SaveFileDialog choofdlog = new SaveFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";

                if (choofdlog.ShowDialog() == true)
                {
                    // Adding to resources
                    SpellsTextPath = choofdlog.FileName;
                }
            }

            // Add the object to the file
            if (!string.IsNullOrEmpty(SpellsTextPath) && !string.IsNullOrEmpty(Output))
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

        private void addSpell(object obj)
        {
            // Check if Ritual
            if (isRitual)
            {
                SpellObject._School = SpellObject._School + " (Ritual)";
            }

            isRitual = false;

            // Add the spell to the list
            _spellTempList.Add(SpellObject);

            getOutput();

            // Reset the object and refresh the screen
            SpellObject = new Spells() { _Level = SpellObject._Level, _School = SpellObject._School, _IsVerbal = "true" };
        }

        private bool canAddSpell(object obj)
        {
            // validation logic goes here
            return true;
        }

        // Output Function
        private void getOutput()
        {
            StringBuilder _sb = new StringBuilder();

            if (_SpellLists.Count != 0)
            {
                _sb.Append("#@;");
                _sb.Append(Environment.NewLine);

                for (int i = 0; i < _SpellLists.Count; i++)
                {
                    // List name
                    _sb.Append(_SpellLists[i].ToString());
                    _sb.Append(Environment.NewLine);

                    i++; // Moving to the spells

                    // get the list of spells
                    string[] lines = _SpellLists[i].Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                    foreach (var _spell in lines)
                    {
                        _sb.Append(_spell);
                        _sb.Append(Environment.NewLine);
                    }
                }
            }

            if (_spellTempList.Count != 0)
            {
                _sb.Append("##;");
                _sb.Append(Environment.NewLine);

                foreach (var spell in _spellTempList)
                {
                    _sb.Append(spell._Name);
                    _sb.Append(Environment.NewLine);

                    _sb.Append(string.Format("{0} {1}",spell._Level,spell._School));
                    _sb.Append(Environment.NewLine);

                    _sb.Append(string.Format("Casting Time: {0}",spell._CastingTime));
                    _sb.Append(Environment.NewLine);

                    _sb.Append(string.Format("Range: {0}", spell._Range));
                    _sb.Append(Environment.NewLine);

                    string _comp = string.Empty ;
                    // Components
                    if (!string.IsNullOrEmpty(spell._IsVerbal))
                    {
                        _comp = "V,";
                    }
                    if (!string.IsNullOrEmpty(spell._IsSomatic))
                    {
                        _comp = _comp + "S,";
                    }
                    if (!string.IsNullOrEmpty(spell._Material))
                    {
                        _comp = _comp + string.Format("M ({0})",spell._Material);
                    }
                    _sb.Append(string.Format("Components: {0}", _comp));
                    _sb.Append(Environment.NewLine);

                    _sb.Append(string.Format("Duration: {0}",spell._Duration));
                    _sb.Append(Environment.NewLine);

                    _sb.Append(spell._Description);
                    _sb.Append(Environment.NewLine);
                }
            }
            Output = _sb.ToString();
        }

        private void addSpellList(object obj)
        {
            _SpellLists.Add(SpellListName);
            _SpellLists.Add(SpellsinList);

            getOutput();

            SpellListName = string.Empty;
            SpellsinList = string.Empty;
        }

        private bool canAddSpellList(object obj)
        {
            return true;
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

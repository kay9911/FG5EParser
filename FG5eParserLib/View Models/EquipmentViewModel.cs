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
    public class EquipmentViewModel : INotifyPropertyChanged
    {
        // Properties
        public string EquipmentTextPath { get; set; }
        public ObservableCollection<Equipment> itemList { get; set; }

        private string Output { get; set; }
        public string _Output
        {
            get
            {
                return Output;
            }
            set
            {
                Output = value;
                OnPropertyChanged("_Output");
            }
        }

        private string SubTypeDescriptionText { get; set; }
        public string _SubTypeDescriptionText
        {
            get
            {
                return SubTypeDescriptionText;
            }
            set
            {
                SubTypeDescriptionText = value;
                OnPropertyChanged("_SubTypeDescriptionText");
            }
        }

        private List<string> SubTypeDescriptionTextList { get; set; }

        // Class Objects
        private Equipment _EquipmentObject { get; set; }
        public Equipment EquipmentObject
        {
            get
            {
                return _EquipmentObject;
            }
            set
            {
                _EquipmentObject = value;
                OnPropertyChanged(null);
            }
        }

        // Relay Commands
        public RelayCommand SaveEquipmentList { get; set; } // Save Button
        public RelayCommand ResetFields { get; set; } // Reset Button
        public RelayCommand AddItemToList { get; set; } // Save Button

        // Constructor
        public EquipmentViewModel()
        {
            // Object Inits
            EquipmentObject = new Equipment();
            SubTypeDescriptionTextList = new List<string>();

            // Property Inits
            itemList = new ObservableCollection<Equipment>();

            // Command Inits
            SaveEquipmentList = new RelayCommand(saveEquipmentList, CanAdd);
            ResetFields = new RelayCommand(resetObject);
            AddItemToList = new RelayCommand(addItemToList, canAddItemtoList);
        }

        // Functions
        private void saveEquipmentList(object obj)
        {
            // Chose the txt file that will hold the information
            if (string.IsNullOrEmpty(EquipmentTextPath))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = false;

                if (choofdlog.ShowDialog() == true)
                {
                    EquipmentTextPath = choofdlog.FileName;
                }
            }

            // Add the object to the file
            if (!string.IsNullOrEmpty(EquipmentTextPath))
            {
                TextWriter tsw = new StreamWriter(EquipmentTextPath, true);
                tsw.WriteLine(getOutput());
                tsw.Close();

                // Reset the object and refresh the screen
                Equipment _equipmentObj = new Equipment() { _Type = EquipmentObject._Type };
                EquipmentObject = _equipmentObj;
            }
        }

        private bool CanAdd(object obj)
        {
            // Validation logic goes here
            return true;
        }

        private void resetObject(object obj)
        {
            // Reset the object and refresh the screen
            Equipment _equipmentObj = new Equipment() { _Type = EquipmentObject._Type };
            EquipmentObject = _equipmentObj;

            _SubTypeDescriptionText = string.Empty;
            SubTypeDescriptionTextList.Clear();
        }

        private void addItemToList(object obj)
        {
            // Add the item to the list
            itemList.Add(EquipmentObject);

            // Check for subtype description
            if (!string.IsNullOrEmpty(_SubTypeDescriptionText))
            {
                SubTypeDescriptionTextList.Add(string.Format("{0}. {1}",EquipmentObject._Subtype,_SubTypeDescriptionText));
                _SubTypeDescriptionText = string.Empty;
            }

            // Get the output
            _Output = getOutput();

            // Reset the object and refresh the screen
            Equipment _equipmentObj = new Equipment() { _Type = EquipmentObject._Type, _Subtype = EquipmentObject._Subtype };
            EquipmentObject = _equipmentObj;
        }

        private bool canAddItemtoList(object obj)
        {
            // Validation logic goes here
            return true;
        }

        private string getOutput()
        {
            StringBuilder _sb = new StringBuilder();

            // Get a list of the major Categories
            List<string> _categoryTypes = itemList.Select(x => x._Type).Distinct().ToList();

            // Check for Major Category
            foreach (var _majorCategory in _categoryTypes)
            {
                _sb.Append(string.Format("#@;{0}",_majorCategory));
                _sb.Append(Environment.NewLine);

                // Add required Header Row
                if (_majorCategory == "Adventuring Gear")
                {
                    _sb.Append("#th;Item;Cost;Weight");
                    _sb.Append(Environment.NewLine);
                }

                if (_majorCategory == "Armor")
                {
                    _sb.Append("#th;Armor;Cost;Armor Class (AC);Strength;Stealth;Weight");
                    _sb.Append(Environment.NewLine);
                }

                if (_majorCategory == "Weapon")
                {
                    _sb.Append("#th;Name;Cost;Damage;Weight;Properties");
                    _sb.Append(Environment.NewLine);
                }

                if (_majorCategory == "Tools")
                {
                    _sb.Append("#th;Item;Cost;Weight");
                    _sb.Append(Environment.NewLine);
                }

                if (_majorCategory == "Mounts and Other Animals")
                {
                    _sb.Append("#th;Item;Cost;Speed;Carrying Capacity");
                    _sb.Append(Environment.NewLine);
                }

                if (_majorCategory == "Tack, Harness, and Drawn Vehicles")
                {
                    _sb.Append("#th;Item;Cost;Weight");
                    _sb.Append(Environment.NewLine);
                }

                if (_majorCategory == "Waterborne Vehicles")
                {
                    _sb.Append("#th;Item;Cost;Speed");
                    _sb.Append(Environment.NewLine);
                }

                // Prepare a shorter list
                List<Equipment> _shortList = itemList.Where(x => x._Type == _majorCategory).ToList();

                // Subtype
                List<string> _subtypes = itemList.Where(y => y._Type == _majorCategory).Select(x => x._Subtype).Distinct().ToList();
                foreach (var subtype in _subtypes)
                {
                    _sb.Append(string.Format("#st;{0}", subtype));
                    _sb.Append(Environment.NewLine);

                    // Prepare a shorter list
                    List<Equipment> _definedList = _shortList.Where(x => x._Subtype == subtype).ToList();

                    // Add the items 
                    // Adventuring Gear : Crystal; 10 gp; 1 lb.;
                    // Armor : Padded; 5 gp; 11 + Dex modifier; —; Disadvantage; 8 lb.;
                    // Weapon : Club; 1 sp; 1d4 bludgeoning; 2 lb.; Light;
                    // Tools : Carpenter’s tools; 8 gp; 6 lb.
                    // Mounts and Other Animals : Camel; 50 gp; 50 ft.; 480 lb.
                    // Tack, Harness, and Drawn Vehicles : Chariot; 250 gp; 100 lb.;
                    // Waterborne Vehicles : Galley; 30,000 gp; 4 mph;
                    foreach (var item in _definedList)
                    {
                        if (_majorCategory == "Adventuring Gear")
                        {
                            _sb.Append(string.Format("{0};{1};{2};"
                            , item._Name
                            , item._Cost
                            , item._Weight
                            ));
                        }

                        if (_majorCategory == "Armor")
                        {
                            _sb.Append(string.Format("{0};{1};{2};{3};{4};{5}"
                            , item._Name
                            , item._Cost
                            , item._AC
                            , item._StrRequired
                            , Convert.ToBoolean(item._StealthDisadvantage) == true ? "-" : "Disadvantage"
                            , item._Weight
                            ));
                        }

                        if (_majorCategory == "Weapon")
                        {
                            _sb.Append(string.Format("{0};{1};{2};{3};{4}"
                                ,item._Name
                                ,item._Cost
                                ,item._Damage
                                ,item._Weight
                                ,item._Properties
                                ));    
                        }

                        if (_majorCategory == "Tools")
                        {
                            _sb.Append(string.Format("{0};{1};{2}"
                            , item._Name
                            , item._Cost
                            , item._Weight
                            ));
                        }

                        if (_majorCategory == "Mounts and Other Animals")
                        {
                            _sb.Append(string.Format("{0};{1};{2};{3}"
                            , item._Name
                            , item._Cost
                            , item._Speed
                            ,item._CarryingCapacity
                            ));
                        }

                        if (_majorCategory == "Tack, Harness, and Drawn Vehicles")
                        {
                            _sb.Append(string.Format("{0};{1};{2}"
                              , item._Name
                              , item._Cost
                              , item._Weight
                              ));
                        }

                        if (_majorCategory == "Waterborne Vehicles")
                        {
                            _sb.Append(string.Format("{0};{1};{2}"
                              , item._Name
                              , item._Cost
                              , item._Speed
                              ));
                        }
                        _sb.Append(Environment.NewLine);
                    }
                }
            }

            // Descriptions
            _sb.Append("##;");
            _sb.Append(Environment.NewLine);

            // Subtype descriptions
            foreach (var desc in SubTypeDescriptionTextList)
            {
                _sb.Append(string.Format("#stt;{0}",desc));
                _sb.Append(Environment.NewLine);
            }

            // Individual item descriptions
            foreach (var item in itemList)
            {
                _sb.Append(string.Format("{0}. {1}", item._Name, item._Description));
                _sb.Append(Environment.NewLine);

                // If there is a item breakdown list
                if (!string.IsNullOrEmpty(item._Subitems))
                {
                    // Format list of items
                    _sb.Append(formatItemList(item._Subitems));
                    _sb.Append(Environment.NewLine);
                }
            }

            return _sb.ToString();
        }

        private string formatItemList(string obj)
        {
            string _sb = string.Empty;
            List<string> _items = new List<string>();

            //Split the lines
            string[] lines = obj.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                _sb = _sb + lines[i] + ";";
            }
            return string.Format("#si;{0}", _sb);
        }

        #region PROPERTY CHANGES
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

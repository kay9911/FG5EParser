using FG5eParserModels.DM_Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace FG5eParserLib.View_Models
{
    public class MagicalItemViewModel : INotifyPropertyChanged
    {
        public string MagicItemTextPath { get; set; }
        public ObservableCollection<MagicalItems> EquipmentList { get; set; }

        // Model Object
        private MagicalItems EquipmentObj { get; set; }
        public MagicalItems EquipmentObject
        {
            get { return EquipmentObj; }
            set
            {
                EquipmentObj = value; OnPropertyChanged("EquipmentObject");
            }
        }

        public List<string> Types { get; set; }
        public List<string> Rarities { get; set; }

        // View Functions
        public RelayCommand AddItemToList { get; set; }
        public RelayCommand SaveEquipmentList { get; set; }

        public MagicalItemViewModel()
        {
            EquipmentObject = new MagicalItems();
            EquipmentList = new ObservableCollection<MagicalItems>();

            // Lists
            Types = new List<string>() {"","Armor","Potion","Ring","Rod","Scroll","Staff","Wand","Weapon","Wondrous Item" };
            Rarities = new List<string>() {"", "Common", "Uncommon", "Rare", "Very Rare", "Legendary"};

            // View Functions
            AddItemToList = new RelayCommand(addItemToList);
            SaveEquipmentList = new RelayCommand(saveEquipmentList);
        }

        /*FUNCTIONS*/
        private void saveEquipmentList(object obj)
        {
            TextWriter tsw = new StreamWriter(MagicItemTextPath, true);
            tsw.WriteLine(getOutput());
            tsw.Close();

            EquipmentList.Clear();
        }

        private void addItemToList(object obj)
        {
            EquipmentList.Add(EquipmentObject);
            EquipmentObject = new MagicalItems();
        }

        private string getOutput()
        {
            StringBuilder _sb = new StringBuilder();

            // CSV type of file with details as follows
            // Name;Type;Subtype;Category;Rarity;Cost;Weight;Properties;AC;ACBonus;DexBonus;StrRequired;Stealth;Damage;DamageBonus;BaseType;BaseDescription;Description

            foreach (MagicalItems item in EquipmentList)
            {
                _sb.Append(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17}"
                    , item._Name
                    , item._Type
                    , item._Subtype
                    , item._Category
                    , item._Rarity
                    , item._Cost
                    , item._Weight
                    , item._Properties
                    , item._AC
                    , item._ACBonus
                    , item._DexBonus
                    , item._StrRequired
                    , item._IsStealthDisadvantage
                    , item._Damage
                    , item._DamageBonus
                    , item._UnidenifiedBaseType
                    , item._UnidentifiedDescription.Replace(";", "@")
                    , item._Description.Replace(";","@")
                    ));
                _sb.Append(Environment.NewLine);
            }
            return _sb.ToString();
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

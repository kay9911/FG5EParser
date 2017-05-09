using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5eParserModels.Player_Models
{
    public class Equipment : INotifyPropertyChanged
    {
        // Mandatory
        private string Name { get; set; }
        private string isLocked { get { return "1"; } }
        private string Type { get; set; }
        private string Subtype { get; set; }
        private string Cost { get; set; }
        private string Weight { get; set; }

        public string _Name
        {
            get { return Name; }
            set { Name = value; OnPropertyChanged("_Name"); }
        }
        public string _Type
        {
            get { return Type; }
            set { Type = value; OnPropertyChanged("_Type"); }
        }
        public string _Subtype
        {
            get { return Subtype; }
            set { Subtype = value; OnPropertyChanged("_Subtype"); }
        }
        public string _Cost
        {
            get { return Cost; }
            set { Cost = value; OnPropertyChanged("_Cost"); }
        }
        public string _Weight
        {
            get { return Weight; }
            set { Weight = value; OnPropertyChanged("_Weight"); }
        }

        // Armor Related
        private string AC { get; set; }
        private string DexBonus { get; set; }
        private string StrRequired { get; set; }
        private string StealthDisadvantage { get; set; }

        public string _AC
        {
            get { return AC; }
            set { AC = value; OnPropertyChanged("_AC"); }
        }
        public string _DexBonus
        {
            get { return DexBonus; }
            set { DexBonus = value; OnPropertyChanged("_DexBonus"); }
        }
        public string _StrRequired
        {
            get { return StrRequired; }
            set { StrRequired = value; OnPropertyChanged("_StrRequired"); }
        }
        public string _StealthDisadvantage
        {
            get { return StealthDisadvantage; }
            set { StealthDisadvantage = value; OnPropertyChanged("_StealthDisadvantage"); }
        }

        // Weapon Related
        private string Damage { get; set; }
        private string Properties { get; set; }

        public string _Damage
        {
            get { return Damage; }
            set { Damage = value; OnPropertyChanged("_Damage"); }
        }
        public string _Properties
        {
            get { return Properties; }
            set { Properties = value; OnPropertyChanged("_Properties"); }
        }

        // Mounts and Locomotives
        private string Speed { get; set; }
        private string CarryingCapacity { get; set; }

        public string _Speed
        {
            get { return Speed; }
            set { Speed = value; OnPropertyChanged("_Speed"); }
        }
        public string _CarryingCapacity
        {
            get { return CarryingCapacity; }
            set { CarryingCapacity = value; OnPropertyChanged("_CarryingCapacity"); }
        }

        // Magic Item Related
        private string ACBonus { get; set; }
        private string isIdentified { get; set; }
        private string Rarity { get; set; }
        private string UnidentifiedBaseType { get; set; }
        private string UnidentifiedDescription { get; set; }

        public string _ACBonus
        {
            get { return ACBonus; }
            set { ACBonus = value; OnPropertyChanged("_ACBonus"); }
        }
        public string _isIdentified
        {
            get { return isIdentified; }
            set { isIdentified = value; OnPropertyChanged("_isIdentified"); }
        }
        public string _Rarity
        {
            get { return Rarity; }
            set { Rarity = value; OnPropertyChanged("_Rarity"); }
        }
        public string _UnidentifiedBaseType
        {
            get { return UnidentifiedBaseType; }
            set { UnidentifiedBaseType = value; OnPropertyChanged("_UnidentifiedBaseType"); }
        }
        public string _UnidentifiedDescription
        {
            get { return UnidentifiedDescription; }
            set { UnidentifiedDescription = value; OnPropertyChanged("_UnidentifiedDescription"); }
        }

        // Misc
        private string Description { get; set; } // Needs formatting options
        public string _Description
        {
            get { return Description; }
            set { Description = value; OnPropertyChanged("_Description"); }
        }

        public ObservableCollection<Subitems> Subitems { get; set; }
        private string isTemplate { get { return "0"; } }

        public Equipment()
        {
            Subitems = new ObservableCollection<Subitems>();
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

    public class Subitems : INotifyPropertyChanged
    {
        private string ItemName { get; set; }
        private string Count { get; set; }

        public string _ItemName
        {
            get { return ItemName; }
            set { ItemName = value; OnPropertyChanged("_ItemName"); }
        }
        public string _Count
        {
            get { return Count; }
            set { Count = value; OnPropertyChanged("_Count"); }
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

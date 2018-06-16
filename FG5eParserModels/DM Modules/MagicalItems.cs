using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5eParserModels.DM_Modules
{
    public class MagicalItems : INotifyPropertyChanged
    {
        /*GENERAL DETAILS*/
        private string Name { get; set; }
        private string Category { get; set; }
        private string Cost { get; set; }
        private string Description { get; set; }
        private string Type { get; set; }
        private string Subtype { get; set; }
        private string Rarity { get; set; }
        private string Weight { get; set; }

        /*ARMOR DETAILS*/
        private string AC { get; set; }
        private string ACBonus { get; set; }
        private string DexBonus { get; set; }
        private string StrRequired { get; set; }
        private string IsStealthDisadvantage { get; set; }

        /*WEAPON DETAILS*/
        private string Damage { get; set; }
        private string DamageBonus { get; set; }

        /*MAGIC ITEM PROPERTIES*/
        private string Properties { get; set; }
        private string UnidenifiedBaseType { get; set; }
        private string UnidentifiedDescription { get; set; }

        /*EXPOSED PROPERTIES*/
        public string _Name { get { return Name; } set { Name = value; OnPropertyChanged("_Name"); } }
        public string _Category { get { return Category; } set { Category = value; OnPropertyChanged("_Category"); } }
        public string _Cost { get { return Cost; } set { Cost = value; OnPropertyChanged("_Cost"); } }
        public string _Description { get { return Description; } set { Description = value; OnPropertyChanged("_Description"); } }
        public string _Type { get { return Type; } set { Type = value; OnPropertyChanged("_Type"); } }
        public string _Subtype { get { return Subtype; } set { Subtype = value; OnPropertyChanged("_Subtype"); } }
        public string _Rarity { get { return Rarity; } set { Rarity = value; OnPropertyChanged("_Rarity"); } }
        public string _Weight { get { return Weight; } set { Weight = value; OnPropertyChanged("_Weight"); } }

        public string _AC { get { return AC; } set { AC = value; OnPropertyChanged("_AC"); } }
        public string _ACBonus { get { return ACBonus; } set { ACBonus = value; OnPropertyChanged("_ACBonus"); } }
        public string _DexBonus { get { return DexBonus; } set { DexBonus = value; OnPropertyChanged("_DexBonus"); } }
        public string _StrRequired { get { return StrRequired; } set { StrRequired = value; OnPropertyChanged("_StrRequired"); } }
        public bool _IsStealthDisadvantage { get { return Convert.ToBoolean(IsStealthDisadvantage); } set { IsStealthDisadvantage = value.ToString(); OnPropertyChanged("_IsStealthDisadvantage"); } }

        public string _Damage { get { return Damage; } set { Damage = value; OnPropertyChanged("_Damage"); } }
        public string _DamageBonus { get { return DamageBonus; } set { DamageBonus = value; OnPropertyChanged("_DamageBonus"); } }

        public string _Properties { get { return Properties; } set { Properties = value; OnPropertyChanged("_Properties"); } }
        public string _UnidenifiedBaseType { get { return UnidenifiedBaseType; } set { UnidenifiedBaseType = value; OnPropertyChanged("_UnidenifiedBaseType"); } }
        public string _UnidentifiedDescription { get { return UnidentifiedDescription; } set { UnidentifiedDescription = value; OnPropertyChanged("_UnidentifiedDescription"); } }

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

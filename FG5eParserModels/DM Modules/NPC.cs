using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FG5eParserModels.DM_Modules
{
    public class NPC : INotifyPropertyChanged
    {
        #region PRIVATE PROPERTIES
        private string Name { get; set; }
        private string Type { get; set; }
        private string SubType { get; set; }
        private string Size { get; set; }
        private string Alignment { get; set; }
        private string AC { get; set; }
        private string HitPoints { get; set; }
        private string HitDice { get; set; }
        private string Speed { get; set; }
        private string Strenght { get; set; }
        private string Dexterity { get; set; }
        private string Constitution { get; set; }
        private string Intelligence { get; set; }
        private string Wisdom { get; set; }
        private string Charisma { get; set; }
        private string SavingThrows { get; set; }
        private string Skills { get; set; }
        private string Senses { get; set; }
        private string Languages { get; set; }
        private string CR { get; set; }
        private int XP { get; set; }

        private string DamageVulnarabilities { get; set; }
        private string DamageResistance { get; set; }
        private string DamageImmunities { get; set; }
        private string ConditionImmunities { get; set; }

        private string Details { get; set; }
        #endregion

        #region EXPOSED PROPERTIES
        public string _Name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
                OnPropertyChanged("_Name");
            }
        }
        public string _Type
        {
            get
            {
                return Type;
            }
            set
            {
                Type = value;
                OnPropertyChanged("_Type");
            }
        }
        public string _SubType
        {
            get
            {
                return SubType;
            }
            set
            {
                SubType = value;
                OnPropertyChanged("_SubType");
            }
        }
        public string _Size
        {
            get
            {
                return Size;
            }
            set
            {
                Size = value;
                OnPropertyChanged("_Size");
            }
        }
        public string _Alignment
        {
            get
            {
                return Alignment;
            }
            set
            {
                Alignment = value;
                OnPropertyChanged("_Alignment");
            }
        }
        public string _AC
        {
            get
            {
                return AC;
            }
            set
            {
                AC = value;
                OnPropertyChanged("_AC");
            }
        }
        public string _HitPoints
        {
            get
            {
                return HitPoints;
            }
            set
            {
                HitPoints = value;
                OnPropertyChanged("_HitPoints");
            }
        }
        public string _HitDice
        {
            get
            {
                return HitDice;
            }
            set
            {
                HitDice = value;
                OnPropertyChanged("_HitDice");
            }
        }
        public string _Speed
        {
            get
            {
                return Speed;
            }
            set
            {
                Speed = value;
                OnPropertyChanged("_Speed");
            }
        }
        public string _Strenght
        {
            get
            {
                return Strenght.ToString();
            }
            set
            {
                Strenght = value;
                OnPropertyChanged("_Strenght");
            }
        }
        public string _Dexterity
        {
            get
            {
                return Dexterity.ToString();
            }
            set
            {
                Dexterity = value;
                OnPropertyChanged("_Dexterity");
            }
        }
        public string _Constitution
        {
            get
            {
                return Constitution.ToString();
            }
            set
            {
                Constitution = value;
                OnPropertyChanged("_Constitution");
            }
        }
        public string _Intelligence
        {
            get
            {
                return Intelligence.ToString();
            }
            set
            {
                Intelligence = value;
                OnPropertyChanged("_Intelligence");
            }
        }
        public string _Wisdom
        {
            get
            {
                return Wisdom.ToString();
            }
            set
            {
                Wisdom = value;
                OnPropertyChanged("_Wisdom");
            }
        }
        public string _Charisma
        {
            get
            {
                return Charisma.ToString();
            }
            set
            {
                Charisma = value;
                OnPropertyChanged("_Charisma");
            }
        }
        public string _SavingThrows
        {
            get
            {
                return SavingThrows;
            }
            set
            {
                SavingThrows = value;
                OnPropertyChanged("_SavingThrows");
            }
        }
        public string _Skills
        {
            get
            {
                return Skills;
            }
            set
            {
                Skills = value;
                OnPropertyChanged("_Skills");
            }
        }
        public string _Senses
        {
            get
            {
                return Senses;
            }
            set
            {
                Senses = value;
                OnPropertyChanged("_Senses");
            }
        }
        public string _Languages
        {
            get
            {
                return Languages;
            }
            set
            {
                Languages = value;
                OnPropertyChanged("_Languages");
            }
        }
        public string _CR
        {
            get
            {
                return CR;
            }
            set
            {
                CR = value;
                OnPropertyChanged("_CR");
            }
        }
        public int _XP
        {
            get
            {
                return XP;
            }
            set
            {
                XP = value;
                OnPropertyChanged("_XP");
            }
        }

        public string _DamageVulnarabilities
        {
            get
            {
                return DamageVulnarabilities;
            }
            set
            {
                DamageVulnarabilities = value;
                OnPropertyChanged("_DamageVulnarabilities");
            }
        }
        public string _DamageResistance
        {
            get
            {
                return DamageResistance;
            }
            set
            {
                DamageResistance = value;
                OnPropertyChanged("_DamageResistance");
            }
        }
        public string _DamageImmunities
        {
            get
            {
                return DamageImmunities;
            }
            set
            {
                DamageImmunities = value;
                OnPropertyChanged("_DamageImmunities");
            }
        }
        public string _ConditionImmunities
        {
            get
            {
                return ConditionImmunities;
            }
            set
            {
                ConditionImmunities = value;
                OnPropertyChanged("_ConditionImmunities");
            }
        }

        public string _Details
        {
            get
            {
                return Details;
            }
            set
            {
                Details = value;
                OnPropertyChanged("_Details");
            }
        }
        #endregion

        // Lists
        public ObservableCollection<string> _Abilities { get; set; }
        public ObservableCollection<string> _Actions { get; set; }
        public ObservableCollection<string> _Legend { get; set; }
        public ObservableCollection<string> _Reaction { get; set; }
        public ObservableCollection<string> _Lair { get; set; }

        // Constructor
        public NPC()
        {
            _Abilities = new ObservableCollection<string>();
            _Actions = new ObservableCollection<string>();
            _Legend = new ObservableCollection<string>();
            _Reaction = new ObservableCollection<string>();
            _Lair = new ObservableCollection<string>();
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

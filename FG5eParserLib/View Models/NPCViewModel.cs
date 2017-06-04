using FG5eParserModels.DM_Modules;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace FG5eParserLib.View_Models
{
    public class NPCViewModel : INotifyPropertyChanged
    {
        // Object Inits
        private NPC _NPCObj { get; set; }
        public NPC NPCObject
        {
            get
            {
                return _NPCObj;
            }
            set
            {
                _NPCObj = value;
                OnPropertyChanged(null);
            }
        }
        private NPCInnateSpellCasting _InnateSpellcastingObj { get; set; }
        public NPCInnateSpellCasting InnateSepllcastingObject
        {
            get
            {
                return _InnateSpellcastingObj;
            }
            set
            {
                _InnateSpellcastingObj = value;
                OnPropertyChanged(null);
            }
        }
        private NPCSpellCasting _SpellcastingObj { get; set; }
        public NPCSpellCasting SpellcastingObject
        {
            get
            {
                return _SpellcastingObj;
            }
            set
            {
                _SpellcastingObj = value;
                OnPropertyChanged(null);
            }
        }

        // Props and List
        public ObservableCollection<NPC> _npcList { get; set; }
        public string NPCTextPath { get; set; }

        // Lists required from the UI
        public List<string> _npcSizes;
        public List<string> _npcTypes;
        public List<string> _npcSubTypes;
        public List<string> _npcAlignments;
        public List<string> _attributes;
        public List<string> _spellSlots;

        // Relay Commands
        public RelayCommand SaveNPC { get; set; } // Save Button
        public RelayCommand ResetFields { get; set; } // Reset Button
        public RelayCommand AddNPCToList { get; set; } // Add Feat to list

        // Output
        private string _Output { get; set; }
        public string Output { get { return _Output; } set { _Output = value; OnPropertyChanged("Output"); } }

        // Tab Control Lists
        public ObservableCollection<string> Actions { get; set; }
        private string actionName { get; set; }
        private string actionDescription { get; set; }

        public ObservableCollection<string> Abilities { get; set; }
        private string abilityName { get; set; }
        private string abilityDescription { get; set; }

        public ObservableCollection<string> Reactions { get; set; }
        private string reactionName { get; set; }
        private string reactionDescription { get; set; }

        public ObservableCollection<string> LegendaryActions { get; set; }
        private string legendaryActionName { get; set; }
        private string legendaryActionDescription { get; set; }

        #region EXPOSED TAB CONTROL PROPERTIES
        public string ActionName
        {
            get
            {
                return actionName;
            }
            set
            {
                actionName = value;
                OnPropertyChanged("ActionName");
            }
        }
        public string ActionDescription
        {
            get
            {
                return actionDescription;
            }
            set
            {
                actionDescription = value;
                OnPropertyChanged("ActionDescription");
            }
        }

        public string AbilityName
        {
            get
            {
                return abilityName;
            }
            set
            {
                abilityName = value;
                OnPropertyChanged("AbilityName");
            }
        }
        public string AbilityDescription
        {
            get
            {
                return abilityDescription;
            }
            set
            {
                abilityDescription = value;
                OnPropertyChanged("AbilityDescription");
            }
        }

        public string ReactionName
        {
            get
            {
                return reactionName;
            }
            set
            {
                reactionName = value;
                OnPropertyChanged("ReactionName");
            }
        }
        public string ReactionDescription
        {
            get
            {
                return reactionDescription;
            }
            set
            {
                reactionDescription = value;
                OnPropertyChanged("ReactionDescription");
            }
        }

        public string LegendaryActionName
        {
            get
            {
                return legendaryActionName;
            }
            set
            {
                legendaryActionName = value;
                OnPropertyChanged("LegendaryActionName");
            }
        }
        public string LegendaryActionDescription
        {
            get
            {
                return legendaryActionDescription;
            }
            set
            {
                legendaryActionDescription = value;
                OnPropertyChanged("LegendaryActionDescription");
            }
        }
        #endregion

        // Tab Control Commands
        public RelayCommand AddActionToList { get; set; }
        public RelayCommand AddAbilityToList { get; set; }
        public RelayCommand AddReactionToList { get; set; }
        public RelayCommand AddLegendaryActionToList { get; set; }

        // Constructor
        public NPCViewModel()
        {
            // Object Inits
            NPCObject = new NPC()
            {   // Starting Values
                _Strenght = "10",
                _Dexterity = "10",
                _Constitution = "10",
                _Intelligence = "10",
                _Wisdom = "10",
                _Charisma = "10"
            };
            InnateSepllcastingObject = new NPCInnateSpellCasting();
            SpellcastingObject = new NPCSpellCasting();

            // List Inits
            _npcList = new ObservableCollection<NPC>();

            #region HARD CODED LISTS           
            _npcSizes = new List<string>() {
                "",
                "Tiny",
                "Small",
                "Medium",
                "Large",
                "Huge",
                "Gargantuan"
            };
            _npcTypes = new List<string>() {
                "",
                "Aberration",
                "Beast",
                "Celestial",
                "Construct",
                "Dragon",
                "Elemental",
                "Fey",
                "Fiend",
                "Giant",
                "Humanoid",
                "Monstrosity",
                "Ooze",
                "Plant",
                "Swarm Of Tiny Beasts",
                "Undead"
            };
            _npcSubTypes = new List<string>() {
                "",
                "Any Race",
                "Demon",
                "Devil",
                "Dwarf",
                "Elf",
                "Gnoll",
                "Gnome",
                "Goblinoid",
                "Grimlock",
                "Kobold",
                "Lizardfolk",
                "Merfolk",
                "Orc",
                "Sahuagin",
                "Shapechanger",
                "Titan"
            };
            _npcAlignments = new List<string>() {
                "",
                "Any Alignment",
                "Lawful good",
                "Neutral good",
                "Chaotic good",
                "Lawful neutral",
                "Neutral",
                "Chaotic neutral",
                "Lawful evil",
                "Neutral evil",
                "Chaotic evil"
            };
            _attributes = new List<string>() {
                "",
                "Strength",
                "Dexterity",
                "Constitution",
                "Intelligence",
                "Wisdom",
                "Charisma"
            };
            _spellSlots = new List<string>() {
                "",
                "1 Slot",
                "2 Slots",
                "3 Slots",
                "4 Slots",
                "5 Slots",
                "6 Slots",
                "7 Slots",
                "8 Slots",
                "9 Slots"
            };
            #endregion

            // Tab Control Lists
            Actions = new ObservableCollection<string>();
            Abilities = new ObservableCollection<string>();
            Reactions = new ObservableCollection<string>();
            LegendaryActions = new ObservableCollection<string>();

            // Delegates
            SaveNPC = new RelayCommand(saveNPC, canSaveNPC);
            ResetFields = new RelayCommand(resetFields);
            AddNPCToList = new RelayCommand(addNPCToList, canAddNPC);

            // Tab Control Delegates
            AddActionToList = new RelayCommand(addActionToList, canAddAction);
            AddAbilityToList = new RelayCommand(addAbilityToList, canAddAction);
            AddReactionToList = new RelayCommand(addReactionToList, canAddReaction);
            AddLegendaryActionToList = new RelayCommand(addLegendaryActionToList, canAddLegendaryAction);
        }

        // Functions
        private void saveNPC(object obj)
        {
            // Chose the txt file that will hold the information
            if (string.IsNullOrEmpty(NPCTextPath))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = false;

                if (choofdlog.ShowDialog() == true)
                {
                    // Adding to resources
                    NPCTextPath = choofdlog.FileName;
                }
            }

            // Add the object to the file
            if (!string.IsNullOrEmpty(NPCTextPath))
            {
                TextWriter tsw = new StreamWriter(NPCTextPath, true);
                tsw.WriteLine(Output);
                tsw.Close();

                // Reset the object and refresh the screen
                NPCObject = new NPC();
            }
        }

        private bool canSaveNPC(object obj)
        {
            // Validation logic goes here
            return true;
        }

        private void resetFields(object obj)
        {
            // Reset the object and refresh the screen
            NPCObject = new NPC();
        }

        private void addNPCToList(object obj)
        {
            // Add the spell to the list
            _npcList.Add(NPCObject);

            getOutput();

            // Reset the object and refresh the screen
            NPCObject = new NPC();
        }

        private bool canAddNPC(object obj)
        {
            // validation logic goes here
            return true;
        }

        // Output Function
        private void getOutput()
        {
            StringBuilder _sb = new StringBuilder();

            foreach (var NPC in _npcList)
            {
                _sb.Append(NPC._Name);
                _sb.Append(Environment.NewLine);

                // size, type and alignement
                _sb.Append(string.Format("{0} {1}{2}, {3}"
                    , NPC._Size
                    , NPC._Type
                    , string.IsNullOrEmpty(NPC._SubType) ? string.Empty : string.Format(" ({0})", NPC._SubType) // A field which may not always be required
                    , NPC._Alignment
                    ));
                _sb.Append(Environment.NewLine);

                _sb.Append(string.Format("Armor Class {0}", NPC._AC));
                _sb.Append(Environment.NewLine);

                _sb.Append(string.Format("Hit Points {0}", NPC._HitPoints)); // Hit dice will also come from here since its now one field
                _sb.Append(Environment.NewLine);

                _sb.Append(string.Format("Speed {0}", NPC._Speed));
                _sb.Append(Environment.NewLine);

                // Stats
                //STR DEX CON INT WIS CHA 10 (+0) 10 (+0) 10 (+0) 10 (+0) 10 (+0) 10 (+0)
                _sb.Append(string.Format("STR DEX CON INT WIS CHA {0} ({1}) {2} ({3}) {4} ({5}) {6} ({7}) {8} ({9}) {10} ({11})"
                    , NPC._Strenght, buildStats(NPC._Strenght)
                    , NPC._Dexterity, buildStats(NPC._Dexterity)
                    , NPC._Constitution, buildStats(NPC._Constitution)
                    , NPC._Intelligence, buildStats(NPC._Intelligence)
                    , NPC._Wisdom, buildStats(NPC._Wisdom)
                    , NPC._Charisma, buildStats(NPC._Charisma)
                    ));

                _sb.Append(string.Format("Saving Throws {0}", NPC._SavingThrows));
                _sb.Append(Environment.NewLine);

                _sb.Append(string.Format("Skills {0}", NPC._Skills));
                _sb.Append(Environment.NewLine);

                _sb.Append(string.Format("Damage Vulnerabilities {0}", NPC._DamageVulnarabilities));
                _sb.Append(Environment.NewLine);

                _sb.Append(string.Format("Damage Resistances {0}", NPC._DamageResistance));
                _sb.Append(Environment.NewLine);

                _sb.Append(string.Format("Damage Immunities {0}", NPC._DamageImmunities));
                _sb.Append(Environment.NewLine);

                _sb.Append(string.Format("Condition Immunities {0}", NPC._ConditionImmunities));
                _sb.Append(Environment.NewLine);

                _sb.Append(string.Format("Senses {0}", NPC._Senses));
                _sb.Append(Environment.NewLine);

                _sb.Append(string.Format("Languages {0}", NPC._Languages));
                _sb.Append(Environment.NewLine);

                _sb.Append(string.Format("Challenge {0}", NPC._CR)); // XP and CR are both in this field
                _sb.Append(Environment.NewLine);

                //Lists

                foreach (var str in NPC._Abilities)
                {
                    _sb.Append(string.Format("{0}. {1}"
                        , str.Split('.')[0]
                        , str.Split('.')[1]
                        ));
                    _sb.Append(Environment.NewLine);
                }

                _sb.Append("ACTIONS");
                _sb.Append(Environment.NewLine);
                foreach (var str in NPC._Actions)
                {
                    _sb.Append(string.Format("{0}. {1}"
                        , str.Split('.')[0]
                        , str.Split('.')[1]
                        ));
                    _sb.Append(Environment.NewLine);
                }

                _sb.Append("REACTIONS");
                _sb.Append(Environment.NewLine);
                foreach (var str in NPC._Reaction)
                {
                    _sb.Append(string.Format("{0}. {1}"
                        , str.Split('.')[0]
                        , str.Split('.')[1]
                        ));
                    _sb.Append(Environment.NewLine);
                }

                _sb.Append("LEGENDARY ACTIONS");
                _sb.Append(Environment.NewLine);
                foreach (var str in NPC._Legend)
                {
                    _sb.Append(string.Format("{0}. {1}"
                        , str.Split('.')[0]
                        , str.Split('.')[1]
                        ));
                    _sb.Append(Environment.NewLine);
                }

                _sb.Append("##;");
                _sb.Append(NPC._Details);
            }

            Output = _sb.ToString();
        }

        private string buildStats(string _val)
        {
            decimal _retVal = Math.Floor((Convert.ToDecimal(_val) - 10) / 2);

            string val = string.Empty;

            if (_retVal < 0)
            {
                val = string.Format("+{0}", Convert.ToString(_retVal));
            }
            else
                val = string.Format("-{0}", Convert.ToString(_retVal));

            return val;
        }

        #region TAB CONTROL FUNCTIONS

        private void addActionToList(object obj)
        {
            string _str = ActionName + "." + ActionDescription;
            Actions.Add(_str);

            // Refresh the properties
            ActionName = string.Empty;
            ActionDescription = string.Empty;
        }

        private bool canAddAction(object obj)
        {
            return true;
        }

        private void addAbilityToList(object obj)
        {
            string _str = AbilityName + "." + AbilityDescription;
            Abilities.Add(_str);

            // Refresh the properties
            AbilityName = string.Empty;
            AbilityDescription = string.Empty;
        }

        private bool canAddAbility(object obj)
        {
            return true;
        }

        private void addReactionToList(object obj)
        {
            string _str = ReactionName + "." + ReactionDescription;
            Reactions.Add(_str);

            // Refresh the properties
            ReactionName = string.Empty;
            ReactionDescription = string.Empty;
        }

        private bool canAddReaction(object obj)
        {
            return true;
        }

        private void addLegendaryActionToList(object obj)
        {
            string _str = LegendaryActionName + "." + LegendaryActionDescription;
            LegendaryActions.Add(_str);

            // Refresh the properties
            LegendaryActionName = string.Empty;
            LegendaryActionDescription = string.Empty;
        }

        private bool canAddLegendaryAction(object obj)
        {
            return true;
        }

        #endregion

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

    public class NPCInnateSpellCasting : INotifyPropertyChanged
    {
        private string SpellcastingModifier { get; set; }
        private string spellDC { get; set; }
        private string Modifier { get; set; }

        private string AtWill { get; set; }
        private string OnceDay { get; set; }
        private string TwiceDay { get; set; }
        private string ThriceDay { get; set; }
        private string FourDay { get; set; }
        private string FiveDay { get; set; }

        public string _AtWill
        {
            get
            {
                return AtWill;
            }
            set
            {
                AtWill = value;
                OnPropertyChanged("_AtWill");
            }
        }
        public string _OnceDay
        {
            get
            {
                return OnceDay;
            }
            set
            {
                OnceDay = value;
                OnPropertyChanged("_OnceDay");
            }
        }
        public string _TwiceDay
        {
            get
            {
                return TwiceDay;
            }
            set
            {
                TwiceDay = value;
                OnPropertyChanged("_TwiceDay");
            }
        }
        public string _ThriceDay
        {
            get
            {
                return ThriceDay;
            }
            set
            {
                ThriceDay = value;
                OnPropertyChanged("_ThriceDay");
            }
        }
        public string _FourDay
        {
            get
            {
                return FourDay;
            }
            set
            {
                FourDay = value;
                OnPropertyChanged("_FourDay");
            }
        }
        public string _FiveDay
        {
            get
            {
                return FiveDay;
            }
            set
            {
                FiveDay = value;
                OnPropertyChanged("_FiveDay");
            }
        }


        public string _SpellcastingModifier
        {
            get
            {
                return SpellcastingModifier;
            }
            set
            {
                SpellcastingModifier = value;
                OnPropertyChanged("_SpellcastingModifier");
            }
        }
        public string _spellDC
        {
            get
            {
                return spellDC;
            }
            set
            {
                spellDC = value;
                OnPropertyChanged("_spellDC");
            }
        }
        public string _Modifier
        {
            get
            {
                return Modifier;
            }
            set
            {
                Modifier = value;
                OnPropertyChanged("_Modifier");
            }
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

    public class NPCSpellCasting : INotifyPropertyChanged
    {
        private string SpellcastingModifier { get; set; }
        private string spellDC { get; set; }
        private string Modifier { get; set; }

        private string Cantrips { get; set; }
        private string FirstLevel { get; set; }
        private string SecondLevel { get; set; }
        private string ThirdLevel { get; set; }
        private string FourthLevel { get; set; }
        private string FifthLevel { get; set; }
        private string SixthLevel { get; set; }
        private string SeventhLevel { get; set; }
        private string EightLevel { get; set; }
        private string NinthLevel { get; set; }

        private string FirstLevel_Slots { get; set; }
        private string SecondLevel_Slots { get; set; }
        private string ThirdLevel_Slots { get; set; }
        private string FourthLevel_Slots { get; set; }
        private string FifthLevel_Slots { get; set; }
        private string SixthLevel_Slots { get; set; }
        private string SeventhLevel_Slots { get; set; }
        private string EightLevel_Slots { get; set; }
        private string NinthLevel_Slots { get; set; }

        public string _Cantrips
        {
            get
            {
                return Cantrips;
            }
            set
            {
                Cantrips = value;
                OnPropertyChanged("_Cantrips");
            }
        }
        public string _FirstLevel
        {
            get
            {
                return FirstLevel;
            }
            set
            {
                FirstLevel = value;
                OnPropertyChanged("_FirstLevel");
            }
        }
        public string _SecondLevel
        {
            get
            {
                return SecondLevel;
            }
            set
            {
                SecondLevel = value;
                OnPropertyChanged("_SecondLevel");
            }
        }
        public string _ThirdLevel
        {
            get
            {
                return ThirdLevel;
            }
            set
            {
                ThirdLevel = value;
                OnPropertyChanged("_ThirdLevel");
            }
        }
        public string _FourthLevel
        {
            get
            {
                return FourthLevel;
            }
            set
            {
                FourthLevel = value;
                OnPropertyChanged("_FourthLevel");
            }
        }
        public string _FifthLevel
        {
            get
            {
                return FifthLevel;
            }
            set
            {
                FifthLevel = value;
                OnPropertyChanged("_FifthLevel");
            }
        }
        public string _SixthLevel
        {
            get
            {
                return SixthLevel;
            }
            set
            {
                SixthLevel = value;
                OnPropertyChanged("_SixthLevel");
            }
        }
        public string _SeventhLevel
        {
            get
            {
                return SeventhLevel;
            }
            set
            {
                SeventhLevel = value;
                OnPropertyChanged("_SeventhLevel");
            }
        }
        public string _EightLevel
        {
            get
            {
                return EightLevel;
            }
            set
            {
                EightLevel = value;
                OnPropertyChanged("_EightLevel");
            }
        }
        public string _NinthLevel
        {
            get
            {
                return NinthLevel;
            }
            set
            {
                NinthLevel = value;
                OnPropertyChanged("_NinthLevel");
            }
        }

        public string _FirstLevel_Slots
        {
            get
            {
                return FirstLevel_Slots;
            }
            set
            {
                FirstLevel_Slots = value;
                OnPropertyChanged("_FirstLevel_Slots");
            }
        }
        public string _SecondLevel_Slots
        {
            get
            {
                return SecondLevel_Slots;
            }
            set
            {
                SecondLevel_Slots = value;
                OnPropertyChanged("_SecondLevel_Slots");
            }
        }
        public string _ThirdLevel_Slots
        {
            get
            {
                return ThirdLevel_Slots;
            }
            set
            {
                ThirdLevel_Slots = value;
                OnPropertyChanged("_ThirdLevel_Slots");
            }
        }
        public string _FourthLevel_Slots
        {
            get
            {
                return FourthLevel_Slots;
            }
            set
            {
                FourthLevel_Slots = value;
                OnPropertyChanged("_FourthLevel_Slots");
            }
        }
        public string _FifthLevel_Slots
        {
            get
            {
                return FifthLevel_Slots;
            }
            set
            {
                FifthLevel_Slots = value;
                OnPropertyChanged("_FifthLevel_Slots");
            }
        }
        public string _SixthLevel_Slots
        {
            get
            {
                return SixthLevel_Slots;
            }
            set
            {
                SixthLevel_Slots = value;
                OnPropertyChanged("_SixthLevel_Slots");
            }
        }
        public string _SeventhLevel_Slots
        {
            get
            {
                return SeventhLevel_Slots;
            }
            set
            {
                SeventhLevel_Slots = value;
                OnPropertyChanged("_SeventhLevel_Slots");
            }
        }
        public string _EightLevel_Slots
        {
            get
            {
                return EightLevel_Slots;
            }
            set
            {
                EightLevel_Slots = value;
                OnPropertyChanged("_EightLevel_Slots");
            }
        }
        public string _NinthLevel_Slots
        {
            get
            {
                return NinthLevel_Slots;
            }
            set
            {
                NinthLevel_Slots = value;
                OnPropertyChanged("_NinthLevel_Slots");
            }
        }


        public string _SpellcastingModifier
        {
            get
            {
                return SpellcastingModifier;
            }
            set
            {
                SpellcastingModifier = value;
                OnPropertyChanged("_SpellcastingModifier");
            }
        }
        public string _spellDC
        {
            get
            {
                return spellDC;
            }
            set
            {
                spellDC = value;
                OnPropertyChanged("_spellDC");
            }
        }
        public string _Modifier
        {
            get
            {
                return Modifier;
            }
            set
            {
                Modifier = value;
                OnPropertyChanged("_Modifier");
            }
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

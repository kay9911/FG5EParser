using FG5eParserLib.Utility;
using FG5eParserModels.DM_Modules;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace FG5eParserLib.View_Models
{
    public class EncounterViewModel : INotifyPropertyChanged
    {
        // Class Object
        private Encounter EncounterObj { get; set; }
        public Encounter EncounterObject
        {
            get
            {
                return EncounterObj;
            }
            set
            {
                EncounterObj = value;
                OnPropertyChanged(null);
            }
        }

        // Local Inits
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
        private string NPCEntries = string.Empty;
        public string EncounterTextPath { get; set; }

        public ObservableCollection<VMNPCRecord> NPCList { get; set; }
        public ObservableCollection<NPCRecord> NpcRecordNames { get; set; }        

        public RelayCommand AddEncounterEntry { get; set; }
        public RelayCommand LoadNPCEntries { get; set; }
        public RelayCommand AddSelectedNPC { get; set; }
        public RelayCommand CalculateCRandXP { get; set; }

        // Constructor
        public EncounterViewModel()
        {
            EncounterObj = new Encounter();
            NPCList = new ObservableCollection<VMNPCRecord>();

            AddEncounterEntry = new RelayCommand(addEncounterEntry);
            LoadNPCEntries = new RelayCommand(loadNPCEntries);
            AddSelectedNPC = new RelayCommand(addSelectedNPC);
            CalculateCRandXP = new RelayCommand(calculateCRandXP);

            NpcRecordNames = new ObservableCollection<NPCRecord>();
        }

        private void addSelectedNPC(object obj)
        {
            if (obj != null)
            {
                // Cast the record
                NPCRecord _record = ((NPCRecord)obj);
                if (_record.CR.Contains("1/2")) _record.CR = "0.5";
                if (_record.CR.Contains("1/4")) _record.CR = "0.25";
                if (_record.CR.Contains("1/8")) _record.CR = "0.125";

                NPCList.Add(new VMNPCRecord()
                {
                    Count = 1,
                    Name = _record.Name,
                    CR = Convert.ToDecimal(_record.CR),
                    XP = Convert.ToInt32(_record.XP)
                });
            }
        }

        private void calculateCRandXP(object obj)
        {
            int total = 0;

            foreach (VMNPCRecord item in NPCList)
            {
                total += item.XP * item.Count;
            }

            EncounterObject._XP = total;
        }

        private void loadNPCEntries(object obj)
        {
            Readers _reader = new Readers();
            if (string.IsNullOrEmpty(NPCEntries))
            {
                Microsoft.Win32.OpenFileDialog _ofd = new Microsoft.Win32.OpenFileDialog() { Title = "Please select a file that contains NPC's" };
                if (_ofd.ShowDialog() == true)
                {
                    NPCEntries = _ofd.FileName;
                }
            }

            if (!string.IsNullOrEmpty(NPCEntries))
            {
                NpcRecordNames.Clear();
                foreach (NPCRecord item in _reader.getNPCList(NPCEntries))
                {
                    if (item != null)
                    {
                        NpcRecordNames.Add(item);
                    }
                }
            }
        }

        private void addEncounterEntry(object obj)
        {
            TextWriter tsw = new StreamWriter(EncounterTextPath, true);
            calculateCRandXP(obj);
            getOutput();

            tsw.WriteLine(_Output);
            tsw.Close();

            _Output = string.Empty;

            // Reset screen objects
            NPCList.Clear();
            EncounterObject = new Encounter();
        }

        private void getOutput()
        {
            StringBuilder _sb = new StringBuilder();
            if (!string.IsNullOrEmpty(EncounterObject._Category))
            {
                _sb.Append(string.Format("#@;{0}", EncounterObject._Category));
                _sb.Append(Environment.NewLine);
            }
            _sb.Append(string.Format("##;{0}",EncounterObject._Name));
            _sb.Append(Environment.NewLine);
            _sb.Append(string.Format("CR {0} XP {1}", EncounterObject._CR, EncounterObject._XP)); // TO DO: Append details in case its a fraction
            _sb.Append(Environment.NewLine);

            foreach (VMNPCRecord item in NPCList)
            {
                _sb.Append(string.Format("{0};{1};{2};;"
                    ,item.Count
                    ,item.Name
                    ,item.UniqueName
                    ));
                _sb.Append(Environment.NewLine);
            }

            _Output = _sb.ToString();
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

    public class VMNPCRecord : INotifyPropertyChanged
    {
        private string _Name { get; set; }
        private string _UniqueName { get; set; }
        private string _CR { get; set; }
        private string _XP { get; set; }
        private string _Count { get; set; }

        #region EXPOSED PROPERTIES
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string UniqueName
        {
            get
            {
                return _UniqueName;
            }
            set
            {
                _UniqueName = value;
                OnPropertyChanged("UniqueName");
            }
        }
        public decimal CR
        {
            get
            {
                return Convert.ToDecimal(_XP);
            }
            set
            {
                _XP = value.ToString();
                OnPropertyChanged("XP");
            }
        }
        public int XP
        {
            get
            {
                return Convert.ToInt32(_CR);
            }
            set
            {
                _CR = value.ToString();
                OnPropertyChanged("CR");
            }
        }
        public int Count
        {
            get
            {
                return Convert.ToInt32(_Count);
            }
            set
            {
                _Count = value.ToString();
                OnPropertyChanged("Count");
            }
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
}

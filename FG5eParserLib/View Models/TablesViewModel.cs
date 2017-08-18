using FG5eParserLib.Utility;
using FG5eParserModels.Utility_Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5eParserLib.View_Models
{
    public class TablesViewModel : INotifyPropertyChanged
    {
        public string tablesTextPath { get; set; }
        private string _SelectedItem { get; set; }
        public string SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private string NPCEntries = string.Empty;
        private string TextEntries = string.Empty;
        string CurrentTab = string.Empty;

        public ObservableCollection<EquipmentRecord> EquipmentRecordNames { get; set; }
        public ObservableCollection<TextRecord> TextEntryNames { get; set; }
        public ObservableCollection<NPCRecord> NpcRecordNames { get; set; }

        public RelayCommand DisplayEntriesList { get; set; }
        public RelayCommand AddNewTableBlock { get; set; }
        public RelayCommand AddNewTableEntry { get; set; }
        public RelayCommand AddSelectedTextItem { get; set; }
        //public RelayCommand AddSelectedImage { get; set; }
        public RelayCommand AddSelectedNPC { get; set; }
        public RelayCommand AddTableEntry { get; set; }

        private string _NumberofRows { get; set; }
        public string NumberofRows
        {
            get
            {
                return _NumberofRows;
            }
            set
            {
                _NumberofRows = value;
                OnPropertyChanged("_NumberofRows");
            }
        }

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

        private string ShowDataTableFlg { get; set; }
        public bool _showDataTableFlg
        {
            get
            {
                return Convert.ToBoolean(ShowDataTableFlg);
            }
            set
            {
                ShowDataTableFlg = value.ToString();
                OnPropertyChanged("_showDataTableFlg");
            }
        }
        private string ShowNPCTableFlg { get; set; }
        public bool _showNPCTableFlg
        {
            get
            {
                return Convert.ToBoolean(ShowNPCTableFlg);
            }
            set
            {
                ShowNPCTableFlg = value.ToString();
                OnPropertyChanged("_showNPCTableFlg");
            }
        }

        // Constructor
        public TablesViewModel()
        {
            EquipmentRecordNames = new ObservableCollection<EquipmentRecord>();
            TextEntryNames = new ObservableCollection<TextRecord>();
            NpcRecordNames = new ObservableCollection<NPCRecord>();

            DisplayEntriesList = new RelayCommand(displayEntriesList);
            AddNewTableBlock = new RelayCommand(addNewTableBlock);
            AddNewTableEntry = new RelayCommand(addNewTableEntry);
            AddSelectedTextItem = new RelayCommand(addSelectedTextItem);
            //AddSelectedImage = new RelayCommand(addSelectedImage);
            AddSelectedNPC = new RelayCommand(addSelectedNPC);
            AddTableEntry = new RelayCommand(addTableEntry);
        }

        private void addTableEntry(object obj)
        {
            try
            {
                TextWriter tsw = new StreamWriter(tablesTextPath, true);
                tsw.WriteLine(_Output);
                tsw.Close();
                _Output = string.Empty;
            }
            catch { throw; }
        }

        private void addSelectedNPC(object obj)
        {
            if (obj != null)
            {
                SelectedItem = string.Format("#zal:NPC:*:{0}:{0}", ((NPCRecord)obj).Name);
            }
        }

        //private void addSelectedImage(object obj)
        //{
        //    throw new NotImplementedException();
        //}

        private void addSelectedTextItem(object obj)
        {
            if (obj != null)
            {
                if (CurrentTab == "story")
                {
                    SelectedItem = string.Format("#zal:ST:*:{0}:{0}", ((TextRecord)obj).Title);
                }
            }
        }

        private void addNewTableEntry(object obj)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(_Output);

            if (!string.IsNullOrEmpty(_Output))
            {
                _sb.Append(Environment.NewLine);
            }

            _sb.Append("##;Table Name goes here");
            _sb.Append(Environment.NewLine);
            _sb.Append("#!;Table Description goes here");
            _sb.Append(Environment.NewLine);
            _sb.Append("column;Columns go here");
            _sb.Append(Environment.NewLine);
            _sb.Append("dice;Dice goes here");
            _sb.Append(Environment.NewLine);
            // Rows
            for (int i = 1; i <= Convert.ToInt32(NumberofRows); i++)
            {
                _sb.Append(string.Format("row;{0};{0};ROW_Description_goes_here", i));
                _sb.Append(Environment.NewLine);
            }

            _Output = _sb.ToString();
        }

        private void addNewTableBlock(object obj)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(_Output);

            if (!string.IsNullOrEmpty(_Output))
            {
                _sb.Append(Environment.NewLine);
            }

            _sb.Append("#@;Category goes here");
            _sb.Append(Environment.NewLine);
            _sb.Append("##;Table Name goes here");
            _sb.Append(Environment.NewLine);
            _sb.Append("#!;Table Description goes here");
            _sb.Append(Environment.NewLine);
            _sb.Append("column;Columns go here");
            _sb.Append(Environment.NewLine);
            _sb.Append("dice;Dice goes here");
            _sb.Append(Environment.NewLine);
            // Rows
            for (int i = 1; i <= Convert.ToInt32(NumberofRows); i++)
            {
                _sb.Append(string.Format("row;{0};{0};ROW_Description_goes_here", i));
                _sb.Append(Environment.NewLine);
            }

            _Output = _sb.ToString();
        }

        private void displayEntriesList(object obj)
        {
            Readers _reader = new Readers();

            // NPC List
            if (obj.ToString().ToLower() == "npc")
            {
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

                _showDataTableFlg = false;
                _showNPCTableFlg = true;
            }

            // Equipment List
            //if (obj.ToString().ToLower() == "equipment")
            //{
            //    if (string.IsNullOrEmpty(EquipmentEntries))
            //    {
            //        Microsoft.Win32.OpenFileDialog _ofd = new Microsoft.Win32.OpenFileDialog() { Title = "Please select a file that contains Basic Equipment Entries" };
            //        if (_ofd.ShowDialog() == true)
            //        {
            //            EquipmentEntries = _ofd.FileName;
            //        }
            //    }

            //    if (!string.IsNullOrEmpty(EquipmentEntries))
            //    {
            //        EquipmentRecordNames.Clear();
            //        foreach (EquipmentRecord item in _reader.getEquipmentList(EquipmentEntries))
            //        {
            //            EquipmentRecordNames.Add(item);
            //        }
            //    }
            //    _showEquipmentTableFlg = true;
            //    _showDataTableFlg = false;
            //    _showNPCTableFlg = false;
            //    _showImageTableFlg = false;
            //}

            //if (obj.ToString().ToLower() == "image")
            //{
            //    if (string.IsNullOrEmpty(ImageEntries))
            //    {
            //        FolderBrowserDialog _ofd = new FolderBrowserDialog() { Description = "Please select a folder that contains Images" };
            //        DialogResult result = _ofd.ShowDialog();
            //        if (result == DialogResult.OK)
            //        {
            //            ImageEntries = _ofd.SelectedPath;
            //        }
            //    }

            //    if (!string.IsNullOrEmpty(ImageEntries))
            //    {
            //        ImageNames.Clear();
            //        string[] names = Directory.GetFiles(ImageEntries);
            //        foreach (var item in names)
            //        {
            //            ImageNames.Add(item.Split('\\').Last());
            //        }
            //    }

            //    _showEquipmentTableFlg = false;
            //    _showDataTableFlg = false;
            //    _showNPCTableFlg = false;
            //    _showImageTableFlg = true;
            //}

            if (obj.ToString().ToLower() == "story" || obj.ToString().ToLower() == "reference")
            {
                if (string.IsNullOrEmpty(TextEntries))
                {
                    Microsoft.Win32.OpenFileDialog _ofd = new Microsoft.Win32.OpenFileDialog() { Title = "Please select a folder that contains Text Entries" };
                    if (_ofd.ShowDialog() == true)
                    {
                        TextEntries = _ofd.FileName;
                    }
                }

                if (!string.IsNullOrEmpty(TextEntries))
                {
                    TextEntryNames.Clear();
                    foreach (TextRecord item in _reader.getTextRecords(TextEntries))
                    {
                        TextEntryNames.Add(item);
                    }

                    CurrentTab = "story";
                }

                _showDataTableFlg = true;
                _showNPCTableFlg = false;
            }
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

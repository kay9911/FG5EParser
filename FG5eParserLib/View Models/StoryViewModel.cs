using FG5eParserLib.Utility;
using FG5eParserModels.DM_Modules;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FG5eParserLib.View_Models
{
    public class StoryViewModel : INotifyPropertyChanged
    {
        public string storyTextPath { get; set; }        
        private bool overrightFlg = false; // WARNING! Enabling this will OVERRIGHT any details present in the save to file
        private string NPCEntries = string.Empty;
        private string EquipmentEntries = string.Empty;
        private string ImageEntries = string.Empty;
        private string TextEntries = string.Empty;

        // Lists and Objects
        private Story StoryObj { get; set; }
        public Story StoryObject
        {
            get
            {
                return StoryObj;
            }
            set
            {
                StoryObj = value;
                OnPropertyChanged("StoryObject");
            }
        }
        private string showDataTableFlg { get; set; }
        public bool _showDataTableFlg
        {
            get
            {
                return Convert.ToBoolean(showDataTableFlg);
            }
            set
            {
                showDataTableFlg = value.ToString();
                OnPropertyChanged("_showDataTableFlg");
            }
        }
        private string showEquipmentTableFlg { get; set; }
        public bool _showEquipmentTableFlg
        {
            get
            {
                return Convert.ToBoolean(showEquipmentTableFlg);
            }
            set
            {
                showEquipmentTableFlg = value.ToString();
                OnPropertyChanged("_showEquipmentTableFlg");
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
        private string ShowImageTableFlg { get; set; }
        public bool _showImageTableFlg
        {
            get
            {
                return Convert.ToBoolean(ShowImageTableFlg);
            }
            set
            {
                ShowImageTableFlg = value.ToString();
                OnPropertyChanged("_showImageTableFlg");
            }
        }

        public ObservableCollection<TextRecord> TextEntryNames { get; set; }
        public ObservableCollection<EquipmentRecord> EquipmentRecordNames { get; set; }
        public ObservableCollection<NPCRecord> NpcRecordNames { get; set; }
        public ObservableCollection<string> ImageNames { get; set; }

        // Relay Commands
        public RelayCommand AddStoryEntry { get; set; } // Save Button
        public RelayCommand SelectTableData { get; set; }
        public RelayCommand AddSelectedTableItem { get; set; }
        public RelayCommand LoadAllEntries { get; set; }
        public RelayCommand AddNewStoryBlock { get; set; }
        public RelayCommand AddNewStoryEntry { get; set; }
        public RelayCommand DisplayEntriesList { get; set; }
        public RelayCommand AddSelectedNPC { get; set; }
        public RelayCommand AddSelectedEquipmentItem { get; set; }
        public RelayCommand AddSelectedImage { get; set; }
        public RelayCommand AddSelectedTextItem { get; set; }

        // Output
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

        // Constructor
        public StoryViewModel()
        {
            EquipmentRecordNames = new ObservableCollection<EquipmentRecord>();
            NpcRecordNames = new ObservableCollection<NPCRecord>();
            ImageNames = new ObservableCollection<string>();
            TextEntryNames = new ObservableCollection<TextRecord>();

            // Class Object
            StoryObj = new Story();

            // Relay Commands Init
            AddStoryEntry = new RelayCommand(addStoryEntry);
            LoadAllEntries = new RelayCommand(loadAllEntries);
            AddNewStoryBlock = new RelayCommand(addNewStoryBlock);
            AddNewStoryEntry = new RelayCommand(addNewStoryEntry);
            DisplayEntriesList = new RelayCommand(displayEntriesList);
            AddSelectedNPC = new RelayCommand(addSelectedNPC);
            AddSelectedEquipmentItem = new RelayCommand(addSelectedEquipmentItem);
            AddSelectedImage = new RelayCommand(addSelectedImage);
            AddSelectedTextItem = new RelayCommand(addSelectedTextItem);

            // Hide all datagrids on the UI
            _showDataTableFlg = false;
            _showEquipmentTableFlg = false;
            _showNPCTableFlg = false;
        }

        private void addSelectedTextItem(object obj)
        {
            if (obj != null)
            {
                StringBuilder _sb = new StringBuilder();
                _sb.Append(_Output);

                if (!string.IsNullOrEmpty(_Output))
                {
                    _sb.Append(Environment.NewLine);
                }

                if (CurrentTab == "story")
                {
                    _sb.Append(string.Format("#zal:ST:*:{0}:{0}", ((TextRecord)obj).Title));
                }

                _Output = _sb.ToString();
            }
        }

        private void addSelectedImage(object obj)
        {
            if (obj != null)
            {
                StringBuilder _sb = new StringBuilder();
                _sb.Append(_Output);

                if (!string.IsNullOrEmpty(_Output))
                {
                    _sb.Append(Environment.NewLine);
                }

                _sb.Append(string.Format("#zal;IMG;*;Image:{0};{1}", obj.ToString().Replace(".jpg","").Trim(), obj.ToString()));

                _Output = _sb.ToString();
            }
        }

        private void addSelectedEquipmentItem(object obj)
        {
            if (obj != null)
            {
                StringBuilder _sb = new StringBuilder();
                _sb.Append(_Output);

                if (!string.IsNullOrEmpty(_Output))
                {
                    _sb.Append(Environment.NewLine);
                }

                if (((EquipmentRecord)obj).Type.ToLower() == "adventuring gear")
                {
                    _sb.Append(string.Format("#zal;EG;*;Gear:{0};{0}", ((EquipmentRecord)obj).Item));
                }
                if (((EquipmentRecord)obj).Type.ToLower() == "armor")
                {
                    _sb.Append(string.Format("#zal;EA;*;Armor:{0};{0}", ((EquipmentRecord)obj).Item));
                }
                if (((EquipmentRecord)obj).Type.ToLower() == "weapon")
                {
                    _sb.Append(string.Format("#zal;EW;*;Weapon:{0};{0}", ((EquipmentRecord)obj).Item));
                }
                if (((EquipmentRecord)obj).Type.ToLower() == "tools")
                {
                    _sb.Append(string.Format("#zal;ET;*;Tool:{0};{0}", ((EquipmentRecord)obj).Item));
                }
                if (((EquipmentRecord)obj).Type.ToLower() == "mounts and other animals")
                {
                    _sb.Append(string.Format("#zal;EM;*;Mount:{0};{0}", ((EquipmentRecord)obj).Item));
                }
                if (((EquipmentRecord)obj).Type.ToLower() == "tack, harness, and drawn vehicles")
                {
                    _sb.Append(string.Format("#zal;EV;*;Vehicle:{0};{0}", ((EquipmentRecord)obj).Item));
                }
                if (((EquipmentRecord)obj).Type.ToLower() == "waterborne vehicles")
                {
                    _sb.Append(string.Format("#zal;EWV;*;Ship:{0};{0}", ((EquipmentRecord)obj).Item));
                }

                _Output = _sb.ToString();
            }
        }

        private void addSelectedNPC(object obj)
        {
            if (obj != null)
            {
                StringBuilder _sb = new StringBuilder();
                _sb.Append(_Output);

                if (!string.IsNullOrEmpty(_Output))
                {
                    _sb.Append(Environment.NewLine);
                }

                _sb.Append(string.Format("#zal;NPC;*;NPC:{0};{0}", ((NPCRecord)obj).Name));

                _Output = _sb.ToString();
            }
        }

        string CurrentTab = string.Empty;
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

                _showEquipmentTableFlg = false;
                _showDataTableFlg = false;
                _showNPCTableFlg = true;
                _showImageTableFlg = false;
            }

            // Equipment List
            if (obj.ToString().ToLower() == "equipment")
            {
                if (string.IsNullOrEmpty(EquipmentEntries))
                {
                    Microsoft.Win32.OpenFileDialog _ofd = new Microsoft.Win32.OpenFileDialog() { Title = "Please select a file that contains Basic Equipment Entries" };
                    if (_ofd.ShowDialog() == true)
                    {
                        EquipmentEntries = _ofd.FileName;
                    }
                }

                if (!string.IsNullOrEmpty(EquipmentEntries))
                {
                    EquipmentRecordNames.Clear();
                    foreach (EquipmentRecord item in _reader.getEquipmentList(EquipmentEntries))
                    {
                        EquipmentRecordNames.Add(item);
                    }
                }
                _showEquipmentTableFlg = true;
                _showDataTableFlg = false;
                _showNPCTableFlg = false;
                _showImageTableFlg = false;
            }

            if (obj.ToString().ToLower() == "image")
            {
                if (string.IsNullOrEmpty(ImageEntries))
                {
                    FolderBrowserDialog _ofd = new FolderBrowserDialog() { Description = "Please select a folder that contains Images" };
                    DialogResult result = _ofd.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        ImageEntries = _ofd.SelectedPath;
                    }
                }

                if (!string.IsNullOrEmpty(ImageEntries))
                {
                    ImageNames.Clear();
                    string[] names = Directory.GetFiles(ImageEntries);
                    foreach (var item in names)
                    {
                        ImageNames.Add(item.Split('\\').Last());
                    }
                }

                _showEquipmentTableFlg = false;
                _showDataTableFlg = false;
                _showNPCTableFlg = false;
                _showImageTableFlg = true;
            }

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

                _showEquipmentTableFlg = false;
                _showDataTableFlg = true;
                _showNPCTableFlg = false;
                _showImageTableFlg = false;
            }
        }

        private void addNewStoryEntry(object obj)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(_Output);

            if (!string.IsNullOrEmpty(_Output))
            {
                _sb.Append(Environment.NewLine);
            }
            _sb.Append("##;<Story Entry Header goes here>");
            _sb.Append(Environment.NewLine);
            _sb.Append("<Story Description>");

            _Output = _sb.ToString();
        }

        private void addNewStoryBlock(object obj)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(_Output);

            if (!string.IsNullOrEmpty(_Output))
            {
                _sb.Append(Environment.NewLine);
            }
            _sb.Append("#@;<Major Story Category goes here>");
            _sb.Append(Environment.NewLine);
            _sb.Append("##;<Story Entry Header goes here>");
            _sb.Append(Environment.NewLine);
            _sb.Append("<Story Description>");

            _Output = _sb.ToString();
        }

        private void loadAllEntries(object obj)
        {
            if (!string.IsNullOrEmpty(storyTextPath))
            {
                StringBuilder _sb = new StringBuilder();
                overrightFlg = true;
                var _lines = File.ReadLines(storyTextPath);

                foreach (string item in _lines)
                {
                    _sb.Append(item);
                    _sb.Append(Environment.NewLine);
                }

                _Output = _sb.ToString();
            }
        }

        private void addStoryEntry(object obj)
        {
            if (!string.IsNullOrEmpty(storyTextPath))
            {
                if (overrightFlg)
                {
                    // WARNING! This will overwrite details in the save to file.
                    TextWriter tsw = new StreamWriter(storyTextPath, false);
                    tsw.WriteLine(_Output);
                    tsw.Close();
                }
                else
                {
                    TextWriter tsw = new StreamWriter(storyTextPath, true);
                    tsw.WriteLine(_Output);
                    tsw.Close();
                    _Output = string.Empty;
                }
            }
        }

        #region PROPERTY CHANGED EVENT
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

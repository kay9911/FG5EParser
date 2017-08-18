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

        public ObservableCollection<EquipmentRecord> EquipmentRecordNames;
        public ObservableCollection<TextRecord> TextEntryNames;
        public ObservableCollection<NPCRecord> NpcRecordNames;

        public RelayCommand DisplayEntriesList { get; set; }
        public RelayCommand AddNewTableBlock { get; set; }
        public RelayCommand AddNewTableEntry { get; set; }
        public RelayCommand AddSelectedTextItem { get; set; }
        public RelayCommand AddSelectedImage { get; set; }
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
            AddSelectedImage = new RelayCommand(addSelectedImage);
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
            throw new NotImplementedException();
        }

        private void addSelectedImage(object obj)
        {
            throw new NotImplementedException();
        }

        private void addSelectedTextItem(object obj)
        {
            throw new NotImplementedException();
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
                _sb.Append(string.Format("row;{0};{0};ROW_Description_goes_here",i));
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
            throw new NotImplementedException();
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

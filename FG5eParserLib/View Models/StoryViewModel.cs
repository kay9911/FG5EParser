using FG5eParserModels.DM_Modules;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FG5eParserLib.View_Models
{
    public class StoryViewModel : INotifyPropertyChanged
    {
        public string storyTextPath { get; set; }

        // Table pop up data
        // private string tableTextPath { get; set; }
        public ObservableCollection<string> EntryNames { get; set; }
        public ObservableCollection<Story> StoryEntryList { get; set; }

        // Relay Commands
        public RelayCommand AddStoryEntry { get; set; } // Save Button
        public RelayCommand AddStoryToList { get; set; } // Add background to the list

        public RelayCommand SelectTableData { get; set; }
        public RelayCommand AddSelectedTableItem { get; set; }
        private string tableTextPath = string.Empty;
        private string locationCommandText = string.Empty;

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

        // Lists and Objects
        private Story StoryObj { get; set; }

        // Output
        private string Output { get; set; }

        // Constructor
        public StoryViewModel()
        {
            _showDataTableFlg = true;
        }

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
    }
}

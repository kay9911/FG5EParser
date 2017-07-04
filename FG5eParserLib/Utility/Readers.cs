using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace FG5eParserLib.Utility
{
    class Readers
    {
        public ObservableCollection<string> ReadTables(string _inputLocation)
        {
            var _lines = File.ReadLines(_inputLocation);
            ObservableCollection<string> _tableList = new ObservableCollection<string>();

            foreach (var _line in _lines)
            {
                if (_line.Contains("##;"))
                {
                    _tableList.Add(_line.Replace("##;", ""));
                }
            }
            return _tableList;
        }

        public ObservableCollection<StoryEntry> ReadStoryEntries(string _inputLocation)
        {
            var _lines = File.ReadLines(_inputLocation);
            ObservableCollection<StoryEntry> _storyList = new ObservableCollection<StoryEntry>();

            foreach (var _line in _lines)
            {
                if (_line.Contains("##;"))
                {
                    _storyList.Add(new StoryEntry() { Title = _line.Replace("##;", "") });
                }
            }
            return _storyList;
        }
    }

    public class StoryEntry : INotifyPropertyChanged
    {
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Coordinates
        {
            get
            {
                return _Coordinates;
            }
            set
            {
                _Coordinates = value;
                OnPropertyChanged("Coordinates");
            }
        }

        private string _Title { get; set; }
        private string _Coordinates { get; set; }

        #region PROPERTY CHANGES
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

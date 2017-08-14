using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace FG5eParserLib.Utility
{
    class Readers
    {
        public List<string> ReadTables(string _inputLocation)
        {
            var _lines = File.ReadLines(_inputLocation);
            List<string> _tableList = new List<string>();

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

        public List<string> getNPCList(string _inputLocation)
        {
            List<string> _npcNames = new List<string>();
            List<string> _Dumplines = new List<string>();
            var _lines = File.ReadLines(_inputLocation);

            foreach (string item in _lines)
            {
                _Dumplines.Add(item);
            }

            for (int i = 0; i < _Dumplines.Count; i++)
            {
                if (i == 0)
                {
                    _npcNames.Add(_Dumplines[i]);
                }

                if (string.IsNullOrEmpty(_Dumplines[i]) && i != _Dumplines.Count-1)
                {
                    i++;
                    _npcNames.Add(_Dumplines[i]);
                    i++;
                }
            }

            return _npcNames;
        }

        public List<EquipmentRecord> getEquipmentList(string _inputLocation)
        {
            List<EquipmentRecord> _equipmentList = new List<EquipmentRecord>();
            List<string> _Dumplines = new List<string>();
            var _lines = File.ReadLines(_inputLocation);

            foreach (string item in _lines)
            {
                _Dumplines.Add(item);
            }

            string _currentType = string.Empty;
            string _subtype = string.Empty;
            for (int i = 0; i < _Dumplines.Count; i++)
            {
                if (!_Dumplines[i].Contains("##;"))
                {
                    if (_Dumplines[i].Contains("#@;"))
                    {
                        // Get the main Type
                        _currentType = _Dumplines[i].Replace("#@;", "").Trim();
                    }

                    if (_Dumplines[i].Contains("#st;"))
                    {
                        // Get the SubType
                        _subtype = _Dumplines[i].Replace("#st;", "").Trim();
                    }

                    // Create the new item
                    if (_Dumplines[i].Contains(";") && !_Dumplines[i].Contains("#@;") && !_Dumplines[i].Contains("#st;") && !_Dumplines[i].Contains("#th;") && !_Dumplines[i].Contains("#si;") && !_Dumplines[i].Contains("##;"))
                    {
                        _equipmentList.Add(new EquipmentRecord()
                        {
                            Item = _Dumplines[i].Split(';')[0].Trim(),
                            Type = _currentType,
                            Subtype = _subtype
                        });
                    }
                }
                else
                    break;
            }
            return _equipmentList;
        }
    }

    /* CLASS TEMPLATES */
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

    public class EquipmentRecord
    {
        public string Item { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
    }
}

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

        public List<NPCRecord> getNPCList(string _inputLocation)
        {
            List<NPCRecord> _npcNames = new List<NPCRecord>();
            List<string> _Dumplines = new List<string>();
            var _lines = File.ReadLines(_inputLocation);

            foreach (string item in _lines)
            {
                _Dumplines.Add(item);
            }

            NPCRecord _npcRecord = new NPCRecord();
            for (int i = 0; i < _Dumplines.Count; i++)
            {   
                // Very first record
                if (i == 0 && !string.IsNullOrEmpty(_Dumplines[i]))
                {
                    _npcRecord.Name = _Dumplines[i].Trim();
                    i++;
                    if (_Dumplines[i].Contains(","))
                    {
                        _npcRecord.Class = _Dumplines[i].Split(',')[0].Trim().Split(' ')[1].Trim();
                    }
                }
                if (_Dumplines[i].Contains("Challenge") && !string.IsNullOrEmpty(_npcRecord.Name))
                {
                    _npcRecord.CR = _Dumplines[i].Split(' ')[1].Trim();
                    _npcNames.Add(_npcRecord);
                    _npcRecord = new NPCRecord();
                    i++;
                }
                
                if (string.IsNullOrEmpty(_Dumplines[i]) && i + 1 != _Dumplines.Count)
                {
                    i++;
                    _npcRecord.Name = _Dumplines[i].Trim();
                    i++;
                    _npcRecord.Class = _Dumplines[i].Split(',')[0].Trim().Split(' ')[1].Trim();
                }
                if (_Dumplines[i].Contains("Challenge"))
                {
                    _npcRecord.CR = _Dumplines[i].Split(' ')[1].Trim();
                    _npcNames.Add(_npcRecord);
                    _npcRecord = new NPCRecord();
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

        public List<TextRecord> getTextRecords(string _inputLocation)
        {
            List<TextRecord> _textRecords = new List<TextRecord>();
            List<string> _Dumplines = new List<string>();
            var _lines = File.ReadLines(_inputLocation);

            foreach (string item in _lines)
            {
                _Dumplines.Add(item);
            }

            string header = string.Empty;

            for (int i = 0; i < _Dumplines.Count; i++)
            {
                if (_Dumplines[i].Contains("#@;"))
                {
                    header = _Dumplines[i].Replace("#@;","").Trim();
                }
                if (_Dumplines[i].Contains("##;"))
                {
                    _textRecords.Add(new TextRecord()
                    {
                        Header = header,
                        Title = _Dumplines[i].Replace("##;", "").Trim()
                    });
                }
            }

            return _textRecords;
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
    public class TextRecord
    {
        public string Header { get; set; }
        public string Title { get; set; }
    }
    public class NPCRecord
    {
        public string Name { get; set; }        
        public string CR { get; set; }
        public string Class { get; set; }
    }
}

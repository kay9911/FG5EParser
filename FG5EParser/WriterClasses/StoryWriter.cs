using FG5EParser.Base_Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.WriterClasses
{
    class StoryWriter
    {
        public List<StoryElements> compileStoryList(string _inputLocation, string _moduleName)
        {
            try
            {
                var _lines = File.ReadLines(_inputLocation);
                List<string> _basic = new List<string>();
                List<StoryElements> _storyList = new List<StoryElements>();

                string StoryHeader = string.Empty;

                #region Populating the basic list

                foreach (var _line in _lines)
                {
                    if (!String.IsNullOrWhiteSpace(_line))
                    {
                        _basic.Add(_line);
                        if (_line.Contains("#@;"))
                        {
                            StoryHeader = _line.Replace("#@;", "");
                        }
                    }
                    else
                    {
                        // Send for processing
                        StoryElements _storyElements = new StoryElements();
                        if (_basic.Count != 0)
                        {
                            _storyElements = _storyElements.bindValues(_basic, StoryHeader, _moduleName);
                            _storyList.Add(_storyElements);
                        }
                        _basic.Clear();
                    }
                }

                // If there is just one entry or the last entry
                if (!string.IsNullOrEmpty(_basic.ToString()))
                {
                    StoryElements _storyElements = new StoryElements();
                    if (_basic.Count != 0)
                    {
                        _storyElements = _storyElements.bindValues(_basic, StoryHeader, _moduleName);
                        _storyList.Add(_storyElements);
                    }
                    _basic.Clear();
                }
                #endregion

                return _storyList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

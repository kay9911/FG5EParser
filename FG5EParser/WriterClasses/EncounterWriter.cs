using FG5EParser.Base_Class;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace FG5EParser.WriterClasses
{
    class EncounterWriter
    {
        public List<Encounters> compileEncounterList(string _inputLocation, string _moduleName)
        {
            try
            {
                var _lines = File.ReadLines(_inputLocation);
                List<string> _basic = new List<string>();
                List<Encounters> _encounterList = new List<Encounters>();

                TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;

                string EncounterHeader = string.Empty;
                Encounters _encounter = new Encounters();

                foreach (var _line in _lines)
                {
                    // Check to see if hearder has come up
                    if (_line.Contains("#@;"))
                    {
                        // Send for processing
                        if (_basic.Count != 0)
                        {
                            _encounterList.AddRange(_encounter.bindValues(_basic, _textInfo.ToTitleCase(EncounterHeader.ToLower().Trim()), _moduleName));
                        }
                        _basic = new List<string>();
                        // Make header
                        EncounterHeader = _line.Replace("#@;", "").Trim();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(_line) && !_line.Contains("Its done!"))
                        {
                            _basic.Add(_line);
                        }
                    }
                }

                // Catch the last bit of entries out of the loop
                if (_basic.Count != 0)
                {
                    _encounterList.AddRange(_encounter.bindValues(_basic, _textInfo.ToTitleCase(EncounterHeader.ToLower().Trim()), _moduleName));
                }

                return _encounterList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

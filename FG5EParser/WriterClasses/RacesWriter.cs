using FG5EParser.Base_Class;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.WriterClasses
{
    class RacesWriter
    {
        public List<Races> compileRaceList(string _inputLocation, string _moduleName)
        {
            try
            {
                var _lines = File.ReadLines(_inputLocation);
                List<string> _basic = new List<string>();
                List<Races> _raceList = new List<Races>();

                TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;

                Races _race = new Races();

                foreach (var _line in _lines)
                {
                    // Check to see if hearder has come up
                    if (_line.Contains("##;"))
                    {
                        // Send for processing
                        if (_basic.Count != 0)
                        {
                            _raceList.AddRange(_race.bindValues(_basic, _moduleName));
                        }
                        _basic = new List<string>();
                        _basic.Add(_line);
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
                    _raceList.AddRange(_race.bindValues(_basic, _moduleName));
                }

                return _raceList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

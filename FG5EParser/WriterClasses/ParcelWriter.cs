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
    class ParcelWriter
    {
        public List<Parcles> compileParcelList(string _inputLocation, string _moduleName)
        {
            try
            {
                var _lines = File.ReadLines(_inputLocation);
                List<string> _basic = new List<string>();
                List<Parcles> _parcleList = new List<Parcles>();

                TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;

                string ParcleHeader = string.Empty;
                Parcles _parcle = new Parcles();

                foreach (var _line in _lines)
                {
                    // Check to see if hearder has come up
                    if (_line.Contains("#@;"))
                    {
                        // Send for processing
                        if (_basic.Count != 0)
                        {
                            _parcleList.AddRange(_parcle.bindValues(_basic, _textInfo.ToTitleCase(ParcleHeader.ToLower().Trim()), _moduleName));
                        }
                        _basic = new List<string>();
                        // Make header
                        ParcleHeader = _line.Replace("#@;", "").Trim();
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
                    _parcleList.AddRange(_parcle.bindValues(_basic, _textInfo.ToTitleCase(ParcleHeader.ToLower().Trim()), _moduleName));
                }

                return _parcleList;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

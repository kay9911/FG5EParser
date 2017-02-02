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
    class BackgroundWriter
    {
        public List<Backgrounds> compileBackgroundList(string _inputLocation, string moduleName)
        {
            try
            {
                var _lines = File.ReadLines(_inputLocation);
                List<string> _basic = new List<string>();
                List<Backgrounds> _backgroundList = new List<Backgrounds>();

                TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;

                //string TableHeader = string.Empty;
                Backgrounds _background = new Backgrounds();

                foreach (var _line in _lines)
                {
                    if (_line.Contains("##;"))
                    {
                        // Send for processing
                        if (_basic.Count != 0)
                        {
                            _backgroundList.AddRange(_background.bindValues(_basic, moduleName));
                        }
                        _basic.Clear();
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
                    _backgroundList.AddRange(_background.bindValues(_basic, moduleName));
                }

                return _backgroundList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

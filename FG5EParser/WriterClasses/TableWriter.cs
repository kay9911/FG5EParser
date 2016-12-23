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
    class TableWriter
    {
        public List<RollableTables> compileTableList(string _inputLocation, string _moduleName)
        {
            try
            {
                var _lines = File.ReadLines(_inputLocation);
                List<string> _basic = new List<string>();
                List<RollableTables> _tableList = new List<RollableTables>();

                TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;

                string TableHeader = string.Empty;
                RollableTables _table = new RollableTables();

                foreach (var _line in _lines)
                {
                    // Check to see if hearder has come up
                    if (_line.Contains("#@;"))
                    {
                        // Send for processing
                        if (_basic.Count != 0)
                        {
                            _tableList.AddRange(_table.bindValues(_basic, _textInfo.ToTitleCase(TableHeader.ToLower().Trim()), _moduleName));
                        }
                        _basic = new List<string>();
                        // Make header
                        TableHeader = _line.Replace("#@;", "").Trim();
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
                    _tableList.AddRange(_table.bindValues(_basic, _textInfo.ToTitleCase(TableHeader.ToLower().Trim()), _moduleName));
                }

                return _tableList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

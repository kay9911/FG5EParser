using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FG5EParser.Base_Class;
using System.IO;
using System.Globalization;

namespace FG5EParser.WriterClasses
{
    class ItemWriter
    {
        public List<Items> compileItemList(string _inputLocation, string _moduleName)
        {
            try
            {
                var _lines = File.ReadLines(_inputLocation);
                List<string> _basic = new List<string>();
                List<Items> _itemList = new List<Items>();

                TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;

                string ItemHeader = string.Empty;
                Items _item = new Items();

                foreach (var _line in _lines)
                {
                    // Check to see if hearder has come up
                    if (_line.Contains("#@;"))
                    {
                        // Send for processing
                        if (_basic.Count != 0)
                        {
                            _itemList.AddRange(_item.bindValues(_basic, _textInfo.ToTitleCase(ItemHeader.ToLower().Trim()), _moduleName));
                        }
                        _basic = new List<string>();
                        // Make header
                        ItemHeader = _line.Replace("#@;", "").Trim();
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
                    _itemList.AddRange(_item.bindValues(_basic, _textInfo.ToTitleCase(ItemHeader.ToLower().Trim()), _moduleName));
                }

                return _itemList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

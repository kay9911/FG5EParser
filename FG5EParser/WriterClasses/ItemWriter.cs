using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FG5EParser.Base_Class;
using System.IO;

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

                string ItemHeader = string.Empty;

                // Bool Counter
                bool hasHeader = false;

                foreach (var _line in _lines)
                {
                    // Check for process condition
                    if (!hasHeader)
                    {
                        if (_line.Contains("#@;"))
                        {
                            _basic.Add(_line);
                            if (_line.Contains("#@;"))
                            {
                                ItemHeader = _line.Replace("#@;", "");
                            }
                        }
                    }
                    else
                    {
                        // Revert counter
                        hasHeader = false;

                        // Send for processing
                        Items _item = new Items();
                        if (_basic.Count != 0)
                        {
                            _itemList.AddRange(_item.bindValues(_basic, ItemHeader, _moduleName));
                        }
                        _basic.Clear();
                    }

                    // Keep track until we hit another header
                    if (_line.Contains("#@;"))
                    {
                        hasHeader = true;
                    }
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

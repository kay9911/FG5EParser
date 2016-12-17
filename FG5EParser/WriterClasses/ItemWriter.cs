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

                // Assigning the item descriptions
                for (int i = 0; i < _basic.Count; i++)
                {
                    // Sub type bulk update
                    if (_basic[i].Contains("#stt;"))
                    {
                        string _temp = _basic[i].Replace("#stt;","");

                        List<Items> _itemDesc = _itemList.Where(x => x.Subtype == _temp.Split('.')[0].Trim()).ToList();

                        // Assign the descriptions
                        foreach (Items _items in _itemDesc)
                        {
                            _items.Description = _temp.Replace(_temp.Split('.')[0].Trim() + ".", "").Trim();
                        }
                    }
                    else if (_basic[i].Contains("."))
                    {
                        Items _itemDesc = _itemList.Where(x => x.Name == _basic[i].Split('.')[0].Trim()).FirstOrDefault();
                        if (_itemDesc != null)
                        {
                            _itemDesc.Description = _basic[i].Replace(_basic[i].Split('.')[0].Trim() + ".","").Trim();

                            // Check to see if this is an Equipment Pack
                            if (_basic[i + 1].Contains("#si;"))
                            {
                                string _temp = _basic[i + 1].Replace("#si;","");

                                // Seperate the list
                                List<string> _packagedGoods = _temp.Split(';').ToList();

                                Subitems _subItem = new Subitems();

                                foreach (string _packageGood in _packagedGoods)
                                {
                                    _subItem.Count = _packageGood.Split('.')[0].Trim();
                                    _subItem.ItemName = _packageGood.Split('.')[1].Trim();

                                    _itemDesc.Subitems.Add(_subItem);

                                    _subItem = new Subitems();
                                }
                                // Increase the index counter
                                i++;
                            }
                        }
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

    class MagicalItemWriter
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
                            _itemList.AddRange(_item.bindMagicalValues(_basic, _textInfo.ToTitleCase(ItemHeader.ToLower().Trim()), _moduleName));
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
                    _itemList.AddRange(_item.bindMagicalValues(_basic, _textInfo.ToTitleCase(ItemHeader.ToLower().Trim()), _moduleName));
                }

                // Assigning the item descriptions
                for (int i = 0; i < _basic.Count; i++)
                {
                    // Sub type bulk update
                    if (_basic[i].Contains("#stt;"))
                    {
                        string _temp = _basic[i].Replace("#stt;", "");

                        List<Items> _itemDesc = _itemList.Where(x => x.Subtype == _temp.Split('.')[0].Trim()).ToList();

                        // Assign the descriptions
                        foreach (Items _items in _itemDesc)
                        {
                            _items.Description = _temp.Replace(_temp.Split('.')[0].Trim() + ".", "").Trim();
                        }
                    }
                    else if (_basic[i].Contains("."))
                    {
                        Items _itemDesc = _itemList.Where(x => x.Name == _basic[i].Split('.')[0].Trim()).FirstOrDefault();
                        if (_itemDesc != null)
                        {
                            _itemDesc.Description = _basic[i].Replace(_basic[i].Split('.')[0].Trim() + ".", "").Trim();

                            // Check to see if there are anymore lines before we can do this
                            if (i + 1 < _basic.Count)
                            {
                                // Check to see if this is an Equipment Pack
                                if (_basic[i + 1].Contains("#si;"))
                                {
                                    string _temp = _basic[i + 1].Replace("#si;", "");

                                    // Seperate the list
                                    List<string> _packagedGoods = _temp.Split(';').ToList();

                                    Subitems _subItem = new Subitems();

                                    foreach (string _packageGood in _packagedGoods)
                                    {
                                        _subItem.Count = _packageGood.Split('.')[0].Trim();
                                        _subItem.ItemName = _packageGood.Split('.')[1].Trim();

                                        _itemDesc.Subitems.Add(_subItem);

                                        _subItem = new Subitems();
                                    }
                                    // Increase the index counter
                                    i++;
                                }
                            } // else skip this step otherwise we're gonna get a out of range exception
                        }
                    }
                }

                return _itemList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

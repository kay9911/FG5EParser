using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FG5EParser.Base_Class;
using System.IO;
using System.Globalization;
using FG5EParser.Utilities;
using FG5eParserModels.DM_Modules;

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

                            // Check to see if this is an Equipment Pack
                            if (i != _basic.Count - 1 && _basic[i + 1].Contains("#si;"))
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
                        }
                    }
                }

                return _itemList;
            }
            catch (Exception)
            {
                throw;
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
                    else if (_basic[i].Contains("#desc;"))
                    {
                        Items _itemDesc = new Items();
                        StringBuilder desc = new StringBuilder();
                        XMLFormatting _xml = new XMLFormatting();

                        desc.Append(_xml.returnFormattedString("#h;Description", _moduleName));

                        for (int j = i; j < _basic.Count; j++)
                        {
                            if (_basic[j].Contains("#desc;"))
                            {
                                _itemDesc = _itemList.Where(x => x.Name == _basic[j].Split(';')[1]).FirstOrDefault();
                            }
                            else
                            {
                                desc.Append(_xml.returnFormattedString(_basic[j], _moduleName));
                            }
                            _itemDesc.Description = desc.ToString();
                        }
                    }
                }

                return _itemList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MagicalItems> compileItemListNew(string _inputLocation, string _moduleName)
        {
            var _lines = File.ReadLines(_inputLocation);
            List<string> _dumpLines = new List<string>();
            List<MagicalItems> _itemList = new List<MagicalItems>();

            foreach (var item in _lines)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    _dumpLines.Add(item);
                }
            }

            // Loop over the list of items now and add them to the master list
            foreach (string item in _dumpLines)
            {
                _itemList.Add(new MagicalItems()
                {
                    _Name = item.Split(';')[0],
                    _Type = item.Split(';')[1],
                    _Subtype = item.Split(';')[2],
                    _Category = item.Split(';')[3],
                    _Rarity = item.Split(';')[4],
                    _Cost =  !string.IsNullOrEmpty(item.Split(';')[5]) ? item.Split(';')[5] : "0",
                    _Weight = !string.IsNullOrEmpty(item.Split(';')[6]) ? item.Split(';')[6] : "0",
                    _Properties = item.Split(';')[7],
                    _AC = item.Split(';')[8],
                    _ACBonus = item.Split(';')[9],
                    _DexBonus = item.Split(';')[10],
                    _StrRequired = item.Split(';')[11],
                    _IsStealthDisadvantage = Convert.ToBoolean(item.Split(';')[12]),
                    _Damage = item.Split(';')[13],
                    _DamageBonus = item.Split(';')[14],
                    _UnidenifiedBaseType = item.Split(';')[15],
                    _UnidentifiedDescription = item.Split(';')[16],
                    _Description = formatDescription(item.Split(';')[17], _moduleName)
                });
            }

            return _itemList;
        }

        private string formatDescription(string description, string moduleName)
        {
            StringBuilder _sb = new StringBuilder();
            XMLFormatting _xmlFormatting = new XMLFormatting();

            // Set the escape char back to the correct formatting one
            description = description.Replace("@",";");

            foreach (string item in description.Split(new string[] { "\\r" }, StringSplitOptions.None))
            {
                _sb.Append(string.Format("{0}\r"
                    , _xmlFormatting.returnFormattedString(item, moduleName)
                    ));
            }

            return _sb.ToString();
        }
    }
}

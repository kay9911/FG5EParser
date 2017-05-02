using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FG5eParserModels.Utility_Modules;
using System.IO;

namespace FG5eParserLib.Utility
{
    class Readers
    {
        public ObservableCollection<string> ReadTables(string _inputLocation)
        {
            var _lines = File.ReadLines(_inputLocation);
            ObservableCollection<string> _tableList = new ObservableCollection<string>();

            foreach (var _line in _lines)
            {
                if (_line.Contains("##;"))
                { 
                    _tableList.Add(_line.Replace("##;", ""));
                }
            }
            return _tableList;
        }
    }
}

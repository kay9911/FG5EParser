using FG5eParserModels.Utility_Modules;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FG5EParser.Base_Class
{
    class RollableTables
    {
        public List<Tables> bindValuesNew(List<string> _Basic, string TableHeader, string _moduleName)
        {
            List<Tables> TableList = new List<Tables>();
            Tables _table = new Tables() { _Category = TableHeader };

            for (int i = 0; i < _Basic.Count; i++)
            {
                if (!string.IsNullOrEmpty(_table._Name) && _Basic[i].Contains("##;"))
                {
                    // Add to list here
                    TableList.Add(_table);
                    _table = new Tables() { _Category = TableHeader };
                }
                if (_Basic[i].Contains("##;"))
                {
                    _table._Name = _Basic[i].Replace("##;","").Trim();
                }
                if (_Basic[i].Contains("#!;"))
                {
                    StringBuilder _sb = new StringBuilder();
                    while (!_Basic[i].Contains("column;"))
                    {
                        _sb.Append(_Basic[i].Replace("#!;",""));
                        i++;
                    }
                    _table._Description = _sb.ToString();
                }
                if (_Basic[i].Contains("column;"))
                {
                    _table._Columns = _Basic[i].Replace("column;", "").Trim().Split(';').ToList();
                }
                if (_Basic[i].Contains("dice;"))
                {
                    _table._Dice = _Basic[i].Replace("dice;", "").Trim();
                }
                if (_Basic[i].Contains("row;"))
                {
                    _table._Rows.Add(_Basic[i].Replace("row;", "").Trim());
                }
            }
            if (!string.IsNullOrEmpty(_table._Name))
            {
                // Add to list here
                TableList.Add(_table);
                _table = new Tables() { _Category = TableHeader };
            }
            return TableList;
        }
    }
}

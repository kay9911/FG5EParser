using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.Utilities
{
    class ContextMenuFunctionHelper
    {
        public string returnFormatted(string _toFormat, string Type)
        {
            if (!string.IsNullOrEmpty(_toFormat))
            {
                switch (Type)
                {
                    case "header": return "#h;" + _toFormat.Trim();
                    case "bold": return "#bp;" + _toFormat.Trim();
                    case "list": return getList(_toFormat);
                    case "table": return getTable(_toFormat);

                    default: return string.Empty;
                }
            }
            else
                return string.Empty;
        }

        private string getList(string _toFormat)
        {
            StringBuilder _makeTable = new StringBuilder();

            _makeTable.Append(_toFormat);

            List<string> _builder = new List<string>(_makeTable.ToString().Split(new string[] { "\n" }, StringSplitOptions.None));

            _makeTable = new StringBuilder();

            // First line
            _makeTable.Append("#ls;");
            _makeTable.Append(Environment.NewLine);

            // Rest of the rows
            for (int i = 0; i < _builder.Count; i++)
            {
                _makeTable.Append("#li;" + _builder[i]);
                _makeTable.Append(Environment.NewLine);
            }

            // Last Line
            _makeTable.Append("#le;");

            return _makeTable.ToString();
        }

        private string getTable(string _toFormat)
        {
            StringBuilder _makeTable = new StringBuilder();

            _makeTable.Append(_toFormat);

            List<string> _builder = new List<string>(_makeTable.ToString().Split(new string[] { "\n" }, StringSplitOptions.None));

            for (int i = 0; i < _builder.Count; i++)
            {
                _builder[i] = _builder[i].Replace(" ", ";");
            }

            _makeTable = new StringBuilder();

            // First line
            _makeTable.Append("#ts;");
            _makeTable.Append(Environment.NewLine);

            // Header which will be the first line
            _makeTable.Append("#th;" + _builder[0]);
            _makeTable.Append(Environment.NewLine);

            // Rest of the rows
            for (int i = 1; i < _builder.Count; i++)
            {
                _makeTable.Append("#tr;" + _builder[i]);
                _makeTable.Append(Environment.NewLine);
            }

            // Last Line
            _makeTable.Append("#te;");

            return _makeTable.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creature_Creator.Models
{
    class TableSections
    {
        public string tableHeader { get; set; }
        private List<string> _headers = new List<string>();
        public List<string> headers { get { return _headers; } set { _headers = value; } }

        private List<string> _descriptions = new List<string>();
        public List<string> descriptions { get { return _descriptions; } set { _descriptions = value; } }


        public TableSections processSection(List<string> _tableList)
        {
            TableSections _section = new TableSections();
            // Set the table name
            _section.tableHeader = formatList(_tableList.Find(x => x.StartsWith("#ht;"))).Replace("#ht;","").Trim();
            // Set headers
            List <string> _headerSection = splitParts(formatList(_tableList.Find(x => x.StartsWith("#th;"))));
            _section.headers = _headerSection;
            // Set descriptions
            List<string> _sections = new List<string>();
            for (int i = 0; i < _tableList.Count; i++)
            {
                if (_tableList[i].Contains("#tr;"))
                {
                    foreach (string _str in splitParts(formatList(_tableList[i])))
                    {
                        _section.descriptions.Add(_str);
                    }
                }
            }

            return _section;
        }

        private string formatList(string _tableList)
        {
            _tableList = _tableList.Replace("#ts;", "").Replace("#th;", "").Replace("#te;", "").Replace("#tr;", "");

            return _tableList;
        }

        private List<string> splitParts(string _row)
        {
            string[] _rowArray = _row.Split(';');
            List<string> _returnString = new List<string>();

            for (int i = 0; i < _rowArray.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(_rowArray[i]))
                {
                    _returnString.Add(_rowArray[i]);
                }
            }

            return _returnString;
        }
    }
}

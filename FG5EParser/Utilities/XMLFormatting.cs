using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.Utilities
{
    class XMLFormatting
    {
        public string returnFormattedString(string _toFormat)
        {
            if (_toFormat.Contains("#h;"))
            {
                _toFormat = string.Format("{0}</h>", _toFormat.Replace("#h;", "<h>"));
            }
            else if (_toFormat.Contains("#ts;"))
            {
                _toFormat = string.Format("<table>");
            }
            else if (_toFormat.Contains("#th;"))
            {
                StringBuilder th = new StringBuilder();

                th.Append("<tr decoration=\"underline\">");

                List<string> _th = new List<string>(_toFormat.Split(';'));

                for (int i = 1; i < _th.Count(); i++)
                {
                    if (!string.IsNullOrEmpty(_th[i].ToString()))
                    {
                        th.Append("<td>");

                        th.Append(string.Format("<b>{0}</b>", _th[i].ToString().Trim()));

                        th.Append("</td>");
                    }
                }

                th.Append("</tr>");

                _toFormat = th.ToString();
            }
            else if (_toFormat.Contains("#tr;"))
            {
                StringBuilder th = new StringBuilder();

                th.Append("<tr>");

                List<string> _th = new List<string>(_toFormat.Split(';'));

                for (int i = 1; i < _th.Count(); i++)
                {
                    if (!string.IsNullOrEmpty(_th[i].ToString()))
                    {
                        th.Append("<td>");

                        th.Append(string.Format("{0}", _th[i].ToString().Trim()));

                        th.Append("</td>");
                    }
                }

                th.Append("</tr>");

                _toFormat = th.ToString();
            }
            else if (_toFormat.Contains("#te;"))
            {
                _toFormat = "</table>";
            }
            else if (_toFormat.Contains("#ls;"))
            {
                return "<list>";
            }
            else if (_toFormat.Contains("#li;"))
            {
                _toFormat = _toFormat.Replace("#li;", "");
                return string.Format("<li>{0}</li>", _toFormat.Trim());
            }
            else if (_toFormat.Contains("#le;"))
            {
                return "</list>";
            }
            else if (_toFormat.Contains("#bp;"))
            {
                _toFormat = _toFormat.Replace("#bp;", "");
                _toFormat = string.Format("<p><b>{0}</b></p>",_toFormat);
            }
            else
            {
                _toFormat = string.Format("<p>{0}</p>", _toFormat);
            }

            return _toFormat;
        }
    }
}

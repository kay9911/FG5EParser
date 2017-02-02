using FG5EParser.Base_Class;
using FG5EParser.Utilities;
using FG5EParser.WriterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class BackgroundHelper
    {
        public string returnBackgroundXML(string _backgroundTextPath, string _moduleName, bool isListCall = false)
        {
            StringBuilder xml = new StringBuilder();

            BackgroundWriter _backgroundWriter = new BackgroundWriter();
            List<Backgrounds> _backgrounds = _backgroundWriter.compileBackgroundList(_backgroundTextPath, _moduleName);

            XMLFormatting _xml = new XMLFormatting();

            #region XML REGION

            if (!isListCall)
            {

                xml.Append("<backgrounddata>");

                foreach (Backgrounds _back in _backgrounds)
                {
                    xml.Append(string.Format("<{0}>", _xml.formatXMLCharachters(_back.Name, "IH")));

                    xml.Append(string.Format("<name type=\"string\">{0}</name>", _back.Name));

                    xml.Append(string.Format("<text type=\"formattedtext\">"));

                    // Background Description
                    xml.Append(_back.Description);

                    xml.Append("<h>Proficiencies</h>");

                    if (!string.IsNullOrEmpty(_back.Skills))
                    {
                        xml.Append(string.Format("<p><b>Skills:</b>{0}</p>", _back.Skills));
                    }

                    if (!string.IsNullOrEmpty(_back.Tools))
                    {
                        xml.Append(string.Format("<p><b>Tools:</b>{0}</p>", _back.Tools));
                    }

                    if (!string.IsNullOrEmpty(_back.Languages))
                    {
                        xml.Append(string.Format("<p><b>Languages:</b>{0}</p>", _back.Languages));
                    }

                    if (!string.IsNullOrEmpty(_back.Equipment))
                    {
                        xml.Append(string.Format("<p><b>Equipment:</b>{0}</p>", _back.Equipment));
                    }

                    xml.Append("<h>Features</h>");

                    xml.Append("<listlink>");

                    xml.Append(string.Format("<link class=\"reference_backgroundfeature\" recordname=\"reference.backgrounddata.{0}.features.{1}@{2}\">{3}</link>"
                        , _xml.formatXMLCharachters(_back.Name, "IH")
                        , _xml.formatXMLCharachters(_back.Feature, "IH")
                        , _moduleName
                        , _back.Feature
                        ));

                    xml.Append("</listlink>");

                    xml.Append("<h>Suggested Characteristics</h>");

                    xml.Append(_back.Charachteristics);

                    //xml.Append("<listlink>");

                    //xml.Append("<link class=\"table\" recordname=\"tables.tab_acolytepersonalitytraits@Player Handbook\">Acolyte Personality Traits</link>");

                    //xml.Append("</listlink>");

                    xml.Append("</text>");

                    xml.Append(string.Format("<skill type=\"string\">{0}</skill>", _back.Skills));

                    xml.Append(string.Format("<languages type=\"string\">{0}</languages>", _back.Languages));

                    xml.Append(string.Format("<equipment type=\"string\">{0}</equipment>", _back.Equipment));

                    xml.Append("<features>");

                    xml.Append(string.Format("<{0}>", _xml.formatXMLCharachters(_back.Feature, "IH")));

                    xml.Append(string.Format("<name type=\"string\">{0}</name>", _back.Feature));                    

                    xml.Append(string.Format("<text type=\"formattedtext\">{0}</text>", _back.FeatureDescription));

                    xml.Append(string.Format("</{0}>", _xml.formatXMLCharachters(_back.Feature, "IH")));

                    xml.Append("</features>");

                    xml.Append(string.Format("</{0}>", _xml.formatXMLCharachters(_back.Name, "IH")));
                }

                xml.Append("</backgrounddata>");
            }
            #endregion  
            else
            {
                xml.Append("<backgroundlists>");

                xml.Append("<byletter>");

                xml.Append("<description type=\"string\">Backgrounds</description>");

                xml.Append("<groups>");

                // Now we need to sort by letter
                xml.Append(string.Format("{0}", sortByLetter(_backgrounds, _moduleName)));

                xml.Append("</groups>");

                xml.Append("</byletter>");

                xml.Append("</backgroundlists>");
            }

            return xml.ToString();
        }

        private string sortByLetter(List<Backgrounds> _backgrounds, string _moduleName)
        {
            StringBuilder _sb = new StringBuilder();
            XMLFormatting _xml = new XMLFormatting();
            List<string> alphabets = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            foreach (string _s in alphabets)
            {
                Backgrounds _current = new Backgrounds();

                _current = _backgrounds.Find(x => x.Name.StartsWith(_s) || x.Name.StartsWith(_s.ToLower()));

                if (_current != null)
                {
                    _sb.Append(string.Format("<typeletter{0}>", _s.ToLower()));

                    _sb.Append(string.Format("<description type=\"string\">{0}</description>", _s));

                    _sb.Append("<index>");

                    var _list = _backgrounds.FindAll(x => x.Name.StartsWith(_s)).ToList();

                    // Start returning NPC's based on starting letter

                    while (_list.Count != 0)
                    {
                        _current = _list.First();

                        _sb.Append(string.Format("<{0}>", _xml.formatXMLCharachters(_current.Name,"IH")));

                        _sb.Append("<link type=\"windowreference\">");

                        _sb.Append("<class>reference_background</class>");

                        _sb.Append(string.Format("<recordname>reference.backgrounddata.{0}@{1}</recordname>"
                            , _xml.formatXMLCharachters(_current.Name, "IH")
                            , _moduleName
                            ));

                        _sb.Append("<description>");

                        _sb.Append("<field>name</field>");

                        _sb.Append("</description>");

                        _sb.Append("</link>");

                        _sb.Append("<source type=\"string\" />");

                        _sb.Append(string.Format("</{0}>", _xml.formatXMLCharachters(_current.Name, "IH")));

                        // After processing get rid of it
                        _list.RemoveAt(0);
                    }

                    _sb.Append("</index>");

                    _sb.Append(string.Format("</typeletter{0}>", _s.ToLower()));

                } // end of (_current != null)

            } // end of foreach

            return _sb.ToString();
        }
    }
}

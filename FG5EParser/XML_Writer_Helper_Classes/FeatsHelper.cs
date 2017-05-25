using FG5EParser.Utilities;
using FG5eParserModels.Player_Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class FeatsHelper
    {
        public string returnFeatsXML(
                                List<Feats> _featsList,
                                bool isList = false
        )
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting _xmlFormatting = new XMLFormatting();

            if (!isList)
            {
                #region XML BUILDER NON LIST

                xml.Append("<featdata>");

                foreach (var feat in _featsList)
                {
                    xml.Append(string.Format("<{0}>",_xmlFormatting.formatXMLCharachters(feat._Name,"IH")));

                    xml.Append(string.Format("<name type=\"string\">{0}</name>", feat._Name));

                    if (string.IsNullOrEmpty(feat._Prerequisit))
                    {
                        xml.Append(string.Format("<text type=\"formattedtext\">{0}</text>", feat._Description));
                    }
                    else
                    {
                        xml.Append(string.Format("<text type=\"formattedtext\"><p><i>Prerequisite: {0}</i></p>{1}</text>", feat._Prerequisit, feat._Description));
                    }

                    if (!string.IsNullOrEmpty(feat._Prerequisit))
                    {
                        //<prerequisite type="string">Dexterity 13 or higher</prerequisite>
                        xml.Append(string.Format("<prerequisite type=\"string\">{0}</prerequisite>", feat._Prerequisit));
                    }

                    xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(feat._Name, "IH")));
                }                

                xml.Append("</featdata>");

                #endregion
            }
            else
            {
                // Obtain the Alphabet Headers
                List<string> _headers = FeatListAlphabets(_featsList);

                xml.Append("<featlists>");

                xml.Append("<byletter>");

                xml.Append("<description type=\"string\">Feats</description>");

                xml.Append("<groups>");

                foreach (var letter in _headers)
                {
                    xml.Append(string.Format("<letter{0}>",letter));

                    xml.Append(string.Format("<description type=\"string\">{0}</description>",letter));

                    xml.Append("<feats>");

                    // Get the list of feats that start with the alphabet
                    List<Feats> _lst = _featsList.Where(x => x._Name.StartsWith(letter)).ToList();

                    foreach (var feat in _lst)
                    {
                        xml.Append(string.Format("<{0}>",_xmlFormatting.formatXMLCharachters(feat._Name,"IH")));

                        xml.Append("<link type=\"windowreference\">");

                        xml.Append("<class>reference_feat</class>");

                        xml.Append(string.Format("<recordname>reference.featdata.{0}</recordname>", _xmlFormatting.formatXMLCharachters(feat._Name, "IH")));

                        xml.Append("</link>");

                        xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(feat._Name, "IH")));
                    }

                    xml.Append("</feats>");

                    xml.Append(string.Format("</letter{0}>", letter));
                }

                xml.Append("</groups>");

                xml.Append("</byletter>");

                xml.Append("</featlists>");

            }
            return xml.ToString();
        }

        private List<string> FeatListAlphabets(List<Feats> _featsList)
        {
            List<string> _headers = new List<string>();

            foreach (var feat in _featsList)
            {
                if (!string.IsNullOrEmpty(feat._Name))
                {
                    _headers.Add(feat._Name.Substring(0, 1));
                }
            }

            List<string> _uniqueHeaders = _headers.Distinct().OrderBy(x => x).ToList();

            return _uniqueHeaders;
        }
    }
}

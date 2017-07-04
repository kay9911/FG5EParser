using FG5EParser.Utilities;
using FG5eParserModels.Utility_Modules;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class ImageHelper
    {
        public string returnImageXML(string _imageFileTextPath, List<ImagePins> _imagePinsList, string _moduleName, bool isListCall = false)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting _xmlFormatting = new XMLFormatting();

            if (!isListCall)
            {
                #region NON LIST REGION 

                xml.Append("<image>");
                xml.Append(string.Format("<category name=\"{0}\" baseicon=\"2\" decalicon=\"1\">",_moduleName));

                foreach (string newPath in Directory.GetFiles(_imageFileTextPath, "*.*", SearchOption.AllDirectories))
                {
                    xml.Append(string.Format("<img{0}>",_xmlFormatting.formatXMLCharachters(newPath.Replace(_imageFileTextPath,""),"IH")));

                    xml.Append("<locked type=\"number\">1</locked>");

                    xml.Append(string.Format("<name type=\"string\">{0}</name>", newPath.Replace(_imageFileTextPath + @"\", "").Split('.')[0].Trim()));

                    xml.Append("<image type=\"image\">");

                    xml.Append(string.Format("<bitmap type=\"string\">images/{0}</bitmap>", newPath.Replace(_imageFileTextPath + @"\", "").Trim()));

                    if (_imagePinsList.Count != 0)
                    {
                        xml.Append("<shortcuts>");
                        foreach (var shortcut in _imagePinsList)
                        {
                            if (shortcut._imageName == newPath.Replace(_imageFileTextPath + @"\", "").Split('.')[0].Trim())
                            {
                                xml.Append("<shortcut>");

                                xml.Append(string.Format("<x>{0}</x>", shortcut._x));
                                xml.Append(string.Format("<y>{0}</y>", shortcut._y));
                                xml.Append(string.Format("<class>{0}</class>", shortcut._classType));
                                xml.Append(string.Format("<recordname>{0}</recordname>", shortcut._recordName));

                                xml.Append("</shortcut>");
                            }
                        }
                        xml.Append("</shortcuts>");
                    }

                    xml.Append("</image>");

                    xml.Append(string.Format("</img{0}>", _xmlFormatting.formatXMLCharachters(newPath.Replace(_imageFileTextPath, ""), "IH")));
                }

                xml.Append("</category>");
                xml.Append("</image>");

                #endregion
            }
            else
            {
                #region LIST REGION

                xml.Append("<imagewindow>");

                xml.Append("<name type=\"string\">Images &amp; Maps</name>");

                xml.Append("<index>");

                foreach (string newPath in Directory.GetFiles(_imageFileTextPath, "*.*", SearchOption.AllDirectories))
                {
                    xml.Append(string.Format("<img{0}>", _xmlFormatting.formatXMLCharachters(newPath.Replace(_imageFileTextPath, ""), "IH")));

                    xml.Append(string.Format("<name type=\"string\">{0}</name>", newPath.Replace(_imageFileTextPath + @"\", "").Trim()));

                    xml.Append("<listlink type=\"windowreference\">");

                    xml.Append("<class>imagewindow</class>");

                    xml.Append(string.Format("<recordname>image.img{0}</recordname>"
                        , _xmlFormatting.formatXMLCharachters(newPath.Replace(_imageFileTextPath, ""), "IH")
                        //, _moduleName
                        ));

                    xml.Append("</listlink>");

                    xml.Append(string.Format("</img{0}>", _xmlFormatting.formatXMLCharachters(newPath.Replace(_imageFileTextPath, ""), "IH")));
                }

                xml.Append("</index>");

                xml.Append("</imagewindow>");

                #endregion
            }
            return xml.ToString();
        }
    }
}

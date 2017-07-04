using FG5EParser.Utilities;
using System.IO;
using System.Text;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class ImageHelper
    {
        public string returnImageXML(string _imageFileTextPath, string _moduleName, bool isListCall = false)
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

                    xml.Append(string.Format("<bitmap type=\"string\">image/{0}</bitmap>", newPath.Replace(_imageFileTextPath + @"\", "").Trim()));

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

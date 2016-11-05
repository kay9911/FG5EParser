using FG5EParser.Base_Classes;
using FG5EParser.XML_Writer_Helper_Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FG5EParser.XMLWriters
{
    class BaseWriter
    {
        public XDocument createCommonXML(
            string _moduleName,
            string _catName,
            string _npcTextPath = "",
            string _classTextPath = ""
        )
        {
            StringBuilder xml = new StringBuilder();

            // Module Based Instances
            PersonalitiesHelper _personalitiesHelper = new PersonalitiesHelper();
            ClassHelper _classHelper = new ClassHelper();

            #region XML Header
            xml.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>");
            xml.Append("<root version=\"3.0\">");
            #endregion

            xml.Append("<reference static=\"true\">");

            // Input for personalities
            if (!string.IsNullOrEmpty(_npcTextPath))
            {
                xml.Append(_personalitiesHelper.returnPersonalitiesXML(_npcTextPath, _moduleName));
            }

            // Input for Classes
            if (!string.IsNullOrEmpty(_classTextPath))
            {
                xml.Append(_classHelper.returnClassesXML(_classTextPath, _moduleName));
            }

            xml.Append("</reference>");

            #region Library References

            // Counter
            int index = 1; 

            xml.Append("<library>");

            xml.Append(string.Format("<libn{0}>", _moduleName.Replace(" ", "").Trim().ToLower()));

            xml.Append(string.Format("<name type=\"string\">{0} Reference Library</name>", _moduleName));

            xml.Append(string.Format("<categoryname type=\"string\">{0}</categoryname>", _catName));

            xml.Append("<entries>");

            if (!string.IsNullOrEmpty(_npcTextPath))
            {
                xml.Append(string.Format("<id-0000{0}>", index.ToString()));
                xml.Append("<librarylink type=\"windowreference\">");

                xml.Append("<class>referenceindex</class>");
                xml.Append("<recordname>reference.npclists.npcs</recordname>");

                xml.Append("</librarylink>");
                xml.Append("<name type=\"string\">NPCs</name>");
                xml.Append(string.Format("</id-0000{0}>", index.ToString()));

                // Counter + 1
                index++;
            }

            if (!string.IsNullOrEmpty(_classTextPath))
            {
                xml.Append(string.Format("<id-0000{0}>", index.ToString()));
                xml.Append("<librarylink type=\"windowreference\">");

                xml.Append("<class>reference_colindex</class>");
                xml.Append("<recordname>reference.classlists.byletter</recordname>");

                xml.Append("</librarylink>");
                xml.Append("<name type=\"string\">Classes</name>");
                xml.Append(string.Format("</id-0000{0}>", index.ToString()));

                // Counter + 1
                index++;
            }

            xml.Append("</entries>");

            xml.Append(string.Format("</libn{0}>", _moduleName.Replace(" ", "").Trim().ToLower()));

            xml.Append("</library>");

            #endregion

            xml.Append("</root>");

            XDocument _xml = XDocument.Parse(xml.ToString());
            return _xml;
        }

        public XDocument createDefinationXML(string _moduleName, string _authorName)
        {
            StringBuilder xml = new StringBuilder();

            StringBuilder _defination = new StringBuilder();
            _defination.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>");
            _defination.Append("<root version=\"3.0\">");
            _defination.Append(string.Format("<name>{0}</name>", _moduleName));
            _defination.Append(string.Format("<author>{0}</author>", _authorName));
            _defination.Append("<ruleset>5E</ruleset>");
            _defination.Append("</root>");

            XDocument _xml = XDocument.Parse(_defination.ToString());
            return _xml;
        }
    }
}

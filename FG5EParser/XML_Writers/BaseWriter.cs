using FG5EParser.Base_Classes;
using FG5EParser.XMLWriterHelperClasses;
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
            string _npcTextPath
        )
        {
            StringBuilder xml = new StringBuilder();

            // Module Based Instances
            PersonalitiesHelper _personalitiesHelper = new PersonalitiesHelper();

            #region XML Header
            xml.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>");
            xml.Append("<root version=\"3.0\">");
            #endregion

            // Input for personalities
            if (!string.IsNullOrEmpty(_npcTextPath))
            {
                xml.Append(_personalitiesHelper.returnPersonalitiesXML(_npcTextPath, _moduleName));
            }

            #region Library References
            xml.Append("<library>");
            xml.Append(string.Format("<libn{0}>", _moduleName.Replace(" ", "").Trim().ToLower()));
            xml.Append(string.Format("<name type=\"string\">{0} Reference Library</name>", _moduleName));
            xml.Append(string.Format("<categoryname type=\"string\">{0}</categoryname>", _catName));

            xml.Append("<entries>");

            xml.Append("<id-00001>");
            xml.Append("<librarylink type=\"windowreference\">");

            xml.Append("<class>referenceindex</class>");
            xml.Append("<recordname>reference.npclists.npcs</recordname>");

            xml.Append("</librarylink>");
            xml.Append("<name type=\"string\">NPCs</name>");
            xml.Append("</id-00001>");

            #region Only if there are tables COMMENTED FOR NOW

            //xml.Append("<id-00002>");
            //xml.Append("<librarylink type=\"windowreference\">");

            //xml.Append("<class>reference_colindex</class>");
            //xml.Append(string.Format("<recordname>lists.table.bycategory@{0}</recordname>",_moduleName));

            //xml.Append("</librarylink>");
            //xml.Append("<name type=\"string\">Tables</name>");
            //xml.Append("</id-00002>");
            #endregion

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

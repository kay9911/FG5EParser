using FG5EParser.Utilities;
using FG5EParser.WriterClasses;
using FG5eParserModels.Utility_Modules;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace FG5EParser.XML_Writer_Helper_Classes
{
    class TableHelper
    {
        public string returnTableXML(string _tableTextPath, string _moduleName, bool isListCall = false)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting xmlFormatting = new XMLFormatting();

            TableWriter _tableWriter = new TableWriter();
            List<Tables> _tableList = _tableWriter.compileTableListNew(_tableTextPath, _moduleName);

            // Gather a collection of all category types
            List<string> _categoryTypes = _tableList.Select(x => x._Category).Distinct().ToList();

            if (!isListCall)
            {
                #region XML WRITING REGION

                xml.Append("<tables>");

                // category
                foreach (string _category in _categoryTypes)
                {
                    xml.Append(string.Format("<category name=\"{0}\" baseicon=\"2\" decalicon=\"1\">", _category));

                    foreach (Tables _table in _tableList)
                    {
                        if (_table._Category == _category)
                        {
                            // Name index
                            xml.Append(string.Format("<tab_{0}>", xmlFormatting.formatXMLCharachters(_table._Name, "IH")));

                            // Locked
                            xml.Append(string.Format("<locked type=\"number\">{0}</locked>", 1));

                            // Name
                            xml.Append(string.Format("<name type=\"string\">{0}</name>", _table._Name));

                            // description
                            xml.Append(string.Format("<description type=\"string\">{0}</description>", _table._Description));

                            //notes
                            xml.Append(string.Format("<notes type=\"formattedtext\">{0}</notes>", _table._Note));

                            // roll results
                            xml.Append(string.Format("<hiderollresults type=\"number\">{0}</hiderollresults>", 0));

                            // Mod
                            xml.Append(string.Format("<mod type=\"number\">{0}</mod>",0));

                            // dice
                            xml.Append(string.Format("<dice type=\"dice\">{0}</dice>", _table._Dice));

                            // labels
                            for (int k = 0; k < _table._Columns.Count; k++)
                            {
                                //<labelcol1 type="string">SOmething</labelcol1>
                                xml.Append(string.Format("<labelcol{0} type=\"string\">{1}</labelcol{0}>", k + 1, _table._Columns[k]));
                            }

                            // Resukt cols are the number of columns
                            xml.Append(string.Format("<resultscols type=\"number\">{0}</resultscols>", _table._Columns.Count));

                            xml.Append("<tablerows>");

                            for (int i = 0; i < _table._Rows.Count; i++)
                            {
                                xml.Append(string.Format("<id-{0}>",i+1));

                                xml.Append(string.Format("<fromrange type=\"number\">{0}</fromrange>", _table._Rows[i].Split(';')[0].Trim()));
                                xml.Append("<results>");

                                for (int a = 1; a <= _table._Columns.Count; a++)
                                {
                                    xml.Append(string.Format("<id-{0}>", a));

                                    if (_table._Rows[i].Contains("#zal:"))
                                    {
                                        xml.Append(string.Format("<result type=\"string\">{0}</result>", _table._Rows[i].Split(';')[a + 1].Split(':')[3]));                                        
                                        if (_table._Rows[i].Contains("NPC"))
                                        {
                                            xml.Append("<resultlink type=\"windowreference\">");
                                            xml.Append("<class>npc</class>");
                                            xml.Append(string.Format("<recordname>{0}</recordname>",xmlFormatting.returnFormattedString(_table._Rows[i].Split(';')[a + 1],_moduleName)));
                                            xml.Append("</resultlink>");
                                        }
                                        if (_table._Rows[i].Contains("ST"))
                                        {
                                            xml.Append("<resultlink type=\"windowreference\">");
                                            xml.Append("<class>encounter</class>");
                                            xml.Append(string.Format("<recordname>{0}</recordname>", xmlFormatting.returnFormattedString(_table._Rows[i].Split(';')[a + 1], _moduleName)));
                                            xml.Append("</resultlink>");
                                        }
                                        if (_table._Rows[i].Contains("T"))
                                        {
                                            xml.Append("<resultlink type=\"windowreference\">");
                                            xml.Append("<class>table</class>");
                                            xml.Append(string.Format("<recordname>{0}</recordname>", xmlFormatting.returnFormattedString(_table._Rows[i].Split(';')[a + 1], _moduleName)));
                                            xml.Append("</resultlink>");
                                        }
                                        if (_table._Rows[i].Contains("ENC"))
                                        {
                                            xml.Append("<resultlink type=\"windowreference\">");
                                            xml.Append("<class>battle</class>");
                                            xml.Append(string.Format("<recordname>{0}</recordname>", xmlFormatting.returnFormattedString(_table._Rows[i].Split(';')[a + 1], _moduleName)));
                                            xml.Append("</resultlink>");
                                        }
                                    }
                                    else
                                    {
                                        xml.Append(string.Format("<result type=\"string\">{0}</result>", _table._Rows[i].Split(';')[a+1]));
                                    }

                                    xml.Append(string.Format("</id-{0}>", a));
                                }
                                xml.Append("</results>");
                                xml.Append(string.Format("<torange type=\"number\">{0}</torange>", _table._Rows[i].Split(';')[1].Trim()));

                                xml.Append(string.Format("</id-{0}>", i + 1));
                            }
                            
                            xml.Append("</tablerows>");

                            xml.Append(string.Format("</tab_{0}>", xmlFormatting.formatXMLCharachters(_table._Name, "IH")));
                        }
                    }
                    xml.Append("</category>");
                }
                xml.Append("</tables>");
            }
            #endregion

            else
            {
                xml.Append("<table>");

                xml.Append("<bycategory>");

                xml.Append("<description type=\"string\">Tables</description>");

                xml.Append("<groups>");

                foreach (string _category in _categoryTypes)
                {
                    xml.Append(string.Format("<typecategory{0}>", xmlFormatting.formatXMLCharachters(_category, "IH")));

                    // Name
                    xml.Append(string.Format("<description type=\"string\">{0}</description>", _category));

                    xml.Append("<index>");

                    foreach (Tables _table in _tableList)
                    {
                        if (_table._Category == _category)
                        {
                            xml.Append(string.Format("<tab_{0}>", xmlFormatting.formatXMLCharachters(_table._Name, "IH")));

                            xml.Append("<link type=\"windowreference\">");

                            xml.Append("<class>table</class>");

                            xml.Append(string.Format("<recordname>tables.tab_{0}@{1}</recordname>", xmlFormatting.formatXMLCharachters(_table._Name, "IH"), _moduleName));

                            xml.Append("<description>");

                            xml.Append("<field>name</field>");

                            xml.Append("</description>");

                            xml.Append("</link>");

                            xml.Append("<source type=\"string\"/>");

                            xml.Append(string.Format("</tab_{0}>", xmlFormatting.formatXMLCharachters(_table._Name, "IH")));
                        }
                    }

                    xml.Append("</index>");

                    xml.Append(string.Format("</typecategory{0}>", xmlFormatting.formatXMLCharachters(_category, "IH")));
                }

                xml.Append("</groups>");

                xml.Append("</bycategory>");

                xml.Append("</table>");
            }

            return xml.ToString();
        }
    }
}

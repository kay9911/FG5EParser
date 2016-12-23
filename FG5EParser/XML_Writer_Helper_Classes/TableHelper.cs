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
    class TableHelper
    {
        public string returnTableXML(string _tableTextPath, string _moduleName, bool isListCall = false)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting xmlFormatting = new XMLFormatting();

            TableWriter _tableWriter = new TableWriter();
            List<RollableTables> _tableList = _tableWriter.compileTableList(_tableTextPath, _moduleName);

            // Gather a collection of all category types
            List<string> _categoryTypes = _tableList.Select(x => x.Category).Distinct().ToList();

            if (!isListCall)
            {
                #region XML WRITING REGION

                xml.Append("<tables>");

                // category
                foreach (string _category in _categoryTypes)
                {
                    xml.Append(string.Format("<category name=\"{0}\" baseicon=\"2\" decalicon=\"1\">", _category));

                    foreach (RollableTables _table in _tableList)
                    {
                        if (_table.Category == _category)
                        {
                            // Name index
                            xml.Append(string.Format("<tab_{0}>", xmlFormatting.formatXMLCharachters(_table.Name, "IH")));

                            // Locked
                            xml.Append(string.Format("<locked type=\"number\">{0}</locked>", _table.isLocked));

                            // Name
                            xml.Append(string.Format("<name type=\"string\">{0}</name>", _table.Name));

                            // description
                            xml.Append(string.Format("<description type=\"string\">{0}</description>", _table.Description));

                            //notes
                            xml.Append(string.Format("<notes type=\"formattedtext\">{0}</notes>", _table.Notes));

                            // roll results
                            xml.Append(string.Format("<hiderollresults type=\"number\">{0}</hiderollresults>", _table.HideResults));

                            // Mod
                            xml.Append(string.Format("<mod type=\"number\">{0}</mod>", _table.Mod));

                            // dice
                            xml.Append(string.Format("<dice type=\"dice\">{0}</dice>", _table.Dice));

                            // labels
                            for (int k = 1; k < _table.ColumnLabel.Count +1; k++)
                            {
                                // check to see if its a a black section
                                if (!string.IsNullOrEmpty(_table.ColumnLabel[k-1]))
                                {
                                    xml.Append(string.Format("<labelcol{0} type=\"string\">{1}</labelcol{0}>", k, _table.ColumnLabel[k - 1].Trim()));
                                }
                            }

                            // result cols???
                            xml.Append("<resultscols type=\"number\">1</resultscols>");

                            // Row section

                            xml.Append("<tablerows>");
                            // declare index
                            int i = 1;

                            foreach (TableRows _row in _table.ColumnResults)
                            {
                                //index
                                xml.Append(string.Format("<id-{0}>", i));

                                // from range
                                xml.Append(string.Format("<fromrange type=\"number\">{0}</fromrange>", _row.FromRange));

                                // end range
                                xml.Append(string.Format("<torange type=\"number\">{0}</torange>", _row.ToRange));

                                // results section
                                xml.Append("<results>");

                                for (int j = 0; j < _row.Result.Split(';').Count(); j++)
                                {
                                    // check to see if its a a black section
                                    if (!string.IsNullOrEmpty(_row.Result.Split(';')[j]))
                                    {
                                        xml.Append(string.Format("<id-{0}>", j));

                                        xml.Append("<resultlink type=\"windowreference\">");

                                        xml.Append("<class>reference_tableresult</class>");

                                        //record name

                                        xml.Append(string.Format("<recordname>tables.{0}.tablerows.id-{1}.results.id-{2}@{3}</recordname>"
                                            , string.Format("tab_{0}", xmlFormatting.formatXMLCharachters(_table.Name, "IH"))
                                            , i
                                            , j
                                            , _moduleName
                                            ));

                                        xml.Append("</resultlink>");

                                        xml.Append(string.Format("<result type=\"string\">{0}</result>", _row.Result.Split(';')[j].Trim()));

                                        xml.Append(string.Format("</id-{0}>", j));
                                    }
                                }

                                xml.Append("</results>");

                                xml.Append(string.Format("</id-{0}>", i));
                                i++;
                            }

                            xml.Append("</tablerows>");

                            xml.Append(string.Format("</tab_{0}>", xmlFormatting.formatXMLCharachters(_table.Name, "IH")));
                        }
                    }

                    xml.Append("</category>");
                }

                xml.Append("</tables>");

                #endregion
            }
            else
            {
                xml.Append("<table>");

                xml.Append("<bycategory>");

                xml.Append("<description type=\"string\">Tables</description>");

                xml.Append("<groups>");

                foreach (string _category in _categoryTypes)
                {
                    xml.Append(string.Format("<typecategory{0}>",xmlFormatting.formatXMLCharachters(_category,"IH")));

                    // Name
                    xml.Append(string.Format("<description type=\"string\">{0}</description>", _category));

                    xml.Append("<index>");

                    foreach (RollableTables _table in _tableList)
                    {
                        if (_table.Category == _category)
                        {
                            xml.Append(string.Format("<tab_{0}>",xmlFormatting.formatXMLCharachters(_table.Name,"IH")));

                            xml.Append("<link type=\"windowreference\">");

                            xml.Append("<class>table</class>");

                            xml.Append(string.Format("<recordname>tables.tab_{0}@{1}</recordname>", xmlFormatting.formatXMLCharachters(_table.Name, "IH"), _moduleName));

                            xml.Append("<description>");

                            xml.Append("<field>name</field>");

                            xml.Append("</description>");

                            xml.Append("</link>");

                            xml.Append("<source type=\"string\"/>");

                            xml.Append(string.Format("</tab_{0}>", xmlFormatting.formatXMLCharachters(_table.Name, "IH")));
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

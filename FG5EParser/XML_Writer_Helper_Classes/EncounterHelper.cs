using FG5EParser.Utilities;
using FG5eParserModels.DM_Modules;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class EncounterHelper
    { 
        public string returnEncounterXML(string _encounterTextPath, List<Encounter> _encounterList, string _moduleName, bool isListCall = false)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting xmlFormatting = new XMLFormatting();

            // Gather a collection of all category types
            List<string> _categoryTypes = _encounterList.Select(x => x._Category).Distinct().ToList();


            if (!isListCall)
            {
                #region XML WRITING REGION

                xml.Append("<battle>");

                foreach (string _category in _categoryTypes)
                {
                    if (!string.IsNullOrEmpty(_category))
                    {
                        xml.Append(string.Format("<category name=\"{0} - {1}\" baseicon=\"2\" decalicon=\"1\">", _category, _moduleName));
                    }

                    foreach (Encounter _encounter in _encounterList)
                    {
                        if (_encounter._Category == _category)
                        {
                            // Name Index of the encounter
                            xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_encounter._Name, "IH")));

                            // CR
                            xml.Append(string.Format("<cr type=\"string\">{0}</cr>", _encounter._CR));
                            // XP
                            xml.Append(string.Format("<exp type=\"number\">{0}</exp>", _encounter._XP));

                            xml.Append(string.Format("<locked type=\"number\">{0}</locked>", 1));
                            // Name
                            xml.Append(string.Format("<name type=\"string\">{0}</name>", _encounter._Name));

                            // Adding the NPC list
                            xml.Append("<npclist>");
                            foreach (NPCList _npc in _encounter._NpcList)
                            {
                                // Name Index
                                xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_npc._Name, "IH")));

                                //Count
                                xml.Append(string.Format("<count type=\"number\">{0}</count>", _npc._Count));

                                xml.Append("<link type=\"windowreference\">");

                                xml.Append("<class>npc</class>");

                                xml.Append(string.Format("<recordname>reference.npcdata.{0}@{1}</recordname>", _npc._Name.ToLower().Replace(" ","").Trim(), _moduleName));

                                xml.Append("</link>");

                                // NPC Name
                                xml.Append(string.Format("<name type=\"string\">{0}</name>", !string.IsNullOrEmpty(_npc._UniqueName) ? _npc._UniqueName : _npc._Name));
                                // Token
                                xml.Append(string.Format("<token type=\"token\">{0}</token>", _npc._Token));

                                xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_npc._Name, "IH")));
                            }
                            xml.Append("</npclist>");

                            xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_encounter._Name, "IH")));
                        }
                    }
                    // close category
                    xml.Append("</category>");
                }

                xml.Append("</battle>");

                #endregion
            }
            else
            {
                xml.Append("<battle>");

                xml.Append("<bycategory>");

                xml.Append("<description type=\"string\">Encounters</description>");

                xml.Append("<groups>");

                foreach (string _category in _categoryTypes)
                {
                    xml.Append(string.Format("<typecategory{0}>", xmlFormatting.formatXMLCharachters(_category, "IH")));

                    xml.Append(string.Format("<description type=\"string\">{0}</description>", _category));

                    xml.Append("<index>");

                    foreach (Encounter _encounter in _encounterList)
                    {
                        if (_encounter._Category == _category)
                        {
                            // Name Index
                            xml.Append(string.Format("<enc_{0}>", xmlFormatting.formatXMLCharachters(_encounter._Name, "IH")));

                            xml.Append("<link type=\"windowreference\">");

                            xml.Append("<class>battle</class>");

                            xml.Append(string.Format("<recordname>battle.{0}@{1}</recordname>"
                                , xmlFormatting.formatXMLCharachters(_encounter._Name, "IH")
                                , _moduleName
                                ));

                            xml.Append("<description>");

                            xml.Append("<field>name</field>");

                            xml.Append("</description>");

                            xml.Append("</link>");

                            xml.Append("<source type=\"string\" />");

                            xml.Append(string.Format("</enc_{0}>", xmlFormatting.formatXMLCharachters(_encounter._Name, "IH")));
                        }
                    }

                    xml.Append("</index>");

                    xml.Append(string.Format("</typecategory{0}>", xmlFormatting.formatXMLCharachters(_category, "IH")));
                }

                xml.Append("</groups>");

                xml.Append("</bycategory>");

                xml.Append("</battle>");
            }

            return xml.ToString();
        }
    }
}

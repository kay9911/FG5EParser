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
    class EncounterHelper
    { 
        public string returnEncounterXML(string _encounterTextPath, string _moduleName, bool isListCall = false)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting xmlFormatting = new XMLFormatting();

            EncounterWriter _encounterWriter = new EncounterWriter();
            List<Encounters> _encounterList = _encounterWriter.compileEncounterList(_encounterTextPath, _moduleName);

            // Gather a collection of all category types
            List<string> _categoryTypes = _encounterList.Select(x => x.Category).Distinct().ToList();


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

                    foreach (Encounters _encounter in _encounterList)
                    {
                        if (_encounter.Category == _category)
                        {
                            // Name Index of the encounter
                            xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_encounter.Name, "IH")));

                            // CR
                            xml.Append(string.Format("<cr type=\"string\">{0}</cr>", _encounter.CR.Trim()));
                            // XP
                            xml.Append(string.Format("<exp type=\"number\">{0}</exp>", _encounter.Exp.Trim()));

                            xml.Append(string.Format("<locked type=\"number\">{0}</locked>", _encounter.isLocked));
                            // Name
                            xml.Append(string.Format("<name type=\"string\">{0}</name>", _encounter.Name.Trim()));

                            // Adding the NPC list
                            xml.Append("<npclist>");
                            foreach (EncounterNPC _npc in _encounter.NPCList)
                            {
                                // Name Index
                                xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_npc.Name, "IH")));

                                //Count
                                xml.Append(string.Format("<count type=\"number\">{0}</count>", _npc.Count));

                                xml.Append("<link type=\"windowreference\">");

                                xml.Append("<class>npc</class>");

                                xml.Append(string.Format("<recordname>reference.npcdata.{0}@{1}</recordname>", _npc.Name.ToLower(), _moduleName));

                                xml.Append("</link>");

                                // NPC Name
                                xml.Append(string.Format("<name type=\"string\">{0}</name>", _npc.Name));
                                // Token
                                xml.Append(string.Format("<token type=\"token\">{0}</token>", _npc.Token));

                                xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_npc.Name, "IH")));
                            }
                            xml.Append("</npclist>");

                            xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_encounter.Name, "IH")));
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

                    xml.Append(string.Format("<description type=\"string\">{0}</description>",_category));

                    xml.Append("<index>");

                    foreach (Encounters _encounter in _encounterList)
                    {
                        if (_encounter.Category == _category)
                        {
                            // Name Index
                            xml.Append(string.Format("<enc_{0}>", xmlFormatting.formatXMLCharachters(_encounter.Name, "IH")));

                            xml.Append("<link type=\"windowreference\">");

                            xml.Append("<class>battle</class>");

                            xml.Append(string.Format("<recordname>battle.{0}@{1}</recordname>"
                                , xmlFormatting.formatXMLCharachters(_encounter.Name, "IH")
                                , _moduleName
                                ));

                            xml.Append("<description>");

                            xml.Append("<field>name</field>");

                            xml.Append("</description>");

                            xml.Append("</link>");

                            xml.Append("<source type=\"string\" />");

                            xml.Append(string.Format("</enc_{0}>", xmlFormatting.formatXMLCharachters(_encounter.Name, "IH")));
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

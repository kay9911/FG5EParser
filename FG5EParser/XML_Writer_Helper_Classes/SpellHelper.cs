using FG5EParser.Utilities;
using FG5EParser.WriterClasses;
using FG5eParserModels.Player_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class SpellHelper
    {
        public string returnSpellsXML(
            List<Spells> _spellList,
            bool isList = false            
        )
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting _xmlFormatting = new XMLFormatting();

            if (!isList)
            {
                #region XML BUILDER NON LIST
                xml.Append("<spelldata>");
                foreach (var spell in _spellList)
                {
                    xml.Append(string.Format("<{0}>", _xmlFormatting.formatXMLCharachters(spell._Name, "IH")));

                    //<name type="string">Conjure Lesser Demon</name>
                    xml.Append(string.Format("<name type=\"string\">{0}</name>", spell._Name));
                    //<locked type="number">1</locked>
                    xml.Append("<locked type=\"number\">1</locked>");
                    // <level type="number">3</level>
                    xml.Append(string.Format("<level type=\"number\">{0}</level>", spell._Level));
                    // <school type="string">Conjuration</school>
                    xml.Append(string.Format("<school type=\"string\">{0}</school>", spell._School));
                    // <castingtime type="string">1 action</castingtime>
                    xml.Append(string.Format("<castingtime type=\"string\">{0}</castingtime>", spell._CastingTime));
                    // <range type="string">60 feet</range>
                    xml.Append(string.Format("<range type=\"string\">{0}</range>", spell._Range));
                    // <components type="string">V, S, M (a vial of blood from an intelligent humanoid killed within the past 24 hours)</components>
                    xml.Append(string.Format("<components type=\"string\">{0}</components>", spell._Components));
                    // <duration type="string">Concentration, up to 1 hour</duration>
                    xml.Append(string.Format("<duration type=\"string\">{0}</duration>", spell._Duration));
                    // Description
                    xml.Append(string.Format("<description type=\"formattedtext\">{0}</description>", spell._Description));
                    // <source type="string">Sorcerer, Wizard</source>
                    xml.Append(string.Format("<source type=\"string\">{0}</source>", spell._Source));

                    xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(spell._Name, "IH")));
                }
                xml.Append("</spelldata>");
                #endregion
            }
            else
            {
                List<string> _headers = SpellListHeaders(_spellList);

                #region XML BUILDER LIST

                xml.Append("<spells>");

                xml.Append("<byclass>");

                xml.Append("<name type=\"string\">Spells by Class</name>");

                xml.Append("<index>");

                // Header Section
                foreach (var header in _headers)
                {
                    xml.Append(string.Format("<{0}>",_xmlFormatting.formatXMLCharachters(header,"IH")));

                    //<name type="string">Bard</name>
                    xml.Append(string.Format("<name type=\"string\">{0}</name>",header));

                    xml.Append("<listlink type=\"windowreference\">");

                    xml.Append("<class>reference_colindex</class>");

                    xml.Append(string.Format("<recordname>lists.spells.byclass.{0}</recordname>", _xmlFormatting.formatXMLCharachters(header, "IH")));

                    xml.Append("</listlink>");

                    xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(header, "IH")));
                }

                xml.Append("</index>");

                // Linked Lists

                foreach (var header in _headers)
                {
                    xml.Append(string.Format("<{0}>", _xmlFormatting.formatXMLCharachters(header, "IH")));

                    xml.Append(string.Format("<description type=\"string\">{0}</description>",header));

                    xml.Append("<groups>");

                    for (int i = 0; i <= 9; i++)
                    {
                        xml.Append(string.Format("<level{0}>", i));

                        xml.Append(string.Format("<description type=\"string\">{0}</description>",
                            i == 0 ? "Cantrips" : string.Format("Level {0} Spells", i)
                            ));

                        xml.Append("<index>");

                        // Adding spells according to level
                        foreach (var spell in _spellList)
                        {
                            if (string.IsNullOrEmpty(spell._Source) || string.IsNullOrEmpty(spell._Level))
                            {
                                // SKIP THIS SPELL
                                Console.Write(spell._Name);
                            }
                            else
                            {
                                if (spell._Source.Contains(header) && spell._Level == i.ToString())
                                {
                                    xml.Append(string.Format("<{0}>", _xmlFormatting.formatXMLCharachters(spell._Name, "IH")));

                                    xml.Append("<link type=\"windowreference\">");

                                    xml.Append("<class>reference_spell</class>");

                                    xml.Append(string.Format("<recordname>reference.spelldata.{0}</recordname>", _xmlFormatting.formatXMLCharachters(spell._Name, "IH")));

                                    xml.Append("</link>");

                                    xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(spell._Name, "IH")));
                                }
                            }
                        }

                        xml.Append("</index>");

                        xml.Append(string.Format("</level{0}>", i));
                    }

                    xml.Append("</groups>");

                    xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(header, "IH")));
                }

                xml.Append("</byclass>");

                xml.Append("</spells>");

                #endregion
            }
            return xml.ToString();
        }

        private List<string> SpellListHeaders(List<Spells> _spellList)
        {
            List<string> _headers = new List<string>();

            foreach (var spell in _spellList)
            {

                // If there is no Source skip the spell
                if (!string.IsNullOrEmpty(spell._Source))
                {
                    if (spell._Source.Contains(","))
                    {
                        for (int i = 0; i < spell._Source.Split(',').Length; i++)
                        {
                            _headers.Add(spell._Source.Split(',')[i].Trim());
                        }
                    }
                    else
                    {
                        _headers.Add(spell._Source.Trim());
                    }
                }
            }

            List<string> _uniqueHeaders = _headers.Distinct().OrderBy(x => x).ToList();

            return _uniqueHeaders;
        }
    }
}

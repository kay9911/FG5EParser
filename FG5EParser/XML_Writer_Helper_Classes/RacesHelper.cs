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
    class RacesHelper
    {
        public string returnRaceXML(string _racesTextPath, string _moduleName, bool isListCall = false)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting _xmlFormatting = new XMLFormatting();

            RacesWriter _raceWriter = new RacesWriter();
            List<Races> _raceList = _raceWriter.compileRaceList(_racesTextPath, _moduleName);

            if (!isListCall)
            {
                #region NON LIST REGION

                xml.Append("<racedata>");

                // Iterate over all the races
                foreach (Races _race in _raceList)
                {
                    // Opening Tag
                    xml.Append(string.Format("<{0}>",_xmlFormatting.formatXMLCharachters(_race.Name,"IH")));

                    // Race Name
                    xml.Append(string.Format("<name type=\"string\">{0}</name>",_race.Name));

                    // Race Description
                    xml.Append(string.Format("<text type=\"formattedtext\">{0}",_race.Description));

                    // Create the list of traits for the description
                    xml.Append("<listlink>");

                    foreach (String _trait in _race.Traits)
                    {
                        xml.Append(string.Format("<link class=\"reference_racialtrait\" recordname=\"reference.racedata.{0}.traits.{1}@{2}\">{3}</link>"
                            , _xmlFormatting.formatXMLCharachters(_race.Name, "IH")
                            , _xmlFormatting.formatXMLCharachters(_trait.Replace("#!;", "").Split('.')[0], "IH")
                            , _moduleName
                            , _trait.Replace("#!;", "").Split('.')[0]
                            ));
                    }

                    xml.Append("</listlink>");

                    xml.Append("</text>");

                    // Traits Section
                    xml.Append("<traits>");

                    // Iterate over the traits
                    foreach (String _trait in _race.Traits)
                    {
                        // Trait Header
                        xml.Append(string.Format("<{0}>",_xmlFormatting.formatXMLCharachters(_trait.Replace("#!;", "").Split('.')[0],"IH")));

                        // Name
                        xml.Append(string.Format("<name type=\"string\">{0}</name>", _trait.Replace("#!;", "").Split('.')[0]));

                        // Description
                        xml.Append(string.Format("<text type=\"formattedtext\">{0}</text>", _trait.Replace(_trait.Split('.')[0] + ".", "")));

                        // Trait Footer
                        xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(_trait.Replace("#!;", "").Split('.')[0], "IH")));
                    }

                    xml.Append("</traits>");

                    // Check for subraces
                    if (_race.Subraces.Count != 0)
                    {
                        xml.Append("<subraces>");
                        // Loop over the subraces now
                        foreach (Races _subRace in _race.Subraces)
                        {
                            xml.Append(string.Format("<{0}>", _xmlFormatting.formatXMLCharachters(_subRace.Name, "IH")));

                            xml.Append(string.Format("<name type=\"string\">{0}</name>", _subRace.Name));

                            xml.Append(string.Format("<text type=\"formattedtext\">{0}", _subRace.Description));

                            // Create the list of traits for the description
                            xml.Append("<listlink>");

                            foreach (String _trait in _subRace.Traits)
                            {
                                xml.Append(string.Format("<link class=\"reference_subracialtrait\" recordname=\"reference.racedata.{0}.subraces.{1}.traits.{2}@{3}\">{4}</link>"
                                    , _xmlFormatting.formatXMLCharachters(_race.Name, "IH")
                                    , _xmlFormatting.formatXMLCharachters(_subRace.Name, "IH")
                                    , _xmlFormatting.formatXMLCharachters(_trait.Replace("#!;", "").Split('.')[0], "IH")
                                    , _moduleName
                                    , _trait.Replace("#!;", "").Split('.')[0]
                                    ));
                            }

                            xml.Append("</listlink>");

                            xml.Append("</text>");

                            xml.Append("<traits>");

                            foreach (String _trait in _subRace.Traits)
                            {
                                // Trait Header
                                xml.Append(string.Format("<{0}>", _xmlFormatting.formatXMLCharachters(_trait.Replace("#!;", "").Split('.')[0], "IH")));

                                // Name
                                xml.Append(string.Format("<name type=\"string\">{0}</name>", _trait.Replace("#!;", "").Split('.')[0]));

                                // Description
                                xml.Append(string.Format("<text type=\"formattedtext\">{0}</text>", _trait.Replace(_trait.Split('.')[0] + ".", "")));

                                // Trait Footer
                                xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(_trait.Replace("#!;", "").Split('.')[0], "IH")));
                            }

                            xml.Append("</traits>");

                            xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(_subRace.Name, "IH")));
                        }

                        xml.Append("</subraces>");
                    }

                    // Closing Tag
                    xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(_race.Name, "IH")));
                }

                xml.Append("</racedata>");

                #endregion

            }
            else
            {
                #region LIST REGION

                xml.Append("<racelists>");

                xml.Append("<byletter>");

                xml.Append("<description type=\"string\">Races</description>");

                xml.Append("<groups>");

                // Now we need to sort by letter
                xml.Append(string.Format("{0}", sortByLetter(_raceList, _moduleName)));

                xml.Append("</groups>");

                xml.Append("</byletter>");

                xml.Append("</racelists>");

                #endregion
            }

            return xml.ToString();
        }

        private string sortByLetter(List<Races> _races, string _moduleName)
        {
            StringBuilder _sb = new StringBuilder();
            XMLFormatting _xml = new XMLFormatting();
            List<string> alphabets = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            foreach (string _s in alphabets)
            {
                Races _current = new Races();

                _current = _races.Find(x => x.Name.StartsWith(_s) || x.Name.StartsWith(_s.ToLower()));

                if (_current != null)
                {
                    _sb.Append(string.Format("<typeletter{0}>", _s.ToLower()));

                    _sb.Append(string.Format("<description type=\"string\">{0}</description>", _s));

                    _sb.Append("<index>");

                    var _list = _races.FindAll(x => x.Name.StartsWith(_s)).ToList();

                    // Start returning NPC's based on starting letter

                    while (_list.Count != 0)
                    {
                        _current = _list.First();

                        _sb.Append(string.Format("<{0}>", _xml.formatXMLCharachters(_current.Name, "IH")));

                        _sb.Append("<link type=\"windowreference\">");

                        _sb.Append("<class>reference_race</class>");

                        _sb.Append(string.Format("<recordname>reference.racedata.{0}@{1}</recordname>"
                            , _xml.formatXMLCharachters(_current.Name, "IH")
                            , _moduleName
                            ));

                        _sb.Append("<description>");

                        _sb.Append("<field>name</field>");

                        _sb.Append("</description>");

                        _sb.Append("</link>");

                        _sb.Append("<source type=\"string\" />");

                        _sb.Append(string.Format("</{0}>", _xml.formatXMLCharachters(_current.Name, "IH")));

                        // After processing get rid of it
                        _list.RemoveAt(0);
                    }

                    _sb.Append("</index>");

                    _sb.Append(string.Format("</typeletter{0}>", _s.ToLower()));

                } // end of (_current != null)

            } // end of foreach

            return _sb.ToString();
        }
    }
}

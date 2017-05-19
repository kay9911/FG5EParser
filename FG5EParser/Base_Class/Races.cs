using FG5EParser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FG5EParser.Base_Class
{
    class Races
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private List<string> TraitDetails = new List<string>();
        public List<String> Traits { get { return TraitDetails; } set { TraitDetails = value; } }

        // For subraces
        private List<Races> SubraceDetails = new List<Races>();
        public List<Races> Subraces { get { return SubraceDetails; } set { SubraceDetails = value; } }

        public List<Races> bindValues(List<string> _Basic, string _moduleName)
        {
            Races _race = new Races();
            List<Races> _raceList = new List<Races>();

            StringBuilder xml = new StringBuilder();
            StringBuilder _sb = new StringBuilder();
            XMLFormatting _xmlFormatting = new XMLFormatting();

            // Variable that will be used in order to process fields that are not mandatory
            string line = _Basic.First();

            while (line != "Its done!")
            {
                // Name of the race
                if (line.Contains("##;"))
                {
                    _race.Name = line.Replace("##;","");
                    line = shiftUp(_Basic);
                }

                // Check for description if any
                while (!line.Contains("#!;") && line != "Its done!")
                {
                    _sb.Append(_xmlFormatting.returnFormattedString(line,_moduleName));
                    line = shiftUp(_Basic);
                }

                // Assign the description
                _race.Description = _sb.ToString();
                _sb.Clear();

                // Traits
                StringBuilder _traits = new StringBuilder();
                while (line != "Its done!" && !line.Contains("#s;"))
                {
                    // Add the existing line
                    _traits.Append(line);
                    line = shiftUp(_Basic);

                    while (!line.Contains("#!;") && line != "Its done!" && !line.Contains("#s;"))
                    {
                        // Adding in line descriptions
                        _traits.Append(_xmlFormatting.returnFormattedString(line, _moduleName));
                        line = shiftUp(_Basic);
                    }

                    // Add the information to the property
                    _race.TraitDetails.Add(_traits.ToString());
                    _traits.Clear();                    
                }

                // Check for Subraces
                while (line != "Its done!" && line.Contains("#s;"))
                {
                    Races _subRace = new Races();
                    _subRace.Name = line.Replace("#s;","");

                    line = shiftUp(_Basic);

                    while (line != "Its done!" && !line.Contains("#s;"))
                    {
                        while (!line.Contains("#!;") && !line.Contains("#s;") && line != "Its done!")
                        {
                            _sb.Append(_xmlFormatting.returnFormattedString(line, _moduleName));
                            line = shiftUp(_Basic);
                        }

                        // Add description
                        _subRace.Description = _sb.ToString();
                        _sb.Clear();

                        // Traits
                        while (line != "Its done!" && !line.Contains("#s;"))
                        {
                            // Add the existing line
                            _traits.Append(line);
                            line = shiftUp(_Basic);

                            while (!line.Contains("#!;") && line != "Its done!" && !line.Contains("#s;"))
                            {
                                // Adding in line descriptions
                                _traits.Append(_xmlFormatting.returnFormattedString(line, _moduleName));
                                line = shiftUp(_Basic);
                            }

                            // Add the information to the property
                            _subRace.TraitDetails.Add(_traits.ToString());
                            _traits.Clear();
                        }
                    }

                    _race.Subraces.Add(_subRace);
                }

                _raceList.Add(_race);
            }

            return _raceList;
        }

        // Makes reading the list variable consistant
        private string shiftUp(List<string> _Basic)
        {
            _Basic.RemoveAt(0);
            if (_Basic.Count != 0)
            {
                return _Basic.First();
            }
            else
            {
                _Basic.Add("Its done!");
                return _Basic.First();
            }
        }
    }
}

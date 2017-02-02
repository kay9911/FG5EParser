using FG5EParser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FG5EParser.Base_Class
{
    class Backgrounds
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Skills { get; set; }
        public string Tools { get; set; }
        public string Languages { get; set; }
        public string Equipment { get; set; }
        public string Feature { get; set; }
        public string FeatureDescription { get; set; }
        public string Charachteristics { get; set; }
        public string Tables { get; set; }

        public List<Backgrounds> bindValues(List<string> _Basic, string _moduleName)
        {
            Backgrounds _backgrounds = new Backgrounds();
            List<Backgrounds> _backgroundsList = new List<Backgrounds>();

            StringBuilder xml = new StringBuilder();
            XMLFormatting _xmlFormatting = new XMLFormatting();

            // Variable that will be used in order to process fields that are not mandatory
            string line = _Basic.First();

            while (line != "Its done!")
            {
                // Get the background Name
                if (line.Contains("##;"))
                {
                    _backgrounds = new Backgrounds();
                    _backgrounds.Name = line.Replace("##;", "");
                    line = shiftUp(_Basic);
                }

                while (line != "Its done!" && !line.Contains("##;"))
                {
                    StringBuilder sb = new StringBuilder();

                    // Check for description
                    while (!line.Contains("Skill Proficiencies:"))
                    {
                        // Send for formatting
                        sb.Append(_xmlFormatting.returnFormattedString(line,_moduleName));                        
                        line = shiftUp(_Basic);
                    }

                    // Add it to the description
                    _backgrounds.Description = sb.ToString();
                    sb.Clear();

                    // skill proffs
                    if (line.Contains("Skill Proficiencies:"))
                    {
                        _backgrounds.Skills = line.Split(':')[1].Trim();
                        line = shiftUp(_Basic);
                    }

                    if (line.Contains("Tool Proficiencies:"))
                    {
                        _backgrounds.Tools = line.Split(':')[1].Trim();
                        line = shiftUp(_Basic);
                    }

                    // Languages
                    if (line.Contains("Languages:"))
                    {
                        _backgrounds.Languages = line.Split(':')[1].Trim();
                        line = shiftUp(_Basic);
                    }

                    // Equips
                    if (line.Contains("Equipment:"))
                    {
                        _backgrounds.Equipment = line.Split(':')[1].Trim();
                        line = shiftUp(_Basic);
                    }

                    // Feature
                    if (line.Contains("Feature:"))
                    {
                        _backgrounds.Feature = line.Split(':')[1].Trim();
                        line = shiftUp(_Basic);
                    }

                    // Feature details
                    while (!line.Contains("Suggested Characteristics"))
                    {
                        // send for formatting
                        sb.Append(_xmlFormatting.returnFormattedString(line,_moduleName));
                        line = shiftUp(_Basic);
                    }

                    // Append the features
                    _backgrounds.FeatureDescription = sb.ToString();
                    sb.Clear();

                    // Charistics
                    while (!line.Contains("##;") && !line.Contains("Its done!"))
                    {
                        if (line.Contains("Suggested Characteristics"))
                        {
                            line = shiftUp(_Basic);
                        }
                        // send for formatting
                        sb.Append(_xmlFormatting.returnFormattedString(line, _moduleName));
                        line = shiftUp(_Basic);
                    }

                    // Add the char
                    _backgrounds.Charachteristics = sb.ToString();
                    sb.Clear();
                }
                // Add the background to the main list
                _backgroundsList.Add(_backgrounds);
            }

            return _backgroundsList;
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

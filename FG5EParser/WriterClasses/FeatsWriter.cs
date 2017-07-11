using FG5EParser.Utilities;
using FG5eParserModels.Player_Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace FG5EParser.WriterClasses
{
    class FeatsWriter
    {
        public List<Feats> compileFeatsList(string _inputLocation, string moduleName)
        {
            try
            {
                XMLFormatting _xmlFormatting = new XMLFormatting();

                // Read lines from file
                var _lines = File.ReadLines(_inputLocation);

                // Local Inits
                List<string> _basic = new List<string>();

                List<Feats> Feats = new List<Feats>();
                Feats _feat = new Feats();

                foreach (var line in _lines)
                {
                    if (line.Contains("##;"))
                    {
                        // Check if a feat has already been entered
                        if (!string.IsNullOrEmpty(_feat._Name))
                        {
                            // Add to list and Refresh
                            Feats.Add(_feat);
                            _feat = new Feats();
                        }
                        _feat._Name = line.Replace("##;", "").Trim();
                    }
                    else if(line.Contains("Prerequisite:"))
                    {
                        _feat._Prerequisit = line.Replace("Prerequisite:", "").Trim();
                    }
                    else
                    {
                        _feat._Description = _feat._Description + _xmlFormatting.returnFormattedString(line, moduleName);
                    }
                }

                // Capture the last one before the list is sent out
                if (!string.IsNullOrEmpty(_feat._Name))
                {
                    // Add to list and Refresh
                    Feats.Add(_feat);
                    _feat = new Feats();
                }

                return Feats;
            }
            catch (Exception)
            { 
                throw;
            }
        }
    }
}

using FG5EParser.Base_Class;
using FG5eParserModels.DM_Modules;
using System;
using System.Collections.Generic;
using System.IO;

namespace FG5EParser.WriterClasses
{
    class EncounterWriter
    {
        public List<Encounter> compileEncounterList(string _inputLocation, string _moduleName)
        {
            try
            {
                var _lines = File.ReadLines(_inputLocation);
                List<string> _basic = new List<string>();
                Encounters _encounterObject = new Encounters();

                // Get all the lines from the reader
                foreach (string item in _lines)
                {
                    if(!string.IsNullOrEmpty(item)) _basic.Add(item);
                }
                return _encounterObject.bindValuesNew(_basic);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

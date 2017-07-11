using FG5EParser.Utilities;
using FG5eParserModels.Utility_Modules;
using System;
using System.Collections.Generic;
using System.IO;

namespace FG5EParser.WriterClasses
{
    public class ImagePinWriter
    {
        public List<ImagePins> compileImagePinsList(string _inputLocation, string moduleName)
        {
            try
            {
                XMLFormatting _xmlFormatting = new XMLFormatting();

                // Read lines from file
                var _lines = File.ReadLines(_inputLocation);
                List<ImagePins> _imagePinsList = new List<ImagePins>();

                foreach (var line in _lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        ImagePins _pin = new ImagePins()
                        {
                            _imageName = line.Split(';')[0],
                            _x = line.Split(';')[1],
                            _y = line.Split(';')[2],
                            _classType = "encounter", // May need to make this more dynamic                       
                            _recordName = string.Format("encounter.enc_{0}", _xmlFormatting.formatXMLCharachters(line.Split(';')[4],"IH"))
                        };
                        _imagePinsList.Add(_pin);
                    }
                }

                return _imagePinsList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

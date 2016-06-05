using Fantasy_Grounds_Parser_Tool.Mod;
using Fantasy_Grounds_Parser_Tool.Zipper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Fantasy_Grounds_Parser_Tool.Text_Reader
{
    public class TextReader
    {
        /// <summary>
        /// Function that processes the XMLs for NPC's
        /// </summary>
        /// <param name="_inputLocation">Location of the text files for input</param>
        /// <param name="_moduleName">The module name</param>
        /// <param name="_catalogueName">The catalogue name</param>
        /// <param name="_useInstalledPath">Use the registry settings to determine destination path</param>
        /// <param name="_destinationPath">Use given settings instead of registry settings</param>
        /// <param name="_authorName">The authors Name</param>
        /// <param name="_isDMOnly">Is this module for the DM only? True = Yes, False = No</param>
        public void ProcesNPCXML(string _inputLocation, string _moduleName, string _catalogueName, string _imagePath, bool _useInstalledPath, string _destinationPath, string _authorName, bool _isDMOnly)
        {
            var _lines = File.ReadLines(_inputLocation);

            List<string> _basic = new List<string>();
            List<Personalities> NPCS = new List<Personalities>();

            //BEGIN

            #region Process Lines
            foreach (var _line in _lines)
            {                
                if (!String.IsNullOrWhiteSpace(_line))
                {
                    _basic.Add(_line);
                }
                else
                {
                    // Send for processing
                    Personalities _personalities = new Personalities();
                    if (_basic.Count != 0)
                    {
                        _personalities = _personalities.BindValues(_basic);
                        NPCS.Add(_personalities);
                    }
                    _basic.Clear();                    
                }                
            }

            // If there is just one entry or the last entry
            if(!string.IsNullOrEmpty(_basic.ToString()))
            {
                Personalities _personalities = new Personalities();
                if (_basic.Count != 0)
                {
                    _personalities = _personalities.BindValues(_basic);
                    NPCS.Add(_personalities);
                }
                _basic.Clear();
            }
            #endregion

            // Get the Xdoc's
            XMLWriter.XMLWriter _xmlWriter = new XMLWriter.XMLWriter();
            if (string.IsNullOrEmpty(_catalogueName))
            {
                _catalogueName = "Core Books";
            }
            if (string.IsNullOrEmpty(_moduleName))
            {
                _moduleName = "ABC Module";
            }
            XDocument commonXML = _xmlWriter.prepareCommonXML(NPCS,_moduleName,_catalogueName);
            if (string.IsNullOrEmpty(_authorName))
            {
                _authorName = "SomeOneCreatedMe";
            }
            XDocument definationXML = _xmlWriter.prepareDefinationXML(_moduleName,_authorName);

            // Zip files and deploy
            ZipClass _zip = new ZipClass();
            // Check for text values and if missing set to defaults
            _zip.ZipFiles(commonXML, definationXML, _moduleName, _destinationPath, _imagePath, _useInstalledPath, _isDMOnly);

            // END
        }

    }
}

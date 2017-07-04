using FG5EParser.XMLWriters;
using FG5EParser.Zipper;
using System.Xml.Linq;

namespace FG5EParser.Utilities
{
    public class XMLParser
    {
        public void ParseXMLs(
            string _catalogueName,
            string _moduleName,
            string _authorName,
            string _destinationPath,
            string _imagePath,
            bool _useInstalledPath,
            bool _isDMOnly,
            string _npcTextPath = null,
            string _classTextPath = null,
            string _storyTextPath = null,
            string _itemTextPath = null,
            string _magicalItemTextPath = null,
            string _encounterTextPath = null,
            string _parcelTextPath = null,
            string _tableTextPath = null,
            string _backgroundTextPath = null,
            string _racesTextPath = null,
            string _spellsTextPath = null,
            string _featsTextPath = null,
            string _referenceManualTextPath = null,
            string _imageFileTextPath = null,
            string _imagePinsTextPath = null
        )
        {
            // Get the Xdoc's
            BaseWriter _xmlWriter = new BaseWriter();
            if (string.IsNullOrEmpty(_catalogueName))
            {
                _catalogueName = "Core Books";
            }
            if (string.IsNullOrEmpty(_moduleName))
            {
                _moduleName = "ABC Module";
            }
            XDocument commonXML = _xmlWriter.createCommonXML(
                _moduleName
                , _catalogueName
                , _npcTextPath
                , _classTextPath
                , _storyTextPath
                , _itemTextPath
                ,_magicalItemTextPath
                ,_encounterTextPath
                ,_parcelTextPath
                ,_tableTextPath
                ,_backgroundTextPath
                ,_racesTextPath,
                _spellsTextPath,
                _featsTextPath,
                _referenceManualTextPath,
                _imageFileTextPath,
                _imagePinsTextPath
                );

            if (string.IsNullOrEmpty(_authorName))
            {
                _authorName = "SomeOneCreatedMe";
            }
            XDocument definationXML = _xmlWriter.createDefinationXML(_moduleName, _authorName);

            // Zip files and deploy
            ZipClass _zip = new ZipClass();
            _zip.ZipFiles(commonXML, definationXML, _moduleName, _destinationPath, _imagePath, _useInstalledPath, _isDMOnly, _imageFileTextPath);
            //END
        }
    }
}

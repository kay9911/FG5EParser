using FG5EParser.Base_Classes;
using FG5EParser.Writer_Classes;
using FG5EParser.WriterClasses;
using FG5EParser.XML_Writer_Helper_Classes;
using FG5eParserModels.DM_Modules;
using FG5eParserModels.Player_Models;
using FG5eParserModels.Utility_Modules;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace FG5EParser.XMLWriters
{
    class BaseWriter
    {
        public XDocument createCommonXML(
            string _moduleName,
            string _catName,
            string _npcTextPath = "",
            string _classTextPath = "",
            string _storyTextPath = "",
            string _itemTextPath = "",
            string _magicalTextPath = "",
            string _encounterTextPath = "",
            string _parcelTextPath = "",
            string _tableTextPath = "",
            string _backgroundTextPath = "",
            string _racesTextPath = "",
            string _spellsTextPath = "",
            string _featsTextPath = "",
            string _referenceManualTextPath = ""
        )
        {
            // Defaults
            StringBuilder xml = new StringBuilder();
            bool requiresList = false;

            #region MODULE BASED INSTANCES           
            PersonalitiesHelper _personalitiesHelper = new PersonalitiesHelper();
            ClassHelper _classHelper = new ClassHelper();
            StoryHelper _storyHelper = new StoryHelper();
            ItemHelper _itemHelper = new ItemHelper();
            MagicalItemHelper _magicalItemHelper = new MagicalItemHelper();
            EncounterHelper _encounterHelper = new EncounterHelper();
            ParcelHelper _parcelHelper = new ParcelHelper();
            TableHelper _tableHelper = new TableHelper();
            BackgroundHelper _backgroundHelper = new BackgroundHelper();
            RacesHelper _raceHelper = new RacesHelper();
            SpellHelper _spellHelper = new SpellHelper();
            FeatsHelper _featsHelper = new FeatsHelper();
            ReferenceManualHelper _referenceManualHelper = new ReferenceManualHelper();
            #endregion

            #region EXPERIMENTAL SECTION
            List<Spells> _spellList = new List<Spells>();
            if (!string.IsNullOrEmpty(_spellsTextPath))
            {
                SpellWriter _spellWriter = new SpellWriter();
                _spellList = _spellWriter.compileSpellList(_spellsTextPath, _moduleName);
            }
            List<Feats> _featsList = new List<Feats>();
            if (!string.IsNullOrEmpty(_featsTextPath))
            {
                FeatsWriter _featsWriter = new FeatsWriter();
                _featsList = _featsWriter.compileFeatsList(_featsTextPath, _moduleName);
            }
            List<Personalities> _npcList = new List<Personalities>();
            if (!string.IsNullOrEmpty(_npcTextPath))
            {
                NPCWriter _npcWriter = new NPCWriter();
                _npcList = _npcWriter.compileNPCListNew(_npcTextPath, _moduleName);
            }
            List<ReferenceManual> _referenceManualList = new List<ReferenceManual>();
            if (!string.IsNullOrEmpty(_referenceManualTextPath))
            {
                ReferenceManualWriter _referenceManualWriter = new ReferenceManualWriter();
                _referenceManualList = _referenceManualWriter.compileReferenceManualList(_referenceManualTextPath, _moduleName);
            }
            #endregion

            #region XML HEADER
            // TO DO: Check and see if this line is required...
            xml.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>");
            xml.Append("<root version=\"3.0\">");
            #endregion

            // Item Entries
            if (!string.IsNullOrEmpty(_itemTextPath) || !string.IsNullOrEmpty(_magicalTextPath))
            {
                xml.Append("<item>");
                if (!string.IsNullOrEmpty(_itemTextPath))
                {
                    xml.Append(_itemHelper.returnItemXML(_itemTextPath, _moduleName));
                }
                if (!string.IsNullOrEmpty(_magicalTextPath))
                {
                    xml.Append(_magicalItemHelper.returnItemXML(_magicalTextPath, _moduleName));
                }
                requiresList = true;
                xml.Append("</item>");
            }

            // Story Entries
            if (!string.IsNullOrEmpty(_storyTextPath))
            {
                xml.Append(_storyHelper.returnStoryXML(_storyTextPath, _moduleName));
                requiresList = true;
            }

            // Encounter Entries
            if (!string.IsNullOrEmpty(_encounterTextPath))
            {
                xml.Append(_encounterHelper.returnEncounterXML(_encounterTextPath, _moduleName));
                requiresList = true;
            }

            // NPC Entries
            if (!string.IsNullOrEmpty(_npcTextPath))
            {
                xml.Append(_personalitiesHelper.returnPersonalitiesXML(_npcList, _moduleName));
                requiresList = true;
            }

            // Treasure Parcel Entries
            if (!string.IsNullOrEmpty(_parcelTextPath))
            {
                xml.Append(_parcelHelper.returnParcelXML(_parcelTextPath,_moduleName));
                requiresList = true;
            }

            // Table Entries
            if (!string.IsNullOrEmpty(_tableTextPath))
            {
                xml.Append(_tableHelper.returnTableXML(_tableTextPath,_moduleName));
                requiresList = true;
            }

            // Spell Entries
            if (!string.IsNullOrEmpty(_spellsTextPath))
            {
                requiresList = true;
            }

            // Feats Entries
            if (!string.IsNullOrEmpty(_featsTextPath))
            {
                requiresList = true;
            }

            // Getting in the additional lists
            if (requiresList)
            {
                xml.Append("<lists>");

                // Item List
                if (!string.IsNullOrEmpty(_itemTextPath))
                {
                    xml.Append(_itemHelper.returnItemXML(_itemTextPath,_moduleName,true)); // true : Switch to list
                }

                // Magical Item List
                if (!string.IsNullOrEmpty(_magicalTextPath))
                {
                    xml.Append(_magicalItemHelper.returnItemXML(_magicalTextPath,_moduleName,true)); // true : Switch to list
                }

                // Story List
                if (!string.IsNullOrEmpty(_storyTextPath))
                {
                    xml.Append(_storyHelper.returnStoryXML(_storyTextPath, _moduleName, true)); // true : Switch to list
                }

                // Encounters List
                if (!string.IsNullOrEmpty(_encounterTextPath))
                {
                    xml.Append(_encounterHelper.returnEncounterXML(_encounterTextPath, _moduleName, true)); // true : Switch to list
                }

                // NPC List
                if (!string.IsNullOrEmpty(_npcTextPath))
                {
                    xml.Append(_personalitiesHelper.returnPersonalitiesXML(_npcList, _moduleName, true)); // true : Switch to list
                }

                // Treasure Parcel List
                if (!string.IsNullOrEmpty(_parcelTextPath))
                {
                    xml.Append(_parcelHelper.returnParcelXML(_parcelTextPath,_moduleName,true)); // true : Switch to list
                }

                // Table List
                if (!string.IsNullOrEmpty(_tableTextPath))
                {
                    xml.Append(_tableHelper.returnTableXML(_tableTextPath, _moduleName, true)); // true : Switch to list
                }

                // Spell List
                if (!string.IsNullOrEmpty(_spellsTextPath))
                {
                    xml.Append(_spellHelper.returnSpellsXML(_spellList, true)); // true : Switch to list
                }
                xml.Append("</lists>");
            }

            // REFRENCE SECTION
            xml.Append("<reference static=\"true\">");

            // Input for personalities
            //if (!string.IsNullOrEmpty(_npcTextPath))
            //{
            //    xml.Append(_personalitiesHelper.returnPersonalitiesXML(_npcList, _moduleName));
            //}

            // Input for Classes
            if (!string.IsNullOrEmpty(_classTextPath))
            {
                xml.Append(_classHelper.returnClassesXML(_classTextPath, _moduleName));
            }

            // Input for Equipement
            if (!string.IsNullOrEmpty(_itemTextPath))
            {
                xml.Append(_itemHelper.returnItemReferenceDetails(_itemTextPath,_moduleName));
                xml.Append(_itemHelper.returnItemXML(_itemTextPath, _moduleName, true)); // true : Switch to list
            }

            // Input for NPC
            if (!string.IsNullOrEmpty(_npcTextPath))
            {
                xml.Append(_personalitiesHelper.returnNPCReferenceDetails(_npcList, _moduleName));
            }

            // Input for Backgrounds
            if (!string.IsNullOrEmpty(_backgroundTextPath))
            {
                xml.Append(_backgroundHelper.returnBackgroundXML(_backgroundTextPath,_moduleName));
                xml.Append(_backgroundHelper.returnBackgroundXML(_backgroundTextPath, _moduleName,true));
            }

            // Input for Races
            if (!string.IsNullOrEmpty(_racesTextPath))
            {
                xml.Append(_raceHelper.returnRaceXML(_racesTextPath,_moduleName));
                xml.Append(_raceHelper.returnRaceXML(_racesTextPath, _moduleName,true));
            }

            // Input for Spells
            if (!string.IsNullOrEmpty(_spellsTextPath))
            {
                xml.Append(_spellHelper.returnSpellsXML(_spellList));
            }

            // Input for Feats
            if (!string.IsNullOrEmpty(_featsTextPath))
            {
                xml.Append(_featsHelper.returnFeatsXML(_featsList));
                xml.Append(_featsHelper.returnFeatsXML(_featsList, true)); // true : Switch to list
            }

            xml.Append("</reference>");

            #region Library References

            // Counter
            int index = 1; 

            xml.Append("<library>");

            xml.Append(string.Format("<libn{0}>", _moduleName.Replace(" ", "").Trim().ToLower()));

            xml.Append(string.Format("<name type=\"string\">{0} Reference Library</name>", _moduleName));

            xml.Append(string.Format("<categoryname type=\"string\">{0}</categoryname>", _catName));

            xml.Append("<entries>");

            // Entry for Items
            if (!string.IsNullOrEmpty(_itemTextPath))
            {
                xml.Append(string.Format("<id-0000{0}>", index.ToString()));

                xml.Append("<librarylink type=\"windowreference\">");

                xml.Append("<class>referenceindex</class>");

                xml.Append("<recordname>reference.equipmentlists.equipment</recordname>");

                xml.Append("</librarylink>");

                xml.Append("<name type=\"string\">Equipment</name>");

                xml.Append(string.Format("</id-0000{0}>", index.ToString()));

                // Counter + 1
                index++;
            }

            // Entry for Magical Items
            if (!string.IsNullOrEmpty(_magicalTextPath))
            {
                xml.Append(string.Format("<id-0000{0}>", index.ToString()));

                xml.Append("<librarylink type=\"windowreference\">");

                xml.Append("<class>reference_colindex</class>");

                xml.Append(string.Format("<recordname>lists.magicitem.bytype</recordname>", _moduleName));

                xml.Append("</librarylink>");

                xml.Append("<name type=\"string\">Magic Items</name>");

                xml.Append(string.Format("</id-0000{0}>", index.ToString()));

                // Counter + 1
                index++;
            }

            // Entry for Ecnounters
            if (!string.IsNullOrEmpty(_encounterTextPath))
            {
                xml.Append(string.Format("<id-0000{0}>", index.ToString()));

                xml.Append("<librarylink type=\"windowreference\">");

                xml.Append("<class>reference_colindex</class>");

                xml.Append(string.Format("<recordname>lists.battle.bycategory@{0}</recordname>", _moduleName));

                xml.Append("</librarylink>");

                xml.Append("<name type=\"string\">Encounters</name>");

                xml.Append(string.Format("</id-0000{0}>", index.ToString()));

                // Counter + 1
                index++;
            }

            // Entry for Stories
            if (!string.IsNullOrEmpty(_storyTextPath))
            {
                xml.Append(string.Format("<id-0000{0}>", index.ToString()));

                xml.Append("<librarylink type=\"windowreference\">");

                xml.Append("<class>reference_colindex</class>");

                xml.Append(string.Format("<recordname>lists.encounter.bycategory@{0}</recordname>",_moduleName));

                xml.Append("</librarylink>");

                xml.Append("<name type=\"string\">Story</name>");

                xml.Append(string.Format("</id-0000{0}>", index.ToString()));

                // Counter + 1
                index++;
            }

            // Entry for NPC's
            if (!string.IsNullOrEmpty(_npcTextPath))
            {
                xml.Append(string.Format("<id-0000{0}>", index.ToString()));
                xml.Append("<librarylink type=\"windowreference\">");

                xml.Append("<class>referenceindex</class>");
                xml.Append("<recordname>reference.npclists.npcs</recordname>");

                xml.Append("</librarylink>");
                xml.Append("<name type=\"string\">NPCs</name>");
                xml.Append(string.Format("</id-0000{0}>", index.ToString()));

                // Counter + 1
                index++;
            }

            // Entry for Classes
            if (!string.IsNullOrEmpty(_classTextPath))
            {
                xml.Append(string.Format("<id-0000{0}>", index.ToString()));
                xml.Append("<librarylink type=\"windowreference\">");

                xml.Append("<class>reference_colindex</class>");
                xml.Append("<recordname>reference.classlists.byletter</recordname>");

                xml.Append("</librarylink>");
                xml.Append("<name type=\"string\">Classes</name>");
                xml.Append(string.Format("</id-0000{0}>", index.ToString()));

                // Counter + 1
                index++;
            }

            // Entry for Tables
            if (!string.IsNullOrEmpty(_tableTextPath))
            {
                xml.Append(string.Format("<id-0000{0}>", index.ToString()));
                xml.Append("<librarylink type=\"windowreference\">");

                xml.Append("<class>reference_colindex</class>");
                xml.Append(string.Format("<recordname>lists.table.bycategory@{0}</recordname>",_moduleName));

                xml.Append("</librarylink>");
                xml.Append("<name type=\"string\">Tables</name>");
                xml.Append(string.Format("</id-0000{0}>", index.ToString()));

                // Counter + 1
                index++;
            }

            // Entry for Backgrounds
            if (!string.IsNullOrEmpty(_backgroundTextPath))
            {
                xml.Append(string.Format("<id-0000{0}>", index.ToString()));
                xml.Append("<librarylink type=\"windowreference\">");

                xml.Append("<class>reference_colindex</class>");
                xml.Append(string.Format("<recordname>reference.backgroundlists.byletter</recordname>"));

                xml.Append("</librarylink>");
                xml.Append("<name type=\"string\">Backgrounds</name>");
                xml.Append(string.Format("</id-0000{0}>", index.ToString()));

                // Counter + 1
                index++;
            }

            // Entry for Races
            if (!string.IsNullOrEmpty(_racesTextPath))
            {
                xml.Append(string.Format("<id-0000{0}>", index.ToString()));
                xml.Append("<librarylink type=\"windowreference\">");

                xml.Append("<class>reference_colindex</class>");
                xml.Append(string.Format("<recordname>reference.racelists.byletter</recordname>"));

                xml.Append("</librarylink>");
                xml.Append("<name type=\"string\">Races</name>");
                xml.Append(string.Format("</id-0000{0}>", index.ToString()));

                // Counter + 1
                index++;
            }

            // Entry for Spells
            if (!string.IsNullOrEmpty(_spellsTextPath))
            {
                xml.Append(string.Format("<id-0000{0}>", index.ToString()));
                xml.Append("<librarylink type=\"windowreference\">");

                xml.Append("<class>referenceindex</class>");
                xml.Append(string.Format("<recordname>lists.spells.byclass</recordname>"));

                xml.Append("</librarylink>");
                xml.Append("<name type=\"string\">Spells</name>");
                xml.Append(string.Format("</id-0000{0}>", index.ToString()));

                // Counter + 1
                index++;
            }

            // Entry for Feats
            if (!string.IsNullOrEmpty(_featsTextPath))
            {
                xml.Append(string.Format("<id-0000{0}>", index.ToString()));
                xml.Append("<librarylink type=\"windowreference\">");

                xml.Append("<class>reference_featlist</class>");
                xml.Append(string.Format("<recordname>reference.featlists.byletter</recordname>"));

                xml.Append("</librarylink>");
                xml.Append("<name type=\"string\">Feats</name>");
                xml.Append(string.Format("</id-0000{0}>", index.ToString()));

                // Counter + 1
                index++;
            }

            xml.Append("</entries>");

            xml.Append(string.Format("</libn{0}>", _moduleName.Replace(" ", "").Trim().ToLower()));

            xml.Append("</library>");

            #endregion

            xml.Append("</root>");

            #region ENCODING FIX
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(xml.ToString());
            byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            string encodedXML = iso.GetString(isoBytes);
            XDocument _xml = XDocument.Parse(encodedXML);
            #endregion

            return _xml;
        }

        public XDocument createDefinationXML(string _moduleName, string _authorName)
        {
            StringBuilder xml = new StringBuilder();

            StringBuilder _defination = new StringBuilder();
            _defination.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>");
            _defination.Append("<root version=\"3.0\">");
            _defination.Append(string.Format("<name>{0}</name>", _moduleName));
            _defination.Append(string.Format("<author>{0}</author>", _authorName));
            _defination.Append("<ruleset>5E</ruleset>");
            _defination.Append("</root>");

            XDocument _xml = XDocument.Parse(_defination.ToString());
            return _xml;
        }
    }
}

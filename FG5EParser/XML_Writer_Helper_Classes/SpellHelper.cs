using FG5EParser.WriterClasses;
using FG5eParserModels.Player_Models;
using System.Collections.Generic;
using System.Text;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class SpellHelper
    {
        public string returnSpellsXML(
            string _spellTextPath,
            string _moduleName,
            bool isList = false
        )
        {
            StringBuilder xml = new StringBuilder();
            SpellWriter _spellWriter = new SpellWriter();

            List<Spells> _Spells = _spellWriter.compileSpellList(_spellTextPath, _moduleName);

            return "something";
        }
    }
}

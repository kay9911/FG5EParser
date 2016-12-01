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
    class ClassHelper
    {
        public string returnClassesXML(
            string _classtxtPath,
            string _moduleName
        )
        {
            StringBuilder xml = new StringBuilder();

            ClassWriter _classWriter = new ClassWriter();
            List<Classes> _classList = _classWriter.compileClassList(_classtxtPath, _moduleName);

            #region START XML PROCESSING

            xml.Append("<classdata>");

            foreach (Classes _class in _classList)
            {
                xml.Append(string.Format("{0}", this.generateClassXML(_class, _moduleName)));
            }

            xml.Append("</classdata>");

            xml.Append("<classlists>");

            xml.Append("<byletter>");

            xml.Append("<description type=\"string\">Classes</description>");

            xml.Append("<groups>");

            //Now we need to sort by letter
            xml.Append(string.Format("{0}", sortByLetter(_classList, _moduleName)));

            xml.Append("</groups>");

            xml.Append("</byletter>");

            xml.Append("</classlists>");

            #endregion

            return xml.ToString();
        }

        private string generateClassXML(Classes _class, string _moduleName)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting xmlFormatting = new XMLFormatting();

            xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_class.className,"CH")));

            xml.Append(string.Format("<name type=\"string\">{0}</name>",_class.className)); // Class name goes here

            xml.Append("<text type=\"formattedtext\">");

            xml.Append(_class.classDescriptions);

            xml.Append("</text>");

            #region HP SECTION

            xml.Append("<hp>");

            xml.Append("<hitdice>");

            xml.Append("<name type=\"string\">Hit Dice</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>",_class.hitDice)); // Hit dice goes here

            xml.Append("</hitdice>");

            xml.Append("</hp>");

            xml.Append("<hitpointsat1stlevel>");

            xml.Append("<name type=\"string\">Hit Points at 1st Level</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>",_class.hitPointsAtFirstLevel)); // Hp at first level goes here   

            xml.Append("</hitpointsat1stlevel>");

            xml.Append("<hitpointsathigherlevels>");

            xml.Append("<name type=\"string\">Hit Points at higher levels</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>",_class.hitPointsAfterFirstLevel)); // hp post first level goes here

            xml.Append("</hitpointsathigherlevels>");

            #endregion

            #region PEOFICIENCIES SECTION

            xml.Append("<proficiencies>");

            xml.Append("<armor>");

            xml.Append("<name type=\"string\">Armor</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>", _class.armour)); // armor goes here

            xml.Append("</armor>");

            xml.Append("<weapons>");

            xml.Append("<name type=\"string\">Weapons</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>", _class.weapons)); // weapons go here       

            xml.Append("</weapons>");

            xml.Append("<tools>");

            xml.Append("<name type=\"string\">Tools</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>",_class.tools)); // tools go here           

            xml.Append("</tools>");

            xml.Append("<savingthrows>");

            xml.Append("<name type=\"string\">Saving Throws</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>",_class.savingThrows)); // saving throws go here 

            xml.Append("</savingthrows>");

            xml.Append("<skills>");

            xml.Append("<name type=\"string\">Skills</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>", _class.skills)); // skills go here                             

            xml.Append("</skills>");

            xml.Append("</proficiencies>");

            #endregion

            #region FEATURES SECTION

            xml.Append("<features>");

            foreach (ClassFeatures _feature in _class.classFeatures)
            {
                xml.Append(string.Format("{0}", returnFeatureXML(_feature)));
            }

            xml.Append("</features>");

            #endregion

            #region ABILITIES SECTION

            xml.Append("<abilities>");

            foreach (ClassAbilities _ability in _class.classAbilities)
            {
                xml.Append(string.Format("{0}",returnAbilityXML(_ability, _class.className, _moduleName)));
            }

            xml.Append("</abilities>");

            #endregion

            #region EQUIPMENT SECTION

            xml.Append("<equipment>");

            xml.Append("<standard>");

            xml.Append("<group type=\"string\">standard</group>");

            xml.Append(string.Format("<item type=\"string\">{0}</item>",_class.equipment)); // equipment goes here

            xml.Append("</standard>");

            xml.Append("</equipment>");

            #endregion

            xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_class.className, "CH")));

            return xml.ToString();
        }

        private string sortByLetter(List<Classes> _classList, string _modulename)
        {
            StringBuilder _class = new StringBuilder();
            List<string> alphabets = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            foreach (string _s in alphabets)
            {
                Classes _current = new Classes();

                _current = _classList.Find(x => x.className.StartsWith(_s));

                if (_current != null)
                {
                    _class.Append(string.Format("<typeletter{0}>", _s));

                    _class.Append(string.Format("<description type=\"string\">{0}</description>", _s));

                    _class.Append("<index>");

                    var _list = _classList.FindAll(x => x.className.StartsWith(_s)).ToList();

                    // start returning classes based on starting letter

                    while (_list.Count != 0)
                    {
                        _current = _list.First();

                        _class.Append(string.Format("<{0}>", _current.className.Replace(" ", "").Trim()));

                        _class.Append("<link type=\"windowreference\">");

                        _class.Append("<class>reference_class</class>"); // UNIQUE FIELD

                        _class.Append(string.Format("<recordname>reference.classdata.{0}@{1}</recordname>", _current.className.Replace(" ", "").ToLower().Trim(), _modulename));

                        _class.Append("<description>");

                        _class.Append("<field>name</field>");

                        _class.Append("</description>");

                        _class.Append("</link>");

                        _class.Append("<source type=\"string\" />");

                        _class.Append(string.Format("</{0}>", _current.className.Replace(" ", "").Trim()));

                        // after processing get rid of it
                        _list.RemoveAt(0);
                    }

                    _class.Append("</index>");

                    _class.Append(string.Format("</typeletter{0}>", _s));

                } // end of (_current != null)

            } // end of foreach

            return _class.ToString();
        }

        private string returnFeatureXML(ClassFeatures _classFeature)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting xmlFormatting = new XMLFormatting();
            List<string> _level = new List<string>(_classFeature.FeatureLevels.Split(','));

            foreach (string level in _level)
            {
                xml.Append(string.Format("<{0}{1}>", xmlFormatting.formatXMLCharachters(_classFeature.FeatureName,"FH"), level));

                xml.Append(string.Format("<name type=\"string\">{0}</name>",_classFeature.FeatureName));

                xml.Append(string.Format("<level type=\"number\">{0}</level>", level));

                xml.Append(string.Format("<text type=\"formattedtext\">{0}</text>",_classFeature.FeatureDescription));

                // Check to see if this is an archtype header
                if (_classFeature.isArchtypeHeader)
                {
                    xml.Append("<specializationchoice type=\"number\">1</specializationchoice>");                    
                }

                // Append what archtype this particular skill falls under
                if (!string.IsNullOrEmpty(_classFeature.UnderArchtype))
                {
                    xml.Append(string.Format("<specialization type=\"string\">{0}</specialization>",_classFeature.UnderArchtype));
                }

                xml.Append(string.Format("</{0}{1}>", xmlFormatting.formatXMLCharachters(_classFeature.FeatureName, "FH"), level));
            }

            return xml.ToString();
        }

        private string returnAbilityXML(ClassAbilities _classAbility, string _className, string _moduleName)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting xmlFormatting = new XMLFormatting();

            xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_classAbility.AbilityName,"FH")));

            xml.Append(string.Format("<name type=\"string\">{0}</name>", _classAbility.AbilityName));

            xml.Append(string.Format("<level type=\"number\">{0}</level>","1"));

            _classAbility.AbilityDescription = _classAbility.AbilityDescription + appendAdditionalDetails(_classAbility, _className, _moduleName);

            xml.Append(string.Format("<text type=\"formattedtext\">{0}</text>",_classAbility.AbilityDescription));

            xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_classAbility.AbilityName, "FH")));          

            return xml.ToString();
        }

        private string appendAdditionalDetails(ClassAbilities _classAbility, string _className, string _moduleName)
        {
            StringBuilder _formatted = new StringBuilder();
            XMLFormatting xmlFormatting = new XMLFormatting();

            _formatted.Append("<h>Features</h>");

            _formatted.Append("<listlink>");

            for (int i = 0; i < _classAbility.AbilityList.Count; i++)
            {
                _formatted.Append(string.Format("<link class=\"reference_classfeature\" recordname=\"reference.classdata.{0}.features.{1}@{2}\">{3}</link>",
                    _className.ToLower().Trim(),
                    xmlFormatting.formatXMLCharachters(_classAbility.AbilityList[i].Split(',')[0],"FH") + _classAbility.AbilityList[i].Split(',')[1].Trim(),
                    _moduleName,
                    _classAbility.AbilityList[i].Split(',')[0].Trim()
                    ));
            }

            _formatted.Append("</listlink>");

            return _formatted.ToString();
        }
    }
}

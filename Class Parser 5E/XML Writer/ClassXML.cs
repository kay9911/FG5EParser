using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Parser_5E.Classes;

namespace Class_Parser_5E.XML_Writer
{
    class ClassXML
    {
        private string classDetailsToXML(ClassFeatures _CF)
        {
            StringBuilder _xml = new StringBuilder();

            #region HIT POINTS

            _xml.Append("<hp>");

            _xml.Append("<hitdice>");

            _xml.Append("<name type=\"string\">Hit Dice </name>");

            _xml.Append(string.Format("<text type=\"string\">{0}</text>", _CF.HitDice));

            _xml.Append("</hitdice>");

            _xml.Append("<hitpointsat1stlevel>");

            _xml.Append("<name type=\"string\">Hit Points at 1st Level</name>");

            _xml.Append(string.Format("<text type=\"string\">{0}</text>", _CF.HitPointsAtFirstLevel));

            _xml.Append("</hitpointsat1stlevel>");

            _xml.Append("<hitpointsathigherlevels>");

            _xml.Append("<name type=\"string\">Hit Points at Higher Levels</name>");

            _xml.Append(string.Format("<text type=\"string\">{0}</text>", _CF.HitPointsBeyondFirstLevel));

            _xml.Append("</hitpointsathigherlevels>");

            _xml.Append("</hp>");

            #endregion           

            #region PROFICIENCIES

            _xml.Append("<proficiencies>");

            _xml.Append("<armor>");

            _xml.Append("<name type=\"string\">Armor</name>");

            _xml.Append(string.Format("<text type=\"string\">{0}</text>", _CF.Armour));

            _xml.Append("</armor>");

            _xml.Append("<weapons>");

            _xml.Append("<name type=\"string\">Weapons</name>");

            _xml.Append(string.Format("<text type=\"string\">{0}</text>", _CF.Weapons));

            _xml.Append("</weapons>");

            _xml.Append("<tools>");

            _xml.Append("<name type=\"string\">Tools</name>");

            _xml.Append(string.Format("<text type=\"string\">{0}</text>", _CF.Tools));

            _xml.Append("</tools>");

            _xml.Append("<savingthrows>");

            _xml.Append("<name type=\"string\">Saving Throws</name>");

            _xml.Append(string.Format("<text type=\"string\">{0}</text>", _CF.SavingThrows));

            _xml.Append("</savingthrows>");

            _xml.Append("<skills>");

            _xml.Append("<name type=\"string\">Skills</name>");

            _xml.Append(string.Format("<text type=\"string\">{0}</text>", _CF.Skills));

            _xml.Append("</skills>");

            _xml.Append("</proficiencies>");

            #endregion

            return _xml.ToString();
        }

        private string classFeaturesToString(List<Ability> _CA)
        {
            StringBuilder _xml = new StringBuilder();

            _xml.Append("<features>");

            foreach (Ability _ability in _CA)
            {
                // Send each ability for formatting and append to the string
                if (!_ability.IsArchTypeHeading)
                {
                    _xml.Append(buildAbilityString(_ability));
                }
            }

            _xml.Append("</features>");

            return _xml.ToString();
        }

        private string buildAbilityString(Ability _ability)
        {
            StringBuilder _ab = new StringBuilder();

            if (!_ability.IsArchtype) // FEATURES
            {
                _ab.Append(string.Format("<{0}{1}>", _ability.AbilityName, _ability.Levels));

                _ab.Append(string.Format("<name type=\"string\">{0}</name>", _ability.AbilityName));

                _ab.Append(string.Format("<level type=\"number\">{0}</level>", _ability.Levels));

                _ab.Append(string.Format("<text type=\"formattedtext\">{0}</text>", _ability.AbilityDescription));

                if (_ability.IsArchtype)
                {
                    _ab.Append(string.Format("<specialization type=\"string\">{0}</specialization>", _ability.ArchtypeName));
                }

                _ab.Append(string.Format("</{0}{1}>", _ability.AbilityName, _ability.Levels));
            }
            else // ABILITY
            {
                _ab.Append(string.Format("<{0}>", _ability.AbilityName));

                _ab.Append(string.Format("<name type=\"string\">{0}</name>", _ability.AbilityName));

                _ab.Append(string.Format("<level type=\"number\">{0}</level>", _ability.Levels));

                _ab.Append(string.Format("<text type=\"formattedtext\">{0}</text>", _ability.AbilityDescription));

                _ab.Append(string.Format("</{0}{1}>", _ability.AbilityName, _ability.Levels));
            }

            return _ab.ToString();
        }

        private string classAbilitiesToString(List<Ability> _CA)
        {
            StringBuilder _abilities = new StringBuilder();

            _abilities.Append("<abilities>");

            foreach (Ability _ability in _CA)
            {
                // Send only the abilities that are domain heads
                if (_ability.IsArchtype)
                {
                    _abilities.Append(buildAbilityString(_ability));
                }
            }

            _abilities.Append("</abilities>");

            return _abilities.ToString();
        }
    }
}

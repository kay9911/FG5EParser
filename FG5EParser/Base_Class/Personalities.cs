using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.Base_Classes
{
    class Personalities
    {
        #region Properties
        public int LockType { get { return 1; } set { } }
        public string NPCName { get; set; }
        public string NPCType { get; set; }
        public string NPCSize { get; set; }
        public string NPCAlignment { get; set; }
        public int NPCAc { get; set; }
        public string NPCAcText { get; set; }
        public int NPCHitPoints { get; set; }
        public string NPCHitDice { get; set; }
        public string NPCSpeed { get; set; }
        public int NPCStrength { get; set; }
        public string NPCStrengthModifier { get; set; }
        public int NPCDexterity { get; set; }
        public string NPCDexterityModifier { get; set; }
        public int NPCConstitution { get; set; }
        public string NPCConstitutionModifier { get; set; }
        public int NPCIntelligence { get; set; }
        public string NPCIntelligenceModifier { get; set; }
        public int NPCWisdom { get; set; }
        public string NPCWisdomModifier { get; set; }
        public int NPCCharisma { get; set; }
        public string NPCCharismaModifier { get; set; }
        public string NPCSavingThrows { get; set; }
        public string NPCSkills { get; set; }
        public string NPCSenses { get; set; }
        public string NPCLanguages { get; set; }
        public string NPCCr { get; set; }
        public int NPCXp { get; set; }
        private List<string> _abilities = new List<string>();
        public List<string> NPCAbilities { get { return _abilities; } set { _abilities = value; } }
        private List<string> _actions = new List<string>();
        public List<string> NPCActions { get { return _actions; } set { _actions = value; } }
        private List<string> _legend = new List<string>();
        public List<string> NPCLegendActions { get { return _legend; } set { _legend = value; } }
        private List<string> _reaction = new List<string>();
        public List<string> NPCReactions { get { return _reaction; } set { _reaction = value; } }
        public string NPCDmgVul { get; set; }
        public string NPCDmgRes { get; set; }
        public string NPCDmgImm { get; set; }
        public string NPCCondImm { get; set; }
        #endregion

        public Personalities BindValues(List<string> _Basic)
        {
            Personalities _new = new Personalities();

            // Variable that will be used in order to process fields that are not mandatory
            string line = string.Empty;

            _new.NPCName = _Basic.First();
            // Type, Alignment, Size
            splitType(_new, _Basic);
            // AC and AC Type (if any)
            splitAc(_new, _Basic);
            // Hp and hp dice
            splitHP(_new, _Basic);
            // Speed
            _new.NPCSpeed = shiftUp(_Basic).Replace("  ", " ").Replace(". ,", ".,").Replace("Speed", "").Trim();
            // Stats
            splitStats(_new, _Basic);

            line = shiftUp(_Basic);

            if (line.Contains("Saving Throws"))
            {
                _new.NPCSavingThrows = line.Replace("Saving Throws", "").Trim();
                line = shiftUp(_Basic);
            }
            if (line.Contains("Skills"))
            {
                _new.NPCSkills = line.Replace("Skills", "").Trim();
                line = shiftUp(_Basic);
            }
            if (line.Contains("Damage Vulnerabilities"))
            {
                _new.NPCDmgVul = trimDMGlines(line);
                line = shiftUp(_Basic);
            }
            if (line.Contains("Damage Resistances"))
            {
                _new.NPCDmgRes = trimDMGlines(line);
                line = shiftUp(_Basic);
            }
            if (line.Contains("Damage Immunities"))
            {
                _new.NPCDmgImm = trimDMGlines(line);
                line = shiftUp(_Basic);
            }
            if (line.Contains("Condition Immunities"))
            {
                _new.NPCCondImm = trimDMGlines(line);
                line = shiftUp(_Basic);
            }
            if (line.Contains("Senses"))
            {
                _new.NPCSenses = line.Replace("Senses", "").Replace(" ,", ",").Trim();
                line = shiftUp(_Basic);
            }
            if (line.Contains("Languages"))
            {
                _new.NPCLanguages = line.Replace("Languages", "").Trim();
                line = shiftUp(_Basic);
            }

            //Challenge
            splitChallenge(_new, _Basic);

            // Check for abilities
            line = shiftUp(_Basic);

            while (line != "ACTIONS")
            {
                if (line == "Innate Spellcasting.")
                {
                    line = shiftUp(_Basic);
                    _new.NPCAbilities.Add(string.Format("Innate Spellcasting. {0}", line));
                    line = shiftUp(_Basic);
                }
                else if (line == "Spellcasting.")
                {
                    line = shiftUp(_Basic);
                    _new.NPCAbilities.Add(string.Format("Spellcasting. {0}", line));
                    line = shiftUp(_Basic);
                }
                else
                {
                    _new.NPCAbilities.Add(line);
                    line = shiftUp(_Basic);
                }
            }

            // Omitting the "ACTIONS" line
            line = shiftUp(_Basic);

            while (line != "LEGENDARY ACTIONS" && line != "REACTIONS" && line != "Its done!")
            {
                _new.NPCActions.Add(line);
                line = shiftUp(_Basic);
            }

            // First check to see if this is a Legendary Action or a Reaction
            while (line != "Its done!")
            {
                // While the reaction section has not been reached
                while (line != "REACTIONS" && line != "Its done!")
                {
                    // Remove the legendary actions line
                    if (line == "LEGENDARY ACTIONS")
                    {
                        line = shiftUp(_Basic);
                        _new.NPCLegendActions.Add(line);
                        line = shiftUp(_Basic);
                    }
                    else
                    {
                        _new.NPCLegendActions.Add(line);
                        line = shiftUp(_Basic);
                    }
                }

                while (line != "Its done!")
                {
                    // Remove the Reactions line
                    if (line == "REACTIONS")
                    {
                        line = shiftUp(_Basic);
                        _new.NPCReactions.Add(line);
                        line = shiftUp(_Basic);
                    }
                    else
                    {
                        _new.NPCReactions.Add(line);
                        line = shiftUp(_Basic);
                    }
                }
            }

            return _new;
        }

        private void splitChallenge(Personalities _person, List<string> _Basic)
        {
            //get the line
            //NO NEED TO SHIFTUP()
            string line = _Basic.First().Replace("Challenge", "").Trim();

            _person.NPCCr = line.Split('(')[0].Trim();

            _person.NPCXp = Convert.ToInt32(line.Replace(_person.NPCCr, "").Replace("(", "").Replace(")", "").Replace("XP", "").Replace(",", "").Trim());
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

        private void splitType(Personalities _person, List<string> _Basic)
        {
            shiftUp(_Basic);
            //Get the type
            string line = _Basic.First();
            //Split to first get the alignment
            if (line.Contains(")"))
            {
                _person.NPCAlignment = line.Split(')')[1].Replace(",", "").Trim();
            }
            else
            {
                _person.NPCAlignment = line.Split(',')[1].Trim();
            }
            //Remove that section
            line = line.Replace(_person.NPCAlignment, ",").Replace(", ,", "").Replace(",,", "");
            //Get the size
            _person.NPCSize = line.Split(' ')[0].Trim();
            //Remove that section
            line = line.Replace(_person.NPCSize, "");
            //Get the type
            //_person.NPCType = line.Replace(",","").Trim();
            _person.NPCType = line.Trim();
        }

        private void splitAc(Personalities _person, List<string> _Basic)
        {
            shiftUp(_Basic);

            //Get the AC
            string line = _Basic.First().Replace("Armor Class", "").Trim();

            //Check if ac type is specified
            if (line.Contains("(") || line.Contains(")"))
            {
                _person.NPCAc = Convert.ToInt32(line.Split('(')[0].Trim());

                //Remove section and reassign the type

                _person.NPCAcText = line.Replace(_person.NPCAc.ToString(), "").Trim();
            }
            else
                _person.NPCAc = Convert.ToInt32(line);
        }

        private void splitStats(Personalities _person, List<string> _Basic)
        {
            //Get the line
            string line = shiftUp(_Basic);
            line = line.Replace(" ", ",").Replace("(", ",").Replace(")", ",").Replace(",,", ",");
            // Split the line
            string[] _arr = line.Split(',');

            _person.NPCStrength = Convert.ToInt32(_arr[6]);
            _person.NPCStrengthModifier = _arr[7].Replace("+0", "0");

            _person.NPCDexterity = Convert.ToInt32(_arr[8]);
            _person.NPCDexterityModifier = _arr[9].Replace("+0", "0");

            _person.NPCConstitution = Convert.ToInt32(_arr[10]);
            _person.NPCConstitutionModifier = _arr[11].Replace("+0", "0");

            _person.NPCIntelligence = Convert.ToInt32(_arr[12]);
            _person.NPCIntelligenceModifier = _arr[13].Replace("+0", "0");

            _person.NPCWisdom = Convert.ToInt32(_arr[14]);
            _person.NPCWisdomModifier = _arr[15].Replace("+0", "0");

            _person.NPCCharisma = Convert.ToInt32(_arr[16]);
            _person.NPCCharismaModifier = _arr[17].Replace("+0", "0");
        }

        private void splitHP(Personalities _person, List<string> _Basic)
        {
            //get the line
            string line = shiftUp(_Basic).Replace("Hit Points", "").Trim();

            _person.NPCHitPoints = Convert.ToInt32(line.Split('(')[0].Trim());

            _person.NPCHitDice = line.Replace(_person.NPCHitPoints.ToString(), "").Trim();
        }

        private string trimDMGlines(string _line)
        {
            _line = _line.Replace("Damage Vulnerabilities", "").Replace("Damage Resistances", "").Replace("Damage Immunities", "").Replace("Condition Immunities", "");
            _line = _line.Replace(". ,", ".,").Replace(" ,", ",").Trim();
            return _line;
        }
    }
}

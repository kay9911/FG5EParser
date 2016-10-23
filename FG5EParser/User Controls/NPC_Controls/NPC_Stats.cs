using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FG5EParser.Utilities;

namespace FG5EParser.User_Controls
{
    public partial class NPC_Stats : UserControl
    {
        // properties
        public string exposeStats {
            get { return _build.ToString(); }
        }

        // Allows the use of the parents controls
        public LandingPage allowUse { get; set; }

        public string getNameforInnateSpellCastingUserControl {
            get { return txtName.Text; }
        }

        public NPC_Stats()
        {
            InitializeComponent();

            txtSTR.Text = "10";
            txtDEX.Text = "10";
            txtCON.Text = "10";
            txtINT.Text = "10";
            txtWIS.Text = "10";
            txtCHR.Text = "10";

            doCompile();
        }

        // String Builders	
        StringBuilder _build = new StringBuilder();
        StringBuilder _buildabilities = new StringBuilder();
        List<KeyValuePair<string, string>> _ability = new List<KeyValuePair<string, string>>();

        // Class instance to use the regex features
        RegularExpressions _regex;

        bool _isStatsComplete;

        public void doCompile()
        {
            // Clear Builder
            _build.Clear();

            // Start Building
            getName();
            getSizeTypeAlignment();
            getAC();
            getHP();
            getSpeed();
            getStats();
            getSavingThrows();
            getSkills();
            getDamageVul();
            getDamageRes();
            getDamageImm();
            getConditionImm();
            getSenses();
            getLanguages();
            getChallenge();

            // Get Abilities			
            _build.Append(_buildabilities.ToString());

            // Some final formatting, its tiresome cathing all of these :S
            _build.Replace("..", ".");
            _build.Replace(". .", ".");
            _build.Replace(".  .", ".");

            if (allowUse == null)
                return;

            RichTextBox _rtc = (allowUse.Controls["rtcDisplay"] as RichTextBox);
            _rtc.Text = _build.ToString();                      
        }

        #region STRING DEFINATIONS FOR NPC STATS

        private void getName()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                _build.Append("<Name Required>");
                _isStatsComplete = false;
            }
            else
            {
                _build.Append(txtName.Text.Trim());
                _isStatsComplete = true;
            }
        }

        private void getSizeTypeAlignment()
        {
            if (string.IsNullOrEmpty(txtSizeTypeAlignment.Text))
            {
                _build.Append(Environment.NewLine);
                _build.Append("<Size Type, Alignment Required>");
                _isStatsComplete = false;
            }
            else
            {
                _build.Append(Environment.NewLine);
                _build.Append(txtSizeTypeAlignment.Text.Trim());
                _isStatsComplete = true;
            }
        }

        private void getAC()
        {
            if (string.IsNullOrEmpty(txtAC.Text))
            {
                _build.Append(Environment.NewLine);
                _build.Append("<Armor Class Required>");
                _isStatsComplete = false;
            }
            else
            {
                _build.Append(Environment.NewLine);
                _build.Append("Armor Class " + txtAC.Text.Trim());
                _isStatsComplete = true;
            }
        }

        private void getHP()
        {
            if (string.IsNullOrEmpty(txtHP.Text))
            {
                _build.Append(Environment.NewLine);
                _build.Append("<Hit Points Required>");
                _isStatsComplete = false;
            }
            else
            {
                _build.Append(Environment.NewLine);
                _build.Append("Hit Points " + txtHP.Text.Trim());
                _isStatsComplete = true;
            }
        }

        private void getSpeed()
        {
            if (string.IsNullOrEmpty(txtSpeed.Text))
            {
                _build.Append(Environment.NewLine);
                _build.Append("<Speed Required>");
                _isStatsComplete = false;
            }
            else
            {
                _build.Append(Environment.NewLine);

                // Check and match for each type of movement
                string _toAppend = string.Empty;

                if (txtSpeed.Text.Contains("ft."))
                {
                    _regex = new RegularExpressions();

                    string[] _speedtypes = txtSpeed.Text.Trim().Split('.');

                    for (int i = 0; i < _speedtypes.Length; i++)
                    {
                        if (!String.IsNullOrWhiteSpace(_speedtypes[i]))
                        {
                            if (i == 0)
                            {
                                _toAppend += string.Format("{0}.", _regex.getCorrectedSpeed(_speedtypes[i]));
                            }
                            else
                                _toAppend += string.Format(", {0}.", _regex.getCorrectedSpeed(_speedtypes[i].ToString()));
                        }
                    }
                }

                _build.Append("Speed " + _toAppend);
                _isStatsComplete = true;
            }
        }

        private void getStats()
        {
            //STR
            string _str = !string.IsNullOrEmpty(txtSTR.Text) ? buildStats(txtSTR.Text) : buildStats("10");
            //DEX
            string _dex = !string.IsNullOrEmpty(txtDEX.Text) ? buildStats(txtDEX.Text) : buildStats("10");
            //CON
            string _con = !string.IsNullOrEmpty(txtCON.Text) ? buildStats(txtCON.Text) : buildStats("10");
            //INT
            string _int = !string.IsNullOrEmpty(txtINT.Text) ? buildStats(txtINT.Text) : buildStats("10");
            //WIS
            string _wis = !string.IsNullOrEmpty(txtWIS.Text) ? buildStats(txtWIS.Text) : buildStats("10");
            //CHR
            string _chr = !string.IsNullOrEmpty(txtCHR.Text) ? buildStats(txtCHR.Text) : buildStats("10");

            // Build final String

            _build.Append(Environment.NewLine);

            _build.Append("STR DEX CON INT WIS CHA ");

            string _format = string.Format("{0} ({1}) ", txtSTR.Text, _str);
            _build.Append(_format);

            _format = string.Format("{0} ({1}) ", txtDEX.Text, _dex);
            _build.Append(_format);


            _format = string.Format("{0} ({1}) ", txtCON.Text, _con);
            _build.Append(_format);


            _format = string.Format("{0} ({1}) ", txtINT.Text, _int);
            _build.Append(_format);


            _format = string.Format("{0} ({1}) ", txtWIS.Text, _wis);
            _build.Append(_format);


            _format = string.Format("{0} ({1})", txtCHR.Text, _chr);
            _build.Append(_format);

        }

        private void getSavingThrows()
        {
            if (string.IsNullOrEmpty(txtSavingThrows.Text))
            {
                // DO NOTHING
            }
            else
            {
                _build.Append(Environment.NewLine);
                _build.Append("Saving Throws " + txtSavingThrows.Text.Trim());
            }
        }

        private void getSkills()
        {
            if (string.IsNullOrEmpty(txtSkills.Text))
            {
                // DO NOTHING
            }
            else
            {
                _build.Append(Environment.NewLine);
                _build.Append("Skills " + txtSkills.Text.Trim());
            }
        }

        private void getSenses()
        {
            if (string.IsNullOrEmpty(txtSenses.Text))
            {
                _build.Append(Environment.NewLine);
                _build.Append("<Senses Required>");
                _isStatsComplete = false;
            }
            else
            {
                _build.Append(Environment.NewLine);
                _build.Append("Senses " + txtSenses.Text.Trim());
                _isStatsComplete = true;
            }
        }

        private void getLanguages()
        {
            if (string.IsNullOrEmpty(txtLanguages.Text))
            {
                _build.Append(Environment.NewLine);
                _build.Append("<Language Required>");
                _isStatsComplete = false;
            }
            else
            {
                _build.Append(Environment.NewLine);
                _build.Append("Languages " + txtLanguages.Text.Trim());
                _isStatsComplete = true;
            }
        }

        private void getChallenge()
        {
            if (string.IsNullOrEmpty(txtChallenge.Text))
            {
                _build.Append(Environment.NewLine);
                _build.Append("<Challenge Required>");
                _isStatsComplete = false;
            }
            else
            {
                _build.Append(Environment.NewLine);
                _build.Append("Challenge " + txtChallenge.Text.Trim());
                _isStatsComplete = true;
            }
        }

        private void getDamageVul()
        {
            if (!string.IsNullOrEmpty(txtDMGVUL.Text))
            {
                _build.Append(Environment.NewLine);
                _build.Append("Damage Vulnerabilities " + txtDMGVUL.Text.Trim().Replace(Environment.NewLine, " "));
            }
        }

        private void getDamageImm()
        {
            if (!string.IsNullOrEmpty(txtDMGIMM.Text))
            {
                _build.Append(Environment.NewLine);
                _build.Append("Damage Immunities " + txtDMGIMM.Text.Trim().Replace(Environment.NewLine, " "));
            }
        }

        private void getConditionImm()
        {
            if (!string.IsNullOrEmpty(txtCONIMM.Text))
            {
                _build.Append(Environment.NewLine);
                _build.Append("Condition Immunities " + txtCONIMM.Text.Trim().Replace(Environment.NewLine, " "));
            }
        }

        private void getDamageRes()
        {
            if (!string.IsNullOrEmpty(txtDMGRES.Text))
            {
                _build.Append(Environment.NewLine);
                _build.Append("Damage Resistances " + txtDMGRES.Text.Trim().Replace(Environment.NewLine, " "));
            }
        }
        #endregion

        private string buildStats(string _val)
        {
            decimal _retVal = Math.Floor((Convert.ToDecimal(_val) - 10) / 2);

            string val = string.Empty;

            if (_retVal < 0)
            {
                val = Convert.ToString(_retVal);
            }
            else
                val = string.Format("+{0}", Convert.ToString(_retVal));

            return val;
        }

        #region TEXT CHANGED EVENTS

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtSizeTypeAlignment_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtAC_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtHP_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtSpeed_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtSavingThrows_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtSkills_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtSenses_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtLanguages_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtChallenge_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtDMGVUL_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtDMGRES_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtDMGIMM_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtCONIMM_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        #endregion

        #region STAT BLOCK ENTER AND EXIT FUNCTIONS

        void TxtSTREnter(object sender, EventArgs e)
        {
            txtSTR.Text = string.Empty;
        }
        void TxtDEXEnter(object sender, EventArgs e)
        {
            txtDEX.Text = string.Empty;
        }
        void TxtCONEnter(object sender, EventArgs e)
        {
            txtCON.Text = string.Empty;
        }
        void TxtINTEnter(object sender, EventArgs e)
        {
            txtINT.Text = string.Empty;
        }
        void TxtWISEnter(object sender, EventArgs e)
        {
            txtWIS.Text = string.Empty;
        }
        void TxtCHREnter(object sender, EventArgs e)
        {
            txtCHR.Text = string.Empty;
        }

        void TxtSTRLeave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSTR.Text))
            {
                txtSTR.Text = "10";
                doCompile();
            }
            else
                doCompile();
        }
        void TxtDEXLeave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDEX.Text))
            {
                txtDEX.Text = "10";
                doCompile();
            }
            else
                doCompile();
        }
        void TxtCONLeave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCON.Text))
            {
                txtCON.Text = "10";
                doCompile();
            }
            else
                doCompile();
        }
        void TxtINTLeave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtINT.Text))
            {
                txtINT.Text = "10";
                doCompile();
            }
            else
                doCompile();
        }
        void TxtWISLeave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtWIS.Text))
            {
                txtWIS.Text = "10";
                doCompile();
            }
            else
                doCompile();
        }
        void TxtCHRLeave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCHR.Text))
            {
                txtCHR.Text = "10";
                doCompile();
            }
            else
                doCompile();
        }
        #endregion

        private void btnADDability_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAbilities.Text))
            {
                if (txtAbilities.Text.Contains("."))
                {
                    // Clear the builder
                    _buildabilities.Clear();

                    // Clear the line breaks
                    string _clearLines = txtAbilities.Text.Trim().Replace(Environment.NewLine, "");

                    // Split the string
                    string[] _arr = _clearLines.Split('.');
                    string _val = _returnString(_arr);

                    // Insert into the keyvalue pair list
                    _ability.Add(new KeyValuePair<string, string>(string.Format("{0}.", _arr[0].ToString()), _val));
                    txtAbilities.Text = string.Empty;

                    foreach (KeyValuePair<string, string> pair in _ability)
                    {
                        string _format = string.Format("{0}{1}", pair.Key.ToString(), pair.Value.ToString());
                        _buildabilities.Append(Environment.NewLine);
                        _buildabilities.Append(_format);
                    }

                    doCompile();
                }
                else
                {
                    MessageBox.Show("Please make sure abilities are in this format : <Ability Name>. <Description>");
                }
            }
        }

        void BtnAbilityRefresh_Click(object sender, EventArgs e)
        {
            _buildabilities.Clear();
            _ability.Clear();
            doCompile();
        }

        private string _returnString(String[] arr)
        {
            StringBuilder _retVal = new StringBuilder();

            for (int i = 1; i < arr.Length; i++)
            {
                _retVal.Append(String.Format(" {0}.", arr[i].ToString().Trim()));
            }

            return _retVal.ToString();
        }
    }
}

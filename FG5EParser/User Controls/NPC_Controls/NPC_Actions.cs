using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FG5EParser.User_Controls.NPC_Controls
{
    public partial class NPC_Actions : UserControl
    {
        // properties
        public string exposeActions
        {
            get { return _build.ToString(); }
        }

        // Allows the use of the parents controls
        public LandingPage allowUse { get; set; }

        public NPC_Actions()
        {
            InitializeComponent();
        }

        #region STRING BUILDERS
        StringBuilder _build = new StringBuilder();
        StringBuilder _buildabilities = new StringBuilder();
        List<KeyValuePair<string, string>> _ability = new List<KeyValuePair<string, string>>();

        StringBuilder _buildActions = new StringBuilder();
        List<KeyValuePair<string, string>> _action = new List<KeyValuePair<string, string>>();

        StringBuilder _buildReactions = new StringBuilder();
        List<KeyValuePair<string, string>> _reaction = new List<KeyValuePair<string, string>>();

        StringBuilder _buildLegends = new StringBuilder();
        List<KeyValuePair<string, string>> _legend = new List<KeyValuePair<string, string>>();
        #endregion

        private void doCompile()
        {
            // Clear Builder
            _build.Clear();

            // Get Abilities			
            _build.Append(_buildabilities.ToString());

            // Get Actions
            _build.Append(_buildActions.ToString());

            // Get Reactions
            _build.Append(_buildReactions.ToString());

            // Get Legendary Actions
            _build.Append(_buildLegends.ToString());

            // Some final formatting, its tiresome cathing all of these :S
            _build.Replace("..", ".");
            _build.Replace(". .", ".");
            _build.Replace(".  .", ".");

            if (allowUse == null)
                return;

            RichTextBox _rtc = (allowUse.Controls["rtcDisplay"] as RichTextBox);
            _rtc.Text = _build.ToString();
        }

        #region ADD BUTTON ON CLICK FUNCTIONS

        // TO DO : NORMALIZE FUNCTION NAMES!

        void BtnADDabilityClick(object sender, EventArgs e)
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

        void BtnADDactionsClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtACTIONS.Text))
            {
                if (txtACTIONS.Text.Contains("."))
                {
                    // Clear the builder
                    _buildActions.Clear();
                    _buildActions.Append(Environment.NewLine);
                    _buildActions.Append("ACTIONS");

                    // Clear the line breaks
                    string _clearLines = txtACTIONS.Text.Trim().Replace(Environment.NewLine, "");

                    // Split the string
                    string[] _arr = _clearLines.Split('.');
                    string _val = _returnString(_arr);

                    // Insert into the keyvalue pair list
                    _action.Add(new KeyValuePair<string, string>(string.Format("{0}.", _arr[0].ToString()), _val));
                    txtACTIONS.Text = string.Empty;

                    foreach (KeyValuePair<string, string> pair in _action)
                    {
                        string _format = string.Format("{0}{1}", pair.Key.ToString(), pair.Value.ToString());
                        _buildActions.Append(Environment.NewLine);
                        _buildActions.Append(_format);
                    }

                    doCompile();
                }
                else
                {
                    MessageBox.Show("Please make sure ACTIONS are in this format : <Action Name>. <Description>");
                }
            }
        }

        void BtnADDlegendaryClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLEGENDARYACTIONS.Text))
            {
                if (txtLEGENDARYACTIONS.Text.Contains("."))
                {
                    // Clear the builder
                    _buildLegends.Clear();
                    _buildLegends.Append(Environment.NewLine);
                    _buildLegends.Append("LEGENDARY ACTIONS");

                    // Clear the line breaks
                    string _clearLines = txtLEGENDARYACTIONS.Text.Trim().Replace(Environment.NewLine, "");

                    // Split the string
                    string[] _arr = _clearLines.Split('.');

                    string _val = _returnString(_arr);

                    // Insert into the keyvalue pair list
                    _legend.Add(new KeyValuePair<string, string>(string.Format("{0}.", _arr[0].ToString()), _val));
                    txtLEGENDARYACTIONS.Text = string.Empty;

                    foreach (KeyValuePair<string, string> pair in _legend)
                    {
                        string _format = string.Format("{0}{1}", pair.Key.ToString(), pair.Value.ToString());
                        _buildLegends.Append(Environment.NewLine);
                        _buildLegends.Append(_format);
                    }

                    doCompile();
                }
                else
                {
                    MessageBox.Show("Please make sure LEGENDARY ACTIONS are in this format : <Legendary Action>. <Description>");
                }
            }
        }

        private void btnAddReaction_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtREACTIONS.Text))
            {
                if (txtREACTIONS.Text.Contains("."))
                {
                    // Clear the builder
                    _buildReactions.Clear();
                    _buildReactions.Append(Environment.NewLine);
                    _buildReactions.Append("REACTIONS");

                    // Clear the line breaks
                    string _clearLines = txtREACTIONS.Text.Trim().Replace(Environment.NewLine, "");

                    // Split the string
                    string[] _arr = _clearLines.Split('.');

                    string _val = _returnString(_arr);

                    // Insert into the keyvalue pair list
                    _reaction.Add(new KeyValuePair<string, string>(string.Format("{0}.", _arr[0].ToString()), _val));
                    txtREACTIONS.Text = string.Empty;

                    foreach (KeyValuePair<string, string> pair in _reaction)
                    {
                        string _format = string.Format("{0}{1}", pair.Key.ToString(), pair.Value.ToString());
                        _buildReactions.Append(Environment.NewLine);
                        _buildReactions.Append(_format);
                    }

                    doCompile();
                }
                else
                {
                    MessageBox.Show("Please make sure REACTIONS are in this format : <Reaction>. <Description>");
                }
            }
        }

        #endregion

        #region REFRESH FUNCTIONS

        // TO DO : NORMALIZE FUNCTION NAMES!

        void BtnAbilityRefresh_Click(object sender, EventArgs e)
        {
            _buildabilities.Clear();
            _ability.Clear();
            doCompile();
        }

        private void btnActionsRefresh_Click(object sender, EventArgs e)
        {
            _buildActions.Clear();
            _action.Clear();
            doCompile();
        }

        void TxtRefreshLegendsClick(object sender, EventArgs e)
        {
            _buildLegends.Clear();
            _legend.Clear();
            doCompile();
        }

        private void btnRefreshReaction_Click(object sender, EventArgs e)
        {
            _buildReactions.Clear();
            _reaction.Clear();
            doCompile();
        }

        #endregion

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

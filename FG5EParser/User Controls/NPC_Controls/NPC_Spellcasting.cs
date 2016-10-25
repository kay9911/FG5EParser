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
    public partial class NPC_Spellcasting : UserControl
    {
        // properties
        public string exposeSpellCasting
        {
            get { return _build.ToString(); }
        }

        #region RESET PROPERTIES

        public string resettxtSpellSave
        { 
            set { txtSpellSave.Text = value; }
        }

        public string resettxtSpellHit
        {
            set { txtSpellHit.Text = value; }
        }
       
        public string resettxtSpellAbilityText
        {
            set { txtSpellAbilityText.Text = value; }
        }

        public string resettxtCantrips
        {
            set { txtCantrips.Text = value; }
        }

        public string resettxtFirstLevel
        {
            set { txtFirstLevel.Text = value; }
        }

        public string resettxtSecondLevel
        {
            set { txtSecondLevel.Text = value; }
        }

        public string resettxtThirdLevel
        {
            set { txtThirdLevel.Text = value; }
        }

        public string resettxtFourthLevel
        {
            set { txtFourthLevel.Text = value; }
        }

        public string resettxtFifthLevel
        {
            set { txtFifthLevel.Text = value; }
        }

        public string resettxtSixthLevel
        {
            set { txtSixthLevel.Text = value; }
        }

        public string resettxtSeventhLevel
        {
            set { txtSeventhLevel.Text = value; }
        }

        public string resettxtEightLevel
        {
            set { txtEightLevel.Text = value; }
        }

        public string resettxtNinthLevel
        {
            set { txtNinthLevel.Text = value; }
        }

        public int resetcmbSpellCastingAbility
        {
            set { cmbSpellCastingAbility.SelectedIndex = value; }
        }

        public int resetcmbcomboBox1
        {
            set { comboBox1.SelectedIndex = value; }
        }
        public int resetcmbcomboBox2
        {
            set { comboBox2.SelectedIndex = value; }
        }
        public int resetcmbcomboBox3
        {
            set { comboBox3.SelectedIndex = value; }
        }
        public int resetcmbcomboBox4
        {
            set { comboBox4.SelectedIndex = value; }
        }
        public int resetcmbcomboBox5
        {
            set { comboBox5.SelectedIndex = value; }
        }
        public int resetcmbcomboBox6
        {
            set { comboBox6.SelectedIndex = value; }
        }
        public int resetcmbcomboBox7
        {
            set { comboBox7.SelectedIndex = value; }
        }
        public int resetcmbcomboBox8
        {
            set { comboBox8.SelectedIndex = value; }
        }
        public int resetcmbcomboBox9
        {
            set { comboBox9.SelectedIndex = value; }
        }

        #endregion

        // Allows the use of the parents controls
        public LandingPage allowUse { get; set; }

        public NPC_Spellcasting()
        {
            InitializeComponent();
            BindSpellcastingAbilityNames();
            BindSpellSlots();
        }

        // String Builders
        StringBuilder _build = new StringBuilder();

        // Is Spellcaster?
        bool _isSpellcaster = false;

        private void doCompile()
        {
            // Clear Builder
            _build.Clear();

            // Get Spellcasting Details
            getSpellCastingMods();
            getSpellCasting();

            // Some final formatting, its tiresome cathing all of these :S
            _build.Replace("..", ".");
            _build.Replace(". .", ".");
            _build.Replace(".  .", ".");

            if (allowUse == null)
                return;

            RichTextBox _rtc = (allowUse.Controls["rtcDisplay"] as RichTextBox);
            _rtc.Text = _build.ToString();
        }

        private void getSpellCastingMods()
        {
            if (!string.IsNullOrEmpty(cmbSpellCastingAbility.SelectedItem.ToString()))
            {
                _build.Append(Environment.NewLine);
                _build.Append("Spellcasting.");
                _build.Append(Environment.NewLine);
                _build.Append(string.Format("Spellcasting ability is {0} (spell save DC {1}, +{2} to hit with spell attacks)", cmbSpellCastingAbility.SelectedItem,
                                            !String.IsNullOrEmpty(txtSpellSave.Text) ? txtSpellSave.Text : "0",
                                            !String.IsNullOrEmpty(txtSpellHit.Text) ? txtSpellHit.Text : "0"));
                _isSpellcaster = true;
            }
            else
            {
                _isSpellcaster = false;
            }
        }

        private void getSpellCasting()
        {
            if (_isSpellcaster)
            {
                if (!string.IsNullOrEmpty(txtSpellAbilityText.Text))
                {
                    _build.Append("\\r" + txtSpellAbilityText.Text.Trim().Replace(Environment.NewLine, " "));
                }

                if (!string.IsNullOrEmpty(txtCantrips.Text))
                {
                    _build.Append("\\rCantrips (At will): " + txtCantrips.Text.Trim());
                }

                if (!string.IsNullOrEmpty(txtFirstLevel.Text))
                {
                    _build.Append(string.Format("\\r1st Level ({0}): {1}", comboBox1.SelectedItem, txtFirstLevel.Text.Trim()));
                }

                if (!string.IsNullOrEmpty(txtSecondLevel.Text))
                {
                    _build.Append(string.Format("\\r2nd Level ({0}): {1}", comboBox2.SelectedItem, txtSecondLevel.Text.Trim()));
                }

                if (!string.IsNullOrEmpty(txtThirdLevel.Text))
                {
                    _build.Append(string.Format("\\r3rd Level ({0}): {1}", comboBox3.SelectedItem, txtThirdLevel.Text.Trim()));
                }

                if (!string.IsNullOrEmpty(txtFourthLevel.Text))
                {
                    _build.Append(string.Format("\\r4th Level ({0}): {1}", comboBox4.SelectedItem, txtFourthLevel.Text.Trim()));
                }

                if (!string.IsNullOrEmpty(txtFifthLevel.Text))
                {
                    _build.Append(string.Format("\\r5th Level ({0}): {1}", comboBox5.SelectedItem, txtFifthLevel.Text.Trim()));
                }

                if (!string.IsNullOrEmpty(txtSixthLevel.Text))
                {
                    _build.Append(string.Format("\\r6th Level ({0}): {1}", comboBox6.SelectedItem, txtSixthLevel.Text.Trim()));
                }

                if (!string.IsNullOrEmpty(txtSeventhLevel.Text))
                {
                    _build.Append(string.Format("\\r7th Level ({0}): {1}", comboBox7.SelectedItem, txtSeventhLevel.Text.Trim()));
                }

                if (!string.IsNullOrEmpty(txtEightLevel.Text))
                {
                    _build.Append(string.Format("\\r8th Level ({0}): {1}", comboBox8.SelectedItem, txtEightLevel.Text.Trim()));
                }

                if (!string.IsNullOrEmpty(txtNinthLevel.Text))
                {
                    _build.Append(string.Format("\\r9th Level ({0}): {1}", comboBox9.SelectedItem, txtNinthLevel.Text.Trim()));
                }
            }
        }

        private void BindSpellcastingAbilityNames()
        {
            List<string> _statNames = new List<string> { "", "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };

            cmbSpellCastingAbility.DataSource = null;
            cmbSpellCastingAbility.Items.Clear();
            cmbSpellCastingAbility.DataSource = _statNames;
        }

        private void BindSpellSlots()
        {
            List<string> _spellSlots = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots2 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots3 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots4 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots5 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots6 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots7 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots8 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots9 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };

            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            comboBox1.DataSource = _spellSlots;

            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
            comboBox2.DataSource = _spellSlots2;

            comboBox3.DataSource = null;
            comboBox3.Items.Clear();
            comboBox3.DataSource = _spellSlots3;

            comboBox4.DataSource = null;
            comboBox4.Items.Clear();
            comboBox4.DataSource = _spellSlots4;

            comboBox5.DataSource = null;
            comboBox5.Items.Clear();
            comboBox5.DataSource = _spellSlots5;

            comboBox6.DataSource = null;
            comboBox6.Items.Clear();
            comboBox6.DataSource = _spellSlots6;

            comboBox7.DataSource = null;
            comboBox7.Items.Clear();
            comboBox7.DataSource = _spellSlots7;

            comboBox8.DataSource = null;
            comboBox8.Items.Clear();
            comboBox8.DataSource = _spellSlots8;

            comboBox9.DataSource = null;
            comboBox9.Items.Clear();
            comboBox9.DataSource = _spellSlots9;
        }

        #region TEXT CHANGE FUNCTIONS
        void TxtSpellAbilityTextTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void TxtCantripsTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void TxtFirstLevelTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void TxtSecondLevelTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void TxtThirdLevelTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void TxtFourthLevelTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void TxtFifthLevelTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void TxtSixthLevelTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void TxtSeventhLevelTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void TxtEightLevelTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void TxtNinthLevelTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void ComboBox2SelectedIndexChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void ComboBox3SelectedIndexChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void ComboBox4SelectedIndexChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void ComboBox5SelectedIndexChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void ComboBox6SelectedIndexChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void ComboBox7SelectedIndexChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void ComboBox8SelectedIndexChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void ComboBox9SelectedIndexChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void CmbSpellCastingAbilitySelectedIndexChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void TxtSpellSaveTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        void TxtSpellHitTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        #endregion
    }
}

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
    public partial class NPC_Innate_Spellcasting : UserControl
    {
        // properties
        public string exposeInnateSpellcasting
        {
            get { return _build.ToString(); }
        }

        #region RESET PROPERTIES

        public string resettxtInnateSaveDc {
            set { txtInnateSaveDc.Text = value; }
        }

        public string resettxtAbilityText
        {
            set { txtAbilityText.Text = value; }
        }

        public string resettxtatwill
        {
            set { txtatwill.Text = value; }
        }

        public string resettxtone
        {
            set { txtone.Text = value; }
        }

        public string resettxttwo
        {
            set { txttwo.Text = value; }
        }

        public string resettxtthree
        {
            set { txtthree.Text = value; }
        }

        public string resettxtfour
        {
            set { txtfour.Text = value; }
        }

        public string resettxtfive
        {
            set { txtfive.Text = value; }
        }

        public int resetAbilityDropcmbInnateSpellCasting {
            set { cmbInnateSpellCasting.SelectedIndex = value; }
        }

        #endregion

        // Allows the use of the parents controls
        public LandingPage allowUse { get; set; }

        public NPC_Innate_Spellcasting()
        {
            InitializeComponent();
            BindInnateSpellCastingAbilityNames();
        }

        private void BindInnateSpellCastingAbilityNames()
        {
            List<string> _statNames = new List<string> { "", "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };

            cmbInnateSpellCasting.DataSource = null;
            cmbInnateSpellCasting.Items.Clear();
            cmbInnateSpellCasting.DataSource = _statNames;
        }

        // String Builders	
        StringBuilder _build = new StringBuilder();

        private void doCompile()
        {
            // Clear Builder
            _build.Clear();

            // Get Innate Spellcasting
            getInnateSpellcasting();

            // Some final formatting, its tiresome cathing all of these :S
            _build.Replace("..", ".");
            _build.Replace(". .", ".");
            _build.Replace(".  .", ".");

            if (allowUse == null)
                return;

            RichTextBox _rtc = (allowUse.Controls["rtcDisplay"] as RichTextBox);
            _rtc.Text = _build.ToString();
        }

        private void getInnateSpellcasting()
        {
            NPC_Stats _stat = new NPC_Stats();

            // Get the ability modifiers here
            if (cmbInnateSpellCasting.SelectedIndex != 0 && !string.IsNullOrEmpty(txtInnateSaveDc.Text))
            {
                _build.Append(Environment.NewLine);
                _build.Append("Innate Spellcasting.");
                _build.Append(Environment.NewLine);
                _build.Append(string.Format("The {2}'s spell casting ability is {0} (spell save DC {1}). ", cmbInnateSpellCasting.SelectedItem,
                                            !String.IsNullOrEmpty(txtInnateSaveDc.Text) ? txtInnateSaveDc.Text : "0",
                                             _stat.getNameforInnateSpellCastingUserControl));

                if (!String.IsNullOrEmpty(txtAbilityText.Text))
                {
                    _build.Append(string.Format("\\r{0}", txtAbilityText.Text));
                }

                if (!string.IsNullOrEmpty(txtatwill.Text))
                {
                    _build.Append("\\rAt will: " + txtatwill.Text.Trim());
                }

                if (!string.IsNullOrEmpty(txtone.Text))
                {
                    _build.Append("\\r1/day each: " + txtone.Text.Trim());
                }

                if (!string.IsNullOrEmpty(txttwo.Text))
                {
                    _build.Append("\\r2/day each: " + txttwo.Text.Trim());
                }

                if (!string.IsNullOrEmpty(txtthree.Text))
                {
                    _build.Append("\\r3/day each: " + txtthree.Text.Trim());
                }

                if (!string.IsNullOrEmpty(txtfour.Text))
                {
                    _build.Append("\\r4/day each: " + txtfour.Text.Trim());
                }

                if (!string.IsNullOrEmpty(txtfive.Text))
                {
                    _build.Append("\\r5/day each: " + txtfive.Text.Trim());
                }
            }
        }

        #region TEXT CHANGE EVENTS
        void CmbInnateSpellCastingSelectedIndexChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        void TxtInnateSaveDcTextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtAbilityText_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtatwill_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtone_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txttwo_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtthree_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtfour_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtfive_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FG5EParser.User_Controls.Class_Controls
{
    public partial class Class_Basics : UserControl
    {
        public string exposeClassBasics {
            get { doCompile(); return _build.ToString(); }
        }

        public string resetTextBoxes {
            set { doReset(value); }
        }

        public string exposeClassName {
            get { return txtClassName.Text; }
        }

        public Class_Basics()
        {
            InitializeComponent();
        }

        StringBuilder _build = new StringBuilder();

        private void doCompile()
        {
            _build.Clear();

            //get Name
            getName();
            //get HP
            getHP();
            //get proffs
            getProficiencies();
            //get starting equipment
            getEquipment();

            if (allowUse == null)
                return;

            RichTextBox _rtc = (allowUse.Controls["rtcDisplay"] as RichTextBox);
            _rtc.Text = _build.ToString();
        }

        private void getName()
        {
            if (!string.IsNullOrEmpty(txtClassName.Text))
            {
                _build.Append(string.Format("##;{0}", txtClassName.Text.Trim()));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<CLASS NAME REQUIRED>");
                _build.Append(Environment.NewLine);
            }
        }

        // Allows the use of the parents controls
        public LandingPage allowUse { get; set; }

        public string doNameCompile()
        {
            return txtClassName.Text;
        }

        private void getEquipment()
        {
            _build.Append("Equipment");
            _build.Append(Environment.NewLine);

            if (!string.IsNullOrEmpty(rtbEquipment.Text))
            {
                _build.Append(string.Format("{0}", rtbEquipment.Text.Trim()));
            }
            else
            {
                _build.Append("<EQUIPMENT REQUIRED>");
            }
        }

        private void getProficiencies()
        {
            _build.Append("Proficiencies");
            _build.Append(Environment.NewLine);

            if (!string.IsNullOrEmpty(txtArmor.Text))
            {
                _build.Append(string.Format("Armor: {0}", txtArmor.Text.Trim()));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<ARMOR REQUIRED>");
                _build.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(txtWeapons.Text))
            {
                _build.Append(string.Format("Weapons: {0}", txtWeapons.Text.Trim()));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<ARMOR WEAPONS>");
                _build.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(txtTools.Text))
            {
                _build.Append(string.Format("Tools: {0}", txtTools.Text.Trim()));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("Tools: None");
                _build.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(txtSavingThrows.Text))
            {
                _build.Append(string.Format("Saving Throws: {0}", txtSavingThrows.Text.Trim()));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<SAVING THROWS REQUIRED>");
                _build.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(txtSkills.Text))
            {
                _build.Append(string.Format("Skills: {0}", txtSkills.Text.Trim()));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<SKILLS REQUIRED>");
                _build.Append(Environment.NewLine);
            }
        }

        private void getHP()
        {
            _build.Append("#de;");
            _build.Append(Environment.NewLine);
            _build.Append("Hit Points");
            _build.Append(Environment.NewLine);

            if (!string.IsNullOrEmpty(txtHitDice.Text))
            {
                _build.Append(string.Format("Hit Dice: {0}", txtHitDice.Text.Trim()));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<HIT DICE REQUIRED>");
                _build.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(txtHitPointsAtFirstLevel.Text))
            {
                _build.Append(string.Format("Hit Points at 1st Level: {0}", txtHitPointsAtFirstLevel.Text.Trim()));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<HIT POINTS AT FIRST LEVEL REQUIRED>");
                _build.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(txtHitPointsAfterFirstLevel.Text))
            {
                _build.Append(string.Format("Hit Points at Higher Levels: {0}", txtHitPointsAfterFirstLevel.Text.Trim()));
                _build.Append(Environment.NewLine);
            }
            else
            {
                _build.Append("<HIT POINTS AFTER FIRST LEVEL REQUIRED>");
                _build.Append(Environment.NewLine);
            }
        }

        private void makeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem _tsmi = (ToolStripMenuItem)sender;
            ContextMenuStrip _cms = (ContextMenuStrip)_tsmi.Owner;
            RichTextBox _rtb = (RichTextBox)_cms.SourceControl;

            Utilities.ContextMenuFunctionHelper _context = new Utilities.ContextMenuFunctionHelper();

            _rtb.SelectedText = _context.returnFormatted(_rtb.SelectedText, "list");
        }

        #region TEXT CHANGED EVENTS

        private void txtClassName_TextChanged(object sender, EventArgs e)
        {
            doNameCompile();
            doCompile();
        }

        private void txtHitDice_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtHitPointsAtFirstLevel_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtHitPointsAfterFirstLevel_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtArmor_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtWeapons_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void txtTools_TextChanged(object sender, EventArgs e)
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

        private void rtbEquipment_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void doReset(string value)
        {
            if (value == "1")
            {
                // RESET ALL TEXTBOXES
                txtClassName.Text = string.Empty;

                txtHitDice.Text = string.Empty;
                txtHitPointsAtFirstLevel.Text = string.Empty;
                txtHitPointsAfterFirstLevel.Text = string.Empty;
                
                txtArmor.Text = string.Empty;
                txtWeapons.Text = string.Empty;
                txtTools.Text = string.Empty;
                txtSavingThrows.Text = string.Empty;                
                txtSkills.Text = string.Empty;

                rtbEquipment.Text = string.Empty;
            }
            else
            {
                doCompile();
                doNameCompile();
            }
        }

        #endregion
    }
}

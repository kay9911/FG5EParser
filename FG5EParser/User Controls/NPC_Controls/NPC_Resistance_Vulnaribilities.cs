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
    public partial class NPC_Resistance_Vulnaribilities : UserControl
    {
        // properties
        public string exposeResAndVul
        {
            get { return _build.ToString(); }
        }

        // Allows the use of the parents controls
        public LandingPage allowUse { get; set; }

        public NPC_Resistance_Vulnaribilities()
        {
            InitializeComponent();
        }

        // String Builders
        StringBuilder _build = new StringBuilder();

        private void doCompile()
        {
            // Clear Builder
            _build.Clear();

            // Start Building
            getDamageVul();
            getDamageRes();
            getDamageImm();
            getConditionImm();

            // Some final formatting, its tiresome cathing all of these :S
            _build.Replace("..", ".");
            _build.Replace(". .", ".");
            _build.Replace(".  .", ".");

            if (allowUse == null)
                return;

            RichTextBox _rtc = (allowUse.Controls["rtcDisplay"] as RichTextBox);
            _rtc.Text = _build.ToString();
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

        #region TEXT CHANGED FUNCTIONS
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

        public void RefreshAll()
        {
            txtDMGVUL.Text = string.Empty;
            txtDMGRES.Text = string.Empty;
            txtDMGIMM.Text = string.Empty;
            txtCONIMM.Text = string.Empty;
        }
    }
}

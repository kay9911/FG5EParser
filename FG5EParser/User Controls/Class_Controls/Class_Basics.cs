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
        public Class_Basics()
        {
            InitializeComponent();

            doCompile();
        }

        StringBuilder _build = new StringBuilder();

        private void doCompile()
        {
            _build.Clear();

            //get HP
            getHP();
            //get proffs
            getProficiencies();
        }

        private void getProficiencies()
        {
            if (!string.IsNullOrEmpty(txtArmor.Text))
            {
                _build.Append(txtArmor.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtWeapons.Text))
            {
                _build.Append(txtWeapons.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtTools.Text))
            {
                _build.Append(txtTools.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtSavingThrows.Text))
            {
                _build.Append(txtSavingThrows.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtTools.Text))
            {
                _build.Append(txtTools.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtSkills.Text))
            {
                _build.Append(txtSkills.Text.Trim());
            }
        }

        private void getHP()
        {
            if (!string.IsNullOrEmpty(txtHitDice.Text))
            {
                _build.Append(txtHitDice.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtHitPointsAtFirstLevel.Text))
            {
                _build.Append(txtHitPointsAtFirstLevel.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtHitPointsAfterFirstLevel.Text))
            {
                _build.Append(txtHitPointsAfterFirstLevel.Text.Trim());
            }
        }
    }
}

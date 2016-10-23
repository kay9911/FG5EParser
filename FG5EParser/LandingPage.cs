using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FG5EParser.User_Controls;
using FG5EParser.User_Controls.NPC_Controls;

namespace FG5EParser
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();

            this._stats.allowUse = this;
            //this._resvul.allowUse = this;
            this._actions.allowUse = this;
            this._innateSpellcasting.allowUse = this;
        }

        #region  Init the User Controls
        SetPaths _setPaths = new SetPaths();
        NPC_Spellcasting _spellcasting = new NPC_Spellcasting();
        NPC_Innate_Spellcasting _innateSpellcasting = new NPC_Innate_Spellcasting();
        NPC_Actions _actions = new NPC_Actions();
        //NPC_Resistance_Vulnaribilities _resvul = new NPC_Resistance_Vulnaribilities();
        NPC_Stats _stats = new NPC_Stats();
        #endregion

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            #region Hide all User Controls

            _setPaths.Hide();
            _stats.Hide();
            _spellcasting.Hide();
            _innateSpellcasting.Hide();
            _actions.Hide();
            //_resvul.Hide();

            #endregion

            if (treeView1.SelectedNode.Name == "_setPath")
            {
                pnlMain.Controls.Add(_setPaths);
                _setPaths.Show();
            }

            #region NPC USER CONTROLS

            if (treeView1.SelectedNode.Name == "_NPC")
            {
                pnlMain.Controls.Add(_stats);
                _stats.Show();

                //pnlMain.Controls.Add(_resvul);
                //_resvul.Show();

                pnlMain.Controls.Add(_actions);
                _actions.Show();

                pnlMain.Controls.Add(_innateSpellcasting);
                _innateSpellcasting.Show();

                pnlMain.Controls.Add(_spellcasting);
                _spellcasting.Show();

                // Display all text blocks at the same time
                rtcDisplay.Text = _stats.exposeStats + _innateSpellcasting.exposeInnateSpellcasting + _actions.exposeActions;
            }

            if (treeView1.SelectedNode.Name == "_stats")
            {
                pnlMain.Controls.Add(_stats);
                _stats.Show();
            }

            // This is now included in the stats block
            //if (treeView1.SelectedNode.Name == "_resistance_and_vulnaribilities")
            //{
            //    pnlMain.Controls.Add(_resvul);
            //    _resvul.Show();
            //}

            if (treeView1.SelectedNode.Name == "_actions")
            {
                pnlMain.Controls.Add(_actions);
                _actions.Show();
            }

            if (treeView1.SelectedNode.Name == "_innate_spellcasting")
            {
                pnlMain.Controls.Add(_innateSpellcasting);
                _innateSpellcasting.Show();
            }

            if (treeView1.SelectedNode.Name == "_spellcasting")
            {
                pnlMain.Controls.Add(_spellcasting);
                _spellcasting.Show();
            }

            #endregion
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_setPaths.InputText))
                {
                    if (!string.IsNullOrEmpty(_setPaths.OutputText) || _setPaths.UseInstalledPath == true)
                    {
                        // TO DO : Send files to parse at this point
                        MessageBox.Show("Parsing done!");
                    }
                    else
                    {
                        MessageBox.Show("An output path is mandatory, please select a path for the parsed modules to go to or else check the \"Use Installed Path\" checkbox to have them directly delivered to your modules folder");
                    }
                }
                else
                {
                    MessageBox.Show("An input path is mandatory, please select the file that you would like to run through the parser.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong :c " + ex.Message);
            }
        }
    }
}

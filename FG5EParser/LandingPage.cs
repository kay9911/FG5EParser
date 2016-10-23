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

namespace FG5EParser
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        #region  Init the User Controls
        SetPaths _setPaths = new SetPaths();
        NPC _npc = new NPC();
        #endregion

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            #region Hide all User Controls

            _setPaths.Hide();
            _npc.Hide();

            #endregion

            if (treeView1.SelectedNode.Name == "_setPath")
            {
                pnlMain.Controls.Add(_setPaths);
                _setPaths.Show();
            }

            if (treeView1.SelectedNode.Name == "_NPC")
            {
                pnlMain.Controls.Add(_npc);
                _npc.Show();
            }
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

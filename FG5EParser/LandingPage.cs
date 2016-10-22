using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FG5EParser
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
            treeView1.BorderStyle = BorderStyle.Fixed3D;
            this.IsMdiContainer = true;
        }

        // Init the User Controls
        SetPaths _setPaths = new SetPaths();
        Class _class = new Class();
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            #region Hide all User Controls

            _setPaths.Hide();
            _class.Hide();

            #endregion

            if (treeView1.SelectedNode.Name == "_setPath")
            {               
                pnlMain.Controls.Add(_setPaths);
                _setPaths.Show();
            }

            if (treeView1.SelectedNode.Text == "Test")
            {
                pnlMain.Controls.Add(_class);
                _class.Show();
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            Fantasy_Grounds_Parser_Tool.Text_Reader.TextReader _tr = new Fantasy_Grounds_Parser_Tool.Text_Reader.TextReader();
            try
            {
                if (!string.IsNullOrEmpty(_setPaths.InputText))
                {
                    if (!string.IsNullOrEmpty(_setPaths.OutputText) || _setPaths.UseInstalledPath == true)
                    {
                        _tr.ProcesNPCXML(_setPaths.InputText, _setPaths.ModuleName, _setPaths.CatalogueName, _setPaths.ImagePath, _setPaths.UseInstalledPath, _setPaths.OutputText, _setPaths.AuthorName, _setPaths.ForDMOnly);
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

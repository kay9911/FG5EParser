using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FG5EParser.User_Controls.Class_Controls
{
    public partial class Class_Buttons : UserControl
    {
        // properties
        public LandingPage LandingPageallowuse { get; set; }

        public Class_Buttons()
        {
            InitializeComponent();
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(LandingPageallowuse.sendClassPath()))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = true;

                if (choofdlog.ShowDialog() == DialogResult.OK)
                {
                    LandingPageallowuse.setClassPath = choofdlog.FileName;
                }
            }
            else
            {
                if (LandingPageallowuse.sendClassisReady())
                {
                    TextWriter tsw = new StreamWriter(LandingPageallowuse.sendClassPath(), true);

                    //tsw.WriteLine(Environment.NewLine);

                    tsw.WriteLine(LandingPageallowuse.sendClassBlocks.ToString());

                    tsw.Close();

                    // Reset all fields back to defaults

                    LandingPageallowuse.RefreshClassBasics();
                    LandingPageallowuse.RefreshClassAbilities();
                    LandingPageallowuse.RefreshClassDescription();
                    LandingPageallowuse.RefreshClassFeatures();
                }
                else
                    MessageBox.Show("Please check the information, you may have some incorrect values");
            }
        }

        private void btnRefreshAll_Click(object sender, EventArgs e)
        {
            LandingPageallowuse.RefreshClassBasics();
            LandingPageallowuse.RefreshClassAbilities();
            LandingPageallowuse.RefreshClassDescription();
            LandingPageallowuse.RefreshClassFeatures();
        }
    }
}

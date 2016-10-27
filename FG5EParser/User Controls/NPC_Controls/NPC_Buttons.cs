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

namespace FG5EParser.User_Controls.NPC_Controls
{
    public partial class NPC_Buttons : UserControl
    {
        // properties
        public LandingPage LandingPageallowuse { get; set; }

        public NPC_Buttons()
        {
            InitializeComponent();
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(LandingPageallowuse.sendNPCPath()))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = true;

                if (choofdlog.ShowDialog() == DialogResult.OK)
                {
                    LandingPageallowuse.setNPCPath = choofdlog.FileName;           
                }
            }
            else
            {
                if (LandingPageallowuse.sendNPCisready())
                {
                    TextWriter tsw = new StreamWriter(LandingPageallowuse.sendNPCPath(), true);

                    tsw.WriteLine(Environment.NewLine);

                    LandingPageallowuse.sendNPCStatBlocks.Replace("..", ".");

                    tsw.WriteLine(LandingPageallowuse.sendNPCStatBlocks.ToString().Replace("  ", " "));

                    tsw.Close();

                    // Reset all fields back to defaults

                    LandingPageallowuse.RefreshNPCInnateSpellcasting();
                    LandingPageallowuse.RefreshNPCSpellcasting();
                    LandingPageallowuse.RefreshNPCActions();
                    LandingPageallowuse.RefreshNPCStats();
                }
                else
                    MessageBox.Show("Please check the information, you may have some incorrect values");
            }
        }

        private void btnRefreshAll_Click(object sender, EventArgs e)
        {            
            LandingPageallowuse.RefreshNPCInnateSpellcasting();
            LandingPageallowuse.RefreshNPCSpellcasting();
            LandingPageallowuse.RefreshNPCActions();
            LandingPageallowuse.RefreshNPCStats();
        }
    }
}

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
    public partial class Class_Description : UserControl
    {
        public Class_Description()
        {
            InitializeComponent();
        }

        private void makeHeaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbClassDescriptions.SelectedText = string.Format("#h;{0}", rtbClassDescriptions.SelectedText);            
        }

        private void makeBoldPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbClassDescriptions.SelectedText = string.Format("#bp;{0}", rtbClassDescriptions.SelectedText);
        }

        private void makeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder _makeTable = new StringBuilder();

            _makeTable.Append(rtbClassDescriptions.SelectedText);

            List<string> _builder = new List<string>(_makeTable.ToString().Split(new string[] { "\n" }, StringSplitOptions.None));

            for (int i = 0; i < _builder.Count; i++)
            {
                _builder[i] = _builder[i].Replace(" ", "; ");
            }

            _makeTable = new StringBuilder();

            // First line
            _makeTable.Append("#ts;");
            _makeTable.Append(Environment.NewLine);

            // Header which will be the first line
            _makeTable.Append("#th;" + _builder[0]);
            _makeTable.Append(Environment.NewLine);

            // Rest of the rows
            for (int i = 1; i < _builder.Count; i++)
            {
                _makeTable.Append("#tr;" + _builder[i]);
                _makeTable.Append(Environment.NewLine);
            }

            // Last Line
            _makeTable.Append("#te;");

            rtbClassDescriptions.SelectedText = _makeTable.ToString();
        }
    }
}

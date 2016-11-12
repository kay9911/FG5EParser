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
        public string exposeClassDescriptions
        {
            get { doCompile(); return _build.ToString(); }
        }

        public Class_Description()
        {
            InitializeComponent();
        }

        // Allows the use of the parents controls
        public LandingPage allowUse { get; set; }

        StringBuilder _build = new StringBuilder();

        private void doCompile()
        {
            _build.Clear();

            getClassDescriptionText();

            if (allowUse == null)
                return;

            RichTextBox _rtc = (allowUse.Controls["rtcDisplay"] as RichTextBox);
            _rtc.Text = _build.ToString();
        }

        private void getClassDescriptionText()
        {
            _build.Append(rtbClassDescriptions.Text);
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
                _builder[i] = _builder[i].Replace(" ", ";");
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

        private void rtbClassDescriptions_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void makeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder _makeTable = new StringBuilder();

            _makeTable.Append(rtbClassDescriptions.SelectedText);

            List<string> _builder = new List<string>(_makeTable.ToString().Split(new string[] { "\n" }, StringSplitOptions.None));

            _makeTable = new StringBuilder();

            // First line
            _makeTable.Append("#ls;");
            _makeTable.Append(Environment.NewLine);

            // Rest of the rows
            for (int i = 0; i < _builder.Count; i++)
            {
                _makeTable.Append("#li;" + _builder[i]);
                _makeTable.Append(Environment.NewLine);
            }

            // Last Line
            _makeTable.Append("#le;");

            rtbClassDescriptions.SelectedText = _makeTable.ToString();
        }
    }
}

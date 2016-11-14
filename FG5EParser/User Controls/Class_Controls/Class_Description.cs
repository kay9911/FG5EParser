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

        private void rtbClassDescriptions_TextChanged(object sender, EventArgs e)
        {
            doCompile();
        }

        private void getClassDescriptionText()
        {
            _build.Append(rtbClassDescriptions.Text);
        }

        private void makeHeaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem _tsmi = (ToolStripMenuItem)sender;
            ContextMenuStrip _cms = (ContextMenuStrip)_tsmi.Owner;
            RichTextBox _rtb = (RichTextBox)_cms.SourceControl;

            Utilities.ContextMenuFunctionHelper _context = new Utilities.ContextMenuFunctionHelper();

            _rtb.SelectedText = _context.returnFormatted(_rtb.SelectedText, "header");
        }

        private void makeBoldPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem _tsmi = (ToolStripMenuItem)sender;
            ContextMenuStrip _cms = (ContextMenuStrip)_tsmi.Owner;
            RichTextBox _rtb = (RichTextBox)_cms.SourceControl;

            Utilities.ContextMenuFunctionHelper _context = new Utilities.ContextMenuFunctionHelper();

            _rtb.SelectedText = _context.returnFormatted(_rtb.SelectedText, "bold");
        }

        private void makeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem _tsmi = (ToolStripMenuItem)sender;
            ContextMenuStrip _cms = (ContextMenuStrip)_tsmi.Owner;
            RichTextBox _rtb = (RichTextBox)_cms.SourceControl;

            Utilities.ContextMenuFunctionHelper _context = new Utilities.ContextMenuFunctionHelper();

            _rtb.SelectedText = _context.returnFormatted(_rtb.SelectedText, "table");
        }

        private void makeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem _tsmi = (ToolStripMenuItem)sender;
            ContextMenuStrip _cms = (ContextMenuStrip)_tsmi.Owner;
            RichTextBox _rtb = (RichTextBox)_cms.SourceControl;

            Utilities.ContextMenuFunctionHelper _context = new Utilities.ContextMenuFunctionHelper();

            _rtb.SelectedText = _context.returnFormatted(_rtb.SelectedText, "list");
        }
    }
}

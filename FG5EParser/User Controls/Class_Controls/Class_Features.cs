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
    public partial class Class_Features : UserControl
    {
        // Allows the use of the parents controls
        public LandingPage allowUse { get; set; }

        public string exposeFeatures
        {
            get { return _build.ToString(); }
        }

        public Class_Features()
        {
            InitializeComponent();
        }

        StringBuilder _build = new StringBuilder();

        StringBuilder _buildActions = new StringBuilder();
        List<KeyValuePair<string, string>> _action = new List<KeyValuePair<string, string>>();

        private void doCompile()
        {
            _build.Clear();

            // Get Actions
            _build.Append(_buildActions.ToString());

            if (allowUse == null)
                return;

            RichTextBox _rtc = (allowUse.Controls["rtcDisplay"] as RichTextBox);
            _rtc.Text = _build.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check Feature Name
            if (!string.IsNullOrEmpty(txtFeatureName.Text))
            {
                // Check Feature Levels
                if (!string.IsNullOrEmpty(txtFeatureLevels.Text))
                {
                    // CHeck Feature Description
                    if (!string.IsNullOrEmpty(rtbFeatureDescription.Text))
                    {
                        // Clear the builder
                        _buildActions.Clear();

                        // Prepare the feature name string

                        string _formattedName = string.Format("#fe;{0};{1}"
                            , txtFeatureName.Text.Trim()
                            , txtFeatureLevels.Text.Replace(" ",",")
                            );

                        // Insert into the keyvalue pair list
                        _action.Add(new KeyValuePair<string, string>(_formattedName,rtbFeatureDescription.Text.Trim()));

                        // Clear the text boxes
                        txtFeatureName.Text = string.Empty;
                        txtFeatureLevels.Text = string.Empty;
                        rtbFeatureDescription.Text = string.Empty;

                        foreach (KeyValuePair<string, string> pair in _action)
                        {
                            string _format = string.Format("{0}{1}{2}", pair.Key.ToString(), Environment.NewLine ,pair.Value.ToString());
                            _buildActions.Append(Environment.NewLine);
                            _buildActions.Append(_format);
                        }

                        doCompile();

                    } // Feature Description
                    else
                    {
                        MessageBox.Show("Feature Description Required");
                    }
                } // Feature Levels
                else
                {
                    MessageBox.Show("Feature Level/s Required");
                }
            } // Feature Name
            else
            {
                MessageBox.Show("Feature Name Required");
            }            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _buildActions.Clear();
            _action.Clear();
            doCompile();
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

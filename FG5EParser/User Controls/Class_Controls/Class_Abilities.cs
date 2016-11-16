using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FG5EParser.Base_Class;

namespace FG5EParser.User_Controls.Class_Controls
{
    public partial class Class_Abilities : UserControl
    {
        // Allows the use of the parents controls
        public LandingPage allowUse { get; set; }

        public string exposeAbilities
        {
            get { return _build.ToString(); }
        }

        public string resetTextBoxes
        {
            set { doReset(value); }
        }

        public Class_Abilities()
        {
            InitializeComponent();

            // On form load
            cmbPathSelect.Items.Add("Select One");
            cmbPathSelect.SelectedIndex = 0;

            disableControls();
        }

        StringBuilder _build = new StringBuilder();
        List<ClassFeatures> _abilityFeatures = new List<ClassFeatures>();
        List<string> _abilityList = new List<string>();

        private void doCompile()
        {
            _build.Clear();
            // Get the archtype name

            if (!string.IsNullOrEmpty(txtArchtypeName.Text.Trim()))
            {
                _build.Append("#abh;" + txtArchtypeName.Text.Trim());
            }

            _build.Append(Environment.NewLine);

            getArchtypeList();

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
                        // NEW : PREPARE THE FEATURE CLASS
                        ClassFeatures _abilityFeature = new ClassFeatures();

                        _abilityFeature.FeatureName = txtFeatureName.Text.Trim();
                        _abilityFeature.FeatureLevels = txtFeatureLevels.Text.Trim();
                        _abilityFeature.FeatureDescription = rtbFeatureDescription.Text.Trim();
                        _abilityFeature.UnderArchtype = cmbPathSelect.Text;

                        // Add to list
                        _abilityFeatures.Add(_abilityFeature);

                        // Clear the text boxes
                        txtFeatureName.Text = string.Empty;
                        txtFeatureLevels.Text = string.Empty;
                        rtbFeatureDescription.Text = string.Empty;

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

        private void getArchtypeList()
        {
            StringBuilder _formatAbilities = new StringBuilder();

            // Loop over the list of archtypes

            foreach (string _archtype in _abilityList)
            {
                _build.Append("#ab;" + _archtype.Trim());          

                for (int i = 0; i < _abilityFeatures.Count; i++)
                {
                    if (_abilityFeatures[i].UnderArchtype == _archtype.Split(new string[] { "\n" }, StringSplitOptions.None)[0].Replace("#ab;","").Trim())
                    {
                        _build.Append(Environment.NewLine);
                        
                        // ability/feature formatting
                        _build.Append(string.Format("#abf;{0};{1}"
                            , _abilityFeatures[i].FeatureName.Trim()
                            , _abilityFeatures[i].FeatureLevels.Replace(" ",",").Trim()));

                        _build.Append(Environment.NewLine);

                        _build.Append(_abilityFeatures[i].FeatureDescription.Trim());
                    }
                }

                // next #ab; on new line
                _build.Append(Environment.NewLine);
            }
        }

        private void btnAddArchtype_Click(object sender, EventArgs e)
        {
            StringBuilder _formatAbility = new StringBuilder();

            _formatAbility.Append(txtPathName.Text.Trim());
            _formatAbility.Append(Environment.NewLine);
            _formatAbility.Append(rtbPathDescription.Text.Trim());

            _abilityList.Add(_formatAbility.ToString());

            // Add to drop down
            cmbPathSelect.Items.Add(txtPathName.Text.Trim());
            cmbPathSelect.Enabled = true;

            txtPathName.Text = string.Empty;
            rtbPathDescription.Text = string.Empty;
        }

        private void cmbPathSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPathSelect.SelectedIndex != 0)
            {
                enableControls();
            }
            else
            {
                disableControls();
            }
        }

        private void disableControls()
        {
            txtFeatureName.Enabled = false;
            txtFeatureLevels.Enabled = false;
            rtbFeatureDescription.Enabled = false;
            cmbPathSelect.Enabled = false;

            btnAdd.Enabled = false;
        }

        private void enableControls()
        {
            txtFeatureName.Enabled = true;
            txtFeatureLevels.Enabled = true;
            rtbFeatureDescription.Enabled = true;
            cmbPathSelect.Enabled = true;

            btnAdd.Enabled = true;
        }

        private void btnRefreshPaths_Click(object sender, EventArgs e)
        {
            // Clear list
            _abilityList.Clear();

            cmbPathSelect.SelectedIndex = 0;
        }

        public void doReset(string value)
        {
            if (value == "1")
            {
                txtArchtypeName.Text = string.Empty;
                txtPathName.Text = string.Empty;
                rtbPathDescription.Text = string.Empty;

                cmbPathSelect.SelectedIndex = 0;
                txtFeatureName.Text = string.Empty;
                txtFeatureLevels.Text = string.Empty;
                rtbFeatureDescription.Text = string.Empty;

                // Clear the List
                _abilityList.Clear();

                // Remove all existing paths from the dropdown
                var _toadd = cmbPathSelect.Items.IndexOf(0);
                cmbPathSelect.Items.Clear();
                cmbPathSelect.Items.Add(_toadd);

                doCompile();
            }
            else
            {
                doCompile();
            }
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

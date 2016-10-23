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

namespace FG5EParser
{
    public partial class SetPaths : UserControl
    {

        #region Properties

        public string InputText {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        public string OutputText
        {
            get { return txtOutput.Text; }
            set { txtOutput.Text = value; }
        }

        public string ModuleName
        {
            get { return txtModuleName.Text; }
            set { txtModuleName.Text = value; }
        }

        public string CatalogueName
        {
            get { return txtCatName.Text; }
            set { txtCatName.Text = value; }
        }

        public string ImagePath
        {
            get { return txtImagePath.Text; }
            set { txtImagePath.Text = value; }
        }

        public string AuthorName
        {
            get { return txtAuthorName.Text; }
            set { txtAuthorName.Text = value; }
        }

        public bool UseInstalledPath
        {
            get { return chkUseInstalled.Checked; }
            set { chkUseInstalled.Checked = value; }
        }

        public bool ForDMOnly
        {
            get { return chkDmOnly.Checked; }
            set { chkDmOnly.Checked = value; }
        }

        #endregion

        public SetPaths()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = Path.GetFullPath(choofdlog.FileName);
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtOutput.Text = fbd.SelectedPath;
            }
        }

        private void chkUseInstalled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseInstalled.Checked)
            {
                txtOutput.Text = string.Empty;
                txtOutput.Enabled = false;
                btnOutput.Enabled = false;
            }
            else
            {
                btnOutput.Enabled = true;
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = Path.GetFullPath(choofdlog.FileName);
            }
        }
    }
}

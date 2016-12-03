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
using FG5EParser.User_Controls.NPC_Controls;

namespace FG5EParser
{
    public partial class SetPaths : UserControl
    {
        #region Properties

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

        public string SetNPCPath
        {
            get { return txtNPCPath.Text; }
            set { txtNPCPath.Text = value; }
        }

        public string SetClassPath
        {
            get { return txtClassPath.Text; }
            set { txtClassPath.Text = value; }
        }

        public string SetStoryPath {
            get { return txtStoryPath.Text; }
            set { txtStoryPath.Text = value; }
        }

        public string SetItemPath
        {
            get { return txtItemPath.Text; }
            set { txtItemPath.Text = value; }
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

        private void btnSetNPCPath_Click(object sender, EventArgs e)
        {
            // Process for opening and choosing where the info gets saved too

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                txtNPCPath.Text = choofdlog.FileName;
            }
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            // Process for opening and choosing where the info gets saved too

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                txtClassPath.Text = choofdlog.FileName;
            }
        }

        private void btnStory_Click(object sender, EventArgs e)
        {
            // Process for opening and choosing where the info gets saved too

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                txtStoryPath.Text = choofdlog.FileName;
            }
        }

        private void btnEquipment_Click(object sender, EventArgs e)
        {
            // Process for opening and choosing where the info gets saved too

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                txtItemPath.Text = choofdlog.FileName;
            }
        }
    }
}

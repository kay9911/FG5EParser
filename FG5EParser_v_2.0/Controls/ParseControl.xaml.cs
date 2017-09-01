using System.Windows;
using System.Windows.Forms;

namespace FG5EParser_v_2._0.Controls
{
    /// <summary>
    /// Interaction logic for ParseControl.xaml
    /// </summary>
    public partial class ParseControl : System.Windows.Controls.UserControl
    {
        public ParseControl()
        {
            InitializeComponent();
        }

        private void btnSelectImagePath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtImagePath.Text = choofdlog.FileName;
            }
        }

        private void btnSelectOutputPath_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog _fbd = new FolderBrowserDialog();

            if (_fbd.ShowDialog() == DialogResult.OK)
            {
                txtOutputPath.Text = _fbd.SelectedPath;
            }
        }

        private void btnBackgroundPathSave_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtBackgroundPath.Text = choofdlog.FileName;
            }
        }

        private void btnSelectTablesPath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtTablesPath.Text = choofdlog.FileName;
            }
        }

        private void btnSelectClassesPath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtClassesPath.Text = choofdlog.FileName;
            }
        }

        private void btnSelectEquipmentPath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtEquipmentPath.Text = choofdlog.FileName;
            }
        }

        private void btnSelectRacesPath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtRacesPath.Text = choofdlog.FileName;
            }
        }

        private void btnSelectSpellsPath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtSpellsPath.Text = choofdlog.FileName;
            }
        }

        private void btnSelectFeatsPath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtFeatsPath.Text = choofdlog.FileName;
            }
        }

        private void btnSelectNPCsPath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtNPCsPath.Text = choofdlog.FileName;
            }
        }

        private void btnSelectReferenceManualPath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtReferenceManualPath.Text = choofdlog.FileName;
            }
        }

        private void btnSelectStorylPath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtStoryPath.Text = choofdlog.FileName;
            }
        }

        private void btnSelectImageFilePath_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog choofdlog = new FolderBrowserDialog();

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                txtImageFilePath.Text = choofdlog.SelectedPath;
            }
        }

        private void btnSelectImagePinsPath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtImagePinsPath.Text = choofdlog.FileName;
            }
        }

        private void btnSelectMagicalItemPath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtMagicalItemPath.Text = choofdlog.FileName;
            }
        }
    }
}

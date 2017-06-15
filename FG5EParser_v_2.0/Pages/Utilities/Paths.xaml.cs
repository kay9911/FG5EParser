using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace FG5EParser_v_2._0.Pages.Utilities
{
    /// <summary>
    /// Interaction logic for Paths.xaml
    /// </summary>
    public partial class Paths : Page
    {
        public Paths()
        {
            InitializeComponent();
        }

        private void btnSelectImagePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtImagePath.Text = choofdlog.FileName;
                txtImagePath.IsEnabled = false;
            }
        }

        private void btnSelectOutputPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtOutputPath.Text = choofdlog.FileName;
                txtOutputPath.IsEnabled = false;
            }
        }

        private void btnBackgroundPathSave_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtBackgroundPath.Text = choofdlog.FileName;
                txtBackgroundPath.IsEnabled = false;
            }
        }

        private void btnSelectTablesPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtTablesPath.Text = choofdlog.FileName;
                txtTablesPath.IsEnabled = false;
            }
        }

        private void btnSelectClassesPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtClassesPath.Text = choofdlog.FileName;
                txtClassesPath.IsEnabled = false;
            }
        }

        private void btnSelectEquipmentPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtEquipmentPath.Text = choofdlog.FileName;
                txtEquipmentPath.IsEnabled = false;
            }
        }

        private void btnSelectRacesPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtRacesPath.Text = choofdlog.FileName;
                txtRacesPath.IsEnabled = false;
            }
        }

        private void btnSelectSpellsPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtSpellsPath.Text = choofdlog.FileName;
                txtSpellsPath.IsEnabled = false;
            }
        }

        private void btnSelectFeatsPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtFeatsPath.Text = choofdlog.FileName;
                txtFeatsPath.IsEnabled = false;
            }
        }

        private void btnSelectNPCsPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtNPCsPath.Text = choofdlog.FileName;
                txtNPCsPath.IsEnabled = false;
            }
        }
    }
}

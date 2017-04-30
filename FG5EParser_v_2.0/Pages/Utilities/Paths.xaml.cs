using FG5eParserLib;
using FG5eParserLib.View_Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void btnBackgroundPathSave_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                // Adding to resources
                Properties.Settings.Default.BackgroundTextPath = choofdlog.FileName;
                txtBackgroundPath.Text = choofdlog.FileName;
                txtBackgroundPath.IsEnabled = false;
            }
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
    }
}

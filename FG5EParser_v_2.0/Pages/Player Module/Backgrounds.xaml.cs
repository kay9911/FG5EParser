using FG5eParserLib.View_Mo.dels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace FG5EParser_v_2._0.Pages.Player_Module
{
    /// <summary>
    /// Interaction logic for Backgrounds.xaml
    /// </summary>
    public partial class Backgrounds : Page
    {
        BackgroundViewModel _bvm = new BackgroundViewModel();

        public string TablesTextPath { get; set; }

        // Textbox Index
        // 1. Personality
        // 2. Ideals
        // 3. Bonds
        // 4. Flaws

        int flg = 0;

        public Backgrounds()
        {
            InitializeComponent();
            DataContext = _bvm;         
        }

        private void btnSelectPersonality_Click(object sender, RoutedEventArgs e)
        {
            rtbOutput.Visibility = Visibility.Hidden;
            dtTableNames.Visibility = Visibility.Visible;
            flg = 1;
            getTableTextPath();
        }

        private void btnSelectIdeals_Click(object sender, RoutedEventArgs e)
        {
            rtbOutput.Visibility = Visibility.Hidden;
            dtTableNames.Visibility = Visibility.Visible;
            flg = 2;
            getTableTextPath();
        }

        private void btnSelectBonds_Click(object sender, RoutedEventArgs e)
        {
            rtbOutput.Visibility = Visibility.Hidden;
            dtTableNames.Visibility = Visibility.Visible;
            flg = 3;
            getTableTextPath();
        }

        private void btnSelectFlaws_Click(object sender, RoutedEventArgs e)
        {
            rtbOutput.Visibility = Visibility.Hidden;
            dtTableNames.Visibility = Visibility.Visible;
            flg = 4;
            getTableTextPath();
        }

        private void dtTableNames_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dtTableNames.SelectedItem == null)
            {
                // DO NOTHING
            }
            else
            {
                rtbOutput.Visibility = Visibility.Visible;
                dtTableNames.Visibility = Visibility.Hidden;
                if (flg == 1)
                {
                    txtPersonalityTraits.Text = dtTableNames.SelectedItem.ToString();
                    flg = 0;
                }
                if (flg == 2)
                {
                    txtIdeals.Text = dtTableNames.SelectedItem.ToString();
                    flg = 0;
                }
                if (flg == 3)
                {
                    txtBonds.Text = dtTableNames.SelectedItem.ToString();
                    flg = 0;
                }
                if (flg == 4)
                {
                    txtFlaws.Text = dtTableNames.SelectedItem.ToString();
                    flg = 0;
                }
            }
        }

        private void getTableTextPath()
        {
            if (string.IsNullOrEmpty(TablesTextPath))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = false;

                if (choofdlog.ShowDialog() == true)
                {
                    // Adding to resources
                    TablesTextPath = choofdlog.FileName;
                    _bvm._tableTextPath = TablesTextPath;
                }
            }
        }
    }
}

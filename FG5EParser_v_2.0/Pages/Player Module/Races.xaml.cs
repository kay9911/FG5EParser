using FG5eParserLib.View_Models;
using System.Windows.Controls;

namespace FG5EParser_v_2._0.Pages.Player_Module
{
    /// <summary>
    /// Interaction logic for Races.xaml
    /// </summary>
    public partial class Races : Page
    {
        RacesViewModel _RVM;

        public Races()
        {
            InitializeComponent();

            // Object Inits
            _RVM = new RacesViewModel();
            DataContext = _RVM;

            // Control Defaults
            txtSubRaceName.IsEnabled = false;
            txtSubRaceDetails.IsEnabled = false;
            txtSubRaceTraits.IsEnabled = false;
        }

        private void txtRaceName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRaceName.Text))
            {
                txtSubRaceName.IsEnabled = true;
                txtSubRaceDetails.IsEnabled = true;
                txtSubRaceTraits.IsEnabled = true;

                txtSubRaceName.Text = string.Empty;
                txtSubRaceDetails.Text = string.Empty;
                txtSubRaceTraits.Text = string.Empty;
            }
            else
            {
                txtSubRaceName.IsEnabled = false;
                txtSubRaceDetails.IsEnabled = false;
                txtSubRaceTraits.IsEnabled = false;
            }
        }
    }
}

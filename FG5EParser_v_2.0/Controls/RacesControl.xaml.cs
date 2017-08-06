using FG5eParserLib.View_Models;
using System.Windows.Controls;

namespace FG5EParser_v_2._0.Controls
{
    /// <summary>
    /// Interaction logic for RacesControl.xaml
    /// </summary>
    public partial class RacesControl : UserControl
    {
        // Constructor
        public RacesControl()
        {
            InitializeComponent();

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

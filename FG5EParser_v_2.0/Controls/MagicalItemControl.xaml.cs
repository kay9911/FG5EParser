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

namespace FG5EParser_v_2._0.Controls
{
    /// <summary>
    /// Interaction logic for MagicalItemControl.xaml
    /// </summary>
    public partial class MagicalItemControl : UserControl
    {
        public MagicalItemControl()
        {
            InitializeComponent();
            cmbType.ItemsSource = getEquipmentTypes();
            // Enabled only when subtype is entered
            //txtSubtypeDescription.IsEnabled = false;
        }

        // Functions
        private List<string> getEquipmentTypes()
        {
            List<string> _equipment = new List<string>() {
            "",
            "Adventuring Gear",
            "Armor",
            "Weapon",
            "Tools",
            "Mounts and Other Animals",
            "Tack, Harness, and Drawn Vehicles",
            "Waterborne Vehicles"
            };
            return _equipment;
        }

        private void DisableAll()
        {
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void txtSubType_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void btnSelectItems_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void dtItemNames_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }
    }
}

using FG5eParserLib.View_Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace FG5EParser_v_2._0.Pages.Player_Module
{
    /// <summary>
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class Equipment : Page
    {
        EquipmentViewModel _EVM;

        // Constructor
        public Equipment()
        {
            InitializeComponent();
            cmbType.ItemsSource = getEquipmentTypes();

            // Enabled only when subtype is entered
            txtSubtypeDescription.IsEnabled = false;

            _EVM = new EquipmentViewModel();
            DataContext = _EVM;
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
            txtAC.IsEnabled = false;
            txtStrength.IsEnabled = false;
            txtDamage.IsEnabled = false;
            txtWeaponProperties.IsEnabled = false;
            txtSpeed.IsEnabled = false;
            txtCarryingCapacity.IsEnabled = false;

            chkStealth.IsChecked = false;
            chkStealth.IsEnabled = false;
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Subtype reset
            txtSubType.Text = string.Empty;

            // Enabling logic goes here
            if (cmbType.SelectedItem.ToString() == "Adventuring Gear")
            {
                DisableAll();

                // Enables
                txtSubType.IsEnabled = true;
                txtItemName.IsEnabled = true;
                txtCost.IsEnabled = true;
                txtWeight.IsEnabled = true;
                txtItemDescription.IsEnabled = true;
            }

            if (cmbType.SelectedItem.ToString() == "Armor")
            {
                DisableAll();
                txtSubType.IsEnabled = true;
                txtItemName.IsEnabled = true;
                txtCost.IsEnabled = true;
                txtWeight.IsEnabled = true;
                txtItemDescription.IsEnabled = true;

                // Armor Related
                txtAC.IsEnabled = true;
                txtStrength.IsEnabled = true;
                chkStealth.IsEnabled = true;
            }

            if (cmbType.SelectedItem.ToString() == "Weapon")
            {
                DisableAll();
                txtSubType.IsEnabled = true;
                txtItemName.IsEnabled = true;
                txtCost.IsEnabled = true;
                txtWeight.IsEnabled = true;
                txtItemDescription.IsEnabled = true;

                // Weapon Related
                txtDamage.IsEnabled = true;
                txtWeaponProperties.IsEnabled = true;
            }

            if (cmbType.SelectedItem.ToString() == "Tools")
            {
                DisableAll();
                txtSubType.IsEnabled = true;
                txtItemName.IsEnabled = true;
                txtCost.IsEnabled = true;
                txtWeight.IsEnabled = true;
                txtItemDescription.IsEnabled = true;
            }

            if (cmbType.SelectedItem.ToString() == "Mounts and Other Animals")
            {
                DisableAll();
                txtSubType.IsEnabled = true;
                txtItemName.IsEnabled = true;
                txtCost.IsEnabled = true;
                txtItemDescription.IsEnabled = true;

                // Mounts and Other Animals related
                txtCarryingCapacity.IsEnabled = true;
                txtSpeed.IsEnabled = true;
            }

            if (cmbType.SelectedItem.ToString() == "Tack, Harness, and Drawn Vehicles")
            {
                DisableAll();
                txtSubType.IsEnabled = true;
                txtItemName.IsEnabled = true;
                txtCost.IsEnabled = true;
                txtWeight.IsEnabled = true;
                txtItemDescription.IsEnabled = true;
            }

            if (cmbType.SelectedItem.ToString() == "Waterborne Vehicles")
            {
                DisableAll();
                txtSubType.IsEnabled = true;
                txtItemName.IsEnabled = true;
                txtCost.IsEnabled = true;
                txtSpeed.IsEnabled = true;
                txtItemDescription.IsEnabled = true;
            }
        }

        private void txtSubType_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubType.Text))
            {
                txtSubtypeDescription.IsEnabled = false;
                txtSubtypeDescription.Text = string.Empty;
            }
            else
                txtSubtypeDescription.IsEnabled = true;
        }

        private void btnSelectItems_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (rtbOutput.Visibility == System.Windows.Visibility.Hidden)
            {
                rtbOutput.Visibility = System.Windows.Visibility.Visible;
                dtItemNames.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                rtbOutput.Visibility = System.Windows.Visibility.Hidden;
                dtItemNames.Visibility = System.Windows.Visibility.Visible;
            }


        }

        private void dtItemNames_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dtItemNames.SelectedItem == null)
            {
                // DO NOTHING
            }
            else
            {
                txtItemParts.Text = !string.IsNullOrEmpty(txtItemParts.Text) ? txtItemParts.Text + Environment.NewLine + _EVM.getSelectedItemName(dtItemNames.SelectedItem) :  _EVM.getSelectedItemName(dtItemNames.SelectedItem);
            }
        }
    }
}

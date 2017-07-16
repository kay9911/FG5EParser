using FG5eParserLib.View_Models;
using System;
using System.Windows.Controls;

namespace FG5EParser_v_2._0.Controls
{
    /// <summary>
    /// Interaction logic for SpellsControl.xaml
    /// </summary>
    public partial class SpellsControl : UserControl
    {
        SpellViewModel _SPV;
        public SpellsControl()
        {
            InitializeComponent();

            // Datacontext
            _SPV = new SpellViewModel();
            DataContext = _SPV;

            // UI Constants/Bindings
            cmbLevels.ItemsSource = _SPV._LevelList;
            cmbSpellSchool.ItemsSource = _SPV._SpellSchools;
        }

        private void btnAddFromList_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (dtSpellNames.Visibility == System.Windows.Visibility.Hidden)
            {
                dtSpellNames.Visibility = System.Windows.Visibility.Visible;
                txtOutput.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                dtSpellNames.Visibility = System.Windows.Visibility.Hidden;
                txtOutput.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void dtSpellNames_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dtSpellNames.SelectedItem == null)
            {
                // DO NOTHING
            }
            else
            {
                txtSpellList.Text = !string.IsNullOrEmpty(txtSpellList.Text) ? txtSpellList.Text + Environment.NewLine + _SPV.getSelectedSpellName(dtSpellNames.SelectedItem) : _SPV.getSelectedSpellName(dtSpellNames.SelectedItem);
            }
        }
    }
}

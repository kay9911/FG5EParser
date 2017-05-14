using FG5eParserLib.View_Models;
using System.Windows.Controls;

namespace FG5EParser_v_2._0.Pages.Player_Module
{
    /// <summary>
    /// Interaction logic for Spells.xaml
    /// </summary>
    public partial class Spells : Page
    {
        SpellViewModel _SPV;
        public Spells()
        {
            InitializeComponent();

            // Datacontext
            _SPV = new SpellViewModel();
            DataContext = _SPV;

            // UI Constants/Bindings
            cmbLevels.ItemsSource = _SPV._LevelList;
            cmbSpellSchool.ItemsSource = _SPV._SpellSchools;
        }
    }
}

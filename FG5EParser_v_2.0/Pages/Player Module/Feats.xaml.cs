using FG5eParserLib.View_Models;
using System.Windows.Controls;

namespace FG5EParser_v_2._0.Pages.Player_Module
{
    /// <summary>
    /// Interaction logic for Feats.xaml
    /// </summary>
    public partial class Feats : Page
    {
        FeatsViewModel _FVM;

        public Feats()
        {
            InitializeComponent();

            _FVM = new FeatsViewModel();
            DataContext = _FVM;
        }
    }
}

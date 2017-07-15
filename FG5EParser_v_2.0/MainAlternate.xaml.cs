// To access MetroWindow, add the following reference
using FG5eParserLib.View_Models;
using MahApps.Metro.Controls;

namespace FG5EParser_v_2._0
{
    /// <summary>
    /// Interaction logic for MainAlternate.xaml
    /// </summary>
    public partial class MainAlternate : MetroWindow
    {
        MainAlternateViewModel _MAVM;

        public MainAlternate()
        {
            InitializeComponent();
            _MAVM = new MainAlternateViewModel();
            DataContext = _MAVM;
        }
    }
}

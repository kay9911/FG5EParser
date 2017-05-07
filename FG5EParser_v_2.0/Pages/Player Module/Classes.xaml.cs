using FG5eParserLib.View_Models;
using System.Windows.Controls;

namespace FG5EParser_v_2._0.Pages.Player_Module
{
    /// <summary>
    /// Interaction logic for Classes.xaml
    /// </summary>
    public partial class Classes : Page
    {
        ClassesViewModel _CVM;

        public Classes()
        {
            InitializeComponent();
            _CVM = new ClassesViewModel();
            DataContext = _CVM;
        }
    }
}

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

        private void btnReview_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (txtOutput.Visibility == System.Windows.Visibility.Hidden)
            {
                txtOutput.Visibility = System.Windows.Visibility.Visible;
                // Refresh the output information
                _CVM.Output = _CVM.getOutput();
            }
            else
            {
                txtOutput.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}

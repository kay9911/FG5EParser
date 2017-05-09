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
            if (rtbOuput.Visibility == System.Windows.Visibility.Hidden)
            {
                rtbOuput.Visibility = System.Windows.Visibility.Visible;
                // Refresh the output information
                _CVM.Output = _CVM.getOutput();
            }
            else
            {
                rtbOuput.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}

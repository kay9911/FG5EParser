using FG5eParserLib.View_Models;
using System.Windows.Controls;

namespace FG5EParser_v_2._0.Controls
{
    /// <summary>
    /// Interaction logic for ClassControl.xaml
    /// </summary>
    public partial class ClassControl : UserControl
    {
        ClassesViewModel _CVM;
        public ClassControl()
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

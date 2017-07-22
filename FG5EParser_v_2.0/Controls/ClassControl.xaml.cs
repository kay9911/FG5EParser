using System.Windows.Controls;

namespace FG5EParser_v_2._0.Controls
{
    /// <summary>
    /// Interaction logic for ClassControl.xaml
    /// </summary>
    public partial class ClassControl : UserControl
    {
        public ClassControl()
        {
            InitializeComponent();
        }

        private void btnReview_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (txtOutput.Visibility == System.Windows.Visibility.Hidden)
            {
                txtOutput.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                txtOutput.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}

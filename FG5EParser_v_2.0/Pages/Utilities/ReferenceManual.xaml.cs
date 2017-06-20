using FG5eParserLib.Utility;
using System.Windows.Controls;

namespace FG5EParser_v_2._0.Pages.Utilities
{
    /// <summary>
    /// Interaction logic for ReferenceManual.xaml
    /// </summary>
    public partial class ReferenceManual : Page
    {
        ReferenceManualViewModel _rvm = new ReferenceManualViewModel();

        public ReferenceManual()
        {
            InitializeComponent();
            DataContext = _rvm;
        }
    }
}

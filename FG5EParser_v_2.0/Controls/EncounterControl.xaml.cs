using FG5eParserLib.Utility;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace FG5EParser_v_2._0.Controls
{
    /// <summary>
    /// Interaction logic for EncounterControl.xaml
    /// </summary>
    public partial class EncounterControl : UserControl
    {
        public EncounterControl()
        {
            InitializeComponent();
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dtNPCTable.Visibility == System.Windows.Visibility.Visible)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(dtNPCTable.ItemsSource);
                view.Filter = o =>
                {
                    var recordToIdentify = o as NPCRecord;
                    return recordToIdentify.Name.Contains(txtFilter.Text);
                };
            }
        }
    }
}

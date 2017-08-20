using FG5eParserLib.Utility;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace FG5EParser_v_2._0.Controls
{
    /// <summary>
    /// Interaction logic for BackgroundControl.xaml
    /// </summary>
    public partial class BackgroundControl : UserControl
    {
        // Constructor
        public BackgroundControl()
        {
            InitializeComponent();
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dtTextTable.Visibility == System.Windows.Visibility.Visible)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(dtTextTable.ItemsSource);
                view.Filter = o =>
                {
                    var recordToIdentify = o as TextRecord;
                    return (recordToIdentify.Title.Contains(txtFilter.Text));
                };
            }
        }
    }
}


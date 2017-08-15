using FG5eParserLib.Utility;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace FG5EParser_v_2._0.Controls
{
    /// <summary>
    /// Interaction logic for StoryControl.xaml
    /// </summary>
    public partial class StoryControl : UserControl
    {
        public StoryControl()
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
            if (dtEquipmentTable.Visibility == System.Windows.Visibility.Visible)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(dtEquipmentTable.ItemsSource);
                view.Filter = o =>
                {
                    var recordToIdentify = o as EquipmentRecord;
                    return (recordToIdentify.Item.Contains(txtFilter.Text) || recordToIdentify.Subtype.Contains(txtFilter.Text));
                };
            }
            if (dtImageTable.Visibility == System.Windows.Visibility.Visible)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(dtImageTable.ItemsSource);
                view.Filter = o =>
                {
                    var recordToIdentify = o as string;
                    return (recordToIdentify.Contains(txtFilter.Text));
                };
            }
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

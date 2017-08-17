using FG5eParserLib.Utility;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace FG5EParser_v_2._0.Controls
{
    /// <summary>
    /// Interaction logic for SpellsControl.xaml
    /// </summary>
    public partial class SpellsControl : UserControl
    {
        public SpellsControl()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dtSpellTable.Visibility == System.Windows.Visibility.Visible)
            {
                ICollectionView view = CollectionViewSource.GetDefaultView(dtSpellTable.ItemsSource);
                view.Filter = o =>
                {
                    var recordToIdentify = o as SpellRecord;
                    return recordToIdentify.Name.Contains(txtFilter.Text);
                };
            }
        }
    }
}

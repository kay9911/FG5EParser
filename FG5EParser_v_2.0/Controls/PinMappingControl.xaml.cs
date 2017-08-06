using FG5eParserLib.Utility;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FG5EParser_v_2._0.Controls
{
    /// <summary>
    /// Interaction logic for PinMappingControl.xaml
    /// </summary>
    public partial class PinMappingControl : UserControl
    {
        ImagePinsViewModel _IPVM;
        StoryEntry _crrentRow;

        double x;
        double y;

        public PinMappingControl()
        {
            InitializeComponent();
            _IPVM = new ImagePinsViewModel();
        }

        private void imageDock_MouseMove(object sender, MouseEventArgs e)
        {
            ImageSource imageSource = imageDock.Source;
            BitmapSource bitmapImage = (BitmapSource)imageSource;
            x = (e.GetPosition(imageDock).X * bitmapImage.PixelWidth / imageDock.ActualWidth);
            y = (e.GetPosition(imageDock).Y * bitmapImage.PixelHeight / imageDock.ActualHeight);

            lblXYCords.Content = string.Format("X:{0},Y:{1}", x.ToString(), y.ToString());
        }

        private void imageDock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _crrentRow = (StoryEntry)dtTemplateData.SelectedItem;
            if (_crrentRow != null)
            {
                _crrentRow.Coordinates = string.Format("{0};{1}", x.ToString(), y.ToString());
            }
        }
    }
}

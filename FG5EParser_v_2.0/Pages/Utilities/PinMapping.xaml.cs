using FG5eParserLib.Utility;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FG5EParser_v_2._0.Pages.Utilities
{
    /// <summary>
    /// Interaction logic for PinMapping.xaml
    /// </summary>
    public partial class PinMapping : Page
    {
        ImagePinsViewModel _IPVM;

        public PinMapping()
        {
            InitializeComponent();
            _IPVM = new ImagePinsViewModel();
            DataContext = _IPVM;
        }

        private void imageDock_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Windows.Point p = e.GetPosition(imageDock);
            double pixelWidth = imageDock.Source.Width;
            double pixelHeight = imageDock.Source.Height;

            double x = Math.Round(pixelWidth * p.X / imageDock.ActualWidth, 0, MidpointRounding.AwayFromZero);
            double y = Math.Round(pixelHeight * p.Y / imageDock.ActualHeight, 0, MidpointRounding.AwayFromZero);

            lblXYCords.Content = string.Format("X:{0},Y:{1}", x.ToString(), y.ToString());
        }

        private void btnSelectImage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog choofdlog = new Microsoft.Win32.OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                txtImagePath.Text = choofdlog.FileName;
                txtImagePath.IsEnabled = false;

                ImageSource _imageSource = new BitmapImage(new Uri(choofdlog.FileName));
                imageDock.Source = _imageSource;
            }
        }
    }
}

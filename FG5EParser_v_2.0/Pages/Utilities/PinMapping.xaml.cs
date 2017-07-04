using FG5eParserLib.Utility;
using System;
using System.Windows.Controls;

namespace FG5EParser_v_2._0.Pages.Utilities
{
    /// <summary>
    /// Interaction logic for PinMapping.xaml
    /// </summary>
    public partial class PinMapping : Page
    {
        ImagePinsViewModel _IPVM;
        StoryEntry _crrentRow;

        double x;
        double y;

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

            x = Math.Round(pixelWidth * p.X / imageDock.ActualWidth, 0, MidpointRounding.AwayFromZero);
            y = Math.Round(pixelHeight * p.Y / imageDock.ActualHeight, 0, MidpointRounding.AwayFromZero);

            lblXYCords.Content = string.Format("X:{0},Y:{1}", x.ToString(), y.ToString());
        }

        private void imageDock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _crrentRow = (StoryEntry)dtTemplateData.SelectedItem;
            if (_crrentRow != null)
            {
                _crrentRow.Coordinates = string.Format("{0};{1}", x.ToString(), y.ToString());
            }
        }
    }
}

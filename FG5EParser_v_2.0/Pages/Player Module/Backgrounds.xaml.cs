using FG5eParserLib.View_Mo.dels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FG5EParser_v_2._0.Pages.Utilities;

namespace FG5EParser_v_2._0.Pages.Player_Module
{
    /// <summary>
    /// Interaction logic for Backgrounds.xaml
    /// </summary>
    public partial class Backgrounds : Page
    {
        public Backgrounds()
        {
            InitializeComponent();
            //BackgroundViewModel _bvm = new BackgroundViewModel(Properties.Settings.Default.BackgroundTextPath);
            //this.DataContext = _bvm;
        }
    }
}

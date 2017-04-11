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

namespace FG5EParser_v_2._0.Pages.Player_Module
{
    /// <summary>
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class Equipment : Page
    {
        public Equipment()
        {
            InitializeComponent();

            cmbType.Items.Add("");
            cmbType.Items.Add("Adventuring Gear");
            cmbType.Items.Add("Armor");
            cmbType.Items.Add("Weapon");
            cmbType.Items.Add("Tools");
            cmbType.Items.Add("Mounts and Other Animals");
            cmbType.Items.Add("Tack, Harness, and Drawn Vehicles");
            cmbType.Items.Add("Waterborne Vehicles");
        }
    }
}

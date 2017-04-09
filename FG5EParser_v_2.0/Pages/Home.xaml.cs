﻿using FG5EParser_v_2._0.Pages.Player_Module;
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

namespace FG5EParser_v_2._0.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnBackgrounds_Click(object sender, RoutedEventArgs e)
        {
            Backgrounds _backgroundPage = new Backgrounds();
            NavigationService.Navigate(_backgroundPage);
        }

        private void btnRaces_Click(object sender, RoutedEventArgs e)
        {
            Races _racePage = new Races();
            NavigationService.Navigate(_racePage);
        }
    }
}
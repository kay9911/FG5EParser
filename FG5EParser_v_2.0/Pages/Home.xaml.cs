﻿using FG5EParser_v_2._0.Pages.DM_Module;
using FG5EParser_v_2._0.Pages.Player_Module;
using FG5EParser_v_2._0.Pages.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FG5EParser_v_2._0.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        Paths _pathsPage;

        public Home()
        {
            InitializeComponent();
            _pathsPage = new Paths();            
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

        private void btnEquipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment _equipmentPage = new Equipment();
            NavigationService.Navigate(_equipmentPage);
        }

        private void btnSpells_Click(object sender, RoutedEventArgs e)
        {
            Spells _spellsPage = new Spells();
            NavigationService.Navigate(_spellsPage);
        }

        private void btnFeats_Click(object sender, RoutedEventArgs e)
        {
            Feats _featsPage = new Feats();
            NavigationService.Navigate(_featsPage);
        }

        private void btnSkills_Click(object sender, RoutedEventArgs e)
        {
            Skills _skillsPage = new Skills();
            NavigationService.Navigate(_skillsPage);
        }

        private void btnClass_Click(object sender, RoutedEventArgs e)
        {
            Classes _classPage = new Classes();
            NavigationService.Navigate(_classPage);
        }

        private void btnParse_Click(object sender, RoutedEventArgs e)
        {            
            NavigationService.Navigate(_pathsPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NPCs _npcPage = new NPCs();
            NavigationService.Navigate(_npcPage);
        }

        private void btnReferenceManual_Click(object sender, RoutedEventArgs e)
        {
            ReferenceManual _referenceManualPage = new ReferenceManual();
            NavigationService.Navigate(_referenceManualPage);
        }

        private void btnImagesandMaps_Click(object sender, RoutedEventArgs e)
        {
            PinMapping _pinMappingPage = new PinMapping();
            NavigationService.Navigate(_pinMappingPage);
        }
    }
}

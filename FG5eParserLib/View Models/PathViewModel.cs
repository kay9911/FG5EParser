using FG5EParser.Utilities;
using FG5eParserModels.Utility_Modules;
using System;
using System.ComponentModel;
using System.Windows;

namespace FG5eParserLib.View_Models
{
    public class PathViewModel : INotifyPropertyChanged
    {
        //properties
        public RelayCommand ParseCommand { get; set; }

        private Paths _pathViewModel { get; set; }
        public Paths pathViewModel
        {
            get { return _pathViewModel; }
            set
            {
                _pathViewModel = value;
                OnPropertyChanged("pathViewModel");
            }
        }

        public string BackgroundPath
        {
            get { return pathViewModel.SetBackgroundPath; }
            set
            {
                pathViewModel.SetBackgroundPath = value;
                OnPropertyChanged("BackgroundPath");
            }
        }

        public string ClassPath
        {
            get { return pathViewModel.SetClassesPath; }
            set
            {
                pathViewModel.SetClassesPath = value;
                OnPropertyChanged("ClassPath");
            }
        }

        public string EquipmentPath
        {
            get { return pathViewModel.SetEquipmentPath; }
            set
            {
                pathViewModel.SetEquipmentPath = value;
                OnPropertyChanged("EquipmentPath");
            }
        }

        public string SpellPath
        {
            get { return pathViewModel.SetSpellsPath; }
            set
            {
                pathViewModel.SetSpellsPath = value;
                OnPropertyChanged("SpellPath");
            }
        }

        public string TablePath
        {
            get { return pathViewModel.SetTablesPath; }
            set
            {
                pathViewModel.SetTablesPath = value;
                OnPropertyChanged("TablePath");
            }
        }

        public string NPCPath
        {
            get { return pathViewModel.SetNPCsPath; }
            set
            {
                pathViewModel.SetNPCsPath = value;
                OnPropertyChanged("NPCPath");
            }
        }

        public string FeatPath
        {
            get { return pathViewModel.SetFeatsPath; }
            set
            {
                pathViewModel.SetFeatsPath = value;
                OnPropertyChanged("FeatPath");
            }
        }

        public string RacesPath
        {
            get { return pathViewModel.SetRacesPath; }
            set
            {
                pathViewModel.SetRacesPath = value;
                OnPropertyChanged("RacesPath");
            }
        }

        public string PinMappingPath
        {
            get { return pathViewModel.SetImagePinsPath; }
            set
            {
                pathViewModel.SetImagePinsPath = value;
                OnPropertyChanged("PinMappingPath");
            }
        }

        public string StoryPath
        {
            get { return pathViewModel.SetStoryPath; }
            set
            {
                pathViewModel.SetStoryPath = value;
                OnPropertyChanged("StoryPath");
            }
        }

        public string EncounterPath
        {
            get { return pathViewModel.SetEncountersPath; }
            set
            {
                pathViewModel.SetEncountersPath = value;
                OnPropertyChanged("EncounterPath");
            }
        }

        public string MagicalItemPath
        {
            get { return pathViewModel.SetMagicalEquipmentPath; }
            set
            {
                pathViewModel.SetMagicalEquipmentPath = value;
                OnPropertyChanged("MagicalItemPath");
            }
        }

        // Constructors
        public PathViewModel()
        {
            ParseCommand = new RelayCommand(Parse,CanParse);
            _pathViewModel = new Paths();
        }

        // Functions
        private void Parse(object _obj)
        {
            // Initiate parser here
            XMLParser _xml = new XMLParser();

            try
            {
                _xml.ParseXMLs(
                    pathViewModel.SetCatalogueName,
                    pathViewModel.SetModuleName,
                    pathViewModel.SetAuthorName,
                    pathViewModel.SetOutputPath,
                    pathViewModel.SetImagePath,
                    pathViewModel.SetOuputChecked,
                    pathViewModel.SetDMOnlyChecked,
                    pathViewModel.SetNPCsPath,
                    pathViewModel.SetClassesPath,
                    pathViewModel.SetStoryPath,
                    pathViewModel.SetEquipmentPath,
                    pathViewModel.SetMagicalEquipmentPath,
                    pathViewModel.SetEncountersPath,
                    null,
                    pathViewModel.SetTablesPath,
                    pathViewModel.SetBackgroundPath,
                    pathViewModel.SetRacesPath,
                    pathViewModel.SetSpellsPath,
                    pathViewModel.SetFeatsPath,
                    pathViewModel.SetReferenceManualPath,
                    pathViewModel.SetImageFolderPath,
                    pathViewModel.SetImagePinsPath
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Parser failed with the following error: " + ex);
            }
        }

        private bool CanParse(object _obj)
        {
            // TO DO: Validation Logic
            return true;
        }

        #region PROPERTY CHANGES
        // Declare the interface event
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}

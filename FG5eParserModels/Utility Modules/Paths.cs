using System.ComponentModel;

namespace FG5eParserModels.Utility_Modules
{
    public class Paths : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
                
        private string OutputPath { get; set; } 
               
        private string ModuleName { get; set; }
        private string CatalogueName { get; set; }
        private string AuthorName { get; set; }
        
        private string ImagePath { get; set; }
        private string StoryPath { get; set; }
        private string ClassesPath { get; set; }
        private string EquipmentPath { get; set; }
        private string MagicalEquipmentPath { get; set; }
        private string EncountersPath { get; set; }
        private string TablesPath { get; set; }
        private string ParcelsPath { get; set; }
        private string BackgroundsPath { get; set; }
        private string RacesPath { get; set; }
        private string NPCsPath { get; set; }

        private bool OuputIsChecked { get; set; }
        private bool DMOnlyIsChecked { get; set; }

        public string SetOutputPath
        {
            get { return OutputPath; }
            set
            {
                OutputPath = value;
                OnPropertyChanged("SetOutputPath");
            }
        }

        public bool SetOuputChecked
        {
            get { return OuputIsChecked; }
            set
            {
                OuputIsChecked = value;
                OnPropertyChanged("SetOuputChecked");
            }
        }

        public string SetModuleName
        {
            get { return ModuleName; }
            set
            {
                ModuleName = value;
                OnPropertyChanged("SetModuleName");
            }
        }

        public string SetCatalogueName
        {
            get { return CatalogueName; }
            set
            {
                CatalogueName = value;
                OnPropertyChanged("SetCatalogueName");
            }
        }

        public string SetAuthorName
        {
            get { return AuthorName; }
            set
            {
                AuthorName = value;
                OnPropertyChanged("SetAuthorName");
            }
        }

        public string SetImagePath
        {
            get { return ImagePath; }
            set
            {
                ImagePath = value;
                OnPropertyChanged("SetImagePath");
            }
        }

        public string SetStoryPath
        {
            get { return StoryPath; }
            set
            {
                StoryPath = value;
                OnPropertyChanged("SetStoryPath");
            }
        }

        public string SetClassesPath
        {
            get { return ClassesPath; }
            set
            {
                ClassesPath = value;
                OnPropertyChanged("SetClassesPath");
            }
        }

        public string SetEquipmentPath
        {
            get { return EquipmentPath; }
            set
            {
                EquipmentPath = value;
                OnPropertyChanged("SetEquipmentPath");
            }
        }

        public string SetMagicalEquipmentPath
        {
            get { return MagicalEquipmentPath; }
            set
            {
                MagicalEquipmentPath = value;
                OnPropertyChanged("SetMagicalEquipmentPath");
            }
        }

        public string SetEncountersPath
        {
            get { return EncountersPath; }
            set
            {
                EncountersPath = value;
                OnPropertyChanged("SetEncountersPath");
            }
        }

        public string SetTablesPath
        {
            get { return TablesPath; }
            set
            {
                TablesPath = value;
                OnPropertyChanged("SetTablesPath");
            }
        }

        public string SetParcelsPath
        {
            get { return ParcelsPath; }
            set
            {
                ParcelsPath = value;
                OnPropertyChanged("SetParcelsPath");
            }
        }

        public string SetBackgroundPath{
            get { return BackgroundsPath; }
            set
            {
                BackgroundsPath = value;
                OnPropertyChanged("SetBackgroundPath");
            }
        }

        public string SetRacesPath
        {
            get { return RacesPath; }
            set
            {
                RacesPath = value;
                OnPropertyChanged("SetRacesPath");
            }
        }

        public string SetNPCsPath
        {
            get { return NPCsPath; }
            set
            {
                NPCsPath = value;
                OnPropertyChanged("SetNPCsPath");
            }
        }

        public bool SetDMOnlyChecked
        {
            get { return DMOnlyIsChecked; }
            set
            {
                DMOnlyIsChecked = value;
                OnPropertyChanged("SetDMOnlyChecked");
            }
        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

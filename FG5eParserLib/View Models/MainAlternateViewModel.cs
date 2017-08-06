using FG5eParserLib.View_Mo.dels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;
using System;
using FG5eParserLib.Utility;

namespace FG5eParserLib.View_Models
{
    public class MainAlternateViewModel : INotifyPropertyChanged
    {
        private string ClassProjectPath;

        public ObservableCollection<TabItem> TabList { get; set; }
        private bool _FlgBackground { get; set; }
        public bool FlgBackground
        {
            get
            {
                return _FlgBackground;
            }
            set
            {
                _FlgBackground = value;
                OnPropertyChanged("FlgBackground");
            }
        }

        public RelayCommand NewClassProject { get; set; }
        public RelayCommand NewAdventureProject { get; set; }
        public RelayCommand ParseOpenProject { get; set; }
        public RelayCommand ParseCustomProject { get; set; }

        // Individual Files
        public RelayCommand NpcPage { get; set; }
        public RelayCommand FeatPage { get; set; }
        public RelayCommand RacePage { get; set; }
        public RelayCommand PinMappingPage { get; set; }

        public MainAlternateViewModel()
        {
            NewClassProject = new RelayCommand(newClassProject);
            ParseOpenProject = new RelayCommand(parseOpenProject);

            // Single pages
            NpcPage = new RelayCommand(singleNpcPage);
            FeatPage = new RelayCommand(featPage);
            RacePage = new RelayCommand(racePage);
            PinMappingPage = new RelayCommand(pinMappingpage);

            // A collection of all the tabs on the screen, initialize only once!
            TabList = new ObservableCollection<TabItem>();
        }

        private void pinMappingpage(object obj)
        {
            string PinMappingPath = string.Empty;
            FolderBrowserDialog choofdlog = new FolderBrowserDialog();
            DialogResult result = choofdlog.ShowDialog();

            if (result == DialogResult.OK)
            {
                PinMappingPath = choofdlog.SelectedPath;
                TabList.Clear();

                // Create necessary Text files and then load the necessary tabs
                File.Create(PinMappingPath + @"\ImagePins.txt");
                TabList.Add(new TabItem { Content = new ImagePinsViewModel() { ImagePinsTextPath = PinMappingPath + @"\ImagePins.txt" }, Header = "Pin Mapping" });

                TabList.Add(new TabItem
                {
                    Content = new PathViewModel()
                    {
                        PinMappingPath = PinMappingPath + @"\ImagePins.txt",
                    },
                    Header = "Parser"
                });
            }
        }

        private void racePage(object obj)
        {
            string RacesPathPage = string.Empty;
            FolderBrowserDialog choofdlog = new FolderBrowserDialog();
            DialogResult result = choofdlog.ShowDialog();

            if (result == DialogResult.OK)
            {
                RacesPathPage = choofdlog.SelectedPath;
                TabList.Clear();

                // Create necessary Text files and then load the necessary tabs
                File.Create(RacesPathPage + @"\Races.txt");
                TabList.Add(new TabItem { Content = new RacesViewModel() { RacesTextPath = RacesPathPage + @"\Races.txt" }, Header = "Races" });

                TabList.Add(new TabItem
                {
                    Content = new PathViewModel()
                    {
                        RacesPath = RacesPathPage + @"\Races.txt",
                    },
                    Header = "Parser"
                });
            }
        }

        private void featPage(object obj)
        {
            string FeatsPathPath = string.Empty;
            FolderBrowserDialog choofdlog = new FolderBrowserDialog();
            DialogResult result = choofdlog.ShowDialog();

            if (result == DialogResult.OK)
            {
                FeatsPathPath = choofdlog.SelectedPath;
                TabList.Clear();

                // Create necessary Text files and then load the necessary tabs
                File.Create(FeatsPathPath + @"\Feats.txt");
                TabList.Add(new TabItem { Content = new FeatsViewModel() { FeatsTextPath = FeatsPathPath + @"\Feats.txt" }, Header = "Feats" });

                TabList.Add(new TabItem
                {
                    Content = new PathViewModel()
                    {
                        FeatPath = FeatsPathPath + @"\Feats.txt",
                    },
                    Header = "Parser"
                });
            }
        }

        private void singleNpcPage(object obj)
        {
            string NpcPagePath = string.Empty;
            FolderBrowserDialog choofdlog = new FolderBrowserDialog();
            DialogResult result = choofdlog.ShowDialog();

            if (result == DialogResult.OK)
            {
                NpcPagePath = choofdlog.SelectedPath;
                TabList.Clear();

                // Create necessary Text files and then load the necessary tabs
                File.Create(NpcPagePath + @"\NPC.txt");
                TabList.Add(new TabItem { Content = new NPCViewModel() { NPCTextPath = NpcPagePath + @"\NPC.txt" }, Header = "NPC" });

                TabList.Add(new TabItem
                {
                    Content = new PathViewModel()
                    {
                        NPCPath = NpcPagePath + @"\NPC.txt",
                    },
                    Header = "Parser"
                });
            }
        }

        private void parseOpenProject(object obj)
        {
            if (!string.IsNullOrEmpty(ClassProjectPath))
            {
                TabList.Add(new TabItem
                {
                    Content = new PathViewModel(),
                    Header = "Parser"
                });
            }
            else
            {
                // Select a folder with details
            }
        }

        private void newClassProject(object obj)
        {
            FolderBrowserDialog choofdlog = new FolderBrowserDialog();
            DialogResult result = choofdlog.ShowDialog();

            if (result == DialogResult.OK)
            {
                ClassProjectPath = choofdlog.SelectedPath;
                TabList.Clear();

                // Create necessary Text files and then load the necessary tabs
                File.Create(ClassProjectPath + @"\Class.txt");
                TabList.Add(new TabItem { Content = new ClassesViewModel() { ClassesTextPath = ClassProjectPath + @"\Class.txt" }, Header = "Class" });
                File.Create(ClassProjectPath + @"\Background.txt");
                TabList.Add(new TabItem { Content = new BackgroundViewModel() { backgroundTextPath = ClassProjectPath + @"\Background.txt", _tableTextPath = ClassProjectPath + @"\Tables.txt" }, Header = "Background" });
                File.Create(ClassProjectPath + @"\Equipment.txt");
                TabList.Add(new TabItem { Content = new EquipmentViewModel() { EquipmentTextPath = ClassProjectPath + @"\Equipment.txt" }, Header = "Equipment" });
                File.Create(ClassProjectPath + @"\Spells.txt");
                TabList.Add(new TabItem { Content = new SpellViewModel() { SpellsTextPath = ClassProjectPath + @"\Spells.txt" }, Header = "Spells" });
                File.Create(ClassProjectPath + @"\Tables.txt");
                TabList.Add(new TabItem { Header = "Tables" });

                TabList.Add(new TabItem
                {
                    Content = new PathViewModel()
                    {
                        BackgroundPath = ClassProjectPath + @"\Background.txt",
                        ClassPath = ClassProjectPath + @"\Class.txt",
                        EquipmentPath = ClassProjectPath + @"\Equipment.txt",
                        SpellPath = ClassProjectPath + @"\Spells.txt",
                        TablePath = ClassProjectPath + @"\Tables.txt"
                    },
                    Header = "Parser"
                });
            }
        }

        #region PROPERTY CHANGES
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

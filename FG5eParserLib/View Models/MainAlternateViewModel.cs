using FG5eParserLib.View_Mo.dels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;
using System;

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

        public MainAlternateViewModel()
        {
            NewClassProject = new RelayCommand(newClassProject);
            ParseOpenProject = new RelayCommand(parseOpenProject);

            TabList = new ObservableCollection<TabItem>();
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

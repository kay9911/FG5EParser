using FG5eParserLib.View_Mo.dels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;

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

        public RelayCommand NewClassProject { get; set; } // Save Button

        public MainAlternateViewModel()
        {
            NewClassProject = new RelayCommand(newClassProject);
            TabList = new ObservableCollection<TabItem>();
        }

        private void newClassProject(object obj)
        {
            FolderBrowserDialog choofdlog = new FolderBrowserDialog();
            DialogResult result = choofdlog.ShowDialog();

            if (result == DialogResult.OK)
            {
                ClassProjectPath = choofdlog.SelectedPath;
            }

            // Create necessary Text files and then load the necessary tabs
            File.Create(ClassProjectPath + @"\Class.txt");
            TabList.Add(new TabItem { Content = new ClassesViewModel(), Header="Class" });
            File.Create(ClassProjectPath + @"\Background.txt");
            TabList.Add(new TabItem { Content = new BackgroundViewModel(), Header = "Background" });
            File.Create(ClassProjectPath + @"\Equipment.txt");
            TabList.Add(new TabItem { Content = new EquipmentViewModel(), Header = "Equipment" });
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

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FG5eParserModels.Utility_Modules
{
    public class ReferenceManual : INotifyPropertyChanged
    {
        private string ChapterName { get; set; }
        ObservableCollection<Chapters> Subchapters { get; set; }

        public string _ChapterName
        {
            get
            {
                return ChapterName;
            }
            set
            {
                ChapterName = value;
                OnPropertyChanged("_ChapterName");
            }
        }

        //constructor
        public ReferenceManual()
        {
            Subchapters = new ObservableCollection<Chapters>();
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

    class Chapters : INotifyPropertyChanged
    {
        private string SubchapterName { get; set; }
        private string Details { get; set; }

        public string _SubchapterName
        {
            get
            {
                return SubchapterName;
            }
            set
            {
                SubchapterName = value;
                OnPropertyChanged("_SubchapterName");
            }
        }

        public string _Details
        {
            get
            {
                return Details;
            }
            set
            {
                Details = value;
                OnPropertyChanged("_Details");
            }
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

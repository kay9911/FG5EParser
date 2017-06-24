using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FG5eParserModels.Utility_Modules
{
    public class ReferenceManual : INotifyPropertyChanged
    {
        private string ChapterName { get; set; }
        public ObservableCollection<string> SubchapterNameList { get; set; }
        public ObservableCollection<ReferenceNote> ReferenceNoteList { get; set; }

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
            ReferenceNoteList = new ObservableCollection<ReferenceNote>();
            SubchapterNameList = new ObservableCollection<string>();
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

    public class ReferenceNote : INotifyPropertyChanged
    {
        private string Title { get; set; }
        private string Details { get; set; }
        private string SubchapterName { get; set; }

        public string _Title
        {
            get
            {
                return Title;
            }
            set
            {
                Title = value;
                OnPropertyChanged("_Title");
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

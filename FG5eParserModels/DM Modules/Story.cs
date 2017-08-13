using System.ComponentModel;

namespace FG5eParserModels.DM_Modules
{
    public class Story : INotifyPropertyChanged
    {
        private string StoryHeader { get; set; }
        private string StoryEntryName { get; set; }
        private string StoryDescription { get; set; }

        public string _storyHeader
        {
            get
            {
                return StoryHeader;
            }
            set
            {
                StoryHeader = value;
                OnPropertyChanged("_storyHeader");
            }
        }
        public string _storyEntryName
        {
            get
            {
                return StoryEntryName;
            }
            set
            {
                StoryEntryName = value;
                OnPropertyChanged("_storyEntryName");
            }
        }
        public string _storyDescription
        {
            get
            {
                return StoryDescription;
            }
            set
            {
                StoryDescription = value;
                OnPropertyChanged("_storyDescription");
            }
        }

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
    }
}

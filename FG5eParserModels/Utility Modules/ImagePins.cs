using System.ComponentModel;

namespace FG5eParserModels.Utility_Modules 
{
    public class ImagePins : INotifyPropertyChanged
    {
        private string imageName { get; set; }
        private string x { get; set; }
        private string y { get; set; }
        private string classType { get; set; }
        private string recordName { get; set; }

        #region EXPOSED PROPERTIES
        public string _imageName
        {
            get
            {
                return imageName;
            }
            set
            {
                imageName = value;
                OnPropertyChanged("_imageName");
            }
        }
        public string _x
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                OnPropertyChanged("_x");
            }
        }
        public string _y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                OnPropertyChanged("_y");
            }
        }
        public string _classType
        {
            get
            {
                return classType;
            }
            set
            {
                classType = value;
                OnPropertyChanged("_classType");
            }
        }
        public string _recordName
        {
            get
            {
                return recordName;
            }
            set
            {
                recordName = value;
                OnPropertyChanged("_recordName");
            }
        }
        #endregion

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

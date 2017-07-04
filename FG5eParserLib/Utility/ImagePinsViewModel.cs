using FG5eParserModels.Utility_Modules;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace FG5eParserLib.Utility
{
    public class ImagePinsViewModel : INotifyPropertyChanged
    {
        private ImagePins ImagePinObj { get; set; }
        public ImagePins ImagePinObject
        {
            get
            {
                return ImagePinObj;
            }
            set
            {
                ImagePinObj = value;
                OnPropertyChanged(null);
            }
        }

        // Relay Commands
        public RelayCommand SavePins { get; set; } // Save all imagepins
        public RelayCommand LoadImage { get; set; } // Loads the image into view
        public RelayCommand LoadStoryList { get; set; } // Get all Story Entries

        // Lists
        public ObservableCollection<StoryEntry> StoryList { get; set; }

        public string ImagePinsTextPath { get; set; }
        private string _ImageFilePath { get; set; }
        public string ImageFilePath
        {
            get
            {
                return _ImageFilePath;
            }
            set
            {
                _ImageFilePath = value;
                OnPropertyChanged("ImageFilePath");
            }
        }
        private string ImageName;

        // Constructor
        public ImagePinsViewModel()
        {
            ImagePinObj = new ImagePins();
            StoryList = new ObservableCollection<StoryEntry>();
            LoadStoryList = new RelayCommand(loadStoryList);

            LoadImage = new RelayCommand(loadImage);
            SavePins = new RelayCommand(savePins);
        }

        // Functions
        private void savePins(object obj)
        {
            // Chose the txt file that will hold the information
            if (string.IsNullOrEmpty(ImagePinsTextPath))
            {
                SaveFileDialog choofdlog = new SaveFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";

                if (choofdlog.ShowDialog() == true)
                {
                    ImagePinsTextPath = choofdlog.FileName;
                    //ImageName = choofdlog.SafeFileName.Replace(".jpg", "").Trim();
                }
            }

            // Add the object to the file
            if (!string.IsNullOrEmpty(ImagePinsTextPath))
            {
                TextWriter tsw = new StreamWriter(ImagePinsTextPath, true);
                tsw.WriteLine(GetOutput());
                tsw.Close();
            }
        }

        private void loadImage(object obj)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                ImageFilePath = choofdlog.FileName;
                ImageName = choofdlog.SafeFileName.Replace(".jpg","").Trim();
            }
        }

        private void loadStoryList(object obj)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == true)
            {
                Readers _readerObject = new Readers();
                StoryList.Clear();
                foreach (var _story in _readerObject.ReadStoryEntries(choofdlog.FileName))
                {
                    StoryList.Add(_story);
                }
            }
        }

        private string GetOutput()
        {
            StringBuilder _sb = new StringBuilder();

            foreach (var entry in StoryList)
            {
                if (!string.IsNullOrEmpty(entry.Coordinates))
                {
                    ImagePins _pin = new ImagePins()
                    {
                        _classType = "story",
                        _imageName = ImageName,
                        _recordName = entry.Title,
                        _x = entry.Coordinates.Split(';')[0],
                        _y = entry.Coordinates.Split(';')[1]
                    };

                    _sb.Append(string.Format("{0};{1};{2};{3};{4}", _pin._imageName, _pin._x, _pin._y, _pin._classType, _pin._recordName));
                    _sb.Append(Environment.NewLine);
                }
            }
            return _sb.ToString();
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

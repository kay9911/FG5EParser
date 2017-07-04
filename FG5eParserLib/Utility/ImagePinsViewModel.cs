using FG5EParser.Base_Class;
using FG5EParser.WriterClasses;
using FG5eParserModels.Utility_Modules;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

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
        public RelayCommand LoadStoryList { get; set; } // Get all Story Entries

        // Lists
        public List<StoryElements> StoryList { get; set; }

        private string ImageName { get; set; }
        public string _ImageName
        {
            get
            {
                return ImageName;
            }
            set
            {
                ImageName = value;
                OnPropertyChanged("_ImageName");
            }
        }

        public string ImagePinsTextPath { get; set; }

        // Constructor
        public ImagePinsViewModel()
        {
            ImagePinObj = new ImagePins();
            StoryList = new List<StoryElements>();
            LoadStoryList = new RelayCommand(loadStoryList);

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
                }
            }

            // Add the object to the file
            if (!string.IsNullOrEmpty(ImagePinsTextPath))
            {
                TextWriter tsw = new StreamWriter(ImagePinsTextPath, true);
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
                StoryWriter _encounterWriterObject = new StoryWriter();
                StoryList.Clear();
                StoryList = _encounterWriterObject.compileStoryList(choofdlog.FileName, "");
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

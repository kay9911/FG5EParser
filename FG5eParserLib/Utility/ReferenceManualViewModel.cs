using FG5eParserModels.Utility_Modules;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;

namespace FG5eParserLib.Utility
{
    public class ReferenceManualViewModel : INotifyPropertyChanged
    {
        // Lists and Objects
        private ReferenceManual ReferenceManualObj { get; set; }
        public ReferenceManual ReferenceManualObject
        {
            get
            {
                return ReferenceManualObj;
            }
            set
            {
                ReferenceManualObj = value;
                OnPropertyChanged(null);
            }
        }

        // Relay Commands
        public RelayCommand SaveRefereces { get; set; } // Save all references

        // Output
        private string Output { get; set; }
        public string _Output
        {
            get
            {
                return Output;
            }
            set
            {
                Output = value;
                OnPropertyChanged("_Output");
            }
        }

        public string ReferenceManualTextPath { get; set; }

        // Constructor
        public ReferenceManualViewModel()
        {
            ReferenceManualObj = new ReferenceManual();
            SaveRefereces = new RelayCommand(saveRefereces);
        }

        // Functions
        private void saveRefereces(object obj)
        {
            // Chose the txt file that will hold the information
            if (string.IsNullOrEmpty(ReferenceManualTextPath))
            {
                SaveFileDialog choofdlog = new SaveFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";

                if (choofdlog.ShowDialog() == true)
                {
                    ReferenceManualTextPath = choofdlog.FileName;
                }
            }

            // Add the object to the file
            if (!string.IsNullOrEmpty(ReferenceManualTextPath))
            {
                TextWriter tsw = new StreamWriter(ReferenceManualTextPath, true);
                tsw.WriteLine(_Output);
                tsw.Close();

                _Output = string.Empty;
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

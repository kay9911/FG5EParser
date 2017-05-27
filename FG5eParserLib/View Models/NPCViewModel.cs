using FG5eParserModels.DM_Modules;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace FG5eParserLib.View_Models
{
    public class NPCViewModel : INotifyPropertyChanged
    {
        // Object Inits
        private NPC _NPCObj { get; set; }
        public NPC NPCObject
        {
            get
            {
                return _NPCObj;
            }
            set
            {
                _NPCObj = value;
                OnPropertyChanged(null);
            }
        }

        // Props and List
        public ObservableCollection<NPC> _npcList { get; set; }
        public string NPCTextPath { get; set; }

        // Relay Commands
        public RelayCommand SaveNPC { get; set; } // Save Button
        public RelayCommand ResetFields { get; set; } // Reset Button
        public RelayCommand AddNPCToList { get; set; } // Add Feat to list

        // Output
        private string _Output { get; set; }
        public string Output { get { return _Output; } set { _Output = value; OnPropertyChanged("Output"); } }

        //constructor
        public NPCViewModel()
        {
            // Object Inits
            NPCObject = new NPC();

            // List Inits
            _npcList = new ObservableCollection<NPC>();

            // Delegates
            SaveNPC = new RelayCommand(saveNPC, canSaveNPC);
            ResetFields = new RelayCommand(resetFields);
            AddNPCToList = new RelayCommand(addNPCToList, canAddNPC);
        }

        // Functions
        private void saveNPC(object obj)
        {
            // Chose the txt file that will hold the information
            if (string.IsNullOrEmpty(NPCTextPath))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = false;

                if (choofdlog.ShowDialog() == true)
                {
                    // Adding to resources
                    NPCTextPath = choofdlog.FileName;
                }
            }

            // Add the object to the file
            if (!string.IsNullOrEmpty(NPCTextPath))
            {
                TextWriter tsw = new StreamWriter(NPCTextPath, true);
                tsw.WriteLine(Output);
                tsw.Close();

                // Reset the object and refresh the screen
                NPCObject = new NPC();
            }
        }

        private bool canSaveNPC(object obj)
        {
            // Validation logic goes here
            return true;
        }

        private void resetFields(object obj)
        {
            // Reset the object and refresh the screen
            NPCObject = new NPC();
        }

        private void addNPCToList(object obj)
        {
            // Add the spell to the list
            _npcList.Add(NPCObject);

            getOutput();

            // Reset the object and refresh the screen
            NPCObject = new NPC();
        }

        private bool canAddNPC(object obj)
        {
            // validation logic goes here
            return true;
        }

        // Output Function
        private void getOutput()
        {
            StringBuilder _sb = new StringBuilder();

            Output = _sb.ToString();
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

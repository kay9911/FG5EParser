using System.Collections.ObjectModel;
using System.ComponentModel;
using FG5eParserModels.Player_Models;
using System.IO;
using Microsoft.Win32;
using FG5eParserLib.Utility;
using System.Text;
using System;

namespace FG5eParserLib.View_Mo.dels
{
    public class BackgroundViewModel : INotifyPropertyChanged
    {
        public string backgroundTextPath { get; set; }

        // Table pop up data
        private string tableTextPath { get; set; }
        public ObservableCollection<string> TableNames { get; set; }
        public ObservableCollection<Backgrounds> BackgroundList { get; set; }

        // Relay Commands
        public RelayCommand AddBackground { get; set; } // Save Button
        public RelayCommand ResetFields { get; set; } // Reset Button
        public RelayCommand AddToList { get; set; } // Add background to the list

        // Lists and Objects
        private Backgrounds BackgroundObj { get; set; }

        // Output
        private string Output { get; set; }

        #region PROPERTY CHANGES
        public event PropertyChangedEventHandler PropertyChanged;
        public Backgrounds Background
        {
            get
            {
                return BackgroundObj;
            }
            set
            {
                BackgroundObj = value;
                OnPropertyChanged(null);
            }
        }
        public string _tableTextPath
        {
            get
            {
                return tableTextPath;
            }
            set
            {
                tableTextPath = value;
                TableNames = getTableList(value);
                OnPropertyChanged(null);
            }
        }
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

        // Constructors
        public BackgroundViewModel()
        {
            // Command Inits
            AddBackground = new RelayCommand(SaveList, CanAdd);
            ResetFields = new RelayCommand(resetObject);
            AddToList = new RelayCommand(AddBackgroundtoList, canAddtoList);

            // List Inits
            BackgroundList = new ObservableCollection<Backgrounds>();

            //Inits
            BackgroundObj = new Backgrounds();
            TableNames = new ObservableCollection<string>();
        }

        // Functions
        private void SaveList(object obj)
        {
            // Chose the txt file that will hold the information
            if (string.IsNullOrEmpty(backgroundTextPath))
            {
                SaveFileDialog choofdlog = new SaveFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";

                if (choofdlog.ShowDialog() == true)
                {
                    backgroundTextPath = choofdlog.FileName;
                }
            }

            // Add the object to the file
            if (!string.IsNullOrEmpty(backgroundTextPath))
            {
                TextWriter tsw = new StreamWriter(backgroundTextPath, true);
                tsw.WriteLine(_Output);
                tsw.Close();

                // Clear the holding list
                BackgroundList.Clear();
            }
        }

        private bool CanAdd(object _obj)
        {
            // TO DO: Validation logic for add goes here
            if (BackgroundList.Count == 0)
            {
                return false;
            }
            return true;
        }

        private void AddBackgroundtoList(object obj)
        {
            // Add to list
            BackgroundList.Add(Background);

            getOutput();

            // Reset the bound object
            Background = new Backgrounds();
        }

        private bool canAddtoList(object obj)
        {
            return true;
        }

        private void resetObject(object obj)
        {
            // Reset the object and refresh the screen           
            Background = new Backgrounds();
            _Output = string.Empty;
            _tableTextPath = string.Empty;
        }

        // _Output value is obtained from here
        private void getOutput()
        {
            StringBuilder _sb = new StringBuilder();

            foreach (var background in BackgroundList)
            {
                // Name
                _sb.Append(string.Format("##;{0}", background._Name));
                _sb.Append(Environment.NewLine);

                // Desc
                _sb.Append(background._Description);
                _sb.Append(Environment.NewLine);

                //Skill Proficiencies: Insight, Religion
                _sb.Append(string.Format("Skill Proficiencies: {0}", background._Skills));
                _sb.Append(Environment.NewLine);

                //Tool Proficiencies: Insight, Religion
                if (!string.IsNullOrEmpty(background._Tools))
                {
                    _sb.Append(string.Format("Tool Proficiencies: {0}", background._Tools));
                    _sb.Append(Environment.NewLine);
                }

                //Languages: Two of your choice 
                if (!string.IsNullOrEmpty(background._Languages))
                {
                    _sb.Append(string.Format("Languages: {0}", background._Languages));
                    _sb.Append(Environment.NewLine);
                }

                //Equipment:
                if (!string.IsNullOrEmpty(background._Equipment))
                {
                    _sb.Append(string.Format("Equipment: {0}", background._Equipment));
                    _sb.Append(Environment.NewLine);
                }

                //Feature:
                _sb.Append(string.Format("Feature: {0}", background._Feature));
                _sb.Append(Environment.NewLine);

                // Desc
                _sb.Append(background._FeatureDescription);
                _sb.Append(Environment.NewLine);

                // Suggested
                _sb.Append("Suggested Characteristics");
                _sb.Append(Environment.NewLine);
                _sb.Append(background._SuggestedCharachteristics);
                _sb.Append(Environment.NewLine);

                // Tables
                _sb.Append("#zls;");
                _sb.Append(Environment.NewLine);

                //#zal;T;*;Acolyte Personality Traits;Acolyte Personality Traits
                _sb.Append(string.Format("#zal;T;*;{0};{0}", background._PersonalityTraits));
                _sb.Append(Environment.NewLine);

                //#zal;T;*;Acolyte Ideals;Acolyte Ideals
                _sb.Append(string.Format("#zal;T;*;{0};{0}", background._Ideals));
                _sb.Append(Environment.NewLine);

                //#zal;T;*;Acolyte Bonds;Acolyte Bonds
                _sb.Append(string.Format("#zal;T;*;{0};{0}", background._Bonds));
                _sb.Append(Environment.NewLine);

                //#zal;T;*;Acolyte Flaws;Acolyte Flaws
                _sb.Append(string.Format("#zal;T;*;{0};{0}", background._Flaws));
                _sb.Append(Environment.NewLine);

                _sb.Append("#zle;");
                _sb.Append(Environment.NewLine); // Seperate the next object in the list by a line break.
            }
            _Output = _sb.ToString();
        }

        private ObservableCollection<string> getTableList(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                Readers _reader = new Readers();
                ObservableCollection<string> _tableList = _tableList = _reader.ReadTables(path);
                return _tableList;
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FG5eParserModels.Player_Models;

namespace FG5eParserLib.View_Mo.dels
{
    public class BackgroundViewModel : INotifyPropertyChanged
    {
        // Relay Commands
        public RelayCommand AddBackground { get; set; } // Save Button
        public RelayCommand ResetFields { get; set; } // Reset Button

        // Lists and Objects
        private Backgrounds BackgroundObj { get; set; }
        public ObservableCollection<Backgrounds> _backgroundList { get; private set; }

        #region PROPERTY CHANGES
        public event PropertyChangedEventHandler PropertyChanged;
        public Backgrounds Background {
            get {
                return BackgroundObj;
            }
            set {
                BackgroundObj = value;
                OnPropertyChanged("_newBackground");
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
            AddBackground = new RelayCommand(BackgroundAddToList,CanAdd);
            ResetFields = new RelayCommand(resetObject);

            //Inits
            _backgroundList = new ObservableCollection<Backgrounds>();
            BackgroundObj = new Backgrounds();
            //BackgroundObj = new Backgrounds() { _Name = "NAME", _Skills = "SKILLS", _Description="DESC", _Equipment="EQ", _Feature="Feat", _FeatureDescription = "featdesc", _Languages = "Lang", _Output = "OP", _SuggestedCharachteristics = "SP", _Tools = "Tool" };
            //_backgroundList.Add(BackgroundObj);
        }        

        // Functions
        public void BackgroundAddToList(object obj)
        {
            _backgroundList.Add(BackgroundObj);

            // Reset the object
            Backgrounds _backObj = new Backgrounds();
            Background = _backObj;
        }

        public bool CanAdd(object _obj)
        {
            // TO DO: Validation logic for add goes here
            return true;
        }

        private void resetObject(object obj)
        {
            Backgrounds _backObj = new Backgrounds();
            Background = _backObj;
            #region OLD CODE
            //var properties = from property in typeof(Backgrounds).GetProperties()
            //                 where property.PropertyType == typeof(string)
            //                 && property.CanRead && property.CanWrite
            //                 select property;

            //foreach (var prop in properties)
            //{
            //    prop.SetValue(_backgrounds,null,null);
            //}
            #endregion
        }
    }
}

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
    class BackgroundViewModel : INotifyPropertyChanged
    {
        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        Backgrounds _background = new Backgrounds();

        public ObservableCollection<Backgrounds> _backgrounds;

        public BackgroundViewModel()
        {
            _backgrounds = new ObservableCollection<Backgrounds>();
        }

        public string txtBackgroundName {
            get { return _background._Name; }
            set { _background._Name = value.Trim(); }
        }

    }
}

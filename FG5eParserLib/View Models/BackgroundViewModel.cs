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
    public class BackgroundViewModel
    {
        public string outputString { get; set; }

        Backgrounds _background = new Backgrounds();

        public ObservableCollection<Backgrounds> _backgrounds { get; private set; }

        public BackgroundViewModel()
        {
            Output = new RelayCommand(displayOutput);
        }

        public string txtBackgroundName {
            get { return _background._Name; }
            set { _background._Name = value.Trim();
            }
        }

        public RelayCommand Output { get; private set; }

        // Functions
        public void displayOutput(Object obj)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(txtBackgroundName);

            outputString = _sb.ToString();
        }

    }
}

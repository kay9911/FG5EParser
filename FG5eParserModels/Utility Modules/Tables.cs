using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5eParserModels.Utility_Modules
{
    public class Tables : INotifyPropertyChanged
    {
        private string TableName { get; set; }

        #region PROPERTY CHANGES
        // Declare the nterface event
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

        public string _TableName {
            get { return TableName; }
            set {
                TableName = value;
                OnPropertyChanged("_TableName");
            }
        }
    }
}

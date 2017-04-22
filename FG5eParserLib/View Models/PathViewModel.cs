using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FG5eParserLib.View_Models
{
    public class PathViewModel
    {
        public RelayCommand ParseCommand { get; set; }

        public PathViewModel()
        {
            ParseCommand = new RelayCommand(Parse,CanParse);
        }

        public void Parse(object _obj)
        {
            // DO something
        }

        public bool CanParse(object _obj)
        {
            if (string.IsNullOrEmpty((string)_obj))
            {
                return false;
            }
            else
                return true;
        }
    }
}

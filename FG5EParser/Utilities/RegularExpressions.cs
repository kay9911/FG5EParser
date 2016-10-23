using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FG5EParser.Utilities
{
    class RegularExpressions
    {
        // This class will hold all the regular expressions based functions

        public string getCorrectedSpeed(string _speed)
        {
            // Remove the extra charachters will be added in later
            _speed = _speed.Replace(",", "").Replace(".", "");

            if (Regex.IsMatch(_speed, @"\w*\s?\d+\s{1}ft"))
            {
                return _speed;
            }
            else
            {
                return _speed.Replace("ft", " ft").Replace("swim", "swim ").Replace("fly", "fly ").Replace("burrow", "burrow ");
            }
        }
    }
}

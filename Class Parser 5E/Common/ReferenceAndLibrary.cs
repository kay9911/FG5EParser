using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Parser_5E.Common
{
    class ReferenceAndLibrary
    {
        public string prepareClassXML()
        {
            StringBuilder _xml = new StringBuilder();

            _xml.Append("<reference static=\"true\">");

            // TO DO : APPROACH TO PASS CLASSES

            // TO DO : LIBRARY INFORMATION

            _xml.Append("</reference>");

            return _xml.ToString();
        }
    }
}

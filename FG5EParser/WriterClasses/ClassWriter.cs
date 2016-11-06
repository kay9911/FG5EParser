using FG5EParser.Base_Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.WriterClasses
{
    class ClassWriter
    {
        public List<Classes> compileClassList(string _inputLocation, string _moduleName)
        {
            try
            {
                var _lines = File.ReadLines(_inputLocation);
                List<string> _basic = new List<string>();
                List<Classes> Classes = new List<Base_Class.Classes>();

                #region Populating the basic list

                foreach (var _line in _lines)
                {
                    if (!String.IsNullOrWhiteSpace(_line))
                    {
                        _basic.Add(_line);
                    }
                    else
                    {
                        // Send for processing
                        Classes _classes = new Classes();
                        if (_basic.Count != 0)
                        {
                            _classes = _classes.bindValues(_basic,_moduleName);
                            Classes.Add(_classes);
                        }
                        _basic.Clear();
                    }
                }

                    // If there is just one entry or the last entry
                    if (!string.IsNullOrEmpty(_basic.ToString()))
                    {
                        Classes _classes = new Classes();
                        if (_basic.Count != 0)
                        {
                            _classes = _classes.bindValues(_basic, _moduleName);
                            Classes.Add(_classes);
                        }
                        _basic.Clear();
                    }
                 #endregion

            return Classes;

            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
    } 
}

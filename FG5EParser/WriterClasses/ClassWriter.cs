using FG5EParser.Base_Class;
using System;
using System.Collections.Generic;
using System.IO;

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
                List<Classes> Classes = new List<Classes>();

                Classes _class = new Classes();

                #region Populating the basic list

                foreach (var _line in _lines)
                {
                    if (_line.Contains("##;"))
                    {
                        // Send for processing
                        if (_basic.Count != 0)
                        {
                            Classes.AddRange(_class.bindValues(_basic, _moduleName));
                        }
                        _basic.Clear();
                        _basic.Add(_line);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(_line) && !_line.Contains("Its done!"))
                        {
                            _basic.Add(_line);
                        }
                    }
                    #endregion
                }

                // Catch the last bit of entries out of the loop
                if (_basic.Count != 0)
                {
                    Classes.AddRange(_class.bindValues(_basic, _moduleName));
                }

                return Classes;
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
    } 
}

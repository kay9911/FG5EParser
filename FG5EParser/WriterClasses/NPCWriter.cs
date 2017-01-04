using FG5EParser.Base_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.Writer_Classes
{
    class NPCWriter
    {
        public List<Personalities> compileNPCList(string _inputLocation, string moduleName)
        {
            try
            {
                var _lines = File.ReadLines(_inputLocation);
                List<string> _basic = new List<string>();
                List<Personalities> NPCS = new List<Personalities>();

                //BEGIN
                #region Process Lines
                foreach (var _line in _lines)
                {
                    if (!String.IsNullOrWhiteSpace(_line))
                    {
                        _basic.Add(_line);
                    }
                    else
                    {
                        // Send for processing
                        Personalities _personalities = new Personalities();
                        if (_basic.Count != 0)
                        {
                            _personalities = _personalities.BindValues(_basic,moduleName);
                            NPCS.Add(_personalities);
                        }
                        _basic.Clear();
                    }
                }

                // If there is just one entry or the last entry
                if (!string.IsNullOrEmpty(_basic.ToString()))
                {
                    Personalities _personalities = new Personalities();
                    if (_basic.Count != 0)
                    {
                        _personalities = _personalities.BindValues(_basic, moduleName);
                        NPCS.Add(_personalities);
                    }
                    _basic.Clear();
                }
                #endregion

                return NPCS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

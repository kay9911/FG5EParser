using FG5EParser.Utilities;
using FG5eParserModels.Utility_Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FG5EParser.WriterClasses
{
    class ReferenceManualWriter
    {
        public List<ReferenceManual> compileReferenceManualList(string _inputLocation, string moduleName)
        {
            try
            {
                XMLFormatting _xmlFormatting = new XMLFormatting();

                // Read lines from file
                var _lines = File.ReadLines(_inputLocation);

                List<ReferenceManual> referenceManualList = new List<ReferenceManual>();
                ReferenceManual _referenceManual = new ReferenceManual();
                ReferenceNote _referenceNote = new ReferenceNote();

                string CurrentSubChapter = string.Empty;

                // Convert _lines to a List
                List<string> ReferenceManualEntries = new List<string>();
                foreach (var line in _lines)
                {
                    ReferenceManualEntries.Add(line);
                }

                for (int i = 0; i < ReferenceManualEntries.Count; i++)
                {
                    if (!string.IsNullOrEmpty(ReferenceManualEntries[i]))
                    {
                        if (!string.IsNullOrEmpty(_referenceManual._ChapterName))
                        {
                            referenceManualList.Add(_referenceManual);
                            _referenceManual = new ReferenceManual();
                            CurrentSubChapter = string.Empty;
                            _referenceNote = new ReferenceNote();
                        }

                        if (ReferenceManualEntries[i].Contains("#@;"))
                        {
                            _referenceManual._ChapterName = ReferenceManualEntries[i].Replace("#@;","").Trim();
                            if (i + 1 != ReferenceManualEntries.Count)
                            {
                                i++;
                            }
                        }

                        if (ReferenceManualEntries[i].Contains("#!"))
                        {
                            _referenceManual.SubchapterNameList.Add(ReferenceManualEntries[i].Replace("#!", "").Trim());
                            CurrentSubChapter = ReferenceManualEntries[i].Replace("#!", "").Trim();

                            if (i + 1 != ReferenceManualEntries.Count)
                            {
                                i++;
                            }
                        }

                        if (ReferenceManualEntries[i].Contains("##;"))
                        {
                            _referenceNote._Title = ReferenceManualEntries[i].Replace("##;", "").Trim();
                            _referenceNote._SubchapterName = CurrentSubChapter;

                            if (i + 1 != ReferenceManualEntries.Count)
                            {
                                i++;
                            }
                        }

                        StringBuilder _sb = new StringBuilder();
                        while (!ReferenceManualEntries[i].Contains("##;") && !ReferenceManualEntries[i].Contains("#!") && !ReferenceManualEntries[i].Contains("#@;"))
                        {
                            _sb.Append(_xmlFormatting.returnFormattedString(ReferenceManualEntries[i], moduleName));
                            

                            if (i + 1 != ReferenceManualEntries.Count)
                            {
                                i++;
                            }
                        }

                        _referenceNote._Details = _sb.ToString();
                        _sb = new StringBuilder();

                        // Add the Reference Note to the master object
                        _referenceManual.ReferenceNoteList.Add(_referenceNote);
                        _referenceNote = new ReferenceNote();
                    }
                    else
                    {
                        if (i + 1 != ReferenceManualEntries.Count)
                        {
                            i++;
                        }                       
                    }
                }
                return referenceManualList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

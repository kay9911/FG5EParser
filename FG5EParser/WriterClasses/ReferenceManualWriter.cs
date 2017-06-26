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
                StringBuilder _description = new StringBuilder();

                // Convert _lines to a List
                List<string> ReferenceManualEntries = new List<string>();
                foreach (var line in _lines)
                {
                    ReferenceManualEntries.Add(line);
                }

                for (int i = 0; i < ReferenceManualEntries.Count; i++)
                {
                    // Check for empty entry
                    if (!string.IsNullOrEmpty(ReferenceManualEntries[i]))
                    {
                        // Chapter Header
                        if (ReferenceManualEntries[i].Contains("#@;"))
                        {
                            // If an entry already exists
                            if (!string.IsNullOrEmpty(_referenceManual._ChapterName))
                            {
                                // Save the last of the details
                                _referenceNote._Details = _description.ToString();
                                _referenceManual.ReferenceNoteList.Add(_referenceNote);

                                referenceManualList.Add(_referenceManual);
                                _referenceManual = new ReferenceManual();
                                _referenceNote = new ReferenceNote();
                                CurrentSubChapter = string.Empty;
                                _description.Clear();
                            }

                            _referenceManual._ChapterName = ReferenceManualEntries[i].Replace("#@;", "").Trim();
                        }
                        // Subchapter Heading
                        else if (ReferenceManualEntries[i].Contains("#!;"))
                        {
                            _referenceManual.SubchapterNameList.Add(ReferenceManualEntries[i].Replace("#!;", "").Trim());
                            CurrentSubChapter = ReferenceManualEntries[i].Replace("#!;", "").Trim();
                        }
                        // Reference Note
                        else if (ReferenceManualEntries[i].Contains("##;"))
                        {
                            // If Reference Note already exists
                            if (!string.IsNullOrEmpty(_referenceNote._Title))
                            {
                                // Append the description
                                _referenceNote._Details = _description.ToString();
                                _description.Clear();

                                // Add it to the main list
                                _referenceManual.ReferenceNoteList.Add(_referenceNote);
                                _referenceNote = new ReferenceNote();
                            }

                            _referenceNote._Title = ReferenceManualEntries[i].Replace("##;", "").Trim();
                            // Under chapter?
                            _referenceNote._SubchapterName = CurrentSubChapter;
                        }
                        // Descriptions
                        else
                        {
                            _description.Append(_xmlFormatting.returnFormattedString(ReferenceManualEntries[i].Trim(), moduleName));
                            _description.Append(Environment.NewLine);
                        }
                    }
                    else
                    {
                        if (i + 1 != ReferenceManualEntries.Count)
                        {
                            i++;
                        }
                    }

                    // Get the last entry
                    if (i + 1 == ReferenceManualEntries.Count)
                    {
                        // Save the last of the details
                        _referenceNote._Details = _description.ToString();
                        _referenceManual.ReferenceNoteList.Add(_referenceNote);

                        // Add it to the main list
                        referenceManualList.Add(_referenceManual);
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

using FG5EParser.Utilities;
using FG5eParserModels.Utility_Modules;
using System.Collections.Generic;
using System.Text;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class ReferenceManualHelper
    {
        public string returnReferenceNotesXML(
        List<ReferenceManual> _referenceManualChapterList,
        bool isList = false
        )
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting _xmlFormatting = new XMLFormatting();

            int blockIndex = 0;

            if (!isList)
            {
                #region XML BUILDER NON LIST

                xml.Append("<referencemanual>");

                foreach (var Chapter in _referenceManualChapterList)
                {
                    foreach (var Subchapter in Chapter.SubchapterNameList)
                    {
                        foreach (var ReferenceNote in Chapter.ReferenceNoteList)
                        {
                            if (ReferenceNote._SubchapterName == Subchapter)
                            {
                                //<copyrights>
                                xml.Append(string.Format("<{0}>", _xmlFormatting.formatXMLCharachters(ReferenceNote._Title, "IH")));

                                xml.Append(string.Format("<name type=\"string\">{0}</name>", ReferenceNote._Title));

                                xml.Append("<blocks>");

                                xml.Append(string.Format("<block{0}>", blockIndex.ToString()));

                                xml.Append("<blocktype type=\"string\">text</blocktype>");

                                xml.Append(string.Format("<text type=\"formattedtext\">{0}</text>", ReferenceNote._Details));

                                xml.Append(string.Format("</block{0}>", blockIndex.ToString()));

                                xml.Append("</blocks>");
                                //</copyrights>
                                xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(ReferenceNote._Title, "IH")));
                            }
                        }
                    }
                }

                xml.Append("</referencemanual>");
                #endregion
            }
            else
            {
                xml.Append("<ReferenceManualEntries>");

                xml.Append("<chapters>");

                foreach (var Chapter in _referenceManualChapterList)
                {
                    xml.Append(string.Format("<{0}>",_xmlFormatting.formatXMLCharachters(Chapter._ChapterName,"IH")));

                    xml.Append(string.Format("<name type=\"string\">{0}</name>", Chapter._ChapterName));

                    xml.Append("<subchapters>");

                    foreach (var Subchapter in Chapter.SubchapterNameList)
                    {
                        xml.Append(string.Format("<{0}>", _xmlFormatting.formatXMLCharachters(Subchapter, "IH")));

                        xml.Append(string.Format("<name type=\"string\">{0}</name>", Subchapter));

                        xml.Append("<refpages>");

                        foreach (var ReferenceNote in Chapter.ReferenceNoteList)
                        {
                            if (ReferenceNote._SubchapterName == Subchapter)
                            {
                                xml.Append(string.Format("<{0}>", _xmlFormatting.formatXMLCharachters(ReferenceNote._Title, "IH")));

                                xml.Append("<listlink type=\"windowreference\">");

                                xml.Append("<class>reference_manualtextwide</class>");

                                xml.Append(string.Format("<recordname>reference.referencemanual.{0}</recordname>", _xmlFormatting.formatXMLCharachters(ReferenceNote._Title, "IH")));

                                xml.Append("</listlink>");

                                xml.Append(string.Format("<name type=\"string\">{0}</name>", ReferenceNote._Title));

                                xml.Append(string.Format("<keywords type=\"string\">{0}</keywords>", ReferenceNote._Title));

                                xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(ReferenceNote._Title, "IH")));
                            }
                        }

                        xml.Append("</refpages>");

                        xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(Subchapter, "IH")));
                    }

                    xml.Append("</subchapters>");

                    xml.Append(string.Format("</{0}>", _xmlFormatting.formatXMLCharachters(Chapter._ChapterName, "IH")));
                }

                xml.Append("</chapters>");

                xml.Append("</ReferenceManualEntries>");
            }

            return xml.ToString();
        }
    }
}

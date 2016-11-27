using FG5EParser.Base_Class;
using FG5EParser.WriterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class StoryHelper
    {
        public string returnStoryXML(string _storyTextPath, string _moduleName, bool isListCall = false)
        {
            StringBuilder xml = new StringBuilder();

            StoryWriter _storyWriter = new StoryWriter();
            List<StoryElements> _storyList = _storyWriter.compileStoryList(_storyTextPath,_moduleName);

            // Gather a collection of all category types
            List<string> _categoryTypes = new List<string>();
            _categoryTypes = _storyList.Select(x => x.StoryHeader).Distinct().ToList();

            if (!isListCall)
            {
                #region NON LIST REGION

                //xml.Append();
                xml.Append("<encounter>");

                foreach (string _header in _categoryTypes)
                {
                    if (!string.IsNullOrEmpty(_header))
                    {
                        xml.Append(string.Format("<category name=\"{0}\" baseicon=\"0\" decalicon=\"0\">", _header));
                    }
                    else
                    {
                        xml.Append("<category name=\"\" baseicon=\"0\" decalicon=\"0\">");
                    }

                    #region LOOP AREA

                    for (int i = 0; i < _storyList.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(_storyList[i].StoryTitle) && _storyList[i].StoryHeader == _header) // Avoid Null exceptions
                        {
                            xml.Append(string.Format("<enc_{0}>", _storyList[i].StoryTitle.ToLower().Replace(" ", "").Trim()));

                            xml.Append(string.Format("<locked type=\"number\">{0}</locked>", _storyList[i].isLocked));

                            xml.Append(string.Format("<name type=\"string\">{0}</name>", _storyList[i].StoryTitle));

                            xml.Append(string.Format("<text type=\"formattedtext\">{0}</text>", _storyList[i].StoryDescription));

                            xml.Append(string.Format("</enc_{0}>", _storyList[i].StoryTitle.ToLower().Replace(" ", "").Trim()));
                        }
                    }

                    #endregion

                    xml.Append("</category>");
                }

                #endregion

                xml.Append("</encounter>");
            }
            else
            {
                #region LIST REGION

                xml.Append("<encounter>");

                xml.Append("<bycategory>");

                xml.Append("<description type=\"string\">Story</description>");

                xml.Append("<groups>");

                xml.Append("<typecategory>");

                foreach (string _header in _categoryTypes)
                {
                    if (!string.IsNullOrEmpty(_header))
                    {
                        xml.Append(string.Format("<description type=\"string\">{0}</description>",_header));
                    }
                    else
                    {
                        xml.Append("<description type=\"string\" />");
                    }

                    xml.Append("<index>");

                    for (int i = 0; i < _storyList.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(_storyList[i].StoryTitle) && _storyList[i].StoryHeader == _header)
                        {
                            xml.Append(string.Format("<enc_{0}>", _storyList[i].StoryTitle.ToLower().Replace(" ", "").Trim()));

                            xml.Append("<link type=\"windowreference\">");

                            xml.Append("<class>encounter</class>");

                            xml.Append(string.Format("<recordname>encounter.enc_{0}@{1}</recordname>"
                                , _storyList[i].StoryTitle.ToLower().Replace(" ", "").Trim()
                                , _moduleName));

                            xml.Append("<description>");

                            xml.Append("<field>name</field>");

                            xml.Append("</description>");

                            xml.Append("</link>");

                            xml.Append("<source type=\"string\" />");

                            xml.Append(string.Format("</enc_{0}>", _storyList[i].StoryTitle.ToLower().Replace(" ", "").Trim()));
                        }
                    }

                    xml.Append("</index>");
                }

                xml.Append("</typecategory>");

                xml.Append("</groups>");

                xml.Append("</bycategory>");

                xml.Append("</encounter>");

                #endregion
            }

            return xml.ToString();
        }
    }
}

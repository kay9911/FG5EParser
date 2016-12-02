using FG5EParser.Base_Class;
using FG5EParser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class ItemHelper
    {
        public string returnItemXML(string _itemTextPath, string _moduleName, bool isListCall = false)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting xmlFormatting = new XMLFormatting();

            // REMOVE
            List<Items> _itemList = new List<Items>();

            // Gather a collection of all category types
            List<string> _categoryTypes = new List<string>();
            List<string> _subTypes = new List<string>();

            //_categoryTypes = _storyList.Select(x => x.StoryHeader).Distinct().ToList();

            if (!isListCall)
            {
                #region NON LIST REGION

                //xml.Append();
                xml.Append("<item>");

                foreach (string _category in _categoryTypes)
                {
                    if (!string.IsNullOrEmpty(_category))
                    {
                        xml.Append(string.Format("<category name=\"{0} - {1}\" baseicon=\"2\" decalicon=\"1\">", _category, _moduleName));
                    }

                    foreach (Items _item in _itemList)
                    {
                        // check for category match
                        if (_item.Type == _category)
                        {
                            // Add the name
                            xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_item.Name,"IH")));

                            // Locked type
                            xml.Append(string.Format("<locked type=\"number\">{0}</locked>", _item.isLocked));

                            // Item Name
                            xml.Append(string.Format("<name type=\"string\">{0}</name>", _item.Name));

                            // Item Type
                            xml.Append(string.Format("<type type=\"string\">{0}</type>", _item.Type));

                            // Item Subtype
                            xml.Append(string.Format("<subtype type=\"string\">{0}</subtype>", _item.Subtype));

                            // Item Cost
                            xml.Append(string.Format("<cost type=\"string\">{0}</cost>", _item.Cost));

                            // Mount Speed
                            if (!string.IsNullOrEmpty(_item.Speed))
                            {
                                xml.Append(string.Format("<speed type=\"string\">{0}</speed>", _item.Speed));
                            }

                            // Mount Carrying Capacity
                            if (!string.IsNullOrEmpty(_item.CarryingCapacity))
                            {
                                xml.Append(string.Format("<carryingcapacity type=\"string\">{0}</carryingcapacity>", _item.CarryingCapacity));
                            }

                            // Item AC
                            if (!string.IsNullOrEmpty(_item.AC))
                            {
                                xml.Append(string.Format("<ac type=\"number\">{0}</ac>", _item.AC));
                            }

                            // Dex bonus
                            if (!string.IsNullOrEmpty(_item.DexBonus))
                            {
                                xml.Append(string.Format("<dexbonus type=\"string\">{0}</dexbonus>", _item.DexBonus));
                            }

                            // Str Requirement
                            if (!string.IsNullOrEmpty(_item.StrRequired))
                            {
                                xml.Append(string.Format("<strength type=\"string\">{0}</strength>", _item.StrRequired));
                            }

                            // Stealth Disadvantage
                            if (!string.IsNullOrEmpty(_item.StealthDisadvantage))
                            {
                                xml.Append(string.Format("<stealth type=\"string\">{0}</stealth>", _item.StealthDisadvantage));
                            }

                            // Item Damage
                            if (!string.IsNullOrEmpty(_item.Damage))
                            {
                                xml.Append(string.Format("<damage type=\"string\">{0}</damage>", _item.Damage));
                            }

                            // Item properties
                            if (!string.IsNullOrEmpty(_item.Properties))
                            {
                                xml.Append(string.Format("<properties type=\"string\">{0}</properties>", _item.Properties));
                            }

                            // Item Weight
                            xml.Append(string.Format("<weight type=\"number\">{0}</weight>", _item.Weight));

                            // Item Description
                            if (!string.IsNullOrEmpty(_item.Description))
                            {
                                xml.Append(string.Format("<description type=\"formattedtext\">{0}</description>", xmlFormatting.returnFormattedString(_item.Description, _moduleName)));
                            }

                            // Subitems
                            if (_item.Subitems.Count != 0)
                            {
                                foreach (Subitems _subItem in _item.Subitems)
                                {
                                    xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_subItem.ItemName,"IH")));

                                    xml.Append(string.Format("<count type=\"number\">{0}</count>", _subItem.Count));

                                    // Unique String
                                    xml.Append("<link type=\"windowreference\">");

                                    xml.Append("<class>reference_equipment</class>");

                                    // Record to link
                                    xml.Append(string.Format("<recordname>reference.equipmentdata.{0}@{1}</recordname>"
                                        , xmlFormatting.formatXMLCharachters(_subItem.ItemName,"IH")
                                        , _moduleName
                                        ));

                                    xml.Append("</link>");

                                    xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_subItem.ItemName,"IH")));
                                }
                            }

                            xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_item.Name, "IH")));
                        }
                    }

                    // Common end tag
                    xml.Append("</category>");
                }

                xml.Append("</item>");

                #endregion
            }
            else
            {
                #region ITEM LIST REGION

                xml.Append("<equipmentlists>");

                xml.Append("<equipment>");

                xml.Append("<name type=\"string\">Equipment</name>");

                xml.Append("<index>");

                for (int i = 0; i < _categoryTypes.Count; i++)
                {
                    xml.Append(string.Format("<index-{0}>",i+1));

                    xml.Append("<listlink type=\"windowreference\">");

                    xml.Append(string.Format("<class>reference_{0}table</class>",xmlFormatting.formatXMLCharachters(_categoryTypes[i],"IH")));

                    xml.Append(string.Format("<recordname>reference.equipmentlists.{0}table@{1}</recordname>"
                        , xmlFormatting.formatXMLCharachters(_categoryTypes[i], "IH")
                        , _moduleName
                        ));

                    xml.Append("</listlink>");

                    xml.Append(string.Format("<name type=\"string\">{0}</name>",_categoryTypes[i]));

                    xml.Append(string.Format("</index-{0}>", i + 1));
                }

                xml.Append("</index>");

                xml.Append("</equipment>");

                foreach (string _category in _categoryTypes)
                {
                    // Start making the sublists
                    xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_category, "IH")));

                    xml.Append(string.Format("<description type=\"string\">{0}</description>",_category));

                    xml.Append("<groups>");

                    // Counter
                    int index = 0;

                    foreach (string _subType in _subTypes)
                    {
                        xml.Append(string.Format("<section{0}>",Convert.ToInt32(index)));

                        xml.Append(string.Format("<description type=\"string\">{0}</description>",_subType));

                        xml.Append("<equipment>");

                        foreach (Items _item in _itemList)
                        {
                            // Check for subtype now
                            if (_item.Subtype == _subType)
                            {
                                xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_item.Name, "IH")));

                                xml.Append("<link type=\"windowreference\">");

                                xml.Append("<class>reference_equipment</class>");

                                xml.Append(string.Format("<recordname>reference.equipmentdata.{0}@{1}</recordname>"
                                    , xmlFormatting.formatXMLCharachters(_item.Name,"IH")
                                    , _moduleName
                                    ));

                                xml.Append("</link>");

                                xml.Append(string.Format("<name type=\"string\">{0}</name>",_item.Name));

                                xml.Append(string.Format("<cost type=\"string\">{0}</cost>",_item.Cost));

                                #region ARMOR

                                if(!string.IsNullOrEmpty(_item.AC))
                                    xml.Append(string.Format("<ac type=\"string\">{0}</ac>",_item.AC));

                                if (!string.IsNullOrEmpty(_item.DexBonus))
                                    xml.Append(string.Format("<dexbonus type=\"string\">{0}</dexbonus>",_item.DexBonus));

                                if (!string.IsNullOrEmpty(_item.StrRequired))
                                    xml.Append(string.Format("<strength type=\"string\">{0}</strength>",_item.StrRequired));

                                if (!string.IsNullOrEmpty(_item.StealthDisadvantage))
                                    xml.Append(string.Format("<stealth type=\"string\">{0}</stealth>",_item.StealthDisadvantage));

                                #endregion

                                #region WEAPONS

                                if (!string.IsNullOrEmpty(_item.Damage))
                                    xml.Append(string.Format("<damage type=\"string\">{0}</damage>",_item.Damage));

                                if (!string.IsNullOrEmpty(_item.Properties))
                                    xml.Append(string.Format("<properties type=\"string\">{0}</properties>",_item.Properties));

                                #endregion

                                #region MOUNTS AND LOCOMOTIVES
                                if (!string.IsNullOrEmpty(_item.Speed))
                                    xml.Append(string.Format("<speed type=\"string\">{0}</speed>",_item.Speed));

                                if (!string.IsNullOrEmpty(_item.CarryingCapacity))
                                    xml.Append(string.Format("<carryingcapacity type=\"string\">{0}</carryingcapacity>",_item.CarryingCapacity));

                                #endregion

                                if (!string.IsNullOrEmpty(_item.Weight))
                                    xml.Append(string.Format("<weight type=\"number\">1.0</weight>", _item.Weight));

                                xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_item.Name, "IH")));
                            }
                        }

                        xml.Append("</equipment>");

                        xml.Append(string.Format("</section{0}>", Convert.ToInt32(index)));
                    }

                    xml.Append("</groups>");

                    xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_category, "IH")));
                }

                xml.Append("</equipmentlists>");

                #endregion
            }

            return xml.ToString();

        }
    }
}

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
            //_categoryTypes = _storyList.Select(x => x.StoryHeader).Distinct().ToList();

            if (!isListCall)
            {
                #region NON LIST REGION

                //xml.Append();
                xml.Append("<item>");

                foreach (string _category in _categoryTypes)
                {
                    if (_category == "ADVENTURING GEAR")
                    {
                        xml.Append(string.Format("<category name=\"Adventuring Gear - {0}\" baseicon=\"2\" decalicon=\"1\">",_moduleName));
                    }

                    if (_category == "TOOLS")
                    {
                        xml.Append(string.Format("<category name=\"Tools - {0}\" baseicon=\"2\" decalicon=\"1\">",_moduleName));
                    }

                    if (_category == "ARMOR")
                    {
                        xml.Append(string.Format("<category name=\"Armor - {0}\" baseicon=\"2\" decalicon=\"1\">",_moduleName));
                    }

                    if (_category == "WEAPON")
                    {
                        xml.Append(string.Format("<category name=\"Weapon - {0}\" baseicon=\"2\" decalicon=\"1\">",_moduleName));
                    }

                    if (_category == "")
                    {
                        xml.Append(string.Format("<category name=\"Mounts And Other Animals - {0}\" baseicon=\"2\" decalicon=\"1\">",_moduleName));
                    }

                    foreach (Items _item in _itemList)
                    {
                        // check for category match
                        if (_item.Type == _category)
                        {
                            // Add the name
                            xml.Append(string.Format("{0}", _item.Name));

                            // Locked type
                            xml.Append(string.Format("<locked type=\"number\">{0}</locked>", _item.isLocked));

                            // Item Name
                            xml.Append(string.Format("<name type=\"string\">{0}</name>", _item.Name));

                            // Item Type
                            xml.Append(string.Format("<type type=\"string\">{0}</type>",_item.Type));

                            // Item Subtype
                            xml.Append(string.Format("<subtype type=\"string\">{0}</subtype>",_item.Subtype));

                            // Item Cost
                            xml.Append(string.Format("<cost type=\"string\">{0}</cost>", _item.Cost));

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
                                xml.Append(string.Format("<stealth type=\"string\">{0}</stealth>",_item.StealthDisadvantage));
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
                            xml.Append(string.Format("<weight type=\"number\">{0}</weight>",_item.Weight));

                            // Item Description (Not mandatory)
                            if (!string.IsNullOrEmpty(_item.Description))
                            {
                                xml.Append(string.Format("<description type=\"formattedtext\">{0}</description>",xmlFormatting.returnFormattedString(_item.Description,_moduleName)));
                            }

                            // TO DO : Implement <subitems>

                            xml.Append(string.Format("{/0}", _item.Name));
                        }
                    }

                    // Common end tag
                    xml.Append("</category>");
                }

                xml.Append("</item>");

                #endregion
            }

            return xml.ToString();

        }
    }
}

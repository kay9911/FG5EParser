using FG5EParser.Base_Class;
using FG5EParser.Utilities;
using FG5EParser.WriterClasses;
using FG5eParserModels.DM_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class ItemHelper
    {
        public string returnItemXML(string _itemTextPath, string _moduleName, bool isListCall = false)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting xmlFormatting = new XMLFormatting();

            ItemWriter _itemWriter = new ItemWriter();
            List<Items> _itemList = _itemWriter.compileItemList(_itemTextPath, _moduleName);

            // Gather a collection of all category types
            List<string> _categoryTypes = _itemList.Select(x => x.Type).Distinct().ToList();

            if (!isListCall)
            {
                #region NON LIST REGION

                //xml.Append();

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
                            xml.Append(string.Format("<subtype type=\"string\">{0}</subtype>", xmlFormatting.formatXMLCharachters(_item.Subtype,"ID")));

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
                                xml.Append("<subitems>");

                                foreach (Subitems _subItem in _item.Subitems)
                                {
                                    xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_subItem.ItemName,"IH")));

                                    xml.Append(string.Format("<name type=\"string\">{0}</name>", _subItem.ItemName));

                                    xml.Append(string.Format("<count type=\"number\">{0}</count>", _subItem.Count));

                                    // Unique String
                                    xml.Append("<link type=\"windowreference\">");

                                    xml.Append("<class>reference_equipment</class>");

                                    // Record to link
                                    xml.Append(string.Format("<recordname>items.{0}@{1}</recordname>"
                                        , xmlFormatting.formatXMLCharachters(_subItem.ItemName,"IH")
                                        , _moduleName
                                        ));

                                    xml.Append("</link>");

                                    xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_subItem.ItemName,"IH")));
                                }

                                xml.Append("</subitems>");
                            }

                            xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_item.Name, "IH")));
                        }
                    }

                    // Common end tag
                    xml.Append("</category>");
                }

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
                    xml.Append(string.Format("<id-{0}>",i+1));

                    xml.Append("<listlink type=\"windowreference\">");

                    if (_categoryTypes[i].ToLower() == "tools")
                    {
                        xml.Append("<class>reference_adventuringgeartable</class>");
                    }
                    else if (_categoryTypes[i].ToLower() == "tack, harness, and drawn vehicles")
                    {
                        xml.Append("<class>reference_adventuringgeartable</class>");
                    }
                    else if (_categoryTypes[i].ToLower() == "waterborne vehicles")
                    {
                        xml.Append("<class>reference_waterbornevehiclestable</class>");
                    }
                    else
                        xml.Append(string.Format("<class>reference_{0}table</class>", xmlFormatting.formatXMLCharachters(_categoryTypes[i], "IH")));

                    xml.Append(string.Format("<recordname>reference.equipmentlists.{0}table@{1}</recordname>"
                        , xmlFormatting.formatXMLCharachters(_categoryTypes[i], "IH")
                        , _moduleName
                        ));

                    xml.Append("</listlink>");

                    xml.Append(string.Format("<name type=\"string\">{0}</name>",_categoryTypes[i]));

                    xml.Append(string.Format("</id-{0}>", i + 1));
                }

                xml.Append("</index>");

                xml.Append("</equipment>");

                foreach (string _category in _categoryTypes)
                {
                    // Start making the sublists
                    xml.Append(string.Format("<{0}table>", xmlFormatting.formatXMLCharachters(_category, "IH")));

                    xml.Append(string.Format("<description type=\"string\">{0}</description>",_category));

                    xml.Append("<groups>");

                    // Counter
                    int index = 0;

                    // Gater the collection wrt to current category
                    List<Items> _currentCollection = _itemList.Where(x => x.Type == _category).ToList();
                    // Gather a collection of all subtypes
                    List<string> _subTypes = _currentCollection.Select(x => x.Subtype).Distinct().ToList();

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

                                if (_category.ToLower() == "armor")
                                {
                                    xml.Append("<class>reference_armor</class>");
                                }
                                else if (_category.ToLower() == "weapon")
                                {
                                    xml.Append("<class>reference_weapon</class>");
                                }
                                else if (_category.ToLower() == "mounts and other animals")
                                {
                                    xml.Append("<class>reference_mountsandotheranimals</class>");
                                }
                                else if (_category.ToLower() == "waterborne vehicles")
                                {
                                    xml.Append("<class>reference_waterbornevehicles</class>");
                                }
                                else
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
                                    xml.Append(string.Format("<weight type=\"number\">{0}</weight>", _item.Weight));

                                xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_item.Name, "IH")));
                            }
                        }

                        xml.Append("</equipment>");

                        xml.Append(string.Format("</section{0}>", Convert.ToInt32(index)));

                        index++;
                    }

                    xml.Append("</groups>");

                    xml.Append(string.Format("</{0}table>", xmlFormatting.formatXMLCharachters(_category, "IH")));
                }

                xml.Append("</equipmentlists>");

                #endregion
            }

            return xml.ToString();

        }

        public string returnItemReferenceDetails(string _itemTextPath, string _moduleName)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting xmlFormatting = new XMLFormatting();

            ItemWriter _itemWriter = new ItemWriter();
            List<Items> _itemList = _itemWriter.compileItemList(_itemTextPath, _moduleName);

            // Gather a collection of all category types
            List<string> _categoryTypes = _itemList.Select(x => x.Type).Distinct().ToList();

            // Gather a collection of all subtypes
            List<string> _subTypes = _itemList.Select(x => x.Subtype).Distinct().ToList();

            xml.Append("<equipmentdata>");

            foreach (Items _item in _itemList)
            {
                // Add the name
                xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_item.Name, "IH")));

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
                    xml.Append("<subitems>");

                    foreach (Subitems _subItem in _item.Subitems)
                    {
                        xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_subItem.ItemName, "IH")));

                        xml.Append(string.Format("<name type=\"string\">{0}</name>",_subItem.ItemName));

                        xml.Append(string.Format("<count type=\"number\">{0}</count>", _subItem.Count));

                        // Unique String
                        xml.Append("<link type=\"windowreference\">");

                        xml.Append("<class>reference_equipment</class>");

                        // Record to link
                        xml.Append(string.Format("<recordname>reference.equipmentdata.{0}@{1}</recordname>"
                            , xmlFormatting.formatXMLCharachters(_subItem.ItemName, "IH")
                            , _moduleName
                            ));

                        xml.Append("</link>");

                        xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_subItem.ItemName, "IH")));
                    }

                    xml.Append("</subitems>");
                }

                xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_item.Name, "IH")));
            }

            xml.Append("</equipmentdata>");

            return xml.ToString();
        }

    }

    class MagicalItemHelper
    {
        public string returnItemXML(string _magicalItemTextPath, List<MagicalItems> _itemList, string _moduleName, bool isListCall = false)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting xmlFormatting = new XMLFormatting();

            // Gather a collection of all category types
            List<string> _categoryTypes = _itemList.Select(x => x._Category).Distinct().ToList();

            if (!isListCall)
            {
                #region NON LIST REGION

                foreach (string _category in _categoryTypes)
                {
                    xml.Append(string.Format("<category name=\"{0}\" baseicon=\"2\" decalicon=\"1\">"
                        , _category
                        ));

                    foreach (MagicalItems _item in _itemList)
                    {
                        if (_item._Category == _category)
                        {
                            // Start tag
                            xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_item._Name, "IH")));

                            if (!string.IsNullOrEmpty(_item._AC))
                            {
                                xml.Append(string.Format("<ac type=\"number\">{0}</ac>", _item._AC));
                            }
                            if (!string.IsNullOrEmpty(_item._ACBonus))
                            {
                                xml.Append(string.Format("<bonus type=\"number\">{0}</bonus>", _item._ACBonus));
                            }
                            xml.Append(string.Format("<cost type=\"string\">{0}</cost>", _item._Cost));

                            if (!string.IsNullOrEmpty(_item._Damage))
                            {
                                xml.Append(string.Format("<damage type=\"string\">{0}</damage>", _item._Damage));
                            }

                            if (!string.IsNullOrEmpty(_item._Description))
                            {
                                xml.Append(string.Format("<description type=\"formattedtext\">{0}</description>", _item._Description));
                            }

                            if (!string.IsNullOrEmpty(_item._DexBonus))
                            {
                                xml.Append(string.Format("<dexbonus type=\"string\">{0}</dexbonus>", _item._DexBonus));
                            }

                            xml.Append(string.Format("<isidentified type=\"number\">{0}</isidentified>", 0));

                            xml.Append(string.Format("<istemplate type=\"number\">{0}</istemplate>", 0));

                            xml.Append(string.Format("<locked type=\"number\">{0}</locked>", 1));

                            xml.Append(string.Format("<name type=\"string\">{0}</name>", _item._Name));

                            if (!string.IsNullOrEmpty(_item._UnidenifiedBaseType))
                            {
                                xml.Append(string.Format("<nonid_name type=\"string\">{0}</nonid_name>", _item._UnidenifiedBaseType));
                            }

                            if (!string.IsNullOrEmpty(_item._UnidentifiedDescription))
                            {
                                xml.Append(string.Format("<nonidentified type=\"string\">{0}</nonidentified>", _item._UnidentifiedDescription));
                            }

                            if (!string.IsNullOrEmpty(_item._Properties))
                            {
                                xml.Append(string.Format("<properties type=\"string\">{0}</properties>", _item._Properties));
                            }

                            if (!string.IsNullOrEmpty(_item._IsStealthDisadvantage.ToString()))
                            {
                                xml.Append(string.Format("<stealth type=\"string\">{0}</stealth>"
                                    , _item._IsStealthDisadvantage.ToString().ToLower() == "true" ? "Disadvantage" : "" 
                                    ));
                            }

                            if (!string.IsNullOrEmpty(_item._StrRequired))
                            {
                                xml.Append(string.Format("<strength type=\"string\">{0}</strength>", _item._StrRequired));
                            }

                            xml.Append(string.Format("<subtype type=\"string\">{0}</subtype>", _item._Subtype));

                            xml.Append(string.Format("<type type=\"string\">{0}</type>", _item._Type));

                            xml.Append(string.Format("<rarity type=\"string\">{0}</rarity>", _item._Rarity));

                            xml.Append(string.Format("<weight type=\"number\">{0}</weight>", _item._Weight));
                            // End tag
                            xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_item._Name, "IH")));
                        }
                    }

                    xml.Append("</category>");
                }

                #endregion
            }
            else
            {
                #region LIST SECTION

                xml.Append("<magicitem>");

                xml.Append("<bytype>");

                xml.Append("<description type=\"string\">Magic Items</description>");

                xml.Append("<groups>");

                foreach (string _category in _categoryTypes)
                {
                    xml.Append(string.Format(string.Format("<type{0}>", xmlFormatting.formatXMLCharachters(_category, "IH"))));

                    xml.Append(string.Format("<description type=\"string\">{0}</description>", _category));

                    xml.Append("<index>");

                    foreach (MagicalItems _item in _itemList)
                    {
                        if (_item._Category == _category)
                        {
                            // Start tag                            
                            xml.Append(string.Format(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_item._Name, "IH"))));

                            xml.Append("<link type=\"windowreference\">");

                            xml.Append("<class>reference_magicitem</class>");

                            xml.Append(string.Format("<recordname>item.{0}@{1}</recordname>"
                                , xmlFormatting.formatXMLCharachters(_item._Name, "IH")
                                , _moduleName
                                ));

                            xml.Append("<description>");

                            xml.Append("<field>name</field>");

                            xml.Append("</description>");

                            xml.Append("</link>");

                            xml.Append(string.Format("<source>{0}</source>", _category));

                            // End Tag
                            xml.Append(string.Format(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_item._Name, "IH"))));
                        }
                    }

                    xml.Append("</index>");

                    xml.Append(string.Format(string.Format("</type{0}>", xmlFormatting.formatXMLCharachters(_category, "IH"))));
                }

                xml.Append("</groups>");

                xml.Append("</bytype>");

                xml.Append("</magicitem>");

                #endregion
            }

            return xml.ToString();
        }

        #region UNUSED CODE
        //public string returnItemReferenceDetails(string _itemTextPath, string _moduleName)
        //{
        //    StringBuilder xml = new StringBuilder();
        //    XMLFormatting xmlFormatting = new XMLFormatting();

        //    ItemWriter _itemWriter = new ItemWriter();
        //    List<Items> _itemList = _itemWriter.compileItemList(_itemTextPath, _moduleName);

        //    // Gather a collection of all category types
        //    List<string> _categoryTypes = _itemList.Select(x => x.Type).Distinct().ToList();

        //    // Gather a collection of all subtypes
        //    List<string> _subTypes = _itemList.Select(x => x.Subtype).Distinct().ToList();

        //    xml.Append("<equipmentdata>");

        //    foreach (Items _item in _itemList)
        //    {
        //        // Add the name
        //        xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_item.Name, "IH")));

        //        // Locked type
        //        xml.Append(string.Format("<locked type=\"number\">{0}</locked>", _item.isLocked));

        //        // Item Name
        //        xml.Append(string.Format("<name type=\"string\">{0}</name>", _item.Name));

        //        // Item Type
        //        xml.Append(string.Format("<type type=\"string\">{0}</type>", _item.Type));

        //        // Item Subtype
        //        xml.Append(string.Format("<subtype type=\"string\">{0}</subtype>", _item.Subtype));

        //        // Item Cost
        //        xml.Append(string.Format("<cost type=\"string\">{0}</cost>", _item.Cost));

        //        // Mount Speed
        //        if (!string.IsNullOrEmpty(_item.Speed))
        //        {
        //            xml.Append(string.Format("<speed type=\"string\">{0}</speed>", _item.Speed));
        //        }

        //        // Mount Carrying Capacity
        //        if (!string.IsNullOrEmpty(_item.CarryingCapacity))
        //        {
        //            xml.Append(string.Format("<carryingcapacity type=\"string\">{0}</carryingcapacity>", _item.CarryingCapacity));
        //        }

        //        // Item AC
        //        if (!string.IsNullOrEmpty(_item.AC))
        //        {
        //            xml.Append(string.Format("<ac type=\"number\">{0}</ac>", _item.AC));
        //        }

        //        // Dex bonus
        //        if (!string.IsNullOrEmpty(_item.DexBonus))
        //        {
        //            xml.Append(string.Format("<dexbonus type=\"string\">{0}</dexbonus>", _item.DexBonus));
        //        }

        //        // Str Requirement
        //        if (!string.IsNullOrEmpty(_item.StrRequired))
        //        {
        //            xml.Append(string.Format("<strength type=\"string\">{0}</strength>", _item.StrRequired));
        //        }

        //        // Stealth Disadvantage
        //        if (!string.IsNullOrEmpty(_item.StealthDisadvantage))
        //        {
        //            xml.Append(string.Format("<stealth type=\"string\">{0}</stealth>", _item.StealthDisadvantage));
        //        }

        //        // Item Damage
        //        if (!string.IsNullOrEmpty(_item.Damage))
        //        {
        //            xml.Append(string.Format("<damage type=\"string\">{0}</damage>", _item.Damage));
        //        }

        //        // Item properties
        //        if (!string.IsNullOrEmpty(_item.Properties))
        //        {
        //            xml.Append(string.Format("<properties type=\"string\">{0}</properties>", _item.Properties));
        //        }

        //        // Item Weight
        //        xml.Append(string.Format("<weight type=\"number\">{0}</weight>", _item.Weight));

        //        // Item Description
        //        if (!string.IsNullOrEmpty(_item.Description))
        //        {
        //            xml.Append(string.Format("<description type=\"formattedtext\">{0}</description>", xmlFormatting.returnFormattedString(_item.Description, _moduleName)));
        //        }

        //        // Subitems
        //        if (_item.Subitems.Count != 0)
        //        {
        //            xml.Append("<subitems>");

        //            foreach (Subitems _subItem in _item.Subitems)
        //            {
        //                xml.Append(string.Format("<{0}>", xmlFormatting.formatXMLCharachters(_subItem.ItemName, "IH")));

        //                xml.Append(string.Format("<name type=\"string\">{0}</name>", _subItem.ItemName));

        //                xml.Append(string.Format("<count type=\"number\">{0}</count>", _subItem.Count));

        //                // Unique String
        //                xml.Append("<link type=\"windowreference\">");

        //                xml.Append("<class>reference_equipment</class>");

        //                // Record to link
        //                xml.Append(string.Format("<recordname>reference.equipmentdata.{0}@{1}</recordname>"
        //                    , xmlFormatting.formatXMLCharachters(_subItem.ItemName, "IH")
        //                    , _moduleName
        //                    ));

        //                xml.Append("</link>");

        //                xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_subItem.ItemName, "IH")));
        //            }

        //            xml.Append("</subitems>");
        //        }

        //        xml.Append(string.Format("</{0}>", xmlFormatting.formatXMLCharachters(_item.Name, "IH")));
        //    }

        //    xml.Append("</equipmentdata>");

        //    return xml.ToString();
        //}
        #endregion
    }
}

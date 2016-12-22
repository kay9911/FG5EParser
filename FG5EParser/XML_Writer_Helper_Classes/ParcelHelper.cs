using FG5EParser.Base_Class;
using FG5EParser.Utilities;
using FG5EParser.WriterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class ParcelHelper
    {
        public string returnParcelXML(string _parcelTextPath, string _moduleName, bool isList = false)
        {
            StringBuilder xml = new StringBuilder();
            XMLFormatting xmlFormatting = new XMLFormatting();

            ParcelWriter _parcelWriter = new ParcelWriter();
            List<Parcles> _parcelList = _parcelWriter.compileParcelList(_parcelTextPath, _moduleName);

            // Gather a collection of all category types
            List<string> _categoryTypes = _parcelList.Select(x => x.Category).Distinct().ToList();

            if (isList)
            {
                #region XML WRITING REGION

                xml.Append("<treasureparcels>");

                foreach (string _category in _categoryTypes)
                {
                    xml.Append(string.Format("<category name=\"{0} - {1}\" baseicon=\"2\" decalicon=\"1\">", _category, _moduleName));

                    foreach (Parcles _parcle in _parcelList)
                    {
                        if (_parcle.Category == _category)
                        {
                            // Name index
                            xml.Append(string.Format("<0>", xmlFormatting.formatXMLCharachters(_parcle.Name, "IH")));

                            // Name
                            xml.Append(string.Format("<name type=\"string\">{0}</name>", _parcle.Name));

                            xml.Append(string.Format("<locked type=\"number\">{0}</locked>", _parcle.isLocked));

                            // Coin List
                            xml.Append("<coinlist>");

                            // Declare Index
                            int i = 1;

                            foreach (Coins _coin in _parcle.coinsList)
                            {
                                xml.Append(string.Format("<index-{0}>", i));

                                xml.Append(string.Format("<amount type=\"number\">{0}</amount>", _coin.Amount));

                                xml.Append(string.Format("<description type=\"string\">{0}</description>", _coin.Name));

                                xml.Append(string.Format("</index-{0}>", i));
                                i++;
                            }

                            xml.Append("</coinlist>");

                            // Item List
                            xml.Append("<itemlist>");

                            // Declare Index
                            i = 1;

                            foreach (ItemList _item in _parcle.itemList)
                            {
                                xml.Append(string.Format("<index-{0}>", i));

                                xml.Append(string.Format("<name type=\"string\">{0}</name>", _item.Name));

                                xml.Append(string.Format("<count type=\"number\">{0}</count>", _item.Count));

                                xml.Append(string.Format("</index-{0}>", i));
                                i++;
                            }

                            xml.Append("</itemlist>");

                            xml.Append(string.Format("</0>", xmlFormatting.formatXMLCharachters(_parcle.Name, "IH")));
                        }
                    }


                    xml.Append("/category");
                }

                xml.Append("</treasureparcels>");

                #endregion
            }
            else
            {
                xml.Append("<treasureparcel>");

                xml.Append("<bycategory>");

                xml.Append("<description type=\"string\">Treasure Parcels</description>");

                xml.Append("<groups>");

                foreach (string _category in _categoryTypes)
                {
                    xml.Append(string.Format("<typecategory{0}>", xmlFormatting.formatXMLCharachters(_category,"IH")));



                    xml.Append(string.Format("</typecategory{0}>", xmlFormatting.formatXMLCharachters(_category, "IH")));
                }                

                xml.Append("</groups>");

                xml.Append("</bycategory>");

                xml.Append("</treasureparcel>");
            }

            return xml.ToString();
        }
    }
}

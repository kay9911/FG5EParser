using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.XML_Writer_Helper_Classes
{
    class ClassHelper
    {
        public string returnClassesXML()
        {
            StringBuilder xml = new StringBuilder();

            // Send for processing here

            #region START XML PROCESSING

            xml.Append("<classdata>");

            // TO DO : Needs to be the class name via the function
            xml.Append("<classname>");

            xml.Append(string.Format("<name type=\"string\">{0}</name>")); // Class name goes here

            xml.Append("<text type=\"formattedtext\">");

            // Here is where a huge block of text needs to come in

            xml.Append("</text>");

            #region HP SECTION

            xml.Append("<hp>");

            xml.Append("<hitdice>");

            xml.Append("<name type=\"string\">Hit Dice</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>")); // Hit dice goes here

            xml.Append("</hitdice>");

            xml.Append("</hp>");

            xml.Append("<hitpointsat1stlevel>");

            xml.Append("<name type=\"string\"> Hit Points at 1st Level</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>")); // Hp at first level goes here   

            xml.Append("</hitpointsat1stlevel>");

            xml.Append("<name type=\"string\"> Hit Points at higher levels</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</ text>")); // hp post first level goes here

            xml.Append("</hitpointsathigherlevels>");

            #endregion

            #region PEOFICIENCIES SECTION

            xml.Append("<proficiencies>");

            xml.Append("<armor>");

            xml.Append("<name type=\"string\">Armor</name>");
 
            xml.Append(string.Format("<text type=\"string\">{0}<text>")); // armor goes here

            xml.Append("</armor>");

            xml.Append("<weapons>");

            xml.Append("<name type=\"string\">Weapons</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>")); // weapons go here       

            xml.Append("</weapons>");

            xml.Append("<tools>");

            xml.Append("<name type=\"string\">Tools</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>")); // tools go here           

            xml.Append("</tools>");

            xml.Append("<savingthrows>");

            xml.Append("<name type=\"string\">Saving Throws</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>")); // saving throws go here 

            xml.Append("</savingthrows>");

            xml.Append("<skills>");

            xml.Append("<name type=\"string\">Skills</name>");

            xml.Append(string.Format("<text type=\"string\">{0}</text>")); // skills go here                             

            xml.Append("</skills>");

            xml.Append("</proficiencies>");

            #endregion

            #region FEATURES SECTION

            xml.Append("<features>");

            // Features to be sent for processing here 

            xml.Append("</features>");

            #endregion

            #region ABILITIES SECTION

            xml.Append("<abilities>");

            // Abilities to be sent for processing here

            xml.Append("</abilities>");

            #endregion

            #region EQUIPMENT SECTION

            xml.Append("<equipment>");

            xml.Append("<standard>");

            xml.Append("<group type=\"string\">standard</group>");

            xml.Append(string.Format(<"item type=s\"string\">{0}</item>")); // equipment goes here
 
            xml.Append("</standard>");

            xml.Append("</equipment>");

            #endregion

            // TO DO : Needs to be the class name via the function
            xml.Append("</classname>"); 

            xml.Append("</classdata>");

            xml.Append("<classlists>");

            xml.Append("<byletter>");

            xml.Append("<description type=\"string\">Classes</description>");

            xml.Append("<groups>");

            // Now we need to sort by letter
            //xml.Append(string.Format("{0}", sortByLetter(_Npcs, _moduleName)));

            xml.Append("</groups>");

            xml.Append("</byletter>");

            xml.Append("</classlists>");

            #endregion

            return xml.ToString();
        }

        //private string sortByLetter(List<Personalities> _Npcs, string _moduleName)
        //{
        //    StringBuilder _npc = new StringBuilder();
        //    List<string> alphabets = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        //    foreach (string _s in alphabets)
        //    {
        //        Personalities _current = new Personalities();

        //        _current = _Npcs.Find(x => x.NPCName.StartsWith(_s) || x.NPCName.StartsWith(_s.ToLower()));

        //        if (_current != null)
        //        {
        //            _npc.Append(string.Format("<typeletter{0}>", _s.ToLower()));

        //            _npc.Append(string.Format("<description type=\"string\">{0}</description>", _s));

        //            _npc.Append("<index>");

        //            var _list = _Npcs.FindAll(x => x.NPCName.StartsWith(_s)).ToList();

        //            // Start returning NPC's based on starting letter

        //            while (_list.Count != 0)
        //            {
        //                _current = _list.First();

        //                _npc.Append(string.Format("<{0}>", _current.NPCName.Replace(" ", "").ToLower().Trim()));

        //                _npc.Append("<link type=\"windowreference\">");

        //                _npc.Append("<class>npc</class>");

        //                _npc.Append(string.Format("<recordname>npc.{0}@{1}</recordname>", _current.NPCName.Replace(" ", "").ToLower().Trim(), _moduleName));

        //                _npc.Append("<description>");

        //                _npc.Append("<field>name</field>");

        //                _npc.Append("</description>");

        //                _npc.Append("</link>");

        //                _npc.Append("<source type=\"string\" />");

        //                _npc.Append(string.Format("</{0}>", _current.NPCName.Replace(" ", "").ToLower().Trim()));

        //                #region Example
        //                //      < deathknight >
        //                //  < link type = "windowreference" >

        //                //     <class>npc</class>
        //                //    <recordname>npc.deathknight @Monster Manual</recordname>
        //                //    <description>
        //                //      <field>name</field>
        //                //    </description>
        //                //  </link>
        //                //  <source type = "string" />
        //                //</ deathknight >
        //                #endregion
        //                // After processing get rid of it
        //                _list.RemoveAt(0);
        //            }

        //            _npc.Append("</index>");

        //            _npc.Append(string.Format("</typeletter{0}>", _s.ToLower()));

        //        } // end of (_current != null)

        //    } // end of foreach

        //    return _npc.ToString();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FG5EParser.Utilities
{
    class XMLFormatting
    {
        public string returnFormattedString(string _toFormat, string _moduleName)
        {
            if (_toFormat.Contains("#h;"))
            {
                _toFormat = string.Format("{0}</h>", _toFormat.Replace("#h;", "<h>"));
            }
            else if (_toFormat.Contains("#ts;"))
            {
                _toFormat = string.Format("<table>");
            }
            else if (_toFormat.Contains("#th;"))
            {
                StringBuilder th = new StringBuilder();

                th.Append("<tr decoration=\"underline\">");

                List<string> _th = new List<string>(_toFormat.Split(';'));

                for (int i = 1; i < _th.Count(); i++)
                {
                    if (!string.IsNullOrEmpty(_th[i].ToString()))
                    {
                        th.Append("<td>");

                        th.Append(string.Format("<b>{0}</b>", _th[i].ToString().Trim()));

                        th.Append("</td>");
                    }
                }

                th.Append("</tr>");

                _toFormat = th.ToString();
            }
            else if (_toFormat.Contains("#tr;"))
            {
                StringBuilder th = new StringBuilder();

                th.Append("<tr>");

                List<string> _th = new List<string>(_toFormat.Split(';'));

                for (int i = 1; i < _th.Count(); i++)
                {
                    if (!string.IsNullOrEmpty(_th[i].ToString()))
                    {
                        th.Append("<td>");

                        th.Append(string.Format("{0}", _th[i].ToString().Trim()));

                        th.Append("</td>");
                    }
                }

                th.Append("</tr>");

                _toFormat = th.ToString();
            }
            else if (_toFormat.Contains("#te;"))
            {
                _toFormat = "</table>";
            }
            else if (_toFormat.Contains("#ls;"))
            {
                return "<list>";
            }
            else if (_toFormat.Contains("#li;"))
            {
                _toFormat = _toFormat.Replace("#li;", "");
                return string.Format("<li>{0}</li>", _toFormat.Trim());
            }
            else if (_toFormat.Contains("#le;"))
            {
                return "</list>";
            }
            else if (_toFormat.Contains("#bp;"))
            {
                _toFormat = _toFormat.Replace("#bp;", "");
                _toFormat = string.Format("<p><b>{0}</b></p>", _toFormat);
            }
            else if (_toFormat.Contains("#zls;"))
            {
                return "<listlink>";
            }
            else if (_toFormat.Contains("#zl;"))
            {
                _toFormat = _toFormat.Replace("#zl;","");

                // Format depending on what record set is required
                if (_toFormat.Contains("_ability"))
                {
                    _toFormat = _toFormat.Replace("_ability", "");

                    string _useName = string.Empty;

                    if (!string.IsNullOrEmpty(_toFormat.Split(';')[2]))
                    {
                        _useName = _toFormat.Split(';')[2];
                    }
                    else
                    {
                        _useName = _toFormat.Split(';')[1];
                    }

                    _toFormat = string.Format("<link class=\"reference_classability\" recordname=\"reference.classdata.{0}.abilities.{1}@{2}\">{3}</link>",
                        _toFormat.Split(';')[0].ToLower().Trim(),
                        _toFormat.Split(';')[1].ToLower().Replace(" ", "").Trim(),
                        _moduleName,
                        _useName.Trim());
                }

            }
            else if (_toFormat.Contains("#zal;"))
            {
                _toFormat = _toFormat.Replace("#zal;", "");

                // Format depending on what record set is required
                if (_toFormat.Contains("_ability"))
                {
                    _toFormat = _toFormat.Replace("_ability", "");

                    string _useName = string.Empty;

                    if (!string.IsNullOrEmpty(_toFormat.Split(';')[3]))
                    {
                        _useName = _toFormat.Split(';')[3];
                    }
                    else
                    {
                        _useName = _toFormat.Split(';')[1];
                    }

                    _toFormat = string.Format("<link class=\"reference_classability\" recordname=\"reference.classdata.{0}.abilities.{1}@{2}\">{3}</link>",
                        _toFormat.Split(';')[0].ToLower().Trim(),
                        _toFormat.Split(';')[1].ToLower().Replace(" ", "").Trim(),
                        _toFormat.Split(';')[2].Trim(),
                        _useName.Trim());
                }

                //<link class="reference_backgroundfeature" recordname="reference.backgrounddata.acolyte.features.shelterofthefaithful@DD5E SRD Data">TESTING</link>
                else if (_toFormat.Contains("background_feature"))
                {
                    //background_feature;Acolyte;Shelter of the faithful;DD5E SRD Data;Background Feature Check

                    _toFormat = _toFormat.Replace("background_feature;", "");

                    //Acolyte;Shelter of the faithful;DD5E SRD Data;Background Feature Check

                    string _useName = string.Empty;
                    if (!string.IsNullOrEmpty(_toFormat.Split(';')[3]))
                    {
                        _useName = _toFormat.Split(';')[3];
                    }
                    else
                    {
                        _useName = _toFormat.Split(';')[1];
                    }

                    _toFormat = string.Format("<link class=\"reference_backgroundfeature\" recordname=\"reference.backgrounddata.{0}.features.{1}@{2}\">{3}</link>",
                        _toFormat.Split(';')[0].ToLower().Replace(" ", "").Trim(),
                        _toFormat.Split(';')[1].ToLower().Replace(" ", "").Trim(),
                        _toFormat.Split(';')[2].Trim(),
                        _useName
                        );
                }

                //<link class="reference_background" recordname="reference.backgrounddata.acolyte@DD5E SRD Data">TESTING</link>
                else if (_toFormat.Contains("background"))
                {
                    //background;Acolyte;DD5E SRD Data;Check this out

                    _toFormat = _toFormat.Replace("background;", "");

                    //Acolyte;DD5E SRD Data;Check this out

                    string _useName = string.Empty;
                    if (!string.IsNullOrEmpty(_toFormat.Split(';')[2]))
                    {
                        _useName = _toFormat.Split(';')[2];
                    }
                    else
                    {
                        _useName = _toFormat.Split(';')[0];
                    }

                    _toFormat = string.Format("<link class=\"reference_background\" recordname=\"reference.backgrounddata.{0}@{1}\">{2}</link>",
                        _toFormat.Split(';')[0].ToLower().Replace(" ", "").Trim(),
                        _toFormat.Split(';')[1].Trim(),
                        _useName
                        );
                }

                //<link class="reference_classfeature" recordname="reference.classdata.barbarian.features.rage1@Player Handbook">TESTING</link>
                else if (_toFormat.Contains("_feature"))
                {
                    //#zal;barbarian_feature;Rage;Player Handbook;Feature Reference Test

                    _toFormat = _toFormat.Replace("_feature", "");

                    //barbarian;Rage;Player Handbook;Feature Reference Test

                    string _useName = string.Empty;

                    if (!string.IsNullOrEmpty(_toFormat.Split(';')[3]))
                    {
                        _useName = _toFormat.Split(';')[3];
                    }
                    else
                    {
                        _useName = _toFormat.Split(';')[1];
                    }

                    _toFormat = string.Format("<link class=\"reference_classfeature\" recordname=\"reference.classdata.{0}.features.{1}@{2}\">{3}</link>",
                        _toFormat.Split(';')[0].ToLower().Trim(),
                        _toFormat.Split(';')[1].ToLower().Replace(" ", "").Trim(),
                        _toFormat.Split(';')[2].Trim(),
                        _useName.Trim());
                }

                //<link class="imagewindow" recordname="image.img_clericfullaart_jpg@Player Handbook">TESTING</link>
                else if (_toFormat.Contains("image"))
                {
                    //#zal;image;ClericFullAart.jpg;Player Handbook;Cleric Art

                    _toFormat = _toFormat.Replace("image;", "");

                    //ClericFullAart.jpg;Player Handbook;Cleric Art

                    string _useName = string.Empty;
                    if (!string.IsNullOrEmpty(_toFormat.Split(';')[2]))
                    {
                        _useName = _toFormat.Split(';')[2];
                    }
                    else
                    {
                        _useName = _toFormat.Split(';')[0];
                    }

                    _toFormat = string.Format("<link class=\"imagewindow\" recordname=\"image.{0}@{1}\">{2}</link>",
                        string.Format("{0}", _toFormat.Split(';')[0].Replace(".", "_").ToLower().Trim()),
                        _toFormat.Split(';')[1].Trim(),
                        _useName
                        );
                }

                //<link class="reference_colindex" recordname="reference.spelllists.thearchfey@Player Handbook">TESTING</link>
                else if (_toFormat.Contains("spellslist"))
                {
                    //#zal;spellslist;Cleric;DD5E SRD Data;Spell List Test

                    _toFormat = _toFormat.Replace("spellslist;", "");

                    //Cleric;DD5E SRD Data;Spell List Test

                    string _useName = string.Empty;
                    if (!string.IsNullOrEmpty(_toFormat.Split(';')[2]))
                    {
                        _useName = _toFormat.Split(';')[2];
                    }
                    else
                    {
                        _useName = _toFormat.Split(';')[0];
                    }

                    _toFormat = string.Format("<link class=\"reference_colindex\" recordname=\"reference.spelllists.{0}@{1}\">{2}</link>",
                        string.Format("{0}", _toFormat.Split(';')[0].Replace(" ", "").ToLower().Trim()),
                        _toFormat.Split(';')[1].Trim(),
                        _useName
                        );
                }

                //<link class="reference_spell" recordname="reference.spelldata.guidance@DD5E SRD Data">TESTING</link>
                else if (_toFormat.Contains("spell"))
                {
                    //#zal;spell;Guidance;DD5E SRD Data;Spell Test

                    _toFormat = _toFormat.Replace("spell;", "");

                    //Guidance;DD5E SRD Data;Spell Test

                    string _useName = string.Empty;
                    if (!string.IsNullOrEmpty(_toFormat.Split(';')[2]))
                    {
                        _useName = _toFormat.Split(';')[2];
                    }
                    else
                    {
                        _useName = _toFormat.Split(';')[0];
                    }

                    _toFormat = string.Format("<link class=\"reference_spell\" recordname=\"reference.spelldata.{0}@{1}\">{2}</link>",
                        string.Format("{0}", _toFormat.Split(';')[0].Replace(" ", "").ToLower().Trim()),
                        _toFormat.Split(';')[1].Trim(),
                        _useName
                        );
                }
            }

            else if (_toFormat.Contains("#zle;"))
            {
                return "</listlink>";
            }
            else
            {
                _toFormat = string.Format("<p>{0}</p>", _toFormat);
            }

            return _toFormat;
        }
    }
}

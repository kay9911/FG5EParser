using FG5EParser_v_2._0.Base_Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FG5EParser_v_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Default Inits 

            #region CLASS
            cmb_Class_Archtype_Selector.Items.Clear();
            cmb_Class_Archtype_Selector.Items.Add("");
            #endregion
        }

        List<ClassFeatures> _featureList = new List<ClassFeatures>();
        List<ClassAbilities> _abilityList = new List<ClassAbilities>();

        private void btn_Class_Add_List_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _sb = new StringBuilder();

            _sb.Append(string.Format("##;{0}",txt_Class_Name.Text.Trim()));
            _sb.Append(Environment.NewLine);

            // Description
            _sb.Append(new TextRange(rtc_Class_Description.Document.ContentStart, rtc_Class_Description.Document.ContentEnd).Text);
            //_sb.Append(Environment.NewLine);

            // Hit Points
            _sb.Append("Hit Points");
            _sb.Append(Environment.NewLine);
            _sb.Append(string.Format("Hit Dice: {0}",txt_Class_HitDice.Text.Trim()));
            _sb.Append(Environment.NewLine);
            _sb.Append(string.Format("Hit Points at 1st Level: {0}", txt_Class_HP_First.Text.Trim()));
            _sb.Append(Environment.NewLine);
            _sb.Append(string.Format("Hit Points at Higher Levels: {0}", txt_Class_HP_After_First.Text.Trim()));
            _sb.Append(Environment.NewLine);

            // Profs
            _sb.Append("Proficiencies");
            _sb.Append(Environment.NewLine);
            _sb.Append(string.Format("Armor: {0}", txt_Class_Armor.Text.Trim()));
            _sb.Append(Environment.NewLine);
            _sb.Append(string.Format("Weapons: {0}", txt_Class_Weapons.Text.Trim()));
            _sb.Append(Environment.NewLine);
            _sb.Append(string.Format("Tools: {0}", txt_Class_Tools.Text.Trim()));
            _sb.Append(Environment.NewLine);
            _sb.Append(string.Format("Saving Throws: {0}", txt_Class_SavingThrows.Text.Trim()));
            _sb.Append(Environment.NewLine);
            _sb.Append(string.Format("Skills: {0}", txt_Class_Skills.Text.Trim()));
            _sb.Append(Environment.NewLine);
            _sb.Append("Equipment");
            _sb.Append(Environment.NewLine);
            _sb.Append(new TextRange(rtc_Class_Starting_Equipment.Document.ContentStart, rtc_Class_Starting_Equipment.Document.ContentEnd).Text);
            //_sb.Append(Environment.NewLine);

            // Features
            foreach (ClassFeatures _feature in _featureList)
            {
                // We only want the class features here not the archtype based ones
                if (string.IsNullOrEmpty(_feature.UnderArchtype))
                {
                    _sb.Append(string.Format("#fe;{0};{1}", _feature.FeatureName, _feature.FeatureLevels));
                    _sb.Append(Environment.NewLine);
                    _sb.Append(_feature.FeatureDescription);
                    //_sb.Append(Environment.NewLine);
                }
            }

            // Abilities
            _sb.Append(Environment.NewLine);
            _sb.Append(string.Format("#abh;{0}",txt_Class_Archtype_Name.Text.Trim()));
            _sb.Append(Environment.NewLine);

            foreach (ClassAbilities _ability in _abilityList)
            {
                _sb.Append(string.Format("#ab;{0}",_ability.AbilityName));
                _sb.Append(Environment.NewLine);
                _sb.Append(_ability.AbilityDescription);

                foreach (ClassFeatures _feature in _featureList)
                {
                    if (_feature.UnderArchtype == _ability.AbilityName)
                    {
                        _sb.Append(string.Format("#abf;{0};{1}",_feature.FeatureName,_feature.FeatureLevels));
                        _sb.Append(Environment.NewLine);
                        _sb.Append(_feature.FeatureDescription);                        
                    }
                }
            }

            // Add this to the text file
            if (String.IsNullOrEmpty(txt_Path_Class.Text))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;

                if (choofdlog.ShowDialog() == true)
                {
                    txt_Path_Class.Text = choofdlog.FileName;
                }
            }
            else
            {
                TextWriter tsw = new StreamWriter(txt_Path_Class.Text, true);

                tsw.WriteLine(Environment.NewLine);

                _sb.Replace("..", ".");

                tsw.WriteLine(_sb.ToString().Replace("  ", " "));

                tsw.Close();

                // Reset all fields back to defaults




                MessageBox.Show("Class added to text file successfully.");
            }
        }

        private void btn_Class_Feature_Add_Click(object sender, RoutedEventArgs e)
        {
            ClassFeatures _classFeature = new ClassFeatures();

            _classFeature.FeatureName = txt_Class_Feature_Name.Text.Trim();
            _classFeature.FeatureLevels = txt_Class_Feature_Level.Text.Trim();
            if ((bool)chk_Class_isArchtype.IsChecked)
            {
                _classFeature.FeatureDescription = new TextRange(rtc_Class_Feature_Description.Document.ContentStart, rtc_Class_Feature_Description.Document.ContentEnd).Text + "#archtype;";
                _classFeature.isArchtypeHeader = true;
            }
            else
                _classFeature.FeatureDescription = new TextRange(rtc_Class_Feature_Description.Document.ContentStart, rtc_Class_Feature_Description.Document.ContentEnd).Text;

            _featureList.Add(_classFeature);

            txt_Class_Feature_Name.Text = string.Empty;
            txt_Class_Feature_Level.Text = string.Empty;
            rtc_Class_Feature_Description.Document.Blocks.Clear();
            chk_Class_isArchtype.IsChecked = false;
        }

        private void btn_Class_Archtype_Add_Click(object sender, RoutedEventArgs e)
        {
            ClassAbilities _ability = new ClassAbilities();

            _ability.AbilityName = txt_Class_Archtype_Path_Name.Text.Trim();
            _ability.AbilityDescription = new TextRange(rtc_Class_Archtype_Description.Document.ContentStart, rtc_Class_Archtype_Description.Document.ContentEnd).Text;

            _abilityList.Add(_ability);
            cmb_Class_Archtype_Selector.Items.Add(txt_Class_Archtype_Path_Name.Text.Trim());

            txt_Class_Archtype_Path_Name.Text = string.Empty;
            rtc_Class_Archtype_Description.Document.Blocks.Clear();
        }

        private void btn_Class_Archtype_Feature_Add_Click(object sender, RoutedEventArgs e)
        {
            ClassFeatures _classFeature = new ClassFeatures();

            _classFeature.FeatureName = txt_Class_Archtype_Feature_Name.Text.Trim();
            _classFeature.FeatureLevels = txt_Class_Archtype_Feature_Levels.Text.Trim();
            _classFeature.FeatureDescription = new TextRange(rtc_Class_Archtype_Feature_Description.Document.ContentStart, rtc_Class_Archtype_Feature_Description.Document.ContentEnd).Text;
            // Extra addition
            _classFeature.UnderArchtype = cmb_Class_Archtype_Selector.SelectedValue.ToString();

            _featureList.Add(_classFeature);

            txt_Class_Archtype_Feature_Name.Text = string.Empty;
            txt_Class_Archtype_Feature_Levels.Text = string.Empty;
            rtc_Class_Archtype_Feature_Description.Document.Blocks.Clear();
        }

        private void btn_Path_Add_Class_Click(object sender, RoutedEventArgs e)
        {
            // Process for opening and choosing where the info gets saved too

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;

            if (choofdlog.ShowDialog() == true)
            {
                txt_Path_Class.Text = choofdlog.FileName;
            }
        }
    }
}

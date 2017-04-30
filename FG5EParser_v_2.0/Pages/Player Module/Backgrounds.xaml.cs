using FG5eParserLib.View_Mo.dels;
using System;
using System.Collections.Generic;
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

namespace FG5EParser_v_2._0.Pages.Player_Module
{
    /// <summary>
    /// Interaction logic for Backgrounds.xaml
    /// </summary>
    public partial class Backgrounds : Page
    {
        public Backgrounds()
        {
            InitializeComponent();
        }

        //private void CollectData(object sender, TextChangedEventArgs e)
        //{
        //    StringBuilder _sb = new StringBuilder();

        //    // Name
        //    _sb.Append(string.Format("##;{0}", txtBackgroundName.Text.Trim()));
        //    _sb.Append(Environment.NewLine);

        //    // Desc
        //    _sb.Append(new TextRange(rtbBackgroundDescription.Document.ContentStart, rtbBackgroundDescription.Document.ContentEnd).Text);
        //    _sb.Append(Environment.NewLine);

        //    //Skill Proficiencies: Insight, Religion
        //    _sb.Append(string.Format("Skill Proficiencies: {0}", txtSkillProficiencies.Text.Trim()));
        //    _sb.Append(Environment.NewLine);

        //    //Tool Proficiencies: Insight, Religion
        //    _sb.Append(string.Format("Tool Proficiencies: {0}", txtToolProficiencies.Text.Trim()));
        //    _sb.Append(Environment.NewLine);

        //    //Languages: Two of your choice 
        //    _sb.Append(string.Format("Languages: {0}", txtLanguages.Text.Trim()));
        //    _sb.Append(Environment.NewLine);

        //    //Equipment:
        //    _sb.Append(string.Format("Equipment: {0}", txtEquipment.Text.Trim()));
        //    _sb.Append(Environment.NewLine);

        //    //Feature:
        //    _sb.Append(string.Format("Feature: {0}", txtFeatureName.Text.Trim()));
        //    _sb.Append(Environment.NewLine);

        //    // Desc
        //    _sb.Append(new TextRange(rtbFeatureDescription.Document.ContentStart, rtbFeatureDescription.Document.ContentEnd).Text);
        //    _sb.Append(Environment.NewLine);

        //    // Suggested
        //    _sb.Append(new TextRange(rtbSuggestedChar.Document.ContentStart, rtbSuggestedChar.Document.ContentEnd).Text);
        //    _sb.Append(Environment.NewLine);

        //    rtbOutput.Document.Blocks.Clear();
        //    rtbOutput.Document.Blocks.Add(new Paragraph(new Run(_sb.ToString())));
        //}
    }
}

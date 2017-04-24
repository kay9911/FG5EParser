using FG5EParser.Utilities;
using FG5eParserModels.Utility_Modules;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace FG5eParserLib.View_Models
{
    public class PathViewModel
    {
        public RelayCommand ParseCommand { get; set; }

        public Paths pathViewModel { get; set; }

        public PathViewModel()
        {
            ParseCommand = new RelayCommand(Parse,CanParse);
            pathViewModel = new Paths();

            //pathViewModel = new Paths() { SetBackgroundPath = "Something" } ;
        }

        public void Parse(object _obj)
        {
            // Initiate parser here
            XMLParser _xml = new XMLParser();

            try
            {
                _xml.ParseXMLs(
                    pathViewModel.SetCatalogueName,
                    pathViewModel.SetModuleName,
                    pathViewModel.SetAuthorName,
                    pathViewModel.SetOutputPath,
                    pathViewModel.SetImagePath,
                    pathViewModel.SetOuputChecked,
                    pathViewModel.SetDMOnlyChecked,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    pathViewModel.SetBackgroundPath,
                    null
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Parser failed with the following error: " + ex.InnerException);
            }
        }

        public bool CanParse(object _obj)
        {
            if (string.IsNullOrEmpty((string)_obj))
            {
                return false;
            }
            else
                return true;
        }
    }
}

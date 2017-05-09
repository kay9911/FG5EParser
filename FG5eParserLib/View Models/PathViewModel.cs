using FG5EParser.Utilities;
using FG5eParserModels.Utility_Modules;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace FG5eParserLib.View_Models
{
    public class PathViewModel
    {
        //properties
        public RelayCommand ParseCommand { get; set; }
        public Paths pathViewModel { get; set; }

        // Constructors
        public PathViewModel()
        {
            ParseCommand = new RelayCommand(Parse,CanParse);
            pathViewModel = new Paths();
        }

        // Functions
        private void Parse(object _obj)
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
                    pathViewModel.SetClassesPath,
                    null,
                    pathViewModel.SetEquipmentPath,
                    null,
                    null,
                    null,
                    pathViewModel.SetTablesPath,
                    pathViewModel.SetBackgroundPath,
                    null
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Parser failed with the following error: " + ex.InnerException);
            }
        }

        private bool CanParse(object _obj)
        {
            // TO DO: Validation Logic
            return true;
        }
    }
}

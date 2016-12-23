using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FG5EParser.User_Controls;
using FG5EParser.User_Controls.NPC_Controls;
using FG5EParser.Utilities;
using FG5EParser.User_Controls.Class_Controls;

namespace FG5EParser
{
    public partial class LandingPage : Form
    {
        #region PROPERTIES
        public string sendNPCStatBlocks {
            get { return getAllStatBlocks(); }
        }

        public string sendClassBlocks
        {
            get { return getAllClassBlocks(); }
        }

        public LandingPage npc_name {
            get { return _stats.allowUse; }
        }

        public string setNPCPath {
            set { _setPaths.SetNPCPath = value; }
        }

        public string setClassPath
        {
            set { _setPaths.SetClassPath = value; }
        }
        #endregion

        public LandingPage()
        {
            InitializeComponent();

            #region INSTACE PASSING

            this._stats.allowUse = this;
            this._actions.allowUse = this;
            this._innateSpellcasting.allowUse = this;
            this._spellcasting.allowUse = this;
            this._npcButtons.LandingPageallowuse = this;

            this._classBasics.allowUse = this;
            this._classDescription.allowUse = this;
            this._classFeatures.allowUse = this;
            this._classAbilities.allowUse = this;
            this._classButtons.LandingPageallowuse = this;

            #endregion
        }

        #region  INIT USER CONTROLS

        #region CLASS
        Class_Basics _classBasics = new Class_Basics();
        Class_Description _classDescription = new Class_Description();
        Class_Features _classFeatures = new Class_Features();
        Class_Abilities _classAbilities = new Class_Abilities();
        Class_Buttons _classButtons = new Class_Buttons();
        #endregion

        #region NPCS
        SetPaths _setPaths = new SetPaths();
        NPC_Spellcasting _spellcasting = new NPC_Spellcasting();
        NPC_Innate_Spellcasting _innateSpellcasting = new NPC_Innate_Spellcasting();
        NPC_Actions _actions = new NPC_Actions();
        NPC_Stats _stats = new NPC_Stats();
        NPC_Buttons _npcButtons = new NPC_Buttons();
        #endregion

        // TEST
        KeyValuePairViewer _keyValuePairViewer = new KeyValuePairViewer();

        #endregion

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            #region Hide all User Controls

            _setPaths.Hide();
            _stats.Hide();
            _spellcasting.Hide();
            _innateSpellcasting.Hide();
            _actions.Hide();
            _npcButtons.Hide();

            _classBasics.Hide();
            _classDescription.Hide();
            _classFeatures.Hide();
            _classAbilities.Hide();
            _classButtons.Hide();

            _keyValuePairViewer.Hide();

            #endregion

            if (e.Node.Name == "_startHere")
            {
                e.Node.Expand();
            }

            if (e.Node.Name == "_test")
            {
                pnlMain.Controls.Add(_keyValuePairViewer);
                _keyValuePairViewer.Show();
            }

            if (e.Node.Name == "_NPC")
            {
                e.Node.Expand();
            }

            if (treeView1.SelectedNode.Name == "_setPath")
            {
                pnlMain.Controls.Add(_setPaths);
                _setPaths.Show();
            }

            #region CLASS USER CONTROLS

            if (treeView1.SelectedNode.Name == "_hpproff" || treeView1.SelectedNode.Name == "_classDescriptions" || treeView1.SelectedNode.Name == "_features" ||
                treeView1.SelectedNode.Name == "_Class" || treeView1.SelectedNode.Name == "_abilities")
            {
                pnlMainButtons.Controls.Add(_classButtons);
                _classButtons.Show();
            }

            if (treeView1.SelectedNode.Name == "_hpproff")
            {
                pnlMain.Controls.Add(_classBasics);
                _classBasics.Show();

                rtcDisplay.Text = _classBasics.exposeClassName + _classBasics.exposeClassBasics;
            }

            if (treeView1.SelectedNode.Name == "_classDescriptions")
            {
                pnlMain.Controls.Add(_classDescription);
                _classDescription.Show();

                rtcDisplay.Text = _classDescription.exposeClassDescriptions;
            }

            if (treeView1.SelectedNode.Name == "_features")
            {
                pnlMain.Controls.Add(_classFeatures);
                _classFeatures.Show();

                rtcDisplay.Text = _classFeatures.exposeFeatures;
            }

            if (treeView1.SelectedNode.Name == "_Class")
            {
                e.Node.Expand();

                pnlMain.Controls.Add(_classBasics);
                _classBasics.Show();

                pnlMain.Controls.Add(_classDescription);
                _classDescription.Show();

                pnlMain.Controls.Add(_classFeatures);
                _classFeatures.Show();

                pnlMain.Controls.Add(_classAbilities);
                _classAbilities.Show();

                string _checkIfEmpty = string.Empty;

                if (!string.IsNullOrEmpty(_classDescription.exposeClassDescriptions))
                {
                    _checkIfEmpty = _classDescription.exposeClassDescriptions;
                }
                else
                {
                    _checkIfEmpty = "#h;Class Features";
                }

                // Display all text blocks at the same time
                rtcDisplay.Text = string.Format("{0}{1}{2}"
                    , _classBasics.exposeClassBasics.Replace("#de;",_checkIfEmpty)
                    , _classFeatures.exposeFeatures
                    , _classAbilities.exposeAbilities
                    );
            }

            if (treeView1.SelectedNode.Name == "_abilities")
            {
                pnlMain.Controls.Add(_classAbilities);
                _classAbilities.Show();
            }

            #endregion

            #region NPC USER CONTROLS

            if (treeView1.SelectedNode.Name == "_NPC" || treeView1.SelectedNode.Name == "_stats" || treeView1.SelectedNode.Name == "_actions" ||
                treeView1.SelectedNode.Name == "_innate_spellcasting" || treeView1.SelectedNode.Name == "_spellcasting")
            {
                pnlMainButtons.Controls.Add(_npcButtons);
                _npcButtons.Show();
            }

            if (treeView1.SelectedNode.Name == "_NPC")
            {
                pnlMain.Controls.Add(_stats);
                _stats.Show();

                pnlMain.Controls.Add(_actions);
                _actions.Show();

                pnlMain.Controls.Add(_innateSpellcasting);
                _innateSpellcasting.Show();

                pnlMain.Controls.Add(_spellcasting);
                _spellcasting.Show();

                // Display all text blocks at the same time
                rtcDisplay.Text = _stats.exposeStats + _innateSpellcasting.exposeInnateSpellcasting + _spellcasting.exposeSpellCasting + _actions.exposeActions;
            }

            if (treeView1.SelectedNode.Name == "_stats")
            {
                pnlMain.Controls.Add(_stats);
                _stats.Show();
                rtcDisplay.Text = _stats.exposeStats;
            }

            if (treeView1.SelectedNode.Name == "_actions")
            {
                pnlMain.Controls.Add(_actions);
                _actions.Show();
                rtcDisplay.Text = _actions.exposeActions;
            }

            if (treeView1.SelectedNode.Name == "_innate_spellcasting")
            {
                pnlMain.Controls.Add(_innateSpellcasting);
                _innateSpellcasting.Show();
                rtcDisplay.Text = _innateSpellcasting.exposeInnateSpellcasting;
            }

            if (treeView1.SelectedNode.Name == "_spellcasting")
            {
                pnlMain.Controls.Add(_spellcasting);
                _spellcasting.Show();
                rtcDisplay.Text = _spellcasting.exposeSpellCasting;
            }

            #endregion
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_setPaths.ModuleName))
                {
                    if (!string.IsNullOrEmpty(_setPaths.OutputText) || _setPaths.UseInstalledPath == true)
                    {
                        XMLParser _xmlParser = new XMLParser();

                        // Pass all paths for processing
                        _xmlParser.ParseXMLs(
                            _setPaths.CatalogueName
                            , _setPaths.ModuleName
                            , _setPaths.AuthorName
                            , _setPaths.OutputText
                            , _setPaths.ImagePath
                            , _setPaths.UseInstalledPath
                            , _setPaths.ForDMOnly
                            , _setPaths.SetNPCPath
                            , _setPaths.SetClassPath
                            , _setPaths.SetStoryPath
                            , _setPaths.SetItemPath
                            , _setPaths.SetMagicalItemPath
                            , _setPaths.SetEncounterPath
                            , _setPaths.SetParcelPath
                            , _setPaths.SetTablePath
                            );

                        MessageBox.Show("Parsing done!");
                    }
                    else
                    {
                        MessageBox.Show("An output path is mandatory, please select a path for the parsed modules to go to or else check the \"Use Installed Path\" checkbox to have them directly delivered to your modules folder");
                    }
                }
                else
                {
                    MessageBox.Show("A module name is mandatory, as references are depenedent on it.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong :c " + ex.Message);
            }
        }

        public string getAllStatBlocks()
        {
            return _stats.exposeStats + _innateSpellcasting.exposeInnateSpellcasting + _spellcasting.exposeSpellCasting + _actions.exposeActions;
        }

        public string getAllClassBlocks()
        {
            string _checkIfEmpty = string.Empty;

            if (!string.IsNullOrEmpty(_classDescription.exposeClassDescriptions))
            {
                _checkIfEmpty = _classDescription.exposeClassDescriptions;
            }
            else
            {
                _checkIfEmpty = "#h;Class Features";
            }

            // Display all text blocks at the same time
            return string.Format("{0}{1}{2}"
                , _classBasics.exposeClassBasics.Replace("#de;", _checkIfEmpty)
                , _classFeatures.exposeFeatures
                , _classAbilities.exposeAbilities
                );
        }

        #region REFRESH FUNCTIONS

        #region NPC REFRESH FUNCTIONS
        public void RefreshNPCStats()
        {
            // Send blank test, it will run doCompile();
            _stats.exposeStats = "";

            // Text Boxes
            _stats.resettxtName = string.Empty;
            _stats.resettxtSizeTypeAlignment = string.Empty;
            _stats.resettxtAC = string.Empty;
            _stats.resettxtHP = string.Empty;
            _stats.resettxtSpeed = string.Empty;
            _stats.resettxtSpeed = string.Empty;
            _stats.resettxttxtSkills = string.Empty;
            _stats.resettxtSenses = string.Empty;
            _stats.resettxtLanguages = string.Empty;
            _stats.resettxtChallenge = string.Empty;
            _stats.resettxtSavingThrows = string.Empty;

            // Stat blocks
            _stats.resettxtSTR = "10";
            _stats.resettxtDEX = "10";
            _stats.resettxtCON = "10";
            _stats.resettxtINT = "10";
            _stats.resettxtWIS = "10";
            _stats.resettxtCHR = "10";

            // Abilities
            _stats.resettxtAbilities = "";

            // Res/Vul
            _stats.resettxtDMGVUL = string.Empty;
            _stats.resettxtDMGRES = string.Empty;
            _stats.resettxtDMGIMM = string.Empty;
            _stats.resettxtCONIMM = string.Empty;
        }

        public void RefreshNPCInnateSpellcasting()
        {
            _innateSpellcasting.resettxtAbilityText = string.Empty;
            _innateSpellcasting.resettxtatwill = string.Empty;
            _innateSpellcasting.resettxtone = string.Empty;
            _innateSpellcasting.resettxttwo = string.Empty;
            _innateSpellcasting.resettxtthree = string.Empty;
            _innateSpellcasting.resettxtfour = string.Empty;
            _innateSpellcasting.resettxtfive = string.Empty;
            _innateSpellcasting.resettxtInnateSaveDc = string.Empty;
            _innateSpellcasting.resetAbilityDropcmbInnateSpellCasting = 0;
        }

        public void RefreshNPCSpellcasting()
        {
            // Combo Boxes
            _spellcasting.resetcmbSpellCastingAbility = 0;
            _spellcasting.resetcmbcomboBox1 = 0;
            _spellcasting.resetcmbcomboBox2 = 0;
            _spellcasting.resetcmbcomboBox3 = 0;
            _spellcasting.resetcmbcomboBox4 = 0;
            _spellcasting.resetcmbcomboBox5 = 0;
            _spellcasting.resetcmbcomboBox6 = 0;
            _spellcasting.resetcmbcomboBox7 = 0;
            _spellcasting.resetcmbcomboBox8 = 0;
            _spellcasting.resetcmbcomboBox9 = 0;

            // Text boxes
            _spellcasting.resettxtSpellAbilityText = string.Empty;
            _spellcasting.resettxtSpellHit = string.Empty;
            _spellcasting.resettxtSpellSave = string.Empty;

            _spellcasting.resettxtCantrips = string.Empty;
            _spellcasting.resettxtFirstLevel = string.Empty;
            _spellcasting.resettxtSecondLevel = string.Empty;
            _spellcasting.resettxtThirdLevel = string.Empty;
            _spellcasting.resettxtFourthLevel = string.Empty;
            _spellcasting.resettxtFifthLevel = string.Empty;      
            _spellcasting.resettxtSixthLevel = string.Empty;
            _spellcasting.resettxtSeventhLevel = string.Empty;
            _spellcasting.resettxtEightLevel = string.Empty;
            _spellcasting.resettxtNinthLevel = string.Empty;
        }

        public void RefreshNPCActions()
        {
            _actions.resettxtACTIONS = "";
            _actions.resettxtREACTIONS = "";
            _actions.resettxtLEGENDARYACTIONS = "";
            _actions.resettxtNPCDetails = "";
        }
        #endregion

        public void RefreshClassBasics()
        {
            _classBasics.resetTextBoxes = "1";
        }

        public void RefreshClassAbilities()
        {
            _classAbilities.resetTextBoxes = "1";
        }

        public void RefreshClassDescription()
        {
            _classDescription.resetTextBoxes = "1";
        }

        public void RefreshClassFeatures()
        {
            _classFeatures.resetTextBoxes = "1";
        }

        #endregion

        public string sendNPCPath()
        {
            return _setPaths.SetNPCPath;
        }

        public string sendClassPath()
        {
            return _setPaths.SetClassPath;
        }

        public bool sendNPCisready()
        {
            return _stats.isready;
        }

        public bool sendClassisReady()
        {
            // TO DO : Still needs implementation
            return true;
        }
    }
}

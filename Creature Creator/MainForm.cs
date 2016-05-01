using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace Creature_Creator
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			
			txtSTR.Text = "10";
			txtDEX.Text = "10";
			txtCON.Text = "10";
			txtINT.Text = "10";
			txtWIS.Text = "10";
			txtCHR.Text = "10";
			
			BindSpellcastingAbilityNames();
			BindInnateSpellCastingAbilityNames();
			BindSpellSlots();
			doCompile();
		}
		
		// String Builders	
		StringBuilder _build = new StringBuilder();
		StringBuilder _buildabilities = new StringBuilder();
		List<KeyValuePair<string,string>> _ability = new List<KeyValuePair<string, string>>();
		
		StringBuilder _buildActions = new StringBuilder();
		List<KeyValuePair<string,string>> _action = new List<KeyValuePair<string, string>>();
		
		StringBuilder _buildLegends = new StringBuilder();
		List<KeyValuePair<string,string>> _legend = new List<KeyValuePair<string, string>>();
		
		// All okay flag
		bool _isOkay = true;

        // Class instance to use the regex features
        RegularExpressions _regex;
		
		// Is Spellcaster?
		bool _isSpellcaster = false;
		
		// Location for save file
		string _save = string.Empty;
		
		// Generic Function that would be called on all events
		private void doCompile()
		{
			// Clear Builder
			_build.Clear();
			
			// Start Building
			getName();
			getSizeTypeAlignment();
			getAC();
			getHP();
			getSpeed();
			getStats();
			getSavingThrows();
			getSkills();
			getDamageVul();
			getDamageRes();
			getDamageImm();
			getConditionImm();
			getSenses();
			getLanguages();
			getChallenge();
			
			// Get Abilities			
			_build.Append(_buildabilities.ToString());
			// Get Innate Spellcasting
			getInnateSpellcasting();
			// Get Spellcasting Details
			getSpellCastingMods();
			getSpellCasting();
			
			// Get Actions
			_build.Append(_buildActions.ToString());
			
			// Get Legendary Actions
			_build.Append(_buildLegends.ToString());
			
			// Some final formatting, its tiresome cathing all of these :S
			_build.Replace("..",".");
			_build.Replace(". .",".");
			_build.Replace(".  .",".");
			
			// Finally display
			richTextBox1.Text = _build.ToString();
		}
		
		private void getInnateSpellcasting()
		{			
			// Get the ability modifiers here
			
			if(cmbInnateSpellCasting.SelectedIndex != 0 && !string.IsNullOrEmpty(txtInnateSaveDc.Text))
			{
				_build.Append(Environment.NewLine);
				_build.Append("Innate Spellcasting.");
				_build.Append(Environment.NewLine);
				_build.Append(string.Format("The {2}'s spell casting ability is {0} (spell save DC {1}). ",cmbInnateSpellCasting.SelectedItem,
				                            !String.IsNullOrEmpty(txtInnateSaveDc.Text) ? txtInnateSaveDc.Text : "0",
				                             txtName.Text));
				
				if(!String.IsNullOrEmpty(txtAbilityText.Text))
				{
					_build.Append(string.Format("{0}",txtAbilityText.Text));
				}
								
				if(!string.IsNullOrEmpty(txtatwill.Text))
				{
					_build.Append("\\rAt will: " + txtatwill.Text.Trim());
				}
				
				if(!string.IsNullOrEmpty(txtone.Text))
				{
					_build.Append("\\r1/day each: " + txtone.Text.Trim());
				}
				
				if(!string.IsNullOrEmpty(txttwo.Text))
				{
					_build.Append("\\r2/day each: " + txttwo.Text.Trim());
				}
				
				if(!string.IsNullOrEmpty(txtthree.Text))
				{
					_build.Append("\\r3/day each: " + txtthree.Text.Trim());
				}
				
				if(!string.IsNullOrEmpty(txtfour.Text))
				{
					_build.Append("\\r4/day each: " + txtfour.Text.Trim());
				}
								
				if(!string.IsNullOrEmpty(txtfive.Text))
				{
					_build.Append("\\r5/day each: " + txtfive.Text.Trim());
				}
			}
		}
		
		private void getSpellCastingMods()
		{
			if(!string.IsNullOrEmpty(cmbSpellCastingAbility.SelectedItem.ToString()))
			{
				_build.Append(Environment.NewLine);
				_build.Append("Spellcasting.");
				_build.Append(Environment.NewLine);
				_build.Append(string.Format("Spellcasting ability is {0} (spell save DC {1}, +{2} to hit with spell attacks)",cmbSpellCastingAbility.SelectedItem,
				                            !String.IsNullOrEmpty(txtSpellSave.Text) ? txtSpellSave.Text : "0",
				                            !String.IsNullOrEmpty(txtSpellHit.Text) ? txtSpellHit.Text : "0"));
				_isSpellcaster = true;
			}
			else
			{				
				_isSpellcaster = false;
			}
		}
		
		private void getSpellCasting()
		{
			if (_isSpellcaster)
			{
				if(!string.IsNullOrEmpty(txtSpellAbilityText.Text))
				{
					_build.Append("\\r" + txtSpellAbilityText.Text.Trim().Replace(Environment.NewLine," "));
				}
						
				if(!string.IsNullOrEmpty(txtCantrips.Text))
				{
					_build.Append("\\rCantrips (At will): " + txtCantrips.Text.Trim());
				}
				
				if(!string.IsNullOrEmpty(txtFirstLevel.Text))
				{
					_build.Append(string.Format("\\r1st Level ({0}): {1}",comboBox1.SelectedItem,txtFirstLevel.Text.Trim()));
				}
				
				if(!string.IsNullOrEmpty(txtSecondLevel.Text))
				{
					_build.Append(string.Format("\\r2nd Level ({0}): {1}",comboBox2.SelectedItem,txtSecondLevel.Text.Trim()));
				}
				
				if(!string.IsNullOrEmpty(txtThirdLevel.Text))
				{
					_build.Append(string.Format("\\r3rd Level ({0}): {1}",comboBox3.SelectedItem,txtThirdLevel.Text.Trim()));
				}
				
				if(!string.IsNullOrEmpty(txtFourthLevel.Text))
				{
					_build.Append(string.Format("\\r4th Level ({0}): {1}",comboBox4.SelectedItem,txtFourthLevel.Text.Trim()));
				}
								
				if(!string.IsNullOrEmpty(txtFifthLevel.Text))
				{
					_build.Append(string.Format("\\r5th Level ({0}): {1}",comboBox5.SelectedItem,txtFifthLevel.Text.Trim()));					
				}
				
				if(!string.IsNullOrEmpty(txtSixthLevel.Text))
				{
					_build.Append(string.Format("\\r6th Level ({0}): {1}",comboBox6.SelectedItem,txtSixthLevel.Text.Trim()));					
				}
				
				if(!string.IsNullOrEmpty(txtSeventhLevel.Text))
				{
					_build.Append(string.Format("\\r7th Level ({0}): {1}",comboBox7.SelectedItem,txtSeventhLevel.Text.Trim()));
				}
				
				if(!string.IsNullOrEmpty(txtEightLevel.Text))
				{
					_build.Append(string.Format("\\r8th Level ({0}): {1}",comboBox8.SelectedItem,txtEightLevel.Text.Trim()));
				}
				
				if(!string.IsNullOrEmpty(txtNinthLevel.Text))
				{
					_build.Append(string.Format("\\r9th Level ({0}): {1}",comboBox9.SelectedItem,txtNinthLevel.Text.Trim()));
				}
			}
		}
		
		private void BindSpellcastingAbilityNames()
		{
			List<string> _statNames = new List<string>{"","Strength","Dexterity","Constitution","Intelligence","Wisdom","Charisma"};
			
			cmbSpellCastingAbility.DataSource = null;
			cmbSpellCastingAbility.Items.Clear();
			cmbSpellCastingAbility.DataSource = _statNames;
		}
		
		private void BindInnateSpellCastingAbilityNames()
		{
			List<string> _statNames = new List<string>{"","Strength","Dexterity","Constitution","Intelligence","Wisdom","Charisma"};
			
			cmbInnateSpellCasting.DataSource = null;
			cmbInnateSpellCasting.Items.Clear();
			cmbInnateSpellCasting.DataSource = _statNames;
		}
		
		private void BindSpellSlots()
		{
			List<string> _spellSlots = new List<string>{"1 slot","2 slots","3 slots","4 slots","5 slots","6 slots","7 slots","8 slots","9 slots"};
			List<string> _spellSlots2 = new List<string>{"1 slot","2 slots","3 slots","4 slots","5 slots","6 slots","7 slots","8 slots","9 slots"};
			List<string> _spellSlots3 = new List<string>{"1 slot","2 slots","3 slots","4 slots","5 slots","6 slots","7 slots","8 slots","9 slots"};
			List<string> _spellSlots4 = new List<string>{"1 slot","2 slots","3 slots","4 slots","5 slots","6 slots","7 slots","8 slots","9 slots"};
			List<string> _spellSlots5 = new List<string>{"1 slot","2 slots","3 slots","4 slots","5 slots","6 slots","7 slots","8 slots","9 slots"};
			List<string> _spellSlots6 = new List<string>{"1 slot","2 slots","3 slots","4 slots","5 slots","6 slots","7 slots","8 slots","9 slots"};
			List<string> _spellSlots7 = new List<string>{"1 slot","2 slots","3 slots","4 slots","5 slots","6 slots","7 slots","8 slots","9 slots"};
			List<string> _spellSlots8 = new List<string>{"1 slot","2 slots","3 slots","4 slots","5 slots","6 slots","7 slots","8 slots","9 slots"};
			List<string> _spellSlots9 = new List<string>{"1 slot","2 slots","3 slots","4 slots","5 slots","6 slots","7 slots","8 slots","9 slots"};
			
			comboBox1.DataSource = null;
			comboBox1.Items.Clear();
			comboBox1.DataSource = _spellSlots;
			
			comboBox2.DataSource = null;
			comboBox2.Items.Clear();
			comboBox2.DataSource = _spellSlots2;
			
			comboBox3.DataSource = null;
			comboBox3.Items.Clear();
			comboBox3.DataSource = _spellSlots3;
			
			comboBox4.DataSource = null;
			comboBox4.Items.Clear();
			comboBox4.DataSource = _spellSlots4;
			
			comboBox5.DataSource = null;
			comboBox5.Items.Clear();
			comboBox5.DataSource = _spellSlots5;
			
			comboBox6.DataSource = null;
			comboBox6.Items.Clear();
			comboBox6.DataSource = _spellSlots6;
			
			comboBox7.DataSource = null;
			comboBox7.Items.Clear();
			comboBox7.DataSource = _spellSlots7;
			
			comboBox8.DataSource = null;
			comboBox8.Items.Clear();
			comboBox8.DataSource = _spellSlots8;
			
			comboBox9.DataSource = null;
			comboBox9.Items.Clear();
			comboBox9.DataSource = _spellSlots9;			
		}
		
		private void getDamageVul()
		{
			if(!string.IsNullOrEmpty(txtDMGVUL.Text))
			{
				_build.Append(Environment.NewLine);
				_build.Append("Damage Vulnerabilities " + txtDMGVUL.Text.Trim().Replace(Environment.NewLine," "));
			}
		}
		
		private void getDamageImm()
		{
			if(!string.IsNullOrEmpty(txtDMGIMM.Text))
			{
				_build.Append(Environment.NewLine);
				_build.Append("Damage Immunities " + txtDMGIMM.Text.Trim().Replace(Environment.NewLine," "));
			}
		}
		
		private void getConditionImm()
		{
			if(!string.IsNullOrEmpty(txtCONIMM.Text))
			{
				_build.Append(Environment.NewLine);
				_build.Append("Condition Immunities " + txtCONIMM.Text.Trim().Replace(Environment.NewLine," "));
			}
		}
		
		private void getDamageRes()
		{
			if(!string.IsNullOrEmpty(txtDMGRES.Text))
			{
				_build.Append(Environment.NewLine);
				_build.Append("Damage Resistances " + txtDMGRES.Text.Trim().Replace(Environment.NewLine," "));
			}
		}
		
		private void getName()
		{
			if(string.IsNullOrEmpty(txtName.Text))
			{
				_build.Append("<Name Required>");
				_isOkay = false;
			}
			else
			{
				_build.Append(txtName.Text.Trim());
				_isOkay = true;
			}
		}
		
		private void getAC()
		{
			if(string.IsNullOrEmpty(txtAC.Text))
			{
				_build.Append(Environment.NewLine);
				_build.Append("<Armor Class Required>");
				_isOkay = false;
			}
			else
			{
				_build.Append(Environment.NewLine);
				_build.Append("Armor Class " + txtAC.Text.Trim());
				_isOkay = true;
			}
		}
		
		private void getSizeTypeAlignment()
		{
			if(string.IsNullOrEmpty(txtSizeTypeAlignment.Text))
			{
				_build.Append(Environment.NewLine);
				_build.Append("<Size Type, Alignment Required>");
				_isOkay = false;
			}
			else
			{
				_build.Append(Environment.NewLine);
				_build.Append(txtSizeTypeAlignment.Text.Trim());
				_isOkay = true;
			}
		}
		
		private void getHP()
		{
			if(string.IsNullOrEmpty(txtHP.Text))
			{
				_build.Append(Environment.NewLine);
				_build.Append("<Hit Points Required>");
				_isOkay = false;
			}
			else
			{
				_build.Append(Environment.NewLine);
				_build.Append("Hit Points " + txtHP.Text.Trim());
				_isOkay = true;
			}
		}
		
		private void getSpeed()
		{
			if(string.IsNullOrEmpty(txtSpeed.Text))
			{
				_build.Append(Environment.NewLine);
				_build.Append("<Speed Required>");
				_isOkay = false;
			}
			else
			{
                _build.Append(Environment.NewLine);

                // Check and match for each type of movement
                string _toAppend = string.Empty;

                if (txtSpeed.Text.Contains("ft."))
                {
                    _regex = new RegularExpressions();

                    string[] _speedtypes = txtSpeed.Text.Trim().Split('.');

                    for (int i = 0; i < _speedtypes.Length; i++)
                    {
                        if (!String.IsNullOrWhiteSpace(_speedtypes[i]))
                        {
                            if (i == 0)
                            {
                                _toAppend += string.Format("{0}.", _regex.getCorrectedSpeed(_speedtypes[i]));
                            }
                            else
                                _toAppend += string.Format(", {0}.", _regex.getCorrectedSpeed(_speedtypes[i].ToString()));
                        }
                    }
                }

                _build.Append("Speed " + _toAppend);
                _isOkay = true;
            }
		}
		
		private void getStats()
		{
			//STR
			string _str = !string.IsNullOrEmpty(txtSTR.Text) ? buildStats(txtSTR.Text) : buildStats("10");
			//DEX
			string _dex = !string.IsNullOrEmpty(txtDEX.Text) ? buildStats(txtDEX.Text) : buildStats("10");
			//CON
			string _con = !string.IsNullOrEmpty(txtCON.Text) ? buildStats(txtCON.Text) : buildStats("10");
			//INT
			string _int = !string.IsNullOrEmpty(txtINT.Text) ? buildStats(txtINT.Text) : buildStats("10");
			//WIS
			string _wis = !string.IsNullOrEmpty(txtWIS.Text) ? buildStats(txtWIS.Text) : buildStats("10");
			//CHR
			string _chr = !string.IsNullOrEmpty(txtCHR.Text) ? buildStats(txtCHR.Text) : buildStats("10");
			
			// Build final String
			
			_build.Append(Environment.NewLine);
			
			_build.Append("STR DEX CON INT WIS CHA ");
			
			string _format = string.Format("{0} ({1}) ",txtSTR.Text,_str);
			_build.Append(_format);
			
			_format = string.Format("{0} ({1}) ",txtDEX.Text,_dex);
			_build.Append(_format);

			
			_format = string.Format("{0} ({1}) ",txtCON.Text,_con);
			_build.Append(_format);

			
			_format = string.Format("{0} ({1}) ",txtINT.Text,_int);
			_build.Append(_format);

			
			_format = string.Format("{0} ({1}) ",txtWIS.Text,_wis);
			_build.Append(_format);

			
			_format = string.Format("{0} ({1})",txtCHR.Text,_chr);
			_build.Append(_format);

		}
		
		private string buildStats(string _val)
		{
			decimal _retVal = Math.Floor((Convert.ToDecimal(_val) - 10)/2);	

			string val = string.Empty;
			
			if(_retVal < 0)
			{
				val = Convert.ToString(_retVal);
			}
			else			
			val = string.Format("+{0}",Convert.ToString(_retVal));
			
			return val;
		}
		
		private void getSavingThrows()
		{
			if(string.IsNullOrEmpty(txtSavingThrows.Text))
			{
				// DO NOTHING
			}
			else
			{
				_build.Append(Environment.NewLine);
				_build.Append("Saving Throws " + txtSavingThrows.Text.Trim());
			}
		}
		
		private void getSkills()
		{
			if(string.IsNullOrEmpty(txtSkills.Text))
			{
				// DO NOTHING
			}
			else
			{
				_build.Append(Environment.NewLine);
				_build.Append("Skills " + txtSkills.Text.Trim());
			}
		}
		
		private void getSenses()
		{
			if(string.IsNullOrEmpty(txtSenses.Text))
			{
				_build.Append(Environment.NewLine);
				_build.Append("<Senses Required>");
				_isOkay = false;
			}
			else
			{
				_build.Append(Environment.NewLine);
				_build.Append("Senses " + txtSenses.Text.Trim());
			}
		}
		
		private void getLanguages()
		{			
			if(string.IsNullOrEmpty(txtLanguages.Text))
			{
				_build.Append(Environment.NewLine);
				_build.Append("<Language Required>");
				_isOkay = false;
			}
			else
			{
				_build.Append(Environment.NewLine);
				_build.Append("Languages " + txtLanguages.Text.Trim());
			}
		}
		
		private void getChallenge()
		{
			if(string.IsNullOrEmpty(txtChallenge.Text))
			{
				_build.Append(Environment.NewLine);
				_build.Append("<Challenge Required>");
				_isOkay = false;
			}
			else
			{
				_build.Append(Environment.NewLine);
				_build.Append("Challenge " + txtChallenge.Text.Trim());
				_isOkay = true;
			}
		}
		
		void BtnADDabilityClick(object sender, EventArgs e)
		{
			if(!string.IsNullOrEmpty(txtAbilities.Text))
			{
				if(txtAbilities.Text.Contains("."))
				{
					// Clear the builder
					_buildabilities.Clear();
					
					// Clear the line breaks
					string _clearLines = txtAbilities.Text.Trim().Replace(Environment.NewLine,"");
					
					// Split the string
					string[] _arr = _clearLines.Split('.');
					string _val = _returnString(_arr);
					
					// Insert into the keyvalue pair list
					_ability.Add(new KeyValuePair<string, string>(string.Format("{0}.",_arr[0].ToString()),_val));
					txtAbilities.Text = string.Empty;
					
					foreach(KeyValuePair<string,string> pair in _ability)
					{
						string _format = string.Format("{0}{1}",pair.Key.ToString(),pair.Value.ToString());
						_buildabilities.Append(Environment.NewLine);
						_buildabilities.Append(_format);
					}
					
					doCompile();
				}
				else
				{
					MessageBox.Show("Please make sure abilities are in this format : <Ability Name>. <Description>");
				}
			}
		}
		
		void BtnADDactionsClick(object sender, EventArgs e)
		{
			if(!string.IsNullOrEmpty(txtACTIONS.Text))
			{
				if(txtACTIONS.Text.Contains("."))
				{
					// Clear the builder
					_buildActions.Clear();
					_buildActions.Append(Environment.NewLine);
					_buildActions.Append("ACTIONS");
					
					// Clear the line breaks
					string _clearLines = txtACTIONS.Text.Trim().Replace(Environment.NewLine,"");
					
					// Split the string
					string[] _arr = _clearLines.Split('.');
					string _val = _returnString(_arr);
					
					// Insert into the keyvalue pair list
					_action.Add(new KeyValuePair<string, string>(string.Format("{0}.",_arr[0].ToString()),_val));
					txtACTIONS.Text = string.Empty;
					
					foreach(KeyValuePair<string,string> pair in _action)
					{
						string _format = string.Format("{0}{1}",pair.Key.ToString(),pair.Value.ToString());
						_buildActions.Append(Environment.NewLine);
						_buildActions.Append(_format);
					}
					
					doCompile();
				}
				else
				{
				    MessageBox.Show("Please make sure ACTIONS are in this format : <Action Name>. <Description>");
				}
			}
		}
		
		void BtnAbilityCheckClick(object sender, EventArgs e)
		{
			_buildabilities.Clear();
			_ability.Clear();
			doCompile();
		}
		
		void BtnActionsRefreshClick(object sender, EventArgs e)
		{
			_buildActions.Clear();
			_action.Clear();
			doCompile();
		}
		
		void BtnADDlegendaryClick(object sender, EventArgs e)
		{
			if(!string.IsNullOrEmpty(txtLEGENDARYACTIONS.Text))
			{
				if(txtLEGENDARYACTIONS.Text.Contains("."))
				{
					// Clear the builder
					_buildLegends.Clear();
					_buildLegends.Append(Environment.NewLine);
					_buildLegends.Append("LEGENDARY ACTIONS");
					
					// Clear the line breaks
					string _clearLines = txtLEGENDARYACTIONS.Text.Trim().Replace(Environment.NewLine,"");
					
					// Split the string
					string[] _arr = _clearLines.Split('.');
					
					string _val = _returnString(_arr);
					
					// Insert into the keyvalue pair list
					_legend.Add(new KeyValuePair<string, string>(string.Format("{0}.",_arr[0].ToString()),_val));
					txtLEGENDARYACTIONS.Text = string.Empty;
					
					foreach(KeyValuePair<string,string> pair in _legend)
					{
						string _format = string.Format("{0}{1}",pair.Key.ToString(),pair.Value.ToString());
						_buildLegends.Append(Environment.NewLine);
						_buildLegends.Append(_format);
					}
					
					doCompile();
				}
				else
				{
				    MessageBox.Show("Please make sure LEGENDARY ACTIONS are in this format : <Legendary Action>. <Description>");
				}
			}
		}
		
		void TxtRefreshLegendsClick(object sender, EventArgs e)
		{
			_buildLegends.Clear();
			_legend.Clear();
			doCompile();
		}

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_save))
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = true;

                if (choofdlog.ShowDialog() == DialogResult.OK)
                {
                    _save = choofdlog.FileName;
                    //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
                }
            }
        }

        void BtnAddtoListClick(object sender, EventArgs e)
		{
			if(String.IsNullOrEmpty(_save))
			{
				OpenFileDialog choofdlog = new OpenFileDialog();
				choofdlog.Filter = "All Files (*.*)|*.*";
				choofdlog.FilterIndex = 1;
				choofdlog.Multiselect = true;
				
				if (choofdlog.ShowDialog() == DialogResult.OK)    
				{     
				    _save = choofdlog.FileName; 
				    //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
				}
			}
			else
			{
				if(_isOkay)
				{				
					TextWriter tsw = new StreamWriter(_save, true);
					
					tsw.WriteLine(Environment.NewLine);
					
					// Replace '..' with '.'
					_build.Replace("..",".");
					
					tsw.WriteLine(_build.ToString().Replace("  "," "));					
					
					tsw.Close();
					
					RefreshAll();
				}
				else
					MessageBox.Show("Please check the information, you have some incorrect values");
			}
		}
		
		private string _returnString(String[] arr)
		{
			StringBuilder _retVal = new StringBuilder();		
			
			for (int i = 1; i < arr.Length; i++)
			{
				_retVal.Append(String.Format(" {0}.",arr[i].ToString().Trim()));
			}
			
			return _retVal.ToString();
		}
		
		private void RefreshAll()
		{
			// Clear builders
			_build.Clear();
			_buildabilities.Clear();
			_buildActions.Clear();
			_buildLegends.Clear();
			
			// Clear lists
			_ability.Clear();
			_action.Clear();
			_legend.Clear();
			
			// Clear text boxes
			txtName.Text = string.Empty;
			txtSizeTypeAlignment.Text = string.Empty;
			txtAC.Text = string.Empty;
			txtHP.Text = string.Empty;
			txtSpeed.Text = string.Empty;
			txtSkills.Text = string.Empty;
			txtSavingThrows.Text = string.Empty;
			txtSenses.Text = string.Empty;
			txtLanguages.Text = string.Empty;
			txtChallenge.Text = string.Empty;
			
			// Clear Innate Spellcasting
			cmbInnateSpellCasting.SelectedIndex = 0;
			txtInnateSaveDc.Text = string.Empty;
			txtAbilityText.Text = string.Empty;
			txtatwill.Text = string.Empty;
			txtone.Text = string.Empty;
			txttwo.Text = string.Empty;
			txtthree.Text = string.Empty;
			txtfour.Text = string.Empty;
			txtfive.Text = string.Empty;
			
			// Clear Res and Vul
			txtDMGVUL.Text = string.Empty;
			txtDMGRES.Text = string.Empty;
			txtCONIMM.Text = string.Empty;
			txtDMGIMM.Text = string.Empty;
			
			// Clear Spell Casting
			txtSpellAbilityText.Text = string.Empty;
			txtCantrips.Text = string.Empty;
			txtFirstLevel.Text = string.Empty;
			txtSecondLevel.Text = string.Empty;
			txtThirdLevel.Text = string.Empty;
			txtFourthLevel.Text = string.Empty;
			txtFifthLevel.Text = string.Empty;
			txtSixthLevel.Text = string.Empty;
			txtSeventhLevel.Text = string.Empty;
			txtEightLevel.Text = string.Empty;
			txtNinthLevel.Text = string.Empty;
			
			cmbSpellCastingAbility.SelectedIndex = 0;
			comboBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 0;
			comboBox3.SelectedIndex = 0;
			comboBox4.SelectedIndex = 0;
			comboBox5.SelectedIndex = 0;
			comboBox6.SelectedIndex = 0;
			comboBox7.SelectedIndex = 0;
			comboBox8.SelectedIndex = 0;
			comboBox9.SelectedIndex = 0;
			
			// Set stat blocks
			txtSTR.Text = "10";
			txtDEX.Text = "10";
			txtCON.Text = "10";
			txtINT.Text = "10";
			txtWIS.Text = "10";
			txtCHR.Text = "10";

            // Refresh the stats in the text area
            doCompile();
		}

		#region Button actions		
		
		void TxtNameTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtSizeTypeAlignmentTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtACTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtHPTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtSpeedTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtSTRLeave(object sender, EventArgs e)
		{
			if(String.IsNullOrEmpty(txtSTR.Text))
			{
				txtSTR.Text = "10";
				doCompile();
			}
			else
				doCompile();
		}
		void TxtDEXLeave(object sender, EventArgs e)
		{
			if(String.IsNullOrEmpty(txtDEX.Text))
			{
				txtDEX.Text = "10";
				doCompile();
			}
			else
				doCompile();
		}
		void TxtCONLeave(object sender, EventArgs e)
		{
			if(String.IsNullOrEmpty(txtCON.Text))
			{
				txtCON.Text = "10";
				doCompile();
			}
			else
				doCompile();
		}
		void TxtINTLeave(object sender, EventArgs e)
		{
			if(String.IsNullOrEmpty(txtINT.Text))
			{
				txtINT.Text = "10";
				doCompile();
			}
			else
				doCompile();
		}
		void TxtWISLeave(object sender, EventArgs e)
		{
			if(String.IsNullOrEmpty(txtWIS.Text))
			{
				txtWIS.Text = "10";
				doCompile();
			}
			else
				doCompile();
		}
		void TxtCHRLeave(object sender, EventArgs e)
		{
			if(String.IsNullOrEmpty(txtCHR.Text))
			{
				txtCHR.Text = "10";
				doCompile();
			}
			else
				doCompile();
		}
		
		void TxtSavingThrowsTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtSkillsTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtSensesTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtLanguagesTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtChallengeTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtSTREnter(object sender, EventArgs e)
		{
			txtSTR.Text = string.Empty;
		}
		void TxtDEXEnter(object sender, EventArgs e)
		{
			txtDEX.Text = string.Empty;
		}
		void TxtCONEnter(object sender, EventArgs e)
		{
			txtCON.Text = string.Empty;
		}
		void TxtINTEnter(object sender, EventArgs e)
		{
			txtINT.Text = string.Empty;
		}
		void TxtWISEnter(object sender, EventArgs e)
		{
			txtWIS.Text = string.Empty;
		}
		void TxtCHREnter(object sender, EventArgs e)
		{
			txtCHR.Text = string.Empty;
		}
		void TxtDMGVULTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtDMGRESTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtDMGIMMTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtCONIMMTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtAbilityTextTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtatwillTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtoneTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxttwoTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtthreeTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtfourTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtfiveTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtSpellAbilityTextTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtCantripsTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtFirstLevelTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtSecondLevelTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtThirdLevelTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtFourthLevelTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtFifthLevelTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtSixthLevelTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtSeventhLevelTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtEightLevelTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtNinthLevelTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void ComboBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void ComboBox3SelectedIndexChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void ComboBox4SelectedIndexChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void ComboBox5SelectedIndexChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void ComboBox6SelectedIndexChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void ComboBox7SelectedIndexChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void ComboBox8SelectedIndexChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void ComboBox9SelectedIndexChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void CmbSpellCastingAbilitySelectedIndexChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtSpellSaveTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtSpellHitTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void CmbInnateSpellCastingSelectedIndexChanged(object sender, EventArgs e)
		{
			doCompile();
		}
		void TxtInnateSaveDcTextChanged(object sender, EventArgs e)
		{
			doCompile();
		}

        #endregion


    }
}

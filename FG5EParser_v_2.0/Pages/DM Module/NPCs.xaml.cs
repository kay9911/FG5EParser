using FG5eParserLib.View_Models;
using System;
using System.Windows.Controls;

namespace FG5EParser_v_2._0.Pages.DM_Module
{
    /// <summary>
    /// Interaction logic for NPCs.xaml
    /// </summary>
    public partial class NPCs : Page
    {
        NPCViewModel _NVM;

        public NPCs()
        {
            InitializeComponent();

            _NVM = new NPCViewModel();
            DataContext = _NVM;

            #region DROPDOWNS            
            cmbNPCSize.ItemsSource = _NVM._npcSizes;
            cmbType.ItemsSource = _NVM._npcTypes;
            cmbSubType.ItemsSource = _NVM._npcSubTypes;
            cmbAlignment.ItemsSource = _NVM._npcAlignments;
            cmbSelectInnateModifier.ItemsSource = _NVM._attributes;
            cmbSelectSpellcastingModifier.ItemsSource = _NVM._attributes;

            cmbLevelOneSlots.ItemsSource = _NVM._spellSlots;
            cmbLevelTwoSlots.ItemsSource = _NVM._spellSlots;
            cmbLevelThreeSlots.ItemsSource = _NVM._spellSlots;
            cmbLevelFourSlots.ItemsSource = _NVM._spellSlots;
            cmbLevelFiveSlots.ItemsSource = _NVM._spellSlots;
            cmbLevelSixSlots.ItemsSource = _NVM._spellSlots;
            cmbLevelSevenSlots.ItemsSource = _NVM._spellSlots;
            cmbLevelEightSlots.ItemsSource = _NVM._spellSlots;
            cmbLevelNineSlots.ItemsSource = _NVM._spellSlots;
            #endregion
        }

        // Functions
        private string buildStats(string _val)
        {
            decimal _retVal = Math.Floor((Convert.ToDecimal(_val) - 10) / 2);

            string val = string.Empty;

            // 0 is neither - nor +
            if (_retVal == 0)
            {
                val = string.Format("{0}", Convert.ToString(_retVal));
            }
            else
            {
                if (_retVal < 0)
                {
                    val = string.Format("{0}", Convert.ToString(_retVal));
                }
                else
                    val = string.Format("+{0}", Convert.ToString(_retVal));
            }

            return val;
        }

        #region ATTRIBUTE TEXT BOX EVENTS
        private void txtSTR_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSTR.Text))
            {
                STR.Content = buildStats(txtSTR.Text.Trim());
            }
        }

        private void txtSTR_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSTR.Text))
            {
                txtSTR.Text = "0";
            }
        }

        private void txtSTR_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            txtSTR.Text = string.Empty;
        }

        private void txtDEX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDEX.Text))
            {
                DEX.Content = buildStats(txtDEX.Text.Trim());
            }
        }

        private void txtDEX_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDEX.Text))
            {
                txtDEX.Text = "0";
            }
        }

        private void txtDEX_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            txtDEX.Text = string.Empty;
        }

        private void txtCON_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCON.Text))
            {
                CON.Content = buildStats(txtCON.Text.Trim());
            }
        }

        private void txtCON_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCON.Text))
            {
                txtCON.Text = "0";
            }
        }

        private void txtCON_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            txtCON.Text = string.Empty;
        }

        private void txtINT_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtINT.Text))
            {
                INT.Content = buildStats(txtINT.Text.Trim());
            }
        }

        private void txtINT_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtINT.Text))
            {
                txtINT.Text = "0";
            }
        }

        private void txtINT_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            txtINT.Text = string.Empty;
        }

        private void txtWIS_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWIS.Text))
            {
                WIS.Content = buildStats(txtWIS.Text.Trim());
            }
        }

        private void txtWIS_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtWIS.Text))
            {
                txtWIS.Text = "0";
            }
        }

        private void txtWIS_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            txtWIS.Text = string.Empty;
        }

        private void txtCHR_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCHR.Text))
            {
                CHR.Content = buildStats(txtCHR.Text.Trim());
            }
        }

        private void txtCHR_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCHR.Text))
            {
                txtCHR.Text = "0";
            }
        }

        private void txtCHR_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            txtCHR.Text = string.Empty;
        }
        #endregion
    }
}

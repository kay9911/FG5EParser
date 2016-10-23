using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FG5EParser.User_Controls.NPC_Controls
{
    public partial class NPC_Spellcasting : UserControl
    {
        public NPC_Spellcasting()
        {
            InitializeComponent();
            BindSpellcastingAbilityNames();
            BindSpellSlots();
        }

        private void BindSpellcastingAbilityNames()
        {
            List<string> _statNames = new List<string> { "", "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };

            cmbSpellCastingAbility.DataSource = null;
            cmbSpellCastingAbility.Items.Clear();
            cmbSpellCastingAbility.DataSource = _statNames;
        }

        private void BindSpellSlots()
        {
            List<string> _spellSlots = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots2 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots3 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots4 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots5 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots6 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots7 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots8 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };
            List<string> _spellSlots9 = new List<string> { "1 slot", "2 slots", "3 slots", "4 slots", "5 slots", "6 slots", "7 slots", "8 slots", "9 slots" };

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
    }
}

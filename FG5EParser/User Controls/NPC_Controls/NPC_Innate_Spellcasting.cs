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
    public partial class NPC_Innate_Spellcasting : UserControl
    {
        public NPC_Innate_Spellcasting()
        {
            InitializeComponent();
            BindInnateSpellCastingAbilityNames();
        }

        private void BindInnateSpellCastingAbilityNames()
        {
            List<string> _statNames = new List<string> { "", "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };

            cmbInnateSpellCasting.DataSource = null;
            cmbInnateSpellCasting.Items.Clear();
            cmbInnateSpellCasting.DataSource = _statNames;
        }
    }
}

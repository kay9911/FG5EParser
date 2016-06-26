using Fantasy_Grounds_Parser_Tool.Text_Reader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creature_Creator
{
    public partial class Test1 : Form
    {
        public Test1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextReader _txt = new TextReader();
            _txt.ProcessClassXML(@"C:\Users\User\Desktop\RAW(Parsed)\Individual_Classes\Cleric\Input\class.txt", "", "", "", false, "", "", false);
        }
    }
}

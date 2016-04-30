/*
 * Created by SharpDevelop.
 * User: User
 * Date: 25-03-2016
 * Time: 14:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace Creature_Creator
{
	/// <summary>
	/// Description of Abilities.
	/// </summary>
	public partial class Abilities : Form
	{
		List<KeyValuePair<string,string>> _ability = new List<KeyValuePair<string, string>>();
		
		public Abilities()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public Abilities(List<KeyValuePair<string,string>> _val)
		{
			InitializeComponent();
		}
		
		void AbilitiesLoad(object sender, EventArgs e)
		{

		}
		
		public void displayDataGridView() 
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FG5EParser.Utilities
{
    public partial class KeyValuePairViewer : UserControl
    {
        List<KeyValuePair<string, string>> _reviewData = new List<KeyValuePair<string, string>>();
        int _selectedIndex;

        public KeyValuePairViewer()
        {
            InitializeComponent();
            List<KeyValuePair<string, string>> _legend = new List<KeyValuePair<string, string>>();
            // Delete Later on
            _legend.Add(new KeyValuePair<string, string>("Key1", "Value1"));
            _legend.Add(new KeyValuePair<string, string>("Key2", "Value2"));
            reviewData(_legend);
        }

        public void reviewData(List<KeyValuePair<string, string>> _recievedData)
        {
            // Clear the combo box of all entries
            comboBox1.Items.Clear();

            comboBox1.Items.Insert(0,"Select Something");           

            // Add values to the combobox
            for (int i = 0; i < _recievedData.Count; i++)
            {
                comboBox1.Items.Insert(i+1,string.Format("{0}",_recievedData[i].Key));
            }

            // Make the data in scope
            _reviewData = _recievedData;
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                // Key Name area
                txtKeyName.Text = _reviewData[comboBox1.SelectedIndex - 1].Key;

                // Value are
                rtbValueName.Text = _reviewData[comboBox1.SelectedIndex - 1].Value;

                // Make selected index in scope
                rtbValueName.Text = _reviewData[comboBox1.SelectedIndex - 1].Value;

                _selectedIndex = comboBox1.SelectedIndex - 1;
            }
            else
            {
                txtKeyName.Text = string.Empty;
                rtbValueName.Text = string.Empty;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _reviewData.RemoveAt(_selectedIndex);

            _reviewData.Insert(_selectedIndex, new KeyValuePair<string, string>(txtKeyName.Text, rtbValueName.Text));

            // call review data
            reviewData(_reviewData);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _reviewData.RemoveAt(_selectedIndex);
            // call review data
            reviewData(_reviewData);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

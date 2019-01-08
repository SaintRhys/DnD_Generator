using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form3 : Form {
        Form1 mainForm;
        public Form3(ListViewItem creatureList, Form1 form) {
            InitializeComponent();
            label1.Text = creatureList.SubItems[0].Text.ToString();
            textBox1.Text = creatureList.SubItems[1].Text.ToString();
            textBox2.Text = creatureList.SubItems[2].Text.ToString();
            mainForm = form;
        }

        private void button2_Click(object sender, EventArgs e) {
            // close form
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            // save changed info and put into listview on main form
            ListViewItem newItem = new ListViewItem(new string[] { label1.Text, textBox1.Text, textBox2.Text });
            mainForm.ReplaceCreatureOnListView(newItem);
        }
    }
}

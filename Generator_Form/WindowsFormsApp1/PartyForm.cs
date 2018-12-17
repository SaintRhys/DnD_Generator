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
    public partial class PartyForm : Form {
        public PartyForm() {
            InitializeComponent();
            this.Width = listView1.Location.X + listView1.Width + 30;
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e) {
            if(button4.Text == "Edit Party") {
                this.Width = listView2.Location.X + listView2.Width + 30;
                button4.Text = "Done Editing";
            } else {
                this.Width = listView1.Location.X + listView1.Width + 30;
                button4.Text = "Edit Party";
            }
            
            
            Console.WriteLine("Width: {0}", this.Width);
        }
    }
}

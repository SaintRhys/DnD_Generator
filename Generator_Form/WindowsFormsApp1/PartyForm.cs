﻿using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1 {
    public partial class PartyForm : Form {
        public PartyForm() {
            InitializeComponent();
            this.Width = listView1.Location.X + listView1.Width + 30;
        }

        public void PopulatePartyNameList() {
            string filePath = @Application.UserAppDataPath + "/Monster_Lists";

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

        private void button3_Click(object sender, EventArgs e) {
            addPartyGroupBox.Visible = !addPartyGroupBox.Visible;
        }

        private void addPartyButton_Click(object sender, EventArgs e) {
            Console.WriteLine("Adding party");
            if (partyNameTextBox.Text != "") {
                Console.WriteLine("Adding party");
                string partyName = JsonConvert.SerializeObject(partyNameTextBox.Text);
                File.WriteAllText(@Application.UserAppDataPath + "/Party_Lists/Party" + listView1.Items.Count + ".json", partyName);
            }
        }
    }
}
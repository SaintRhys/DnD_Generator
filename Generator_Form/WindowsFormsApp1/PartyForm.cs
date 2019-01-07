using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WindowsFormsApp1 {
    public partial class PartyForm : Form {
        Form1 mainForm;
        public PartyForm(Form1 form) {
            InitializeComponent();
            this.Width = listView1.Location.X + listView1.Width + 30;
            mainForm = form;
            PopulatePartyNameList();
        }

        public void PopulatePartyNameList() {
            listView1.Items.Clear();
            string filePath = @Application.UserAppDataPath + "/Party_Lists";
            DirectoryInfo d = new DirectoryInfo(filePath);

            foreach (var file in d.GetFiles("*.json")) { 
                PartyDetails partyDetails = JsonConvert.DeserializeObject<PartyDetails>(File.ReadAllText(file.DirectoryName + "/" + file));
                ListViewItem partyNameListItem = new ListViewItem(partyDetails.partyName);
                listView1.Items.Add(partyNameListItem);
            }
        }

        public void PopulatePlayerNameList(PartyDetails partyDetails){
            listView2.Items.Clear();
            if (partyDetails.partyMemberNames != null)
            {
                for (int i = 0; i < partyDetails.partyMemberNames.Count; i++)
                {
                    ListViewItem playerName = new ListViewItem(partyDetails.partyMemberNames[i]);
                    listView2.Items.Add(playerName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e) {
            // edit button and expand form
            if(button4.Text == "Edit Party") {
                Console.WriteLine("Selected item: {0}", listView1.SelectedItems.Count);
                if (listView1.SelectedItems.Count > 0) {
                    this.Width = listView2.Location.X + listView2.Width + 30;
                    button4.Text = "Done Editing";
                    button6.Visible = true;

                    PartyDetails partyDetails = JsonConvert.DeserializeObject<PartyDetails>(File.ReadAllText(Application.UserAppDataPath + "/Party_Lists/Party" + listView1.SelectedItems[0].Index + ".json"));
                    PopulatePlayerNameList(partyDetails);
                }
            } else {
                this.Width = listView1.Location.X + listView1.Width + 30;
                button4.Text = "Edit Party";
                button6.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            addPartyGroupBox.Visible = !addPartyGroupBox.Visible;
        }

        private void addPartyButton_Click(object sender, EventArgs e) {
            // add new party
            if (partyNameTextBox.Text != "") {
                if (addPartyButton.Text == "Add") { 
                    PartyDetails partyDetails = new PartyDetails();
                    AssignPartyDetails(partyDetails, partyNameTextBox.Text, "");
                    string partyName = JsonConvert.SerializeObject(partyDetails);
                    File.WriteAllText(@Application.UserAppDataPath + "/Party_Lists/Party" + listView1.Items.Count + ".json", partyName);
                } else {
                    PartyDetails partyDetails = JsonConvert.DeserializeObject<PartyDetails>(File.ReadAllText(Application.UserAppDataPath + "/Party_Lists/Party" + listView1.SelectedItems[0].Index + ".json"));
                    AssignPartyDetails(partyDetails, partyNameTextBox.Text, "");
                    string partyName = JsonConvert.SerializeObject(partyDetails);
                    File.WriteAllText(@Application.UserAppDataPath + "/Party_Lists/Party" + listView1.SelectedItems[0].Index + ".json", partyName);
                }

                partyNameTextBox.Clear();
                PopulatePartyNameList();
            }
        }

        private void AssignPartyDetails(PartyDetails partyDetails, string partyName, string partyMemberName){
            partyDetails.partyName = partyName;

            if (partyDetails.partyMemberNames == null)
                partyDetails.partyMemberNames = new List<string>();

            if(partyMemberName != "")
                partyDetails.partyMemberNames.Add(partyMemberName);
        }

        private void button6_Click(object sender, EventArgs e){
            groupBox1.Visible = !groupBox1.Visible;
            button5.Text = "Add";
        }

        private void button5_Click(object sender, EventArgs e){
            // add player name
            if (textBox1.Text != ""){
                PartyDetails partyDetails = JsonConvert.DeserializeObject<PartyDetails>(File.ReadAllText(Application.UserAppDataPath + "/Party_Lists/Party" + listView1.SelectedItems[0].Index + ".json"));
                if (button5.Text == "Add") {
                    AssignPartyDetails(partyDetails, partyDetails.partyName, textBox1.Text);
                } else {
                    AssignPartyDetails(partyDetails, partyDetails.partyName, "");
                    partyDetails.partyMemberNames[listView2.SelectedItems[0].Index] = textBox1.Text;
                    groupBox1.Visible = false;
                }
                PopulatePlayerNameList(partyDetails);
                textBox1.Clear();

                string partyName = JsonConvert.SerializeObject(partyDetails);
                File.WriteAllText(@Application.UserAppDataPath + "/Party_Lists/Party" + listView1.SelectedItems[0].Index + ".json", partyName);
            }
        }

        private void button8_Click(object sender, EventArgs e) {
            // delete player name
            if (listView2.SelectedItems.Count > 0) {
                PartyDetails partyDetails = JsonConvert.DeserializeObject<PartyDetails>(File.ReadAllText(Application.UserAppDataPath + "/Party_Lists/Party" + listView1.SelectedItems[0].Index + ".json"));
                AssignPartyDetails(partyDetails, partyDetails.partyName, "");
                partyDetails.partyMemberNames.RemoveAt(listView2.SelectedItems[0].Index);
                PopulatePlayerNameList(partyDetails);

                string partyName = JsonConvert.SerializeObject(partyDetails);
                File.WriteAllText(@Application.UserAppDataPath + "/Party_Lists/Party" + listView1.SelectedItems[0].Index + ".json", partyName);
            }
        }

        private void button7_Click(object sender, EventArgs e) {
            // edit player name
            if (listView2.SelectedItems.Count > 0) {
                groupBox1.Visible = true;
                button5.Text = "Change";
                textBox1.Text = listView2.SelectedItems[0].Text;
            }
        }

        private void button9_Click(object sender, EventArgs e) {
            // edit party name
            if (listView1.SelectedItems.Count > 0) {
                groupBox1.Visible = false;
                addPartyGroupBox.Visible = true;
                addPartyButton.Text = "Change";
                partyNameTextBox.Text = listView1.SelectedItems[0].Text;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            // show players of selected party
            if (listView1.SelectedItems.Count > 0) {
                PartyDetails partyDetails = JsonConvert.DeserializeObject<PartyDetails>(File.ReadAllText(Application.UserAppDataPath + "/Party_Lists/Party" + listView1.SelectedItems[0].Index + ".json"));
                PopulatePlayerNameList(partyDetails);
            }
        }

        private void button10_Click(object sender, EventArgs e) {
            // Delete party
            File.Delete(@Application.UserAppDataPath + "/Party_Lists/Party" + listView1.SelectedItems[0].Index + ".json");

            string filePath = @Application.UserAppDataPath + "/Party_Lists";
            DirectoryInfo d = new DirectoryInfo(filePath);

            int index = 0;
            foreach (var file in d.GetFiles("*.json")) {
                Console.WriteLine(file.Name);
                File.Move(file.DirectoryName + "/" + file, file.DirectoryName + "/Party" + index + ".json");
                index++;
            }

            PopulatePartyNameList();
        }

        private void button1_Click(object sender, EventArgs e) {
            // populate listView2 on form1
            if (listView1.SelectedItems.Count > 0) {
                mainForm.ClearEncounterListView();
                foreach (ListViewItem player in listView2.Items) {
                    string[] playerInfo = new string[] { player.SubItems[0].Text, "0", "0" };
                    ListViewItem newItem = new ListViewItem(playerInfo);

                    mainForm.AddToListView(newItem);
                }
                mainForm.ReAddMonsterNames();
                this.Close();
            }
        }
    }
}

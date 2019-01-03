using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1 {
    public partial class PartyForm : Form {
        public PartyForm() {
            InitializeComponent();
            this.Width = listView1.Location.X + listView1.Width + 30;
            PopulatePartyNameList();
        }

        public void PopulatePartyNameList() {
            listView1.Items.Clear();
            string filePath = @Application.UserAppDataPath + "/Party_Lists";
            DirectoryInfo d = new DirectoryInfo(filePath);

            Console.WriteLine("File count: {0}", d.GetFiles().Length);

            foreach (var file in d.GetFiles("*.json")) {
                Console.WriteLine("File is: {0}", file);
                string partyName = JsonConvert.DeserializeObject<string>(File.ReadAllText(file.DirectoryName + "/" + file));
                ListViewItem partyNameListItem = new ListViewItem(partyName);
                listView1.Items.Add(partyNameListItem);
            }
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
                string partyName = JsonConvert.SerializeObject(partyNameTextBox.Text);
                File.WriteAllText(@Application.UserAppDataPath + "/Party_Lists/Party" + listView1.Items.Count + ".json", partyName);
                PopulatePartyNameList();
            }
        }
    }
}

using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using Newtonsoft.Json;
using System.Drawing;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        static int maxLevel = 20;
        static int maxPartySize = 8;
        static string[] difficulty = new string[] {"Easy", "Medium", "Hard", "Deadly"};
        static string[] environment = new string[] {"Any", "Arctic", "Coast", "Desert", "Forest", "Grassland", "Hill", "Mountain", "Swamp", "Underdark", "Underwater", "Urban" };

        int[] chlLvl = new int[] {10, 25, 50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000, 2100};
        List<ListViewItem> playerNames = new List<ListViewItem>();
        List<ListViewItem> monsterNames = new List<ListViewItem>();
        List<int> randomIDs = new List<int>();

        public Form1() {
            InitializeComponent();
            ListViewSetUp();
            CheckAndCreateFilePath();
            this.CenterToScreen();
        }

        #region buttons
        private void button3_Click(object sender, EventArgs e) {
            int currLevel = int.Parse(textBox1.Text);
            textBox1.Text = (currLevel += currLevel == maxLevel ? 0 : 1).ToString();
        }

        private void button4_Click(object sender, EventArgs e) {
            int currLevel = int.Parse(textBox1.Text);
            textBox1.Text = (currLevel -= currLevel == 1 ? 0 : 1).ToString();
        }

        private void button5_Click(object sender, EventArgs e) {
            int currLevel = int.Parse(textBox4.Text);
            textBox4.Text = (currLevel -= currLevel == 1 ? 0 : 1).ToString();
        }

        private void button6_Click(object sender, EventArgs e) {
            int currLevel = int.Parse(textBox4.Text);
            textBox4.Text = (currLevel += currLevel == maxPartySize ? 0 : 1).ToString();
        }

        private void button7_Click(object sender, EventArgs e) {
            int diffNum = Array.IndexOf(difficulty, textBox6.Text);
            diffNum -= diffNum <= 0 ? 0 : 1;
            textBox6.Text = difficulty[diffNum];
        }

        private void button8_Click(object sender, EventArgs e) {
            int diffNum = Array.IndexOf(difficulty, textBox6.Text);
            diffNum += diffNum >= difficulty.Length - 1 ? 0 : 1;
            textBox6.Text = difficulty[diffNum];
        }

        #endregion buttons

        private void CheckAndCreateFilePath() {
            string filePath = @Application.UserAppDataPath + "/Monster_Lists";
            if (!Directory.Exists(filePath)) {
                Console.WriteLine(Application.UserAppDataPath + "/Monster_Lists");
                Directory.CreateDirectory(filePath);
            } else {
                Console.WriteLine("Path found");
            }

            filePath = @Application.UserAppDataPath + "/Party_Lists";
            if (!Directory.Exists(filePath)) {
                Console.WriteLine(Application.UserAppDataPath + "/Party_Lists");
                Directory.CreateDirectory(filePath);
            } else {
                Console.WriteLine("Path found: " + filePath);
            }
        }

        private void ListViewSetUp() {
            listView1.FullRowSelect = true;
            comboBox1.DataSource = environment;
        }

        private void button11_Click(object sender, EventArgs e) {
            //Generate encounter
            DeleteUnneededJsons();
            int level = int.Parse(textBox1.Text);
            int pSize = int.Parse(textBox4.Text);
            int diff = (Array.IndexOf(difficulty, textBox6.Text) + 1);
            int challenge = (level * pSize * diff) * 25;
            int enviroIndex = comboBox1.SelectedIndex;

            List<int> posChl = new List<int>();
            List<int> monsterList = new List<int>();

            //clear json file
            //File.WriteAllText(@Application.UserAppDataPath + "/Monster_Lists/monsterList.txt", "");

            textBox10.Text = "0";
            listView1.Items.Clear();

            foreach (int i in chlLvl) {
                if (i / challenge <= 1) {
                    posChl.Add(i);
                }
            }

            Random r = new Random();
            int missFires = 0;
            while (challenge > 0) {
                int rInt = r.Next(0, posChl.Count);
                if (challenge - posChl[rInt] >= 0) {
                    challenge -= posChl[rInt];
                    monsterList.Add(posChl[rInt]);
                    PopulateViewListInternalDatabase(posChl[rInt], enviroIndex);
                } else
                    missFires++;
                if (missFires == 5)
                    break;
            }

            textBox9.Text = string.Join(", ", monsterList);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            CloseUnneededForms(this.Name);
        }

        private void PopulateViewListInternalDatabase(int chl, int enviroIndex) {
            string conString = "data source=MonsterDB.db;";
            string query = "";
            if (enviroIndex == 0) {
                query = "SELECT * FROM monster_list WHERE challenge='" + chl + "' ORDER BY RANDOM() LIMIT 1;";
            } else {
                query = "SELECT * FROM monster_list WHERE " + environment[enviroIndex] + "='YES' AND challenge='" + chl + "' ORDER BY RANDOM() LIMIT 1;";
            }

            SQLiteConnection conDatabase = new SQLiteConnection(conString);
            SQLiteCommand cmdDatabase = new SQLiteCommand(query, conDatabase);
            SQLiteDataReader myReader;

            try
            {
                int totalXP = int.Parse(textBox10.Text);
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read()) {
                    //totalXP += myReader.GetInt32("XP");
                    // add to json file
                    List<string> monsterAttList = new List<string>();
                    for (int i = 0; i < myReader.FieldCount; i++) {
                        monsterAttList.Add(myReader.GetValue(i).ToString());
                    }

                    MonsterAttributes monAtt = new MonsterAttributes();
                    AssignAttributes(monAtt, monsterAttList);
                    string completeMon = JsonConvert.SerializeObject(monAtt);
                    File.WriteAllText(@Application.UserAppDataPath + "/Monster_Lists/monsterList" + listView1.Items.Count + ".json", completeMon);
                    
                    string[] monsterRow = new string[] {monAtt.id.ToString(), myReader.GetString(1),
                        myReader.GetString(2), myReader.GetString(3)};

                    ListViewItem newItem = new ListViewItem(monsterRow);
                    listView1.Items.Add(newItem);
                }

                textBox10.Text = totalXP.ToString();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateViewList(int chl) {
            string conString = "datasource=localhost;port=3306;username=root;password=SuperAdmin1!;";
            string query = "SELECT * FROM monster_database.monster_list WHERE Challenge='" + chl + "' ORDER BY RAND() LIMIT 1;";

            MySqlConnection conDatabase = new MySqlConnection(conString);
            MySqlCommand cmdDatabase = new MySqlCommand(query, conDatabase);
            MySqlDataReader myReader;

            try {
                int totalXP = int.Parse(textBox10.Text);
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read()) {
                   
                    //totalXP += myReader.GetInt32("XP");
                    // add to json file
                    List<string> monsterAttList = new List<string>();
                    for (int i = 0; i < myReader.FieldCount; i++) {
                        monsterAttList.Add(myReader.GetValue(i).ToString());
                    }
                    MonsterAttributes monAtt = new MonsterAttributes();
                    AssignAttributes(monAtt, monsterAttList);
                    string completeMon = JsonConvert.SerializeObject(monAtt);
                    File.WriteAllText(@Application.UserAppDataPath + "/Monster_Lists/monsterList" + listView1.Items.Count + ".json", completeMon);


                    string[] monsterRow = new string[] {myReader.GetString("Name"), myReader.GetString("Size"),
                        myReader.GetString("Type"), myReader.GetInt32("Challenge").ToString()};

                    ListViewItem newItem = new ListViewItem(monsterRow);
                    listView1.Items.Add(newItem);
                }

                textBox10.Text = totalXP.ToString();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void TransferAllMonsters() {
            // transfers all monsters from listview1 to listview2 and rolls initiative and hp
            if (listView1.Items.Count > 0) {
                ClearEncounterListView();
                string filePath = @Application.UserAppDataPath + "/Monster_Lists";
                DirectoryInfo d = new DirectoryInfo(filePath);

                foreach (var file in d.GetFiles("*.json")) {
                    MonsterAttributes monAtts = JsonConvert.DeserializeObject<MonsterAttributes>(File.ReadAllText(file.DirectoryName + "/" + file));
                    string health = monAtts.hp.ToString();

                    ListViewItem newItem = new ListViewItem(new string[] { monAtts.name, monAtts.initiative.ToString(), health, monAtts.id.ToString() });
                    monsterNames.Add(newItem);
                    listView2.Items.Add(newItem);
                }
                ReAddPlayerNames();
            }
        }

        public void ClearEncounterListView() {
            listView2.Items.Clear();
        }

        private void ReAddPlayerNames() {
            if (playerNames.Count > 0) {
                foreach (ListViewItem item in playerNames) {
                    listView2.Items.Add(item);
                }
            }
        }

        public void ReAddMonsterNames() {
            if (monsterNames.Count > 0) {
                foreach (ListViewItem item in monsterNames) {
                    listView2.Items.Add(item);
                }
            }
        }

        public void AddToListView(ListViewItem newItem) {
            // adds item to the encounter listView
            listView2.Items.Add(newItem);
            playerNames.Add(newItem);
        }

        private void listView1_DoubleClick(object sender, EventArgs e) {
            // double click on monster in main window
            // cycle through open forms and see if current selected monster form is open
            FormCollection fc = Application.OpenForms;
            bool monsterFormExists = false;
            foreach (Form item in fc) {
                if (item.Text == listView1.SelectedItems[0].Text + listView1.SelectedItems[0].Index) {
                    monsterFormExists = true;
                    item.BringToFront();
                }
            }

            // create monster form
            if (!monsterFormExists) {
                OpenMonsterForm(listView1.SelectedItems[0]);
            }
        }

        private void OpenMonsterForm(ListViewItem monsterListView) {
            MonsterAttributes completeMon = JsonConvert.DeserializeObject<MonsterAttributes>(File.ReadAllText(@Application.UserAppDataPath + "/Monster_Lists/monsterList" + monsterListView.Index + ".json"));
            Monster_Form mForm = new Monster_Form(completeMon, this);
            mForm.Text = monsterListView.Text + monsterListView.Index;
            mForm.Show();
        }

        public void CloseUnneededForms(string formName) {
            List<Form> formList = new List<Form>();
            foreach (Form frm in Application.OpenForms) {
                if (frm.Name != this.Name)
                    formList.Add(frm);
            }
            foreach (Form frm in formList) {
                frm.Close();
            }
        }

        public void DeleteUnneededJsons() {
            string filePath = @Application.UserAppDataPath + "/Monster_Lists/";
            DirectoryInfo d = new DirectoryInfo(filePath);

            foreach (var file in d.GetFiles("*.Json")) {
                Console.WriteLine("File name: " + file.FullName);
                file.Delete();
            }
        }

        public void AssignAttributes(MonsterAttributes monAtt, List<string> myReaderList) {
            monAtt.id = CreateRandomID();
            monAtt.name = myReaderList[1];
            monAtt.size = myReaderList[2];
            monAtt.type = myReaderList[3];
            monAtt.align = myReaderList[4];
            monAtt.challenge = int.Parse(myReaderList[5]);
            // nothing in column xp = int.Parse(myReaderList[6]);
            monAtt.cr = double.Parse(myReaderList[7]);
            monAtt.ac = int.Parse(myReaderList[8]);
            monAtt.hp = int.Parse(myReaderList[9]);
            monAtt.currHp = int.Parse(myReaderList[9]);
            monAtt.hitDice = myReaderList[10];
            monAtt.speeds = myReaderList[11];
            monAtt.str = int.Parse(myReaderList[12]);
            monAtt.dex = int.Parse(myReaderList[13]);
            monAtt.con = int.Parse(myReaderList[14]);
            monAtt.intt = int.Parse(myReaderList[15]);
            monAtt.wis = int.Parse(myReaderList[16]);
            monAtt.cha = int.Parse(myReaderList[17]);
            monAtt.savingThrows = myReaderList[18];
            monAtt.skills = myReaderList[19];
            monAtt.wri = myReaderList[20];
            monAtt.senses = myReaderList[21];
            monAtt.languages = myReaderList[22];
            monAtt.additional = myReaderList[23];
            monAtt.actions = myReaderList[24];
            monAtt.arctic = myReaderList[25];
            monAtt.coast = myReaderList[26];
            monAtt.desert = myReaderList[27];
            monAtt.forest = myReaderList[28];
            monAtt.grassland = myReaderList[29];
            monAtt.hill = myReaderList[30];
            monAtt.mountain = myReaderList[31];
            monAtt.swamp = myReaderList[32];
            monAtt.underdark = myReaderList[33];
            monAtt.underwater = myReaderList[34];
            monAtt.urban = myReaderList[35];
            monAtt.font = myReaderList[36];
            monAtt.addInfo = myReaderList[37];
            Random rnd = new Random();
            int initiative = (rnd.Next(1, 21) + (int)Math.Floor((double)(monAtt.dex / 2) + -5));
            monAtt.initiative = initiative;
        }

        private void button12_Click(object sender, EventArgs e) {

        }

        private void listView2_ItemDrag(object sender, ItemDragEventArgs e) {
            // drag and drop for listview2
            listView2.DoDragDrop(listView2.SelectedItems, DragDropEffects.Move);
        }

        private void listView2_DragDrop(object sender, DragEventArgs e) {
            // drag and drop monsters or players for listview2
            if (listView2.SelectedItems.Count == 0) return;
            Point pt = listView2.PointToClient(new Point(e.X, e.Y));
            ListViewItem itemDrag = listView2.GetItemAt(pt.X, pt.Y);
            ListViewItem lowestItem = listView2.Items[listView2.Items.Count - 1];

            int indexOffset = -1;
            if (itemDrag == null && (lowestItem.Position.Y + lowestItem.Bounds.Size.Height) <= pt.Y) {
                itemDrag = lowestItem;
                indexOffset = 0;
            } else if (itemDrag == null) return;

            int itemDragIndex = itemDrag.Index;
            ListViewItem[] sel = new ListViewItem[listView2.SelectedItems.Count];
            for (int i = 0; i < listView2.SelectedItems.Count; i++) {
                sel[i] = listView2.SelectedItems[i];
            }
            for (int i = 0; i < sel.GetLength(0); i++) {
                ListViewItem item = sel[i];
                int itemIndex = itemDragIndex;

                if (itemIndex == item.Index) return;
                if (item.Index < itemIndex)
                    itemIndex++;
                else
                    itemIndex = itemDragIndex + 1;

                ListViewItem insertItem = (ListViewItem)item.Clone();
                listView2.Items.Insert(itemIndex + indexOffset, insertItem);
                listView2.Items.Remove(item);
            }
        }

        private void listView2_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void button12_Click_1(object sender, EventArgs e) {
            // open all monsters
            for (int i = 0; i < listView1.Items.Count; i++) {
                FormCollection fc = Application.OpenForms;
                bool monsterFormExists = false;
                foreach (Form item in fc) {
                    if (item.Text == listView1.Items[i].Text + listView1.Items[i].Index) {
                        monsterFormExists = true;
                        item.BringToFront();
                    }
                }

                // create monster form
                if (!monsterFormExists) {
                    OpenMonsterForm(listView1.Items[i]);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e) {
            PartyForm partyForm = new PartyForm(this);
            partyForm.Show();
        }

        private void button1_Click(object sender, EventArgs e) {
            TransferAllMonsters();
        }

        private void listView2_DoubleClick(object sender, EventArgs e) {
            // open creature and edit info
            FormCollection fc = Application.OpenForms;
            ListViewItem selectedItem = listView2.SelectedItems[0];
            bool alreadyOpen = false;
            foreach  (Form form in fc) {
                if (form.Name == selectedItem.SubItems[0].Text + selectedItem.Index) {
                    alreadyOpen = true;
                    break;
                }
            }
            if (!alreadyOpen) {
                if (playerNames.Contains(selectedItem)) {
                    Form3 newForm = new Form3(listView2.SelectedItems[0], this);
                    newForm.Name = selectedItem.SubItems[0].Text + selectedItem.Index;
                    newForm.Show();
                } else if (monsterNames.Contains(selectedItem)) {
                    foreach (ListViewItem item in listView1.Items) {
                        if (item.SubItems[0].Text == selectedItem.SubItems[3].Text) {
                            OpenMonsterForm(item);
                            break;
                        }
                    }
                }
            }
        }

        public void ReplaceCreatureOnListView(ListViewItem newItem) {
            // look for same creature in listview2 and replace it with new one
            for (int i = 0; i < listView2.Items.Count; i++) {
                if (listView2.Items[i].SubItems[0].Text == newItem.SubItems[0].Text) {

                    if (monsterNames.Contains(listView2.Items[i])) {
                        int index = monsterNames.IndexOf(listView2.Items[i]);
                        monsterNames[index] = newItem;
                    } else if (playerNames.Contains(listView2.Items[i])) {
                        int index = playerNames.IndexOf(listView2.Items[i]);
                        playerNames[index] = newItem;
                    }

                    listView2.Items[i] = newItem;
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            ListViewItem newItem = new ListViewItem(new string[] {"Name", "10", "95", "ID" });
            listView2.Items.Add(newItem);
        }

        public void SaveNewMonsterStats(string[] newStats) {
            foreach (ListViewItem item in listView1.Items) {
                if(newStats[0] == item.SubItems[0].Text) {
                    MonsterAttributes monAtt = JsonConvert.DeserializeObject<MonsterAttributes>(File.ReadAllText(@Application.UserAppDataPath + "/Monster_Lists/monsterList" + item.Index + ".json"));
                    monAtt.initiative = int.Parse(newStats[1]);
                    monAtt.hp = int.Parse(newStats[2]);
                    monAtt.currHp = int.Parse(newStats[3]);
                    monAtt.ac = int.Parse(newStats[4]);
                    string completeMon = JsonConvert.SerializeObject(monAtt);
                    File.WriteAllText(@Application.UserAppDataPath + "/Monster_Lists/monsterList" + item.Index + ".json", completeMon);
                    break;
                }
            }
        }

        private int CreateRandomID() {
            Random rnd = new Random();
            int randomID;
            do {
                randomID = rnd.Next(1, 10001);
            } while (randomIDs.Contains(randomID));
            return randomID;
        }
    }
}

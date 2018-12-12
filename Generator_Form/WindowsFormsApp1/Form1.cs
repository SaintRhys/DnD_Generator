using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using Newtonsoft.Json;
using System.Xml;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        static int maxLevel = 20;
        static int maxPartySize = 8;
        static string[] difficulty = new string[] {"Easy", "Medium", "Hard", "Deadly"};
        static string[] environment = new string[] {"Any", "Arctic", "Coastal", "Desert", "Forest", "Grassland", "Hill", "Mountain", "Swamp", "Underdark", "Underwater", "Urban" };

        int[] chlLvl = new int[] {10, 25, 50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000, 2100};

        public Form1() {
            InitializeComponent();
            ListViewSetUp();
            CheckAndCreateFilePath();
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

        private void button9_Click(object sender, EventArgs e) {
            int envoNum = Array.IndexOf(environment, textBox8.Text);
            envoNum -= envoNum <= 0 ? 0 : 1;
            textBox8.Text = environment[envoNum];
        }

        private void button10_Click(object sender, EventArgs e) {
            int envoNum = Array.IndexOf(environment, textBox8.Text);
            envoNum += envoNum >= environment.Length - 1 ? 0 : 1;
            textBox8.Text = environment[envoNum];
        }

        #endregion buttons

        private void CheckAndCreateFilePath() {
            string filePath = @Application.UserAppDataPath + "/Monster_Lists";
            if (!Directory.Exists(filePath)) {
                Console.WriteLine(Application.UserAppDataPath + "/Monster_Lists");
            } else {
                Console.WriteLine("Path found");
            }
        }

        private void ListViewSetUp() {
            listView1.FullRowSelect = true;
        }

        private void button11_Click(object sender, EventArgs e) {
            //Generate encounter
            int level = int.Parse(textBox1.Text);
            int pSize = int.Parse(textBox4.Text);
            int diff = (Array.IndexOf(difficulty, textBox6.Text) + 1);
            int challenge = (level * pSize * diff) * 25;

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
                Console.WriteLine("Random: {0} and pos: {1}", rInt, posChl[rInt]);
                if (challenge - posChl[rInt] >= 0) {
                    challenge -= posChl[rInt];
                    monsterList.Add(posChl[rInt]);
                    PopulateViewListInternalDatabase(posChl[rInt]);
                } else
                    missFires++;
                if (missFires == 5)
                    break;
            }

            textBox9.Text = string.Join(", ", monsterList);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            CloseUnneededForms(this.Name);
        }

        private void PopulateViewListInternalDatabase(int chl) {
            string conString = "data source=MonsterDB.db;";
            string query = "SELECT * FROM monster_list WHERE challenge='" + chl + "' ORDER BY RANDOM() LIMIT 1;";

            SQLiteConnection conDatabase = new SQLiteConnection(conString);
            SQLiteCommand cmdDatabase = new SQLiteCommand(query, conDatabase);
            SQLiteDataReader myReader;
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
                    
                    string[] monsterRow = new string[] {myReader.GetValue(0).ToString(), myReader.GetString(1),
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

        private void listView1_DoubleClick(object sender, EventArgs e) {

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
                MonsterAttributes completeMon = JsonConvert.DeserializeObject<MonsterAttributes>(File.ReadAllText(@Application.UserAppDataPath + "/Monster_Lists/monsterList" + listView1.SelectedItems[0].Index + ".json"));
                Monster_Form mForm = new Monster_Form(completeMon);
                Console.WriteLine("Count: {0}", completeMon.name);
                mForm.Text = listView1.SelectedItems[0].Text + listView1.SelectedItems[0].Index;
                mForm.Show();
            }
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

        public void AssignAttributes(MonsterAttributes monAtt, List<string> myReaderList) {
            monAtt.id = int.Parse(myReaderList[0]);
            monAtt.name = myReaderList[1];
            monAtt.size = myReaderList[2];
            monAtt.type = myReaderList[3];
            monAtt.align = myReaderList[4];
            monAtt.challenge = int.Parse(myReaderList[5]);
            // nothing in column xp = int.Parse(myReaderList[6]);
            monAtt.cr = double.Parse(myReaderList[7]);
            monAtt.ac = int.Parse(myReaderList[8]);
            monAtt.hp = int.Parse(myReaderList[9]);
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
        }

        private void button12_Click(object sender, EventArgs e) {

        }
    }
}

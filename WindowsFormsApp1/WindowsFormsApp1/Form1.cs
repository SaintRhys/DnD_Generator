using System;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        static int maxLevel = 20;
        static int maxPartySize = 8;
        static string[] difficulty = new string[] {"Easy", "Medium", "Hard", "Deadly"};
        static string[] environment = new string[] {"Any", "Arctic", "Coastal", "Desert", "Forest", "Grassland", "Hill", "Mountain", "Swamp", "Underdark", "Underwater", "Urban" };

        public Form1() {
            InitializeComponent();
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
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApp1 {
    public partial class Monster_Form : Form {
        string[] monsterProps = new string[] {"Saving Throws:", "Skills:", "Damage Resistance:", "Damage Immunities:", "Condition Immunities:", "Senses:", "Language:", "Challenge"};
        MonsterAttributes monAtt;
        public Monster_Form(MonsterAttributes currMonAtt) {
            InitializeComponent();
            monAtt = currMonAtt;
            SetUpMonsterStats();
        }

        private void SetUpMonsterStats() {
            textName.Text = monAtt.name;
            textType.Text = monAtt.type + ", " + monAtt.align;
            textAC.Text = monAtt.ac.ToString();
            textCurrHP.Text = monAtt.hp.ToString();
            textMaxHP.Text = monAtt.hp.ToString();
            textHitDice.Text = monAtt.hitDice;
            textSpeed.Text = monAtt.speeds;

            string[] monsterRow = new string[] {monAtt.str.ToString(), monAtt.dex.ToString(),
                        monAtt.con.ToString(), monAtt.intt.ToString(), monAtt.wis.ToString(), monAtt.cha.ToString()};

            for (int i = 0; i < monsterRow.Length; i++) {
                monsterRow[i] += " (" + (Math.Floor(double.Parse(monsterRow[i]) / 2) + -5) + ")";
            }

            ListViewItem newItem = new ListViewItem(monsterRow);
            listView1.Items.Add(newItem);

            SetUpMonsterProps(new string[] {monAtt.savingThrows, monAtt.skills, monAtt.wri, monAtt.wri, monAtt.wri, monAtt.senses, monAtt.languages, monAtt.challenge.ToString() });
        }

        private void AddNewPanel(int controlCount, Panel newPanel, int p) {
            newPanel.Location = new Point(10, ((panel1.Controls.Count - p) * 30 * controlCount) + 10);
            newPanel.Width = panel1.Width - 20;
            panel1.Controls.Add(newPanel);

            Label line = new Label {
                Location = new Point(10, newPanel.Location.Y - 10),
                Text = "",
                BorderStyle = BorderStyle.Fixed3D,
                AutoSize = false,
                Height = 2,
                Width = panel1.Width - 20
            };
            panel1.Controls.Add(line);
        }

        private void SetUpMonsterProps(string[] props) {
            int controlCount = 1;
            Panel newPanel = new Panel();
            AddNewPanel(controlCount, newPanel, 0);

            for (int i = 0; i < props.Length; i++) {
                if (props[i] != "None") {
                    TextBox mProp = new TextBox();
                    TextBox mPropText = new TextBox();

                    mPropText.Text = monsterProps[i];
                    mPropText.Location = new Point(10, newPanel.Controls.Count / 2 * 25);

                    mProp.Text = props[i];
                    mProp.Location = new Point(mPropText.Width + 20, newPanel.Controls.Count / 2 * 25);
                        
                    newPanel.Controls.Add(mPropText);
                    newPanel.Controls.Add(mProp);
                }
                controlCount = newPanel.Controls.Count / 2;
            }

            newPanel.Height = controlCount * 25;

            Panel newPanel1 = new Panel();
            AddNewPanel(controlCount, newPanel1, 1);

            string[] additionalInfo = monAtt.additional.Split(',');

            controlCount = 0;
            for (int i = 0; i < additionalInfo.Length; i++) {
                if (additionalInfo[i] != "None") {
                    TextBox mProp = new TextBox();
                    TextBox mPropText = new TextBox();

                    mProp.Text = additionalInfo[i];
                    mProp.Location = new Point(10, (newPanel1.Controls.Count + controlCount) * 25);
                    newPanel1.Controls.Add(mProp);

                    mPropText.Multiline = true;
                    mPropText.Text = "Lorem ipsum congue sem sociosqu ullamcorper lacus massa hendrerit velit praesent lorem viverra adipiscing vel, porta etiam cursus metus massa curae justo at ac bibendum placerat ut purus gravida quam gravida elementum habitant sociosqu hac taciti sed.";
                    mPropText.Location = new Point(10, (newPanel1.Controls.Count + controlCount) * 25);
                    mPropText.Width = newPanel1.Width - 10;

                    // gets height needed for text box
                    Size sz = new Size(mPropText.ClientSize.Width, int.MaxValue);
                    TextFormatFlags flags = TextFormatFlags.WordBreak;
                    int padding = 3;
                    int borders = mPropText.Height - mPropText.ClientSize.Height;
                    sz = TextRenderer.MeasureText(mPropText.Text, mPropText.Font, sz, flags);
                    int h = sz.Height + borders + padding;
                    if (mPropText.Top + h > this.ClientSize.Height - 10) {
                        h = this.ClientSize.Height - 10 - mPropText.Top;
                    }
                    mPropText.Height = h;

                    newPanel1.Controls.Add(mPropText);
                    newPanel1.Height += h;
                    controlCount += (h / 22) - 1;
                }
                //controlCount = newPanel1.Controls.Count;
                
            }
        }
    }
}

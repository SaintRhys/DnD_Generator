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

        private void AddNewPanel(Panel newPanel, int offset) {
            Console.WriteLine("Control C: {0} and PCC: {1}", panel1.Controls.Count, offset);
            newPanel.Location = new Point(10, offset);
            newPanel.Width = panel1.Width - 20;
            newPanel.BorderStyle = BorderStyle.FixedSingle;
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
            AddNewPanel(newPanel, 1);

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
            if (monAtt.additional != "None") {
                AddNewPanel(newPanel1, newPanel.Location.Y + newPanel.Height + 25);
                newPanel1.Height = 25;

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
                        newPanel1.Height += h + 25;
                        controlCount += (h / 22) - 1;
                    }
                }
            }

            if (monAtt.actions != "None") {
                Panel newPanel2 = new Panel();
                AddNewPanel(newPanel2, newPanel1.Location.Y + newPanel1.Height + 25);
                newPanel2.Height = 25;

                string[] actions = monAtt.actions.Split(',');

                TextBox actionText = new TextBox();
                actionText.Text = "ACTIONS";
                actionText.Location = new Point((newPanel2.Width / 2) - (actionText.Width / 2), 10);
                newPanel2.Controls.Add(actionText);

                
                controlCount = 0;
                for (int i = 0; i < actions.Length; i++) {
                    if (actions[i] != "None") {
                        TextBox mProp = new TextBox();
                        TextBox mPropText = new TextBox();

                        mProp.Text = actions[i];
                        mProp.Location = new Point(10, (newPanel2.Controls.Count + controlCount) * 25);
                        newPanel2.Controls.Add(mProp);

                        mPropText.Multiline = true;
                        mPropText.Text = "Lorem ipsum congue sem sociosqu ullamcorper lacus massa hendrerit velit praesent lorem viverra adipiscing vel, porta etiam cursus metus massa curae justo at ac bibendum placerat ut purus gravida quam gravida elementum habitant sociosqu hac taciti sed.";
                        mPropText.Location = new Point(10, (newPanel2.Controls.Count + controlCount) * 25);
                        mPropText.Width = newPanel2.Width - 10;

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

                        newPanel2.Controls.Add(mPropText);
                        newPanel2.Height += h;
                        controlCount += (h / 22) - 1;
                    }
                }
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1 {
    public partial class Monster_Form : Form {
        string[] monsterProps = new string[] {"Saving Throws:", "Skills:", "Damage Resistance:", "Damage Immunities:", "Condition Immunities:", "Senses:", "Language:", "Challenge"};
        MonsterAttributes monAtt;
        Form1 mainForm;
        public Monster_Form(MonsterAttributes currMonAtt, Form1 form) {
            InitializeComponent();
            monAtt = currMonAtt;
            SetUpMonsterStats();
            mainForm = form;
        }

        private void SetUpMonsterStats() {
            textName.Text = monAtt.name;
            textType.Text = monAtt.type + ", " + monAtt.align;
            textAC.Text = monAtt.ac.ToString();
            textCurrHP.Text = monAtt.currHp.ToString();
            textMaxHP.Text = monAtt.hp.ToString();
            textHitDice.Text = monAtt.hitDice;
            textSpeed.Text = monAtt.speeds;
            textInitiative.Text = monAtt.initiative.ToString();

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

        private Size GetStringWidth(string str, Font font) {
            Size size = TextRenderer.MeasureText(str, font);
            return size;
        }

        private void SetUpMonsterProps(string[] props) {
            int controlCount = 1;
            Panel newPanel = new Panel();
            AddNewPanel(newPanel, 1);

            int extraSpace = 0;
            for (int i = 0; i < props.Length; i++) {
                if (props[i] != "None") {
                    TextBox mProp = new TextBox();
                    TextBox mPropText = new TextBox();

                    mPropText.Text = monsterProps[i];
                    mPropText.Location = new Point(10, (newPanel.Controls.Count / 2 * 25 + extraSpace) + 5);
                    mPropText.TextAlign = HorizontalAlignment.Right;
                    mPropText.Width = GetStringWidth(mPropText.Text, new Font("Microsoft Sans Serif", 8.0f)).Width;

                    mProp.Text = props[i];
                    mProp.Location = new Point(mPropText.Width + 10 + mPropText.Location.X, (newPanel.Controls.Count / 2 * 25 + extraSpace) + 5);
                    mProp.Width = GetStringWidth(mProp.Text, new Font("Microsoft Sans Serif", 8.0f)).Width;
                    //mProp.BorderStyle = BorderStyle.None;
                    mProp.BackColor = this.BackColor;

                    Console.WriteLine("Text: {0}, form: {1}", mProp.Location.X + mProp.Width, panel1.Width + panel1.Location.X);
                    if (mProp.Location.X + mProp.Width >= panel1.Width + panel1.Location.X) {
                        mProp.Multiline = true;
                        mProp.Width = panel1.Width + panel1.Location.X - mProp.Location.X - 40;
                        mProp.Height = mProp.Height * 2;
                        extraSpace += 25;
                    }

                    newPanel.Controls.Add(mPropText);
                    newPanel.Controls.Add(mProp);
                }
                controlCount = newPanel.Controls.Count / 2;
            }

            newPanel.Height = (controlCount * 25) + 10 + extraSpace;

            Panel newPanel1 = new Panel();
            // add monster properties panel
            if (monAtt.additional != "None") {
                AddNewPanel(newPanel1, newPanel.Location.Y + newPanel.Height + 25);
                newPanel1.Height = 25;

                string[] additionalInfo = monAtt.additional.Split(',');

                controlCount = 0;
                int controlCountCount = 0;
                for (int i = 0; i < additionalInfo.Length; i++) {
                    if (additionalInfo[i] != "None") {
                        TextBox mProp = new TextBox();
                        TextBox mPropText = new TextBox();

                        mProp.Text = additionalInfo[i];
                        Console.WriteLine("Control {0} and num {1}", newPanel1.Controls.Count, (controlCountCount + 1) * 2 - 1);
                        mProp.Location = new Point(10, i == 0 ? 10 : newPanel1.Controls[newPanel1.Controls.Count - 1].Location.Y + newPanel1.Controls[newPanel1.Controls.Count - 1].Height + 10);
                        newPanel1.Controls.Add(mProp);

                        mPropText.Multiline = true;
                        mPropText.Text = "Lorem ipsum congue sem sociosqu ullamcorper lacus massa hendrerit velit praesent lorem viverra adipiscing vel, porta etiam cursus metus massa curae justo at ac bibendum placerat ut purus gravida quam gravida elementum habitant sociosqu hac taciti sed.";
                        mPropText.Location = new Point(10, i == 0 ? 35 : newPanel1.Controls[newPanel1.Controls.Count - 1].Location.Y + 25);
                        mPropText.Width = newPanel1.Width - 20;

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
                        //newPanel1.Height += h + 30;
                        newPanel1.Height = newPanel1.Controls[newPanel1.Controls.Count - 1].Location.Y + newPanel1.Controls[newPanel1.Controls.Count - 1].Height + 10;
                        controlCount += (h / 22) - 1;
                        controlCountCount++;
                    }
                }
            }

            // add monster actions panel
            if (monAtt.actions != "None") {
                Panel newPanel2 = new Panel();
                AddNewPanel(newPanel2, newPanel1.Location.Y + newPanel1.Height + 25);
                

                string[] actions = monAtt.actions.Split(',');

                TextBox actionText = new TextBox();
                actionText.Text = "ACTIONS";
                actionText.Location = new Point((newPanel2.Width / 2) - (actionText.Width / 2), 10);
                newPanel2.Controls.Add(actionText);
                newPanel2.Height = actionText.Location.Y + actionText.Height + 10;

                controlCount = 0;
                for (int i = 0; i < actions.Length; i++) {
                    if (actions[i] != "None") {
                        TextBox mProp = new TextBox();
                        TextBox mPropText = new TextBox();

                        mProp.Text = actions[i];
                        mProp.Location = new Point(10, i == 0 ? 10 : newPanel2.Controls[newPanel2.Controls.Count - 1].Location.Y + newPanel2.Controls[newPanel2.Controls.Count - 1].Height + 10);
                        newPanel2.Controls.Add(mProp);

                        mPropText.Multiline = true;
                        mPropText.Text = "Lorem ipsum congue sem sociosqu ullamcorper lacus massa hendrerit velit praesent lorem viverra adipiscing vel, porta etiam cursus metus massa curae justo at ac bibendum placerat ut purus gravida quam gravida elementum habitant sociosqu hac taciti sed.";
                        mPropText.Location = new Point(10, i == 0 ? 35 : newPanel2.Controls[newPanel2.Controls.Count - 1].Location.Y + 25);
                        mPropText.Width = newPanel2.Width - 20;

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

                        Console.WriteLine("H: {0} and height: {1}", h, newPanel2.Height);

                        newPanel2.Controls.Add(mPropText);
                        newPanel2.Height = newPanel2.Controls[newPanel2.Controls.Count - 1].Location.Y + newPanel2.Controls[newPanel2.Controls.Count - 1].Height + 10;
                        controlCount += (h / 22) - 1;
                    }
                }
            }
            panel1.Width = this.Width - 28;
        }

        private void button1_Click(object sender, EventArgs e) {
            // save changes to monster and add it back to listview2
            string[] newStats = new string[] {  monAtt.id.ToString(),
                                                textInitiative.Text,
                                                textMaxHP.Text,
                                                textCurrHP.Text,
                                                textAC.Text};
            mainForm.SaveNewMonsterStats(newStats);
        }
    }
}

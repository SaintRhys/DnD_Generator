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
    public partial class Monster_Form : Form {
        string[] monsterProps = new string[] {"Saving Throws:", "Skills:", "Damage Resistance:", "Damage Immunities:", "Condition Immunities:", "Senses:", "Language:", "Challenge"};
        public Monster_Form() {
            InitializeComponent();

            Random r = new Random();
            SetUpMonsterProps(new int[] { r.Next(0, 2), r.Next(0, 2), r.Next(0, 2), r.Next(0, 2), r.Next(0, 2), r.Next(0, 2), r.Next(0, 2), r.Next(0, 2) });
        }

        private void SetUpMonsterProps(int[] props) {
            int controlCount = 1;

            for (int p = 0; p < 10; p++) {
                Panel newPanel = new Panel();
                
                newPanel.Location = new Point(10, ((panel1.Controls.Count - p) * 30 * controlCount) + 10 );
                panel1.Controls.Add(newPanel);

                Label line = new Label();
                line.Location = new Point(10, newPanel.Location.Y - 10);
                line.Text = "";
                line.BorderStyle = BorderStyle.Fixed3D;
                line.AutoSize = false;
                line.Height = 2;
                line.Width = panel1.Width - 20;
                panel1.Controls.Add(line);

                for (int i = 0; i < props.Length; i++) {
                    if (props[i] == 1) {
                        TextBox mProp = new TextBox();
                        mProp.Text = monsterProps[i];
                        mProp.Location = new Point(10, newPanel.Controls.Count * 25);

                        newPanel.Controls.Add(mProp);
                    }
                    controlCount = newPanel.Controls.Count;
                }

                newPanel.Height = controlCount * 25;
            }
        }
    }

    public class Monster_Info {
        string id;
        string name;
        string size;
        string type;

        int armorClass;
        string hitDice;
        int maxHP;
        int currHP;
        int speed;
        int[] attirbutes;

        string[] extraInfo;
        string[] features;
        string[] actions;
    }
}

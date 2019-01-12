namespace WindowsFormsApp1 {
    partial class Monster_Form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textType = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textAC = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textCurrHP = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textMaxHP = new System.Windows.Forms.TextBox();
            this.textHitDice = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textSpeed = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textInitiative = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textType
            // 
            this.textType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textType.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textType.Enabled = false;
            this.textType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textType.Location = new System.Drawing.Point(10, 30);
            this.textType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textType.Name = "textType";
            this.textType.ReadOnly = true;
            this.textType.Size = new System.Drawing.Size(141, 12);
            this.textType.TabIndex = 0;
            this.textType.Text = "Medium Beast";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox2.Location = new System.Drawing.Point(10, 54);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(77, 12);
            this.textBox2.TabIndex = 1;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Armor Class:";
            // 
            // textAC
            // 
            this.textAC.Location = new System.Drawing.Point(92, 54);
            this.textAC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textAC.Name = "textAC";
            this.textAC.Size = new System.Drawing.Size(60, 20);
            this.textAC.TabIndex = 2;
            this.textAC.Text = "12";
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(10, 76);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(77, 12);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "Hit Points:";
            // 
            // textCurrHP
            // 
            this.textCurrHP.Location = new System.Drawing.Point(92, 76);
            this.textCurrHP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textCurrHP.Name = "textCurrHP";
            this.textCurrHP.Size = new System.Drawing.Size(31, 20);
            this.textCurrHP.TabIndex = 4;
            this.textCurrHP.Text = "12";
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(127, 76);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(8, 13);
            this.textBox6.TabIndex = 5;
            this.textBox6.Text = "/";
            // 
            // textMaxHP
            // 
            this.textMaxHP.Location = new System.Drawing.Point(139, 76);
            this.textMaxHP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textMaxHP.Name = "textMaxHP";
            this.textMaxHP.Size = new System.Drawing.Size(31, 20);
            this.textMaxHP.TabIndex = 6;
            this.textMaxHP.Text = "12";
            // 
            // textHitDice
            // 
            this.textHitDice.Enabled = false;
            this.textHitDice.Location = new System.Drawing.Point(173, 76);
            this.textHitDice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textHitDice.Name = "textHitDice";
            this.textHitDice.Size = new System.Drawing.Size(60, 20);
            this.textHitDice.TabIndex = 7;
            this.textHitDice.Text = "(3d8 + 6)";
            this.textHitDice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox9.Enabled = false;
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(10, 99);
            this.textBox9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(77, 12);
            this.textBox9.TabIndex = 8;
            this.textBox9.Text = "Speed:";
            // 
            // textSpeed
            // 
            this.textSpeed.Enabled = false;
            this.textSpeed.Location = new System.Drawing.Point(92, 99);
            this.textSpeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textSpeed.Name = "textSpeed";
            this.textSpeed.Size = new System.Drawing.Size(78, 20);
            this.textSpeed.TabIndex = 9;
            this.textSpeed.Text = "30ft.";
            // 
            // listView1
            // 
            this.listView1.AutoArrange = false;
            this.listView1.BackColor = System.Drawing.Color.LightGray;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(92, 122);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Scrollable = false;
            this.listView1.Size = new System.Drawing.Size(276, 44);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STR";
            this.columnHeader1.Width = 46;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "DEX";
            this.columnHeader2.Width = 46;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CON";
            this.columnHeader3.Width = 46;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "INT";
            this.columnHeader4.Width = 46;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "WIS";
            this.columnHeader5.Width = 46;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "CHA";
            this.columnHeader6.Width = 46;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(10, 170);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 440);
            this.panel1.TabIndex = 11;
            // 
            // textName
            // 
            this.textName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textName.Enabled = false;
            this.textName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textName.Location = new System.Drawing.Point(9, 10);
            this.textName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textName.Name = "textName";
            this.textName.ReadOnly = true;
            this.textName.Size = new System.Drawing.Size(223, 16);
            this.textName.TabIndex = 12;
            this.textName.TabStop = false;
            this.textName.Text = "Monster Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(387, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox1.Location = new System.Drawing.Point(173, 54);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(77, 12);
            this.textBox1.TabIndex = 14;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Initiative:";
            // 
            // textInitiative
            // 
            this.textInitiative.Location = new System.Drawing.Point(232, 52);
            this.textInitiative.Margin = new System.Windows.Forms.Padding(2);
            this.textInitiative.Name = "textInitiative";
            this.textInitiative.Size = new System.Drawing.Size(60, 20);
            this.textInitiative.TabIndex = 15;
            this.textInitiative.Text = "12";
            // 
            // Monster_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 620);
            this.Controls.Add(this.textInitiative);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textSpeed);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textHitDice);
            this.Controls.Add(this.textMaxHP);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textCurrHP);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textAC);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textType);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Monster_Form";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textType;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textAC;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textCurrHP;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textMaxHP;
        private System.Windows.Forms.TextBox textHitDice;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textSpeed;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textInitiative;
    }
}
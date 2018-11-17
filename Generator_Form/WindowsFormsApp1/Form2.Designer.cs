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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Medium Beast";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(13, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(103, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Armor Class:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(123, 42);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(78, 22);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "12";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(13, 70);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(103, 22);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "Hit Points:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(123, 70);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(40, 22);
            this.textBox5.TabIndex = 4;
            this.textBox5.Text = "12";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(169, 70);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(10, 22);
            this.textBox6.TabIndex = 5;
            this.textBox6.Text = "/";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(185, 70);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(40, 22);
            this.textBox7.TabIndex = 6;
            this.textBox7.Text = "12";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(231, 70);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(78, 22);
            this.textBox8.TabIndex = 7;
            this.textBox8.Text = "(3d8 + 6)";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(13, 98);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(103, 22);
            this.textBox9.TabIndex = 8;
            this.textBox9.Text = "Speed:";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(123, 98);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(78, 22);
            this.textBox10.TabIndex = 9;
            this.textBox10.Text = "30ft.";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.LightGray;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.Location = new System.Drawing.Point(123, 126);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(367, 52);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STR";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "DEX";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CON";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "INT";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "WIS";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "CHA";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(13, 185);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 566);
            this.panel1.TabIndex = 11;
            // 
            // Monster_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 763);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Monster_Form";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel panel1;
    }
}
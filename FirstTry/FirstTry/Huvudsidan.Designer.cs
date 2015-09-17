namespace FirstTry
{
    partial class Huvudsidan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox_forestallning = new System.Windows.Forms.ListBox();
            this.listBox_akter = new System.Windows.Forms.ListBox();
            this.textBox_vuxen = new System.Windows.Forms.TextBox();
            this.textBox_ungdom = new System.Windows.Forms.TextBox();
            this.textBox_barn = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label_vuxen = new System.Windows.Forms.Label();
            this.label_ungdom = new System.Windows.Forms.Label();
            this.label_barn = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_forestallning
            // 
            this.listBox_forestallning.FormattingEnabled = true;
            this.listBox_forestallning.Location = new System.Drawing.Point(93, 53);
            this.listBox_forestallning.Name = "listBox_forestallning";
            this.listBox_forestallning.Size = new System.Drawing.Size(190, 238);
            this.listBox_forestallning.TabIndex = 0;
            this.listBox_forestallning.SelectedIndexChanged += new System.EventHandler(this.listBox_forestallning_SelectedIndexChanged);
            // 
            // listBox_akter
            // 
            this.listBox_akter.FormattingEnabled = true;
            this.listBox_akter.Location = new System.Drawing.Point(433, 53);
            this.listBox_akter.Name = "listBox_akter";
            this.listBox_akter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_akter.Size = new System.Drawing.Size(190, 238);
            this.listBox_akter.TabIndex = 1;
            this.listBox_akter.SelectedIndexChanged += new System.EventHandler(this.listBox_akter_SelectedIndexChanged);
            // 
            // textBox_vuxen
            // 
            this.textBox_vuxen.Location = new System.Drawing.Point(532, 324);
            this.textBox_vuxen.Name = "textBox_vuxen";
            this.textBox_vuxen.Size = new System.Drawing.Size(22, 20);
            this.textBox_vuxen.TabIndex = 2;
            this.textBox_vuxen.Text = "0";
            this.textBox_vuxen.TextChanged += new System.EventHandler(this.textBox_vuxen_TextChanged);
            // 
            // textBox_ungdom
            // 
            this.textBox_ungdom.Location = new System.Drawing.Point(532, 350);
            this.textBox_ungdom.Name = "textBox_ungdom";
            this.textBox_ungdom.Size = new System.Drawing.Size(22, 20);
            this.textBox_ungdom.TabIndex = 3;
            this.textBox_ungdom.Text = "0";
            this.textBox_ungdom.TextChanged += new System.EventHandler(this.textBox_ungdom_TextChanged);
            // 
            // textBox_barn
            // 
            this.textBox_barn.Location = new System.Drawing.Point(532, 376);
            this.textBox_barn.Name = "textBox_barn";
            this.textBox_barn.Size = new System.Drawing.Size(22, 20);
            this.textBox_barn.TabIndex = 4;
            this.textBox_barn.Text = "0";
            this.textBox_barn.TextChanged += new System.EventHandler(this.textBox_barn_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(560, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Fortsätt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_vuxen
            // 
            this.label_vuxen.AutoSize = true;
            this.label_vuxen.Location = new System.Drawing.Point(491, 331);
            this.label_vuxen.Name = "label_vuxen";
            this.label_vuxen.Size = new System.Drawing.Size(37, 13);
            this.label_vuxen.TabIndex = 6;
            this.label_vuxen.Text = "Vuxen";
            // 
            // label_ungdom
            // 
            this.label_ungdom.AutoSize = true;
            this.label_ungdom.Location = new System.Drawing.Point(481, 353);
            this.label_ungdom.Name = "label_ungdom";
            this.label_ungdom.Size = new System.Drawing.Size(47, 13);
            this.label_ungdom.TabIndex = 7;
            this.label_ungdom.Text = "Ungdom";
            // 
            // label_barn
            // 
            this.label_barn.AutoSize = true;
            this.label_barn.Location = new System.Drawing.Point(497, 376);
            this.label_barn.Name = "label_barn";
            this.label_barn.Size = new System.Drawing.Size(29, 13);
            this.label_barn.TabIndex = 8;
            this.label_barn.Text = "Barn";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(560, 402);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Reservation";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Totalt pris;";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(525, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Pris per föreställning:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Pris per akt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(416, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Vuxen";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(416, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Vuxen";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(416, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Vuxen";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 376);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Vuxen";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(287, 353);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Vuxen";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(287, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Vuxen";
            this.label10.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(623, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Logga ut";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Huvudsidan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 481);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label_barn);
            this.Controls.Add(this.label_ungdom);
            this.Controls.Add(this.label_vuxen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_barn);
            this.Controls.Add(this.textBox_ungdom);
            this.Controls.Add(this.textBox_vuxen);
            this.Controls.Add(this.listBox_akter);
            this.Controls.Add(this.listBox_forestallning);
            this.Name = "Huvudsidan";
            this.Text = "Huvudsidan";
            this.Load += new System.EventHandler(this.Huvudsidan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_forestallning;
        private System.Windows.Forms.ListBox listBox_akter;
        private System.Windows.Forms.TextBox textBox_vuxen;
        private System.Windows.Forms.TextBox textBox_ungdom;
        private System.Windows.Forms.TextBox textBox_barn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_vuxen;
        private System.Windows.Forms.Label label_ungdom;
        private System.Windows.Forms.Label label_barn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
    }
}
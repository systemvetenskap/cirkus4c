﻿namespace FirstTry
{
    partial class FormBehorigheter
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
            this.listBoxBehorighet = new System.Windows.Forms.ListBox();
            this.listBoxTabell = new System.Windows.Forms.ListBox();
            this.listBoxAnvandare = new System.Windows.Forms.ListBox();
            this.btnLaggTillBeh = new System.Windows.Forms.Button();
            this.btnTaBortBeh = new System.Windows.Forms.Button();
            this.lblBehorighet = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxBehorighet
            // 
            this.listBoxBehorighet.FormattingEnabled = true;
            this.listBoxBehorighet.Location = new System.Drawing.Point(13, 101);
            this.listBoxBehorighet.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxBehorighet.Name = "listBoxBehorighet";
            this.listBoxBehorighet.Size = new System.Drawing.Size(114, 147);
            this.listBoxBehorighet.TabIndex = 0;
            this.listBoxBehorighet.SelectedIndexChanged += new System.EventHandler(this.listBoxBehorighet_SelectedIndexChanged);
            // 
            // listBoxTabell
            // 
            this.listBoxTabell.FormattingEnabled = true;
            this.listBoxTabell.Location = new System.Drawing.Point(201, 101);
            this.listBoxTabell.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxTabell.Name = "listBoxTabell";
            this.listBoxTabell.Size = new System.Drawing.Size(114, 147);
            this.listBoxTabell.TabIndex = 1;
            this.listBoxTabell.SelectedIndexChanged += new System.EventHandler(this.listBoxTabell_SelectedIndexChanged);
            // 
            // listBoxAnvandare
            // 
            this.listBoxAnvandare.FormattingEnabled = true;
            this.listBoxAnvandare.Location = new System.Drawing.Point(374, 101);
            this.listBoxAnvandare.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxAnvandare.Name = "listBoxAnvandare";
            this.listBoxAnvandare.Size = new System.Drawing.Size(227, 147);
            this.listBoxAnvandare.TabIndex = 2;
            this.listBoxAnvandare.SelectedIndexChanged += new System.EventHandler(this.listBoxAnvandare_SelectedIndexChanged);
            // 
            // btnLaggTillBeh
            // 
            this.btnLaggTillBeh.Location = new System.Drawing.Point(201, 267);
            this.btnLaggTillBeh.Margin = new System.Windows.Forms.Padding(2);
            this.btnLaggTillBeh.Name = "btnLaggTillBeh";
            this.btnLaggTillBeh.Size = new System.Drawing.Size(114, 24);
            this.btnLaggTillBeh.TabIndex = 3;
            this.btnLaggTillBeh.Text = "Lägg till behörigheter";
            this.btnLaggTillBeh.UseVisualStyleBackColor = true;
            this.btnLaggTillBeh.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTaBortBeh
            // 
            this.btnTaBortBeh.Location = new System.Drawing.Point(13, 266);
            this.btnTaBortBeh.Margin = new System.Windows.Forms.Padding(2);
            this.btnTaBortBeh.Name = "btnTaBortBeh";
            this.btnTaBortBeh.Size = new System.Drawing.Size(114, 25);
            this.btnTaBortBeh.TabIndex = 4;
            this.btnTaBortBeh.Text = "Ta bort behörigheter";
            this.btnTaBortBeh.UseVisualStyleBackColor = true;
            this.btnTaBortBeh.Click += new System.EventHandler(this.btnTaBortBeh_Click);
            // 
            // lblBehorighet
            // 
            this.lblBehorighet.AutoSize = true;
            this.lblBehorighet.Location = new System.Drawing.Point(11, 75);
            this.lblBehorighet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBehorighet.Name = "lblBehorighet";
            this.lblBehorighet.Size = new System.Drawing.Size(132, 13);
            this.lblBehorighet.TabIndex = 52;
            this.lblBehorighet.Text = "Användarens behörigheter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Tillgängliga behörigheter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Användare";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(647, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Ny användare";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(650, 202);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(114, 20);
            this.textBox4.TabIndex = 58;
            this.textBox4.Text = "Användarenamn:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(650, 153);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(114, 20);
            this.textBox3.TabIndex = 57;
            this.textBox3.Text = "Personummer:";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(650, 127);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 20);
            this.textBox2.TabIndex = 56;
            this.textBox2.Text = "Efternamn:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(650, 101);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 20);
            this.textBox1.TabIndex = 55;
            this.textBox1.Text = "Förnamn:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(650, 228);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(114, 20);
            this.textBox5.TabIndex = 60;
            this.textBox5.Text = "användare";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(650, 266);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 24);
            this.button1.TabIndex = 61;
            this.button1.Text = "Skapa ny användare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 11);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 37);
            this.button2.TabIndex = 62;
            this.button2.Text = "Admin";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 11);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 37);
            this.button3.TabIndex = 63;
            this.button3.Text = "Biljetförsäljning";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormBehorigheter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 345);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBehorighet);
            this.Controls.Add(this.btnTaBortBeh);
            this.Controls.Add(this.btnLaggTillBeh);
            this.Controls.Add(this.listBoxAnvandare);
            this.Controls.Add(this.listBoxTabell);
            this.Controls.Add(this.listBoxBehorighet);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormBehorigheter";
            this.Text = "FormBehorigheter";
            this.Load += new System.EventHandler(this.FormBehorigheter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxBehorighet;
        private System.Windows.Forms.ListBox listBoxTabell;
        private System.Windows.Forms.ListBox listBoxAnvandare;
        private System.Windows.Forms.Button btnLaggTillBeh;
        private System.Windows.Forms.Button btnTaBortBeh;
        private System.Windows.Forms.Label lblBehorighet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
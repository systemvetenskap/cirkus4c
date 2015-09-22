﻿namespace FirstTry
{
    partial class AdminForm
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
            this.listBoxAdminForestallning = new System.Windows.Forms.ListBox();
            this.textBoxForestNamn = new System.Windows.Forms.TextBox();
            this.labelForestNamn = new System.Windows.Forms.Label();
            this.buttonLaggTillForest = new System.Windows.Forms.Button();
            this.listBoxAkter = new System.Windows.Forms.ListBox();
            this.buttonLaggTillAktInfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxAktInf = new System.Windows.Forms.RichTextBox();
            this.richTextBoxForestInf = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Lable3 = new System.Windows.Forms.Label();
            this.textBoxAktnamn = new System.Windows.Forms.TextBox();
            this.textBoxAktStarttid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAktSluttid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAktVuxenpris = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxForestStarttid = new System.Windows.Forms.TextBox();
            this.textBoxForestSluttid = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonOppnaForest = new System.Windows.Forms.Button();
            this.uppdatera = new System.Windows.Forms.Button();
            this.buttonTaBort = new System.Windows.Forms.Button();
            this.textBoxVuxenpris = new System.Windows.Forms.TextBox();
            this.textBoxUngdomspris = new System.Windows.Forms.TextBox();
            this.textBoxBarnpris = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonUppdateraAkt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxAktUngdPris = new System.Windows.Forms.TextBox();
            this.TextBoxAktBarnpris = new System.Windows.Forms.TextBox();
            this.btnSkapaForestallning = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxAdminForestallning
            // 
            this.listBoxAdminForestallning.FormattingEnabled = true;
            this.listBoxAdminForestallning.ItemHeight = 16;
            this.listBoxAdminForestallning.Location = new System.Drawing.Point(256, 50);
            this.listBoxAdminForestallning.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxAdminForestallning.Name = "listBoxAdminForestallning";
            this.listBoxAdminForestallning.Size = new System.Drawing.Size(223, 340);
            this.listBoxAdminForestallning.TabIndex = 0;
            this.listBoxAdminForestallning.SelectedIndexChanged += new System.EventHandler(this.listBoxAdminForestallning_SelectedIndexChanged);
            // 
            // textBoxForestNamn
            // 
            this.textBoxForestNamn.Location = new System.Drawing.Point(52, 71);
            this.textBoxForestNamn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxForestNamn.Name = "textBoxForestNamn";
            this.textBoxForestNamn.Size = new System.Drawing.Size(179, 22);
            this.textBoxForestNamn.TabIndex = 1;
            // 
            // labelForestNamn
            // 
            this.labelForestNamn.AutoSize = true;
            this.labelForestNamn.Location = new System.Drawing.Point(48, 50);
            this.labelForestNamn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelForestNamn.Name = "labelForestNamn";
            this.labelForestNamn.Size = new System.Drawing.Size(131, 17);
            this.labelForestNamn.TabIndex = 2;
            this.labelForestNamn.Text = "Föreställningsnamn";
            this.labelForestNamn.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonLaggTillForest
            // 
            this.buttonLaggTillForest.Enabled = false;
            this.buttonLaggTillForest.Location = new System.Drawing.Point(256, 509);
            this.buttonLaggTillForest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLaggTillForest.Name = "buttonLaggTillForest";
            this.buttonLaggTillForest.Size = new System.Drawing.Size(100, 28);
            this.buttonLaggTillForest.TabIndex = 3;
            this.buttonLaggTillForest.Text = "Lägg till ";
            this.buttonLaggTillForest.UseVisualStyleBackColor = true;
            this.buttonLaggTillForest.Visible = false;
            this.buttonLaggTillForest.Click += new System.EventHandler(this.buttonLaggTillForest_Click);
            // 
            // listBoxAkter
            // 
            this.listBoxAkter.FormattingEnabled = true;
            this.listBoxAkter.ItemHeight = 16;
            this.listBoxAkter.Location = new System.Drawing.Point(728, 50);
            this.listBoxAkter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxAkter.Name = "listBoxAkter";
            this.listBoxAkter.Size = new System.Drawing.Size(197, 340);
            this.listBoxAkter.TabIndex = 4;
            this.listBoxAkter.SelectedIndexChanged += new System.EventHandler(this.listBoxAkter_SelectedIndexChanged);
            // 
            // buttonLaggTillAktInfo
            // 
            this.buttonLaggTillAktInfo.Location = new System.Drawing.Point(793, 399);
            this.buttonLaggTillAktInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLaggTillAktInfo.Name = "buttonLaggTillAktInfo";
            this.buttonLaggTillAktInfo.Size = new System.Drawing.Size(133, 28);
            this.buttonLaggTillAktInfo.TabIndex = 6;
            this.buttonLaggTillAktInfo.Text = "Lägg till ";
            this.buttonLaggTillAktInfo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(528, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Aktinfo";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // richTextBoxAktInf
            // 
            this.richTextBoxAktInf.Location = new System.Drawing.Point(532, 135);
            this.richTextBoxAktInf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxAktInf.Name = "richTextBoxAktInf";
            this.richTextBoxAktInf.Size = new System.Drawing.Size(155, 85);
            this.richTextBoxAktInf.TabIndex = 8;
            this.richTextBoxAktInf.Text = "";
            // 
            // richTextBoxForestInf
            // 
            this.richTextBoxForestInf.Location = new System.Drawing.Point(52, 137);
            this.richTextBoxForestInf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxForestInf.Name = "richTextBoxForestInf";
            this.richTextBoxForestInf.Size = new System.Drawing.Size(179, 102);
            this.richTextBoxForestInf.TabIndex = 9;
            this.richTextBoxForestInf.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Föreställnings information";
            // 
            // Lable3
            // 
            this.Lable3.AutoSize = true;
            this.Lable3.Location = new System.Drawing.Point(528, 50);
            this.Lable3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lable3.Name = "Lable3";
            this.Lable3.Size = new System.Drawing.Size(63, 17);
            this.Lable3.TabIndex = 12;
            this.Lable3.Text = "Aktnamn";
            // 
            // textBoxAktnamn
            // 
            this.textBoxAktnamn.Location = new System.Drawing.Point(532, 71);
            this.textBoxAktnamn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAktnamn.Name = "textBoxAktnamn";
            this.textBoxAktnamn.Size = new System.Drawing.Size(155, 22);
            this.textBoxAktnamn.TabIndex = 13;
            // 
            // textBoxAktStarttid
            // 
            this.textBoxAktStarttid.Location = new System.Drawing.Point(535, 261);
            this.textBoxAktStarttid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAktStarttid.Name = "textBoxAktStarttid";
            this.textBoxAktStarttid.Size = new System.Drawing.Size(132, 22);
            this.textBoxAktStarttid.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(536, 239);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Starttid";
            // 
            // textBoxAktSluttid
            // 
            this.textBoxAktSluttid.Location = new System.Drawing.Point(533, 318);
            this.textBoxAktSluttid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAktSluttid.Name = "textBoxAktSluttid";
            this.textBoxAktSluttid.Size = new System.Drawing.Size(132, 22);
            this.textBoxAktSluttid.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(536, 299);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Sluttid";
            // 
            // textBoxAktVuxenpris
            // 
            this.textBoxAktVuxenpris.Location = new System.Drawing.Point(536, 372);
            this.textBoxAktVuxenpris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAktVuxenpris.Name = "textBoxAktVuxenpris";
            this.textBoxAktVuxenpris.Size = new System.Drawing.Size(132, 22);
            this.textBoxAktVuxenpris.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(536, 351);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Vuxenpris";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 267);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Starttid";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 314);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Sluttid";
            // 
            // textBoxForestStarttid
            // 
            this.textBoxForestStarttid.Location = new System.Drawing.Point(51, 288);
            this.textBoxForestStarttid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxForestStarttid.Name = "textBoxForestStarttid";
            this.textBoxForestStarttid.Size = new System.Drawing.Size(132, 22);
            this.textBoxForestStarttid.TabIndex = 22;
            // 
            // textBoxForestSluttid
            // 
            this.textBoxForestSluttid.Location = new System.Drawing.Point(52, 335);
            this.textBoxForestSluttid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxForestSluttid.Name = "textBoxForestSluttid";
            this.textBoxForestSluttid.Size = new System.Drawing.Size(132, 22);
            this.textBoxForestSluttid.TabIndex = 23;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(855, 516);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(154, 21);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Öppna föreställning";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonOppnaForest
            // 
            this.buttonOppnaForest.Location = new System.Drawing.Point(855, 549);
            this.buttonOppnaForest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOppnaForest.Name = "buttonOppnaForest";
            this.buttonOppnaForest.Size = new System.Drawing.Size(167, 33);
            this.buttonOppnaForest.TabIndex = 25;
            this.buttonOppnaForest.Text = "Öppna";
            this.buttonOppnaForest.UseVisualStyleBackColor = true;
            // 
            // uppdatera
            // 
            this.uppdatera.Location = new System.Drawing.Point(380, 468);
            this.uppdatera.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uppdatera.Name = "uppdatera";
            this.uppdatera.Size = new System.Drawing.Size(100, 28);
            this.uppdatera.TabIndex = 26;
            this.uppdatera.Text = "Uppdatera";
            this.uppdatera.UseVisualStyleBackColor = true;
            // 
            // buttonTaBort
            // 
            this.buttonTaBort.Location = new System.Drawing.Point(380, 511);
            this.buttonTaBort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonTaBort.Name = "buttonTaBort";
            this.buttonTaBort.Size = new System.Drawing.Size(100, 28);
            this.buttonTaBort.TabIndex = 27;
            this.buttonTaBort.Text = "Ta bort";
            this.buttonTaBort.UseVisualStyleBackColor = true;
            // 
            // textBoxVuxenpris
            // 
            this.textBoxVuxenpris.Location = new System.Drawing.Point(47, 401);
            this.textBoxVuxenpris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxVuxenpris.Name = "textBoxVuxenpris";
            this.textBoxVuxenpris.Size = new System.Drawing.Size(132, 22);
            this.textBoxVuxenpris.TabIndex = 28;
            // 
            // textBoxUngdomspris
            // 
            this.textBoxUngdomspris.Location = new System.Drawing.Point(47, 448);
            this.textBoxUngdomspris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUngdomspris.Name = "textBoxUngdomspris";
            this.textBoxUngdomspris.Size = new System.Drawing.Size(132, 22);
            this.textBoxUngdomspris.TabIndex = 29;
            // 
            // textBoxBarnpris
            // 
            this.textBoxBarnpris.Location = new System.Drawing.Point(47, 494);
            this.textBoxBarnpris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxBarnpris.Name = "textBoxBarnpris";
            this.textBoxBarnpris.Size = new System.Drawing.Size(132, 22);
            this.textBoxBarnpris.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 474);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Barnpris";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 427);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Ungdomspris";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(48, 377);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 33;
            this.label10.Text = "Vuxenpris";
            // 
            // buttonUppdateraAkt
            // 
            this.buttonUppdateraAkt.Location = new System.Drawing.Point(793, 434);
            this.buttonUppdateraAkt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUppdateraAkt.Name = "buttonUppdateraAkt";
            this.buttonUppdateraAkt.Size = new System.Drawing.Size(133, 28);
            this.buttonUppdateraAkt.TabIndex = 34;
            this.buttonUppdateraAkt.Text = "Uppdatera Akt";
            this.buttonUppdateraAkt.UseVisualStyleBackColor = true;
            this.buttonUppdateraAkt.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(827, 474);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 35;
            this.button1.Text = "Ta bort";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(536, 412);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 17);
            this.label11.TabIndex = 36;
            this.label11.Text = "Ungdomspris";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(536, 474);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 17);
            this.label12.TabIndex = 37;
            this.label12.Text = "Barnpris";
            // 
            // textBoxAktUngdPris
            // 
            this.textBoxAktUngdPris.Location = new System.Drawing.Point(535, 434);
            this.textBoxAktUngdPris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAktUngdPris.Name = "textBoxAktUngdPris";
            this.textBoxAktUngdPris.Size = new System.Drawing.Size(132, 22);
            this.textBoxAktUngdPris.TabIndex = 38;
            // 
            // TextBoxAktBarnpris
            // 
            this.TextBoxAktBarnpris.Location = new System.Drawing.Point(540, 494);
            this.TextBoxAktBarnpris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxAktBarnpris.Name = "TextBoxAktBarnpris";
            this.TextBoxAktBarnpris.Size = new System.Drawing.Size(132, 22);
            this.TextBoxAktBarnpris.TabIndex = 39;
            this.TextBoxAktBarnpris.TextChanged += new System.EventHandler(this.TextBoxAktBarnpris_TextChanged);
            // 
            // btnSkapaForestallning
            // 
            this.btnSkapaForestallning.Location = new System.Drawing.Point(256, 412);
            this.btnSkapaForestallning.Name = "btnSkapaForestallning";
            this.btnSkapaForestallning.Size = new System.Drawing.Size(224, 23);
            this.btnSkapaForestallning.TabIndex = 40;
            this.btnSkapaForestallning.Text = "Skapa föreställning";
            this.btnSkapaForestallning.UseVisualStyleBackColor = true;
            this.btnSkapaForestallning.Click += new System.EventHandler(this.btnSkapaForestallning_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 597);
            this.Controls.Add(this.btnSkapaForestallning);
            this.Controls.Add(this.TextBoxAktBarnpris);
            this.Controls.Add(this.textBoxAktUngdPris);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonUppdateraAkt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxBarnpris);
            this.Controls.Add(this.textBoxUngdomspris);
            this.Controls.Add(this.textBoxVuxenpris);
            this.Controls.Add(this.buttonTaBort);
            this.Controls.Add(this.uppdatera);
            this.Controls.Add(this.buttonOppnaForest);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBoxForestSluttid);
            this.Controls.Add(this.textBoxForestStarttid);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxAktVuxenpris);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxAktSluttid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxAktStarttid);
            this.Controls.Add(this.textBoxAktnamn);
            this.Controls.Add(this.Lable3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBoxForestInf);
            this.Controls.Add(this.richTextBoxAktInf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLaggTillAktInfo);
            this.Controls.Add(this.listBoxAkter);
            this.Controls.Add(this.buttonLaggTillForest);
            this.Controls.Add(this.labelForestNamn);
            this.Controls.Add(this.textBoxForestNamn);
            this.Controls.Add(this.listBoxAdminForestallning);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAdminForestallning;
        private System.Windows.Forms.TextBox textBoxForestNamn;
        private System.Windows.Forms.Label labelForestNamn;
        private System.Windows.Forms.Button buttonLaggTillForest;
        private System.Windows.Forms.ListBox listBoxAkter;
        private System.Windows.Forms.Button buttonLaggTillAktInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxAktInf;
        private System.Windows.Forms.RichTextBox richTextBoxForestInf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lable3;
        private System.Windows.Forms.TextBox textBoxAktnamn;
        private System.Windows.Forms.TextBox textBoxAktStarttid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAktSluttid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAktVuxenpris;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxForestStarttid;
        private System.Windows.Forms.TextBox textBoxForestSluttid;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonOppnaForest;
        private System.Windows.Forms.Button uppdatera;
        private System.Windows.Forms.Button buttonTaBort;
        private System.Windows.Forms.TextBox textBoxVuxenpris;
        private System.Windows.Forms.TextBox textBoxUngdomspris;
        private System.Windows.Forms.TextBox textBoxBarnpris;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonUppdateraAkt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxAktUngdPris;
        private System.Windows.Forms.TextBox TextBoxAktBarnpris;
        private System.Windows.Forms.Button btnSkapaForestallning;
    }
}
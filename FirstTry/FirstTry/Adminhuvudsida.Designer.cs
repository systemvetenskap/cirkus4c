﻿namespace FirstTry
{
    partial class Adminhuvudsida
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
            this.buttonTillHuvudsida = new System.Windows.Forms.Button();
            this.LabelOppen = new System.Windows.Forms.Label();
            this.buttonLoggaUt = new System.Windows.Forms.Button();
            this.listBoxForestallning = new System.Windows.Forms.ListBox();
            this.listBoxAkt = new System.Windows.Forms.ListBox();
            this.labelForestallning = new System.Windows.Forms.Label();
            this.labelForestallningsinfo = new System.Windows.Forms.Label();
            this.labelTillhorandeAkter = new System.Windows.Forms.Label();
            this.labelAktInfo = new System.Windows.Forms.Label();
            this.richTextBoxForestallning = new System.Windows.Forms.RichTextBox();
            this.richTextBoxAkter = new System.Windows.Forms.RichTextBox();
            this.buttonNyForestallning = new System.Windows.Forms.Button();
            this.buttonUppdateraForest = new System.Windows.Forms.Button();
            this.buttonTaBortForest = new System.Windows.Forms.Button();
            this.buttonOppnaForsaljning = new System.Windows.Forms.Button();
            this.buttonSkapaNyAkt = new System.Windows.Forms.Button();
            this.buttonUppdateraAkt = new System.Windows.Forms.Button();
            this.buttonTaBortAkt = new System.Windows.Forms.Button();
            this.buttonRapporter = new System.Windows.Forms.Button();
            this.buttonAndraBehorighet = new System.Windows.Forms.Button();
            this.buttonAdminhuvudsida = new System.Windows.Forms.Button();
            this.labelForsaljningsslut = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.SuspendLayout();
            // 
            // buttonTillHuvudsida
            // 
            this.buttonTillHuvudsida.Location = new System.Drawing.Point(28, 7);
            this.buttonTillHuvudsida.Name = "buttonTillHuvudsida";
            this.buttonTillHuvudsida.Size = new System.Drawing.Size(134, 30);
            this.buttonTillHuvudsida.TabIndex = 0;
            this.buttonTillHuvudsida.Text = "Biljettförsäljning";
            this.buttonTillHuvudsida.UseVisualStyleBackColor = true;
            this.buttonTillHuvudsida.Click += new System.EventHandler(this.buttonTillHuvudsida_Click);
            // 
            // LabelOppen
            // 
            this.LabelOppen.AutoSize = true;
            this.LabelOppen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LabelOppen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOppen.ForeColor = System.Drawing.Color.LimeGreen;
            this.LabelOppen.Location = new System.Drawing.Point(30, 54);
            this.LabelOppen.Name = "LabelOppen";
            this.LabelOppen.Size = new System.Drawing.Size(284, 20);
            this.LabelOppen.TabIndex = 1;
            this.LabelOppen.Text = "Föreställningen är öppen för försäljning";
            this.LabelOppen.Click += new System.EventHandler(this.LabelOppen_Click);
            // 
            // buttonLoggaUt
            // 
            this.buttonLoggaUt.Location = new System.Drawing.Point(772, 11);
            this.buttonLoggaUt.Name = "buttonLoggaUt";
            this.buttonLoggaUt.Size = new System.Drawing.Size(103, 26);
            this.buttonLoggaUt.TabIndex = 2;
            this.buttonLoggaUt.Text = "Logga ut";
            this.buttonLoggaUt.UseVisualStyleBackColor = true;
            this.buttonLoggaUt.Click += new System.EventHandler(this.buttonLoggaUt_Click);
            // 
            // listBoxForestallning
            // 
            this.listBoxForestallning.FormattingEnabled = true;
            this.listBoxForestallning.Location = new System.Drawing.Point(29, 106);
            this.listBoxForestallning.Name = "listBoxForestallning";
            this.listBoxForestallning.Size = new System.Drawing.Size(251, 394);
            this.listBoxForestallning.TabIndex = 3;
            this.listBoxForestallning.SelectedIndexChanged += new System.EventHandler(this.listBoxForestallning_SelectedIndexChanged);
            // 
            // listBoxAkt
            // 
            this.listBoxAkt.FormattingEnabled = true;
            this.listBoxAkt.Location = new System.Drawing.Point(476, 107);
            this.listBoxAkt.Name = "listBoxAkt";
            this.listBoxAkt.Size = new System.Drawing.Size(262, 394);
            this.listBoxAkt.TabIndex = 4;
            this.listBoxAkt.SelectedIndexChanged += new System.EventHandler(this.listBoxAkt_SelectedIndexChanged);
            // 
            // labelForestallning
            // 
            this.labelForestallning.AutoSize = true;
            this.labelForestallning.Location = new System.Drawing.Point(26, 84);
            this.labelForestallning.Name = "labelForestallning";
            this.labelForestallning.Size = new System.Drawing.Size(75, 13);
            this.labelForestallning.TabIndex = 5;
            this.labelForestallning.Text = "Föreställningar";
            this.labelForestallning.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelForestallningsinfo
            // 
            this.labelForestallningsinfo.AutoSize = true;
            this.labelForestallningsinfo.Location = new System.Drawing.Point(297, 84);
            this.labelForestallningsinfo.Name = "labelForestallningsinfo";
            this.labelForestallningsinfo.Size = new System.Drawing.Size(122, 13);
            this.labelForestallningsinfo.TabIndex = 6;
            this.labelForestallningsinfo.Text = "Föreställningsinformation";
            // 
            // labelTillhorandeAkter
            // 
            this.labelTillhorandeAkter.AutoSize = true;
            this.labelTillhorandeAkter.Location = new System.Drawing.Point(473, 84);
            this.labelTillhorandeAkter.Name = "labelTillhorandeAkter";
            this.labelTillhorandeAkter.Size = new System.Drawing.Size(86, 13);
            this.labelTillhorandeAkter.TabIndex = 7;
            this.labelTillhorandeAkter.Text = "Tillhörande akter";
            // 
            // labelAktInfo
            // 
            this.labelAktInfo.AutoSize = true;
            this.labelAktInfo.Location = new System.Drawing.Point(756, 84);
            this.labelAktInfo.Name = "labelAktInfo";
            this.labelAktInfo.Size = new System.Drawing.Size(40, 13);
            this.labelAktInfo.TabIndex = 8;
            this.labelAktInfo.Text = "Aktinfo";
            // 
            // richTextBoxForestallning
            // 
            this.richTextBoxForestallning.Location = new System.Drawing.Point(300, 106);
            this.richTextBoxForestallning.Name = "richTextBoxForestallning";
            this.richTextBoxForestallning.Size = new System.Drawing.Size(126, 193);
            this.richTextBoxForestallning.TabIndex = 9;
            this.richTextBoxForestallning.Text = "";
            // 
            // richTextBoxAkter
            // 
            this.richTextBoxAkter.Location = new System.Drawing.Point(759, 107);
            this.richTextBoxAkter.Name = "richTextBoxAkter";
            this.richTextBoxAkter.Size = new System.Drawing.Size(126, 233);
            this.richTextBoxAkter.TabIndex = 10;
            this.richTextBoxAkter.Text = "";
            // 
            // buttonNyForestallning
            // 
            this.buttonNyForestallning.Location = new System.Drawing.Point(301, 305);
            this.buttonNyForestallning.Name = "buttonNyForestallning";
            this.buttonNyForestallning.Size = new System.Drawing.Size(125, 44);
            this.buttonNyForestallning.TabIndex = 11;
            this.buttonNyForestallning.Text = "Skapa ny föreställning";
            this.buttonNyForestallning.UseVisualStyleBackColor = true;
            this.buttonNyForestallning.Click += new System.EventHandler(this.buttonNyForestallning_Click);
            // 
            // buttonUppdateraForest
            // 
            this.buttonUppdateraForest.Location = new System.Drawing.Point(301, 355);
            this.buttonUppdateraForest.Name = "buttonUppdateraForest";
            this.buttonUppdateraForest.Size = new System.Drawing.Size(125, 44);
            this.buttonUppdateraForest.TabIndex = 12;
            this.buttonUppdateraForest.Text = "Uppdatera Föreställning";
            this.buttonUppdateraForest.UseVisualStyleBackColor = true;
            this.buttonUppdateraForest.Click += new System.EventHandler(this.buttonUppdateraForest_Click);
            // 
            // buttonTaBortForest
            // 
            this.buttonTaBortForest.Location = new System.Drawing.Point(301, 405);
            this.buttonTaBortForest.Name = "buttonTaBortForest";
            this.buttonTaBortForest.Size = new System.Drawing.Size(125, 44);
            this.buttonTaBortForest.TabIndex = 13;
            this.buttonTaBortForest.Text = "Ta bort föreställning";
            this.buttonTaBortForest.UseVisualStyleBackColor = true;
            this.buttonTaBortForest.Click += new System.EventHandler(this.buttonTaBortForest_Click);
            // 
            // buttonOppnaForsaljning
            // 
            this.buttonOppnaForsaljning.Location = new System.Drawing.Point(301, 457);
            this.buttonOppnaForsaljning.Name = "buttonOppnaForsaljning";
            this.buttonOppnaForsaljning.Size = new System.Drawing.Size(125, 44);
            this.buttonOppnaForsaljning.TabIndex = 14;
            this.buttonOppnaForsaljning.Text = "Öppna försäljning";
            this.buttonOppnaForsaljning.UseVisualStyleBackColor = true;
            this.buttonOppnaForsaljning.Click += new System.EventHandler(this.buttonOppnaForsaljning_Click);
            // 
            // buttonSkapaNyAkt
            // 
            this.buttonSkapaNyAkt.Location = new System.Drawing.Point(760, 355);
            this.buttonSkapaNyAkt.Name = "buttonSkapaNyAkt";
            this.buttonSkapaNyAkt.Size = new System.Drawing.Size(125, 44);
            this.buttonSkapaNyAkt.TabIndex = 15;
            this.buttonSkapaNyAkt.Text = "Skapa ny akt";
            this.buttonSkapaNyAkt.UseVisualStyleBackColor = true;
            this.buttonSkapaNyAkt.Click += new System.EventHandler(this.buttonSkapaNyAkt_Click);
            // 
            // buttonUppdateraAkt
            // 
            this.buttonUppdateraAkt.Location = new System.Drawing.Point(760, 407);
            this.buttonUppdateraAkt.Name = "buttonUppdateraAkt";
            this.buttonUppdateraAkt.Size = new System.Drawing.Size(125, 44);
            this.buttonUppdateraAkt.TabIndex = 16;
            this.buttonUppdateraAkt.Text = "Uppdatera akt";
            this.buttonUppdateraAkt.UseVisualStyleBackColor = true;
            this.buttonUppdateraAkt.Click += new System.EventHandler(this.buttonUppdateraAkt_Click);
            // 
            // buttonTaBortAkt
            // 
            this.buttonTaBortAkt.Location = new System.Drawing.Point(760, 457);
            this.buttonTaBortAkt.Name = "buttonTaBortAkt";
            this.buttonTaBortAkt.Size = new System.Drawing.Size(125, 44);
            this.buttonTaBortAkt.TabIndex = 17;
            this.buttonTaBortAkt.Text = "Ta bort akt";
            this.buttonTaBortAkt.UseVisualStyleBackColor = true;
            this.buttonTaBortAkt.Click += new System.EventHandler(this.buttonTaBortAkt_Click);
            // 
            // buttonRapporter
            // 
            this.buttonRapporter.Location = new System.Drawing.Point(168, 7);
            this.buttonRapporter.Name = "buttonRapporter";
            this.buttonRapporter.Size = new System.Drawing.Size(125, 30);
            this.buttonRapporter.TabIndex = 18;
            this.buttonRapporter.Text = "Rapporter";
            this.buttonRapporter.UseVisualStyleBackColor = true;
            this.buttonRapporter.Click += new System.EventHandler(this.buttonRapporter_Click);
            // 
            // buttonAndraBehorighet
            // 
            this.buttonAndraBehorighet.Enabled = false;
            this.buttonAndraBehorighet.Location = new System.Drawing.Point(299, 7);
            this.buttonAndraBehorighet.Name = "buttonAndraBehorighet";
            this.buttonAndraBehorighet.Size = new System.Drawing.Size(125, 30);
            this.buttonAndraBehorighet.TabIndex = 19;
            this.buttonAndraBehorighet.Text = "Ändra behörighet";
            this.buttonAndraBehorighet.UseVisualStyleBackColor = true;
            this.buttonAndraBehorighet.Visible = false;
            this.buttonAndraBehorighet.Click += new System.EventHandler(this.buttonAndraBehorighet_Click);
            // 
            // buttonAdminhuvudsida
            // 
            this.buttonAdminhuvudsida.Enabled = false;
            this.buttonAdminhuvudsida.Location = new System.Drawing.Point(555, 12);
            this.buttonAdminhuvudsida.Name = "buttonAdminhuvudsida";
            this.buttonAdminhuvudsida.Size = new System.Drawing.Size(134, 30);
            this.buttonAdminhuvudsida.TabIndex = 20;
            this.buttonAdminhuvudsida.Text = "Administration";
            this.buttonAdminhuvudsida.UseVisualStyleBackColor = true;
            this.buttonAdminhuvudsida.Visible = false;
            this.buttonAdminhuvudsida.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelForsaljningsslut
            // 
            this.labelForsaljningsslut.AutoSize = true;
            this.labelForsaljningsslut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelForsaljningsslut.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelForsaljningsslut.Location = new System.Drawing.Point(304, 54);
            this.labelForsaljningsslut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelForsaljningsslut.Name = "labelForsaljningsslut";
            this.labelForsaljningsslut.Size = new System.Drawing.Size(152, 20);
            this.labelForsaljningsslut.TabIndex = 21;
            this.labelForsaljningsslut.Text = "labelForsaljningsslut";
            this.labelForsaljningsslut.Click += new System.EventHandler(this.labelForsaljningsslut_Click);
            // 
            // Adminhuvudsida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 577);
            this.Controls.Add(this.labelForsaljningsslut);
            this.Controls.Add(this.buttonAdminhuvudsida);
            this.Controls.Add(this.buttonAndraBehorighet);
            this.Controls.Add(this.buttonRapporter);
            this.Controls.Add(this.buttonTaBortAkt);
            this.Controls.Add(this.buttonUppdateraAkt);
            this.Controls.Add(this.buttonSkapaNyAkt);
            this.Controls.Add(this.buttonOppnaForsaljning);
            this.Controls.Add(this.buttonTaBortForest);
            this.Controls.Add(this.buttonUppdateraForest);
            this.Controls.Add(this.buttonNyForestallning);
            this.Controls.Add(this.richTextBoxAkter);
            this.Controls.Add(this.richTextBoxForestallning);
            this.Controls.Add(this.labelAktInfo);
            this.Controls.Add(this.labelTillhorandeAkter);
            this.Controls.Add(this.labelForestallningsinfo);
            this.Controls.Add(this.labelForestallning);
            this.Controls.Add(this.listBoxAkt);
            this.Controls.Add(this.listBoxForestallning);
            this.Controls.Add(this.buttonLoggaUt);
            this.Controls.Add(this.LabelOppen);
            this.Controls.Add(this.buttonTillHuvudsida);
            this.Name = "Adminhuvudsida";
            this.Text = "Adminhuvudsida";
            this.Load += new System.EventHandler(this.Adminhuvudsida_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTillHuvudsida;
        private System.Windows.Forms.Label LabelOppen;
        private System.Windows.Forms.Button buttonLoggaUt;
        private System.Windows.Forms.ListBox listBoxForestallning;
        private System.Windows.Forms.ListBox listBoxAkt;
        private System.Windows.Forms.Label labelForestallning;
        private System.Windows.Forms.Label labelForestallningsinfo;
        private System.Windows.Forms.Label labelTillhorandeAkter;
        private System.Windows.Forms.Label labelAktInfo;
        private System.Windows.Forms.RichTextBox richTextBoxForestallning;
        private System.Windows.Forms.RichTextBox richTextBoxAkter;
        private System.Windows.Forms.Button buttonNyForestallning;
        private System.Windows.Forms.Button buttonUppdateraForest;
        private System.Windows.Forms.Button buttonTaBortForest;
        private System.Windows.Forms.Button buttonOppnaForsaljning;
        private System.Windows.Forms.Button buttonSkapaNyAkt;
        private System.Windows.Forms.Button buttonUppdateraAkt;
        private System.Windows.Forms.Button buttonTaBortAkt;
        private System.Windows.Forms.Button buttonRapporter;
        private System.Windows.Forms.Button buttonAndraBehorighet;
        private System.Windows.Forms.Button buttonAdminhuvudsida;
        private System.Windows.Forms.Label labelForsaljningsslut;
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}
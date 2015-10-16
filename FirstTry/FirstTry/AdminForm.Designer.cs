namespace FirstTry
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
            this.label13 = new System.Windows.Forms.Label();
            this.checkBoxfriPlacering = new System.Windows.Forms.CheckBox();
            this.btnAndraTaBortBeh = new System.Windows.Forms.Button();
            this.textBoxForsaljningsslut = new System.Windows.Forms.TextBox();
            this.btnAkt = new System.Windows.Forms.Button();
            this.checkBoxForestallning1 = new System.Windows.Forms.CheckBox();
            this.textBoxForestDatum1 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btn_Huvud = new System.Windows.Forms.Button();
            this.lblforestallningoppen = new System.Windows.Forms.Label();
            this.buttonAdminhuvudsida = new System.Windows.Forms.Button();
            this.buttonLoggaUt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxAdminForestallning
            // 
            this.listBoxAdminForestallning.FormattingEnabled = true;
            this.listBoxAdminForestallning.ItemHeight = 16;
            this.listBoxAdminForestallning.Location = new System.Drawing.Point(251, 124);
            this.listBoxAdminForestallning.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxAdminForestallning.Name = "listBoxAdminForestallning";
            this.listBoxAdminForestallning.Size = new System.Drawing.Size(271, 484);
            this.listBoxAdminForestallning.TabIndex = 11;
            this.listBoxAdminForestallning.SelectedIndexChanged += new System.EventHandler(this.listBoxAdminForestallning_SelectedIndexChanged);
            // 
            // textBoxForestNamn
            // 
            this.textBoxForestNamn.Location = new System.Drawing.Point(37, 128);
            this.textBoxForestNamn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxForestNamn.Name = "textBoxForestNamn";
            this.textBoxForestNamn.Size = new System.Drawing.Size(179, 22);
            this.textBoxForestNamn.TabIndex = 1;
            this.textBoxForestNamn.TextChanged += new System.EventHandler(this.textBoxForestNamn_TextChanged);
            // 
            // labelForestNamn
            // 
            this.labelForestNamn.AutoSize = true;
            this.labelForestNamn.Location = new System.Drawing.Point(33, 108);
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
            this.buttonLaggTillForest.Location = new System.Drawing.Point(251, 629);
            this.buttonLaggTillForest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLaggTillForest.Name = "buttonLaggTillForest";
            this.buttonLaggTillForest.Size = new System.Drawing.Size(272, 28);
            this.buttonLaggTillForest.TabIndex = 13;
            this.buttonLaggTillForest.Text = "Skapa föreställning";
            this.buttonLaggTillForest.UseVisualStyleBackColor = true;
            this.buttonLaggTillForest.Visible = false;
            this.buttonLaggTillForest.Click += new System.EventHandler(this.buttonLaggTillForest_Click);
            // 
            // listBoxAkter
            // 
            this.listBoxAkter.FormattingEnabled = true;
            this.listBoxAkter.ItemHeight = 16;
            this.listBoxAkter.Location = new System.Drawing.Point(987, 124);
            this.listBoxAkter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxAkter.Name = "listBoxAkter";
            this.listBoxAkter.Size = new System.Drawing.Size(281, 484);
            this.listBoxAkter.TabIndex = 23;
            this.listBoxAkter.SelectedIndexChanged += new System.EventHandler(this.listBoxAkter_SelectedIndexChanged);
            // 
            // buttonLaggTillAktInfo
            // 
            this.buttonLaggTillAktInfo.Enabled = false;
            this.buttonLaggTillAktInfo.Location = new System.Drawing.Point(987, 625);
            this.buttonLaggTillAktInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLaggTillAktInfo.Name = "buttonLaggTillAktInfo";
            this.buttonLaggTillAktInfo.Size = new System.Drawing.Size(283, 28);
            this.buttonLaggTillAktInfo.TabIndex = 25;
            this.buttonLaggTillAktInfo.Text = "Skapa ny akt";
            this.buttonLaggTillAktInfo.UseVisualStyleBackColor = true;
            this.buttonLaggTillAktInfo.Visible = false;
            this.buttonLaggTillAktInfo.Click += new System.EventHandler(this.buttonLaggTillAktInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(684, 153);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Aktinfo";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // richTextBoxAktInf
            // 
            this.richTextBoxAktInf.Enabled = false;
            this.richTextBoxAktInf.Location = new System.Drawing.Point(688, 176);
            this.richTextBoxAktInf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxAktInf.Name = "richTextBoxAktInf";
            this.richTextBoxAktInf.Size = new System.Drawing.Size(179, 102);
            this.richTextBoxAktInf.TabIndex = 17;
            this.richTextBoxAktInf.Text = "";
            this.richTextBoxAktInf.Visible = false;
            this.richTextBoxAktInf.TextChanged += new System.EventHandler(this.richTextBoxAktInf_TextChanged);
            // 
            // richTextBoxForestInf
            // 
            this.richTextBoxForestInf.Location = new System.Drawing.Point(37, 176);
            this.richTextBoxForestInf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxForestInf.Name = "richTextBoxForestInf";
            this.richTextBoxForestInf.Size = new System.Drawing.Size(179, 102);
            this.richTextBoxForestInf.TabIndex = 2;
            this.richTextBoxForestInf.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Föreställnings information";
            // 
            // Lable3
            // 
            this.Lable3.AutoSize = true;
            this.Lable3.Location = new System.Drawing.Point(684, 105);
            this.Lable3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lable3.Name = "Lable3";
            this.Lable3.Size = new System.Drawing.Size(63, 17);
            this.Lable3.TabIndex = 12;
            this.Lable3.Text = "Aktnamn";
            this.Lable3.Visible = false;
            // 
            // textBoxAktnamn
            // 
            this.textBoxAktnamn.Enabled = false;
            this.textBoxAktnamn.Location = new System.Drawing.Point(688, 124);
            this.textBoxAktnamn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAktnamn.Name = "textBoxAktnamn";
            this.textBoxAktnamn.Size = new System.Drawing.Size(159, 22);
            this.textBoxAktnamn.TabIndex = 16;
            this.textBoxAktnamn.Visible = false;
            // 
            // textBoxAktStarttid
            // 
            this.textBoxAktStarttid.Enabled = false;
            this.textBoxAktStarttid.Location = new System.Drawing.Point(688, 368);
            this.textBoxAktStarttid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAktStarttid.Name = "textBoxAktStarttid";
            this.textBoxAktStarttid.Size = new System.Drawing.Size(159, 22);
            this.textBoxAktStarttid.TabIndex = 18;
            this.textBoxAktStarttid.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(684, 348);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Starttid HH:mm";
            this.label4.Visible = false;
            // 
            // textBoxAktSluttid
            // 
            this.textBoxAktSluttid.Enabled = false;
            this.textBoxAktSluttid.Location = new System.Drawing.Point(697, 441);
            this.textBoxAktSluttid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAktSluttid.Name = "textBoxAktSluttid";
            this.textBoxAktSluttid.Size = new System.Drawing.Size(159, 22);
            this.textBoxAktSluttid.TabIndex = 19;
            this.textBoxAktSluttid.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(693, 420);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Sluttid HH:mm";
            this.label5.Visible = false;
            // 
            // textBoxAktVuxenpris
            // 
            this.textBoxAktVuxenpris.Enabled = false;
            this.textBoxAktVuxenpris.Location = new System.Drawing.Point(697, 492);
            this.textBoxAktVuxenpris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAktVuxenpris.Name = "textBoxAktVuxenpris";
            this.textBoxAktVuxenpris.Size = new System.Drawing.Size(159, 22);
            this.textBoxAktVuxenpris.TabIndex = 20;
            this.textBoxAktVuxenpris.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(693, 469);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Vuxenpris";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 368);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Starttid HH:mm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 420);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Sluttid HH:mm";
            // 
            // textBoxForestStarttid
            // 
            this.textBoxForestStarttid.Enabled = false;
            this.textBoxForestStarttid.Location = new System.Drawing.Point(37, 393);
            this.textBoxForestStarttid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxForestStarttid.Name = "textBoxForestStarttid";
            this.textBoxForestStarttid.Size = new System.Drawing.Size(189, 22);
            this.textBoxForestStarttid.TabIndex = 4;
            this.textBoxForestStarttid.TextChanged += new System.EventHandler(this.textBoxForestStarttid_TextChanged);
            // 
            // textBoxForestSluttid
            // 
            this.textBoxForestSluttid.Enabled = false;
            this.textBoxForestSluttid.Location = new System.Drawing.Point(37, 441);
            this.textBoxForestSluttid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxForestSluttid.Name = "textBoxForestSluttid";
            this.textBoxForestSluttid.Size = new System.Drawing.Size(189, 22);
            this.textBoxForestSluttid.TabIndex = 5;
            this.textBoxForestSluttid.TextChanged += new System.EventHandler(this.textBoxForestSluttid_TextChanged);
            // 
            // uppdatera
            // 
            this.uppdatera.Enabled = false;
            this.uppdatera.Location = new System.Drawing.Point(251, 665);
            this.uppdatera.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uppdatera.Name = "uppdatera";
            this.uppdatera.Size = new System.Drawing.Size(272, 28);
            this.uppdatera.TabIndex = 14;
            this.uppdatera.Text = "Uppdatera föreställning";
            this.uppdatera.UseVisualStyleBackColor = true;
            this.uppdatera.Visible = false;
            this.uppdatera.Click += new System.EventHandler(this.uppdatera_Click);
            // 
            // buttonTaBort
            // 
            this.buttonTaBort.Enabled = false;
            this.buttonTaBort.Location = new System.Drawing.Point(251, 700);
            this.buttonTaBort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonTaBort.Name = "buttonTaBort";
            this.buttonTaBort.Size = new System.Drawing.Size(272, 28);
            this.buttonTaBort.TabIndex = 15;
            this.buttonTaBort.Text = "Ta bort föreställning";
            this.buttonTaBort.UseVisualStyleBackColor = true;
            this.buttonTaBort.Visible = false;
            this.buttonTaBort.Click += new System.EventHandler(this.buttonTaBort_Click);
            // 
            // textBoxVuxenpris
            // 
            this.textBoxVuxenpris.Enabled = false;
            this.textBoxVuxenpris.Location = new System.Drawing.Point(37, 492);
            this.textBoxVuxenpris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxVuxenpris.Name = "textBoxVuxenpris";
            this.textBoxVuxenpris.Size = new System.Drawing.Size(189, 22);
            this.textBoxVuxenpris.TabIndex = 6;
            this.textBoxVuxenpris.TextChanged += new System.EventHandler(this.textBoxVuxenpris_TextChanged);
            // 
            // textBoxUngdomspris
            // 
            this.textBoxUngdomspris.Enabled = false;
            this.textBoxUngdomspris.Location = new System.Drawing.Point(37, 545);
            this.textBoxUngdomspris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUngdomspris.Name = "textBoxUngdomspris";
            this.textBoxUngdomspris.Size = new System.Drawing.Size(189, 22);
            this.textBoxUngdomspris.TabIndex = 7;
            // 
            // textBoxBarnpris
            // 
            this.textBoxBarnpris.Enabled = false;
            this.textBoxBarnpris.Location = new System.Drawing.Point(37, 596);
            this.textBoxBarnpris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxBarnpris.Name = "textBoxBarnpris";
            this.textBoxBarnpris.Size = new System.Drawing.Size(189, 22);
            this.textBoxBarnpris.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 576);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Barnpris";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 522);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Ungdomspris";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 469);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 33;
            this.label10.Text = "Vuxenpris";
            // 
            // buttonUppdateraAkt
            // 
            this.buttonUppdateraAkt.Enabled = false;
            this.buttonUppdateraAkt.Location = new System.Drawing.Point(987, 661);
            this.buttonUppdateraAkt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUppdateraAkt.Name = "buttonUppdateraAkt";
            this.buttonUppdateraAkt.Size = new System.Drawing.Size(283, 28);
            this.buttonUppdateraAkt.TabIndex = 26;
            this.buttonUppdateraAkt.Text = "Uppdatera akt";
            this.buttonUppdateraAkt.UseVisualStyleBackColor = true;
            this.buttonUppdateraAkt.Visible = false;
            this.buttonUppdateraAkt.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(736, 700);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(283, 28);
            this.button1.TabIndex = 27;
            this.button1.Text = "Ta bort akt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(693, 522);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 17);
            this.label11.TabIndex = 36;
            this.label11.Text = "Ungdomspris";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(693, 576);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 17);
            this.label12.TabIndex = 37;
            this.label12.Text = "Barnpris";
            this.label12.Visible = false;
            // 
            // textBoxAktUngdPris
            // 
            this.textBoxAktUngdPris.Enabled = false;
            this.textBoxAktUngdPris.Location = new System.Drawing.Point(697, 545);
            this.textBoxAktUngdPris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAktUngdPris.Name = "textBoxAktUngdPris";
            this.textBoxAktUngdPris.Size = new System.Drawing.Size(159, 22);
            this.textBoxAktUngdPris.TabIndex = 21;
            this.textBoxAktUngdPris.Visible = false;
            // 
            // TextBoxAktBarnpris
            // 
            this.TextBoxAktBarnpris.Enabled = false;
            this.TextBoxAktBarnpris.Location = new System.Drawing.Point(697, 596);
            this.TextBoxAktBarnpris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxAktBarnpris.Name = "TextBoxAktBarnpris";
            this.TextBoxAktBarnpris.Size = new System.Drawing.Size(159, 22);
            this.TextBoxAktBarnpris.TabIndex = 22;
            this.TextBoxAktBarnpris.Visible = false;
            this.TextBoxAktBarnpris.TextChanged += new System.EventHandler(this.TextBoxAktBarnpris_TextChanged);
            // 
            // btnSkapaForestallning
            // 
            this.btnSkapaForestallning.Location = new System.Drawing.Point(251, 735);
            this.btnSkapaForestallning.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSkapaForestallning.Name = "btnSkapaForestallning";
            this.btnSkapaForestallning.Size = new System.Drawing.Size(272, 26);
            this.btnSkapaForestallning.TabIndex = 12;
            this.btnSkapaForestallning.Text = "Töm textfält föreställning";
            this.btnSkapaForestallning.UseVisualStyleBackColor = true;
            this.btnSkapaForestallning.Click += new System.EventHandler(this.btnSkapaForestallning_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 631);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(277, 17);
            this.label13.TabIndex = 43;
            this.label13.Text = "Sista försäljningsdag YYYY-mm-dd HH:mm";
            this.label13.Visible = false;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // checkBoxfriPlacering
            // 
            this.checkBoxfriPlacering.AutoSize = true;
            this.checkBoxfriPlacering.Enabled = false;
            this.checkBoxfriPlacering.Location = new System.Drawing.Point(37, 714);
            this.checkBoxfriPlacering.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxfriPlacering.Name = "checkBoxfriPlacering";
            this.checkBoxfriPlacering.Size = new System.Drawing.Size(108, 21);
            this.checkBoxfriPlacering.TabIndex = 10;
            this.checkBoxfriPlacering.Text = "Fri placering";
            this.checkBoxfriPlacering.UseVisualStyleBackColor = true;
            this.checkBoxfriPlacering.Visible = false;
            this.checkBoxfriPlacering.CheckedChanged += new System.EventHandler(this.checkBoxfriPlacering_CheckedChanged);
            // 
            // btnAndraTaBortBeh
            // 
            this.btnAndraTaBortBeh.Enabled = false;
            this.btnAndraTaBortBeh.Location = new System.Drawing.Point(433, 17);
            this.btnAndraTaBortBeh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAndraTaBortBeh.Name = "btnAndraTaBortBeh";
            this.btnAndraTaBortBeh.Size = new System.Drawing.Size(172, 37);
            this.btnAndraTaBortBeh.TabIndex = 28;
            this.btnAndraTaBortBeh.Text = "Ändra behörigheter";
            this.btnAndraTaBortBeh.UseVisualStyleBackColor = true;
            this.btnAndraTaBortBeh.Click += new System.EventHandler(this.btnAndraTaBortBeh_Click);
            // 
            // textBoxForsaljningsslut
            // 
            this.textBoxForsaljningsslut.Enabled = false;
            this.textBoxForsaljningsslut.Location = new System.Drawing.Point(37, 676);
            this.textBoxForsaljningsslut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxForsaljningsslut.Name = "textBoxForsaljningsslut";
            this.textBoxForsaljningsslut.Size = new System.Drawing.Size(189, 22);
            this.textBoxForsaljningsslut.TabIndex = 9;
            this.textBoxForsaljningsslut.Text = "yyyy-mm-dd hh:mm";
            this.textBoxForsaljningsslut.Visible = false;
            this.textBoxForsaljningsslut.TextChanged += new System.EventHandler(this.textBoxForsaljningsslut_TextChanged);
            // 
            // btnAkt
            // 
            this.btnAkt.Enabled = false;
            this.btnAkt.Location = new System.Drawing.Point(736, 735);
            this.btnAkt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAkt.Name = "btnAkt";
            this.btnAkt.Size = new System.Drawing.Size(283, 26);
            this.btnAkt.TabIndex = 24;
            this.btnAkt.Text = "Töm textfält akt";
            this.btnAkt.UseVisualStyleBackColor = true;
            this.btnAkt.Visible = false;
            this.btnAkt.Click += new System.EventHandler(this.btnAkt_Click);
            // 
            // checkBoxForestallning1
            // 
            this.checkBoxForestallning1.AutoSize = true;
            this.checkBoxForestallning1.Enabled = false;
            this.checkBoxForestallning1.Location = new System.Drawing.Point(37, 740);
            this.checkBoxForestallning1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxForestallning1.Name = "checkBoxForestallning1";
            this.checkBoxForestallning1.Size = new System.Drawing.Size(154, 21);
            this.checkBoxForestallning1.TabIndex = 84;
            this.checkBoxForestallning1.Text = "Öppna föreställning";
            this.checkBoxForestallning1.UseVisualStyleBackColor = true;
            this.checkBoxForestallning1.Visible = false;
            this.checkBoxForestallning1.CheckedChanged += new System.EventHandler(this.checkBoxForestallning1_CheckedChanged);
            // 
            // textBoxForestDatum1
            // 
            this.textBoxForestDatum1.Enabled = false;
            this.textBoxForestDatum1.Location = new System.Drawing.Point(37, 340);
            this.textBoxForestDatum1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxForestDatum1.Name = "textBoxForestDatum1";
            this.textBoxForestDatum1.Size = new System.Drawing.Size(189, 22);
            this.textBoxForestDatum1.TabIndex = 85;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(44, 316);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(137, 17);
            this.label28.TabIndex = 86;
            this.label28.Text = "Datum YYYY-mm-dd";
            // 
            // btn_Huvud
            // 
            this.btn_Huvud.Location = new System.Drawing.Point(47, 17);
            this.btn_Huvud.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Huvud.Name = "btn_Huvud";
            this.btn_Huvud.Size = new System.Drawing.Size(172, 37);
            this.btn_Huvud.TabIndex = 88;
            this.btn_Huvud.Text = "Tillbaka till Huvudsidan";
            this.btn_Huvud.UseVisualStyleBackColor = true;
            this.btn_Huvud.Click += new System.EventHandler(this.btn_Huvud_Click);
            // 
            // lblforestallningoppen
            // 
            this.lblforestallningoppen.AutoSize = true;
            this.lblforestallningoppen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblforestallningoppen.ForeColor = System.Drawing.Color.Green;
            this.lblforestallningoppen.Location = new System.Drawing.Point(43, 73);
            this.lblforestallningoppen.Name = "lblforestallningoppen";
            this.lblforestallningoppen.Size = new System.Drawing.Size(227, 25);
            this.lblforestallningoppen.TabIndex = 46;
            this.lblforestallningoppen.Text = "Föreställningen är öppen";
            this.lblforestallningoppen.Visible = false;
            this.lblforestallningoppen.Click += new System.EventHandler(this.label14_Click);
            // 
            // buttonAdminhuvudsida
            // 
            this.buttonAdminhuvudsida.Location = new System.Drawing.Point(236, 17);
            this.buttonAdminhuvudsida.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAdminhuvudsida.Name = "buttonAdminhuvudsida";
            this.buttonAdminhuvudsida.Size = new System.Drawing.Size(179, 37);
            this.buttonAdminhuvudsida.TabIndex = 89;
            this.buttonAdminhuvudsida.Text = "Administration";
            this.buttonAdminhuvudsida.UseVisualStyleBackColor = true;
            this.buttonAdminhuvudsida.Click += new System.EventHandler(this.buttonAdminhuvudsida_Click);
            // 
            // buttonLoggaUt
            // 
            this.buttonLoggaUt.Location = new System.Drawing.Point(619, 17);
            this.buttonLoggaUt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLoggaUt.Name = "buttonLoggaUt";
            this.buttonLoggaUt.Size = new System.Drawing.Size(172, 37);
            this.buttonLoggaUt.TabIndex = 90;
            this.buttonLoggaUt.Text = "Logga ut";
            this.buttonLoggaUt.UseVisualStyleBackColor = true;
            this.buttonLoggaUt.Click += new System.EventHandler(this.buttonLoggaUt_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1676, 791);
            this.Controls.Add(this.buttonLoggaUt);
            this.Controls.Add(this.buttonAdminhuvudsida);
            this.Controls.Add(this.btn_Huvud);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.textBoxForestDatum1);
            this.Controls.Add(this.checkBoxForestallning1);
            this.Controls.Add(this.btnAkt);
            this.Controls.Add(this.textBoxForsaljningsslut);
            this.Controls.Add(this.btnAndraTaBortBeh);
            this.Controls.Add(this.lblforestallningoppen);
            this.Controls.Add(this.checkBoxfriPlacering);
            this.Controls.Add(this.label13);
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
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBoxfriPlacering;
        private System.Windows.Forms.Button btnAndraTaBortBeh;
        private System.Windows.Forms.TextBox textBoxForsaljningsslut;
        private System.Windows.Forms.Button btnAkt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxForestDatum;
        //private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBoxForestallning;
        private System.Windows.Forms.CheckBox checkBoxForestallning1;
        private System.Windows.Forms.TextBox textBoxForestDatum1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btn_Huvud;
        private System.Windows.Forms.Label lblforestallningoppen;
        private System.Windows.Forms.Button buttonAdminhuvudsida;
        private System.Windows.Forms.Button buttonLoggaUt;
    }
}
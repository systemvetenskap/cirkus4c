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
            this.textBoxVuxenpris = new System.Windows.Forms.TextBox();
            this.textBoxUngdomspris = new System.Windows.Forms.TextBox();
            this.textBoxBarnpris = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonUppdateraAkt = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxAktUngdPris = new System.Windows.Forms.TextBox();
            this.TextBoxAktBarnpris = new System.Windows.Forms.TextBox();
            this.btnSkapaForestallning = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBoxfriPlacering = new System.Windows.Forms.CheckBox();
            this.btnAndraTaBortBeh = new System.Windows.Forms.Button();
            this.textBoxForsaljningsslut = new System.Windows.Forms.TextBox();
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
            this.listBoxAdminForestallning.Location = new System.Drawing.Point(188, 101);
            this.listBoxAdminForestallning.Name = "listBoxAdminForestallning";
            this.listBoxAdminForestallning.Size = new System.Drawing.Size(266, 394);
            this.listBoxAdminForestallning.TabIndex = 11;
            this.listBoxAdminForestallning.SelectedIndexChanged += new System.EventHandler(this.listBoxAdminForestallning_SelectedIndexChanged);
            // 
            // textBoxForestNamn
            // 
            this.textBoxForestNamn.Location = new System.Drawing.Point(31, 104);
            this.textBoxForestNamn.Name = "textBoxForestNamn";
            this.textBoxForestNamn.Size = new System.Drawing.Size(132, 20);
            this.textBoxForestNamn.TabIndex = 1;
            this.textBoxForestNamn.Visible = false;
            this.textBoxForestNamn.TextChanged += new System.EventHandler(this.textBoxForestNamn_TextChanged);
            // 
            // labelForestNamn
            // 
            this.labelForestNamn.AutoSize = true;
            this.labelForestNamn.Location = new System.Drawing.Point(25, 88);
            this.labelForestNamn.Name = "labelForestNamn";
            this.labelForestNamn.Size = new System.Drawing.Size(97, 13);
            this.labelForestNamn.TabIndex = 2;
            this.labelForestNamn.Text = "Föreställningsnamn";
            this.labelForestNamn.Visible = false;
            this.labelForestNamn.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonLaggTillForest
            // 
            this.buttonLaggTillForest.Enabled = false;
            this.buttonLaggTillForest.Location = new System.Drawing.Point(188, 511);
            this.buttonLaggTillForest.Name = "buttonLaggTillForest";
            this.buttonLaggTillForest.Size = new System.Drawing.Size(266, 23);
            this.buttonLaggTillForest.TabIndex = 13;
            this.buttonLaggTillForest.Text = "Skapa föreställning";
            this.buttonLaggTillForest.UseVisualStyleBackColor = true;
            this.buttonLaggTillForest.Visible = false;
            this.buttonLaggTillForest.Click += new System.EventHandler(this.buttonLaggTillForest_Click);
            // 
            // listBoxAkter
            // 
            this.listBoxAkter.FormattingEnabled = true;
            this.listBoxAkter.Location = new System.Drawing.Point(687, 101);
            this.listBoxAkter.Name = "listBoxAkter";
            this.listBoxAkter.Size = new System.Drawing.Size(265, 394);
            this.listBoxAkter.TabIndex = 23;
            this.listBoxAkter.SelectedIndexChanged += new System.EventHandler(this.listBoxAkter_SelectedIndexChanged);
            // 
            // buttonLaggTillAktInfo
            // 
            this.buttonLaggTillAktInfo.Enabled = false;
            this.buttonLaggTillAktInfo.Location = new System.Drawing.Point(687, 511);
            this.buttonLaggTillAktInfo.Name = "buttonLaggTillAktInfo";
            this.buttonLaggTillAktInfo.Size = new System.Drawing.Size(265, 23);
            this.buttonLaggTillAktInfo.TabIndex = 25;
            this.buttonLaggTillAktInfo.Text = "Skapa ny akt";
            this.buttonLaggTillAktInfo.UseVisualStyleBackColor = true;
            this.buttonLaggTillAktInfo.Visible = false;
            this.buttonLaggTillAktInfo.Click += new System.EventHandler(this.buttonLaggTillAktInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(513, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Aktinfo";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // richTextBoxAktInf
            // 
            this.richTextBoxAktInf.Enabled = false;
            this.richTextBoxAktInf.Location = new System.Drawing.Point(516, 143);
            this.richTextBoxAktInf.Name = "richTextBoxAktInf";
            this.richTextBoxAktInf.Size = new System.Drawing.Size(135, 127);
            this.richTextBoxAktInf.TabIndex = 17;
            this.richTextBoxAktInf.Text = "";
            this.richTextBoxAktInf.Visible = false;
            this.richTextBoxAktInf.TextChanged += new System.EventHandler(this.richTextBoxAktInf_TextChanged);
            // 
            // richTextBoxForestInf
            // 
            this.richTextBoxForestInf.Location = new System.Drawing.Point(28, 143);
            this.richTextBoxForestInf.Name = "richTextBoxForestInf";
            this.richTextBoxForestInf.Size = new System.Drawing.Size(135, 84);
            this.richTextBoxForestInf.TabIndex = 2;
            this.richTextBoxForestInf.Text = "";
            this.richTextBoxForestInf.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Föreställnings information";
            this.label2.Visible = false;
            // 
            // Lable3
            // 
            this.Lable3.AutoSize = true;
            this.Lable3.Location = new System.Drawing.Point(513, 85);
            this.Lable3.Name = "Lable3";
            this.Lable3.Size = new System.Drawing.Size(49, 13);
            this.Lable3.TabIndex = 12;
            this.Lable3.Text = "Aktnamn";
            this.Lable3.Visible = false;
            // 
            // textBoxAktnamn
            // 
            this.textBoxAktnamn.Enabled = false;
            this.textBoxAktnamn.Location = new System.Drawing.Point(516, 101);
            this.textBoxAktnamn.Name = "textBoxAktnamn";
            this.textBoxAktnamn.Size = new System.Drawing.Size(135, 20);
            this.textBoxAktnamn.TabIndex = 16;
            this.textBoxAktnamn.Visible = false;
            // 
            // textBoxAktStarttid
            // 
            this.textBoxAktStarttid.Enabled = false;
            this.textBoxAktStarttid.Location = new System.Drawing.Point(516, 299);
            this.textBoxAktStarttid.Name = "textBoxAktStarttid";
            this.textBoxAktStarttid.Size = new System.Drawing.Size(135, 20);
            this.textBoxAktStarttid.TabIndex = 18;
            this.textBoxAktStarttid.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Starttid HH:mm";
            this.label4.Visible = false;
            // 
            // textBoxAktSluttid
            // 
            this.textBoxAktSluttid.Enabled = false;
            this.textBoxAktSluttid.Location = new System.Drawing.Point(516, 358);
            this.textBoxAktSluttid.Name = "textBoxAktSluttid";
            this.textBoxAktSluttid.Size = new System.Drawing.Size(135, 20);
            this.textBoxAktSluttid.TabIndex = 19;
            this.textBoxAktSluttid.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(520, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Sluttid HH:mm";
            this.label5.Visible = false;
            // 
            // textBoxAktVuxenpris
            // 
            this.textBoxAktVuxenpris.Enabled = false;
            this.textBoxAktVuxenpris.Location = new System.Drawing.Point(516, 400);
            this.textBoxAktVuxenpris.Name = "textBoxAktVuxenpris";
            this.textBoxAktVuxenpris.Size = new System.Drawing.Size(135, 20);
            this.textBoxAktVuxenpris.TabIndex = 20;
            this.textBoxAktVuxenpris.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(520, 381);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Vuxenpris";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 299);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Starttid HH:mm";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 341);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Sluttid HH:mm";
            this.label8.Visible = false;
            // 
            // textBoxForestStarttid
            // 
            this.textBoxForestStarttid.Enabled = false;
            this.textBoxForestStarttid.Location = new System.Drawing.Point(28, 319);
            this.textBoxForestStarttid.Name = "textBoxForestStarttid";
            this.textBoxForestStarttid.Size = new System.Drawing.Size(135, 20);
            this.textBoxForestStarttid.TabIndex = 4;
            this.textBoxForestStarttid.Visible = false;
            this.textBoxForestStarttid.TextChanged += new System.EventHandler(this.textBoxForestStarttid_TextChanged);
            // 
            // textBoxForestSluttid
            // 
            this.textBoxForestSluttid.Enabled = false;
            this.textBoxForestSluttid.Location = new System.Drawing.Point(28, 358);
            this.textBoxForestSluttid.Name = "textBoxForestSluttid";
            this.textBoxForestSluttid.Size = new System.Drawing.Size(135, 20);
            this.textBoxForestSluttid.TabIndex = 5;
            this.textBoxForestSluttid.Visible = false;
            this.textBoxForestSluttid.TextChanged += new System.EventHandler(this.textBoxForestSluttid_TextChanged);
            // 
            // uppdatera
            // 
            this.uppdatera.AutoEllipsis = true;
            this.uppdatera.Enabled = false;
            this.uppdatera.Location = new System.Drawing.Point(188, 540);
            this.uppdatera.Name = "uppdatera";
            this.uppdatera.Size = new System.Drawing.Size(266, 23);
            this.uppdatera.TabIndex = 14;
            this.uppdatera.Text = "Uppdatera föreställning";
            this.uppdatera.UseVisualStyleBackColor = true;
            this.uppdatera.Visible = false;
            this.uppdatera.Click += new System.EventHandler(this.uppdatera_Click);
            // 
            // textBoxVuxenpris
            // 
            this.textBoxVuxenpris.Enabled = false;
            this.textBoxVuxenpris.Location = new System.Drawing.Point(28, 397);
            this.textBoxVuxenpris.Name = "textBoxVuxenpris";
            this.textBoxVuxenpris.Size = new System.Drawing.Size(136, 20);
            this.textBoxVuxenpris.TabIndex = 6;
            this.textBoxVuxenpris.Visible = false;
            this.textBoxVuxenpris.TextChanged += new System.EventHandler(this.textBoxVuxenpris_TextChanged);
            // 
            // textBoxUngdomspris
            // 
            this.textBoxUngdomspris.Enabled = false;
            this.textBoxUngdomspris.Location = new System.Drawing.Point(28, 436);
            this.textBoxUngdomspris.Name = "textBoxUngdomspris";
            this.textBoxUngdomspris.Size = new System.Drawing.Size(136, 20);
            this.textBoxUngdomspris.TabIndex = 7;
            this.textBoxUngdomspris.Visible = false;
            // 
            // textBoxBarnpris
            // 
            this.textBoxBarnpris.Enabled = false;
            this.textBoxBarnpris.Location = new System.Drawing.Point(31, 475);
            this.textBoxBarnpris.Name = "textBoxBarnpris";
            this.textBoxBarnpris.Size = new System.Drawing.Size(136, 20);
            this.textBoxBarnpris.TabIndex = 8;
            this.textBoxBarnpris.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Barnpris";
            this.label3.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 420);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Ungdomspris";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 381);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Vuxenpris";
            this.label10.Visible = false;
            // 
            // buttonUppdateraAkt
            // 
            this.buttonUppdateraAkt.Enabled = false;
            this.buttonUppdateraAkt.Location = new System.Drawing.Point(687, 538);
            this.buttonUppdateraAkt.Name = "buttonUppdateraAkt";
            this.buttonUppdateraAkt.Size = new System.Drawing.Size(265, 23);
            this.buttonUppdateraAkt.TabIndex = 26;
            this.buttonUppdateraAkt.Text = "Uppdatera akt";
            this.buttonUppdateraAkt.UseVisualStyleBackColor = true;
            this.buttonUppdateraAkt.Visible = false;
            this.buttonUppdateraAkt.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(520, 424);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "Ungdomspris";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(520, 468);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Barnpris";
            this.label12.Visible = false;
            // 
            // textBoxAktUngdPris
            // 
            this.textBoxAktUngdPris.Enabled = false;
            this.textBoxAktUngdPris.Location = new System.Drawing.Point(516, 443);
            this.textBoxAktUngdPris.Name = "textBoxAktUngdPris";
            this.textBoxAktUngdPris.Size = new System.Drawing.Size(135, 20);
            this.textBoxAktUngdPris.TabIndex = 21;
            this.textBoxAktUngdPris.Visible = false;
            // 
            // TextBoxAktBarnpris
            // 
            this.TextBoxAktBarnpris.Enabled = false;
            this.TextBoxAktBarnpris.Location = new System.Drawing.Point(516, 484);
            this.TextBoxAktBarnpris.Name = "TextBoxAktBarnpris";
            this.TextBoxAktBarnpris.Size = new System.Drawing.Size(135, 20);
            this.TextBoxAktBarnpris.TabIndex = 22;
            this.TextBoxAktBarnpris.Visible = false;
            this.TextBoxAktBarnpris.TextChanged += new System.EventHandler(this.TextBoxAktBarnpris_TextChanged);
            // 
            // btnSkapaForestallning
            // 
            this.btnSkapaForestallning.Location = new System.Drawing.Point(516, 540);
            this.btnSkapaForestallning.Margin = new System.Windows.Forms.Padding(2);
            this.btnSkapaForestallning.Name = "btnSkapaForestallning";
            this.btnSkapaForestallning.Size = new System.Drawing.Size(135, 21);
            this.btnSkapaForestallning.TabIndex = 12;
            this.btnSkapaForestallning.Text = "Töm textfält";
            this.btnSkapaForestallning.UseVisualStyleBackColor = true;
            this.btnSkapaForestallning.Click += new System.EventHandler(this.btnSkapaForestallning_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 513);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(206, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "Sista försäljningsdag YYYY-mm-dd HH:mm";
            this.label13.Visible = false;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // checkBoxfriPlacering
            // 
            this.checkBoxfriPlacering.AutoSize = true;
            this.checkBoxfriPlacering.Enabled = false;
            this.checkBoxfriPlacering.Location = new System.Drawing.Point(28, 580);
            this.checkBoxfriPlacering.Name = "checkBoxfriPlacering";
            this.checkBoxfriPlacering.Size = new System.Drawing.Size(83, 17);
            this.checkBoxfriPlacering.TabIndex = 10;
            this.checkBoxfriPlacering.Text = "Fri placering";
            this.checkBoxfriPlacering.UseVisualStyleBackColor = true;
            this.checkBoxfriPlacering.Visible = false;
            this.checkBoxfriPlacering.CheckedChanged += new System.EventHandler(this.checkBoxfriPlacering_CheckedChanged);
            // 
            // btnAndraTaBortBeh
            // 
            this.btnAndraTaBortBeh.Enabled = false;
            this.btnAndraTaBortBeh.Location = new System.Drawing.Point(325, 14);
            this.btnAndraTaBortBeh.Margin = new System.Windows.Forms.Padding(2);
            this.btnAndraTaBortBeh.Name = "btnAndraTaBortBeh";
            this.btnAndraTaBortBeh.Size = new System.Drawing.Size(129, 30);
            this.btnAndraTaBortBeh.TabIndex = 28;
            this.btnAndraTaBortBeh.Text = "Ändra behörigheter";
            this.btnAndraTaBortBeh.UseVisualStyleBackColor = true;
            this.btnAndraTaBortBeh.Click += new System.EventHandler(this.btnAndraTaBortBeh_Click);
            // 
            // textBoxForsaljningsslut
            // 
            this.textBoxForsaljningsslut.Enabled = false;
            this.textBoxForsaljningsslut.Location = new System.Drawing.Point(28, 549);
            this.textBoxForsaljningsslut.Name = "textBoxForsaljningsslut";
            this.textBoxForsaljningsslut.Size = new System.Drawing.Size(143, 20);
            this.textBoxForsaljningsslut.TabIndex = 9;
            this.textBoxForsaljningsslut.Text = "yyyy-mm-dd hh:mm";
            this.textBoxForsaljningsslut.Visible = false;
            this.textBoxForsaljningsslut.TextChanged += new System.EventHandler(this.textBoxForsaljningsslut_TextChanged);
            // 
            // checkBoxForestallning1
            // 
            this.checkBoxForestallning1.AutoSize = true;
            this.checkBoxForestallning1.Enabled = false;
            this.checkBoxForestallning1.Location = new System.Drawing.Point(28, 601);
            this.checkBoxForestallning1.Name = "checkBoxForestallning1";
            this.checkBoxForestallning1.Size = new System.Drawing.Size(117, 17);
            this.checkBoxForestallning1.TabIndex = 84;
            this.checkBoxForestallning1.Text = "Öppna föreställning";
            this.checkBoxForestallning1.UseVisualStyleBackColor = true;
            this.checkBoxForestallning1.Visible = false;
            this.checkBoxForestallning1.CheckedChanged += new System.EventHandler(this.checkBoxForestallning1_CheckedChanged);
            // 
            // textBoxForestDatum1
            // 
            this.textBoxForestDatum1.Enabled = false;
            this.textBoxForestDatum1.Location = new System.Drawing.Point(28, 276);
            this.textBoxForestDatum1.Name = "textBoxForestDatum1";
            this.textBoxForestDatum1.Size = new System.Drawing.Size(135, 20);
            this.textBoxForestDatum1.TabIndex = 85;
            this.textBoxForestDatum1.Visible = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(30, 246);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(103, 13);
            this.label28.TabIndex = 86;
            this.label28.Text = "Datum YYYY-mm-dd";
            this.label28.Visible = false;
            // 
            // btn_Huvud
            // 
            this.btn_Huvud.Location = new System.Drawing.Point(35, 14);
            this.btn_Huvud.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Huvud.Name = "btn_Huvud";
            this.btn_Huvud.Size = new System.Drawing.Size(129, 30);
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
            this.lblforestallningoppen.Location = new System.Drawing.Point(32, 59);
            this.lblforestallningoppen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblforestallningoppen.Name = "lblforestallningoppen";
            this.lblforestallningoppen.Size = new System.Drawing.Size(185, 20);
            this.lblforestallningoppen.TabIndex = 46;
            this.lblforestallningoppen.Text = "Föreställningen är öppen";
            this.lblforestallningoppen.Visible = false;
            this.lblforestallningoppen.Click += new System.EventHandler(this.label14_Click);
            // 
            // buttonAdminhuvudsida
            // 
            this.buttonAdminhuvudsida.Location = new System.Drawing.Point(177, 14);
            this.buttonAdminhuvudsida.Name = "buttonAdminhuvudsida";
            this.buttonAdminhuvudsida.Size = new System.Drawing.Size(134, 30);
            this.buttonAdminhuvudsida.TabIndex = 89;
            this.buttonAdminhuvudsida.Text = "Administration";
            this.buttonAdminhuvudsida.UseVisualStyleBackColor = true;
            this.buttonAdminhuvudsida.Click += new System.EventHandler(this.buttonAdminhuvudsida_Click);
            // 
            // buttonLoggaUt
            // 
            this.buttonLoggaUt.Location = new System.Drawing.Point(464, 14);
            this.buttonLoggaUt.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoggaUt.Name = "buttonLoggaUt";
            this.buttonLoggaUt.Size = new System.Drawing.Size(129, 30);
            this.buttonLoggaUt.TabIndex = 90;
            this.buttonLoggaUt.Text = "Logga ut";
            this.buttonLoggaUt.UseVisualStyleBackColor = true;
            this.buttonLoggaUt.Click += new System.EventHandler(this.buttonLoggaUt_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 566);
            this.Controls.Add(this.buttonLoggaUt);
            this.Controls.Add(this.buttonAdminhuvudsida);
            this.Controls.Add(this.btn_Huvud);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.textBoxForestDatum1);
            this.Controls.Add(this.checkBoxForestallning1);
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
            this.Controls.Add(this.buttonUppdateraAkt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxBarnpris);
            this.Controls.Add(this.textBoxUngdomspris);
            this.Controls.Add(this.textBoxVuxenpris);
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
        private System.Windows.Forms.TextBox textBoxVuxenpris;
        private System.Windows.Forms.TextBox textBoxUngdomspris;
        private System.Windows.Forms.TextBox textBoxBarnpris;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonUppdateraAkt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxAktUngdPris;
        private System.Windows.Forms.TextBox TextBoxAktBarnpris;
        private System.Windows.Forms.Button btnSkapaForestallning;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBoxfriPlacering;
        private System.Windows.Forms.Button btnAndraTaBortBeh;
        private System.Windows.Forms.TextBox textBoxForsaljningsslut;
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
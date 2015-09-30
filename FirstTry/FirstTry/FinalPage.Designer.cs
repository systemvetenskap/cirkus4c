namespace FirstTry
{
    partial class FinalPage
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_epost = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox_kunder = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(211, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(725, 542);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 442);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Skicka som e-post";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(47, 511);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Skriv ut";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_epost
            // 
            this.textBox_epost.Location = new System.Drawing.Point(47, 405);
            this.textBox_epost.Name = "textBox_epost";
            this.textBox_epost.Size = new System.Drawing.Size(105, 20);
            this.textBox_epost.TabIndex = 3;
            this.textBox_epost.Text = "E-post:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(47, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 40);
            this.button3.TabIndex = 4;
            this.button3.Text = "Tillbaka till huvudsidan";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox_kunder
            // 
            this.listBox_kunder.FormattingEnabled = true;
            this.listBox_kunder.Location = new System.Drawing.Point(14, 143);
            this.listBox_kunder.Name = "listBox_kunder";
            this.listBox_kunder.ScrollAlwaysVisible = true;
            this.listBox_kunder.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_kunder.Size = new System.Drawing.Size(177, 225);
            this.listBox_kunder.TabIndex = 5;
            this.listBox_kunder.Visible = false;
            // 
            // FinalPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 563);
            this.Controls.Add(this.listBox_kunder);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox_epost);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "FinalPage";
            this.Text = "FinalPage";
            this.Load += new System.EventHandler(this.FinalPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_epost;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox_kunder;
    }
}
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
            // 
            // textBox_vuxen
            // 
            this.textBox_vuxen.Location = new System.Drawing.Point(532, 324);
            this.textBox_vuxen.Name = "textBox_vuxen";
            this.textBox_vuxen.Size = new System.Drawing.Size(22, 20);
            this.textBox_vuxen.TabIndex = 2;
            // 
            // textBox_ungdom
            // 
            this.textBox_ungdom.Location = new System.Drawing.Point(532, 350);
            this.textBox_ungdom.Name = "textBox_ungdom";
            this.textBox_ungdom.Size = new System.Drawing.Size(22, 20);
            this.textBox_ungdom.TabIndex = 3;
            // 
            // textBox_barn
            // 
            this.textBox_barn.Location = new System.Drawing.Point(532, 376);
            this.textBox_barn.Name = "textBox_barn";
            this.textBox_barn.Size = new System.Drawing.Size(22, 20);
            this.textBox_barn.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(560, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
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
            // Huvudsidan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 481);
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
    }
}
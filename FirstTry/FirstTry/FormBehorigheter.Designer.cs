namespace FirstTry
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
            this.SuspendLayout();
            // 
            // listBoxBehorighet
            // 
            this.listBoxBehorighet.FormattingEnabled = true;
            this.listBoxBehorighet.ItemHeight = 16;
            this.listBoxBehorighet.Location = new System.Drawing.Point(79, 66);
            this.listBoxBehorighet.Name = "listBoxBehorighet";
            this.listBoxBehorighet.Size = new System.Drawing.Size(150, 180);
            this.listBoxBehorighet.TabIndex = 0;
            this.listBoxBehorighet.SelectedIndexChanged += new System.EventHandler(this.listBoxBehorighet_SelectedIndexChanged);
            // 
            // listBoxTabell
            // 
            this.listBoxTabell.FormattingEnabled = true;
            this.listBoxTabell.ItemHeight = 16;
            this.listBoxTabell.Location = new System.Drawing.Point(329, 66);
            this.listBoxTabell.Name = "listBoxTabell";
            this.listBoxTabell.Size = new System.Drawing.Size(150, 180);
            this.listBoxTabell.TabIndex = 1;
            // 
            // listBoxAnvandare
            // 
            this.listBoxAnvandare.FormattingEnabled = true;
            this.listBoxAnvandare.ItemHeight = 16;
            this.listBoxAnvandare.Location = new System.Drawing.Point(593, 66);
            this.listBoxAnvandare.Name = "listBoxAnvandare";
            this.listBoxAnvandare.Size = new System.Drawing.Size(150, 180);
            this.listBoxAnvandare.TabIndex = 2;
            // 
            // btnLaggTillBeh
            // 
            this.btnLaggTillBeh.Location = new System.Drawing.Point(593, 275);
            this.btnLaggTillBeh.Name = "btnLaggTillBeh";
            this.btnLaggTillBeh.Size = new System.Drawing.Size(150, 29);
            this.btnLaggTillBeh.TabIndex = 3;
            this.btnLaggTillBeh.Text = "Lägg till behörigheter";
            this.btnLaggTillBeh.UseVisualStyleBackColor = true;
            this.btnLaggTillBeh.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTaBortBeh
            // 
            this.btnTaBortBeh.Location = new System.Drawing.Point(593, 319);
            this.btnTaBortBeh.Name = "btnTaBortBeh";
            this.btnTaBortBeh.Size = new System.Drawing.Size(150, 31);
            this.btnTaBortBeh.TabIndex = 4;
            this.btnTaBortBeh.Text = "Ta bort behörigheter";
            this.btnTaBortBeh.UseVisualStyleBackColor = true;
            this.btnTaBortBeh.Click += new System.EventHandler(this.btnTaBortBeh_Click);
            // 
            // lblBehorighet
            // 
            this.lblBehorighet.AutoSize = true;
            this.lblBehorighet.Location = new System.Drawing.Point(76, 34);
            this.lblBehorighet.Name = "lblBehorighet";
            this.lblBehorighet.Size = new System.Drawing.Size(77, 17);
            this.lblBehorighet.TabIndex = 52;
            this.lblBehorighet.Text = "Behörighet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "Tabell";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(593, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 54;
            this.label2.Text = "Användare";
            // 
            // FormBehorigheter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 393);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBehorighet);
            this.Controls.Add(this.btnTaBortBeh);
            this.Controls.Add(this.btnLaggTillBeh);
            this.Controls.Add(this.listBoxAnvandare);
            this.Controls.Add(this.listBoxTabell);
            this.Controls.Add(this.listBoxBehorighet);
            this.Name = "FormBehorigheter";
            this.Text = "FormBehorigheter";
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
    }
}
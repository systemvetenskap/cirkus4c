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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelForestNamn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxAdminForestallning
            // 
            this.listBoxAdminForestallning.FormattingEnabled = true;
            this.listBoxAdminForestallning.Location = new System.Drawing.Point(224, 42);
            this.listBoxAdminForestallning.Name = "listBoxAdminForestallning";
            this.listBoxAdminForestallning.Size = new System.Drawing.Size(112, 186);
            this.listBoxAdminForestallning.TabIndex = 0;
            this.listBoxAdminForestallning.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // labelForestNamn
            // 
            this.labelForestNamn.AutoSize = true;
            this.labelForestNamn.Location = new System.Drawing.Point(25, 42);
            this.labelForestNamn.Name = "labelForestNamn";
            this.labelForestNamn.Size = new System.Drawing.Size(97, 13);
            this.labelForestNamn.TabIndex = 3;
            this.labelForestNamn.Text = "Namn Föreställning";
            this.labelForestNamn.Click += new System.EventHandler(this.label1_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 445);
            this.Controls.Add(this.labelForestNamn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxAdminForestallning);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAdminForestallning;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelForestNamn;
    }
}
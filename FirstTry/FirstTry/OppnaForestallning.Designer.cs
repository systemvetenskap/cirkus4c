namespace FirstTry
{
    partial class OppnaForestallning
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
            this.textBoxSistaForsaljningsdag = new System.Windows.Forms.TextBox();
            this.labelSistaForsaljningsdag = new System.Windows.Forms.Label();
            this.buttonSistaFörsäljningsdag = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxSistaForsaljningsdag
            // 
            this.textBoxSistaForsaljningsdag.Location = new System.Drawing.Point(33, 70);
            this.textBoxSistaForsaljningsdag.Name = "textBoxSistaForsaljningsdag";
            this.textBoxSistaForsaljningsdag.Size = new System.Drawing.Size(188, 22);
            this.textBoxSistaForsaljningsdag.TabIndex = 0;
            this.textBoxSistaForsaljningsdag.Text = "YYYY-MM-DD HH:mm";
            // 
            // labelSistaForsaljningsdag
            // 
            this.labelSistaForsaljningsdag.AutoSize = true;
            this.labelSistaForsaljningsdag.Location = new System.Drawing.Point(30, 50);
            this.labelSistaForsaljningsdag.Name = "labelSistaForsaljningsdag";
            this.labelSistaForsaljningsdag.Size = new System.Drawing.Size(139, 17);
            this.labelSistaForsaljningsdag.TabIndex = 1;
            this.labelSistaForsaljningsdag.Text = "Sista försäljningsdag";
            // 
            // buttonSistaFörsäljningsdag
            // 
            this.buttonSistaFörsäljningsdag.Location = new System.Drawing.Point(30, 110);
            this.buttonSistaFörsäljningsdag.Name = "buttonSistaFörsäljningsdag";
            this.buttonSistaFörsäljningsdag.Size = new System.Drawing.Size(191, 81);
            this.buttonSistaFörsäljningsdag.TabIndex = 2;
            this.buttonSistaFörsäljningsdag.Text = "Öppna försäljning av föreställningen";
            this.buttonSistaFörsäljningsdag.UseVisualStyleBackColor = true;
            this.buttonSistaFörsäljningsdag.Click += new System.EventHandler(this.buttonSistaFörsäljningsdag_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(665, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vänligen observera att du måste välja sista försäljningsdag för att öppna försälj" +
    "ningen av föreställningen";
            // 
            // OppnaForestallning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 253);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSistaFörsäljningsdag);
            this.Controls.Add(this.labelSistaForsaljningsdag);
            this.Controls.Add(this.textBoxSistaForsaljningsdag);
            this.Name = "OppnaForestallning";
            this.Text = "OppnaForestallning";
            this.Load += new System.EventHandler(this.OppnaForestallning_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSistaForsaljningsdag;
        private System.Windows.Forms.Label labelSistaForsaljningsdag;
        private System.Windows.Forms.Button buttonSistaFörsäljningsdag;
        private System.Windows.Forms.Label label1;
    }
}
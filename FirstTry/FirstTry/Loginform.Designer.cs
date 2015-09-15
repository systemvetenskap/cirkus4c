namespace FirstTry
{
    partial class Loginform
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
            this.textBox_anvandarnamn = new System.Windows.Forms.TextBox();
            this.textBox_losenord = new System.Windows.Forms.TextBox();
            this.label_anvandarnamn = new System.Windows.Forms.Label();
            this.label_losenord = new System.Windows.Forms.Label();
            this.button_login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_anvandarnamn
            // 
            this.textBox_anvandarnamn.Location = new System.Drawing.Point(157, 60);
            this.textBox_anvandarnamn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_anvandarnamn.Name = "textBox_anvandarnamn";
            this.textBox_anvandarnamn.Size = new System.Drawing.Size(132, 22);
            this.textBox_anvandarnamn.TabIndex = 0;
            // 
            // textBox_losenord
            // 
            this.textBox_losenord.Location = new System.Drawing.Point(157, 106);
            this.textBox_losenord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_losenord.Name = "textBox_losenord";
            this.textBox_losenord.Size = new System.Drawing.Size(132, 22);
            this.textBox_losenord.TabIndex = 1;
            // 
            // label_anvandarnamn
            // 
            this.label_anvandarnamn.AutoSize = true;
            this.label_anvandarnamn.Location = new System.Drawing.Point(157, 37);
            this.label_anvandarnamn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_anvandarnamn.Name = "label_anvandarnamn";
            this.label_anvandarnamn.Size = new System.Drawing.Size(104, 17);
            this.label_anvandarnamn.TabIndex = 2;
            this.label_anvandarnamn.Text = "Användarnamn";
            // 
            // label_losenord
            // 
            this.label_losenord.AutoSize = true;
            this.label_losenord.Location = new System.Drawing.Point(157, 86);
            this.label_losenord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_losenord.Name = "label_losenord";
            this.label_losenord.Size = new System.Drawing.Size(68, 17);
            this.label_losenord.TabIndex = 3;
            this.label_losenord.Text = "Lösenord";
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(157, 139);
            this.button_login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(100, 28);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "Logga in";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // Loginform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 210);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.label_losenord);
            this.Controls.Add(this.label_anvandarnamn);
            this.Controls.Add(this.textBox_losenord);
            this.Controls.Add(this.textBox_anvandarnamn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Loginform";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Loginform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_anvandarnamn;
        private System.Windows.Forms.TextBox textBox_losenord;
        private System.Windows.Forms.Label label_anvandarnamn;
        private System.Windows.Forms.Label label_losenord;
        private System.Windows.Forms.Button button_login;
    }
}
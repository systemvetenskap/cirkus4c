using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.Net.Mail;

namespace FirstTry
{
    partial class FinalPage : Form
    {
        Tempkop tk = new Tempkop();
        public FinalPage(Tempkop tk2)
        {
            InitializeComponent();
            tk = tk2;
        }
        public FinalPage()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = "javlamoodle@hotmail.com";
            string password = "qwert12345";

            //SendGmail(user, password, user, "sq.martin91@gmail.com","","MY SUBJECT","MY MESSAGE", true);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");

                mail.From = new MailAddress(user);
                mail.To.Add("jili1400@student.miun.se");
                mail.Subject = "Farligt mail med Virus i!!!";
                mail.Body = "Vill du köpa biljetter jaja";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(user, password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FinalPage_Load(object sender, EventArgs e)
        {
            int totalt = tk.vuxna + tk.ungdom + tk.barn;


            foreach (int biljett in tk.biljett_id)
            {
                richTextBox1.Text += biljett.ToString();
                
            }


        }
    }
}

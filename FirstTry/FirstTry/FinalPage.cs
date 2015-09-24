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
using System.Drawing.Printing;

namespace FirstTry
{
    partial class FinalPage : Form
    {
        PrintDocument pd = new PrintDocument();
        Tempkop tk = new Tempkop();
        int x = 0;
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
        private void pdf()
        {


        }
        private void FinalPage_Load(object sender, EventArgs e)
        {
            if (tk.reservation == true)
            {
                textBox_epost.Text = tk.epost;
            }

            int totalt = tk.vuxna + tk.ungdom + tk.barn;


            if (tk.biljett_id != null)
            {
                //pd.PrintController = new StandardPrintController();
                //pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                //pd.PrinterSettings.PrintToFile = true;
                //pd.Print();

                foreach (Biljett bilj in tk.biljetter)
                {
                    richTextBox1.Text += " Biljett ID: " + bilj.ToString();
                    richTextBox1.Text += " \n Föreställningsnamn: " + bilj.forestallning.namn;
                    richTextBox1.Text += " \n Akt: " + bilj.akter.namn;
                    richTextBox1.Text += "\n Datum: " + bilj.forestallning.datum.ToShortDateString();
                    richTextBox1.Text += " \n Tid: " + bilj.forestallning.tid.ToShortTimeString();
                    richTextBox1.Text += "\n Plats: " + bilj.plats_id.ToString();
                    richTextBox1.Text += "\n " + bilj.biljettyp + " \n  \n -------------------------------  \n \n";

                }                           

            }
        }
        //private void pd_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    int pointVar = 10;
        //    int strinPlacering = 120;
        //    foreach (Biljett i in tk.biljetter)
        //    {
        //        Graphics g = e.Graphics;
                
        //        Rectangle rect = new Rectangle(10, pointVar, 593, 343);
        //        Pen pen = new Pen(Brushes.Black);
        //        g.DrawRectangle(pen, rect);

        //        Font fBody = new Font("Lucida Console", 15, FontStyle.Bold);
        //        Font fBody1 = new Font("Lucida Console", 15, FontStyle.Regular);
        //        Font fBody2 = new Font("Lucida Console", 9, FontStyle.Regular);

        //        SolidBrush sb = new SolidBrush(Color.Black);
        //        g.DrawString("Föreställning: "+i.forestallning.ToString(), fBody1, sb, 10, strinPlacering);
        //        g.DrawString("Akt: "+i.akter.namn, fBody1, sb, 10, strinPlacering + 20);
        //        g.DrawString("Datum: "+i.forestallning.datum.ToShortDateString(), fBody1, sb, 10, strinPlacering + 40);
        //        g.DrawString("Biljett Nr: "+i.ToString(), fBody1, sb, 10, strinPlacering + 60);
        //        pointVar += 360;
        //        strinPlacering += 360;
        //        pd.Dispose();
        //    }


        //}
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

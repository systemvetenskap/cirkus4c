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
            int x = 0;
            int y = 0;


            if (tk.biljett_id != null)
            {
                foreach (int biljett in tk.biljett_id)
                {

                    Print();
                    
                    //richTextBox1.Text += " Biljett ID: " + biljett.ToString() + " \n Föreställningsnamn: " + tk.forestallning.namn +" \n Akt: " + tk.akter[y].namn +  "\n Datum: " + tk.forestallning.datum.ToShortDateString() + " \n Tid: " + tk.forestallning.tid.ToShortTimeString() + "\n Plats: " + tk.platsnamn[x].ToString()  + "\n " + tk.typ[x] + " \n  \n -------------------------------  \n \n";
                    //x++;
                    //if (x == (tk.antal * (y+1)))
                    //{
                    //  y++;
                    //}
                }

            }
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            int SPACE = 145;

            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(10, 10, 573, 403);
            Pen pen = new Pen(Brushes.Black);
            g.DrawRectangle(pen, rect);
            
            Font fBody = new Font("Lucida Console", 15, FontStyle.Bold);
            Font fBody1 = new Font("Lucida Console", 15, FontStyle.Regular);
            Font fBody2 = new Font("Lucida Console", 9, FontStyle.Regular);

            SolidBrush sb = new SolidBrush(Color.Black);

                g.DrawString(tk.forestallning.namn, fBody1, sb, 10, 120);
                g.DrawString(tk.akter[x].namn, fBody1, sb, 10, 140);
                g.DrawString(tk.forestallning.datum.ToString(), fBody1, sb, 10, 160);
                g.DrawString(tk.biljett_id[x].ToString(), fBody1, sb, 10, 180);

        }
        private void Print()
        {
            PrintDocument pd = new PrintDocument();
            PaperSize ps = new PaperSize("test", 583, 413);
            
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            pd.PrintController = new StandardPrintController();
            /*     pd.DefaultPageSettings.Margins.Left = 50;
                 pd.DefaultPageSettings.Margins.Right = 50;
                 pd.DefaultPageSettings.Margins.Top = 50;
                 pd.DefaultPageSettings.Margins.Bottom = 50; */
            pd.PrinterSettings.DefaultPageSettings.PaperSize = ps;
            pd.PrinterSettings.PrintToFile = true;
            pd.Print();
            //g.Dispose();
        }


    }
}

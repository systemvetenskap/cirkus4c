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
using Npgsql;

namespace FirstTry
{
    partial class FinalPage : Form
    {
        string content = "";
        Font printFont = new Font("Arial", 10);
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
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
        private bool arDetMail()
        {
            string mail = textBox_epost.Text;
            try
            {
                var test = new MailAddress(mail);
                return true;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Oj Oj Oj OJ, nu har du allt skrivit in en konstig mail adress!");
                return false;
                // wrong format for email
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            string user = "javlamoodle@hotmail.com";
            string password = "qwert12345";

            if (arDetMail() == true)
            {
                //SendGmail(user, password, user, "sq.martin91@gmail.com","","MY SUBJECT","MY MESSAGE", true);
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.live.com");

                    mail.From = new MailAddress(user);
                    mail.To.Add(textBox_epost.Text);
                    mail.Subject = "Biljetter för föreställningen " + tk.biljetter[0].forestallning.namn;
                    mail.Body = richTextBox1.Text;

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
            int antalAkter = tk.akter.Count;

            if (tk.biljett_id != null)
            {
                if (tk.hela == true)
                {
                    foreach (Biljett bilj in tk.biljetter)
                    {
                        richTextBox1.Text += " Biljett ID: " + bilj.ToString();
                        richTextBox1.Text += " \n Föreställningsnamn: " + bilj.forestallning.namn;
                        richTextBox1.Text += " \n Akt: " + bilj.akter.namn;
                        richTextBox1.Text += "\n Datum: " + bilj.forestallning.datum.ToShortDateString();
                        richTextBox1.Text += " \n Tid: " + bilj.forestallning.tid.ToShortTimeString();
                        richTextBox1.Text += "\n Plats: " + platsnamn(bilj.plats_id.ToString());
                        richTextBox1.Text += "\n Pris: " + bilj.pris.ToString();
                        richTextBox1.Text += "\n " + bilj.biljettyp + " \n  \n -------------------------------  \n \n";
                    }
                }
                else
                {
                    foreach (Biljett bilj in tk.biljetter)
                    {
                        richTextBox1.Text += " Biljett ID: " + bilj.ToString();
                        richTextBox1.Text += " \n Föreställningsnamn: " + bilj.forestallning.namn;
                        richTextBox1.Text += " \n Akt: " + bilj.akter.namn;
                        richTextBox1.Text += "\n Datum: " + bilj.forestallning.datum.ToShortDateString();
                        richTextBox1.Text += " \n Tid: " + bilj.forestallning.tid.ToShortTimeString();
                        richTextBox1.Text += "\n Plats: " + platsnamn(bilj.plats_id.ToString());
                        richTextBox1.Text += "\n Pris: " + bilj.pris.ToString();
                        richTextBox1.Text += "\n " + bilj.biljettyp + " \n  \n -------------------------------  \n \n";
                    }
                }
                                  

            }
        }

        public string platsnamn(string platsID)
        {
            conn.Open();
            string namn = "";
            string query = "select nummer from platser where id = ";
            query += platsID.ToString();
            // NpgsqlCommand cmd = new NpgsqlCommand();
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);

            da.Fill(dt);

            DataTableReader dtr = new DataTableReader(dt);

            while (dtr.Read())
            {
                namn = dtr[0].ToString();
            }
            conn.Close();
            return namn;
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
        //        g.DrawString("Föreställning: " + i.forestallning.ToString(), fBody1, sb, 10, strinPlacering);
        //        g.DrawString("Akt: " + i.akter.namn, fBody1, sb, 10, strinPlacering + 20);
        //        g.DrawString("Datum: " + i.forestallning.datum.ToShortDateString(), fBody1, sb, 10, strinPlacering + 40);
        //        g.DrawString("Biljett Nr: " + i.ToString(), fBody1, sb, 10, strinPlacering + 60);
        //        pointVar += 360;
        //        strinPlacering += 360;
        //        pd.Dispose();
        //    }


        //}
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //private void button2_Click(object sender, EventArgs e)
        //{

        //    //richTextBox1.SaveFile("biljetttttttttttter.rtf");
        //    //PrintDocument rtf = new PrintDocument();
        //    //FileStream fs = new FileStream("biljetttttttttttter.rtf", FileMode.Open);
        //    //StreamReader sr = new StreamReader(fs);
        //    //sr.ToString();
        //    ////pd.Print();
        //    //pd.PrintController = new StandardPrintController();
        //    //pd.PrintPage += new PrintPageEventHandler();
        //    //////pd.PrinterSettings.PrintToFile = true;
        //    ////pd.PrinterSettings.PrintToFile = true;
        //    ////pd.Print();
        //}
        
        private void button2_Click(object sender, EventArgs e)
        {
            string namn = tk.biljetter[0].ToString();
            File.AppendAllText(namn + ".txt", richTextBox1.Text);





            //richTextBox1.SaveFile("biljetttttttttttter.txt");
            try
            {
                content = File.ReadAllText(namn + ".txt");
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                pd.PrinterSettings.PrintToFile = true;
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.DrawString(content, printFont, Brushes.Black,
                            ev.MarginBounds.Left, 0, new StringFormat());
        }
    }
}

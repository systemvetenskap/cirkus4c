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
            listBox_kunder.Visible = true;
              
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
                    MessageBox.Show("E-post skickat");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


        }
        private void laddaKundRich(Kund k)
        {
            if (k.bilj[0].biljettyp == "vuxen")
            {
                richTextBox1.Text += " Biljett ID: ";
                for (int i = 0; i < k.bilj.Count; i++)
                {
                    richTextBox1.Text += k.bilj[i].biljett_id + ", ";
                }

                richTextBox1.Text += " \n Föreställningsnamn: " + k.bilj[0].forestallning.namn;
                richTextBox1.Text += " \n Alla akter";
                richTextBox1.Text += "\n Datum: " + k.bilj[0].forestallning.datum.ToShortDateString();
                richTextBox1.Text += " \n Tid: " + k.bilj[0].forestallning.starttid.ToShortTimeString();
                richTextBox1.Text += "\n Plats: " + platsnamn(k.bilj[0].plats_id.ToString());
                richTextBox1.Text += "\n Pris: " + k.bilj[0].forestallning.vuxen;
                richTextBox1.Text += "\n Vuxen";
            }
            if (k.bilj[0].biljettyp == "ungdom")
            {
                richTextBox1.Text += " Biljett ID: ";
                for (int i = 0; i < k.bilj.Count; i++)
                {
                    richTextBox1.Text += k.bilj[i].biljett_id + ", ";
                }

                richTextBox1.Text += " \n Föreställningsnamn: " + k.bilj[0].forestallning.namn;
                richTextBox1.Text += " \n Alla akter";
                richTextBox1.Text += "\n Datum: " + k.bilj[0].forestallning.datum.ToShortDateString();
                richTextBox1.Text += " \n Tid: " + k.bilj[0].forestallning.starttid.ToShortTimeString();
                richTextBox1.Text += "\n Plats: " + platsnamn(k.bilj[0].plats_id.ToString());
                richTextBox1.Text += "\n Pris: " + k.bilj[0].forestallning.ungdom;
                richTextBox1.Text += "\n Ungdom";
            }
            if (k.bilj[0].biljettyp == "barn")
            {
                richTextBox1.Text += " Biljett ID: ";
                for (int i = 0; i < k.bilj.Count; i++)
                {
                    richTextBox1.Text += k.bilj[i].biljett_id + ", ";
                }

                richTextBox1.Text += " \n Föreställningsnamn: " + tk.biljetter[0].forestallning.namn;
                richTextBox1.Text += " \n Alla akter";
                richTextBox1.Text += "\n Datum: " + k.bilj[0].forestallning.datum.ToShortDateString();
                richTextBox1.Text += " \n Tid: " + k.bilj[0].forestallning.starttid.ToShortTimeString();
                richTextBox1.Text += "\n Plats: " + platsnamn(k.bilj[0].plats_id.ToString());
                richTextBox1.Text += "\n Pris: " + k.bilj[0].forestallning.barn;
                richTextBox1.Text += "\n Barn";
            }

            richTextBox1.Text += " \n  \n -------------------------------  \n \n";
            // richTextBox1.Text += "\n Pris: " + tk.forestallning


        }

        private void laddaHelafore(Biljett bilj)
        {
            richTextBox1.Text += " Biljett ID: " + bilj.ToString();
            richTextBox1.Text += " \n Föreställningsnamn: " + bilj.forestallning.namn;
            richTextBox1.Text += " \n Akt: " + bilj.akter.namn;
            richTextBox1.Text += "\n Datum: " + bilj.forestallning.datum.ToShortDateString();
            richTextBox1.Text += " \n Tid: " + bilj.akter.Starttid.ToShortTimeString();
            richTextBox1.Text += "\n Plats: " + platsnamn(bilj.plats_id.ToString());
            richTextBox1.Text += "\n Pris: " + bilj.pris.ToString();
            richTextBox1.Text += "\n " + bilj.biljettyp + " \n  \n -------------------------------  \n \n";
        }


        private void FinalPage_Load(object sender, EventArgs e)
        {
            tk.fardig = true;


            if (tk.biljetter.Count > 0)
            {
                if (tk.biljetter[0].resserverad == true)
                {
                    textBox_epost.Text = tk.epost;
                }

                int totalt = tk.vuxna + tk.ungdom + tk.barn;
                int antalAkter = tk.akter.Count;

                if (tk.biljetter != null)
                {
                    if (tk.hela == true)
                    {
                        /* for (int i = 0; i < totalt; i++)
                         {

                             richTextBox1.Text += " Biljett ID: " + tk.biljetter[i].biljett_id;

                             richTextBox1.Text += " \n Föreställningsnamn: " + tk.biljetter[0].forestallning.namn;
                             richTextBox1.Text += " \n Alla akter";
                             richTextBox1.Text += "\n Datum: " + tk.biljetter[0].forestallning.datum.ToShortDateString();
                             richTextBox1.Text += " \n Tid: " + tk.biljetter[0].forestallning.tid.ToShortTimeString();
                             richTextBox1.Text += "\n Plats: " + platsnamn(tk.biljetter[i + totalt].plats_id.ToString());
                            // richTextBox1.Text += "\n Pris: " + tk.forestallning

                             richTextBox1.Text += "\n " + tk.biljetter[i + totalt].biljettyp;

                             if (tk.biljetter[i + totalt].biljettyp == "vuxen")
                             {
                                 richTextBox1.Text += "\n Pris: " + tk.biljetter[0].forestallning.vuxen.ToString()  +" \n  \n -------------------------------  \n \n";
                             }
                             if (tk.biljetter[i + totalt].biljettyp == "ungdom")
                             {
                                 richTextBox1.Text += "\n Pris: " + tk.biljetter[0].forestallning.ungdom.ToString() + " \n  \n -------------------------------  \n \n";
                             }
                             if (tk.biljetter[i + totalt].biljettyp == "barn")
                             {
                                 richTextBox1.Text += "\n Pris: " + tk.biljetter[0].forestallning.barn.ToString() + " \n  \n -------------------------------  \n \n";
                             }
                         }*/

                        foreach (Kund k in tk.kunder)
                        {
                            laddaKundRich(k);

                        }



                    }
                    else
                    {
                        foreach (Biljett bilj in tk.biljetter)
                        {
                            laddaHelafore(bilj);
                        }
                    }


                }

            }
            else
            {
                string query = "select * from kund";
                
                // NpgsqlCommand cmd = new NpgsqlCommand();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);

                da.Fill(dt);

                conn.Open();

                foreach (DataRow row in dt.Rows)
                {
                    Kund k = new Kund();
                    k.kund_id = (Convert.ToInt32(row["id"]));
                    k.fornamn = (row["namn"].ToString());
                    k.efternamn = (row["efternamn"].ToString());


                    string query2 = "SELECT biljett.id, akter.aktnamn, forestallning.namn, biljett.pris, biljett.kund_id, forestallning.datum, forestallning.starttid, biljett.plats_id FROM public.forestallning, public.biljett, public.akter WHERE biljett.forestallning_id = forestallning.id AND biljett.akt_id = akter.id And kund_id = ";
                    query2 += k.kund_id.ToString() + ";";
                    // NpgsqlCommand cmd = new NpgsqlCommand();
                    DataTable dt2 = new DataTable();
                    NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(query2, conn);

                    da2.Fill(dt2);

                    foreach (DataRow row2 in dt2.Rows)
                    {
                        Biljett b = new Biljett();
                        Forestallning f = new Forestallning();
                        Akt a = new Akt();
                        b.forestallning = f;
                        b.akter = a;

                        b.biljett_id = (Convert.ToInt32(row2["id"]));
                        b.pris = (Convert.ToInt32(row2["pris"]));
                        b.forestallning.namn = ((row2["namn"]).ToString());
                        b.akter.namn = ((row2["aktnamn"]).ToString());
                        b.plats_id = (Convert.ToInt32((row2["plats_id"])));
                        b.forestallning.datum = (DateTime)row2["datum"];
                        b.forestallning.tid = (DateTime)row2["starttid"];
                        k.bilj.Add(b);

                        tk.biljetter.Add(b);
                    }
                    listBox_kunder.Items.Add(k);

                }
                conn.Close();



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
            ReadFile();
            pd.PrintPage +=
                new PrintPageEventHandler(pd_PrintPage);
            pd.PrinterSettings.PrintToFile = true;
            pd.Print();
        }
        //private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        //{
        //    ev.Graphics.DrawString(content, printFont, Brushes.Black,
        //                    ev.MarginBounds.Left, 0, new StringFormat());
        //    ev.HasMorePages = (content.Length > 0);
        //}

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Copied from https://msdn.microsoft.com/en-us/library/cwbe712d(v=vs.110).aspx
            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(content, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page
            e.Graphics.DrawString(content, this.Font, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            content = content.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (content.Length > 0);
        }


        private void ReadFile()
        {
            string namn = tk.biljetter[0].ToString();
            File.AppendAllText(namn + ".txt", richTextBox1.Text);
            string docName = (namn + ".txt");
            string docPath = @"C:\Users\Martin\Documents\nyGit\cirkus4c\FirstTry\FirstTry\bin\";
            pd.DocumentName = docName;
            using (FileStream stream = new FileStream(docPath + docName, FileMode.OpenOrCreate)) //Open or create?
            using (StreamReader reader = new StreamReader(stream))
            {
                content = reader.ReadToEnd();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Huvudsidan hs = new Huvudsidan();
            hs.ShowDialog();
            this.Close();
        }

        private void listBox_kunder_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            Kund k = new Kund();
            k = (Kund)listBox_kunder.SelectedItem;


            foreach (Biljett bilj in k.bilj)
            {
                laddaHelafore(bilj);
            }
            



        }
    }
}

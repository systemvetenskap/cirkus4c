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
        List<int> aktortyper = new List<int>();
        int x = 0;


        public FinalPage(Tempkop tk2, List<int> aktortyperID)
        {
            InitializeComponent();
            tk = tk2;
            aktortyper = aktortyperID;
        }
        public FinalPage(List<int> aktortyperID)
        {
            InitializeComponent();
            aktortyper = aktortyperID;
            listBox_kunder.Visible = true;
            button5.Visible = true;
            button4.Visible = true;
        }
        public FinalPage()
        {
            InitializeComponent();
            listBox_kunder.Visible = true;
            button5.Visible = true;
            button4.Visible = true;

              
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

        private int laggTilliDatabasenBiljetter()
        {


            string query = "INSERT INTO biljett (pris, forestallning_id, akt_id, biljettyp, reserverad, tidsstampel, fri_placering) VALUES(@pris, @forestallning_id, @akt_id, @biljettyp, @reserverad, @tidsstampel, @fri_placering) RETURNING id;";
            Biljett biljetten = new Biljett();



            if (tk.biljetter[tk.fuskIgen].resserverad == true)
            {
                query = "INSERT INTO biljett (pris, forestallning_id, akt_id, biljettyp, reserverad, tidsstampel, kund_id, fri_placering) VALUES(@pris, @forestallning_id, @akt_id, @biljettyp, @reserverad, @tidsstampel, @kund_id, @fri_placering) RETURNING id;";
            }


            NpgsqlCommand command = new NpgsqlCommand(query, conn);

            command.Parameters.AddWithValue("@pris", tk.biljetter[tk.fuskIgen].pris);
            command.Parameters.AddWithValue("@forestallning_id", tk.biljetter[tk.fuskIgen].forestallning.id);
            command.Parameters.AddWithValue("@akt_id", tk.biljetter[tk.fuskIgen].akter.id);
            command.Parameters.AddWithValue("@biljettyp", tk.biljetter[tk.fuskIgen].biljettyp);
            command.Parameters.AddWithValue("@reserverad", tk.biljetter[tk.fuskIgen].resserverad);
            command.Parameters.AddWithValue("@tidsstampel", DateTime.Now);

            command.Parameters.AddWithValue("@fri_placering", tk.biljetter[tk.fuskIgen].forestallning.friplacering);

            if (tk.biljetter[tk.fuskIgen].resserverad == true)
            {
                command.Parameters.AddWithValue("@kund_id", tk.biljetter[tk.fuskIgen].kund_id);
            }



            int x = (int)command.ExecuteScalar();

            tk.biljetter[tk.fuskIgen].biljett_id = x;
            tk.biljetter[tk.fuskIgen].kopt = true;

            tk.fuskIgen++;

            return x;
        }
        private void FinalPage_Load(object sender, EventArgs e)
        {
            tk.fardig = true;

            if (tk.biljetter.Count > 0 && tk.biljetter[0].forestallning.friplacering == true)
            {
                textBox_epost.Text = tk.epost;
                foreach (Biljett bilj in tk.biljetter)
                {
                    conn.Open();
                    laggTilliDatabasenBiljetter();
                    conn.Close();

                    richTextBox1.Text += " Biljett ID: " + bilj.ToString();
                    richTextBox1.Text += " \n Föreställningsnamn: " + bilj.forestallning.namn;
                    richTextBox1.Text += " \n Akt: " + bilj.akter.namn;
                    richTextBox1.Text += "\n Datum: " + bilj.forestallning.datum.ToShortDateString();
                    richTextBox1.Text += " \n Tid: " + bilj.akter.Starttid.ToShortTimeString();
                    richTextBox1.Text += "\n Plats: Fri placering";
                    richTextBox1.Text += "\n Pris: " + bilj.pris.ToString();
                    richTextBox1.Text += "\n " + bilj.biljettyp + " \n  \n -------------------------------  \n \n";
                }
            }
            else if (tk.biljetter.Count > 0)
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
                    k.epost = (row["mail"].ToString());

                    string query2 = "SELECT biljett.id, akter.aktnamn, forestallning.namn, biljett.pris, biljett.kund_id, forestallning.datum, forestallning.starttid, biljett.plats_id, biljett.fri_placering FROM public.forestallning, public.biljett, public.akter WHERE biljett.forestallning_id = forestallning.id AND biljett.akt_id = akter.id And kund_id = ";
                    query2 += k.kund_id.ToString() + ";";
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
                        if ((bool)row2["fri_placering"] == false)
                        {
                            b.plats_id = (Convert.ToInt32((row2["plats_id"])));
                        }

                        b.forestallning.datum = (DateTime)row2["datum"];
                        b.akter.Starttid = (DateTime)row2["starttid"];
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            ReadFile();
            pd.PrintPage +=
                new PrintPageEventHandler(pd_PrintPage);
            pd.PrinterSettings.PrintToFile = true;
            pd.Print();
        }

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
            string test = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string namn = tk.biljetter[0].ToString();
            File.WriteAllText(test + namn + ".txt", richTextBox1.Text);
            string docName = (namn + ".txt");
            
            string docPath = test;
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
            Huvudsidan hs = new Huvudsidan(aktortyper);
            hs.ShowDialog();
            this.Close();
        }

        private void listBox_kunder_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (listBox_kunder.Items.Count > 0)
            {
                Kund k = new Kund();
                k = (Kund)listBox_kunder.SelectedItem;

                int x = listBox_kunder.SelectedIndex;

                if (listBox_kunder.SelectedIndex != -1)
                {
                    textBox_epost.Text = k.epost;

                    foreach (Biljett bilj in k.bilj)
                    {
                        laddaHelafore(bilj);
                    }
                }



            }

            



        }
        private void taBortKund(Kund k)
        {
            string query2 = "delete from kund where id =";
            query2 += k.kund_id;
            NpgsqlCommand command2 = new NpgsqlCommand(query2, conn);

            command2.ExecuteNonQuery();
            

            listBox_kunder.Items.Remove(k);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vill du verkligen köp biljetterna?", "Köpa biljetterna", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Kund k = (Kund)listBox_kunder.SelectedItem;

                foreach (Biljett b in k.bilj)
                {
                    conn.Open();
                    string query = "update biljett set kund_id = null, reserverad = false where id = ";
                    query += b.biljett_id;
                    NpgsqlCommand command = new NpgsqlCommand(query, conn);

                    command.ExecuteNonQuery();
                    conn.Close();
                }

                conn.Open();
                taBortKund(k);
                conn.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vill du verkligen ta bort reservationen?", "Ta bort reservation", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                textBox_epost.Text = "";
                Kund k = (Kund)listBox_kunder.SelectedItem;

                foreach (Biljett b in k.bilj)
                {
                    conn.Open();
                    string query = "delete from biljett where id = ";
                    query += b.biljett_id;
                    NpgsqlCommand command = new NpgsqlCommand(query, conn);

                    command.ExecuteNonQuery();
                    conn.Close();
                }


                conn.Open();
                taBortKund(k);
                conn.Close();
            }



        }
    }
}

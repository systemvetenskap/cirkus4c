using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace FirstTry
{
    public partial class Huvudsidan : Form
    {
        List<int> aktortyper = new List<int>();
        public Huvudsidan()
        {
            InitializeComponent();
        }
        public Huvudsidan(List<int> aktortypID)
        {
            InitializeComponent();
            aktortyper = aktortypID;
        }
        Tempkop session;
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
        

        

        
        int antalakter = 0;

        private void Form1_Shown(object sender, EventArgs e)
        {
            
            session = new Tempkop();

        }
        private void Huvudsidan_Load(object sender, EventArgs e)
        {
            
            if (aktortyper.Contains(3) == true || aktortyper.Contains(4) == true || aktortyper.Contains(5) == true || aktortyper.Contains(6) == true || aktortyper.Contains(7) == true || aktortyper.Contains(9) == true)
            {
                this.button3.Enabled = true;
                this.button3.Visible = true;
            }
            session = new Tempkop();
            conn.Open();
            session.totalpris = 0; //För att kolla vid button click att inget är vallt
            
            //listBox_akter.SelectedIndex = -1;
            //listBox_forestallning.SelectedIndex = -1;
            DataTable dt = new DataTable();
            string query = "select * from forestallning";
            //string forenamn = "forestallning";
            //int forenummer = 1;
            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                da.Fill(dt);

                /*  DateTime slutdatum = new DateTime();
                  DateTime tid2 = new DateTime();
                  slutdatum = DateTime.Now;
                  tid2 = DateTime.Now;*/
                

                foreach (DataRow row in dt.Rows)
                {
                    
                   

                    if ((bool)row["open"] == true )
                    {
                        DateTime slutdatum = (DateTime)row["forsaljningslut"];
                       // if (slutdatum > DateTime.Now)
                    {
                        string info = row["generell_info"].ToString();
                        string namn = row["namn"].ToString();
                        string id = row["id"].ToString();
                        int vuxen = Convert.ToInt32(row["vuxenpris"]);
                        int ungdom = Convert.ToInt32(row["ungdomspris"]);
                        int barn = Convert.ToInt32(row["barnpris"]);
                        DateTime datum = (DateTime)row["datum"];
                        DateTime tid = (DateTime)row["starttid"];
                        Forestallning fs = new Forestallning();
                        fs.akter = new List<Akt>();
                        fs.generellinfo = info;
                        fs.namn = namn;
                        fs.id = Convert.ToInt32(id);
                        fs.barn = barn;
                        fs.ungdom = ungdom;
                        fs.vuxen = vuxen;
                        fs.datum = datum;
                        fs.starttid = tid;
                        fs.forsaljningsslut = slutdatum;
                        listBox_forestallning.Items.Add(fs);
                        //forenamn += forenummer;
                        //forenummer++;


                        string query2 = "select * from akter where forestallningsid = " + fs.id.ToString();
                        NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(query2, conn);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        foreach (DataRow row2 in dt2.Rows)
                        {
                            Akt akt = new Akt();
                                string aktinfo = row2["aktinfo"].ToString();
                                string aktnamn = row2["aktnamn"].ToString();
                            string aktid = row2["id"].ToString();
                            //  int aktpris = Convert.ToInt32(row2["vuxenpris"]);
                            int vuxen2 = Convert.ToInt32(row2["vuxenpris"]);
                            int ungdom2 = Convert.ToInt32(row2["ungdomspris"]);
                            int barn2 = Convert.ToInt32(row2["barnpris"]);
                            DateTime tidakt = (DateTime)row["starttid"];
                            akt.namn = aktnamn;
                            akt.id = Convert.ToInt32(aktid);
                            akt.vuxen = vuxen2;
                            akt.ungdom = ungdom2;
                            akt.barn = barn2;
                            akt.Starttid = tidakt;
                                akt.Aktinfo = aktinfo;
                            fs.akter.Add(akt);
                        }
                        

 
                    }
                    }


                }
                //listBox_forestallning.Items.Add(namn);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox_forestallning_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            label16.Text = "";
            label15.Text = "";

            Forestallning fs = new Forestallning();
            fs.akter = new List<Akt>();
            listBox_akter.Items.Clear();

            if ((Forestallning)listBox_forestallning.SelectedItem != null)
            {
                fs = (Forestallning)listBox_forestallning.SelectedItem;
                foreach (Akt akt in fs.akter)
                {
                    listBox_akter.Items.Add(akt);
                }
                label15.Visible = true;
                label16.Visible = true;
                
                label16.Text = fs.datum.ToShortDateString();
                label15.Text = fs.starttid.ToShortTimeString();               
            }
           
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;

            noll();

            label10.Visible = true;
            label9.Visible = true;
            label8.Visible = true;

            label10.Text = fs.vuxen.ToString();
            label9.Text = fs.ungdom.ToString();
            label8.Text = fs.barn.ToString();

            richTextBox1.Text = fs.generellinfo;

            //string forestallning = listBox_forestallning.SelectedItem.ToString();
            //string query2 = "SELECT aktinfo, id FROM public.akter WHERE akter.forestallningsid = " + fs.id;
            //DataTable dt2 = new DataTable();
            //try
            //{
            //    NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(query2, conn);
            //    da2.Fill(dt2);

            //    foreach (DataRow row2 in dt2.Rows)
            //    {
            //        string aktnamn = row2["aktinfo"].ToString();
            //        string aktid = row2["id"].ToString();
            //        Akt akt = new Akt();
            //        akt.namn = aktnamn;
            //        akt.id = Convert.ToInt32(aktid);
            //        fs.akter.Add(akt);

            //    }
            //}
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void skapaBiljetter()
        {

            int antalv = Convert.ToInt32(textBox_vuxen.Text);
            int antalu = Convert.ToInt32(textBox_ungdom.Text);
            int antalb = Convert.ToInt32(textBox_barn.Text);

            foreach (Akt akt in listBox_akter.SelectedItems)
            {
                for (int i = 0; i < antalv; i++)
                {
                    skapaTempkop("vuxen", akt, akt.vuxen);
                }
                for (int i = 0; i < antalu; i++)
                {
                    skapaTempkop("ungdom", akt, akt.ungdom);
                }
                for (int i = 0; i < antalb; i++)
                {
                    skapaTempkop("barn", akt, akt.barn);
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int kollaOmDetarHela = 0;

            //  session.platsnamn = new List<string>();
            // session.typ = new List<string>();
            session.hela = false; //låg kvar som true om man gick tillbaka från platskartan

            foreach (Akt akter in listBox_akter.SelectedItems)
            {
                session.loopar++;
                session.akter.Add(akter);
            }
            foreach (Akt item in listBox_akter.Items)
            {
                kollaOmDetarHela++;
            }
            if (session.loopar == kollaOmDetarHela)
            {
                session.hela = true;
            }
            if (antal_ar_siffror() == true)
            {
                if (session.hela == true)
                {
                    biljetterForHela();
                    session.antalKunder = session.kunder.Count;
                }
                else
                {
                    skapaBiljetter();
                }
            }
          
            
           // session.biljett_id = new List<int>();

            foreach (Biljett b in session.biljetter)
            {
                if (checkBox1.Checked == true)
                {
                    b.resserverad = true;
                }
            }
            session.antal = 0;

            if (antal_ar_siffror() == false)
            {
                    MessageBox.Show("Hoppsan! Du fyllde i antalet besökare felaktigt.");
            }
                else if ((Forestallning)listBox_forestallning.SelectedItem == null)
                {
                    MessageBox.Show("Hoppsan! Du glömde visst att välja en föreställning");
                }
                else if ((Akt)listBox_akter.SelectedItem == null)
                {
                    MessageBox.Show("Hoppsan! Du glömde visst att välja akt");
                }

        
           else if (session.fullbokat(session) == true)
            {
                MessageBox.Show("Tyvärr så finns det inte tillräkligt med plats på de valda akterna");
            }
            else
            {
            //Admin ska väll kunna ändra pris?
                if (checkBox1.Checked == true)
            {
                this.Hide();
                Kunduppgifter ku = new Kunduppgifter(session, aktortyper);
                ku.ShowDialog();

                this.Close();
            }
                else if (session.biljetter[0].forestallning.friplacering == true)
            {
                    //ladda biljett stuff direkt
                    // MessageBox.Show("ITS WORKING");
                    //ladda biljett stuff direkt
                    //MessageBox.Show("ITS WORKING");
                    this.Hide();
                    FinalPage fp = new FinalPage(session, aktortyper);
                    fp.ShowDialog();
                    this.Close();
                }
            else
            {
                this.Hide();
                Platskarta pk = new Platskarta(session, aktortyper);
                pk.ShowDialog();
                this.Close();
            }
            }

        }
        private bool helaforestallningen()
        {
            int xh = 0;
            int l = 0;

            foreach (Akt akt in listBox_akter.SelectedItems)
            {
                xh++;
            }
            foreach (Akt akt2 in listBox_akter.Items)
            {
                l++;
            }

            if (xh == l)
            {
                //då har vill man boka hela förestälningen
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool antal_ar_siffror()
        {
            int u;
            int v;
            int b;
            

            if (int.TryParse(textBox_ungdom.Text, out u) == false)
            {
                return false;
                //session.ungdom = u;
            }
            else if (int.TryParse(textBox_vuxen.Text, out v) == false)
            {
                return false;
                //session.vuxna = v;
            }
            else if (int.TryParse(textBox_barn.Text, out b) == false)
            {
                return false;
                //session.barn = b;
            }
            else if ((u + v + b) == 0)
            {
                return false;
            }
            else
            {
                session.ungdom = u;
                session.vuxna = v;
                session.barn = b;
                return true;
            }
            //if (u != 0 || v != 0 || b != 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            //if ((u + v + b) == 0)
            //{
            //    return false;
            //}

            
        }
        private void biljetterForHela()
        {
            Forestallning fore = new Forestallning();
            fore = (Forestallning)listBox_forestallning.SelectedItem;
            int antalv = Convert.ToInt32(textBox_vuxen.Text);
            int antalu = Convert.ToInt32(textBox_ungdom.Text);
            int antalb = Convert.ToInt32(textBox_barn.Text);

            for (int i = 0; i < antalv; i++)
            {
                Kund k = new Kund();

                foreach (Akt item in listBox_akter.SelectedItems)
                {
                    skapaHelaTempkop("vuxen", item, fore.vuxen, k);
                }          
                session.kunder.Add(k);
            }
            for (int i = 0; i < antalu; i++)
            {
                Kund k = new Kund();

                foreach (Akt item in listBox_akter.SelectedItems)
                {
                    skapaHelaTempkop("ungdom", item, fore.ungdom, k);
                }
                session.kunder.Add(k);
            }
            for (int i = 0; i < antalb; i++)
            {
                Kund k = new Kund();

                foreach (Akt item in listBox_akter.SelectedItems)
                {
                    skapaHelaTempkop("barn", item, fore.barn, k);
        }
                session.kunder.Add(k);
            }
        }
        private void skapaHelaTempkop(string biljettyp, Akt akt, int pris, Kund k)
        {

            if (listBox_akter.SelectedItem != null && listBox_forestallning != null && antal_ar_siffror() == true)
        {
                // int loopar = 0;

            
                //       Tempkop s2 = new Tempkop();
                //     session = s2;
                Biljett b = new Biljett();

                b.hela = helaforestallningen();
                b.akter = akt;
                b.forestallning = (Forestallning)listBox_forestallning.SelectedItem;
                b.biljettyp = biljettyp;
                b.pris = pris;
                b.resserverad = false;

                session.biljetter.Add(b);
                k.bilj.Add(b);
            }
        }

        private void skapaTempkop(string biljettyp, Akt akt, int pris)
        {

            if (listBox_akter.SelectedItem != null && listBox_forestallning != null && antal_ar_siffror() == true)
            {
               // int loopar = 0;


                //       Tempkop s2 = new Tempkop();
                //     session = s2;
                Biljett b = new Biljett();
                
                b.hela= helaforestallningen();
                b.akter = akt;
                b.forestallning = (Forestallning)listBox_forestallning.SelectedItem;
                b.biljettyp = biljettyp;
                b.pris = pris;
                b.resserverad = false;

                session.biljetter.Add(b);


                     

             //   uppdateraPris();
                // List<Akt> aktlista = new List<Akt>();

                /*     foreach (Akt akt in listBox_akter.SelectedItems)
            {
                aktlista.Add(akt);
                loopar++;           
            }

                 */


                /*
                session.akter = aktlista;
                session.forestallning = (Forestallning)listBox_forestallning.SelectedItem;
                session.reservation = checkBox1.Checked;
                session.antal = 0;
                session.loopar = loopar;

            */
                //      antal_ar_siffror();

                /*   conn.Open();
                LaggTillTempkop(); //behövs den?
                conn.Close();
                */

                /*  int totalpris = 0;

            if (session.hela == true)
            {
                totalpris += session.barn * session.forestallning.barn;
                totalpris += session.ungdom * session.forestallning.ungdom;
                totalpris += session.vuxna * session.forestallning.vuxen;
            }
            else
            {
                foreach (Akt item in aktlista)
                {
                    totalpris += session.barn * item.barn;
                    totalpris += session.ungdom * item.ungdom;
                    totalpris += session.vuxna * item.vuxen;
                }
            }

            session.totalpris = totalpris;
            label2.Visible = true;
            label2.Text = session.totalpris.ToString();
                  */


            }


        }

        private int LaggTillTempkop()
        {
            string query = "INSERT INTO tempkop (forestallning, vuxna, ungdom, barn) VALUES(@forestallning, @vuxna, @ungdom, @barn)";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);

            command.Parameters.AddWithValue("@forestallning", session.forestallning.id);
            command.Parameters.AddWithValue("@vuxna", session.vuxna);
            command.Parameters.AddWithValue("@ungdom", session.ungdom);
            command.Parameters.AddWithValue("@barn", session.barn);
            return command.ExecuteNonQuery();

        }
        private int HamtaMaxId(string q, string radnamn)
        {
            int idnummer = 0;
            DataTable dt3 = new DataTable();
            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(q, conn);
                da.Fill(dt3);

                foreach (DataRow row in dt3.Rows)
                {
                    string namn = row[radnamn].ToString();
                    idnummer = Convert.ToInt32(namn);
                }

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return idnummer;
        }

        private int LaggTillAktlista(Akt aktinfo)
        {
            int id1 = HamtaMaxId("SELECT MAX(id) from tempkop", "max");
            string query = "INSERT INTO aktlista (akt, tempkop) VALUES(@akt, @tempkop)";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
                       
                command.Parameters.AddWithValue("@akt", aktinfo.id);
                command.Parameters.AddWithValue("@tempkop", id1);
                  

            

            return command.ExecuteNonQuery();
            // Gör om så vi arbetar mot idnummer.

        }
        private void uppdateraPris()
        {
            if (antal_ar_siffror() == true)
            {
                int totalpris = 0;
                int b = Convert.ToInt32(textBox_barn.Text);
                int u = Convert.ToInt32(textBox_ungdom.Text);
                int v = Convert.ToInt32(textBox_vuxen.Text);

                if (helaforestallningen() == true)
                {
                    Forestallning f = new Forestallning();
                    f = (Forestallning)listBox_forestallning.SelectedItem;
                    totalpris += f.vuxen * v;
                    totalpris += f.ungdom * u;
                    totalpris += f.barn * b;
                }
                else
                {
                    foreach (Akt item in listBox_akter.SelectedItems)
                    {
                        totalpris += item.barn * b;
                        totalpris += item.ungdom * u;
                        totalpris += item.vuxen * v;
                    }
                }

                session.totalpris = totalpris;
                label2.Visible = true;
                label2.Text = totalpris.ToString();

            }
            


 

            /*     if (session.hela == true)
                 {
                     totalpris += session.barn * session.forestallning.barn;
                     totalpris += session.ungdom * session.forestallning.ungdom;
                     totalpris += session.vuxna * session.forestallning.vuxen;
                 }
                 else
                 {
                     foreach (Akt item in session.biljetter)
                     {
                         totalpris += session.barn * item.barn;
                         totalpris += session.ungdom * item.ungdom;
                         totalpris += session.vuxna * item.vuxen;
                     }
                 }

                 session.totalpris = totalpris;
                 label2.Visible = true;
                 label2.Text = session.totalpris.ToString();

                 */
        }
        private void textBox_vuxen_TextChanged(object sender, EventArgs e)
        {
            //Ska vi dölja dem innan man valt akt och föreställning
            if ((Forestallning)listBox_forestallning.SelectedItem != null && (Akt)listBox_akter.SelectedItem != null && antal_ar_siffror() == true)
            {

                uppdateraPris();

                //int totalpris = 0;

            }

            
            /*
            Forestallning fs = (Forestallning)listBox_forestallning.SelectedItem;
            List<Akt> a = new List<Akt>();
            int x = 0;

            foreach (Akt item in listBox_akter.SelectedItems)
            {
                

            } */

            

            //label2

        }

        private void totpris(string typ)
        {

        }

        private void textBox_ungdom_TextChanged(object sender, EventArgs e)
        {
            if ((Forestallning)listBox_forestallning.SelectedItem != null && (Akt)listBox_akter.SelectedItem != null)
            {
                /*int totalpris = 0;
                int antal = Convert.ToInt32(textBox_ungdom.Text);
                foreach (Akt akt in listBox_akter.SelectedItems)
                {
                    for (int i = 0; i < antal; i++)
                    {
                        skapaTempkop("ungdom", akt, akt.ungdom);
                    }
                    
                }
                foreach (Biljett b in session.biljetter)
                {
                    totalpris += totalpris;
                } */
                uppdateraPris();
            }
        }

        private void textBox_barn_TextChanged(object sender, EventArgs e)
        {
            if ((Forestallning)listBox_forestallning.SelectedItem != null && (Akt)listBox_akter.SelectedItem != null)
            {
                /* int totalpris = 0;
                 int antal = Convert.ToInt32(textBox_barn.Text);
                 foreach (Akt akt in listBox_akter.SelectedItems)
                 {
                     for (int i = 0; i < antal; i++)
                     {
                         skapaTempkop("barn", akt, akt.barn);

                     }
                 }
                 foreach (Biljett b in session.biljetter)
                 {
                     totalpris += totalpris;
                 }*/
                uppdateraPris();
            }
        }

        private void listBox_akter_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if ((Akt)(listBox_akter.SelectedItem) != null)
            {
                Akt akt = (Akt)(listBox_akter.SelectedItem);

                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;

                noll();

                label5.Text = akt.vuxen.ToString();
                label6.Text = akt.ungdom.ToString();
                label7.Text = akt.barn.ToString();
                richTextBox2.Clear();
                if (listBox_akter.SelectedItems.Count > 0)
                {
                    foreach (Akt item in listBox_akter.SelectedItems)
                    {
                        richTextBox2.Text += item.namn + ": \n" + item.Aktinfo + "\n \n";
                    }
                }
                
                    
                
                
                
            }
            else
            {
                richTextBox2.Clear();
            }
            
            
        }

        private void noll()
        {
            
            textBox_barn.Text = "0";
            textBox_vuxen.Text = "0";
            textBox_ungdom.Text = "0";
            label2.Text = "0";
            session.totalpris = 0;
        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loginform lf = new Loginform();
            lf.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adminhuvudsida ah = new Adminhuvudsida(aktortyper);
            ah.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FinalPage fp = new FinalPage(aktortyper);
            fp.ShowDialog();
            this.Close();
        }
    }
}

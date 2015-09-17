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
        public Huvudsidan()
        {
            InitializeComponent();
        }
        public Huvudsidan(List<int> aktortypID)
        {
            InitializeComponent();
        }
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
        
        Tempkop session = new Tempkop();

        int totalpris = 0;
        int antalakter = 0;


        private void Huvudsidan_Load(object sender, EventArgs e)
        {
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
                    DateTime slutdatum = (DateTime)row["forsaljningslut"];
                   

                    if ((bool)row["open"] == true && slutdatum > DateTime.Now)
                    {
                        string namn = row["namn"].ToString();
                        string id = row["id"].ToString();
                        bool fri = (bool)row["fri_placering"];
                        int vuxen = Convert.ToInt32(row["vuxenpris"]);
                        int ungdom = Convert.ToInt32(row["ungdomspris"]);
                        int barn = Convert.ToInt32(row["barnpris"]);
                        DateTime datum = (DateTime)row["datum"];
                        DateTime tid = (DateTime)row["starttid"];
                        Forestallning fs = new Forestallning();
                        fs.akter = new List<Akt>();
                        fs.namn = namn;
                        fs.id = Convert.ToInt32(id);
                        fs.friplacering = fri;
                        fs.barn = barn;
                        fs.ungdom = ungdom;
                        fs.vuxen = vuxen;
                        fs.datum = datum;
                        fs.tid = tid;
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
                            string aktnamn = row2["aktinfo"].ToString();
                            string aktid = row2["id"].ToString();
                            //  int aktpris = Convert.ToInt32(row2["vuxenpris"]);
                            int vuxen2 = Convert.ToInt32(row2["vuxenpris"]);
                            int ungdom2 = Convert.ToInt32(row2["ungdomspris"]);
                            int barn2 = Convert.ToInt32(row2["barnpris"]);
                            akt.namn = aktnamn;
                            akt.id = Convert.ToInt32(aktid);
                            akt.vuxen = vuxen2;
                            akt.ungdom = ungdom2;
                            akt.barn = barn2;
                            fs.akter.Add(akt);
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
                label15.Text = fs.tid.ToShortTimeString();               
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

        private void button1_Click(object sender, EventArgs e)
        {


           ///asdf
        
            //Admin ska väll kunna ändra pris?
           if (session.reservation == true)
            {
                this.Hide();
                Kunduppgifter ku = new Kunduppgifter(session);
                ku.ShowDialog();
                this.Close();
            }
            else if (session.forestallning.friplacering == true)
            {
                //ladda biljett stuff direkt
                MessageBox.Show("ITS WORKING");
            }
            else
            {
                this.Hide();
                Platskarta pk = new Platskarta(session);
                pk.ShowDialog();
                this.Close();
            }


        }
        private void helaforestallningen()
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
                session.hela = true;
            }
            else
            {
                session.hela = false;
            }

        }
        private void skapaTempkop()
        {

            helaforestallningen();
            int loopar = 0;

            Tempkop s2 = new Tempkop();
            session = s2;
            List<Akt> aktlista = new List<Akt>();

            foreach (Akt akt in listBox_akter.SelectedItems)
            {
                aktlista.Add(akt);
                loopar++;           
            }

            
            session.akter = aktlista;
            session.forestallning = (Forestallning)listBox_forestallning.SelectedItem;
            session.vuxna = Convert.ToInt32(textBox_vuxen.Text.ToString());
            session.ungdom = Convert.ToInt32(textBox_ungdom.Text.ToString());
            session.barn = Convert.ToInt32(textBox_barn.Text.ToString());
            session.reservation = checkBox1.Checked;
            session.antal = 0;
            session.loopar = loopar;

            conn.Open();
            LaggTillTempkop(); //behövs den?
            conn.Close();


            /*
            string query = "SELECT biljettyp.rabattsats, biljettyp FROM public.biljettyp;";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);
            */
            int totalpris = 0;

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

        private void textBox_vuxen_TextChanged(object sender, EventArgs e)
        {
            skapaTempkop();
            
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
            skapaTempkop();
        }

        private void textBox_barn_TextChanged(object sender, EventArgs e)
        {
            skapaTempkop();
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
            }
            

        }

        private void noll()
        {
            
            textBox_barn.Text = "0";
            textBox_vuxen.Text = "0";
            textBox_ungdom.Text = "0";

            session.totalpris = 0;
        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loginform lf = new Loginform();
            lf.ShowDialog();
            this.Close();
        }
    }
}

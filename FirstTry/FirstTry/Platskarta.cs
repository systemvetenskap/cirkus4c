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
    partial class Platskarta : Form
    {
        Tempkop tk = new Tempkop();
        //  List<int> biljett_id = new List<int>();

        
        public Platskarta(Tempkop tk2)
        {
            InitializeComponent();
            tk = tk2;
        }

        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
        DataTable dt = new DataTable();
        int antalk = 0;

        //   int vilkenbiljett = 0;

        int death = 0;


        private void generellknapp(Button knapp)
        {

            

            if (radioButton_ungdom.Checked == false && radioButton_barn.Checked == false && radioButton_vuxen.Checked == false)
            {
                MessageBox.Show("Var vänlig välj en biljettyp");
            }
            else if(tk.hela == true)
            {
                /* foreach (Akt id in tk.akter)
                 {
                     bokaplats(knapp, id.id);
                 }*/

                for (int i = 0; i < tk.kunder[antalk].bilj.Count; i++)
                {
                    bokaplats(knapp, tk.kunder[antalk].bilj[i].akter.id);
                }

                labelkoll();
                antalk++;
                
               // radiokoll();
            }
            else
            {
                bokaplats(knapp, tk.akter[tk.antal].id);
            }
            rk2();
            radiokoll();
        }

        private void bokaplats(Button knapp, int id)
        {
            conn.Open();
            //dubbelkolla igen först så den inte är bokad

          //  ReserveraBiljett();
            if (ReserveraBiljett(knapp.Text) == -1)
            {
                this.Hide();
                Platskarta pk2 = new Platskarta(tk);
                pk2.ShowDialog();
                this.Close(); //ta bort this?
            }
          //  Innehaller(id, knapp.Text);
            conn.Close();

            knapp.BackColor = Color.Red;
            knapp.Enabled = false;

            if (tk.hela == true)
            {

            }
            else
            {
                labelkoll();
            }
            
        }
        private void labelkoll()
        {
            if (radioButton_barn.Checked == true)
            {
                // tk.typ.Add("barn");
                int x = Convert.ToInt32(label3.Text);
                x--;
                label3.Text = x.ToString();
                if (tk.hela == false)
                {
                    rk2();
                    radiokoll();
                }

            }
            if (radioButton_ungdom.Checked == true)
            {
                // tk.typ.Add("ungdom");
                int x = Convert.ToInt32(label2.Text);
                x--;
                label2.Text = x.ToString();
                if (tk.hela == false)
                {
                    rk2();
                    radiokoll();
                }
            }
            if (radioButton_vuxen.Checked == true)
            {
                //tk.typ.Add("vuxen");
                int x = Convert.ToInt32(label1.Text);
                x--;
                label1.Text = x.ToString();
                if (tk.hela == false)
                {
                    rk2();
                    radiokoll();
                }
            }
        }

        private void skapakundKlass()
        {
            
            int antal = tk.vuxna + tk.barn + tk.ungdom;
            string namn = "k";



            for (int i = 0; i < antal; i++)
            {
                for (int j = 0; j < tk.akter.Count; j++)
                {
                    Kund k = new Kund();
                    

                    tk.kunder.Add(k);
                }
                
            }

            for (int i = 0; i < tk.akter.Count; i++)
            {
                for (int j = 0; j < tk.biljetter.Count; j++)
                {
                    if (tk.biljetter[j].akter.id == tk.akter[i].id)
                    {

                    }
                }
            }




        }
        private int ReserveraBiljett(string kn)
        {
            conn.Close();
            conn.Open();
            try
            {
                string query = "INSERT INTO biljett (pris, forestallning_id, akt_id, biljettyp, plats_id, reserverad) VALUES(@pris, @forestallning_id, @akt_id, @biljettyp, @plats_id, @reserverad) RETURNING id;";
                Biljett biljetten = new Biljett();
                NpgsqlCommand command = new NpgsqlCommand(query, conn);

                tk.biljetter[tk.fuskIgen].plats_id = KnappId(kn);

                command.Parameters.AddWithValue("@pris", tk.biljetter[tk.fuskIgen ].pris);
                command.Parameters.AddWithValue("@forestallning_id", tk.biljetter[tk.fuskIgen].forestallning.id);
                command.Parameters.AddWithValue("@akt_id", tk.biljetter[tk.fuskIgen].akter.id);
                command.Parameters.AddWithValue("@biljettyp", tk.biljetter[tk.fuskIgen].biljettyp);
                command.Parameters.AddWithValue("@plats_id", tk.biljetter[tk.fuskIgen].plats_id);
                command.Parameters.AddWithValue("@reserverad", tk.biljetter[tk.fuskIgen].resserverad);

                int x = (int)command.ExecuteScalar();
                
                //  biljett_id.Add(x);
                //   tk.biljett_id.Add(x);
                tk.biljetter[tk.fuskIgen].biljett_id = x;
                tk.biljetter[tk.fuskIgen].kopt = true;

                tk.fuskIgen++;
                
                return x;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tyvärr blev platsen precis bokad" + ex.ToString());

                return -1;
                //throw;
            }
            conn.Close();


            // nyssInlagdBiljett();




            //command.Parameters.AddWithValue("@tidsstampel", session.forestallning.ToString());
            //command.Parameters.AddWithValue("@datum", session.vuxna);
            //command.Parameters.AddWithValue("@tid", session.ungdom);

        }
        private void nyssInlagdBiljett()
        {
            string query = "SELECT CURRVAL('biljett','id')";

            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                tk.biljett_id.Add(Convert.ToInt32(item["id"]));
            }
        }

        private int Innehaller(int aktint, string kn)
        {
            //ReserveraBiljett(kn);
            //tk.platsnamn.Add(kn);
            return -1;

          /*  if (tk.reservation == true)
            {
                string query2 = "INSERT INTO innehaller (akter_id, platser_id, biljett_id, tidsstampel, reserverad, kund_id) VALUES(@akter_id, @platser_id, (select max(id) from biljett), @tidsstampel, @reserverad, @kund_id)";

                try
                {
                    NpgsqlCommand command2 = new NpgsqlCommand(query2, conn);

                    command2.Parameters.AddWithValue("@akter_id", aktint);
                    command2.Parameters.AddWithValue("@platser_id", KnappId(kn));
                    command2.Parameters.AddWithValue("@tidsstampel", DateTime.Now);
                    command2.Parameters.AddWithValue("@reserverad", true);
                    command2.Parameters.AddWithValue("@kund_id", tk.kund_id);

                    return command2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tyvärr blev platsen precis bokad" + ex.ToString());

                    return -1;
                    //throw;
                }

            }
            else
            {
                try
                {
                    string query2 = "INSERT INTO innehaller (akter_id, platser_id, biljett_id, reserverad) VALUES(@akter_id, @platser_id, (select max(id) from biljett), @reserverad)";

                    NpgsqlCommand command2 = new NpgsqlCommand(query2, conn);

                    int knapp = KnappId(kn);

                    command2.Parameters.AddWithValue("@akter_id", aktint);
                    command2.Parameters.AddWithValue("@platser_id", knapp);
                    command2.Parameters.AddWithValue("@reserverad", false);


                    return command2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tyvärr blev platsen precis bokad" + ex.ToString());

                    return -1;
                    //throw;
                }

            } */

        }

        private int KnappId(string knappnamn)
        {
            string query = "select id from platser where nummer = '" + knappnamn + "'";
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            da.Fill(dt);
            string id = "";

            foreach (DataRow row in dt.Rows)
            {
                id = row["id"].ToString();
            }

            int idnummer = Convert.ToInt32(id);

            return idnummer;
        }

        private void backbone(Akt akten)
        {
            label1.Text = tk.vuxna.ToString();
            label2.Text = tk.ungdom.ToString();
            label3.Text = tk.barn.ToString();
            label5.Text = tk.biljetter[tk.fuskIgen].forestallning.namn;
            label6.Text = tk.biljetter[tk.fuskIgen].akter.namn;
            rk2();
         //   label8.Text = tk.totalpris.ToString() + " Kr";


        //    radiokoll(); den var här förut, funkade, beehövs den`?



            //Akt temp = new Akt();

            //temp = tk.akter[tk.antal];

            //  int id = tk.biljetter[tk.fuskIgen].akter.id;
            int id = akten.id;
            string query = "select * from biljett where akt_id = ";
            query += id.ToString();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            da.Fill(dt);
            int x = 0;
            x = tk.vuxna + tk.barn + tk.ungdom;

           /* if (x >= 8)
            {
                MessageBox.Show("Tyvärr finns inte tillräkligt med plats, utanför");
                this.Hide();
                Huvudsidan hu = new Huvudsidan();
                hu.ShowDialog();
                Close(); 
            }*/
            //Här ska tk metoden ligga, kanske :p

            foreach (DataRow row in dt.Rows)
            {



             /*   if (x >= 8)
                {
                    MessageBox.Show("Tyvärr finns inte tillräkligt med plats, innanför");
                    this.Hide();
                    Huvudsidan hu = new Huvudsidan();
                    hu.ShowDialog();
                    Close();
                }
                else
                { */
                    string platsid = row["plats_id"].ToString();
                    bool vecka = false;

                /*    if ((bool)row["reserverad"] == true)
                    {
                        DateTime dat = (DateTime)row["tidsstampel"];
                        DateTime nu = DateTime.Now;
                        TimeSpan ts = new TimeSpan(0, 0, 0, 15);
                        TimeSpan elapsed = nu.Subtract(dat);

                        if (elapsed > ts)
                        {
                            vecka = true;
                        }
                    }
                    */
                    string query2 = "select nummer from platser where id =" + platsid;



                    NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(query2, conn);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    DataTableReader dr = new DataTableReader(dt2);

                    string platsnamn = "";


                    while (dr.Read())
                    {
                        string fusk = "button_";
                        platsnamn = dr[0].ToString();
                        fusk += platsnamn;

                        gk(button_A1, fusk, vecka, platsid, id);
                        gk(button_A2, fusk, vecka, platsid, id);
                        gk(button_A3, fusk, vecka, platsid, id);
                        gk(button_A4, fusk, vecka, platsid, id);
                        gk(button_A5, fusk, vecka, platsid, id);
                        gk(button_A6, fusk, vecka, platsid, id);
                        gk(button_A7, fusk, vecka, platsid, id);
                        gk(button_A8, fusk, vecka, platsid, id);

                        gk(button_B1, fusk, vecka, platsid, id);
                        gk(button_B2, fusk, vecka, platsid, id);
                        gk(button_B3, fusk, vecka, platsid, id);
                        gk(button_B4, fusk, vecka, platsid, id);
                        gk(button_B5, fusk, vecka, platsid, id);
                        gk(button_B6, fusk, vecka, platsid, id);
                        gk(button_B7, fusk, vecka, platsid, id);
                        gk(button_B8, fusk, vecka, platsid, id);

                        gk(button_D1, fusk, vecka, platsid, id);
                        gk(button_D2, fusk, vecka, platsid, id);
                        gk(button_D3, fusk, vecka, platsid, id);
                        gk(button_D4, fusk, vecka, platsid, id);
                        gk(button_D5, fusk, vecka, platsid, id);
                        gk(button_D6, fusk, vecka, platsid, id);
                        gk(button_D7, fusk, vecka, platsid, id);
                        gk(button_D8, fusk, vecka, platsid, id);

                        gk(button_F1, fusk, vecka, platsid, id);
                        gk(button_F2, fusk, vecka, platsid, id);
                        gk(button_F3, fusk, vecka, platsid, id);
                        gk(button_F4, fusk, vecka, platsid, id);
                        gk(button_F5, fusk, vecka, platsid, id);
                        gk(button_F6, fusk, vecka, platsid, id);
                        gk(button_F7, fusk, vecka, platsid, id);
                        gk(button_F8, fusk, vecka, platsid, id);

                    // }
                }
                dr.Close();
                x++;
            }
        }

        /*  private DateTime kop_slut()
           {
               DataTable dt2 = new DataTable();
               string query = "select forsaljningslut from forestallning where id = ";
               query += tk.forestallning.id.ToString();
               NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
               da.Fill(dt2);

               foreach (DataRow fslut in dt2.Rows)
               {              
                   return (DateTime)fslut["forsaljningslut"];
               }

               return DateTime.Now;
           }

           private DateTime tid_vid_kop()
           {
               DataTable dt2 = new DataTable();
               string query = "SELECT biljett.tid_vid_kop, platser.nummer, platser.id FROM public.biljett, public.innehaller, public.platser WHERE innehaller.biljett_id = biljett.id AND innehaller.platser_id = platser.id;";
               query += tk.forestallning.id.ToString();
               NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
               da.Fill(dt2);

               foreach (DataRow bslut in dt2.Rows)
               {
                   return (DateTime)bslut["tid_vid_kop"];
               }

               return DateTime.Now;
           }
           */
        private void Platskarta_FormClosing(object sender, FormClosedEventArgs e)
        {
            death = 666;
         //   Application.Exit();
           // Environment.Exit(0);
        }
        private void Platskarta_Load(object sender, EventArgs e)
        {



            label8.Text = tk.totalpris.ToString() + " Kr";

            // DateTime dtr = new DateTime();

            // dtr = kop_slut();
            conn.Open();
            if (tk.hela == true)
            {
                foreach (Akt item in tk.akter)
                {
                    backbone(item);
                }
                label6.Text = "Alla akter";
            }
            else
            {
                //Akt temp = new Akt();

                // temp = tk.akter[tk.antal];
                // här är den som funkade förut backbone(tk.akter[tk.antal]);
                backbone(tk.biljetter[tk.fuskIgen].akter);
            }

            conn.Close();

        }
        private void rk2()
        {
            int x = 0;
            if (Convert.ToInt32(label1.Text) <= 0)
            {
                radioButton_vuxen.Enabled = false;
                radioButton_vuxen.Checked = false;
                x++;
            }
            if (Convert.ToInt32(label2.Text) <= 0)
            {
                radioButton_ungdom.Enabled = false;
                radioButton_ungdom.Checked = false;
                x++;
            }
            if (Convert.ToInt32(label3.Text) <= 0)
            {
                radioButton_barn.Enabled = false;
                radioButton_barn.Checked = false;
                x++;
            }
        }
        private void radiokoll()
        {


            /*     if (tk.biljetter[tk.fuskIgen].biljettyp == "vuxen")
                 {
                     radioButton_vuxen.Checked = true;
                 }
                 else if (tk.biljetter[tk.fuskIgen].biljettyp == "ungdom")
                 {
                     radioButton_ungdom.Checked = true;
                 }
                 else if (tk.biljetter[tk.fuskIgen].biljettyp == "barn")
                 {
                     radioButton_barn.Checked = true;
                 }

         */
            bool kopt = true;
            int antalkopta = 0;
            int ai = tk.fuskIgen - 1;

            foreach (Biljett b in tk.biljetter)
            {
                if (b.akter.id == tk.biljetter[ai].akter.id)
                {
                    if (b.kopt != true)
                    {
                        kopt = false;
                    }
                }
            }




            if (kopt == true)
            {
              

                    tk.antal++;
                    this.Hide();

                if (tk.antal < tk.loopar && tk.hela == false)
                {
                    Platskarta pk2 = new Platskarta(tk);
                    pk2.ShowDialog();

                }
                else if (tk.fardig == true)
                {
                    Huvudsidan hu = new Huvudsidan();
                    hu.ShowDialog();
                    this.Close();
                    //  Application.Exit();
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Vill du Slutföra köpet?", "Bokning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {


                        //biljettform ladda
                        FinalPage fp = new FinalPage(tk);
                        fp.ShowDialog();

                        this.Close();
                       // this.Dispose();


                    }
                    else if (dialogResult == DialogResult.No)
                    {

                        Huvudsidan hu = new Huvudsidan();
                        hu.ShowDialog();

                    }


                }

               
                
                this.Close();
                
            }

        }

        private int tabortreserv(string plats, int akt)
        {
            string dquery = "delete from innehaller where platser_id = " + plats + " and akter_id = " + akt + ";";
           
            NpgsqlCommand command = new NpgsqlCommand(dquery, conn);
            return command.ExecuteNonQuery();           
        }
        private void gk(Button bt, string namn, bool vecka, string plats, int akt)
        {
            if (bt.Name == namn)
            {

                if (vecka == true)
                {
                    conn.Open();
                    tabortreserv(plats, akt);
                    conn.Close();                    
                }
                else
                {
                    bt.Enabled = false;
                    bt.BackColor = Color.Red;
                }
            }
        }
        private void avbrytkop()
        {
            foreach (int bid in tk.biljett_id)
            {
                string dquery = "delete from innehaller where biljett_id = " + bid;

                NpgsqlCommand command = new NpgsqlCommand(dquery, conn);
                command.ExecuteNonQuery();
            }

        }

        private void button_A1_Click(object sender, EventArgs e)
        {
            generellknapp(button_A1);
        }

        private void button_A2_Click(object sender, EventArgs e)
        {
            generellknapp(button_A2);
        }

        private void button_A3_Click(object sender, EventArgs e)
        {
            generellknapp(button_A3);
        }

        private void button_A4_Click(object sender, EventArgs e)
        {
            generellknapp(button_A4);
        }

        private void button_A5_Click(object sender, EventArgs e)
        {
            generellknapp(button_A5);
        }

        private void button_A6_Click(object sender, EventArgs e)
        {
            generellknapp(button_A6);
        }

        private void button_A7_Click(object sender, EventArgs e)
        {
            generellknapp(button_A7);
        }

        private void button_A8_Click(object sender, EventArgs e)
        {
            generellknapp(button_A8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            avbrytkop();
            conn.Close();

            this.Hide();
            Huvudsidan hs = new Huvudsidan();
            hs.ShowDialog();
            this.Close();
        }

        private void button_B1_Click(object sender, EventArgs e)
        {
            generellknapp(button_B1);
        }

        private void button_B2_Click(object sender, EventArgs e)
        {
            generellknapp(button_B2);
        }

        private void button_B3_Click(object sender, EventArgs e)
        {
            generellknapp(button_B3);
        }

        private void button_B4_Click(object sender, EventArgs e)
        {
            generellknapp(button_B4);
        }

        private void button_B5_Click(object sender, EventArgs e)
        {
            generellknapp(button_B5);
        }

        private void button_B6_Click(object sender, EventArgs e)
        {
            generellknapp(button_B6);
        }

        private void button_B7_Click(object sender, EventArgs e)
        {
            generellknapp(button_B7);
        }

        private void button_B8_Click(object sender, EventArgs e)
        {
            generellknapp(button_B8);
        }

        private void button_D1_Click(object sender, EventArgs e)
        {
            generellknapp(button_D1);
        }

        private void button_D2_Click(object sender, EventArgs e)
        {
            generellknapp(button_D2);
        }

        private void button_D3_Click(object sender, EventArgs e)
        {
            generellknapp(button_D3);
        }

        private void button_D4_Click(object sender, EventArgs e)
        {
            generellknapp(button_D4);
        }

        private void button_D5_Click(object sender, EventArgs e)
        {
            generellknapp(button_D5);
        }

        private void button_D6_Click(object sender, EventArgs e)
        {
            generellknapp(button_D6);
        }

        private void button_D7_Click(object sender, EventArgs e)
        {
            generellknapp(button_D7);
        }

        private void button_D8_Click(object sender, EventArgs e)
        {
            generellknapp(button_D8);
        }

        private void button_F1_Click(object sender, EventArgs e)
        {
            generellknapp(button_F1);
        }

        private void button_F2_Click(object sender, EventArgs e)
        {
            generellknapp(button_F2);
        }

        private void button_F3_Click(object sender, EventArgs e)
        {
            generellknapp(button_F3);
        }

        private void button_F4_Click(object sender, EventArgs e)
        {
            generellknapp(button_F4);
        }

        private void button_F5_Click(object sender, EventArgs e)
        {
            generellknapp(button_F5);
        }

        private void button_F6_Click(object sender, EventArgs e)
        {
            generellknapp(button_F6);
        }

        private void button_F7_Click(object sender, EventArgs e)
        {
            generellknapp(button_F7);
        }

        private void button_F8_Click(object sender, EventArgs e)
        {
            generellknapp(button_F8);
        }

        private void button_H1_Click(object sender, EventArgs e)
        {
            generellknapp(button_H1);
        }

        private void button_H2_Click(object sender, EventArgs e)
        {
            generellknapp(button_H2);
        }

        private void button_H3_Click(object sender, EventArgs e)
        {
            generellknapp(button_H3);
        }

        private void button_H4_Click(object sender, EventArgs e)
        {
            generellknapp(button_H4);
        }

        private void button_H5_Click(object sender, EventArgs e)
        {
            generellknapp(button_H5);
        }

        private void button_H6_Click(object sender, EventArgs e)
        {
            generellknapp(button_H6);
        }

        private void button_H7_Click(object sender, EventArgs e)
        {
            generellknapp(button_H7);
        }

        private void button_H8_Click(object sender, EventArgs e)
        {
            generellknapp(button_H8);
        }
    }
}

﻿using System;
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
    public partial class FormBehorigheter : Form
    {
        private List<int> aktortyper;
        private Personal valdpersonal;
        private Behorigheter valdbehorighet;
        private List<Personal> personallista = new List<Personal>();
        private List<Behorigheter> behorigheter = new List<Behorigheter>();
        
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

        public FormBehorigheter(List<int> aktortypID)
        {
           InitializeComponent();
            aktortyper = aktortypID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (listBoxAnvandare.SelectedIndex < 0)
            {
                MessageBox.Show("Hoppsan, du glömde visst välja användare");
            }
            else
            {
                conn.Open();
                laggTillBehorighet();
                conn.Close();
            }

 
        }
        private void updateraPersonalensBehorighet(string aktortyp_id)
        {
            int index = listBoxAnvandare.SelectedIndex;

            Personal p = (Personal)listBoxAnvandare.SelectedItem;

            

            List<Behorigheter> be = new List<Behorigheter>();

            foreach (Behorigheter b in p.behorigheter)
            {
                if (aktortyp_id != b.Id)
                {
                    be.Add(b);
                }
            }
            p.behorigheter = be;


            listBoxAnvandare.Items.Add(p);
            


        }
        private void taBortfranBehorighetsListan(string aktortyp_id, int pindex)
        {
            int x = 0;



            foreach (Behorigheter b in behorigheter)
            {
                if (aktortyp_id == b.Id)
                {
                    x++;
                    personallista[pindex].behorigheter.Add(b);
                }
            }


           






         /*   List<Behorigheter> be = new List<Behorigheter>();
            updateraPersonalensBehorighet(aktortyp_id);

            


            foreach (Behorigheter b in listBoxTabell.Items)
            {
                if (aktortyp_id != b.Id)
                {
                    be.Add(b);
                }
            }

            listBoxTabell.Items.Clear();

            foreach (Behorigheter b in be)
            {
                listBoxTabell.Items.Add(b);
            }
            */


        }


        private int laggTillBehorighet()
        {
          
            try
            {
                string query = "INSERT INTO aktortyplist(aktortyp_id, inlog_id) VALUES(@aktortyp_id, @inlog_id) ";

                NpgsqlCommand command = new NpgsqlCommand(query, conn);

             //   Personal p = new Personal();
                //  p = (Personal)listBoxAnvandare.SelectedItem;

                int pindex = listBoxAnvandare.SelectedIndex;
                int bindex = listBoxTabell.SelectedIndex;
                

             Behorigheter b = new Behorigheter();
             b = (Behorigheter)listBoxTabell.SelectedItem;




                command.Parameters.AddWithValue("@aktortyp_id", b.Id);
                command.Parameters.AddWithValue("@inlog_id", personallista[pindex].Id); //p.id innan
                aktortyper.Add(Convert.ToInt32(b.Id));



                taBortfranBehorighetsListan(b.Id, pindex);

                updateraBehorighetsListorna();

                //listBoxBehorighet.Items.Add(b);

                return command.ExecuteNonQuery();
                //  biljett_id.Add(x);
                //   tk.biljett_id.Add(x);
            }
            catch (Exception ex)
            {
                if (listBoxTabell.Items.Count == 0)
                {
                    MessageBox.Show("Det finns inga fler behörigheter att lägga till");

                }
                else
                {
                    MessageBox.Show("Hoppsan, du glöde välja behörighet att lägg till!");

                }


                //throw;
            }
            
            return -1;
            
        }
        private void tabortPeronalBehorighet(int pID, string bId)
        {

            //   personallista[pID].behorigheter.Remove()
            int bindex = listBoxBehorighet.SelectedIndex;
            int pindex = listBoxAnvandare.SelectedIndex;
            /*  if (personallista[pID].behorigheter[bindex].Id == bId)
              {
                  personallista[pID].behorigheter.RemoveAt(bindex);
              }
              */
            personallista[pindex].behorigheter.RemoveAt(bindex);

            updateraBehorighetsListorna();


        }
        private void taBortBehorighet()
        {

            Personal p = (Personal)listBoxAnvandare.SelectedItem;
            Behorigheter b = (Behorigheter)listBoxBehorighet.SelectedItem;
            try
            {
                string query = "delete from aktortyplist where inlog_id = ";
                query += p.Id + " and aktortyp_id = " + b.Id;





                tabortPeronalBehorighet(p.Id, b.Id);
                aktortyper.Remove(Convert.ToInt32(b.Id));


                NpgsqlCommand command = new NpgsqlCommand(query, conn);
                command.ExecuteNonQuery(); //this line here??


            }
            catch (Exception)
            {
                if (listBoxBehorighet.Items.Count == 0)
                {
                    MessageBox.Show("Det finns inte fler behörigheter att ta bort");

                }
                else
                {
                    MessageBox.Show("Hoppsan, du glömde välja behörighet att ta bort!");

                }

                // throw;
            }
        }
        private void btnTaBortBeh_Click(object sender, EventArgs e)
        {

            if (listBoxAnvandare.SelectedIndex < 0)
            {
                MessageBox.Show("Hoppsan, du glömde visst välja användare");
            }
            else
            {
                conn.Open();
                taBortBehorighet();
                conn.Close();
            }


            // MessageBox.Show(MessageBoxButtons.YesNo.ToString());



            // NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

            //try
            //{
            //    conn.Open();
            //    // dropdown NpgsqlCommand command = new NpgsqlCommand(@"REVOKE '" + txtObjektBehorighet + "' '" + txtObjektBehorighet + "' ON '" + txtTabell + "' FROM '" + txtAnvandare + "')", conn);

            //}
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    conn.Close();
            //}
        }

        private void listBoxBehorighet_SelectedIndexChanged(object sender, EventArgs e)
        {

       
            
            //valdbehorighet = (Behorigheter)listBoxBehorigheter.SelectedItem;
            //if (valdbehorighet != null)
            //{
            //    listBoxBehorigheter.DataSource = Databasmetoder.HamtaAkttypLista(valdbehorighet.id);
            //}
        }

        private void FormBehorigheter_Load(object sender, EventArgs e)
        {
            textBox5.UseSystemPasswordChar = true;
            hamtaPersonal();
            hamtaBehorighet();
        }

        private void hamtaPersonal()
        {

            DataTable dt = new DataTable();
            string query = "select * from inlog";

            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                da.Fill(dt);

                foreach (DataRow anvandare in dt.Rows)
                {
                    Personal tempp = new Personal();
                    tempp.Id = Convert.ToInt32(anvandare["id"]);
                    //  tempp. anvandarnamn = anvandare["anvandarnamn"].ToString();
                    // string losenord = anvandare["losenord"].ToString();
                    tempp.Fornamn = anvandare["fornamn"].ToString();
                    tempp.Efternamn = anvandare["efternamn"].ToString();
                  //  tempp.Personnr = anvandare["personnr"].ToString();

                    DataTable dt2 = new DataTable();
                    string query2 = "SELECT aktortyp.typ, aktortyplist.inlog_id, aktortyplist.aktortyp_id FROM public.aktortyp, public.aktortyplist, public.inlog WHERE aktortyp.id = aktortyplist.aktortyp_id AND aktortyplist.inlog_id = inlog.id AND inlog.id = ";
                    //   Personal p = (Personal)listBoxAnvandare.SelectedItem;
                    //  query2 += p.Id.ToString();
                    query2 += tempp.Id.ToString();

                    try
                    {
                        NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(query2, conn);
                        da2.Fill(dt2);

                        foreach (DataRow b in dt2.Rows)
                        {
                            Behorigheter beho = new Behorigheter();
                            beho.Typ = b["typ"].ToString();
                            beho.Id = b["aktortyp_id"].ToString();
                            tempp.behorigheter.Add(beho);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }


                    listBoxAnvandare.Items.Add(tempp);
                    personallista.Add(tempp);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        
        private void hamtaBehorighet()
        {
            DataTable dt2 = new DataTable();
            string query2 = "select * from aktortyp";
            //   Personal p = (Personal)listBoxAnvandare.SelectedItem;
            //  query2 += p.Id.ToString();

        
            try
            {
                NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(query2, conn);
                da2.Fill(dt2);

                foreach (DataRow b in dt2.Rows)
                {
                    Behorigheter beho = new Behorigheter();
                    beho.Typ = b["typ"].ToString();
                    beho.Id = b["id"].ToString();
                    listBoxTabell.Items.Add(beho);
                    behorigheter.Add(beho);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void updateraBehorighetsListorna()
        {

            listBoxTabell.Items.Clear();

            foreach (Behorigheter b in behorigheter)
            {
                listBoxTabell.Items.Add(b);
            }

            listBoxBehorighet.Items.Clear();



            List<int> behoID = new List<int>();

            Personal p = (Personal)listBoxAnvandare.SelectedItem;

            foreach (Behorigheter b in p.behorigheter)
            {
                behoID.Add(Convert.ToInt32(b.Id));
                listBoxBehorighet.Items.Add(b);

                for (int n = listBoxTabell.Items.Count - 1; n >= 0; --n)
                {
                    Behorigheter removelistitem = b;
                    if (listBoxTabell.Items[n].ToString().Contains(b.ToString()))
                    {
                        listBoxTabell.Items.RemoveAt(n);
                    }
                }
            }



        }

        private void listBoxAnvandare_SelectedIndexChanged(object sender, EventArgs e)
        {

            updateraBehorighetsListorna();
            /*listBoxBehorighet.Items.Clear();

            Personal p = (Personal)listBoxAnvandare.SelectedItem;

            foreach (Behorigheter b in p.behorigheter)
            {
                listBoxBehorighet.Items.Add(b);

                for (int n = listBoxTabell.Items.Count - 1; n >= 0; --n)
                {
                    Behorigheter removelistitem = b;
                    if (listBoxTabell.Items[n].ToString().Contains(b.ToString()))
                    {
                        listBoxTabell.Items.RemoveAt(n);
                    }
                }
            }*/

            /*

            listBoxTabell.Items.Clear();

            foreach (Behorigheter b in behorigheter)
            {
                listBoxTabell.Items.Add(b);
            }

            listBoxBehorighet.Items.Clear();



            List<int> behoID = new List<int>();

            Personal p = (Personal)listBoxAnvandare.SelectedItem;

            foreach (Behorigheter b in p.behorigheter)
            {
                behoID.Add(Convert.ToInt32(b.Id));
                listBoxBehorighet.Items.Add(b);

                for (int n = listBoxTabell.Items.Count - 1; n >= 0; --n)
                {
                    Behorigheter removelistitem = b;
                    if (listBoxTabell.Items[n].ToString().Contains(b.ToString()))
                    {
                        listBoxTabell.Items.RemoveAt(n);
                    }
                }
            }


            */



        }





                    private int laggTillAnvandare()
        {

            try
            {
                string query = "INSERT INTO inlog (anvandarnamn, losenord, fornamn, efternamn, personnr) VALUES(@anvandarnamn, @losenord, @fornamn, @efternamn, @personnr) RETURNING id;";
                Biljett biljetten = new Biljett();
                NpgsqlCommand command = new NpgsqlCommand(query, conn);



                command.Parameters.AddWithValue("@anvandarnamn", textBox4.Text);
                command.Parameters.AddWithValue("@losenord", textBox5.Text);
                command.Parameters.AddWithValue("@fornamn", textBox1.Text);
                command.Parameters.AddWithValue("@efternamn", textBox2.Text);
                command.Parameters.AddWithValue("@personnr", textBox3.Text);


                int x = (int)command.ExecuteScalar();

                //  biljett_id.Add(x);
                //   tk.biljett_id.Add(x);
                //      tk.biljetter[tk.fuskIgen].biljett_id = x;
                //       tk.biljetter[tk.fuskIgen].kopt = true;

                //       tk.fuskIgen++;

                //      return x;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hopsan  " + ex.ToString());

                return -1;
                //throw;
            }





            return -1;


        }
       /* private void button1_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            laggTillAnvandare();
            conn.Close();
        }*/

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vill du verkligen skapa en ny användare?", "Ny användare", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                conn.Open();
                laggTillAnvandare();

                listBoxAnvandare.Items.Clear();
                personallista.Clear();
                hamtaPersonal();
                conn.Close();
            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adminhuvudsida ah = new Adminhuvudsida(aktortyper);
            ah.ShowDialog();
            this.Close();
        }

        private void listBoxTabell_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Huvudsidan h = new Huvudsidan(aktortyper);
            h.ShowDialog();
            this.Close();
        }
    }
    }


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
    public partial class FormBehorigheter : Form
    {
        private Personal valdpersonal;
        private Behorigheter valdbehorighet;
        private List<Personal> personallista = new List<Personal>();
        private List<Behorigheter> behorigheter = new List<Behorigheter>();
        
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

        public FormBehorigheter()
        {
           InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            laggTillBehorighet();
            conn.Close();
        }

        private int laggTillBehorighet()
        {
          
            try
            {
                string query = "INSERT INTO aktortyplist(aktortyp_id, inlog_id) VALUES(@aktortyp_id, @inlog_id) ";

                NpgsqlCommand command = new NpgsqlCommand(query, conn);

                Personal p = new Personal();
                p = (Personal)listBoxAnvandare.SelectedItem;

                Behorigheter b = new Behorigheter();
                b = (Behorigheter)listBoxTabell.SelectedItem;


                command.Parameters.AddWithValue("@aktortyp_id", b.Id);
                command.Parameters.AddWithValue("@inlog_id", p.Id);
                
                listBoxBehorighet.Items.Add(b);
                return command.ExecuteNonQuery();
                //  biljett_id.Add(x);
                //   tk.biljett_id.Add(x);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tyvärr blev platsen precis bokad" + ex.ToString());


                //throw;
            }
            
            return -1;
            
        }

        private void btnTaBortBeh_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MessageBoxButtons.YesNo.ToString());

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
                    tempp.Personnr = anvandare["personnr"].ToString();

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }


        private void listBoxAnvandare_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxBehorighet.Items.Clear();

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
            }
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
                MessageBox.Show("Tyvärr blev platsen precis bokad" + ex.ToString());

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
            conn.Open();
            laggTillAnvandare();
            conn.Close();
        }
    }
    }


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
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
        
        Tempkop session = new Tempkop();
        List<Akt> aktlista = new List<Akt>();

        private void Huvudsidan_Load(object sender, EventArgs e)
        {
            //listBox_akter.SelectedIndex = -1;
            //listBox_forestallning.SelectedIndex = -1;
            DataTable dt = new DataTable();
            string query = "select namn, id from forestallning";
            //string forenamn = "forestallning";
            //int forenummer = 1;
            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {

                    string namn = row["namn"].ToString();
                    string id = row["id"].ToString();
                    Forestallning fs = new Forestallning();
                    fs.akter = new List<Akt>();                   
                    fs.namn = namn;
                    fs.id = Convert.ToInt32(id);
                    listBox_forestallning.Items.Add(fs);
                    //forenamn += forenummer;
                    //forenummer++;

                    
                    string query2 = "select aktinfo, id from akter where forestallningsid = " + fs.id.ToString();
                    NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(query2, conn);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    foreach (DataRow row2 in dt2.Rows)
                    {
                        Akt akt = new Akt();
                        string aktnamn = row2["aktinfo"].ToString();
                        string aktid = row2["id"].ToString();
                        akt.namn = aktnamn;
                        akt.id = Convert.ToInt32(aktid);
                        fs.akter.Add(akt);
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
            Forestallning fs = new Forestallning();
            fs.akter = new List<Akt>();
            listBox_akter.Items.Clear();
            fs = (Forestallning)listBox_forestallning.SelectedItem;
            foreach (Akt akt in fs.akter)
            {
                listBox_akter.Items.Add(akt);
            }


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
            foreach (Akt akt in listBox_akter.SelectedItems)
            {
                aktlista.Add(akt);
            }

            session.akter = aktlista;
            session.forestallning = (Forestallning)listBox_forestallning.SelectedItem;
            session.vuxna = Convert.ToInt32(textBox_vuxen.Text.ToString());
            session.ungdom = Convert.ToInt32(textBox_ungdom.Text.ToString());
            session.barn = Convert.ToInt32(textBox_barn.Text.ToString());
            conn.Open();
            LaggTillTempkop();

            foreach (Akt akt in aktlista)
            {
                LaggTillAktlista(akt);
            }
            conn.Close();
            this.Hide();
            Platskarta pk = new Platskarta(session);
            pk.ShowDialog();
            this.Close();
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
    }
}

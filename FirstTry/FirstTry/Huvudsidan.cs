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
        List<string> aktlista = new List<string>();

        private void Huvudsidan_Load(object sender, EventArgs e)
        {            
            DataTable dt = new DataTable();
            string query = "select namn, id from forestallning";

            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    string namn = row["namn"].ToString();
                    string id = row["id"].ToString();
                   
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
            listBox_akter.Items.Clear();
            string forestallning = listBox_forestallning.SelectedItem.ToString();
            string query2 = "SELECT akter.aktinfo FROM public.akter, public.forestallning WHERE akter.forestallningsid = forestallning.id AND forestallning.namn = '" + forestallning + "'";
            DataTable dt2 = new DataTable();
            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query2, conn);
                da.Fill(dt2);

                foreach (DataRow row in dt2.Rows)
                {
                    string namn = row["aktinfo"].ToString();

                    listBox_akter.Items.Add(namn);
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }                      
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            foreach (Object item in listBox_akter.SelectedItems)
            {
                aktlista.Add(item.ToString());
            }

            session.akter = aktlista;
            session.forestallning = listBox_forestallning.SelectedItem.ToString();
            session.vuxna = Convert.ToInt32(textBox_vuxen.Text.ToString());
            session.ungdom = Convert.ToInt32(textBox_ungdom.Text.ToString());
            session.barn = Convert.ToInt32(textBox_barn.Text.ToString());
            conn.Open();
            LaggTillTempkop();
            
            //foreach (string item in aktlista)
            //{
            //    LaggTillAktlista(item);
            //}
            conn.Close();
        }

        private int LaggTillTempkop()
        {
            String query = "INSERT INTO tempkop (forestallning, vuxna, ungdom, barn) VALUES(@forestallning, @vuxna, @ungdom, @barn)";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);

            command.Parameters.AddWithValue("@forestallning", session.forestallning);
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

        private int LaggTillAktlista(string aktinfo)
        {
            int id1 = HamtaMaxId("SELECT MAX(id) from tempkop", "max");
            string query = "INSERT INTO aktlista (akt, tempkop) VALUES(@akt, @tempkop)";
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
                       
                command.Parameters.AddWithValue("@akt", aktinfo);
                command.Parameters.AddWithValue("@tempkop", id1);
                  

            

            return command.ExecuteNonQuery();
            // Gör om så vi arbetar mot idnummer.

        }
    }
}

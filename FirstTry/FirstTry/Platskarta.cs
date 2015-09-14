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

        public Platskarta(Tempkop tk2)
        {
            InitializeComponent();
            tk = tk2;
        }

        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
        DataTable dt = new DataTable();    

        private void generellknapp(Button knapp)
        {
            conn.Open();
            //dubbelkolla igen först så den inte är bokad
            ReserveraBiljett();
            foreach (Akt akt in tk.akter)
            {
                Innehaller(akt.id, knapp.Text);
            }
            conn.Close();

            knapp.BackColor = Color.Red;
            knapp.Enabled = false;
        }

        private int ReserveraBiljett()
        {
            Biljett biljetten = new Biljett();
            string query = "INSERT INTO biljett (totalpris) VALUES(@totalpris)";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);

            //command.Parameters.AddWithValue("@tidsstampel", session.forestallning.ToString());
            //command.Parameters.AddWithValue("@datum", session.vuxna);
            //command.Parameters.AddWithValue("@tid", session.ungdom);
            command.Parameters.AddWithValue("@totalpris", 66);
            return command.ExecuteNonQuery();
        }

        private int Innehaller(int aktint, string kn)
        {
            string query = "INSERT INTO innehaller (akter_id, platser_id, biljett_id) VALUES(@akter_id, @platser_id, (select max(id) from biljett))";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);

            command.Parameters.AddWithValue("@akter_id", aktint);
            command.Parameters.AddWithValue("@platser_id", KnappId(kn));

            return command.ExecuteNonQuery();
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

        private void Platskarta_Load(object sender, EventArgs e)
        {
            label1.Text = tk.vuxna.ToString();
            label2.Text = tk.ungdom.ToString();
            label3.Text = tk.barn.ToString();
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
    }
}

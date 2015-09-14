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
    public partial class Platskarta : Form
    {
        public Platskarta()
        {
            InitializeComponent();
        }

        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
        DataTable dt = new DataTable();
        Tempkop tk = new Tempkop();

        private void button_A1_Click(object sender, EventArgs e)
        {
            conn.Open();
            ReserveraBiljett();


            foreach (Akt akt in tk.akter)
            {
                Innehaller(akt.id, button_A1.Text);
            }
            conn.Close();
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

            return Convert.ToInt32(dt.Rows.ToString());
        }

        private void Platskarta_Load(object sender, EventArgs e)
        {

            string query = "select * from tempkop where id = (select MAX(id) from tempkop)";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataTableReader dr = new DataTableReader(dt);
                    

            while (dr.Read())
            {
                tk.vuxna = Convert.ToInt32(dr[1]);
                tk.ungdom = Convert.ToInt32(dr[2]);
                tk.barn = Convert.ToInt32(dr[3]);
                label1.Text = tk.vuxna.ToString();
                label2.Text = tk.ungdom.ToString();
                label3.Text = tk.barn.ToString();
                //tk.forestallning = (Forestallning)dr[1];
            }
            

            //try
            //{
            //    List<int> lstSelect = new List<int>();

            //    NpgsqlCommand command = new NpgsqlCommand(query, conn);
            //    NpgsqlDataReader dr = command.ExecuteReader();

            //    while (dr.Read())
            //    {
            //        for (int i = 0; i < dr.FieldCount; i++)
            //        {
            //            lstSelect.Add(Convert.ToInt32(dr[i]));
            //        }
            //    }

            //}
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}


            //foreach (DataRow item in dt.Rows)
            //{
            //dt.Select("vuxna");
            int vuxna = Convert.ToInt32(dt.Select("vuxna"));
            //int ungdomar = Convert.ToInt32(item["ungdomar"]);
            //int barn = Convert.ToInt32(item["barn"]);
            tk.vuxna = vuxna;
            //tk.ungdom = ungdomar;
            //tk.barn = barn;

            //}
            




        }
    }
}

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

        private void Huvudsidan_Load(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            string query = "select namn from forestallning";

            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    string namn = row["namn"].ToString();

                    listBox_forestallning.Items.Add(namn);
                }                
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
    }
}

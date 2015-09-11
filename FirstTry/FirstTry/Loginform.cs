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
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            DataTable dt = new DataTable();
            string query = "SELECT id FROM inlog WHERE anvandarnamn = 'dilan' AND losenord = '123'";

            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    int nyint = Convert.ToInt32(row["id"].ToString());
                    if (nyint > 0)
                    {
                        this.Hide();
                        Huvudsidan hs = new Huvudsidan();
                        hs.ShowDialog();
                        this.Close();
                    }                                       
                }
                MessageBox.Show("Inloggning misslyckades");             
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }                  

        }
    }
}

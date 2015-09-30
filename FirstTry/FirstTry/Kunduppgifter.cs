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
    partial class Kunduppgifter : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
        Tempkop tk = new Tempkop();

        public Kunduppgifter(Tempkop tk2)
        {

            InitializeComponent();
            tk = tk2;

        }

        private int nyKund()
        {
            try
            {
                string query = "INSERT INTO kund(namn, telefon, mail, efternamn) VALUES (@namn, @telefon, @mail, @efternamn);";

                NpgsqlCommand command = new NpgsqlCommand(query, conn);

                command.Parameters.AddWithValue("@namn", textBox1.Text);
                command.Parameters.AddWithValue("@efternamn", textBox2.Text);
                command.Parameters.AddWithValue("@telefon", textBox3.Text);
                command.Parameters.AddWithValue("@mail", textBox4.Text);

                tk.epost = textBox4.Text;

                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Hoppsan, något gick fel");
                throw;
            }

        }

        private int nyKundID()
        {
            string query = "SELECT currval(pg_get_serial_sequence('kund','id'));";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            NpgsqlCommand nc = new NpgsqlCommand(query, conn);

            NpgsqlDataReader dr = nc.ExecuteReader();

            while(dr.Read())
            {
                return Convert.ToInt32(dr[0]);
            }
            return -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int x;

            if (int.TryParse(textBox3.Text, out x) == true && textBox3.Text.Count() < 14 && textBox3.Text.Count() > 7)
            {
                conn.Open();
                nyKund();
                //  tk.kund_id = nyKundID();
                conn.Close();

                this.Hide();
                Platskarta pk = new Platskarta(tk);
                pk.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Hoppsan, du skrev in telefonnummeret felaktigt");
            }

        }

        private void Kunduppgifter_Load(object sender, EventArgs e)
        {

        }
    }
}

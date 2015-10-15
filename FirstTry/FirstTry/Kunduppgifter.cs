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
        List<int> aktortyper = new List<int>();

        public Kunduppgifter(Tempkop tk2, List<int> aktortyperID)
        {

            InitializeComponent();
            tk = tk2;
            aktortyper = aktortyperID;
        }
        private void kundIDBiljetter(int x)
        {
            foreach (Biljett b in tk.biljetter)
            {
                b.kund_id = x;
            }
        }
        private int nyKund()
        {
            try
            {
                string query = "INSERT INTO kund(namn, telefon, mail, efternamn) VALUES (@namn, @telefon, @mail, @efternamn) RETURNING id;";

                NpgsqlCommand command = new NpgsqlCommand(query, conn);

                command.Parameters.AddWithValue("@namn", textBox1.Text);
                command.Parameters.AddWithValue("@efternamn", textBox2.Text);
                command.Parameters.AddWithValue("@telefon", textBox3.Text);
                command.Parameters.AddWithValue("@mail", textBox4.Text);

                tk.epost = textBox4.Text;

                int x = (int)command.ExecuteScalar();
                kundIDBiljetter(x);
                return x;
                //  return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Hoppsan, något gick fel");
                return -1;
                throw;
            }

        }
        bool kollarEpost()
        {
            try
            {
                var test = new System.Net.Mail.MailAddress(textBox4.Text);
                return test.Address == textBox4.Text;
            }
            catch
            {
                return false;
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

            if (textBox1.Text == "Förnamn:" || textBox1.Text.Count() < 2)
            {
                MessageBox.Show("Hoppsan, du skrev in förnamn felaktigt");

            }
            else if (textBox2.Text == "Efternamn:" || textBox2.Text.Count() < 2)
            {
                MessageBox.Show("Hoppsan, du skrev in efternamn felaktigt");
            }
            else if (int.TryParse(textBox3.Text, out x) == false && textBox3.Text.Count() > 14 && textBox3.Text.Count() < 7)
            {
                MessageBox.Show("Hoppsan, du skrev in telefonnummeret felaktigt");
            }
            else if (kollarEpost() == false)
            {
                MessageBox.Show("Hoppsan, du skrev in epost adressen felaktigt");

            }
            else
            {
                conn.Open();
                nyKund();
                //  tk.kund_id = nyKundID();
                conn.Close();



            }

        }

        private void Kunduppgifter_Load(object sender, EventArgs e)
        {

        }
    }
}

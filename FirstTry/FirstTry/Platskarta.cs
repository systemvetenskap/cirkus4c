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

            if (radioButton_ungdom.Checked == false && radioButton_barn.Checked == false && radioButton_vuxen.Checked == false)
            {
                MessageBox.Show("Var vänlig välj en biljettyp");
            }
            else
            {
                conn.Open();
                //dubbelkolla igen först så den inte är bokad
                ReserveraBiljett();
                Innehaller(tk.akter[tk.antal].id, knapp.Text);
                conn.Close();

                knapp.BackColor = Color.Red;
                knapp.Enabled = false;

                if (radioButton_barn.Checked == true)
                {
                    int x = Convert.ToInt32(label3.Text);
                    x--;
                    label3.Text = x.ToString();
                    radiokoll();
                }
                if (radioButton_ungdom.Checked == true)
                {
                    int x = Convert.ToInt32(label2.Text);
                    x--;
                    label2.Text = x.ToString();
                    radiokoll();
                }
                if (radioButton_vuxen.Checked == true)
                {
                    int x = Convert.ToInt32(label1.Text);
                    x--;
                    label1.Text = x.ToString();
                    radiokoll();
                }
            }
        }

        private int ReserveraBiljett()
        {

            string query = "";

            if (tk.reservation == true)
            {
                query = "INSERT INTO biljett (totalpris, tidsstampel) VALUES(@totalpris, @tidsstampel)";
                Biljett biljetten = new Biljett();
                NpgsqlCommand command = new NpgsqlCommand(query, conn);
                command.Parameters.AddWithValue("@totalpris", 66);
                command.Parameters.AddWithValue("@tidsstampel", DateTime.Now);
                //måste insert kund ID
                return command.ExecuteNonQuery();
            }
            else
            {
                query = "INSERT INTO biljett (totalpris) VALUES(@totalpris)";
                Biljett biljetten = new Biljett();
                NpgsqlCommand command = new NpgsqlCommand(query, conn);
                command.Parameters.AddWithValue("@totalpris", 66);

                return command.ExecuteNonQuery();
            }


            //command.Parameters.AddWithValue("@tidsstampel", session.forestallning.ToString());
            //command.Parameters.AddWithValue("@datum", session.vuxna);
            //command.Parameters.AddWithValue("@tid", session.ungdom);

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
            label5.Text = tk.forestallning.namn;
            label6.Text = tk.akter[tk.antal].namn;


            radiokoll();

            Akt temp = new Akt();

            temp = tk.akter[tk.antal];
            
            int id = temp.id;

            string query = "select platser_id from innehaller where akter_id = ";
            query += id.ToString();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            da.Fill(dt);
            int x = 0;
            x = tk.vuxna + tk.barn + tk.ungdom;

            if (x >= 8)
            {
                MessageBox.Show("Tyvärr finns inte tillräkligt med plats, utanför");
                this.Hide();
                Huvudsidan hu = new Huvudsidan();
                hu.ShowDialog();
                Close();
            }

            foreach (DataRow row in dt.Rows)
            {

                

                if (x >= 8)
                {
                    MessageBox.Show("Tyvärr finns inte tillräkligt med plats, innanför");
                    this.Hide();
                    Huvudsidan hu = new Huvudsidan();
                    hu.ShowDialog();
                    Close();
                }
                else
                {
                    string platsid = row["platser_id"].ToString();

                    string query2 = "select nummer from platser where id =" + platsid;



                    NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(query2, conn);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    DataTableReader dr = new DataTableReader(dt2);

                    string platsnamn = "";


                    while (dr.Read())
                    {
                        string fusk = "button_";
                        platsnamn = dr[0].ToString();
                        fusk += platsnamn;

                        gk(button_A1, fusk);
                        gk(button_A2, fusk);
                        gk(button_A3, fusk);
                        gk(button_A4, fusk);
                        gk(button_A5, fusk);
                        gk(button_A6, fusk);
                        gk(button_A7, fusk);
                        gk(button_A8, fusk);
                    }
                }
                x++;
            }

        }

        private void radiokoll()
        {
            int x = 0;
            if (Convert.ToInt32(label1.Text) == 0)
            {
                radioButton_vuxen.Enabled = false;
                radioButton_vuxen.Checked = false;
                x++;
            }
            if (Convert.ToInt32(label2.Text) == 0)
            {
                radioButton_ungdom.Enabled = false;
                radioButton_ungdom.Checked = false;
                x++;
            }
            if (Convert.ToInt32(label3.Text) == 0)
            {
                radioButton_barn.Enabled = false;
                radioButton_barn.Checked = false;
                x++;
            }
            if (x == 3)
            {

                tk.antal++;
                this.Hide();
                if (tk.antal < tk.loopar)
                {
                    
                    Platskarta pk2 = new Platskarta(tk);
                    pk2.ShowDialog();
                    

                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Vill du Slutföra köpet?", "Bokning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        

                        if (tk.reservation == true)
                        {
                            Kunduppgifter ku = new Kunduppgifter(tk);
                            ku.ShowDialog();
                        }
                        else
                        {
                            Huvudsidan hu = new Huvudsidan();
                            hu.ShowDialog();
                        }

                        
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //ej krav?!
                        Huvudsidan hu = new Huvudsidan();
                        hu.ShowDialog();
                    }

                }

                this.Close();
                
            }

        }
        private void gk(Button bt, string namn)
        {
            if (bt.Name == namn)
            {
                bt.Enabled = false;
                bt.BackColor = Color.Red;
            }
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

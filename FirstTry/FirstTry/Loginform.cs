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
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");


        private void button_login_Click(object sender, EventArgs e)
        {
            bool bolean = false;
            DataTable dt = new DataTable();
            string anv = textBox_anvandarnamn.Text;
            string losen = textBox_losenord.Text;

            string query = "SELECT id FROM inlog WHERE anvandarnamn = '" + anv + "' AND losenord = '" + losen + "'";

            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                da.Fill(dt);
                int nyint = 0;
                foreach (DataRow row in dt.Rows)
                {
                    nyint = Convert.ToInt32(row["id"].ToString());
                    if (nyint > 0)
                    {
                        bolean = true;
                    }
                                                              
                    
                                    
                }
                if (bolean == false)
                {
                    textBox_anvandarnamn.Text = "";
                    textBox_losenord.Text = "";
                    MessageBox.Show("Användarnamnet eller lösenordet var fel, var god försök igen.");
                }
                else
                {
                    bool admin = false;

                    string query2 = "select aktortyp_id from aktortyplist where inlog_id =" + nyint;
                    DataTable dt2 = new DataTable();
                    NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(query2, conn);
                    da2.Fill(dt2);



                    this.Hide();
                    List<int> aktortyper = new List<int>();
                    foreach (DataRow row in dt2.Rows)
                    {
                        
                        int x = Convert.ToInt32(row["aktortyp_id"]);
                        aktortyper.Add(x);



                        if (Convert.ToInt32(row["aktortyp_id"]) == 6)
                        {
                            AdminForm af = new AdminForm();
                            af.ShowDialog();
                        }
                        else if(Convert.ToInt32(row["aktortyp_id"]) == 3)
                        {
                            Huvudsidan hs = new Huvudsidan(aktortyper);
                            hs.ShowDialog();
                        }
                    }

                    this.Close();

                }

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }                  

        }

        private void Loginform_Load(object sender, EventArgs e)
        {
            textBox_losenord.UseSystemPasswordChar = true;
            /*
                        dateTimePicker2.Format = DateTimePickerFormat.Custom;
                        dateTimePicker2.CustomFormat = "HH mm";



                        dateTimePicker2.ShowUpDown = true;
                        */
            // conn.Open();
            // LaggTillAktlista();
            // conn.Close();


        }
        /*
       private int LaggTillAktlista()
       {
           
           string query = "INSERT INTO forestallning (open, fri_placering, forsaljningslut) VALUES(@open, @fri_placering, @forsaljningslut)";
           NpgsqlCommand command = new NpgsqlCommand(query, conn);

           DateTime dt2 = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;

           command.Parameters.AddWithValue("@open", true);
           command.Parameters.AddWithValue("@fri_placering", false);
           command.Parameters.AddWithValue("@forsaljningslut", dt2);

           return command.ExecuteNonQuery();
        // Gör om så vi arbetar mot idnummer.
    }
    */

        private void textBox_losenord_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}

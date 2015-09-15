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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

       NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
              DataTable dt = new DataTable();
                    string query = "select * from forestallning";
                   
                    try
                    {
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            
                            string namn = row["namn"].ToString();
                            string id = row["id"].ToString();
                            string generell_info = row["generell_info"].ToString();
                    
                            string starttid = row["starttid"].ToString();
                            DateTime starttid2 = DateTimeConverter.;
                            
                            Forestallning fs = new Forestallning();
                            fs.akter = new List<Akt>();                   
                            fs.namn = namn;
                            fs.id = Convert.ToInt32(id);
                            listBoxAdminForestallning.Items.Add(fs);
                       


                            string query2 = "select aktnr, id from akter";
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
    }
}

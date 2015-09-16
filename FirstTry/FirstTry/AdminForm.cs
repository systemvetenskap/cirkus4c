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
        Forestallning fs = new Forestallning();
        

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
            listBoxAdminForestallning.Items.Clear();
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
                            string generellinfo = row["generell_info"].ToString();
                          //string starttid = row["starttid"].ToString(); Måste ändra till datetime
                          //string sluttid = row["slutttid"].ToString(); Måste ändra till datetime
                             
                            string vuxenpris = row["vuxenpris"].ToString();
                            string ungdomspris = row["ungdomspris"].ToString();
                            string barnpris = row["barnpris"].ToString();
                            //bool open = (row["open"]);

                            //Forestallning fs = new Forestallning();
                            fs.akter = new List<Akt>();
                            fs.namn = namn;
                            fs.id = Convert.ToInt32(id);
                            fs.generellinfo = generellinfo;
                            //fs.vuxenpris = Convert.ToInt32(vuxenpris);
                            //fs.ungdomspris = Convert.ToInt32(ungdomspris); 
                            //fs.barnpris = Convert.ToInt32(barnpris); 

                    listBoxAdminForestallning.Items.Add(fs);
                       


                            //string query2 = "select aktnr, id from akter";
                            //NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(query2, conn);
                            //DataTable dt2 = new DataTable();
                            //da2.Fill(dt2);
                            //foreach (DataRow row2 in dt2.Rows)
                            //{
                            //    Akt akt = new Akt();
                            //    string aktnamn = row2["aktinfo"].ToString();
                            //    string aktid = row2["id"].ToString();
                            //    akt.namn = aktnamn;
                            //    akt.id = Convert.ToInt32(aktid);
                            //    fs.akter.Add(akt);
                            //}

                        }
                        //listBox_forestallning.Items.Add(namn);
                    }
                    catch (NpgsqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

        
        private void listBoxAdminForestallning_SelectedIndexChanged(object sender, EventArgs e)
        {


           //Forestallning fs2 = new Forestallning();
           //fs2.namn = listBoxAdminForestallning.SelectedItem.ToString();

           textBoxForestNamn.Text = listBoxAdminForestallning.SelectedItem.ToString();

            //this.Refresh();

        }


    }

                   
        }
    


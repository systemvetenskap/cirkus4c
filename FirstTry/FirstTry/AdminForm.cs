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
        List<Forestallning> forestallningslista = new List<Forestallning>();


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
            try
            {
                conn.Open();
                //MessageBox.Show(conn.State.ToString());
                NpgsqlCommand command = new NpgsqlCommand("Select namn from forestallning" , conn);
                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    listBoxAdminForestallning.Items.Add(dr["namn"]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
           
            //listBoxAdminForestallning.Items.Clear();
            //  DataTable dt = new DataTable();
            //        string query = "select * from forestallning";
                       
                   
            //        try
            //        {
            //            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            //            da.Fill(dt);

            //            foreach (DataRow row in dt.Rows)
            //            {
                            
                            //string namn = row["namn"].ToString();
                            //int id = Convert.ToInt32(row["id"]);
                            //string generellinfo = row["generell_info"].ToString();
                            //DateTime starttid = (DateTime)row["starttid"];
                            //DateTime sluttid = (DateTime)row["sluttid"];
                           
                    
                            // int vuxenpris = Convert.ToInt32(row["vuxenpris"]);
                            ////int ungdomspris = Convert.ToInt32(row["ungdomspris"]);
                            ////int barnpris = Convert.ToInt32(row["barnpris"]);
                          

                    //Markerat ut nedanstående tills jag fått rätt på ovanstånde/Jill
                    
                    //fs.akter = new List<Akt>(); 
                    //        fs.namn = namn;
                    //        fs.id = Convert.ToInt32(id);
                    //        fs.generellinfo = generellinfo;
                    //        fs.vuxenpris = Convert.ToInt32(vuxenpris);
                    //        fs.ungdomspris = Convert.ToInt32(ungdomspris); 
                    //        fs.barnpris = Convert.ToInt32(barnpris); 

                    //listBoxAdminForestallning.Items.Add(fs);
                       


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
                //    }
                //    catch (NpgsqlException ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //}

        
        private void listBoxAdminForestallning_SelectedIndexChanged(object sender, EventArgs e)
        {


           //Forestallning fs2 = new Forestallning();
           //fs2.namn = listBoxAdminForestallning.SelectedItem.ToString();

           textBoxForestNamn.Text = listBoxAdminForestallning.SelectedItem.ToString();

           

        }
        private int LaggTillForestallning()
        {
            Forestallning laggtillforestallning = new Forestallning();
            string query = "INSERT INTO forestallning (forestallning, namn, generell_info, starttid, sluttid, vuxenpris, ungdomspris, barnpris) VALUES(@namn, @generell_info, @starttid, @sluttid, vuxenpris, ungdomspris, barnpris)";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);

            command.Parameters.AddWithValue("@namn", laggtillforestallning.namn);
            command.Parameters.AddWithValue("@generellinfo", laggtillforestallning.generellinfo);
            command.Parameters.AddWithValue("@starttid", laggtillforestallning.starttid);
            command.Parameters.AddWithValue("@sluttid", laggtillforestallning.sluttid);
            command.Parameters.AddWithValue("@open", false);//false tills öppnad
            command.Parameters.AddWithValue("@vuxenpris", laggtillforestallning.vuxenpris);
            command.Parameters.AddWithValue("@ungdomspris", laggtillforestallning.ungdomspris);
            command.Parameters.AddWithValue("@barnpris", laggtillforestallning.barnpris);

            return command.ExecuteNonQuery();

        }

        private void buttonLaggTillForest_Click(object sender, EventArgs e)
        { 
            //Påbörjat knapp lägg till föreställning, dock osäker på huruvida vi skulle lägga texten
            //uppe i formen så låter det vara så här""
            
            fs.namn = (textBoxForestNamn.Text);
            fs.generellinfo = (richTextBoxForestInf.Text);
            //fs.starttid = 
            //fs.sluttid 
            //fs.open
            //fs.vuxenpris
            //fs.ungdomspris
            //fs.barnpris
            //conn.Open();
            //LaggTillForestallning();

            foreach (Forestallning forest in forestallningslista)
            {
                LaggTillForestallning();
            }
            this.Refresh();
            conn.Close();
           
        }
    }
}

                   

    


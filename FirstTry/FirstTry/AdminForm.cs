﻿using System;
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
        private Forestallning valdforestallning;
        private Akt valdAkt;
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
        
        public AdminForm()
        {
            InitializeComponent();
        }

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
            
            dateTimePickerTid.Enabled = true;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
           

            listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();

            dateTimePickerTid.Format = DateTimePickerFormat.Custom;
            dateTimePickerTid.CustomFormat = "yyyy-MM-dd  HH:mm";
            
           

        }
        private void listBoxAdminForestallning_SelectedIndexChanged(object sender, EventArgs e)
        {

                valdforestallning = (Forestallning)listBoxAdminForestallning.SelectedItem;
            if (valdforestallning != null)
            {
                listBoxAkter.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);
                textBoxForestNamn.Text = valdforestallning.namn;
                richTextBoxForestInf.Text = valdforestallning.generellinfo;
                textBoxForestStarttid.Text = valdforestallning.starttid.ToString();
                textBoxForestSluttid.Text = valdforestallning.sluttid.ToString();
                textBoxVuxenpris.Text = valdforestallning.vuxenpris.ToString();
                textBoxUngdomspris.Text = valdforestallning.ungdomspris.ToString();
                textBoxBarnpris.Text = valdforestallning.barnpris.ToString();

            }  
          }
       
        private int laggTillForest(string namn, string generellinfo, DateTime starttid, DateTime sluttid, int vuxenpris, int ungdomspris, int barnpris)
        {
           
           //// NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            conn.Open();
           // Forestallning laggtillforestallning = new Forestallning();
            string query = "INSERT INTO forestallning (namn, generell_info, starttid, sluttid, open, vuxenpris, ungdomspris, barnpris, fri_placering) VALUES(@namn, @generell_info, @starttid, @sluttid, @open, @vuxenpris, @ungdomspris, @barnpris, @fri_placering)";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);

            command.Parameters.AddWithValue("@namn", namn);
            command.Parameters.AddWithValue("@generell_info", generellinfo);
            command.Parameters.AddWithValue("@starttid", starttid);
            command.Parameters.AddWithValue("@sluttid", sluttid);
            command.Parameters.AddWithValue("@open", false);//false tills öppnad
            command.Parameters.AddWithValue("@vuxenpris", vuxenpris);
            command.Parameters.AddWithValue("@ungdomspris", ungdomspris);
            command.Parameters.AddWithValue("@barnpris", barnpris);
            command.Parameters.AddWithValue("@fri_placering", false);

            return command.ExecuteNonQuery();
        }
        private void buttonLaggTillForest_Click(object sender, EventArgs e)
        {

           // Forestallning tillagdfs = new Forestallning();
            //listBoxAdminForestallning.Items.Clear();
            
            string namn = textBoxForestNamn.Text;
            string generellinfo = richTextBoxForestInf.Text;
            DateTime starttid = Convert.ToDateTime(textBoxForestStarttid.Text);
            DateTime sluttid = Convert.ToDateTime(textBoxForestSluttid.Text);
            bool open = false;
            int vuxenpris = Convert.ToInt32(textBoxVuxenpris.Text);
            int ungdomspris = Convert.ToInt32(textBoxUngdomspris.Text);
            int barnpris = Convert.ToInt32(textBoxBarnpris.Text);
            bool friplacering = false;

            if (checkBoxfriPlacering.Checked == true)
            {
                friplacering = true;
            }

            Databasmetoder.LaggTillNyForestallning(namn, generellinfo, open, starttid, sluttid, vuxenpris, ungdomspris, barnpris, friplacering);

            //Databasmetoder.HamtaForestallningLista();
            listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();

            // conn.Open();

            //Databasmetoder.LaggTillNyForestallning(namn, generellinfo, starttid, sluttid, vuxenpris, ungdomspris, barnpris);



            //listBoxAdminForestallning.Items.Clear();
            //  listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();

            //NpgsqlCommand command = new NpgsqlCommand("Select * from forestallning", conn);
            //NpgsqlDataReader dr = command.ExecuteReader();
            //while (dr.Read())
            //{
            //    listBoxAdminForestallning.Items.Add(dr["namn"]);
            //} 
            //Databasmetoder.HamtaForestallningLista();

            //foreach (Forestallning forest in forestallningslista)
            //{
            //    LaggTillForestallning();
            //}
            //forestallningslista.Add(fs);

            conn.Close();

        }

        private void listBoxAkter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  listBoxAkter.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);
            // Akt valdAkt = new Akt();
            // Akt valdAkt = listBoxAkter.SelectedItem;
            //if ((Akt)(listBoxAkter.SelectedItem) != null)
            //{
            Akt valdAkt = (Akt)(listBoxAkter.SelectedItem);


            textBoxAktnamn.Text = valdAkt.namn;
            richTextBoxAktInf.Text = valdAkt.Aktinfo;
            textBoxAktStarttid.Text = valdAkt.Starttid.ToString();
            textBoxAktSluttid.Text = valdAkt.Sluttid.ToString(); 
            textBoxAktVuxenpris.Text = valdAkt.vuxen.ToString();
            textBoxAktUngdPris.Text = valdAkt.ungdom.ToString();
            TextBoxAktBarnpris.Text = valdAkt.barn.ToString();
        
         }


            private void tomTextBoxarAkt()
        {
            textBoxAktnamn.Clear();
            richTextBoxAktInf.Clear();
            textBoxAktStarttid.Clear();
            textBoxAktSluttid.Clear();
            textBoxAktVuxenpris.Clear();
            textBoxAktUngdPris.Clear();
            TextBoxAktBarnpris.Clear(); 
            
        }
             
        private void tomTextBoxarForestallning()
        {
            textBoxForestNamn.Clear();
            richTextBoxForestInf.Clear();
            textBoxForestStarttid.Clear();
            textBoxForestSluttid.Clear();
            textBoxVuxenpris.Clear();
            textBoxUngdomspris.Clear();
            textBoxBarnpris.Clear();
        }

        /* richTextBoxAktInf.Text = valdAkt.
        textBoxForestStarttid.Text = valdforestallning.starttid.ToString();
        textBoxForestSluttid.Text = valdforestallning.sluttid.ToString();
        textBoxVuxenpris.Text = valdforestallning.vuxenpris.ToString();
        textBoxUngdomspris.Text = valdforestallning.ungdomspris.ToString();
        textBoxBarnpris.Text = valdforestallning.barnpris.ToString();
        //listBoxAkter.DataSource */
    

    private void button1_Click_1(object sender, EventArgs e)
    { }

        

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void TextBoxAktBarnpris_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSkapaForestallning_Click(object sender, EventArgs e)
        {
            
            buttonLaggTillForest.Enabled = true;
            listBoxAdminForestallning.SelectionMode = SelectionMode.None;
            tomTextBoxarForestallning();


            //listBoxAdminForestallning.Items.Clear();
            //tomTextBoxar();
            //listBoxAdminForestallning.SelectedIndex = -1;
        }

        private void uppdatera_Click(object sender, EventArgs e)
        {
            int id = valdforestallning.id;
            string namn = textBoxForestNamn.Text;
            string generellinfo = richTextBoxForestInf.Text;
            DateTime starttid = Convert.ToDateTime(textBoxForestStarttid.Text);
            DateTime sluttid = Convert.ToDateTime(textBoxForestSluttid.Text);
            int vuxenpris = Convert.ToInt32(textBoxUngdomspris.Text);
            int ungdomspris = Convert.ToInt32(textBoxUngdomspris.Text);
            int barnpris = Convert.ToInt32(textBoxBarnpris.Text);


            Databasmetoder.UppdateraForestallning(id, namn, generellinfo, starttid, sluttid, vuxenpris, ungdomspris, barnpris);
            Databasmetoder.HamtaForestallningLista();
        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerTid_ValueChanged(object sender, EventArgs e)
        {
            buttonOppnaForest.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxForestNamn_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonOppnaForest_Click(object sender, EventArgs e)
        {

        }
    }
}



// datetime picker för att kunna sätta slutdatum för försäljning.
//lägga till behörighet. 
/*
try
            {
                conn.Open();
                //MessageBox.Show(conn.State.ToString());
                NpgsqlCommand command = new NpgsqlCommand("Select * from forestallning" , conn);
                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    listBoxAdminForestallning.Items.Add(dr["namn"]);
                    //fs.namn = textBoxForestNamn.Text;
                    // fs.generellinfo = richTextBoxForestInf.Text;
                    //fs.generellinfo = textBox2.Text;
                   

                    string namn = dr["namn"].ToString();
                    int id = Convert.ToInt32(dr["id"]);
                    string generellinfo = dr["generell_info"].ToString();
                    //  DateTime starttid = Convert.ToDateTime(dr["starttid"]); jörgens föslag
                    //DateTime sluttid = (DateTime)row["sluttid"];


                    // int vuxenpris = Convert.ToInt32(row["vuxenpris"]);
                    ////int ungdomspris = Convert.ToInt32(row["ungdomspris"]);
                    ////int barnpris = Convert.ToInt32(row["barnpris"]);

                    //fs.akter = new List<Akt>(); 
                       fs.namn = namn;
                        fs.id = id;
                       fs.generellinfo = generellinfo;
                    //        fs.vuxenpris = Convert.ToInt32(vuxenpris);
                    //        fs.ungdomspris = Convert.ToInt32(ungdomspris); 
                    //        fs.barnpris = Convert.ToInt32(barnpris); 

                    //listBoxAdminForestallning.Items.Add(fs);
                    forestallningslista.Add(fs);

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
                          //  DateTime starttid = Convert.ToDateTime(dr["starttid"]); jörgens föslag
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


*/





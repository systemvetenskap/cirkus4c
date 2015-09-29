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
        private List<int> aktorlistaId = new List<int>();
        private Forestallning valdforestallning;
        private Akt valdakt;
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

        public AdminForm()
        {
            InitializeComponent();
        }

        public AdminForm(List<int> aktorlista)
        {
            aktorlistaId = aktorlista;

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
            textBoxForsaljningsslut.Clear();
            valdforestallning = (Forestallning)listBoxAdminForestallning.SelectedItem;
            if (valdforestallning != null)
            {
                listBoxAkter.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);
                textBoxForestNamn.Text = valdforestallning.namn;
                richTextBoxForestInf.Text = valdforestallning.generellinfo;
                textBoxForestStarttid.Text = valdforestallning.starttid.ToShortTimeString();
                textBoxForestSluttid.Text = valdforestallning.sluttid.ToShortTimeString();
                textBoxVuxenpris.Text = valdforestallning.vuxenpris.ToString();
                textBoxUngdomspris.Text = valdforestallning.ungdomspris.ToString();
                textBoxBarnpris.Text = valdforestallning.barnpris.ToString();

                if (valdforestallning.friplacering == true)
                {
                    checkBoxfriPlacering.Checked = true;
                }
                else
                {
                    checkBoxfriPlacering.Checked = false;
                }

                if (valdforestallning.open == true)
                {
                    lblforestallningoppen.Visible = true;
                 
                    string sqlforsaljningslut = (@"SELECT forsaljningslut FROM forestallning WHERE id ='" + valdforestallning.id + "'");
                    
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand(sqlforsaljningslut, conn);
                    
                    NpgsqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        valdforestallning.forsaljningsslut = Convert.ToDateTime(dr["forsaljningslut"]);
                    }
                    conn.Close();
                    textBoxForsaljningsslut.Text = valdforestallning.forsaljningsslut.ToShortDateString() + " " +valdforestallning.forsaljningsslut.ToShortTimeString();
                  

                       
                    }
                else
                {
                    lblforestallningoppen.Visible = false;
                }
            }
        }

        private int laggTillForest(string namn, string generellinfo, DateTime starttid, DateTime sluttid, int vuxenpris, int ungdomspris, int barnpris)
        {

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
            listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();

            conn.Close();

        }

        private void listBoxAkter_SelectedIndexChanged(object sender, EventArgs e)
        {
            valdforestallning = (Forestallning)listBoxAdminForestallning.SelectedItem;
            if (valdforestallning != null)
            {
                valdakt = (Akt)listBoxAkter.SelectedItem;
                

                if (valdakt != null)
                {
                    textBoxAktnamn.Text = valdakt.namn.ToString();
                    richTextBoxAktInf.Text = valdakt.Aktinfo.ToString();
                    textBoxAktStarttid.Text = valdakt.Starttid.ToShortTimeString();
                    textBoxAktSluttid.Text = valdakt.Sluttid.ToShortTimeString();
                    textBoxAktVuxenpris.Text = valdakt.vuxen.ToString();
                    textBoxAktUngdPris.Text = valdakt.ungdom.ToString();
                    TextBoxAktBarnpris.Text = valdakt.barn.ToString();
                }

            }

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


        private void button1_Click_1(object sender, EventArgs e)
        {
            int fsid = valdforestallning.id;
            int id = valdakt.id;
            string namn = textBoxAktnamn.Text;
            string aktinfo = richTextBoxAktInf.Text;
            DateTime starttid = Convert.ToDateTime(textBoxAktStarttid.Text);
            DateTime sluttid = Convert.ToDateTime(textBoxAktSluttid.Text);
            int vuxen = Convert.ToInt32(textBoxAktVuxenpris.Text);
            int ungdom = Convert.ToInt32(textBoxAktUngdPris.Text);
            int barn = Convert.ToInt32(TextBoxAktBarnpris.Text);


            Forestallning fs = new Forestallning();
            fs = (Forestallning)listBoxAdminForestallning.SelectedItem;


            Databasmetoder.UppdateraAkt(id, namn, aktinfo, starttid, sluttid, vuxen, ungdom, barn);
            listBoxAkter.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);
        }



        private void button1_Click_2(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vill du radera denna akt?", "Akter", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                TaBortAkt();
            }
        
            else if (dialogResult == DialogResult.No)
            {
                Refresh();

    }
}

        private void TaBortAkt()
        {

            int groda = valdakt.id;

            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            NpgsqlTransaction trans = null;

            string sql3 = @"DELETE FROM aktlista WHERE akt = '" + groda + "' ";
            string sql6 = @"DELETE FROM innehaller WHERE akter_id = '" + groda + "' ";
            string sql7 = @"DELETE FROM biljett WHERE akt_id = '" + groda + "' ";
            string sql8 = @"DELETE FROM akter WHERE id = '" + groda + "' ";

            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                NpgsqlCommand command1 = new NpgsqlCommand(sql3, conn);
                command1.Transaction = trans;
                int numberOfAffectedRows1 = command1.ExecuteNonQuery();

                NpgsqlCommand command2 = new NpgsqlCommand(sql6, conn);
                command2.Transaction = trans;
                int numberOfAffectedRows2 = command2.ExecuteNonQuery();

                NpgsqlCommand command3 = new NpgsqlCommand(sql7, conn);
                command3.Transaction = trans;
                int numberOfAffectedRows3 = command3.ExecuteNonQuery();

                NpgsqlCommand command4 = new NpgsqlCommand(sql8, conn);
                command4.Transaction = trans;
                int numberOfAffectedRows4 = command4.ExecuteNonQuery();


                trans.Commit();
                listBoxAkter.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);
                MessageBox.Show("Föreställningen har raderats");

            }

            catch (NpgsqlException exception)
            {
                trans.Rollback();
                MessageBox.Show(exception.ToString());
            }
            finally
            {

                conn.Close();
            }
        }


        private void TextBoxAktBarnpris_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSkapaForestallning_Click(object sender, EventArgs e)
        {
            buttonLaggTillForest.Enabled = true;
            listBoxAdminForestallning.SelectionMode = SelectionMode.None;
            tomTextBoxarForestallning();
        }

        private void uppdatera_Click(object sender, EventArgs e)
        {
            int id = valdforestallning.id;
            string namn = textBoxForestNamn.Text;
            string generellinfo = richTextBoxForestInf.Text;
            bool open = false;
            DateTime starttid = Convert.ToDateTime(textBoxForestStarttid.Text);
            DateTime sluttid = Convert.ToDateTime(textBoxForestSluttid.Text);
            int vuxenpris = Convert.ToInt32(textBoxVuxenpris.Text);
            int ungdomspris = Convert.ToInt32(textBoxUngdomspris.Text);
            int barnpris = Convert.ToInt32(textBoxBarnpris.Text);
            bool friplacering = false;

            Databasmetoder.UppdateraForestallning(id, namn, generellinfo, open, starttid, sluttid, vuxenpris, ungdomspris, barnpris, friplacering);
            listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();
        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerTid_ValueChanged(object sender, EventArgs e)
        {

            btnOK.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxForestNamn_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonOppnaForest_Click(object sender, EventArgs e)
        {
           textBoxForsaljningsslut.Visible = true;
           dateTimePickerTid.Visible = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int id = valdforestallning.id;
            DateTime forsaljningsslut = Convert.ToDateTime(dateTimePickerTid.Text);
            Databasmetoder.UppdateraDateTimePicker(id, forsaljningsslut);

           

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnbehorigheter_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

            try
            {
                conn.Open();
                // dropdown command = new NpgsqlCommand(@"GRANT '" + txtObjektBehorighet + "' '" + txtObjektBehorighet + "' ON '" + txtTabell + "' FROM '" + txtAnvandare + "')", conn);

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

        }

        private void btnTaBortBehorighet_Click(object sender, EventArgs e)
        {

            MessageBox.Show(MessageBoxButtons.YesNo.ToString());

            // NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

            //try
            //{
            //    conn.Open();
            //    // dropdown NpgsqlCommand command = new NpgsqlCommand(@"REVOKE '" + txtObjektBehorighet + "' '" + txtObjektBehorighet + "' ON '" + txtTabell + "' FROM '" + txtAnvandare + "')", conn);

            //}
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    conn.Close();
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void buttonTaBort_Click(object sender, EventArgs e)
        {

            int padda = valdforestallning.id;
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            NpgsqlTransaction trans = null;

            DialogResult dialogResult = MessageBox.Show("Vill du radera hela föreställningen samt alla tillhörande akter?", "Bokning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (valdakt != null)
                {
                    TaBortAkt();
                }

                string sql1 = @"DELETE FROM tempkop WHERE forestallning = '" + padda + "' ";
                string sql2 = @"DELETE FROM biljett WHERE forestallning_id = '" + padda + "'";
                string sql3 = "DELETE FROM akter WHERE forestallningsid = '" + padda + "'";
                string sql4 = @"DELETE FROM forestallning WHERE id =  '" + padda + "'";

                try
                {

                    conn.Open();
                    trans = conn.BeginTransaction();

                    NpgsqlCommand command1 = new NpgsqlCommand(sql1, conn);
                    command1.Transaction = trans;
                    int numberOfAffectedRows1 = command1.ExecuteNonQuery();
                    MessageBox.Show(numberOfAffectedRows1 + " 1 rader har raderats");

                    NpgsqlCommand command2 = new NpgsqlCommand(sql2, conn);
                    command2.Transaction = trans;
                    int numberOfAffectedRows2 = command2.ExecuteNonQuery();
                    MessageBox.Show(numberOfAffectedRows2 + " 2 rader har raderats");

                    NpgsqlCommand command3 = new NpgsqlCommand(sql3, conn);
                    command3.Transaction = trans;
                    int numberOfAffectedRows3 = command3.ExecuteNonQuery();
                    MessageBox.Show(numberOfAffectedRows3 + " 3 rader har raderats");

                    NpgsqlCommand command4 = new NpgsqlCommand(sql4, conn);
                    command4.Transaction = trans;
                    int numberOfAffectedRows4 = command4.ExecuteNonQuery();
                    MessageBox.Show(numberOfAffectedRows3 + " 4 rader har raderats");

                    trans.Commit();
                    listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();
                }


                catch (NpgsqlException exception)
                {
                    trans.Rollback();
                    MessageBox.Show(exception.ToString());
                }
                finally
                {

                    conn.Close();


                }
            }
            else if (dialogResult == DialogResult.No)
            {
                Refresh();

            }
        }





        ////    //int padda = valdforestallning.id;
        ////    //NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");


        ////    if (valdakt != null)
        ////    {
        ////        TaBortAkt();
        ////    }

        ////    string sql1 = @"DELETE FROM tempkop WHERE forestallning = '" + padda + "' "; //från akt ?? foreställningsid = :valdforestallning.id hade du skrivit        
        ////    string sql2 = @"DELETE FROM biljett WHERE forestallning_id = '" + padda + "'";
        ////    string sql3 = "DELETE FROM akter WHERE forestallningsid = '" + padda + "'";
        ////    string sql4 = @"DELETE FROM forestallning WHERE id =  '" + padda + "'";

        ////    try
        ////    {
        ////        conn.Open();
        ////        trans = conn.BeginTransaction();

        ////        NpgsqlCommand command1 = new NpgsqlCommand(sql1, conn);
        ////        command1.Transaction = trans;
        ////        int numberOfAffectedRows1 = command1.ExecuteNonQuery();
        ////        MessageBox.Show(numberOfAffectedRows1 + " 1 rader har raderats");

        ////        NpgsqlCommand command2 = new NpgsqlCommand(sql2, conn);
        ////        command2.Transaction = trans;
        ////        int numberOfAffectedRows2 = command2.ExecuteNonQuery();
        ////        MessageBox.Show(numberOfAffectedRows2 + " 2 rader har raderats");

        ////        NpgsqlCommand command3 = new NpgsqlCommand(sql3, conn);
        ////        command3.Transaction = trans;
        ////        int numberOfAffectedRows3 = command3.ExecuteNonQuery();
        ////        MessageBox.Show(numberOfAffectedRows3 + " 3 rader har raderats");

        ////        NpgsqlCommand command4 = new NpgsqlCommand(sql4, conn);
        ////        command4.Transaction = trans;
        ////        int numberOfAffectedRows4 = command4.ExecuteNonQuery();
        ////        MessageBox.Show(numberOfAffectedRows3 + " 4 rader har raderats");

        ////        trans.Commit();
        ////        listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();

        ////    }

        ////    catch (NpgsqlException exception)
        ////    {
        ////        trans.Rollback();
        ////        MessageBox.Show(exception.ToString());
        ////    }
        ////    finally
        ////    {

        ////        conn.Close();
        ////    }
        ////}

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click_2(object sender, EventArgs e)
        {

        }

        private void btnAndraTaBortBeh_Click(object sender, EventArgs e)
        {
            //if (aktorlistaId != 6)
            //{
            //    btnAndraTaBortBeh.Enabled;
            //}

        }

        private void textBoxForsaljningsslut_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void buttonLaggTillAktInfo_Click(object sender, EventArgs e)
        {
          
            string namn = textBoxAktnamn.Text;
            //string aktinfo = richTextBoxAktInf.Text;
            //DateTime starttid = Convert.ToDateTime(textBoxAktStarttid.Text);
            //DateTime sluttid = Convert.ToDateTime(textBoxAktSluttid.Text);
            //int vuxen = Convert.ToInt32(textBoxAktVuxenpris.Text);
            //int ungdom = Convert.ToInt32(textBoxAktUngdPris.Text);
            //int barn = Convert.ToInt32(TextBoxAktBarnpris.Text);

            Databasmetoder.LaggTillNyAkt(namn);  //, aktinfo, starttid, sluttid, vuxen, ungdom, barn);
            listBoxAkter.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);

            conn.Close();
        }

        private void btnAkt_Click(object sender, EventArgs e)
        {
            buttonLaggTillAktInfo.Enabled = true;
            listBoxAkter.SelectionMode = SelectionMode.None;
            tomTextBoxarAkt();
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





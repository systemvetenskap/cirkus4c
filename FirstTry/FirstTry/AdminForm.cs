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


        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

            if (aktorlistaId.Contains(4) == true)
            {
                uppdatera.Enabled = true;
                buttonUppdateraAkt.Enabled = true;
                textBoxAktVuxenpris.Enabled = true;
                textBoxAktUngdPris.Enabled = true;
                TextBoxAktBarnpris.Enabled = true;
                textBoxVuxenpris.Enabled = true;
                textBoxUngdomspris.Enabled = true;
                textBoxBarnpris.Enabled = true;
                label13.Text = "Sista försäljningsdag \n YYYY-mm-dd HH:mm";
            }
            if (aktorlistaId.Contains(5) == true || aktorlistaId.Contains(7) == true)
            {
                this.btnAndraTaBortBeh.Enabled = true;
                this.btnAndraTaBortBeh.Visible = true;
            }
            if (aktorlistaId.Contains(9) == true)
            {
                checkBoxForestallning1.Enabled = true;
                uppdatera.Enabled = true;
                buttonUppdateraAkt.Enabled = true;
            }

            if (aktorlistaId.Contains(3) == true)
            {
                //Föreställning edit
                this.buttonLaggTillForest.Enabled = false;
                this.buttonLaggTillForest.Visible = false;
                this.btnSkapaForestallning.Enabled = true;
                this.btnSkapaForestallning.Visible = true;
                this.uppdatera.Enabled = true;
                this.uppdatera.Visible = true;
                this.buttonTaBort.Enabled = true;
                this.buttonTaBort.Visible = true;
                textBoxForestNamn.Enabled = true;
                richTextBoxForestInf.Enabled = true;
                textBoxForestDatum1.Enabled = true;
                textBoxForestStarttid.Enabled = true;
                textBoxForestSluttid.Enabled = true;
                textBoxForsaljningsslut.Enabled = true;
                checkBoxfriPlacering.Enabled = true;
                checkBoxForestallning1.Enabled = true;
                //Akt edit
                this.btnAkt.Enabled = true;
                this.btnAkt.Visible = true;
                this.buttonLaggTillAktInfo.Enabled = false;
                this.buttonLaggTillAktInfo.Visible = false;
                this.buttonUppdateraAkt.Enabled = true;
                this.buttonUppdateraAkt.Visible = true;
                this.button1.Enabled = true;
                this.button1.Visible = true;
                textBoxAktnamn.Enabled = true;
                richTextBoxAktInf.Enabled = true;
                textBoxAktStarttid.Enabled = true;
                textBoxAktSluttid.Enabled = true;

            }

            listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();

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
                textBoxForestDatum1.Text = valdforestallning.datum.ToShortDateString();
                textBoxForestStarttid.Text = valdforestallning.starttid.ToShortTimeString();
                textBoxForestSluttid.Text = valdforestallning.sluttid.ToShortTimeString();
                textBoxVuxenpris.Text = valdforestallning.vuxenpris.ToString();
                textBoxUngdomspris.Text = valdforestallning.ungdomspris.ToString();
                textBoxBarnpris.Text = valdforestallning.barnpris.ToString();
                textBoxForsaljningsslut.Text = valdforestallning.forsaljningsslut.ToShortDateString();

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
                    checkBoxForestallning1.Checked = true;
                }
                else
                {
                    checkBoxForestallning1.Checked = false;
                }

                    conn.Close();
                  
                    }
            Rapport();
        }
                




private void Rapport()
        {
            string sql = "SELECT coalesce (sum(case when id IS NOT NULL then 1 else 0 end), 0) as totalt, coalesce (sum(case when biljettyp = 'vuxen' then 1 else 0 end), 0) as vuxen, coalesce (sum(case when biljettyp = 'ungdom' then 1 else 0 end), 0) as ungdom, coalesce (sum(case when biljettyp = 'barn' then 1 else 0 end), 0) as barn, coalesce (sum(pris), 0) as totaltKr FROM biljett WHERE forestallning_id = " + valdforestallning.id;
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            
            NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int vuxen = Convert.ToInt32(dr["vuxen"]);
                    int ungdom = Convert.ToInt32(dr["ungdom"]);
                    int barn = Convert.ToInt32(dr["barn"]);
                    int totalt = Convert.ToInt32(dr["totalt"]);
                    int totaltKr = Convert.ToInt32(dr["totaltkr"]);
                    label20.Text = totalt.ToString() + " st";
                    label21.Text = vuxen.ToString() + " st";
                    label22.Text = ungdom.ToString() + " st";
                    label23.Text = barn.ToString() + " st";
                    label25.Text = totaltKr.ToString() + " kr";
                    //label14.Text = "Antal besökare";
                    label26.Text = valdforestallning.namn;
                }  
            
            conn.Close();

            string sql1 = "SELECT coalesce (sum(case when id IS NOT NULL then 1 else 0 end), 0) as totalt, coalesce (sum(case when biljettyp = 'vuxen' then 1 else 0 end), 0) as vuxen, coalesce (sum(case when biljettyp = 'ungdom' then 1 else 0 end), 0) as ungdom, coalesce (sum(case when biljettyp = 'barn' then 1 else 0 end), 0) as barn, coalesce (sum(pris), 0) as totaltKr FROM biljett;";
            conn.Open();

            NpgsqlCommand cmd1 = new NpgsqlCommand(sql1, conn);

            NpgsqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                int vuxen = Convert.ToInt32(dr1["vuxen"]);
                int ungdom = Convert.ToInt32(dr1["ungdom"]);
                int barn = Convert.ToInt32(dr1["barn"]);
                int totalt = Convert.ToInt32(dr1["totalt"]);
                int totaltKr = Convert.ToInt32(dr1["totaltkr"]);
                label39.Text = totalt.ToString() + " st";
                label38.Text = vuxen.ToString() + " st";
                label37.Text = ungdom.ToString() + " st";
                label36.Text = barn.ToString() + " st";
                label35.Text = totaltKr.ToString() + " kr";
               // label14.Text = "Antal besökare";
            }

            conn.Close();

            //string sql1 = "SELECT sum(pris) FROM biljett WHERE biljettyp = 'vuxen' UNION SELECT sum(pris) FROM biljett WHERE biljettyp = 'ungdom' UNION SELECT sum(pris) FROM biljett WHERE biljettyp = 'barn'";
            //conn.Open();
            //NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql1, conn);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //DataTableReader dr1 = new DataTableReader(dt);
            ////NpgsqlCommand cmd1 = new NpgsqlCommand(sql1, conn);

            ////NpgsqlDataReader dr1 = cmd1.ExecuteReader();
            //foreach (DataRow item in dt.Rows)
            //{
            //    int vuxen1 = Convert.ToInt32(dr1[0]);

            //    int barn1 = Convert.ToInt32(dr1[1]);
            //    int ungdom1 = Convert.ToInt32(dr1[2]);
            //    label27.Text = vuxen1.ToString() + " kr";
            //    label28.Text = ungdom1.ToString() + " kr";
            //    label29.Text = barn1.ToString() + " kr";
            //}




            //conn.Close();
        }




        private void buttonLaggTillForest_Click(object sender, EventArgs e)
        {
            try
            {

                string namn = textBoxForestNamn.Text;
                string generellinfo = richTextBoxForestInf.Text;
                DateTime datum = Convert.ToDateTime(textBoxForestDatum1.Text);
                DateTime starttid = Convert.ToDateTime(textBoxForestStarttid.Text);
                DateTime sluttid = Convert.ToDateTime(textBoxForestSluttid.Text);
                bool open = false;
                int vuxenpris = Convert.ToInt32(textBoxVuxenpris.Text);
                int ungdomspris = Convert.ToInt32(textBoxUngdomspris.Text);
                int barnpris = Convert.ToInt32(textBoxBarnpris.Text);
                bool friplacering = false;
                DateTime forsaljningsslut = Convert.ToDateTime(textBoxForsaljningsslut.Text);

                if (checkBoxfriPlacering.Checked == true)
                {
                    friplacering = true;
                }
                if (checkBoxForestallning1.Checked == true)
                {
                    valdforestallning.open = true;
                }
                else
                {
                    checkBoxForestallning1.Checked = false;
                }



                if (datum.Date >= DateTime.Now.Date)
                {
                    if (starttid.TimeOfDay < sluttid.TimeOfDay)
                    {
                        if (vuxenpris >= ungdomspris && vuxenpris >= barnpris && ungdomspris >= barnpris)
                        {
                            if (forsaljningsslut.Date >= datum.Date)
                            {
                                Databasmetoder.LaggTillNyForestallning(namn, generellinfo, open, datum, starttid, sluttid, vuxenpris, ungdomspris, barnpris, friplacering, forsaljningsslut);
                                listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();
                                buttonLaggTillForest.Enabled = false;
                                listBoxAdminForestallning.SelectionMode = SelectionMode.One;

                                conn.Close();
                                MessageBox.Show("Föreställningen är nu tillagd i föreställningslistan.");
                            }
                            else
                            {
                                MessageBox.Show("Du bör inte sälja biljetter efter att föreställningen spelats klart.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vuxen är dyrast, sedan kommer ungdom följt av barn.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Föreställningen är för kort!");
                    }

                }
                else
                {
                    MessageBox.Show("Sätt ett senare datum!");
                }

            }

            catch (Exception)
            {

                MessageBox.Show("Vänligen observera att alla textfält måste vara ifyllda korrekt, se exempelkod. Kontrollera även så att du inte glömt att fylla i ett textfält.");
            }

            finally
            {
                conn.Close();
               
            }
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
            textBoxForestDatum1.Clear();
            textBoxForestStarttid.Clear();
            textBoxForestSluttid.Clear();
            textBoxVuxenpris.Clear();
            textBoxUngdomspris.Clear();
            textBoxBarnpris.Clear();
            textBoxForsaljningsslut.Clear();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            //int fsid = valdforestallning.id;
            //int id = valdakt.id;
            //string namn = textBoxAktnamn.Text;
            //string aktinfo = richTextBoxAktInf.Text;
            //DateTime starttid = Convert.ToDateTime(textBoxAktStarttid.Text);
            //DateTime sluttid = Convert.ToDateTime(textBoxAktSluttid.Text);
            //int vuxen = Convert.ToInt32(textBoxAktVuxenpris.Text);
            //int ungdom = Convert.ToInt32(textBoxAktUngdPris.Text);
            //int barn = Convert.ToInt32(TextBoxAktBarnpris.Text);


            //Forestallning fs = new Forestallning();  //använder vi denna?????
            //fs = (Forestallning)listBoxAdminForestallning.SelectedItem;

            //Databasmetoder.UppdateraAkt(id, namn, aktinfo, starttid, sluttid, vuxen, ungdom, barn);
            //listBoxAkter.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);


            try
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

                DateTime forestStart = valdforestallning.starttid;

                if (starttid.TimeOfDay >= forestStart.TimeOfDay && sluttid.TimeOfDay <= valdforestallning.sluttid.TimeOfDay)
                {
                    if (starttid.TimeOfDay < sluttid.TimeOfDay)
                    {
                        if (vuxen <= valdforestallning.vuxenpris && ungdom <= valdforestallning.ungdomspris && barn <= valdforestallning.barnpris)
                        {
                            if (vuxen >= ungdom && vuxen >= barn && ungdom >= barn)
                            {
                            Databasmetoder.UppdateraAkt(id, namn, aktinfo, starttid, sluttid, vuxen, ungdom, barn);
                            listBoxAkter.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);

                            conn.Close();
                            MessageBox.Show("Akten är nu uppdaterad!");
                            }
                            else
                            {
                                MessageBox.Show("Vuxen är dyrast, sedan kommer ungdom följt av barn.");
                            }
                               
                        }
                        else
                        {
                            MessageBox.Show("Akten har fel pris!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Akten är för kort!");
                    }
                }
                else
                {
                    MessageBox.Show("Akten måste ha en tid som passar föreställningen!");

        }

            }
            catch (Exception)
            {
                MessageBox.Show("Alla textboxar måste vara korrekt ifyllda!");

            }
        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vill du radera denna akt?", "Akter", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                TaBortAkt();
                MessageBox.Show("Akten har raderats");
            }
        
            else if (dialogResult == DialogResult.No)
            {
                Refresh();
                MessageBox.Show("Vill du endast göra ändringar, vänligen tryck på knappen Uppdatera akt");
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
            //buttonLaggTillForest.Enabled = true;
            //buttonLaggTillForest.Visible = true;
            //btnSkapaForestallning.Enabled = false;
            //btnSkapaForestallning.Visible = false;
            //btn_Avbryt.Enabled = true;
            //btn_Avbryt.Visible = true;
            listBoxAdminForestallning.SelectionMode = SelectionMode.None;
            tomTextBoxarForestallning();
            tomTextBoxarAkt();
            exempelkodforest();

        }

        private void uppdatera_Click(object sender, EventArgs e)
        {
            try
            {
            int id = valdforestallning.id;
            string namn = textBoxForestNamn.Text;
            string generellinfo = richTextBoxForestInf.Text;
            bool open = checkBoxForestallning1.Checked;
            DateTime datum = Convert.ToDateTime(textBoxForestDatum1.Text);
            DateTime starttid = Convert.ToDateTime(textBoxForestStarttid.Text);
            DateTime sluttid = Convert.ToDateTime(textBoxForestSluttid.Text);
            int vuxenpris = Convert.ToInt32(textBoxVuxenpris.Text);
            int ungdomspris = Convert.ToInt32(textBoxUngdomspris.Text);
            int barnpris = Convert.ToInt32(textBoxBarnpris.Text);
            bool friplacering = false;
            DateTime forsaljningsslut = Convert.ToDateTime(textBoxForsaljningsslut.Text);


                if (checkBoxForestallning1.Checked == true)
                {
                    valdforestallning.open = true;
                }

                else
                {
                    checkBoxForestallning1.Checked = false;
                }

                if (datum.Date >= DateTime.Now.Date)
                {
                    if (starttid.TimeOfDay < sluttid.TimeOfDay)
                    {
                        if (vuxenpris >= ungdomspris && vuxenpris >= barnpris && ungdomspris >= barnpris)
                        {
                            Databasmetoder.UppdateraForestallning(id, namn, generellinfo, open, datum, starttid, sluttid, vuxenpris, ungdomspris, barnpris, friplacering, forsaljningsslut);
            listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();
                            MessageBox.Show("Föreställningen har nu uppdaterats");
                        }
                        else
                        {
                            MessageBox.Show("Vuxen är dyrast, sedan kommer ungdom följt av barn.");
        }

                    }
                    else
                    {
                        MessageBox.Show("Föreställningen är för kort!");
                    }

                }
                else
                {
                    MessageBox.Show("Sätt ett senare datum!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Alla textboxar måste vara korrekt ifyllda, vänligen se exempelkod vid textboxarna!");
            }

            conn.Close();
        }







        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerTid_ValueChanged(object sender, EventArgs e)
        {


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

        private void btnOK_Click(object sender, EventArgs e)
        { }

        private void label14_Click(object sender, EventArgs e)
        { }

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

                    NpgsqlCommand command2 = new NpgsqlCommand(sql2, conn);
                    command2.Transaction = trans;
                    int numberOfAffectedRows2 = command2.ExecuteNonQuery();

                    NpgsqlCommand command3 = new NpgsqlCommand(sql3, conn);
                    command3.Transaction = trans;
                    int numberOfAffectedRows3 = command3.ExecuteNonQuery();

                    NpgsqlCommand command4 = new NpgsqlCommand(sql4, conn);
                    command4.Transaction = trans;
                    int numberOfAffectedRows4 = command4.ExecuteNonQuery();

                    trans.Commit();
                    listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();
                    MessageBox.Show("Föreställningen har nu raderats");
                }


                catch (NpgsqlException exception)
                {
                    trans.Rollback();
                    MessageBox.Show("Tyvärr uppstod ett fel! Vänligen kontrollera så att du har markerat föreställningen.");
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
            this.Hide();
            FormBehorigheter fbh = new FormBehorigheter();
            fbh.ShowDialog();
            this.Close();
            //if (aktorlistaId != 6)
            //{
            //    btnAndraTaBortBeh.Enabled;
            //}

        }

        private void textBoxForsaljningsslut_TextChanged(object sender, EventArgs e)
        {}
        private void buttonLaggTillAktInfo_Click(object sender, EventArgs e)
        {
          
            try
            {
            string namn = textBoxAktnamn.Text;
                string aktinfo = richTextBoxAktInf.Text;
                DateTime starttid = (Convert.ToDateTime(textBoxAktStarttid.Text));
                DateTime sluttid = Convert.ToDateTime(textBoxAktSluttid.Text);
                int vuxen = Convert.ToInt32(textBoxAktVuxenpris.Text);
                int ungdom = Convert.ToInt32(textBoxAktUngdPris.Text);
                int barn = Convert.ToInt32(TextBoxAktBarnpris.Text);
                int forestallningsid = Convert.ToInt32(valdforestallning.id);

                DateTime forestStart = valdforestallning.starttid;
                
                if (starttid.TimeOfDay >= forestStart.TimeOfDay  &&  sluttid.TimeOfDay <= valdforestallning.sluttid.TimeOfDay)
                {
                    if (starttid.TimeOfDay < sluttid.TimeOfDay)
                    {
                        if (vuxen <= valdforestallning.vuxenpris && ungdom <= valdforestallning.ungdomspris && barn <= valdforestallning.barnpris)
                        {
                            if (vuxen >= ungdom && vuxen >= barn && ungdom >= barn)
                            {
                            Databasmetoder.LaggTillNyAkt(namn, aktinfo, starttid, sluttid, vuxen, ungdom, barn, forestallningsid);
                            listBoxAkter.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);
                            listBoxAkter.SelectionMode = SelectionMode.One;
                            btnAkt.Enabled = true;
                            btnAkt.Visible = true;
                            buttonLaggTillAktInfo.Enabled = false;
                            buttonLaggTillAktInfo.Visible = false;

                                conn.Close();
                                MessageBox.Show("Akten är nu tillagd i aktlistan.");
                            }
                            else
                            {
                                MessageBox.Show("Vuxen är dyrast, sedan kommer ungdom följt av barn.");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Akten bör inte vara dyrare än föreställningen!");
        }

                    }
                    else
        {
                        MessageBox.Show("Akten är för kort!");
        }
    }
                else
                {
                    MessageBox.Show("Akten måste ha en tid som passar föreställningen!");

}

            }
            catch (Exception)
            {
                MessageBox.Show("Vänligen observera att alla textfält måste vara ifyllda korrekt, se exempelkod. Kontrollera även så att du inte glömt att fylla i ett textfält.");

            }
            finally
            {
               
                conn.Close();
            }
        }

        private void btnAkt_Click(object sender, EventArgs e)
        {
            buttonLaggTillAktInfo.Enabled = true;
            buttonLaggTillAktInfo.Visible = true;
            btnAkt.Enabled = false;
            btnAkt.Visible = false;
            btn_Avbryt.Enabled = true;
            btn_Avbryt.Visible = true;
            listBoxAkter.SelectionMode = SelectionMode.None;
            tomTextBoxarAkt();
           exempelkodakt();
        }           
            private void exempelkodforest()
        {
            textBoxForestDatum1.Text = "YYYY-mm-dd";
            textBoxForsaljningsslut.Text = "HH:mm";
            textBoxForestStarttid.Text = "HH:mm";
            textBoxForsaljningsslut.Text = "YYYY-mm-dd HH:mm";

        }

        private void exempelkodakt()
            {
            textBoxAktStarttid.Text = "HH:mm";
            textBoxAktSluttid.Text = "HH:mm";

        }
                   



        private void label13_Click(object sender, EventArgs e)
        {

        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Refresh();
        //    // Databasmetoder.HamtaForestallningLista();
        //}

        private void textBoxForestStarttid_TextChanged(object sender, EventArgs e)
            {

            }

        private void checkBoxForestallning_CheckedChanged(object sender, EventArgs e)
            {
                           
            }
           
        private void richTextBoxAktInf_TextChanged(object sender, EventArgs e)
        {

        }
                            
        private void textBoxForestSluttid_TextChanged(object sender, EventArgs e)
        {
                           
        }
                    
        private void textBoxVuxenpris_TextChanged(object sender, EventArgs e)
        {
                          
        }

        private void checkBoxForestallning1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_Avbryt_Click(object sender, EventArgs e)
        {
           
        }
    }

}
                    

                       










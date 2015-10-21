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
        string st;

        public AdminForm()
        {
            InitializeComponent();
        }

        public AdminForm(List<int> aktorlista, string st2)
        {
            aktorlistaId = aktorlista;
            st = st2;

            InitializeComponent();
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
            
            
            if (st=="skapaForestallning")
            {
                //this.buttonLaggTillForest.Enabled = false;
                //this.buttonLaggTillForest.Visible = false;
                this.btnSkapaForestallning.Enabled = true;
                this.btnSkapaForestallning.Visible = true;
                //this.uppdatera.Enabled = true;
                //this.uppdatera.Visible = true;
                //this.buttonTaBort.Enabled = true;
                //this.buttonTaBort.Visible = true;
                textBoxForestNamn.Enabled = true;
                textBoxForestNamn.Visible = true;
                richTextBoxForestInf.Enabled = true;
                richTextBoxForestInf.Visible = true;
                textBoxForestDatum1.Enabled = true;
                textBoxForestDatum1.Visible = true;
                textBoxForestStarttid.Enabled = true;
                textBoxForestStarttid.Visible = true;
                textBoxForestSluttid.Enabled = true;
                textBoxForestSluttid.Visible = true;
                textBoxForsaljningsslut.Enabled = true;
                textBoxVuxenpris.Enabled = true;
                textBoxVuxenpris.Visible = true;
                textBoxUngdomspris.Enabled = true;
                textBoxUngdomspris.Visible = true;
                textBoxBarnpris.Enabled = true;
                textBoxBarnpris.Visible = true;
                listBoxAkter.Visible = false;
                listBoxAkter.Enabled = false;
                label2.Visible = true;
                label28.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label3.Visible = true;
                labelForestNamn.Visible = true;
                buttonLaggTillForest.Enabled = true;
                buttonLaggTillForest.Visible = true;
                
                //Akt edit
                //this.btnAkt.Enabled = true;
                //this.btnAkt.Visible = true;
                //this.buttonLaggTillAktInfo.Enabled = true;
                //this.buttonLaggTillAktInfo.Visible = true;
                //this.buttonUppdateraAkt.Enabled = true;
                //this.buttonUppdateraAkt.Visible = true;
                //this.button1.Enabled = true;
                //this.button1.Visible = true;
                //textBoxAktnamn.Enabled = true;
                //richTextBoxAktInf.Enabled = true;
                //textBoxAktStarttid.Enabled = true;
                //textBoxAktSluttid.Enabled = true;
            }

            if (st=="uppdateraForestallning")
            {
                uppdatera.Enabled = true;
                uppdatera.Visible = true;
                textBoxForestNamn.Enabled = true;
                richTextBoxForestInf.Enabled = true;
                textBoxForestDatum1.Enabled = true;
                textBoxForestStarttid.Enabled = true;
                textBoxForestSluttid.Enabled = true;
               // textBoxForsaljningsslut.Enabled = true;
                textBoxForestNamn.Visible = true;
                richTextBoxForestInf.Enabled = true;
                richTextBoxForestInf.Visible = true;
                textBoxForestDatum1.Enabled = true;
                textBoxForestDatum1.Visible = true;
                textBoxForestStarttid.Enabled = true;
                textBoxForestStarttid.Visible = true;
                textBoxForestSluttid.Enabled = true;
                textBoxForestSluttid.Visible = true;
               // textBoxForsaljningsslut.Enabled = true;
                textBoxVuxenpris.Enabled = true;
                textBoxVuxenpris.Visible = true;
                textBoxUngdomspris.Enabled = true;
                textBoxUngdomspris.Visible = true;
                textBoxBarnpris.Enabled = true;
                textBoxBarnpris.Visible = true;
                listBoxAkter.Visible = false;
                listBoxAkter.Enabled = false;
                label2.Visible = true;
                label28.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label3.Visible = true;
                labelForestNamn.Visible = true;




                //this.buttonLaggTillForest.Enabled = false;
                //this.buttonLaggTillForest.Visible = false;
                this.btnSkapaForestallning.Enabled = true;
                this.btnSkapaForestallning.Visible = true;
                //this.uppdatera.Enabled = true;
                //this.uppdatera.Visible = true;
                //this.buttonTaBort.Enabled = true;
                //this.buttonTaBort.Visible = true;
                textBoxForestNamn.Enabled = true;
                richTextBoxForestInf.Enabled = true;
                textBoxForestDatum1.Enabled = true;
                textBoxForestStarttid.Enabled = true;
                textBoxForestSluttid.Enabled = true;
               // textBoxForsaljningsslut.Enabled = true;
                //Akt edit
                //this.btnAkt.Enabled = true;
                //this.btnAkt.Visible = true;
                //this.buttonLaggTillAktInfo.Enabled = true;
                //this.buttonLaggTillAktInfo.Visible = true;
                //this.buttonUppdateraAkt.Enabled = true;
                //this.buttonUppdateraAkt.Visible = true;
                //this.button1.Enabled = true;
                //this.button1.Visible = true;
                //textBoxAktnamn.Enabled = true;
                //richTextBoxAktInf.Enabled = true;
                //textBoxAktStarttid.Enabled = true;
                //textBoxAktSluttid.Enabled = true;
            }

            if (st == "skapaAkt")
            {
                buttonLaggTillAktInfo.Enabled = true;
                buttonLaggTillAktInfo.Visible = true;
                listBoxAdminForestallning.Visible = true;
                listBoxAdminForestallning.Enabled = true;
                listBoxAkter.Visible = true;
                listBoxAkter.Enabled = true;
                textBoxAktnamn.Visible = true;
                textBoxAktnamn.Enabled = true;
                richTextBoxAktInf.Visible = true;
                richTextBoxAktInf.Enabled = true;
                TextBoxAktBarnpris.Visible = true;
                textBoxAktStarttid.Enabled = true;
                textBoxAktStarttid.Visible = true;
                textBoxAktSluttid.Enabled = true;
                textBoxAktSluttid.Visible = true;
                TextBoxAktBarnpris.Enabled = true;
                textBoxAktUngdPris.Enabled = true;
                textBoxAktUngdPris.Visible = true;
                textBoxAktVuxenpris.Visible = true;
                textBoxAktVuxenpris.Enabled = true;
                Lable3.Visible = true;
                label1.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
            }

            if (st == "uppdateraAkt")
            {
                buttonUppdateraAkt.Enabled = true;
                buttonUppdateraAkt.Visible = true;
                listBoxAdminForestallning.Visible = true;
                listBoxAdminForestallning.Enabled = true;
                listBoxAkter.Visible = true;
                listBoxAkter.Enabled = true;
                textBoxAktnamn.Visible = true;
                textBoxAktnamn.Enabled = true;
                richTextBoxAktInf.Visible = true;
                richTextBoxAktInf.Enabled = true;
                TextBoxAktBarnpris.Visible = true;
                textBoxAktStarttid.Enabled = true;
                textBoxAktStarttid.Visible = true;
                textBoxAktSluttid.Enabled = true;
                textBoxAktSluttid.Visible = true;
                TextBoxAktBarnpris.Enabled = true;
                textBoxAktUngdPris.Enabled = true;
                textBoxAktUngdPris.Visible = true;
                textBoxAktVuxenpris.Visible = true;
                textBoxAktVuxenpris.Enabled = true;
                Lable3.Visible = true;
                label1.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label11.Visible = true;
                label12.Visible = true;

            }

            /*if (aktorlistaId.Contains(4) == true)
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
                 this.buttonLaggTillForest.Enabled = true;
                 this.buttonLaggTillForest.Visible = true;
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
                 this.buttonLaggTillAktInfo.Enabled = true;
                 this.buttonLaggTillAktInfo.Visible = true;
                 this.buttonUppdateraAkt.Enabled = true;
                 this.buttonUppdateraAkt.Visible = true;
                 this.button1.Enabled = true;
                 this.button1.Visible = true;
                 textBoxAktnamn.Enabled = true;
                 richTextBoxAktInf.Enabled = true;
                 textBoxAktStarttid.Enabled = true;
                 textBoxAktSluttid.Enabled = true;

             }*/

              listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();

          }


          private void listBoxAdminForestallning_SelectedIndexChanged(object sender, EventArgs e)
          {
              textBoxForsaljningsslut.Clear();
              valdforestallning = (Forestallning)listBoxAdminForestallning.SelectedItem;
            if (valdforestallning != null && st != "skapaForestallning")
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
                       }

              



        

        private void varningar()
        {

        }


        /*  DialogResult dialogResult = MessageBox.Show("Vill du radera hela föreställningen samt alla tillhörande akter? Observera att det kan finnas biljetter bokade på denna föreställning!", "Bokning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (valdakt != null)
                {
                    TaBortAkt();
                }  
                
               else if (dialogResult == DialogResult.No)
            {
                Refresh();

            }
            */

        private void buttonLaggTillForest_Click(object sender, EventArgs e)
        {
            string namn;
            string generellinfo = richTextBoxForestInf.Text;
            bool open = false;
            DateTime datum;
            DateTime starttid;
            DateTime sluttid;
            int vuxenpris;
            int ungdomspris;
            int barnpris;
            DateTime forsaljningsslut;
           


            //namn
            if (textBoxForestNamn.Text != "")
            {
                namn = textBoxForestNamn.Text;
            }
            else
            {
                MessageBox.Show("Vänligen ge föreställningen ett namn under föreställningsnamn.");
                textBoxForestNamn.Focus();
                return;
            }


            //generell info får vara "";
           
            //datum

            try
            {

                datum = Convert.ToDateTime(textBoxForestDatum1.Text);
                forsaljningsslut = datum;

                if (datum.Date < DateTime.Now.Date)
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du vill skapa en föreställning på ett datum som redan varit?", "Datum", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                       textBoxForestDatum1.Focus();
                        
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vänligen fyll i datumfältet enligt följande: 2015-10-27");
                textBoxForestDatum1.Focus();
                return;
            }


            //starttid


            try
            {

                starttid = Convert.ToDateTime(textBoxForestStarttid.Text);

                if (textBoxForestStarttid.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha en starttid på din föreställning?", "Starttid", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxForestStarttid.Focus();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vänligen fyll i starttidsfältet enligt följande: 19:00, glöm ej : mellan timmar och minuter.");
                textBoxForestStarttid.Focus();
                return;
            }

            //sluttid

            try
            {
                sluttid = Convert.ToDateTime(textBoxForestSluttid.Text);
                if (textBoxForestSluttid.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha en sluttid på din föreställning?", "Sluttid", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxForestSluttid.Focus();
                    }
                }
                if (starttid.TimeOfDay > sluttid.TimeOfDay)
                {
                    DialogResult dialogResult = MessageBox.Show("Vill du verkligen att föreställningen skall ta slut innan den börjar?", "Sluttid", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxForestSluttid.Focus();
                    }
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Vänligen fyll i Sluttidsfältet enligt följande: 19:00, glöm ej : mellan timmar och minuter.");
                textBoxForestSluttid.Focus();
                return;
            }

            //vuxenpris
            try
            {
                vuxenpris = Convert.ToInt32(textBoxVuxenpris.Text);
                if (textBoxVuxenpris.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha ett vuxenpris på din föreställning?", "Vuxenpris", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxVuxenpris.Focus();
                    }
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Vänligen fyll i vuxenpriset med siffror.");
                textBoxVuxenpris.Focus();
                return;
            }

            //undgdomspris
            try
            {
                ungdomspris = Convert.ToInt32(textBoxUngdomspris.Text);
                if (textBoxUngdomspris.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha ett ungdomspris på din föreställning?", "Ungdomspris", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxUngdomspris.Focus();
                    }
                }
                if (vuxenpris < ungdomspris)
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du skall ha ett högre ungdomspris än vuxenpris?", "Ungdomspris", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxUngdomspris.Focus();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vänligen fyll i ungdomspriset med siffror.");
                textBoxUngdomspris.Focus();
                return;
            }

            //barnpris

            //undgdomspris
            try
            {
                barnpris = Convert.ToInt32(textBoxBarnpris.Text);
                if (textBoxBarnpris.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha ett barnpris på din föreställning?", "Barnpris", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxBarnpris.Focus();
                    }
                }
                if (vuxenpris <= barnpris && ungdomspris <= barnpris)
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du skall ha ett så högt barnpris?", "Barnpris", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxBarnpris.Focus();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vänligen fyll i barnpriset med siffror.");
                textBoxBarnpris.Focus();
                return;
            }


            Databasmetoder.LaggTillNyForestallning(namn, generellinfo,open, datum, starttid, sluttid, vuxenpris, ungdomspris, barnpris, forsaljningsslut);
            listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();
            tomTextBoxarForestallning();

            MessageBox.Show("Föreställningen är nu tillagd i föreställningslistan.");

        }

            // gammmal ifasts kod

            //try
            //{

            //namn = textBoxForestNamn.Text;


            //string generellinfo = richTextBoxForestInf.Text;
            // datum = Convert.ToDateTime(textBoxForestDatum1.Text);


            //DateTime starttid = Convert.ToDateTime(textBoxForestStarttid.Text);
            // DateTime sluttid = Convert.ToDateTime(textBoxForestSluttid.Text);
            //bool open = checkBoxForestallning1.Checked;
            //vuxenpris = Convert.ToInt32(textBoxVuxenpris.Text);
            //ungdomspris = Convert.ToInt32(textBoxUngdomspris.Text);
            //barnpris = Convert.ToInt32(textBoxBarnpris.Text);
            //  bool friplacering = false;
            // DateTime forsaljningsslut = Convert.ToDateTime(textBoxForsaljningsslut.Text);

            //if (checkBoxfriPlacering.Checked == true)
            //{
            //    friplacering = true;
            //}


            //if (checkBoxForestallning1.Checked == true)
            //{
            //    valdforestallning.open = true;

            //}

            //else
            //{
            //    checkBoxForestallning1.Checked = false;
            //}



            //if (starttid.TimeOfDay < sluttid.TimeOfDay)
            //        {
            //if (vuxenpris >= ungdomspris && vuxenpris >= barnpris && ungdomspris >= barnpris)
            //{
            //if (forsaljningsslut.Date <= datum.Date)
            //{

            //Databasmetoder.LaggTillNyForestallning(namn, generellinfo, datum, starttid, sluttid, vuxenpris, ungdomspris, barnpris);



            //listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();
            //                   // buttonLaggTillForest.Enabled = false;
            //                   // listBoxAdminForestallning.SelectionMode = SelectionMode.One;
                            
            //                conn.Close();
            //                    MessageBox.Show("Föreställningen är nu tillagd i föreställningslistan.");
            //                //}
                            //else
                            //{
                            //    MessageBox.Show("Du bör inte sälja biljetter efter att föreställningen spelats klart.");
                            //}
                        //}
                        //else
                        //{ 
                        //    MessageBox.Show("Vuxen är dyrast, sedan kommer ungdom följt av barn.");
                        //}
                        
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Föreställningen är för kort!");
                    //}
               
                //}
                //else
                //{
                //    MessageBox.Show("Sätt ett senare datum!");
                //}
               
            //}

            //catch (Exception)
            //{

            //    MessageBox.Show("Vänligen observera att alla textfält måste vara ifyllda korrekt, se exempelkod. Kontrollera även så att du inte glömt att fylla i ett textfält.");
            //}

        //    finally
        //    {
        //    conn.Close();

        //}
        //}

        private void listBoxAkter_SelectedIndexChanged(object sender, EventArgs e)
        {
            valdforestallning = (Forestallning)listBoxAdminForestallning.SelectedItem;
            if (valdforestallning != null && st != "skapaAkt")
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

            string namn;// = textBoxAktnamn.Text;
            string aktinfo = richTextBoxAktInf.Text;
            DateTime starttid;// = (Convert.ToDateTime(textBoxAktStarttid.Text));
            DateTime sluttid; // = Convert.ToDateTime(textBoxAktSluttid.Text);
            int vuxen = 0; // = Convert.ToInt32(textBoxAktVuxenpris.Text);
            int ungdom = 0;// = Convert.ToInt32(textBoxAktUngdPris.Text);
            int barn = 0;// = Convert.ToInt32(TextBoxAktBarnpris.Text);
            int forestallningsid = Convert.ToInt32(valdforestallning.id);
            valdakt = (Akt)listBoxAkter.SelectedItem;
            


            DateTime forestStart = valdforestallning.starttid;


            //namn
            if (textBoxAktnamn.Text != "")
            {
                namn = textBoxAktnamn.Text;
            }
            else
            {
                MessageBox.Show("Vänligen ge akten ett namn under aktnamn.");
                textBoxAktnamn.Focus();
                return;
            }





            //starttid
            if (textBoxAktStarttid.Text != "" && textBoxAktStarttid.Text != null)
            {
                try
                {
                    //DateTime forestStart = valdforestallning.starttid;
                    starttid = Convert.ToDateTime(textBoxAktStarttid.Text);


                    if (starttid.TimeOfDay < forestStart.TimeOfDay || starttid.TimeOfDay > valdforestallning.sluttid.TimeOfDay)
                    {
                        DialogResult dialogResult = MessageBox.Show("Observera att starttid på akten inte överensstämmer med föreställningens tider? Vill du ha det så?", "Starttid", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            textBoxAktStarttid.Focus();
                            return;

                        }
                        else //- blir knas att sätta fyll i starttid rätt eftersom det kan den ju vara även om tiden är knas. 
                        {
                            starttid = Convert.ToDateTime(textBoxAktStarttid.Text);
                            textBoxAktSluttid.Focus();

                        }



                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Vänligen fyll i starttidsfältet enligt följande: 19:00, glöm ej : mellan timmar och minuter.");
                    textBoxAktStarttid.Focus();
                    return;
                }
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Du har ingen starttid i din akt, vill du ha det så?", "Starttid", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    textBoxAktStarttid.Focus();
                    return;
                }

                else
                {
                    textBoxAktSluttid.Focus();
                    starttid = Convert.ToDateTime("00:00:59");

                }
            }


            //sluttid

            if (textBoxAktSluttid.Text != "" && textBoxAktSluttid.Text != null)
            {
                try
                {
                    //DateTime forestStart = valdforestallning.starttid;
                    sluttid = Convert.ToDateTime(textBoxAktSluttid.Text);


                    if (sluttid.TimeOfDay < forestStart.TimeOfDay || sluttid.TimeOfDay > valdforestallning.sluttid.TimeOfDay)
                    {
                        DialogResult dialogResult = MessageBox.Show("Observera att sluttid på akten inte överensstämmer med föreställningens tider? Vill du ha det så?", "Starttid", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            textBoxAktSluttid.Focus();
                            return;

                        }
                        else //- blir knas att sätta fyll i starttid rätt eftersom det kan den ju vara även om tiden är knas. 
                        {
                            sluttid = Convert.ToDateTime(textBoxAktSluttid.Text);
                            textBoxAktVuxenpris.Focus();

                        }



                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Vänligen fyll i sluttidsfältet enligt följande: 19:00, glöm ej : mellan timmar och minuter.");
                    textBoxAktSluttid.Focus();
                    return;
                }
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Du har ingen sluttid i din akt, vill du ha det så?", "Sluttid", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    textBoxAktSluttid.Focus();
                    return;
                }

                else
                {
                    textBoxAktVuxenpris.Focus();
                    sluttid = Convert.ToDateTime("00:00:59");

                }
            }







            //vuxenpris 
            if (textBoxAktVuxenpris.Text != "")
            {

                try
                {
                    vuxen = Convert.ToInt32(textBoxAktVuxenpris.Text);

                }
                catch (Exception)
                {

                    MessageBox.Show("Vänligen fyll i vuxenpriset med siffror.");
                    textBoxAktVuxenpris.Focus();
                    return;
                }
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha ett vuxenpris på din föreställning?", "Vuxenpris", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    textBoxAktUngdPris.Focus();
                }
            }

            //undgdomspris
            if (textBoxAktUngdPris.Text != "")
            {

                try
                {
                    ungdom = Convert.ToInt32(textBoxAktUngdPris.Text);

                }
                catch (Exception)
                {
                    MessageBox.Show("Vänligen fyll i ungdomspriset med siffror.");
                    textBoxAktUngdPris.Focus();
                    return;
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha ett ungdomspris på din föreställning?", "Ungdomspris", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    TextBoxAktBarnpris.Focus();
                }
            }

            //barnpris

            if (TextBoxAktBarnpris.Text != "")
            {

                try
                {
                    barn = Convert.ToInt32(TextBoxAktBarnpris.Text);

                }
                catch (Exception)
                {
                    MessageBox.Show("Vänligen fyll i barnpriset med siffror.");
                    TextBoxAktBarnpris.Focus();
                    return;
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha ett barnpris på din föreställning?", "Barnpris", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    buttonLaggTillAktInfo.Focus();
                }
            }


            Databasmetoder.UppdateraAkt(valdakt.id, namn, aktinfo, starttid, sluttid, vuxen, ungdom, barn);
            listBoxAkter.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);
            

            MessageBox.Show("Akten är nu uppdaterad.");
        }
    

//            if (listBoxAkter.SelectedIndex != -1)
//            {
//                try
//            {
//            int fsid = valdforestallning.id;
//            int id = valdakt.id;
//            string namn = textBoxAktnamn.Text;
//            string aktinfo = richTextBoxAktInf.Text;
//            DateTime starttid = Convert.ToDateTime(textBoxAktStarttid.Text);
//            DateTime sluttid = Convert.ToDateTime(textBoxAktSluttid.Text);
//            int vuxen = Convert.ToInt32(textBoxAktVuxenpris.Text);
//            int ungdom = Convert.ToInt32(textBoxAktUngdPris.Text);
//            int barn = Convert.ToInt32(TextBoxAktBarnpris.Text);

//                DateTime forestStart = valdforestallning.starttid;

                

//                    if (starttid.TimeOfDay >= forestStart.TimeOfDay && sluttid.TimeOfDay <= valdforestallning.sluttid.TimeOfDay)
//                    {
//                        if (starttid.TimeOfDay < sluttid.TimeOfDay)
//                        {
//                            if (vuxen <= valdforestallning.vuxenpris && ungdom <= valdforestallning.ungdomspris && barn <= valdforestallning.barnpris)
//                            {
//                                if (vuxen >= ungdom && vuxen >= barn && ungdom >= barn)
//                                {
//                                    Databasmetoder.UppdateraAkt(id, namn, aktinfo, starttid, sluttid, vuxen, ungdom, barn);
//                                    listBoxAkter.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);
//                                    conn.Close();
//                                    MessageBox.Show("Akten är nu uppdaterad!");
//                                }
//                                else
//                                {
//                                    MessageBox.Show("Vuxen är dyrast, sedan kommer ungdom följt av barn.");
//                                }

//                            }
//                            else
//                            {
//                                MessageBox.Show("Akten har fel pris!");
//                            }

//                        }
//                        else
//                        {
//                            MessageBox.Show("Akten är för kort!");
//                        }
//                    }
//                    else
//                    {
//                        MessageBox.Show("Akten måste ha en tid som passar föreställningen!");
//                    }
               


//            }
//            catch (Exception)
//            {
//                MessageBox.Show("Alla textboxar måste vara korrekt ifyllda!");

//            }
//            }
//            else
//            {
//                MessageBox.Show("För att kunna uppdatera måste du ha valt en akt.");
//            }
//        }


//        private void button1_Click_2(object sender, EventArgs e)
//        {
//            DialogResult dialogResult = MessageBox.Show("Vill du radera denna akt?", "Akter", MessageBoxButtons.YesNo);
//            if (dialogResult == DialogResult.Yes)
//            {
//                TaBortAkt();
//                MessageBox.Show("Akten har raderats");
//            }
        
//            else if (dialogResult == DialogResult.No)
//            {
//                Refresh();
//                MessageBox.Show("Vill du endast göra ändringar, vänligen tryck på knappen Uppdatera akt");
//    }
//}

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
           
            tomTextBoxarForestallning();
            tomTextBoxarAkt();
            //exempelkodforest();

        }

        private void uppdatera_Click(object sender, EventArgs e)
        {
            int id = valdforestallning.id;
            string namn;
            string generellinfo = richTextBoxForestInf.Text;
           
            DateTime datum;
            DateTime starttid;
            DateTime sluttid;
            int vuxenpris;
            int ungdomspris;
            int barnpris;
           



            //namn
            if (textBoxForestNamn.Text != "")
            {
                namn = textBoxForestNamn.Text;
            }
            else
            {
                MessageBox.Show("Vänligen ge föreställningen ett namn under föreställningsnamn.");
                textBoxForestNamn.Focus();
                return;
            }


            //generell info får vara "";

            //datum

            try
            {

                datum = Convert.ToDateTime(textBoxForestDatum1.Text);
         

                if (datum.Date < DateTime.Now.Date)
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du vill skapa en föreställning på ett datum som redan varit?", "Datum", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxForestDatum1.Focus();

                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vänligen fyll i datumfältet enligt följande: 2015-10-27");
                textBoxForestDatum1.Focus();
                return;
            }


            //starttid


            try
            {

                starttid = Convert.ToDateTime(textBoxForestStarttid.Text);

                if (textBoxForestStarttid.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha en starttid på din föreställning?", "Starttid", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxForestStarttid.Focus();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vänligen fyll i starttidsfältet enligt följande: 19:00, glöm ej : mellan timmar och minuter.");
                textBoxForestStarttid.Focus();
                return;
            }

            //sluttid

            try
            {
                sluttid = Convert.ToDateTime(textBoxForestSluttid.Text);
                if (textBoxForestSluttid.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha en sluttid på din föreställning?", "Sluttid", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxForestSluttid.Focus();
                    }
                }
                if (starttid.TimeOfDay > sluttid.TimeOfDay)
                {
                    DialogResult dialogResult = MessageBox.Show("Vill du verkligen att föreställningen skall ta slut innan den börjar?", "Sluttid", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxForestSluttid.Focus();
                    }
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Vänligen fyll i Sluttidsfältet enligt följande: 19:00, glöm ej : mellan timmar och minuter.");
                textBoxForestSluttid.Focus();
                return;
            }

            //vuxenpris
            try
            {
                vuxenpris = Convert.ToInt32(textBoxVuxenpris.Text);
                if (textBoxVuxenpris.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha ett vuxenpris på din föreställning?", "Vuxenpris", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxVuxenpris.Focus();
                    }
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Vänligen fyll i vuxenpriset med siffror.");
                textBoxForestSluttid.Focus();
                return;
            }

            //undgdomspris
            try
            {
                ungdomspris = Convert.ToInt32(textBoxUngdomspris.Text);
                if (textBoxUngdomspris.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha ett ungdomspris på din föreställning?", "Ungdomspris", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxUngdomspris.Focus();
                    }
                }
                if (vuxenpris < ungdomspris)
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du skall ha ett högre ungdomspris än vuxenpris?", "Ungdomspris", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxUngdomspris.Focus();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vänligen fyll i ungdomspriset med siffror.");
                textBoxUngdomspris.Focus();
                return;
            }

            //barnpris

            //undgdomspris
            try
            {
                barnpris = Convert.ToInt32(textBoxBarnpris.Text);
                if (textBoxBarnpris.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha ett barnpris på din föreställning?", "Barnpris", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxBarnpris.Focus();
                    }
                }
                if (vuxenpris <= barnpris && ungdomspris <= barnpris)
                {
                    DialogResult dialogResult = MessageBox.Show("Är du säker på att du skall ha ett så högt barnpris?", "Barnpris", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        textBoxBarnpris.Focus();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vänligen fyll i barnpriset med siffror.");
                textBoxBarnpris.Focus();
                return;
            }

            //input
            Databasmetoder.UppdateraForestallning(id, namn, generellinfo, datum, starttid, sluttid, vuxenpris, ungdomspris, barnpris);
            listBoxAdminForestallning.DataSource = Databasmetoder.HamtaForestallningLista();

          
            MessageBox.Show("Föreställningen är nu uppdaterad.");

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
        //    this.Hide();
        //    FormBehorigheter fbh = new FormBehorigheter(aktorlistaId);
        //    fbh.ShowDialog();
        //    this.Close();
            //if (aktorlistaId != 6)
            //{
            //    btnAndraTaBortBeh.Enabled;
            //}

        }

        private void textBoxForsaljningsslut_TextChanged(object sender, EventArgs e)
        {}
        private void buttonLaggTillAktInfo_Click(object sender, EventArgs e)
        {
            string namn;// = textBoxAktnamn.Text;
            string aktinfo = richTextBoxAktInf.Text;
            DateTime starttid;// = (Convert.ToDateTime(textBoxAktStarttid.Text));
            DateTime sluttid; // = Convert.ToDateTime(textBoxAktSluttid.Text);
            int vuxen = 0; // = Convert.ToInt32(textBoxAktVuxenpris.Text);
            int ungdom = 0;// = Convert.ToInt32(textBoxAktUngdPris.Text);
            int barn = 0;// = Convert.ToInt32(TextBoxAktBarnpris.Text);
            int forestallningsid = Convert.ToInt32(valdforestallning.id);



            DateTime forestStart = valdforestallning.starttid;


            //namn
            if (textBoxAktnamn.Text != "")
            {
                namn = textBoxAktnamn.Text;
            }
            else
            {
                MessageBox.Show("Vänligen ge akten ett namn under aktnamn.");
                textBoxAktnamn.Focus();
                return;
            }





            //starttid
            if (textBoxAktStarttid.Text != "" && textBoxAktStarttid.Text != null)
            {
                try
                {
                    //DateTime forestStart = valdforestallning.starttid;
                    starttid = Convert.ToDateTime(textBoxAktStarttid.Text);


                    if (starttid.TimeOfDay < forestStart.TimeOfDay || starttid.TimeOfDay > valdforestallning.sluttid.TimeOfDay)
                    {
                        DialogResult dialogResult = MessageBox.Show("Observera att starttid på akten inte överensstämmer med föreställningens tider? Vill du ha det så?", "Starttid", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            textBoxAktStarttid.Focus();
                            return;

                        }
                        else //- blir knas att sätta fyll i starttid rätt eftersom det kan den ju vara även om tiden är knas. 
                        {
                            starttid = Convert.ToDateTime(textBoxAktStarttid.Text);
                            textBoxAktSluttid.Focus();

                        }



                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Vänligen fyll i starttidsfältet enligt följande: 19:00, glöm ej : mellan timmar och minuter.");
                    textBoxAktStarttid.Focus();
                    return;
                }
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Du har ingen starttid i din akt, vill du ha det så?", "Starttid", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    textBoxAktStarttid.Focus();
                    return;
                }

                else
                {
                    textBoxAktSluttid.Focus();
                    starttid = Convert.ToDateTime("00:00:59");

                }
            }


            //sluttid

            if (textBoxAktSluttid.Text != "" && textBoxAktSluttid.Text != null)
            {
                try
                {
                    //DateTime forestStart = valdforestallning.starttid;
                    sluttid = Convert.ToDateTime(textBoxAktSluttid.Text);


                    if (sluttid.TimeOfDay < forestStart.TimeOfDay || sluttid.TimeOfDay > valdforestallning.sluttid.TimeOfDay)
                    {
                        DialogResult dialogResult = MessageBox.Show("Observera att sluttid på akten inte överensstämmer med föreställningens tider? Vill du ha det så?", "Starttid", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            textBoxAktSluttid.Focus();
                            return;

                        }
                        else //- blir knas att sätta fyll i starttid rätt eftersom det kan den ju vara även om tiden är knas. 
                        {
                            sluttid = Convert.ToDateTime(textBoxAktSluttid.Text);
                            textBoxAktVuxenpris.Focus();

                        }



                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Vänligen fyll i sluttidsfältet enligt följande: 19:00, glöm ej : mellan timmar och minuter.");
                    textBoxAktSluttid.Focus();
                    return;
                }
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Du har ingen sluttid i din akt, vill du ha det så?", "Sluttid", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    textBoxAktSluttid.Focus();
                    return;
                }

                else
                {
                    textBoxAktVuxenpris.Focus();
                    sluttid = Convert.ToDateTime("00:00:59");

                }
            }







            //vuxenpris 
            if (textBoxAktVuxenpris.Text != "")
            {

                try
                {
                    vuxen = Convert.ToInt32(textBoxAktVuxenpris.Text);

                }
                catch (Exception)
                {

                    MessageBox.Show("Vänligen fyll i vuxenpriset med siffror.");
                    textBoxAktVuxenpris.Focus();
                    return;
                }
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha ett vuxenpris på din föreställning?", "Vuxenpris", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    textBoxAktUngdPris.Focus();
                }
            }

            //undgdomspris
            if (textBoxAktUngdPris.Text != "")
            {

                try
                {
                    ungdom = Convert.ToInt32(textBoxAktUngdPris.Text);

                }
                catch (Exception)
                {
                    MessageBox.Show("Vänligen fyll i ungdomspriset med siffror.");
                    textBoxAktUngdPris.Focus();
                    return;
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha ett ungdomspris på din föreställning?", "Ungdomspris", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    TextBoxAktBarnpris.Focus();
                }
            }

            //barnpris

            if (TextBoxAktBarnpris.Text != "")
            {

                try
                {
                    barn = Convert.ToInt32(TextBoxAktBarnpris.Text);

                }
                catch (Exception)
                {
                    MessageBox.Show("Vänligen fyll i barnpriset med siffror.");
                    TextBoxAktBarnpris.Focus();
                    return;
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Är du säker på att du inte vill ha ett barnpris på din föreställning?", "Barnpris", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    buttonLaggTillAktInfo.Focus();
                }
            }


            Databasmetoder.LaggTillNyAkt(namn, aktinfo, starttid, sluttid, vuxen, ungdom, barn, forestallningsid);

            // Databasmetoder.LaggTillNyForestallning(namn, generellinfo, open, datum, starttid, sluttid, vuxenpris, ungdomspris, barnpris, forsaljningsslut);
            listBoxAkter.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);
            tomTextBoxarAkt();

            MessageBox.Show("Akten är nu tillagd i föreställningslistan.");
        }

        private void btnAkt_Click(object sender, EventArgs e)
        {
            //buttonLaggTillAktInfo.Enabled = true;
            //buttonLaggTillAktInfo.Visible = true;
            //btnAkt.Enabled = false;
            //btnAkt.Visible = false;
            //btn_Avbryt.Enabled = true;
            //btn_Avbryt.Visible = true;
            //listBoxAkter.SelectionMode = SelectionMode.None;
            tomTextBoxarAkt();
           exempelkodakt();
        }           
            private void exempelkodforest()
        {
            textBoxForestDatum1.Text = "YYYY-mm-dd";
            textBoxForsaljningsslut.Text = "HH:mm";
            textBoxForestStarttid.Text = "HH:mm";
            textBoxForsaljningsslut.Text =  "YYYY-mm-dd HH:mm"; //textBoxForestDatum.Text.ToString();//

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

        private void btn_Huvud_Click(object sender, EventArgs e)
        {
            this.Hide();
            Huvudsidan hs = new Huvudsidan(aktorlistaId);
            hs.ShowDialog();
            this.Close();
        }

        private void checkBoxForestallning1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_Avbryt_Click(object sender, EventArgs e)
        {
           
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBoxForestDatum1_TextChanged(object sender, EventArgs e)
        {
            //if (textBoxForestDatum1.)
            //{
            //    MessageBox.Show("jeyyy");
            //}
        }

        private void checkBoxfriPlacering_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdminhuvudsida_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adminhuvudsida ah = new Adminhuvudsida(aktorlistaId);
            ah.ShowDialog();
            this.Close();
        }

        private void buttonLoggaUt_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loginform lf = new Loginform();
            lf.ShowDialog();
            this.Close();
        }
    }

}
                    

                       










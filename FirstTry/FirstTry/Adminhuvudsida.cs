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
    public partial class Adminhuvudsida : Form
    {

        private List<int> aktorlistaId = new List<int>();
        private Forestallning valdforestallning;
        private Akt valdakt;
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");


        public Adminhuvudsida()
        {
            InitializeComponent();
        }

        public Adminhuvudsida(List<int> aktorlista)
        {
            aktorlistaId = aktorlista;

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonOppnaForsaljning_Click(object sender, EventArgs e)
        {

        }

        private void Adminhuvudsida_Load(object sender, EventArgs e)
        {

            listBoxForestallning.DataSource = Databasmetoder.HamtaForestallningLista();

            /* if (aktorlistaId.Contains(4) == true)
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
        }

        private void buttonRapporter_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rapporter rapporter = new Rapporter();
            rapporter.ShowDialog();
            this.Close();
        }

        private void buttonAndraBehorighet_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBehorigheter fbh = new FormBehorigheter(aktorlistaId);
            fbh.ShowDialog();
            this.Close();
        }

        private void buttonTillHuvudsida_Click(object sender, EventArgs e)
        {
            this.Hide();
            Huvudsidan hs = new Huvudsidan(aktorlistaId);
            hs.ShowDialog();
            this.Close();
        }

        private void buttonLoggaUt_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loginform lf = new Loginform();
            lf.ShowDialog();
            this.Close();
        }

        private void buttonUppdateraForest_Click(object sender, EventArgs e)
        {
            this.Hide();
            string st = "uppdateraForestallning";
            AdminForm af = new AdminForm();
            af.ShowDialog();
            this.Close();


            //x = Databasmetoder.UppdateraForestallning(id, namn, generellinfo, open, datum, starttid, sluttid, vuxenpris, ungdomspris, barnpris, friplacering, forsaljningsslut);
        }

        private void buttonNyForestallning_Click(object sender, EventArgs e)
        {
            this.Hide();
            string st = "skapaForestallning";
            AdminForm af = new AdminForm();
            af.ShowDialog();
            this.Close();
        }

        private void buttonTaBortForest_Click(object sender, EventArgs e)
        {

        }

        private void buttonSkapaNyAkt_Click(object sender, EventArgs e)
        {
            this.Hide();
            string st = "skapaAkt";
            AdminForm af = new AdminForm();
            af.ShowDialog();
            this.Close();
        }

        private void buttonUppdateraAkt_Click(object sender, EventArgs e)
        {
            this.Hide();
            string st = "uppdateraAkt";
            AdminForm af = new AdminForm();
            af.ShowDialog();
            this.Close();

        }

        private void listBoxForestallning_SelectedIndexChanged(object sender, EventArgs e)
        {

            valdforestallning = (Forestallning)listBoxForestallning.SelectedItem;
            if (valdforestallning != null)
            {
                listBoxAkt.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);
                richTextBoxForestallning.Text = valdforestallning.generellinfo;
            }

        }

        private void listBoxAkt_SelectedIndexChanged(object sender, EventArgs e)
        {
            valdforestallning = (Forestallning)listBoxForestallning.SelectedItem;
            if (valdforestallning != null)
            {
                valdakt = (Akt)listBoxAkt.SelectedItem;


                if (valdakt != null)
                {

                    richTextBoxAkter.Text = valdakt.Aktinfo.ToString();
                }
            }
        }
    }
}

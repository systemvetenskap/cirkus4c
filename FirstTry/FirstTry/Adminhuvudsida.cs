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
        string st;
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
            if (aktorlistaId.Contains(5) == true || aktorlistaId.Contains(7) == true)
            {
                this.buttonAndraBehorighet.Enabled = true;
                this.buttonAndraBehorighet.Visible = true;
            }
            listBoxForestallning.DataSource = Databasmetoder.HamtaForestallningLista();

          
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
            AdminForm af = new AdminForm(aktorlistaId, st);
            af.ShowDialog();
            this.Close();


            //x = Databasmetoder.UppdateraForestallning(id, namn, generellinfo, open, datum, starttid, sluttid, vuxenpris, ungdomspris, barnpris, friplacering, forsaljningsslut);
        }

        private void buttonNyForestallning_Click(object sender, EventArgs e)
        {
            this.Hide();
            string st = "skapaForestallning";
            AdminForm af = new AdminForm(aktorlistaId, st);
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
            AdminForm af = new AdminForm(aktorlistaId, st);
            af.ShowDialog();
            this.Close();
        }

        private void buttonUppdateraAkt_Click(object sender, EventArgs e)
        {
            this.Hide();
            string st = "uppdateraAkt";
            AdminForm af = new AdminForm(aktorlistaId, st);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adminhuvudsida ah = new Adminhuvudsida(aktorlistaId);
            ah.ShowDialog();
            this.Close();
        }
    }
}

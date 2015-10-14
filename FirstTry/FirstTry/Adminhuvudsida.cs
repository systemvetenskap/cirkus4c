using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstTry
{
    public partial class Adminhuvudsida : Form
    {

        private List<int> aktorlistaId = new List<int>();
        private Forestallning valdforestallning;


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
            //string x;
            //x = Databasmetoder.UppdateraForestallning(id, namn, generellinfo, open, datum, starttid, sluttid, vuxenpris, ungdomspris, barnpris, friplacering, forsaljningsslut);
        }
    }
}

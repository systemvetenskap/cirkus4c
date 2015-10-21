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
    public partial class Rapporter : Form
    {
        private List<int> aktorlistaId = new List<int>();
        private Forestallning valdforestallning;
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");


        public Rapporter()
        {
            InitializeComponent();
        }

        public Rapporter(List<int> aktorlista)
        {
            aktorlistaId = aktorlista;

            InitializeComponent();
        }


        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void Rapport()
        {
            string sql = "SELECT coalesce (sum(case when id IS NOT NULL then 1 else 0 end), 0) as totalt, coalesce (sum(case when biljettyp = 'vuxen' then 1 else 0 end), 0) as vuxen, coalesce (sum(case when biljettyp = 'ungdom' then 1 else 0 end), 0) as ungdom, coalesce (sum(case when biljettyp = 'barn' then 1 else 0 end), 0) as barn, coalesce (sum(pris), 0) as totaltKr FROM biljett WHERE forestallning_id = " + valdforestallning.id;
            conn.Close();
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




        }

        private void listBoxFöreställning_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            valdforestallning = (Forestallning)listBoxForestallning.SelectedItem;
            if (valdforestallning != null)
            {
                Rapport();

            }
            else
            {
                MessageBox.Show("Vänligen välj en föreställning för att kunna få en rapport på denna.");
            }
           
        }

        private void Rapporter_Load(object sender, EventArgs e)
        {
            listBoxForestallning.DataSource = Databasmetoder.HamtaForestallningLista();
        }

        private void buttonTillHuvudsida_Click(object sender, EventArgs e)
        {
            this.Hide();
            Huvudsidan hs = new Huvudsidan(aktorlistaId);
            hs.ShowDialog();
            this.Close();
        }

        private void buttonAdminhuvudsida_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adminhuvudsida ah = new Adminhuvudsida(aktorlistaId);
            ah.ShowDialog();
            this.Close();
        }

        private void buttonAndraBehorighet_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBehorigheter fbh = new FormBehorigheter(aktorlistaId);
            fbh.ShowDialog();
            this.Close();
        }

        private void buttonRapporter_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rapporter rapporter = new Rapporter(aktorlistaId);
            rapporter.ShowDialog();
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
  

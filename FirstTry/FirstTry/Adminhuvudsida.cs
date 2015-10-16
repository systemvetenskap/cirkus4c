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
            this.Hide();
            OppnaForestallning open = new OppnaForestallning();
            open.ShowDialog();
            this.Close();
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
            int padda = valdforestallning.id;
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            NpgsqlTransaction trans = null;

            DialogResult dialogResult = MessageBox.Show("Vill du radera hela föreställningen samt alla tillhörande akter? Observera att det kan finnas biljetter bokade på denna föreställning!", "Bokning", MessageBoxButtons.YesNo);
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
                    listBoxForestallning.DataSource = Databasmetoder.HamtaForestallningLista();
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
                labelForsaljningsslut.Text = ("t.o.m " + valdforestallning.forsaljningsslut.ToShortDateString());
            }
            else
            {
                labelForsaljningsslut.Visible = false;

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
                listBoxAkt.DataSource = Databasmetoder.HamtaAktLista(valdforestallning.id);


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

        private void buttonTaBortAkt_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Observera att det kan finnas biljetter bokade på denna akt! Vill du radera ändå?", "Bokning", MessageBoxButtons.YesNo);
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
            }

        }

        private void LabelOppen_Click(object sender, EventArgs e)
        {

        }

        private void labelForsaljningsslut_Click(object sender, EventArgs e)
        {
           
        }
    }
}

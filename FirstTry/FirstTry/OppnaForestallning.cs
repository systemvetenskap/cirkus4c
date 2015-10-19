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
    public partial class OppnaForestallning : Form
    {
        private List<int> aktorlistaId = new List<int>();
        private Forestallning valdforestallning;
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
        int id;

        public OppnaForestallning()
        {
            InitializeComponent();
        }

        public OppnaForestallning(List<int> aktorlista, int id2)
        {
            aktorlistaId = aktorlista;
            id = id2;

            InitializeComponent();
        }

        private void OppnaForestallning_Load(object sender, EventArgs e)
        {

        }





        private void buttonSistaFörsäljningsdag_Click(object sender, EventArgs e)
        {

            bool open;
            DateTime forsaljningsslut;
           try
           {
                open = true;
                forsaljningsslut = Convert.ToDateTime(textBoxSistaForsaljningsdag.Text);

                if (textBoxSistaForsaljningsdag.Text == "")
                {

                    Databasmetoder.UppdateraOpenochForsaljningsslut(id, open, forsaljningsslut);
                    MessageBox.Show("Föreställningen är nu öppnad och sista försäljningsdag är tillagd!");
                }
                else
                {
                    MessageBox.Show("Datumfältet måste vara ifyllt enligt följande: 2015-10-15. Önskas även klockslag för försäljningsslut: 2015-10-15 16:00. Tänk på att det ska vara kolontecken mellan timmar och minuter");
                    textBoxSistaForsaljningsdag.Focus();
                    return;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("ex");
            }

            conn.Close();
        }      
    }
}

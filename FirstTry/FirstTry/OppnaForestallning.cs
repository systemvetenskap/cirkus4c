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

        public OppnaForestallning()
        {
            InitializeComponent();
        }

        private void OppnaForestallning_Load(object sender, EventArgs e)
        {

        }

        private void buttonSistaFörsäljningsdag_Click(object sender, EventArgs e)
        {
            bool open = true;
            DateTime forsaljningsslut = Convert.ToDateTime(textBoxSistaForsaljningsdag.Text);


            Databasmetoder.LaggTillOpenOchForsaljningsslut(open, forsaljningsslut);

            MessageBox.Show("Föreställningen är nu öppnad och sista försäljningsdag är tillagd!");
        }
        
    }
}

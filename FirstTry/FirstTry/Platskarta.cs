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
    public partial class Platskarta : Form
    {
        public Platskarta()
        {
            InitializeComponent();
        }

        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
        DataTable dt = new DataTable();
        
        


        private void button_A1_Click(object sender, EventArgs e)
        {
            Biljett biljetten = new Biljett();
            
        }

        private void Platskarta_Load(object sender, EventArgs e)
        {
            string query = "select * from tempkop where id = (select MAX(id) from tempkop)";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            da.Fill(dt);
            Tempkop tk = new Tempkop();
            foreach (DataRow item in dt.Rows)
            {
                int vuxna = Convert.ToInt32(item["vuxna"]);
                int ungdomar = Convert.ToInt32(item["ungdomar"]);
                int barn = Convert.ToInt32(item["barn"]);
                tk.vuxna = vuxna;
                tk.ungdom = ungdomar;
                tk.barn = barn;

            }
          
            





        }
    }
}

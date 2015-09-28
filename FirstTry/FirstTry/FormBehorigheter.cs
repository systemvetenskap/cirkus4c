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
    public partial class FormBehorigheter : Form
    {
        private Personal valdpersonal;
        private Behorigheter valdbehorighet;
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

        public FormBehorigheter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

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

        private void btnTaBortBeh_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MessageBoxButtons.YesNo.ToString());

            // NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

            //try
            //{
            //    conn.Open();
            //    // dropdown NpgsqlCommand command = new NpgsqlCommand(@"REVOKE '" + txtObjektBehorighet + "' '" + txtObjektBehorighet + "' ON '" + txtTabell + "' FROM '" + txtAnvandare + "')", conn);

            //}
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    conn.Close();
            //}
        }

        private void listBoxBehorighet_SelectedIndexChanged(object sender, EventArgs e)
        {
            //valdbehorighet = (Behorigheter)listBoxBehorigheter.SelectedItem;
            //if (valdbehorighet != null)
            //{
            //    listBoxBehorigheter.DataSource = Databasmetoder.HamtaAkttypLista(valdbehorighet.id);
            //}
        }
    }
}

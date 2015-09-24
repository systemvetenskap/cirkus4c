using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace FirstTry
{
    class Biljett
    {

        public Forestallning forestallning { get; set; }
        public Akt akter { get; set; }
        public int pris { get; set; }
        public string biljettyp { get; set; }
        public int biljett_id { get; set; }
        public int plats_id { get; set; }
        public bool resserverad { get; set; }
        public bool hela { get; set; }
        //datum
        //tid

        /// <summary>
        /// Make life hell.
        /// </summary>
        public Biljett()
        {
            

        }
        public override string ToString()
        {
            return biljett_id.ToString();
        }
        public string platsnamn(int platsID)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

            DataTable dt = new DataTable();
            string query = "select nummer from platser where id = ";
            query += platsID.ToString();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            da.Fill(dt);
            NpgsqlCommand cmd = new NpgsqlCommand();

            string namn = (string)cmd.ExecuteScalar();
            return namn;
        }    

    }
}

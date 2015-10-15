using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace FirstTry
{
    class Akt
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

        public string namn { get; set; }
        public int id { get; set; }
        public DateTime datumTid { get; set; } 
        public int vuxen { get; set; } 
        public int ungdom { get; set; }
        public int barn { get; set; }
        public string Aktinfo { get; set; }
        public DateTime Starttid { get; set; }
        public DateTime Sluttid { get; set; }
        public int Forestallningsid { get; set; }

        public override string ToString()
        {
            
            int antalChar = 0;

            for (int i = 0; i < namn.Length; i++)
            {
                antalChar++;
            }

            if (antalChar > 9)
            {
                string antalLedig;
                antalLedig = AntalLedigaPlatser();

                return namn + "\t " + Starttid.ToShortTimeString() + "\t " + "\t " + AntalLedigaPlatser() + "\t " + "\t " + "\t " + LaktarPlatser(); 
            } 
            else
            {
                return namn + "\t "+ "\t " + Starttid.ToShortTimeString() + "\t " + AntalLedigaPlatser();
            } 
        }
        private string LaktarPlatser()
        {
            string query = "SELECT COUNT(biljett.id) FROM public.akter, public.biljett WHERE akter.id = biljett.akt_id AND biljett.fri_placering = true AND akter.id =" + this.id + ";";
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            da.Fill(dt);

            int lediga = 0;


            foreach (DataRow row in dt.Rows)
            {
                lediga = Convert.ToInt32(row["count"]);
            }



            lediga = 250 - lediga;


            return lediga.ToString() + " av 250";
        }
        private string AntalLedigaPlatser()
        {
            string query = "SELECT COUNT(platser.id) FROM akter, platser, biljett WHERE akter.id = biljett.akt_id AND platser.id = biljett.plats_id AND akter.id = " + this.id + ";";
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            da.Fill(dt);

            int lediga = 0;


            foreach (DataRow row in dt.Rows)
            {
                lediga = Convert.ToInt32(row["count"]);
            }

            

            lediga = 64 - lediga;
            

            return lediga.ToString() + " av 64";
        }


    }
}

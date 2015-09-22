using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace FirstTry
{

    class Databasmetoder
    {

        public static List<Forestallning> HamtaForestallningLista()
        {
            List<Forestallning> forestallningslista = new List<Forestallning>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("Select * from forestallning", conn);
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Forestallning forestallning = new Forestallning
                {
                    id = Convert.ToInt32(dr["id"]),
                    namn = (string)dr["namn"],
                    generellinfo = (string)dr["generell_info"],
                    starttid = Convert.ToDateTime(dr["starttid"]),
                    sluttid = Convert.ToDateTime(dr["sluttid"]),
                    vuxenpris = Convert.ToInt32(dr["vuxenpris"]),
                    ungdomspris = Convert.ToInt32(dr["ungdomspris"]),
                    barnpris = Convert.ToInt32(dr["barnpris"]),
                };

                forestallningslista.Add(forestallning);
            }
            conn.Close();
            return forestallningslista;

        }
        public static List<Akt> HamtaAktLista(int fsid)
        {
            /*  List<Forestallning> forestallningslista = new List<Forestallning>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("Select * from forestallning", conn);
            NpgsqlDataReader dr = command.ExecuteReader();  */

            List<Akt> aktlista = new List<Akt>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(@"Select * from akter , forestallning
                                                  Where akter.forestallningsid = forestallning.id
                                                 and forestallningsid = :fsid ;", conn);  ///**/

             command.Parameters.Add(new NpgsqlParameter("fsid", DbType.Int32));
             command.Parameters[0].Value = Convert.ToInt32(fsid);
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Akt akten = new Akt();

                akten.id = Convert.ToInt32(dr["id"]);
                akten.namn = (string)dr["aktnamn"];
                akten.Aktinfo  = (string)dr["aktinfo"];
                //akten.Starttid = Convert.ToDateTime(dr["starttid"]);   //datumtid
                //akten.Sluttid = Convert.ToDateTime(dr["sluttid"]);
                akten.vuxen = Convert.ToInt32(dr["vuxenpris"]);
                akten.ungdom = Convert.ToInt32(dr["ungdomspris"]);
                akten.barn = Convert.ToInt32(dr["barnpris"]);


                //Akt akten = new Akt();
                //{
                //    id = Convert.ToInt32(dr["id"]),
                //    namn = (string)dr["aktnamn"],
                //    AktInfo = (string)dr["aktinfo"],
                //    //starttid = Convert.ToDateTime(dr["starttid"]),   //datumtid
                //    Sluttid = Convert.ToDateTime(dr["sluttid"]),
                //    vuxen = Convert.ToInt32(dr["vuxenpris"]),
                //    ungdom = Convert.ToInt32(dr["ungdomspris"]),
                //    barn = Convert.ToInt32(dr["barnpris"]),

                //};
                
                aktlista.Add(akten);
            }
            conn.Close();
            return aktlista;


        }
    }
}
            
       
        
       


    

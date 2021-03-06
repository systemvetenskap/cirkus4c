﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace FirstTry
{

    class Databasmetoder
    {

        

        public static List<Forestallning> HamtaForestallningLista()
        {
            List<Forestallning> forestallningslista = new List<Forestallning>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("Select * from forestallning ORDER BY namn, datum, starttid ASC", conn);
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {

                Forestallning forestallning = new Forestallning();

                forestallning.id = Convert.ToInt32(dr["id"]);
                forestallning.namn = (string)dr["namn"];
                forestallning.generellinfo = (string)dr["generell_info"];
                forestallning.open = (bool)dr["open"];
                forestallning.datum = Convert.ToDateTime(dr["datum"]);
                forestallning.starttid = Convert.ToDateTime(dr["starttid"]);
                forestallning.sluttid = Convert.ToDateTime(dr["sluttid"]);
                forestallning.vuxenpris = Convert.ToInt32(dr["vuxenpris"]);
                forestallning.ungdomspris = Convert.ToInt32(dr["ungdomspris"]);
                forestallning.barnpris = Convert.ToInt32(dr["barnpris"]);
                forestallning.forsaljningsslut = Convert.ToDateTime(dr["forsaljningslut"]);

                forestallningslista.Add(forestallning);
            }
            conn.Close();
            return forestallningslista;
        }


        public static List<Akt> HamtaAktLista(int valdforestallningsid)
        {


            List<Akt> aktlista = new List<Akt>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            conn.Open();
            string sql1 = @"SELECT * FROM akter , forestallning WHERE akter.forestallningsid = forestallning.id
                                                 and akter.forestallningsid = :nyValdforestallningsid ORDER BY akter.starttid ASC";

            NpgsqlCommand command = new NpgsqlCommand(sql1, conn);


            command.Parameters.Add(new NpgsqlParameter("nyValdforestallningsid", DbType.Int32));
            command.Parameters[0].Value = valdforestallningsid;


            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Akt akten = new Akt();

                akten.namn = (string)dr["aktnamn"];
                akten.Aktinfo = (string)dr["aktinfo"];
                akten.Starttid = Convert.ToDateTime(dr["starttid"]);   
                akten.Sluttid = Convert.ToDateTime(dr["sluttid"]);
                akten.vuxen = Convert.ToInt32(dr["vuxenpris"]);
                akten.ungdom = Convert.ToInt32(dr["ungdomspris"]);
                akten.barn = Convert.ToInt32(dr["barnpris"]);
                akten.id = Convert.ToInt32(dr["id"]);


                aktlista.Add(akten);
            }
            conn.Close();
            return aktlista;
        }

        public static void UppdateraOpenochForsaljningsslut(int id, bool open, DateTime forsaljningsslut)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

            try
            {
                conn1.Open();
                NpgsqlCommand command1 = new NpgsqlCommand(@"UPDATE forestallning SET open = :nyOpen, forsaljningslut = :nyForsaljningsslut WHERE id = :nyId", conn1);

                command1.Parameters.Add(new NpgsqlParameter("nyId", DbType.Int32));
                command1.Parameters[0].Value = id;
                command1.Parameters.Add(new NpgsqlParameter("nyOpen", DbType.Boolean));
                command1.Parameters[1].Value = open;
                command1.Parameters.Add(new NpgsqlParameter("nyForsaljningsslut", DbType.DateTime));
                command1.Parameters[2].Value = forsaljningsslut;
               



                int numberOfAffectedRows = command1.ExecuteNonQuery();



            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show("Tyvärr uppstod ett fel! Vänligen kontrollera så att alla textboxar är korrekt ifyllda, se exempelkoden i textboxarna.");
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn1.Close();
            }
        }


        public static void LaggTillNyForestallning(string namn, string generellinfo, bool open, DateTime datum, DateTime starttid, DateTime sluttid, int vuxenpris, int ungdomspris, int barnpris, DateTime forsaljningsslut)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

            try
            {
                conn1.Open();

                NpgsqlCommand command1 = new NpgsqlCommand(@"INSERT INTO forestallning(namn, generell_info, open, datum, starttid, sluttid, vuxenpris, ungdomspris, barnpris, forsaljningslut) VALUES (:nyNamn, :nyGenerellInfo,:nyOpen , :nyDatum, :nyStarttid, :nySluttid, :nyVuxenpris, :nyUngdomspris, :nyBarnpris, :nyForsaljningsslut)", conn1);


                command1.Parameters.Add(new NpgsqlParameter("nyNamn", DbType.String));
                command1.Parameters[0].Value = namn;
                command1.Parameters.Add(new NpgsqlParameter("nyGenerellinfo", DbType.String));
                command1.Parameters[1].Value = generellinfo;
                command1.Parameters.Add(new NpgsqlParameter("nyOpen", DbType.Boolean));
                command1.Parameters[2].Value = open;
                command1.Parameters.Add(new NpgsqlParameter("nyDatum", DbType.DateTime));
                command1.Parameters[3].Value = datum;
                command1.Parameters.Add(new NpgsqlParameter("nyStarttid", DbType.DateTime));
                command1.Parameters[4].Value = starttid;
                command1.Parameters.Add(new NpgsqlParameter("nySluttid", DbType.DateTime));
                command1.Parameters[5].Value = sluttid;
                command1.Parameters.Add(new NpgsqlParameter("nyVuxenpris", DbType.Int32));
                command1.Parameters[6].Value = vuxenpris;
                command1.Parameters.Add(new NpgsqlParameter("nyUngdomspris", DbType.Int32));
                command1.Parameters[7].Value = ungdomspris;
                command1.Parameters.Add(new NpgsqlParameter("nyBarnpris", DbType.Int32));
                command1.Parameters[8].Value = barnpris;
                command1.Parameters.Add(new NpgsqlParameter("nyForsaljningsslut", DbType.DateTime));
                command1.Parameters[9].Value = forsaljningsslut;


                int numberOfAffectedRows = command1.ExecuteNonQuery();

            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn1.Close();
            }
        }

        public static void LaggTillNyAkt(string namn, string aktinfo, DateTime starttid, DateTime sluttid, int vuxen, int ungdom, int barn, int forestallningsid)  ///*, string aktinfo, DateTime starttid, DateTime sluttid, int vuxen, int ungdom, int barn*/
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

            try
            {
                conn1.Open();


                NpgsqlCommand command1 = new NpgsqlCommand(@"INSERT INTO akter(aktnamn, aktinfo, starttid, sluttid, vuxenpris, ungdomspris, barnpris, forestallningsid) VALUES (:nyAktNamn, :nyAktInfo, :nyStarttid, :nySluttid, :nyVuxenpris, :nyUngdomspris, :nyBarnpris, :nyForestallningsid)", conn1);


                command1.Parameters.Add(new NpgsqlParameter("nyAktNamn", DbType.String));
                command1.Parameters[0].Value = namn;
                command1.Parameters.Add(new NpgsqlParameter("nyAktInfo", DbType.String));
                command1.Parameters[1].Value = aktinfo;
                command1.Parameters.Add(new NpgsqlParameter("nyStarttid", DbType.DateTime));
                command1.Parameters[2].Value = starttid;
                command1.Parameters.Add(new NpgsqlParameter("nySluttid", DbType.DateTime));
                command1.Parameters[3].Value = sluttid;
                command1.Parameters.Add(new NpgsqlParameter(":nyVuxenpris", DbType.Int32));
                command1.Parameters[4].Value = vuxen;
                command1.Parameters.Add(new NpgsqlParameter("nyUngdomspris", DbType.Int32));
                command1.Parameters[5].Value = ungdom;
                command1.Parameters.Add(new NpgsqlParameter("nyBarnpris", DbType.Int32));
                command1.Parameters[6].Value = barn;
                command1.Parameters.Add(new NpgsqlParameter("nyForestallningsid", DbType.Int32));
                command1.Parameters[7].Value = forestallningsid;

                int numberOfAffectedRows = command1.ExecuteNonQuery();

            }

            catch (NpgsqlException ex1)
            {

                MessageBox.Show("akt" + ex1);
            }
            finally
            {
                conn1.Close();

            }
        }

        public static void UppdateraForestallning(int id, string namn, string generellinfo, DateTime datum, DateTime starttid, DateTime sluttid, int vuxenpris, int ungdomspris, int barnpris)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

            try
            {
                conn1.Open();
                NpgsqlCommand command1 = new NpgsqlCommand(@"UPDATE forestallning SET namn = :nyNamn, generell_info = :nyGenerellInfo, datum = :nyDatum, starttid = :nyStarttid, sluttid = :nySluttid, vuxenpris = :nyVuxenpris, ungdomspris = :nyUngdomspris, barnpris = :nyBarnpris WHERE id = :nyId", conn1);

                command1.Parameters.Add(new NpgsqlParameter("nyNamn", DbType.String));
                command1.Parameters[0].Value = namn;
                command1.Parameters.Add(new NpgsqlParameter("nyGenerellinfo", DbType.String));
                command1.Parameters[1].Value = generellinfo;
                //command1.Parameters.Add(new NpgsqlParameter("nyOpen", DbType.Boolean));
                //command1.Parameters[2].Value = open;
                command1.Parameters.Add(new NpgsqlParameter("nyDatum", DbType.DateTime));
                command1.Parameters[2].Value = datum;
                command1.Parameters.Add(new NpgsqlParameter("nyStarttid", DbType.DateTime));
                command1.Parameters[3].Value = starttid;
                command1.Parameters.Add(new NpgsqlParameter("nySluttid", DbType.DateTime));
                command1.Parameters[4].Value = sluttid;
                command1.Parameters.Add(new NpgsqlParameter("nyVuxenpris", DbType.Int32));
                command1.Parameters[5].Value = vuxenpris;
                command1.Parameters.Add(new NpgsqlParameter("nyUngdomspris", DbType.Int32));
                command1.Parameters[6].Value = ungdomspris;
                command1.Parameters.Add(new NpgsqlParameter("nyBarnpris", DbType.Int32));
                command1.Parameters[7].Value = barnpris;
                //command1.Parameters.Add(new NpgsqlParameter("nyForsaljningsslut", DbType.DateTime));
                //command1.Parameters[10].Value = forsaljningsslut;
                command1.Parameters.Add(new NpgsqlParameter("nyId", DbType.Int32));
                command1.Parameters[8].Value = id;



                int numberOfAffectedRows = command1.ExecuteNonQuery();



            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show("Tyvärr uppstod ett fel! Vänligen kontrollera så att alla textboxar är korrekt ifyllda, se exempelkoden i textboxarna.");
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn1.Close();
            }
        }


        public static void UppdateraAkt(int id, string namn, string aktinfo, DateTime starttid, DateTime sluttid, int vuxen, int ungdom, int barn)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

            try
            {
                Forestallning fs = new Forestallning();
                conn1.Open();
                NpgsqlCommand command1 = new NpgsqlCommand(@"UPDATE akter SET aktnamn = :nyNamn, aktinfo = :nyAktinfo, starttid = :nyStarttid, sluttid = :nySluttid, vuxenpris = :nyVuxen, ungdomspris = :nyUngdom, barnpris = :nyBarn WHERE id = :nyId", conn1);

                command1.Parameters.Add(new NpgsqlParameter("nyNamn", DbType.String));
                command1.Parameters[0].Value = namn;
                command1.Parameters.Add(new NpgsqlParameter("nyAktinfo", DbType.String));
                command1.Parameters[1].Value = aktinfo;
                command1.Parameters.Add(new NpgsqlParameter("nyStarttid", DbType.DateTime));
                command1.Parameters[2].Value = starttid;
                command1.Parameters.Add(new NpgsqlParameter("nySluttid", DbType.DateTime));
                command1.Parameters[3].Value = sluttid;
                command1.Parameters.Add(new NpgsqlParameter("nyVuxen", DbType.Int32));
                command1.Parameters[4].Value = vuxen;
                command1.Parameters.Add(new NpgsqlParameter("nyUngdom", DbType.Int32));
                command1.Parameters[5].Value = ungdom;
                command1.Parameters.Add(new NpgsqlParameter("nyBarn", DbType.Int32));
                command1.Parameters[6].Value = barn;
                command1.Parameters.Add(new NpgsqlParameter("nyId", DbType.Int32));
                command1.Parameters[7].Value = id;


                int numberOfAffectedRows = command1.ExecuteNonQuery();

            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show("Tyvärr uppstod ett fel! Vänligen kontrollera så att alla textboxar är korrekt ifyllda, se exempelkoden i textboxarna.");
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn1.Close();
            }
        }


        public static void TaBortAkt(int valdaktid)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

            try
            {
                Forestallning fs = new Forestallning();
                conn1.Open();
                string sql = "DELETE * FROM akt WHERE id = :valdaktid";
                NpgsqlCommand command1 = new NpgsqlCommand(sql);

                command1.Parameters.Add(new NpgsqlParameter("id", DbType.String));
                command1.Parameters[0].Value = valdaktid;

            }
            catch
            {

            }
            finally
            {

                conn1.Close();
            }

        }

    }
}
    






            
       
        
       


    

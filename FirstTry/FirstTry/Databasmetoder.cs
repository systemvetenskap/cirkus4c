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
        public static List<string> HamtaAktLista(int fsid)
        {
            List<string> aktlista = new List<string>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(@"Select aktnamn from akter , forestallning
                                                  Where akter.forestallningsid = forestallning.id
                                                  and forestallningsid = :fsid;", conn);

            command.Parameters.Add(new NpgsqlParameter("fsid", DbType.Int32));
            command.Parameters[0].Value = Convert.ToInt32(fsid);
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                aktlista.Add((string)dr["aktnamn"]);
            }
            conn.Close();
            return aktlista;
        }

        public static void LaggTillNyForestallning(string namn, string generellinfo, DateTime starttid, DateTime sluttid, int vuxenpris, int ungdomspris, int barnpris)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            NpgsqlTransaction trans = null;


            try
            {
                conn1.Open();
                trans = conn1.BeginTransaction();

                NpgsqlCommand command1 = new NpgsqlCommand(@"INSERT INTO forestallning(namn, generellinfo, starttid, sluttid, vuxenpris, ungdomspris, barnpris) VALUES (:nyttNamn, :NyGenerellInfo, :NyStarttid, :NySluttid, NyttVuxenpris, :NyttUngdomspris, :NyttBarnpris)", conn1);

                command1.Parameters.Add(new NpgsqlParameter("nyttNamn", DbType.String));
                command1.Parameters[0].Value = namn;
                command1.Parameters.Add(new NpgsqlParameter("nyGenerellinfo", DbType.String));
                command1.Parameters[0].Value = generellinfo;
                command1.Parameters.Add(new NpgsqlParameter("nyStarttid", DbType.DateTime));
                command1.Parameters[0].Value = starttid;
                command1.Parameters.Add(new NpgsqlParameter("nySluttid", DbType.DateTime));
                command1.Parameters[0].Value = sluttid;
                command1.Parameters.Add(new NpgsqlParameter("nyttVuxenpris", DbType.Int32));
                command1.Parameters[0].Value = vuxenpris;
                command1.Parameters.Add(new NpgsqlParameter("nyttUngdomspris", DbType.Int32));
                command1.Parameters[0].Value = ungdomspris;
                command1.Parameters.Add(new NpgsqlParameter("nyttBarnpris", DbType.Int32));
                command1.Parameters[0].Value = barnpris;
                command1.Transaction = trans;
                int numberOfAffectedRows = command1.ExecuteNonQuery();


                NpgsqlCommand command2 = new NpgsqlCommand(@"SELECT id FROM forestallning WHERE namn = :namn", conn1);

                command2.Parameters.Add(new NpgsqlParameter("nyttNamn", DbType.String));
                command2.Parameters[0].Value = namn;
                command2.Transaction = trans;
                int id = (int)command2.ExecuteScalar();


                NpgsqlCommand command3 = new NpgsqlCommand(@"SELECT aktid FROM forestallning WHERE aktnamn = :aktnamn", conn1);

                command3.Parameters.Add(new NpgsqlParameter("nyttNamn", DbType.String));
                command3.Parameters[0].Value = namn;

                command3.Transaction = trans;
                int aktid = (int)command3.ExecuteScalar();

                NpgsqlCommand command4 = new NpgsqlCommand(@"INSERT INTO innehaller (id, aktid) VALUES(:id, :aktid)", conn1);

                command4.Parameters.Add(new NpgsqlParameter("aktid", DbType.Int32));
                command4.Parameters[0].Value = id;
                command4.Parameters.Add(new NpgsqlParameter("id", DbType.Int32));
                command4.Parameters[0].Value = aktid;

                command4.Transaction = trans;
                numberOfAffectedRows = command4.ExecuteNonQuery();
                trans.Commit();
            }

            catch (NpgsqlException ex)
            {
                trans.Rollback();
            }
            finally
            {
                conn1.Close();
            }       
       }

        //public static void LaggTillNyForestallning(string namn, string generellinfo, DateTime starttid, DateTime sluttid, int vuxenpris, int ungdomspris, int barnpris)
        //{
        //    NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
        //    NpgsqlTransaction trans = null;


        //    try
        //    {
        //        conn1.Open();
        //        trans = conn1.BeginTransaction();

        //        NpgsqlCommand command1 = new NpgsqlCommand(@"INSERT INTO forestallning(namn, generellinfo, starttid, sluttid, vuxenpris, ungdomspris, barnpris) VALUES (:nyttNamn, :NyGenerellInfo, :NyStarttid, :NySluttid, NyttVuxenpris, :NyttUngdomspris, :NyttBarnpris)", conn1);

        //        command1.Parameters.Add(new NpgsqlParameter("nyttNamn", DbType.String));
        //        command1.Parameters[0].Value = namn;
        //        command1.Parameters.Add(new NpgsqlParameter("nyGenerellinfo", DbType.String));
        //        command1.Parameters[0].Value = generellinfo;
        //        command1.Parameters.Add(new NpgsqlParameter("nyStarttid", DbType.DateTime));
        //        command1.Parameters[0].Value = starttid;
        //        command1.Parameters.Add(new NpgsqlParameter("nySluttid", DbType.DateTime));
        //        command1.Parameters[0].Value = sluttid;
        //        command1.Parameters.Add(new NpgsqlParameter("nyttVuxenpris", DbType.Int32));
        //        command1.Parameters[0].Value = vuxenpris;
        //        command1.Parameters.Add(new NpgsqlParameter("nyttUngdomspris", DbType.Int32));
        //        command1.Parameters[0].Value = ungdomspris;
        //        command1.Parameters.Add(new NpgsqlParameter("nyttBarnpris", DbType.Int32));
        //        command1.Parameters[0].Value = barnpris;
        //        command1.Transaction = trans;
        //        int numberOfAffectedRows = command1.ExecuteNonQuery();


        //        NpgsqlCommand command2 = new NpgsqlCommand(@"SELECT id FROM forestallning WHERE namn = :namn", conn1);

        //        command2.Parameters.Add(new NpgsqlParameter("nyttNamn", DbType.String));
        //        command2.Parameters[0].Value = namn;
        //        command2.Transaction = trans;
        //        int id = (int)command2.ExecuteScalar();


        //        NpgsqlCommand command3 = new NpgsqlCommand(@"SELECT aktid FROM forestallning WHERE aktnamn = :aktnamn", conn1);

        //        command3.Parameters.Add(new NpgsqlParameter("nyttNamn", DbType.String));
        //        command3.Parameters[0].Value = namn;

        //        command3.Transaction = trans;
        //        int aktid = (int)command3.ExecuteScalar();

        //        NpgsqlCommand command4 = new NpgsqlCommand(@"INSERT INTO innehaller (id, aktid) VALUES(:id, :aktid)", conn1);

        //        command4.Parameters.Add(new NpgsqlParameter("aktid", DbType.Int32));
        //        command4.Parameters[0].Value = id;
        //        command4.Parameters.Add(new NpgsqlParameter("id", DbType.Int32));
        //        command4.Parameters[0].Value = aktid;

        //        command4.Transaction = trans;
        //        numberOfAffectedRows = command4.ExecuteNonQuery();
        //        trans.Commit();
        //    }

        //    catch (NpgsqlException ex)
        //    {
        //        trans.Rollback();
        //    }
        //    finally
        //    {
        //        conn1.Close();
        //    }
        //}

    }
}





            
       
        
       


    

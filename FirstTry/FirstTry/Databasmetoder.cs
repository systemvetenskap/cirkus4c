using System;
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
        public int x { get; set; }



        public static int LaggTillForestallning(Forestallning laggtillforestallning)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            conn.Open();
            //Forestallning laggtillforestallning = new Forestallning();
            string query = "INSERT INTO forestallning (namn, generell_info, starttid, sluttid, open, vuxenpris, ungdomspris, barnpris, fri_placering) VALUES(@namn, @generell_info, @starttid, @sluttid, @open, @vuxenpris, @ungdomspris, @barnpris, @fri_placering)";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);

            command.Parameters.AddWithValue("@namn", laggtillforestallning.namn);
            command.Parameters.AddWithValue("@generell_info", laggtillforestallning.generellinfo);
            command.Parameters.AddWithValue("@starttid", laggtillforestallning.starttid);
            command.Parameters.AddWithValue("@sluttid", laggtillforestallning.sluttid);
            command.Parameters.AddWithValue("@open", false);//false tills öppnad
            command.Parameters.AddWithValue("@vuxenpris", laggtillforestallning.vuxenpris);
            command.Parameters.AddWithValue("@ungdomspris", laggtillforestallning.ungdomspris);
            command.Parameters.AddWithValue("@barnpris", laggtillforestallning.barnpris);
            command.Parameters.AddWithValue(@"fri_placering", false);

            return command.ExecuteNonQuery();
            
        }

       
        public static List<Forestallning> HamtaForestallningLista()
        {
            List<Forestallning> forestallningslista = new List<Forestallning>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("Select * from forestallning", conn);
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
               
                Forestallning forestallning = new Forestallning();

                   forestallning.id = Convert.ToInt32(dr["id"]);
                   forestallning.namn = (string)dr["namn"];
                   forestallning.generellinfo = (string)dr["generell_info"];
                   forestallning.open = (bool)dr["open"];
                   forestallning.starttid = Convert.ToDateTime(dr["starttid"]);
                   forestallning.sluttid = Convert.ToDateTime(dr["sluttid"]);
                   forestallning.vuxenpris = Convert.ToInt32(dr["vuxenpris"]);
                   forestallning.ungdomspris = Convert.ToInt32(dr["ungdomspris"]);
                   forestallning.barnpris = Convert.ToInt32(dr["barnpris"]);
                   forestallning.friplacering = (bool)dr["fri_placering"];
                
                    
                forestallningslista.Add(forestallning);
                
            }
            conn.Close();
            return forestallningslista;

        }
        public static List<Akt> HamtaAktLista(int valdforestallningsid)
        {
            //List<Forestallning> forestallningslista = new List<Forestallning>();
            int fsid = valdforestallningsid;
            List<Akt> aktlista = new List<Akt>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(@"Select * from akter , forestallning
                                                  Where akter.forestallningsid = forestallning.id
                                                 and akter.forestallningsid = :fsid", conn);

            
             command.Parameters.Add(new NpgsqlParameter("fsid", DbType.Int32));
             command.Parameters[0].Value = valdforestallningsid;


            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Akt akten = new Akt();

                akten.id = Convert.ToInt32(dr["id"]);
                akten.namn = (string)dr["aktnamn"];
                akten.Aktinfo  = (string)dr["aktinfo"];
                akten.Starttid = Convert.ToDateTime(dr["starttid"]);   //datumtid
                akten.Sluttid = Convert.ToDateTime(dr["sluttid"]);
                akten.vuxen = Convert.ToInt32(dr["vuxenpris"]);
                akten.ungdom = Convert.ToInt32(dr["ungdomspris"]);
                akten.barn = Convert.ToInt32(dr["barnpris"]);

                aktlista.Add(akten);
            }
            conn.Close();
            return aktlista;
        }

        public static void LaggTillNyForestallning(string namn, string generellinfo, bool open ,DateTime starttid, DateTime sluttid, int vuxenpris, int ungdomspris, int barnpris, bool friplacering)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            // NpgsqlTransaction trans = new NpgsqlTransaction();
            //NpgsqlTransaction trans = null;
           
            //NpgsqlTransaction trans = conn1.BeginTransaction();

            try
            {
                conn1.Open();
               // NpgsqlTransaction trans = conn1.BeginTransaction();

                NpgsqlCommand command1 = new NpgsqlCommand(@"INSERT INTO forestallning(namn, generell_info, open, starttid, sluttid, vuxenpris, ungdomspris, barnpris, fri_placering) VALUES (:nyNamn, :nyGenerellInfo,:nyOpen ,:nyStarttid, :nySluttid, :nyVuxenpris, :nyUngdomspris, :nyBarnpris, :nyFriplacering)", conn1);

              

                command1.Parameters.Add(new NpgsqlParameter("nyNamn", DbType.String));
                command1.Parameters[0].Value = namn;
                command1.Parameters.Add(new NpgsqlParameter("nyGenerellinfo", DbType.String));
                command1.Parameters[1].Value = generellinfo;
                command1.Parameters.Add(new NpgsqlParameter("nyOpen", DbType.Boolean));
                command1.Parameters[2].Value = open;
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
                command1.Parameters.Add(new NpgsqlParameter("nyFriplacering", DbType.Boolean));
                command1.Parameters[8].Value = friplacering;
                // command1.Transaction = trans;
                int numberOfAffectedRows = command1.ExecuteNonQuery();


                //NpgsqlCommand command2 = new NpgsqlCommand(@"SELECT id FROM forestallning WHERE namn = :namn", conn1);

                //command2.Parameters.Add(new NpgsqlParameter("nyttNamn", DbType.String));
                //command2.Parameters[0].Value = namn;
                //command2.Transaction = trans;
                //int id = (int)command2.ExecuteScalar();


                //NpgsqlCommand command3 = new NpgsqlCommand(@"SELECT aktid FROM forestallning WHERE aktnamn = :aktnamn", conn1);

                //command3.Parameters.Add(new NpgsqlParameter("nyttNamn", DbType.String));
                //command3.Parameters[0].Value = namn;

                //command3.Transaction = trans;
                //int aktid = (int)command3.ExecuteScalar();

                //NpgsqlCommand command4 = new NpgsqlCommand(@"INSERT INTO innehaller (id, aktid) VALUES(:id, :aktid)", conn1);

                //command4.Parameters.Add(new NpgsqlParameter("aktid", DbType.Int32));
                //command4.Parameters[0].Value = id;
                //command4.Parameters.Add(new NpgsqlParameter("id", DbType.Int32));
                //command4.Parameters[0].Value = aktid;

                //command4.Transaction = trans;
                //numberOfAffectedRows = command4.ExecuteNonQuery();
                //trans.Commit();
            }

            catch (NpgsqlException ex)
            {
                //trans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn1.Close();
            }       
       }

        public static void LaggTillNyAkt(string namn, string aktinfo, DateTime starttid, DateTime sluttid, int vuxen, int ungdom, int barn)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            //NpgsqlTransaction trans = null;


            try
            {
                conn1.Open();
               // trans = conn1.BeginTransaction();

                NpgsqlCommand command1 = new NpgsqlCommand(@"INSERT INTO forestallning(aktnamn, aktinfo, starttid, sluttid, vuxen, ungdom, barn) VALUES (:nyAktNamn, :nyAktInfo, :nyStarttid, :nySluttid, nyVuxenpris, :nyUngdomspris, :nyBarnpris)", conn1);

                command1.Parameters.Add(new NpgsqlParameter("nyAktNamn", DbType.String));
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
               // command1.Transaction = trans;
                int numberOfAffectedRows = command1.ExecuteNonQuery();


                //NpgsqlCommand command2 = new NpgsqlCommand(@"SELECT id FROM forestallning WHERE namn = :namn", conn1);

                //command2.Parameters.Add(new NpgsqlParameter("nyttNamn", DbType.String));
                ////command2.Parameters[0].Value = namn;
                //command2.Transaction = trans;
                //int id = (int)command2.ExecuteScalar();


                //NpgsqlCommand command3 = new NpgsqlCommand(@"SELECT aktid FROM forestallning WHERE aktnamn = :aktnamn", conn1);

                //command3.Parameters.Add(new NpgsqlParameter("nyttAktNamn", DbType.String));
                //command3.Parameters[0].Value = aktnamn;

                //command3.Transaction = trans;
                //int aktid = (int)command3.ExecuteScalar();

                
                //trans.Commit();
            }

            catch (NpgsqlException ex1)
            {
                // trans.Rollback();
                MessageBox.Show("akt" + ex1);
            }
            finally
            {
                conn1.Close();
            }
        }


        

        public static void UppdateraForestallning(int id, string namn, string generellinfo, bool open, DateTime starttid, DateTime sluttid, int vuxenpris, int ungdomspris, int barnpris, bool friplacering)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
    
            try
            {
                conn1.Open();
                NpgsqlCommand command1 = new NpgsqlCommand(@"UPDATE forestallning SET namn = :nyNamn, generell_info = :nyGenerellInfo, open = :nyOpen, starttid = :nyStarttid, sluttid = :nySluttid, vuxenpris = :nyVuxenpris, ungdomspris = :nyUngdomspris, barnpris = :nyBarnpris, fri_placering = :nyFriplacering WHERE id = :nyId", conn1);

                command1.Parameters.Add(new NpgsqlParameter("nyNamn", DbType.String));
                command1.Parameters[0].Value = namn;
                command1.Parameters.Add(new NpgsqlParameter("nyGenerellinfo", DbType.String));
                command1.Parameters[1].Value = generellinfo;
                command1.Parameters.Add(new NpgsqlParameter("nyOpen", DbType.Boolean));
                command1.Parameters[2].Value = open;
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
                command1.Parameters.Add(new NpgsqlParameter("nyFriplacering", DbType.Boolean));
                command1.Parameters[8].Value = friplacering;
                command1.Parameters.Add(new NpgsqlParameter("nyId", DbType.Int32));
                command1.Parameters[9].Value = id;



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


        public static void UppdateraAkt(int id, string namn, string aktinfo, DateTime starttid, DateTime sluttid, int vuxen, int ungdom, int barn)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

            try
            {
                Forestallning fs = new Forestallning();
                conn1.Open();
                NpgsqlCommand command1 = new NpgsqlCommand(@"UPDATE akter SET aktnamn = :nyNamn, aktinfo = :nyAktinfo, starttid = :nyStarttid, sluttid = :nySluttid, vuxenpris = :nyVuxen, ungdomspris = :nyUngdom, barnpris = :nyBarn WHERE forsaljning.id = nyId", conn1);

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

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn1.Close();
            }
        }

        //ta bort akt
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
                command1.Parameters[0].Value = valdaktid; //ändrat till valdaktid eftersom den måste stämma med parameter däruppe. 


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


        // ta bort föreställning och/eller akt  

        /* kopplingar till föreställning som behöver raderas innan vi kan radera akt och sedan föreställning.
        J - funkar det inte så att man bara behöver ta   
        innehåller - akt_id,                        1  
        tempkop- forestallning, 
        biljett- forestallnings_id och akt_id,      1
        aktlista - akt                              1
        akter - forestallningsid
        */
        //string sql1 = @"DELETE *FROM akt WHERE id = :valdakt.id";// från akt ?? foreställningsid = :valdforestallning.id hade du skrivit
        //string sql2 = @"DELETE * FROM forestallning WHERE forestallningsid = :valdforestallning.id";
       
        
        //string sql5 = @"DELETE* FROM akter WHERE forestallnings_id = :valdforestallning.id";
        //GRANT INSERT ON forestallning AND akter TO user1;??
        //REVOKE INSERT ON forestallning FROM user1
        //'"+textbox+'"  '"+textbox+'" ON '"+textbox+'" FROM '"+textbox+'", conn1;  - https - beginner-sql-tutorial.com/sql-grant-revoke-privileges-roles.htm

    }






            
       
        
       


    

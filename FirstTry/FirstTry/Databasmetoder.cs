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
       



        public static int LaggTillForestallning(Forestallning laggtillforestallning)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            conn.Open();
            
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
            NpgsqlCommand command = new NpgsqlCommand("Select * from forestallning ORDER BY namn", conn);
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
           
           
            List<Akt> aktlista = new List<Akt>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
            conn.Open();
            string sql1 = @"SELECT * FROM akter , forestallning WHERE akter.forestallningsid = forestallning.id
                                                 and akter.forestallningsid = :nyValdforestallningsid";

            NpgsqlCommand command = new NpgsqlCommand(sql1, conn);

            
             command.Parameters.Add(new NpgsqlParameter("nyValdforestallningsid", DbType.Int32));
             command.Parameters[0].Value = valdforestallningsid;


            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Akt akten = new Akt();
           
                akten.namn = (string)dr["aktnamn"];
                akten.Aktinfo  = (string)dr["aktinfo"];
                akten.Starttid = Convert.ToDateTime(dr["starttid"]);   //datumtid
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



        public static void LaggTillNyForestallning(string namn, string generellinfo, bool open ,DateTime starttid, DateTime sluttid, int vuxenpris, int ungdomspris, int barnpris, bool friplacering, DateTime forsaljningsslut)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
           
            try
            {
                conn1.Open();
               
                NpgsqlCommand command1 = new NpgsqlCommand(@"INSERT INTO forestallning(namn, generell_info, open, starttid, sluttid, vuxenpris, ungdomspris, barnpris, fri_placering, forsaljningslut) VALUES (:nyNamn, :nyGenerellInfo,:nyOpen ,:nyStarttid, :nySluttid, :nyVuxenpris, :nyUngdomspris, :nyBarnpris, :nyFriplacering, :nyForsaljningsslut)", conn1);


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
                command1.Parameters.Add(new NpgsqlParameter("nyForsaljningsslut", DbType.Boolean));
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


        

        public static void UppdateraForestallning(int id, string namn, string generellinfo, bool open, DateTime starttid, DateTime sluttid, int vuxenpris, int ungdomspris, int barnpris, bool friplacering, DateTime forsaljningsslut)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");
    
            try
            {
                conn1.Open();
                NpgsqlCommand command1 = new NpgsqlCommand(@"UPDATE forestallning SET namn = :nyNamn, generell_info = :nyGenerellInfo, open = :nyOpen, starttid = :nyStarttid, sluttid = :nySluttid, vuxenpris = :nyVuxenpris, ungdomspris = :nyUngdomspris, barnpris = :nyBarnpris, fri_placering = :nyFriplacering, forsaljningslut = :nyForsaljningsslut WHERE id = :nyId", conn1);

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
                command1.Parameters.Add(new NpgsqlParameter("nyForsaljningsslut", DbType.DateTime));
                command1.Parameters[8].Value = forsaljningsslut;
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

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn1.Close();
            }
        }

        public static void UppdateraDateTimePicker(int id, DateTime forsaljningsslut)
        {
           
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

            try
            { 
                Forestallning fs = new Forestallning();
                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE forestallning SET forsaljningslut = :nyForsaljningsslut WHERE id = :nyId", conn);

                command.Parameters.Add(new NpgsqlParameter("nyForsaljningsslut", DbType.DateTime).Value);
                command.Parameters[0].Value = forsaljningsslut;
                command.Parameters.Add(new NpgsqlParameter("nyId", DbType.Int32));
                command.Parameters[9].Value = id;

                int numberOfAffectedRows = command.ExecuteNonQuery();

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

    

    }






            
       
        
       


    

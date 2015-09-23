using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace FirstTry
{
    class Tempkop
    {

        public Forestallning forestallning { get; set; }
        public List<Akt> akter { get; set; }
        public int vuxna { get; set; }
        public int ungdom { get; set; }
        public int barn { get; set; }
        public bool reservation { get; set; }
        public int antal { get; set; }

        public int loopar { get; set; }

        public int kund_id { get; set; }
        public int totalpris { get; set; }

        public bool hela { get; set; }

        public List<int> biljett_id {get; set;}
        public List<string> platsnamn { get; set; }
        public List<string> typ { get; set; }
        public string epost { get; set; }
        public List<Biljett> biljetter { get; set; }



        public Tempkop()
        {
            biljetter = new List<Biljett>();
        }


        public bool fullbokat(Tempkop tk)
        {
           
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;Database=pgmvaru_g4;User Id=pgmvaru_g4;Password=trapets;ssl=true");

           // int id = akt_id;//akten.id;

            string query = "select platser_id, tidsstampel, reserverad from innehaller where akter_id = ";

            if (tk.akter != null)
            {



                foreach (Akt item in tk.akter)
                {
                    query += item.id.ToString();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    int x = 0;
                    x = tk.vuxna + tk.barn + tk.ungdom;


                    if (x >= 16)
                    {
                        // MessageBox.Show("Tyvärr finns inte tillräkligt med plats, utanför");
                        // this.Hide();
                        //Huvudsidan hu = new Huvudsidan();
                        //hu.ShowDialog();
                        // Close();
                        return true;
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        if (x >= 16)
                        {
                            // MessageBox.Show("Tyvärr finns inte tillräkligt med plats, innanför");
                            //this.Hide();
                            Huvudsidan hu = new Huvudsidan();
                            hu.ShowDialog();
                            //Close();
                            return true;
                        }
                        x++;
                    }
                }
            }         
                return false;
        }
    }

    
}

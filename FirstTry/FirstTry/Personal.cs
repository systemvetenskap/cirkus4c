using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTry
{
    class Personal
    {

        public int Id { get; set; }
        public string Fornamn { get; set; }
        public string Efternamn { get; set; }
        public int Inlog_id { get; set; }
    //    public string Personnr { get; set; }
        public string losenord { get; set; }
        public string anvandarnamn { get; set; }
        public List<Behorigheter> behorigheter { get; set; }


        public Personal()
        {
            behorigheter = new List<Behorigheter>();
        }

        public override string ToString()
        {
            return Fornamn + " " + Efternamn /*+ " " + Personnr*/;
        }
    }
}

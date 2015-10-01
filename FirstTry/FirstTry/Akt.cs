using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTry
{
    class Akt
    {

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
                return namn + "\t " + Starttid.ToShortTimeString();
            }
            else
            {
                return namn + "\t "+ "\t " + Starttid.ToShortTimeString();
            }

           
        }
    }
}

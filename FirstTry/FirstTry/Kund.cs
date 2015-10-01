using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTry
{
    class Kund
    {
        public int kund_id { get; set; }
        public string fornamn { get; set; }
        public string efternamn { get; set; }
        public string telefon { get; set; }
        public string epost { get; set; }
        public List<Biljett> bilj { get; set; }

        public Kund ()
        {
            bilj = new List<Biljett>();
        }
        public override string ToString()
        {
            return fornamn.ToString() + " " + efternamn.ToString();
        }

    }
}

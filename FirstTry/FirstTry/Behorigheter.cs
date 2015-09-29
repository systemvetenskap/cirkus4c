using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTry
{
    class Behorigheter
    {

       // public List<Aktorstyp> aktorstyper { get; set; }
        public string Typ { get; set; }
        public string Id { get; set; }


        public override string ToString()
        {
            return Typ;
        }

    }
}
    
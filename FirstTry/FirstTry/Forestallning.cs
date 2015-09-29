using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FirstTry
{
    class Forestallning
    {
        

        public string namn { get; set; }
        public int id { get; set; }
        public string generellinfo { get; set; }
        public bool open { get; set; }
        public DateTime datum { get; set; }
        public DateTime starttid { get; set; }
        public DateTime sluttid { get; set; }
        public int vuxenpris { get; set; }
        public int ungdomspris { get; set; }
        public int barnpris { get; set; }
        public DateTime forsaljningsslut { get; set; }
        public bool friplacering { get; set; }
        public List<Akt> akter { get; set; }
        public int vuxen { get; set; }
        public int ungdom { get; set; }
        public int barn { get; set; }
        public DateTime tid { get; set; }


        public override string ToString()
        {
            return namn + "\t \t" + starttid.ToShortDateString() + " " + starttid.ToShortTimeString();
        }

    }
}

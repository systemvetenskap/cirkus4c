using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTry
{
    class Forestallning
    {
        

        public string namn { get; set; }
        public int id { get; set; }
        public int vuxenpris { get; set; }
        public int ungdomspris { get; set; }
        public int barnpris { get; set; }
        public string generellinfo { get; set; }
        public DateTime starttid { get; set; }
        public DateTime sluttid { get; set; }
        public bool open { get; set; }
        public List<Akt> akter { get; set; }




        public override string ToString()
        {
            return namn;
        }

    }
}

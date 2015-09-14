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
        public List<Akt> akter { get; set; }



        public override string ToString()
        {
            return namn;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTry
{
    class Biljett
    {

        public Forestallning forestallning { get; set; }
        public Akt akter { get; set; }
        public int pris { get; set; }
        public string biljettyp { get; set; }
        public int biljett_id { get; set; }
        public int plats_id { get; set; }
        public bool resserverad { get; set; }
        public bool hela { get; set; }
        //datum
        //tid

        /// <summary>
        /// Make life hell.
        /// </summary>
        public Biljett()
        {
            

        }
        public override string ToString()
        {
            return biljett_id.ToString();
        }

    }
}

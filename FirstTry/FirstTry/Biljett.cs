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
        public List<Akt> akter { get; set; }
        public int pris { get; set; }
        public DateTime tid { get; set; }
        public string biljettyp { get; set; }
        public int biljettnummer { get; set; }
        
        /// <summary>
        /// Make life hell.
        /// </summary>
        public Biljett()
        {


        }
    }
}

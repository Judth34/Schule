using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StraßenNetzLib
{
    public class Abschnitt
    {
        public string id { get; set; }
        public string descr { get; set; }

        public Abschnitt(string id, string descr)
        {
            this.id = id;
            this.descr = descr;
        }

        override
        public string ToString()
        {
            return id + ", " + descr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonenLib;

namespace StraßenNetzLib
{
    public class Zuteilung
    {
        public decimal person { get; set; }
        public string abschnitt { get; set; }

        public Zuteilung(decimal p, string a)
        {
            this.person = p;
            this.abschnitt = a;
        }

        override
        public string ToString()
        {
            return "Zuteilung: Abschnitt: " + abschnitt + " zugeteilt: " + person;
        }
    }
}

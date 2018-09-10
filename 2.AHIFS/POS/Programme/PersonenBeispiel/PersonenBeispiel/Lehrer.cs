using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonenBeispiel
{
    class Lehrer : Person
    {
        public string Kuerzel { get; set; }

        public Lehrer(string ASVGNr) : base (ASVGNr)
        {

        }
    }
}

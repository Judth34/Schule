using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonenBeispiel
{
    class Schueler : Person
    {
        public byte Katalognummer { get; set; }
        public string Klasse { get; set; }

       public Schueler(string ASVGNr) : base (ASVGNr)
        {

        }

    }
}

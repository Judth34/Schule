using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonenBeispiel
{
    class Abteilungsvorstand : Lehrer
    {
        public string Datum { get; set; }

        public Abteilungsvorstand(string ASVGNr) : base (ASVGNr)
        {

        }
    }
}

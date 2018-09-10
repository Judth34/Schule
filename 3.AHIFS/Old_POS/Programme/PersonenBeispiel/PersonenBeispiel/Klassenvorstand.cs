using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonenBeispiel
{
    class Klassenvorstand : Lehrer
    {
        public string Klasse { get; set; }

        public Klassenvorstand(string ASVGNr) : base(ASVGNr)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonenBeispiel
{
    class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string ASVGNr { get; set; }

        public Person(string ASVGNr)
        {
            this.ASVGNr = ASVGNr;
        }
    }
}

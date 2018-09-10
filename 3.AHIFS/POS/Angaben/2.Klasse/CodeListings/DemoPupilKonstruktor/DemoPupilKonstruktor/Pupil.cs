using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPupilKonstruktor
{
    class Pupil
    {
        public string Name;
        public int Id;
        public int CatalogNumber;

        public Pupil (string Name)
        {
            this.Name = Name;
            Console.WriteLine("Der 1. Pupil-Konstruktor wurde aufgerufen!");
        }

        public Pupil (string Name, int CatalogNumber)
        {
            this.Id = (int) DateTime.Now.Ticks;
            this.CatalogNumber = CatalogNumber;
            this.Name = Name;

            Console.WriteLine("Der 2. Pupil-Konstruktor wurde aufgerufen!");
        }

        public string GetPupilData ()
        {
            return "(" + CatalogNumber + ") " 
                + Name + 
                " <"+ this.Id +">"; 
        }


    }
}

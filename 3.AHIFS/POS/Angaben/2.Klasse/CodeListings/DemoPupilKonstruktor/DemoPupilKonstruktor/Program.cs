using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPupilKonstruktor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pupil p1 = new Pupil()
            //p1.CatalogNumber = 5;
            //p1.Name = "Bugelnig";

            Pupil p1 = new Pupil("Bugelnig", 5);
            Console.WriteLine(p1.GetPupilData());

            Pupil p2 = new Pupil("Kandut", 11);
            Console.WriteLine(p2.GetPupilData());

            Pupil p3 = new Pupil("Kraschl");
            Console.WriteLine(p3.GetPupilData());
        }
    }
}

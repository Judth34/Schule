using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parameter
{
    class Program
    {
        static void Main(string[] args)
        {
            int Zahl1 = 25;
            int Zahl2 = 12;
            string Name;
            string Wohnort="";

            MethodeIn(Zahl1, Zahl2);
            Console.WriteLine(Zahl1);
            Console.WriteLine(Zahl2);

            MethodOut(out Name);
            Console.WriteLine(Name);

            MethodeRef(ref Wohnort);
            Console.WriteLine(Wohnort);
            
        }

        static void MethodeIn(int Zahl1, int Zahl2)
        {
            Zahl1 = Zahl1 + Zahl2;
        }

        static void MethodOut(out string MeinName)
        {
            MeinName = "Andreas Drabosenig";
        }

        static void MethodeRef(ref string MeinWohnort)
        {
            MeinWohnort = "Ledenitzen";
        }

        //static void MethodeParasm(params string[] satz)
        //{

        //}
    }
}

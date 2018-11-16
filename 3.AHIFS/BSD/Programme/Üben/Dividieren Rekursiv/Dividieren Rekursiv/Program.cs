using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dividieren_Rekursiv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(dividiere(88, 8));
        }
        static int dividiere(int Zahl1, int Zahl2)
        {
            if(Zahl1 - Zahl2 >= 0)
            {
                return 1 + dividiere(Zahl1 - Zahl2, Zahl2);
            }

            return 0;
        }
    }
}

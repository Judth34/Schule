using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probe
{
    class Program
    {
        static void Main(string[] args)
        {
            int erg = 0;

            erg = Addiere(-5, 2);
            Console.WriteLine(erg);

            erg = Addiere(2, 5);
            Console.WriteLine(erg);

            erg = Addiere(-100, -2);
            Console.WriteLine(erg);
        
        }

        static int Addiere(int z1, int z2)
        {
            int erg = 0;

            if(z1<0||z2<0)
            {
                erg = -1;
            }
            else
            {
                erg = z1 + z2;

            }

            return erg;

        }
    }
}

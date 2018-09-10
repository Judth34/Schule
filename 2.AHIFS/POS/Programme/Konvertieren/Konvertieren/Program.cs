using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konvertieren
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            float f = 3.14F;
            i = (int)f;
            byte b = 0;
            i = 257;
            b = (byte) i;
            Console.WriteLine(i);
            Console.WriteLine(b);
            double d = 44.44;
            i =(int) d;

            Console.WriteLine(i);
        }
    }
}

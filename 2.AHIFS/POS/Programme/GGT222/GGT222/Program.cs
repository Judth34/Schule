using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGT222
{
    class Program
    {
        static void Main(string[] args)
        {
            int Nenner = 28;
            int Zaehler =35;
            int erg = 0;
            int GGT = 0;

            if (Nenner > Zaehler)
            {
                do
                {
                    erg = Nenner - Zaehler;

                    if (Zaehler < erg)
                    {
                        Nenner = erg;
                    }

                    if (Zaehler > erg)
                    {
                        Nenner = Zaehler;
                        Zaehler = erg;
                    }

                    if (Nenner - Zaehler == Zaehler)
                    {
                        Nenner = erg;
                    }
                    GGT = Nenner;
                } while (erg != 0);
            }
            
            if(Nenner < Zaehler)
            {
                 
                do
                {
                    erg = Zaehler - Nenner;

                    if (Nenner < erg)
                    {
                        Zaehler = erg;
                    }

                    if (Nenner > erg)
                    {
                        Zaehler = Nenner;
                        Nenner = erg;
                    }

                    if (Zaehler - Nenner == Nenner)
                    {
                        Zaehler = erg;
                    }
                    GGT = Zaehler;
                } while (erg != 0);
            }
            Console.WriteLine(GGT);
        }
    }
}

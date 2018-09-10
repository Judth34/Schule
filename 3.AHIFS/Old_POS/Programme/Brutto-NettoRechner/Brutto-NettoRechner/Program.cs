using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brutto_NettoRechner
{
    class Program
    {
        static void Main(string[] args)
        {
            double BruttoImMonat = 0;
            int Auswahl = 0;

            BruttoImMonat = GetAValidNumber(0, 1000000, "Geben Sie ihr Brutto Gehalt pro Monat ein: ");           
            Auswahl = GetAValidNumber(0, 1, "Sind Sie ein Angestellter(0 eingeben) oder ein Arbeiter(1 eigeben):");
          
            Console.WriteLine("Sie verdienen " + Rechner.BruttoInNetto(BruttoImMonat, Auswahl) + " Euro Netto im Monat.");
        }

        static int GetAValidNumber(int min, int max, string Eingabe)
        {
            int i;
            bool result;

            do
            {
                Console.Write(Eingabe);
                result = int.TryParse(Console.ReadLine(), out i);

            } while (i < min || i > max || result == false);
            return i;
        }
    }
}

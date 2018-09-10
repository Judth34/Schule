using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBruch2_0
{
    class Program
    {
        static void Main(string[] args)
        {
            int Zaehler1;
            int Nenner1;
            int Zaehler2;
            int Nenner2;
            int wahl;

            Zaehler1 = GetAValid(0, 10, "Zaehler1: ");
            Nenner1 = GetAValid(0, 10, "Nenner1: ");

            Zaehler2 = GetAValid(0, 10, "Zaehler2: ");
            Nenner2 = GetAValid(0, 10, "Nenner2: ");

            Bruch Zahl1 = new Bruch();
            Bruch Zahl2 = new Bruch();
            try
            {
                
                Zahl1.Zaehler = Zaehler1;
                Zahl1.Nenner = Nenner1;

                
                Zahl2.Zaehler = Zaehler2;
                Zahl2.Nenner = Nenner2;

                Console.WriteLine("1. Bruch");
                Console.WriteLine(Zahl1.GanzerBruch());

                Console.WriteLine("2.Bruch");
                Console.WriteLine(Zahl2.GanzerBruch());

                #region Auswahl der Rechnungsart
                wahl = GetAValid(0, 4, "Wollen Sie die Brueche addieren (1), subtrahieren (2), multiplizieren (3) oder dividieren (4):");
                switch (wahl)
                {
                    case 1:
                        Zahl1.addiere(Zahl2);
                        Console.WriteLine("Bruch: " + Zahl1.GanzerBruch());
                        Console.WriteLine("Ergebnis: " + Zahl1.Zahl);
                        break;

                    case 2:
                        Zahl1.subtrahiere(Zahl2);
                        Console.WriteLine("Bruch: " + Zahl1.GanzerBruch());
                        Console.WriteLine("Ergebnis: " + Zahl1.Zahl);
                        break;

                    case 3:
                        Zahl1.multipliziere(Zahl2);
                        Console.WriteLine("Bruch: " + Zahl1.GanzerBruch());
                        Console.WriteLine("Ergebnis: " + Zahl1.Zahl);
                        break;

                    case 4:
                        Zahl1.dividiere(Zahl2);
                        Console.WriteLine("Bruch: " + Zahl1.GanzerBruch());
                        Console.WriteLine("Ergebnis: " + Zahl1.Zahl);
                        break;

                    default:
                        break;
                }
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static int GetAValid(int min, int max, string Eingabe)
        {
            int i;
            bool result;

            do
            {
                Console.WriteLine(Eingabe);
                result = int.TryParse(Console.ReadLine(), out i);

            } while (i < min || i > max || result == false);
            return i;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Kommentar:
// Hier gibts die Infos zum Nullable-Datatype:
// https://msdn.microsoft.com/de-at/library/1t3y8s4s.aspx?f=255&MSPPError=-2147217396 
//

namespace ConsoleApplication11
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Referenz- und Wertedatentypen
            int i = 10;
            Rechner r1 = new Rechner();
            r1.Zahl1 = 9;
            r1.Zahl2 = 10;

            doSomething(r1);
            doSomething1(i);

            Console.WriteLine("Zahl1: {0}; Zahl2: {1}", r1.Zahl1, r1.Zahl2);
            Console.WriteLine("Integer i = {0}", i);
            #endregion

            #region Kapselung
            try
            {
                Rechner r2 = new Rechner();
                r2.Zahl2 = 20;
                r2.Zahl1 = 5;

                r2.Addiere();
                // r2.Zahl1 = 100;
                Console.WriteLine("{0} + {1} = {2}",
                    r2.Zahl1, r2.Zahl2, r2.Resultat);
            }
            catch (Exception myEx)
            {
                Console.WriteLine(myEx.Message);
            }
            #endregion

            #region Static 
            Console.WriteLine("Anzahl von Rechner-Objekten: {0}", 
                Rechner.InstanceCounter);
            #endregion
        }

        private static void doSomething1(int j)
        {
            j = j * 2;
        }

        private static void doSomething(Rechner aObjectReference)
        {
            aObjectReference.Zahl1 = 99;
            aObjectReference.Zahl2 = 100;
        }
    }
}

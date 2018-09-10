using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kilowatt_PS_Umwandler
{
    class Program
    {
        static void Main(string[] args)
        {
            double PS = 0;
            double KW = 0;
            int Auswahl = 0;

            Console.WriteLine("Wollen Sie PS in KW (= 0) oder KW in PS(= 1) umrechnen");
            Auswahl = int.Parse(Console.ReadLine());

            #region Auswahl
            if (Auswahl == 0)
            {
                try
                {
                    Console.WriteLine("Geben Sie einen Wert fuer PS ein:");
                    PS = double.Parse(Console.ReadLine());
                    Console.WriteLine("Umgerechnet sind es " + Umrechner.PSinKW(PS) + "KW");
                }
                catch(Exception Fail)
                {
                    Console.WriteLine("Fehler: " + Fail.Message);
                }
                
            }
            else
            {
                if(Auswahl == 1)
                {
                    try
                    {
                        Console.WriteLine("Geben Sie einen Wert fuer KW ein:");
                        KW = double.Parse(Console.ReadLine());
                        Console.WriteLine("Umgerechnet sind es " + Umrechner.KWinPS(KW) + "PS");
                    }
                    catch(Exception Fail2)
                    {
                        Console.WriteLine("Fehler: " + Fail2.Message);
                    }
                }
            }

        }
        #endregion
    }


}

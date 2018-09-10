using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Beispiel
{
    class Program
    {
        static void Main(string[] args)
        {
            bool MotorAn = false;
            bool AutoFaehrt = false;
            int AuswahlDesZustandes = 0;
            Auto ZustandDesAutos = new Auto(MotorAn, AutoFaehrt);

            Console.WriteLine("Bedienungsanleitung: ");
            Console.WriteLine("Mit der 1 starten Sie den Motor.");
            Console.WriteLine("Mit der 2 schalten Sie den Motor ab.");
            Console.WriteLine("Mit der 3 fahren Sie los.");
            Console.WriteLine("Mit der 4 halten Sie an.\n");

            #region Zustand des Autos
            do
            {
                AuswahlDesZustandes = GetAValid(0, 4, "Was soll das Auto machen: ");

                if (ZustandDesAutos.GetMotor() == false && ZustandDesAutos.GetFaehrt() == false && AuswahlDesZustandes == 1)
                {
                    ZustandDesAutos.anstarten();
                    Console.WriteLine("Sie haben den Motor gestartet.\n");
                }

                if (ZustandDesAutos.GetMotor() == true && ZustandDesAutos.GetFaehrt() == false && AuswahlDesZustandes == 2)
                {
                    ZustandDesAutos.abstellen();
                    Console.WriteLine("Sie haben den Motor abgestellt.\n");
                }

                if (ZustandDesAutos.GetMotor() == true && ZustandDesAutos.GetFaehrt() == false && AuswahlDesZustandes == 3)
                { 
                    ZustandDesAutos.anfahren();
                    Console.WriteLine("Sie fahren.\n");
                }

                if (ZustandDesAutos.GetMotor() == true && ZustandDesAutos.GetFaehrt() == true && AuswahlDesZustandes == 4)
                {
                    ZustandDesAutos.anhalten();
                    Console.WriteLine("Sie bleiben stehen.\n");
                }
               
                if(AuswahlDesZustandes == 0)
                {
                    Console.WriteLine("Aus");
                }
            } while (AuswahlDesZustandes != 0);
            #endregion

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

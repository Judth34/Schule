using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int Zahl = 10;
            int FiboZahl = 6;
            Counter(Zahl);
            Countdown(Zahl);
            GGT(14, 140);
            int Ergebniss = Fibo(FiboZahl);
            Console.WriteLine("Fibonacci Folge: " + Ergebniss);
         }

        static int Fibo(int n)
        {
            if (n < 0)
                return 0;

            if (n == 0)
                return 1;

            return Fibo(n - 1) + Fibo(n - 2);
        }

        static void GGT(int n1, int n2)
        {
            if(n1 == n2)
            {
                Console.WriteLine("Der GGt ist: " + n1);
            }
            else if(n1 < n2)
            {
                GGT(n1, n2 - n1);
            }
            else if(n1 > n2)
            {
                GGT(n1 - n2, n2);
            }                
        }

        static void Counter(int n)
        {
            if (n > 0)
            {
                Counter(n - 1);
                Console.WriteLine(n);
            }
        }

        static void Countdown(int n)
        {
            if (n > 0)
            {
                Console.WriteLine(n);
                Countdown(n - 1);
            }
        }
    }
}

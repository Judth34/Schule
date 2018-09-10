using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addieren
{
    class Program
    {
        static void Main(string[] args)
        {
            int summe = 0;
            summe=addieren(25,25);
            Console.WriteLine("Die Summe=" +summe);
        }

        static int addieren(params int[] zahlen)
        {
            int result = 0;

            for (int idx = 0; idx < zahlen.Length; idx++)
            {
                result = zahlen[idx]+result;
            }
            return result;
        }
    }
}
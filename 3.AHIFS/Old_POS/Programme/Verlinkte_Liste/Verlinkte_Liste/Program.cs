using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlinkte_Liste
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTestCaseResult("01", TestCases.TestCount());
            PrintTestCaseResult("02", TestCases.TestGetAValueAt());
            SimpleList n = new SimpleList();
            
            Console.WriteLine("Programm Ende");
        }

        private static void PrintTestCaseResult(string TestCaseName, bool TestCaseResult)
        {
            ConsoleColor oldcolor = Console.ForegroundColor;
            if (TestCaseResult)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine("Ergebnis von {0} ist {1}" , TestCaseName , TestCaseResult);
            Console.ForegroundColor = oldcolor;
        }
    }
}

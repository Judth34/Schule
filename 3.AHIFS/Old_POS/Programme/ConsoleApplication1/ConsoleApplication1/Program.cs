using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string namen = " ";
            MethodParams("Josef", "Hans", "Maria");
            Console.WriteLine(namen);
        }

        static string[] MethodParams(params string[] namen)
        {
            namen[0] = namen[0];
            return namen[0];
        }
    }
}

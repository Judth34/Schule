using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concat
{
    class Program
    {
        static void Main(string[] args)
        {
            string namen;

            namen=concat("Peter", "Hans", "Klaus");
            Console.WriteLine(namen);
        }

        static string concat(params string[]namen)
        {
            string result = "";
            
            for(int idx=0; idx<namen.Length;idx++)
            {
                result = result + namen[idx] + ";"; 
            }

            return result;
          
        }
    }
}

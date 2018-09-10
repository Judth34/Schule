using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Float_double_decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            float calcresult = 0;
            double calcresultdd = 0;
            decimal calcresultdc = 0;
            int counter;

            for(counter =10000; counter>0; counter--)
            {
                calcresult += 0.3F;

                calcresultdd += 0.3;

                calcresultdc += 0.3m;
            }

            Console.WriteLine("10.000 mal 0.3 = {1} mit float" ,calcresult);
            Console.WriteLine("10.000 mal 0.3 = {1} mit double" ,calcresultdd);
            Console.WriteLine("10.000 mal 0.3 = {1} mit decimal" ,calcresultdc);
        }
    }
}

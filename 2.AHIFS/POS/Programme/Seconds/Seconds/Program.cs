using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            TimePeriod time = new TimePeriod();
            time.Hours = 24;
            Console.WriteLine("Time in hours: " + time.Hours);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace _10_Judth_Marcel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Average a = new Average("config.txt");
                double[] average = a.CalculateAverage();

                Console.WriteLine("Average tree:" + average[0]);
                Console.WriteLine("Average list:" + average[1]);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CLBTreeList;
using System.Text;
using System.Threading.Tasks;

namespace PLFJulianBlaschke
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadBinaryfile lb = new LoadBinaryfile();
            //SimpleList s = lb.createSimpleList();
            //List<double?> l = s.PrintAll();
            //foreach (double? value in l)
            //{
            //    Console.WriteLine(value);
            //}

            Console.WriteLine("Durchschitt aller Doulbe Werte:\t" + lb.GetAverageDouble());
            Console.WriteLine("Durchschitt aller int32 Werte:\t" + lb.GetAverageInteger());

        }
    }
}

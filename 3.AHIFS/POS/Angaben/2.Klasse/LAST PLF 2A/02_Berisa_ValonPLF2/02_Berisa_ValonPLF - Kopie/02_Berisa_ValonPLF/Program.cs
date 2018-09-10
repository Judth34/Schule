using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_Berisa_ValonPLF;

namespace _02_Berisa_ValonPLF
{
    class Program
    {
        // KAA: Programm macht eine Ausgabe, die nicht der Vorgabe entspricht!
        //
        static void Main(string[] args)
        {
            // getAverage gemacht aber funktioniert nicht... 

            CSV c = new CSV("Filenames.config");
            string[] filenames = c.LoadCSV();

            List<int> test = new List<int>();
            BinaryManager bm1 = new BinaryManager();
            Console.WriteLine("integers : ");
            bm1.LoadBinary(filenames);
            BinaryTree b3 = bm1.myTreefilledwithIntegers;
            test = b3.getValues();
            test.ForEach(Console.WriteLine);

            Console.WriteLine("\n\n\n");

            Console.WriteLine("doubles");
            SimpleList s1 = bm1.mySimpleListfilledwithDoubles;
            string[] test2 = s1.GetValues();  // KAA: wieso string - Werte werden richtig lesen und geladen, aber es gibt keine AVG-Berechnung, die funktioniert!
            foreach (var item in test2)
            {
                Console.WriteLine(item);
            }

        }
    }

}

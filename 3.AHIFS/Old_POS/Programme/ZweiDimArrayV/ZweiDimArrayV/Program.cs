using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZweiDimArrayV
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] array = new string[4, 6];
            array[0, 0] = "D";
            array[0, 1] = "D";
            array[0, 2] = "D";
            array[0, 3] = "D";
            array[0, 4] = "D";
            array[0, 5] = "D";
            array[1, 0] = "C";
            array[1, 1] = "C";
            array[1, 2] = "C";
            array[1, 3] = "C";
            array[1, 4] = "C";
            array[1, 5] = "C";
            array[2, 0] = "B";
            array[2, 1] = "B";
            array[2, 2] = "B";
            array[2, 3] = "B";
            array[2, 4] = "B";
            array[2, 5] = "B";
            array[3, 0] = "A";
            array[3, 1] = "A";
            array[3, 2] = "A";
            array[3, 3] = "A";
            array[3, 4] = "A";
            array[3, 5] = "A";
            

            string[,] help = new string[1, 6];

            for (int counter = 0; counter < ((array.GetLength(0) * 2) - 1); counter++)
            {
                for (int idx = 0; idx < (array.GetLength(0) - 1); idx++)
                {
                    if (array[idx, 0].CompareTo(array[(idx + 1), 0]) > 1)
                    {
                        for (int idxs = 0; idxs < array.GetLength(1); idxs++)
                        {
                            help[0, idxs] = array[idx, idxs];
                        }
                        for (int idxs = 0; idxs < array.GetLength(1); idxs++)
                        {
                            array[idx, idxs] = array[(idx + 1), idxs];
                        }
                        for (int idxs = 0; idxs < array.GetLength(1); idxs++)
                        {
                            array[(idx + 1), idxs] = help[0, idxs];
                        }
                    }
                }
            }
            Console.WriteLine(array[0, 0]);
            Console.WriteLine(array[0, 1]);
            Console.WriteLine(array[0, 2]);
            Console.WriteLine(array[0, 3]);
            Console.WriteLine(array[0, 4]);
            Console.WriteLine(array[0, 5]);

            Console.WriteLine(array[1, 0]);
            Console.WriteLine(array[1, 1]);
            Console.WriteLine(array[1, 2]);
            Console.WriteLine(array[1, 3]);
            Console.WriteLine(array[1, 4]);
            Console.WriteLine(array[1, 5]);

            Console.WriteLine(array[2, 0]);
            Console.WriteLine(array[2, 1]);
            Console.WriteLine(array[2, 2]);
            Console.WriteLine(array[2, 3]);
            Console.WriteLine(array[2, 4]);
            Console.WriteLine(array[2, 5]);

            Console.WriteLine(array[3, 0]);
            Console.WriteLine(array[3, 1]);
            Console.WriteLine(array[3, 2]);
            Console.WriteLine(array[3, 3]);
            Console.WriteLine(array[3, 4]);
            Console.WriteLine(array[3, 5]);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileNames = new string[3];
            double[] Values1 = new double[100];
            double[] Values2 = new double[100];
            double[] Values3 = new double[100];

            fileNames = Config.getFiles(@"E:\C#\filesDemo\filesDemo\bin\Debug\Files\Filenames.config");

            Values1 = BinFile.getValues(fileNames[0]);
            Values2 = BinFile.getValues(fileNames[1]);
            Values3 = BinFile.getValues(fileNames[2]);

            Console.WriteLine(Values1[0]);

        }
    }
}

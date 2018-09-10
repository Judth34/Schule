using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF
{
    class Program
    {
        // KAA: ganz eindeutig nicht genügend - ein schwerer Fehler nach dem anderen! 
        //      die Datenstruktur des Baumes kommt nicht in einmal mehr vor!!! 


        static void Main(string[] args)
        {
            string[] fileNames = new string[3];
            List<int> Int32 = new List<int>();
            List<double> Double = new List<double>();

            fileNames = Config.getFiles(@".\Filenames.config");

            // KAA: SChleife!!!
            add(BinFile.getValues(fileNames[0]),ref Int32,ref Double);
            add(BinFile.getValues(fileNames[1]),ref Int32,ref Double);
            add(BinFile.getValues(fileNames[2]),ref Int32,ref Double);

            Console.WriteLine(DurchschnittInt(Int32));
            Console.WriteLine(DurchschnittDouble(Double));
            
        }
        public static void add(double[] Values,ref List<int> Int32,ref List<double> Double)
        {
            int idx = 0;
            while(idx < Values.Length)
            {
                Int32.Add((int)Values[idx]);
                idx++;
                Double.Add(Values[idx]);
                idx++;
            }
        }
        public static double DurchschnittInt(List<int> Int32)
        {
            return Int32.Average();

        }
        public static double DurchschnittDouble(List<double> Double)
        {
            return Double.Average();
        }
    }
}

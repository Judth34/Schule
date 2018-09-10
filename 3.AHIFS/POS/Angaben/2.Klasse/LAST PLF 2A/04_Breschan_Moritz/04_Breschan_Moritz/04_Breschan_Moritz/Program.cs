using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Breschan_Moritz
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = @".\PLFAngaben\";
            FileLoader.FileLoaderTXT config = new FileLoader.FileLoaderTXT(Path + "Filenames" + @".config");
            List<string> Dateinamen = config.Load();
            Datastructures.SimpleList List = new Datastructures.SimpleList();
            Datastructures.SimpleTree Tree = new Datastructures.SimpleTree();
            int counter = 0;
            foreach (string s in Dateinamen)
            {
                FileLoader.FileLoaderBin binLodaer = new FileLoader.FileLoaderBin(Path + Dateinamen[counter]);
                counter++;
                binLodaer.Load(List, Tree);
            }
            Console.WriteLine("int: " + Tree.GetAverage());

            double ergDouble = 0;
            double[] AllDoublevalues = List.GetValues();
            foreach(double d in AllDoublevalues)
            {
                ergDouble += d;
            }
            Console.WriteLine("Double: " + ergDouble / AllDoublevalues.Length);
        }
    }
}

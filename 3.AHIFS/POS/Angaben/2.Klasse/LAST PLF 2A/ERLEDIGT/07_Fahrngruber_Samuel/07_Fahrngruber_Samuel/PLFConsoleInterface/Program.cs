using PLFClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string configFilename;// = "Filenames.config";
                Console.Write("Geben Sie den Dateinamen der Config-Datei ein: ");
                configFilename = Console.ReadLine();

                string[] ConfigFileLines = File.ReadAllLines(configFilename);

                Tree IntTree = new Tree();
                List<double> DoubleList = new List<double>();

                double doubleSum = 0;
                int intSum = 0;

                foreach (string line in ConfigFileLines)
                {
                    string[] lineArray = line.Split(';');
                    foreach (string filename in lineArray)
                    {
                        if (filename != "")
                        {
                            Console.WriteLine("loading " + filename + "...");
                            BinFileReader.ReadBinFile(filename, IntTree, DoubleList);
                        }
                    }
                }

                foreach (double d in DoubleList)
                {
                    doubleSum += d;
                }
                foreach (int i in IntTree.GetValues())
                {
                    intSum += i;
                }
                Console.WriteLine("Der Durchschnitt der Double-Zahlen ist: " + (doubleSum / DoubleList.Count));
                Console.WriteLine("Der Durchschnitt der Int-Zahlen ist: " + ((double)intSum / IntTree.GetValues().Count));
            }
            catch(Exception ex)
            {
                ConsoleColor c = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fehler: " + ex.Message);
                Console.ForegroundColor = c;
            }
        }

   
    }
}

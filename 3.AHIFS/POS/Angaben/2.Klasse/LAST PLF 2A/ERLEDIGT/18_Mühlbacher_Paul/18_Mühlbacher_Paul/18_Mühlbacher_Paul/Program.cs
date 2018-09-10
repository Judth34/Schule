using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLFClassLibrary;

namespace _18_Mühlbacher_Paul
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IntAndDoubleFileLoader idfl = new IntAndDoubleFileLoader();
                List<string> l = idfl.GetFileNames("Filenames.config");

                Tree t;
                Tree bigTree = new Tree();

                List<double> doubleList;
                List<double> bigList = new List<double>();

                foreach (string s in l)
                {
                    t = idfl.SaveIntegersFromFileInTree(s);
                    doubleList = idfl.SaveDoublesFromFileInList(s);

                    foreach (int i in t.GetAllValues())
                    {
                        bigTree.Add(i);
                    }

                    foreach (double i in doubleList)
                    {
                        bigList.Add(i);
                    }
                }

                IntAndDoubleCalculator idc = new IntAndDoubleCalculator();

                Console.WriteLine("Average Int = " + idc.GetAverageOfIntegersFromTree(bigTree));
                Console.WriteLine("Average Double = " + idc.GetAverageOfDoublesFromList(bigList));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
    }
}

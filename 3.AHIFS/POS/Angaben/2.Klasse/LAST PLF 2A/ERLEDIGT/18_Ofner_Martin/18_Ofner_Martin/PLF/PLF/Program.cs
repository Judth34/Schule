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
            try
            {
                PersonenManagerLoader.PersonenManagerLoaderCSV myLoader = new PersonenManagerLoader.PersonenManagerLoaderCSV();
                PersonenManagerLoader.PersonenManagerLoaderBin myBinLoader = new PersonenManagerLoader.PersonenManagerLoaderBin();
                ///////Die NAmen der files bekommen//////
                string[] allfiles = myLoader.LoadCSVFile("Filenames.config");
                foreach(string s in allfiles)
                {
                    Console.WriteLine(s);
                }
                ////////Die einzelenen Files einlesen///////////////
                for (int Schleifenidx = 0; Schleifenidx < 3; Schleifenidx++)
                {
                    myBinLoader.LoadBinary(allfiles[Schleifenidx]);
                }
                //////////////////Den baum füllen//////////////////////

                // KAA: sehr schlechter Ansatz!!!
                Tree myT = new Tree();
                int idx = 0;
                int[] allInts= myBinLoader.allInts.ToArray();
                foreach(int n in allInts)
                {
                    myT.Append(allInts[idx]);
                        idx++;
                }

                ///Durchschnitt aller ints berechnen////////
                int sumofints = 0;
                List<int> allIntsValues = myT.GetValues();
                for (int idx4 = 0; idx4 < allIntsValues.Count; idx4++)
                {
                    sumofints = allIntsValues.ElementAt(idx4);
                }
                sumofints = sumofints / allIntsValues.Count;
                Console.WriteLine("Durchscnitt aller int Zahlen = "+sumofints);

                //////////////Durchschnitt aller doubles berechnen////////////////
                List<double> alldoublevalues = new List<double>();
                foreach(double d in myBinLoader.alldoubles)
                {
                    alldoublevalues.Add(d);
                }
                double sumofdouble = 0;

                for (int idx2 = 0 ; idx2 < alldoublevalues.Count; idx2++)
                {
                    sumofdouble = alldoublevalues.ElementAt(idx2);
                }
                sumofdouble = sumofdouble / alldoublevalues.Count;
                Console.WriteLine("Durchschnitt aller double elemente = "+ sumofdouble);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

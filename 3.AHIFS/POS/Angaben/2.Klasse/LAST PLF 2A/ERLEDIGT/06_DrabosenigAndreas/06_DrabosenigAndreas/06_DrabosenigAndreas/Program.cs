using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.IO;

namespace _06_DrabosenigAndreas
{
    class Program
    {
        static void Main(string[] args)
        {
            // KAA: Code-Struktur ist nicht ideal, aber Grundstruktur ist erkennbar; Baum fehlt vollkommen!
            try
            {
                BinaryTree bt = null;
                List<string> Filenames = new List<string>();
                double AverageDouble = 0;
                Filenames = getFileNames();
                AverageDouble =  Load(Filenames, bt);

                Console.WriteLine(AverageDouble);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // KAA: zentraler Fehler - Referenz nicht verstanden !!!
        static double Load(List<string> fileNames, BinaryTree bt)
        {
            bt = new BinaryTree();
            List<double> DoubleWerte = new List<double>();
            
                for (int i = 0; i < (fileNames.Count - 1); i++)
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileNames[i], FileMode.Open)))
                    {
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            bt.Add(reader.ReadInt32());
                            DoubleWerte.Add(reader.ReadDouble());
                        }
                    }
                }
            double AverageDouble = getAverageOfDouble(DoubleWerte);

            return AverageDouble;
        }

        static double getAverageOfDouble(List<double> Doublewerte)
        {
            double erg = 0;
            for (int i = 0; i < Doublewerte.Count; i++)
            {
                erg += Doublewerte[i];
            }
            double AverageOfDouble = erg / Doublewerte.Count;

            return AverageOfDouble;
        }

        static List<string> getFileNames()
        {
            string[] filenamesInArray = File.ReadAllLines(@"Filenames.config");
            string[] Split = null;
            List<string> FilenamesInList = new List<string>();
            for (int i = 0; i < filenamesInArray.Length; i++)
            {
                Split = filenamesInArray[i].Split(';');
            }
            for (int i = 0; i < Split.Length; i++)
            {
                FilenamesInList.Add(Split[i]);
            }

            return FilenamesInList;
        }
    }
}
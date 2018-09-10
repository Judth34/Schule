using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFKumnigLIB
{
    static public class MyLoader
    {
        public static string[] LoadCsvFile(string path)
        {
            StreamReader sr = null;
            List<string> texte = null;
            string zeile;
            string[] text = null;
            try
            {
                sr = new StreamReader(path);
                texte = new List<string>();

                while ((zeile = sr.ReadLine()) != null)
                {
                    text = zeile.Split(';');

                    for (int idx = 0; idx < text.Length - 1; idx++)
                    {
                        texte.Add(text[idx]);
                    }
                }
            }
            finally
            {
                sr.Close();
            }
            return texte.ToArray();
        }

        public static void LoadIntAndDouble(string[] filenames, MyTree mt, List<double> DoubleWerte)
        {
            foreach (string filename in filenames)
            {
                using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open)))
                {
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        // KAA: checken, ob die Werte richtig lesen werden 
                        int i = br.ReadInt32();
                        double d = br.ReadDouble();
                        Console.WriteLine(i);
                        Console.WriteLine(d);
                        mt.Appand(i);
                        // KAA: keine gute Idee hier Count unterzubringen!
                        mt.Count++;
                        DoubleWerte.Add(d);
                    }
                }
            }
        }

    }
}

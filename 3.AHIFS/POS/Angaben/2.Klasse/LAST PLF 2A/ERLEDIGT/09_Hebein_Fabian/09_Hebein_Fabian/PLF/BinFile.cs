using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF
{
    class BinFile
    {
        public static double[] getValues(string Filename)
        {
            double[] Werte = new double[100];   // KAA: Literal !!! - ganz schlechte Strategie int und double in einem Array unterzubringen!!! 

            int i = 0;

            using (BinaryReader br = new BinaryReader(File.Open(Filename, FileMode.Open)))
            {

                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    Werte[i] = br.ReadInt32();
                    i++;
                    Werte[i] = br.ReadDouble();
                    i++;
                }
            }
                return Werte;
        }
    }
}

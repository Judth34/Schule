using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PLFClassLibrary
{
    static public class BinFileReader
    {
        public static void ReadBinFile(string Filename, Tree IntegerTree, List<double> DoubleList)
        {
            bool isInteger = true;
            using (BinaryReader br = new BinaryReader(File.Open(Filename, FileMode.Open)))
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    if (isInteger)
                    {
                        //int i = br.ReadInt32();
                        //Console.WriteLine(i);
                        //it.Add(i);
                        IntegerTree.Add(br.ReadInt32());
                    }
                    else
                    {
                        DoubleList.Add(br.ReadDouble());
                    }
                    isInteger = !isInteger;
                }
            }
        }
    }
}

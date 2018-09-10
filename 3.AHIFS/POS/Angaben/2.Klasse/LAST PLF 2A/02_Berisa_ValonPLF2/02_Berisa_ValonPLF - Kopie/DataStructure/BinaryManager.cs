using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Berisa_ValonPLF
{
    public class BinaryManager
    {      
        public BinaryTree myTreefilledwithIntegers { get; private set; }
        public SimpleList mySimpleListfilledwithDoubles { get; private set; }

        public BinaryManager()
        {
            myTreefilledwithIntegers = new BinaryTree();
            mySimpleListfilledwithDoubles = new SimpleList();

        }
        public void LoadBinary(string[] filenames)
        {
            for (int indexOfFilename = 0; indexOfFilename < filenames.Length - 1; indexOfFilename++)
            {
                using (BinaryReader br = new BinaryReader(File.Open(filenames[indexOfFilename], FileMode.Open)))
                {
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        myTreefilledwithIntegers.Add(br.ReadInt32());
                        mySimpleListfilledwithDoubles.Append(Convert.ToString(br.ReadDouble()));
                    }
                }
            }

        }





    }
}

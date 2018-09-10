using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryFiles
{
    class Program
    {
        static string FileNameExample01 = @".\data\intArray.bin";
        static void Main(string[] args)
        {
            WriteIntArray_Ex01();
            // ReadIntArray_Ex01();
            ReadIntArray_Ex01Wrong();
            Console.WriteLine("Demo Program ended");
        }

        private static void WriteIntArray_Ex01()
        {
            using (BinaryWriter bw =
                new BinaryWriter(File.Open(FileNameExample01, FileMode.Create)))
            {
                int numberOfIntsToWrite = 5;
                for (int i = 0; i < numberOfIntsToWrite; i++)
                {
                    bw.Write(i * 1);
                }
            }

            // Das gleiche ohne Umsetzung mit using 

        }

        private static void ReadIntArray_Ex01Wrong()
        {
            using (BinaryReader br = new BinaryReader(File.Open(FileNameExample01, FileMode.Open)))
            {
                Console.WriteLine(br.ReadByte().ToString());
                Console.WriteLine(br.ReadInt32().ToString());
                Console.WriteLine(br.ReadInt32().ToString());
                Console.WriteLine(br.ReadInt32().ToString());
                Console.WriteLine(br.ReadInt32().ToString());
            }
        }
        private static void ReadIntArray_Ex01()
        {
            using (BinaryReader br = new BinaryReader(File.Open(FileNameExample01, FileMode.Open)))
            {
                // 2.
                // Position and length variables.
                int pos = 0;
                // 2A.
                // Use BaseStream.
                
                int length = (int)br.BaseStream.Length;
                while (pos < length)
                {
                    // 3.
                    // Read integer.
                    int v = br.ReadInt32();
                    Console.WriteLine(v);

                    // 4.
                    // Advance our position variable.
                    pos += sizeof(int);
                }
            }

            Console.WriteLine("\n\nEs folgt die Ausgabe mit int16!\n\n");
            using (BinaryReader br = new BinaryReader(File.Open(FileNameExample01, FileMode.Open)))
            {
                // 2.
                // Position and length variables.
                int pos = 0;
                // 2A.
                // Use BaseStream.
                int length = (int)br.BaseStream.Length;
                while (pos < length)
                {
                    // 3.
                    // Read integer.
                    int v = br.ReadInt16();
                    Console.WriteLine(v);

                    // 4.
                    // Advance our position variable.
                    pos += sizeof(Int16);
                }
            }
        }

        private static void CompleteExample()
        {
            BinaryWriter bw;
            BinaryReader br;
            int i = 25;
            double d = 3.14157;
            bool b = true;
            string s = "I am happy";

            //create the file
            try
            {
                bw = new BinaryWriter(new FileStream("mydata", FileMode.Create));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot create file.");
                return;
            }

            //writing into the file
            try
            {
                bw.Write(i);
                bw.Write(d);
                bw.Write(b);
                bw.Write(s);
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot write to file.");
                return;
            }
            bw.Close();

            //reading from the file
            try
            {
                br = new BinaryReader(new FileStream("mydata", FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot open file.");
                return;
            }
            try
            {
                i = br.ReadInt32();
                Console.WriteLine("Integer data: {0}", i);
                d = br.ReadDouble();
                Console.WriteLine("Double data: {0}", d);
                b = br.ReadBoolean();
                Console.WriteLine("Boolean data: {0}", b);
                s = br.ReadString();
                Console.WriteLine("String data: {0}", s);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot read from file.");
                return;
            }
            br.Close();

            Console.ReadKey();
        }

    }
}

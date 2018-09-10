using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileLoader
{
    public class FileLoaderBin : FileLoader
    {
        public FileLoaderBin(string Path) : base(Path)
        {

        }
        public void Load(Datastructures.SimpleList List, Datastructures.SimpleTree Tree)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(Path, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    Tree.AddValue(reader.ReadInt32());
                    List.Append(reader.ReadDouble());
                }
                reader.Close(); // KAA: nicht nötig bei using-clause!!
            }
        }
    }
}

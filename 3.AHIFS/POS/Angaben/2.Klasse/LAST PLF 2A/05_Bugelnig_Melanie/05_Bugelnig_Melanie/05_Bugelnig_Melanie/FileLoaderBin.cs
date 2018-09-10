using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _05_Bugelnig_Melanie
{
    class FileLoaderBin
    {
        public SimpleList AllValues = new SimpleList();
        public SimpleTree AllVal = new SimpleTree();
        public string Path;
        public FileLoaderBin(string Path)
        {
            this.Path = Path;
        }
        public List<int> LoadDouble()
        {
            Stream s = File.Open(Path, FileMode.Open);
            BinaryReader reader = new BinaryReader(s);
            

            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {

                AllValues.Append(reader.ReadInt32());
            }
            s.Close();
            reader.Close();

            return AllValues;
            
        }

        public List<int> LoadReadInt32()
        {
            Stream s = File.Open(Path, FileMode.Open);
            BinaryReader reader = new BinaryReader(s);


            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                AllVal.AddValue(reader.ReadDouble());
            }

            s.Close();
            reader.Close();

            return AllVal;
        }


    }
    }


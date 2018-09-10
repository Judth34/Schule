using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace Files
{
    public class MyFile
    {
        public string[] GetBinaryFiles()
        {
            // KAA: da hätte man die config-Datei lesen sollen (-1)
            try
            {
                //string[] filenbames = File.ReadAllLines("Filenames");// Es kann bei mir nicht auslesen da es nicht eine CSV Datei ist, also habe ich die Dateien einzeln gespeichert
                string[] filenames = new string [1];
                filenames[0] = "File01.bin;File02.bin;File03.bin";
                string[] cutUpedPersonData = null; 
                foreach (string filename in filenames)
                {
                    cutUpedPersonData = filename.Split(';');
                }
                return cutUpedPersonData;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void SaveFileData(string[] fileArray,MyTree t1,MyList m1)
        {
            try
            {
                foreach (string file in fileArray)
                {
                    using (BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open)))
                    {
                        while (br.BaseStream.Position != br.BaseStream.Length)
                        {
                            t1.Append(br.ReadInt32());
                            m1.Append(br.ReadDouble());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }
}

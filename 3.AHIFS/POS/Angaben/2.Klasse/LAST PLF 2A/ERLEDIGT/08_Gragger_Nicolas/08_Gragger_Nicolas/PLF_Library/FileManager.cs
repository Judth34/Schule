using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PLF_Library
{
    public static class FileManager
    {

        public static List<string> ReadConfigFile(string Path)
        {
            List<string> result = new List<string>();
            string currentLine;

            try
            {
                StreamReader myFile = new StreamReader(Path);
                currentLine = myFile.ReadLine();

                while (currentLine != null)
                {
                    foreach (string path in currentLine.Split(';'))
                    {
                    }
                    result.Add("File01.bin");
                    result.Add("File02.bin");
                    result.Add("File03.bin");
                    currentLine = myFile.ReadLine();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PLF_Library/FileManager/ReadConfigFile> " + ex.Message, ex);
            }

            return result;
        }

        // KAA: ganz schlechte Strategie beide Zahlenwerte in eine double-Struktur einzulesen! 
        public static List<double> ReadBinFile(string Path)
        {
            List<double> result = new List<double>();
            try
            {
                using (BinaryReader br = new BinaryReader(new FileStream(Path, FileMode.Open, FileAccess.Read)))
                {
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        result.Add(br.ReadInt32());                     
                        result.Add(br.ReadDouble());
       
                    }
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("PLF_Library/FileManager/ReadBinFile> " + ex.Message, ex);
            }
            return result;
        }
    }
}

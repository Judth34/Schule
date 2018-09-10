using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _05_Bugelnig_Melanie
{
    class FileLoaderTXT
    {
        string Filename = "config.txt";
        public string Path;
        public FileLoaderTXT(string Path)
        {
            this.Path = Path;
        }
        public List<string> Load()
        {
            List<string> AllValues = new List<string>();
            string[] Lines = File.ReadAllLines(Path);
            string line = "";

            using (StreamReader sr = new StreamReader(new FileStream(this.Filename, FileMode.Open)))
            {
                line = sr.ReadLine();
                string[] split = line.Split(';');
                AllValues.Add(line);
            }
            return AllValues;
        }


    }
}

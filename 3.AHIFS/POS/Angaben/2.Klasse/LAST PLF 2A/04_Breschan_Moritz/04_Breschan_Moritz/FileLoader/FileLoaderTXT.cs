using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileLoader
{
    public class FileLoaderTXT : FileLoader
    {
        public FileLoaderTXT(string Path) : base(Path)
        {

        }
        public List<string> Load()
        {
            List<string> AllValues = new List<string>();
            string[] Lines = File.ReadAllLines(Path);
            Lines = Lines[0].Split(';');
            AllValues = Lines.ToList<string>();
            return AllValues;
        }
    }
}

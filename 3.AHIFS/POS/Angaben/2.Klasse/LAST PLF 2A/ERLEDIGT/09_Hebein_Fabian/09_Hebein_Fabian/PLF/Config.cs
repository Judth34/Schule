using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF
{
    class Config
    {

        public static string[] getFiles(string path)
        {
            StreamReader myFile = new StreamReader(path);
            string[] Files = new string[3];

            string line;
            line = myFile.ReadLine();
            Files = line.Split(';');
            myFile.Close();

            return Files;
        }

    }
}

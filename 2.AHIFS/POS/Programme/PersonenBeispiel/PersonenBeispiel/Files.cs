using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonenBeispiel
{
    static class Files
    {
        public static void WriteLineLinePerLine(string Path, string[]People)
        {
            StreamWriter person = null;

            person = new StreamWriter(Path);

            foreach(string pupil in People)
            {
                person.WriteLine(pupil);
            }

            person.Close();
        }
    }
}

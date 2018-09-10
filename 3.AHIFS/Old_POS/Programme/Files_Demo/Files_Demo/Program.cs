using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            FilesDemo.PrintTextFile(@"d:\tmp\Textfile1.txt");            

            FilesDemo.WriteTectFileLinePerLine(@"Textfile1.csv", new string[] { "Hallo", "Mein", "Name", "ist", "Andreas"});

            FilesDemo.PrintTextFileLinePerLine(@"Textfile1.csv");
        }
    }
}

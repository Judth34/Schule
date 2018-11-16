using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Judth_Marcel_PLF01_Lib;

namespace Judth_Marcel_PLF01_console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> root = HtmlExplorer.GetHtmlStructure(@"..\..\..\Judth_Marcel_PLF01_Lib\Html\Template.html");

            foreach(string s in root)
            {
                Console.WriteLine(s);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWAtcher.Lib;

namespace CodeWatcher.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Codewatcher cw = new Codewatcher();
            cw.GenerateNewSite(@".\Template.html", @".\Namen.csv");
        }
    }
}

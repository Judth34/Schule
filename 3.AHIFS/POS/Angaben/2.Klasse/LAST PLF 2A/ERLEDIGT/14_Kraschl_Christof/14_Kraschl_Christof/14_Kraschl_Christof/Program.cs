using Durchschnittsberechnung;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Kraschl_Christof
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] toReadFiles = Files.GetToReadFilesFromTxtFile("Filenames.config");

                Console.WriteLine("Durchschnitt Tree (int): " + TreeBerechnung.Durchschnitt(Files.LoadIntsToBinaryTree(toReadFiles)));
                Console.WriteLine("Durchschnitt Baum (double): " + ListBerechnung.Durchschnitt(Files.LoadDoublesToSimpleList(toReadFiles)));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Fehlermeldung: " + ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PLF_LIB;

namespace ConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleList L;
            SimpleTree T;
            string Path = @"config.txt";
            Loader Loader = new Loader();

            try
            {
                //Laden
                Loader.Filename = Path;
                Loader.LoadAllTreesAndLists(out T, out L);
                Console.WriteLine("Laden abgeschlossen!");

                //Ausgabe
                Console.WriteLine("Durchschnitt des Baums: " + T.getAverage());
                Console.WriteLine("Durchschnitt der Liste: " + L.getAverage());
            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Laden der Files: " + ex.Message);
            }
        }
    }
}

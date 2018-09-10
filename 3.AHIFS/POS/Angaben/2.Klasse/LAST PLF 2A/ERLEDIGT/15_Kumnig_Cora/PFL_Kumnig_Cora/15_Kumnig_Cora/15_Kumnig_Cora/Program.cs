using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLFKumnigLIB;

namespace _15_Kumnig_Cora
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<double> doubleWerte = new List<double>();
                MyTree newMT = new MyTree();
                string[] filenames;
                filenames = MyLoader.LoadCsvFile("Filenames.config");
                MyLoader.LoadIntAndDouble(filenames, newMT, doubleWerte);

                float durchschnittBaum = newMT.GetDurchschnittTree();
                Console.WriteLine("Durchschnitt des Baumes: "+ durchschnittBaum);

                float durchschnittListe = List.GetDurchschnittList(doubleWerte);
                Console.WriteLine("Durchschnitt der Liste: "+ durchschnittListe);
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace _20_Rajic_Kristian
{
    // KAA: Programmlogik in einigen Teilen nicht unmittelbar nachvollziehbar!
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // KAA: 
                FileReader MyFileReader = new FileReader("Filenames.txt");
                // KAA: Gesamtablauf hier im Main nicht gut gelöst
                MyFileReader.ReadAnSaveFiles();

                Console.WriteLine(MyFileReader.getDurchschnittInList());

                Console.WriteLine(MyFileReader.GetDurchschnittInTree());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

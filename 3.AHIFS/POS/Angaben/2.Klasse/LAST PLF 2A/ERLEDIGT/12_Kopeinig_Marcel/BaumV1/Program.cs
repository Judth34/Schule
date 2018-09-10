using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaumV1
{
    // KAA: Programm kompiliert nicht - Projekttrennung ist nicht in Ordnung - Ablauflogik nicht nachvollziehbar - sehr viel "sinnloser" Code, 
    //      der nicht zur Lösung beiträgt 
    // Eindeutig: Nicht Genügend!

    class Program
    {
        static void Main(string[] args)
        {
            SimpleTree s = new SimpleTree();

            s = s.Load("Lines.txt");
            try
            {
                s.Add(6); }
            catch (Exception Ex)
            { Console.WriteLine(Ex.Message); }
                
            s.search(222);

            List<double> liste = s.printall();
            foreach (double l in liste)
            { Console.Write(l + " "); }
            
        }
    }
}

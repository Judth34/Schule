using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlinkte_Liste
{
    static class TestCases
    {
        /// <summary>
        /// Testet ob die Eigenschaft Count funktioniert
        /// </summary>
        /// <returns>Testfall-Ergebnis</returns>
        public static bool TestCount()
        {
            //TestStartegie 
            //a) Leere liste count == 0
            //b) Liste füllen Count == Anzahl der Element
            //c) 

            bool resultat = false;
            SimpleList s = new SimpleList();


            try
            {

                resultat = (s.Count() == 0);


                if (resultat == true)
                {
                    Random random = new Random();
                    int numberOfElements = random.Next(100, 1000);

                    for (int idx = 0; idx < numberOfElements; idx++)
                    {
                        s.Append("value" + idx);
                    }

                    resultat = (s.Count() == numberOfElements);

                    if (resultat == true)
                    {
                        int numberOfElementsToRemove = numberOfElements / 2;

                        for (int idx = 0; idx < numberOfElementsToRemove; idx++)
                        {
                            s.DeleteNode(0);
                        }
                        resultat = (s.Count() == (numberOfElements - numberOfElementsToRemove));
                    }
                }
            }
            catch(Exception myEx)
            {
                Console.WriteLine("Falsch" + myEx.Message);
            }
            return resultat;
        }

        public static bool TestGetAValueAt()
        {
            bool resultat = false;
            SimpleList s = new SimpleList();
            Random random = new Random();
            int numberOfElements = random.Next(10, 10000);
            string[]  alleElements = new string[numberOfElements];

            for(int idx = 0; idx < numberOfElements; idx++)
            {
                alleElements[idx] = "value" + idx;
                s.Append("value" + idx);
            }

            for (int idx = 0; (idx < numberOfElements); idx++)
            {
                if(s.GetValueAt(idx) == alleElements[idx])
                {
                    resultat = true;
                }
            }
            return resultat;
        }
    }
}
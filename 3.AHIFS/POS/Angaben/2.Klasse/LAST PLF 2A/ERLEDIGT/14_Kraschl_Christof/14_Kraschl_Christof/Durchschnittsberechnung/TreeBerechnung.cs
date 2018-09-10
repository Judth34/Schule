using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durchschnittsberechnung
{
    public static class TreeBerechnung
    {
        // KAA: nicht effizient das zweimal durchzumachen
        public static double Durchschnitt(BinarySearchTree myTree)
        {
            int[] ints = myTree.GetAllValues();
            int erg = 0;

            foreach(int i in ints)
            {
                erg += i;
            }
            return (double)erg / ints.Length;
        }
    }
}

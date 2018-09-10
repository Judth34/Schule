using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durchschnittsberechnung
{
    public static class ListBerechnung
    {
        public static double Durchschnitt(SimpleList myList)
        {
            double erg = 0;
            double[] doubles = myList.GetValues();

            foreach(double d in doubles)
            {
                erg += d;
            }
            return erg / doubles.Length;
        }
    }
}

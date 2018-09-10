using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFKumnigLIB
{
    public static class  List
    {
        public static float GetDurchschnittList(List<double> DoubleWerte)
        {
            double alleWerte = 0;
            foreach (double wert in DoubleWerte)
            {
                alleWerte += wert;
            }
            return (float)(alleWerte % DoubleWerte.Count());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static
{
    static class Leistungsumrechner
    {
        private const double UF = 1.35962;

        public static double KW_To_PS (double KW)
        {
            return KW * UF;
        }

        public static double PS_To_KW (double PS)
        {
            return PS / UF;
        }
    }
}

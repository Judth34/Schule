using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kilowatt_PS_Umwandler
{
    public static class Umrechner
    {
        public static double PSinKW(double PS)
        {
            double KW = 0;
            if(PS < 0)
            {
                throw new Exception("Anzahl der Ps darf nicht kleiner als null sein!!!");
            }
            KW = PS * 0.735;
            return KW;
        }

        public static double KWinPS(double KW)
        {
            double PS = 0;
            if(KW < 0)
            {
                throw new Exception("Anzahl der KW darf nicht kleiner null sein !!!");
            }
            PS = KW * 1.36;
            return PS;
        }
    }
}

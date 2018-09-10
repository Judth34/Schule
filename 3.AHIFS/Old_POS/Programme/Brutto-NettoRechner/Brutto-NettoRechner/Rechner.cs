using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brutto_NettoRechner
{
    static class Rechner
    {
        #region Eigenschaften
        private static int asvgBmg = 4650;
        private static int[] LstGrenzen = new int[3];
        private static double[] LstProzente = new double[4];
        #endregion

        #region Öffentliche Methoden
        public static double BruttoInNetto(double BruttoImMonat, int Auswahl)
        {
            #region Abzug des SV
            if (Auswahl == 0)   //Ngestellter
            {
                if (BruttoImMonat > asvgBmg)
                {
                    abzugDesSVAsvgBmgAngestellter(ref BruttoImMonat);
                }
                else
                {
                    abzugDesSVAngestellter(ref BruttoImMonat);
                }
            }
            else
            {
                if (Auswahl == 1)   //Arbeiter
                {
                    if (BruttoImMonat > asvgBmg)
                    {
                        abzugDesSVAsvgBmgArbeiter(ref BruttoImMonat);
                    }
                    else
                    {
                        abzugDesSVArbeiter(ref BruttoImMonat);
                    }
                }
            }
            #endregion

            #region Abzug derLst
            abzugDerLohnsteuer(ref BruttoImMonat);
            #endregion

            return BruttoImMonat;
        }
        #endregion

        #region Private Methoden

        private static double[] zuweisungDerLstProzente(double[] lstProzente)
        {
            lstProzente[0] = 0;
            lstProzente[1] = 0.365;
            lstProzente[2] = 0.432;
            lstProzente[3] = 0.5;

            return lstProzente;
        }

        private static int[] zuweisungDerLstGrenzen(int [] LstGrenzen)
        {
            LstGrenzen[0] = 11000;
            LstGrenzen[1] = 25000;
            LstGrenzen[2] = 60000;
            return LstGrenzen;
        }
        
        #region Abzug der SV
        private static void abzugDesSVAsvgBmgAngestellter(ref double bruttoImMonat)
        {
            const double AngestellterSV = 0.1807;
            bruttoImMonat = bruttoImMonat - (asvgBmg * AngestellterSV);
        }

        private static void abzugDesSVAsvgBmgArbeiter(ref double bruttoImMonat)
        {
            const double ArbeiterSV = 0.182;
            bruttoImMonat = bruttoImMonat - (asvgBmg * ArbeiterSV);
        }

        private static void abzugDesSVArbeiter(ref double BruttoImMonat)
        {
            const double ArbeiterSV = 0.182;
            BruttoImMonat = BruttoImMonat - (BruttoImMonat * ArbeiterSV);
        }

        private static void abzugDesSVAngestellter(ref double BruttoImMonat)
        {
            const double AngestellterSV = 0.1807;
            BruttoImMonat = BruttoImMonat - (BruttoImMonat * AngestellterSV);
        }
        #endregion

        private static void abzugDerLohnsteuer(ref double BruttoImMonat)
        {
            int Gehaelter = 14;
            double BruttoImJahr = 0;
            double Lst = 0;
            
            zuweisungDerLstGrenzen(LstGrenzen);
            zuweisungDerLstProzente(LstProzente);
            BruttoImJahr = BruttoImMonat * Gehaelter;

            if (BruttoImJahr > LstGrenzen[0] && BruttoImJahr < LstGrenzen[1])
            {
                Lst = (BruttoImJahr - LstGrenzen[0]) * LstProzente[0];
            }
            else
            {
                if(BruttoImJahr > LstGrenzen[1] && BruttoImJahr < LstGrenzen[2])
                {
                    Lst = (5110) + ((BruttoImJahr - LstGrenzen[1]) * (LstProzente[2]));
                }
                else
                {
                    if(BruttoImJahr > LstGrenzen[2])
                    {
                        Lst = ((BruttoImJahr - LstGrenzen[2]) * (LstProzente[3])) + 20235;
                    }
                }
            }    
                    
            BruttoImJahr = BruttoImJahr - Lst;
            BruttoImMonat = BruttoImJahr / Gehaelter;
        }
        #endregion
    }
}

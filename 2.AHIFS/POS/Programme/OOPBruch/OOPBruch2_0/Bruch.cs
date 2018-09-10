using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBruch2_0
{
    class Bruch
    {
        #region Daten und Eigenschaften
        int zaehler;
        int nenner;
        #endregion

        #region Konstruktor(en)
        public Bruch()
        {
            zaehler = 1;
            nenner = 1;
        }
        #endregion

        #region Properties
        public int Zaehler
        {
            set
            {
                zaehler = value;
                //kuerzen();
            }

            get
            {
                return zaehler;
            }
        }

        public int Nenner
        {
            set
            {
                if (value > 0)
                {
                    nenner = value;
                }
                else
                {
                  throw new Exception("Der Nenner darf nicht 0 sein!!!");
                }
            }

            get
            {
                return nenner;
            }
        }

        public double Zahl
        {
            get
            {
                return (double)zaehler / (double)nenner;
            }            
        }
        #endregion

        #region öffentliche Methoden
        public void addiere(Bruch summand)
        {
            int Nenner = nenner;
            if (nenner != summand.nenner)
            {
                zaehler *= summand.nenner;
                nenner *= summand.nenner;

                summand.zaehler *= Nenner;
                summand.nenner *= Nenner;

                zaehler += summand.zaehler;
            }
            else
            {
                zaehler += summand.zaehler;
            }
           
                kuerzen();
        }

        public void subtrahiere(Bruch subtrahend)
        {
            int Nenner = nenner;

            if (Nenner != subtrahend.nenner)
            {
                nenner *= subtrahend.nenner;
                zaehler *= subtrahend.nenner;

                subtrahend.zaehler *= Nenner;
                subtrahend.nenner *= Nenner;

                zaehler -= subtrahend.zaehler;
            }
            else
            {
                zaehler -= subtrahend.zaehler;
            }
            kuerzen();
        }

        public void multipliziere(Bruch multiplikator)
        {
            zaehler *= multiplikator.zaehler;
            nenner *= multiplikator.nenner;
            kuerzen();
        }

        public void dividiere(Bruch dividend)
        {
            int hilfsvariable = 0;

            hilfsvariable = zaehler;
            zaehler = nenner;
            nenner = hilfsvariable;

            multipliziere(dividend);
        }

        public string GanzerBruch()
        {
            return zaehler + " / " + nenner;
        }
        #endregion

        #region private Methoden
        void kuerzen()
        {
            int ggt = 0;
            ggt = GroeßterGemeinsamerTeiler();

            zaehler = zaehler / ggt;
            nenner = nenner / ggt;
        }

        int GroeßterGemeinsamerTeiler()
        {
            int GGT = 0;
            int erg = 0;
            int Nenner = nenner;
            int Zaehler = zaehler;
          
            #region GGT wenn Nenner > Zaheler
            if (Nenner > Zaehler)
            {
                do
                {
                    erg = Nenner - Zaehler;

                    if (Zaehler < erg)
                    {
                        Nenner = erg;
                    }

                    if (Zaehler > erg)
                    {
                        Nenner = Zaehler;
                        Zaehler = erg;
                    }

                    if (Nenner - Zaehler == Zaehler)
                    {
                        Nenner = erg;
                    }
                    GGT = Nenner;
                } while (erg != 0);
            }
            #endregion

            #region GGT wenn Nenner < Zaehler
            if (Nenner < Zaehler)
            {
                do
                {
                    erg = Zaehler - Nenner;

                    if (Nenner < erg)
                    {
                        Zaehler = erg;
                    }

                    if (Nenner > erg)
                    {
                        Zaehler = Nenner;
                        Nenner = erg;
                    }

                    if (Zaehler - Nenner == Nenner)
                    {
                        Zaehler = erg;
                    }
                    GGT = Zaehler;
                } while (erg != 0);
            }
            #endregion

            #region GGT wenn Nenner == Zaehler
            if (Nenner == Zaehler)
            {
                GGT = Nenner;
            }
            #endregion

            return GGT;
        }
        #endregion

        #region Destructor
        ~Bruch()
        {
           
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    class Rechner
    {
        enum Operation { Add, Sub, Mul, Div };
        const int defaultValue = 1;   // Standardwert
        public static int instanceCounter = 0;

        #region privates
        private Operation LetzteOperation;
        private double resultat;
        #endregion

        #region public fields and properties
        public int Zahl1;
        public int Zahl2;

        public double Resultat
        {
            private set
            {
                resultat = value;
            }
            get
            {
                return CheckAndReturnResultat();
            }
        }

        public static int InstanceCounter { get { return instanceCounter; } }
        #endregion

        #region constructor(s)
        public Rechner()
        {
            Zahl1 = defaultValue;
            Zahl2 = defaultValue;
            instanceCounter++;
        }
        public Rechner(int Zahl1)
        {
            this.Zahl1 = Zahl1;
            Zahl2 = defaultValue;
            instanceCounter++;
        }

        public Rechner(int Zahl1, int Zahl2)
        {
            this.Zahl1 = Zahl1;
            this.Zahl2 = Zahl2;
            instanceCounter++;
        }
        #endregion

        #region public methods
        public void Addiere()
        {
            Resultat = Zahl1 + Zahl2;
            LetzteOperation = Operation.Add;
        }

        public void Subtrahiere()
        {
            Resultat = Zahl1 - Zahl2;
            LetzteOperation = Operation.Sub;
        }

        public void Multipliziere()
        {
            Resultat = Zahl1 * Zahl2;
            LetzteOperation = Operation.Mul;
        }

        public void Dividiere()
        {
            Resultat = Zahl1 / Zahl2;
            LetzteOperation = Operation.Div;
        }
        #endregion

        #region private methods
        private double CheckAndReturnResultat()
        {
            double erwartetesResultat = 0;
            switch (LetzteOperation)
            {
                case Operation.Add:
                    erwartetesResultat = Zahl1 + Zahl2;
                    break;
                case Operation.Sub:
                    erwartetesResultat = Zahl1 - Zahl2;
                    break;
                case Operation.Mul:
                    erwartetesResultat = Zahl1 * Zahl2;
                    break;
                case Operation.Div:
                    erwartetesResultat = Zahl1 / Zahl2;
                    break;
                default:
                    throw new Exception("Unbekannte Operation");
            }
            if (erwartetesResultat != resultat)
            {
                throw new Exception("Achtung: Operanden wurden im nachhinein verändert!");
            }
            return resultat;
        }
        #endregion
    }
}

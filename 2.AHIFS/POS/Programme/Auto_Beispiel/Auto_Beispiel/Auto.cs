using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Beispiel
{
    class Auto
    {
        #region Daten und Eigenschaften
        private bool  motor;
        private bool faehrt;
        #endregion

        #region Konstruktor
        public Auto(bool Motor, bool Faehrt)
        {
            this.motor = Motor;
            this.faehrt = Faehrt;
        }
        #endregion

        #region Getter
        public bool GetMotor()
        {
            return motor;
        }

        public bool GetFaehrt()
        {
            return faehrt;
        }
        #endregion

        #region öffentliche Methoden
        public void anstarten()
        {
            motor = true;
            faehrt = false;
            Console.WriteLine("Motor ein: " + motor + "\nAuto faehrt: " + faehrt);
        }

        public void abstellen()
        {
            motor = false;
            faehrt = false;
            Console.WriteLine("Motor ein: " + motor + "\nAuto faehrt: " + faehrt);
        }

        public void anfahren()
        {
            motor = true;
            faehrt = true;
            Console.WriteLine("Motor ein: " + motor + "\nAuto faehrt: " + faehrt);
        }

        public void anhalten()
        {
            motor = true;
            faehrt = false;
            Console.WriteLine("Motor ein: " + motor + "\nAuto faehrt: " + faehrt);
        }
        #endregion

        #region Destruktor
        ~Auto()
        {

        }
        #endregion
    }
}

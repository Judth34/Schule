using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personen_Manager
{
    class Vorgesetzter : Mitarbeiter
    {
        #region Properties
        public double Prämie { get; }
        #endregion

        #region Konstruktor(en)
        public Vorgesetzter(string Name, string MitarbeiterNr, double Prämie) : base(Name, MitarbeiterNr)
        {
            this.Prämie = Prämie;
            PersonenTyp = "V";
        }

        public Vorgesetzter(string PersonenTyp, string Name, string MitarbeiterNr, double Prämie) : base(PersonenTyp ,Name, MitarbeiterNr)
        {
            this.Prämie = Prämie;
        }
        #endregion

        public override string toString()
        {
            return base.toString() + Prämie + " ";
        }

        public override string ToStringCSV()
        {
            return "V;" +  ToCSVWithoutType() + Prämie;
        }

        public override string toPraemie()
        {
            return Convert.ToString(Prämie);
        }
    }
}

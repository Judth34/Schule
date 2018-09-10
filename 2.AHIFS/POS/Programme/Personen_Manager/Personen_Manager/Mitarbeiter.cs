using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personen_Manager
{
    class Mitarbeiter : Person
    {
        #region Properties
        public string MitarbeiterNr { get; }
        #endregion

        #region Konstruktor(en)
        public Mitarbeiter(string PersonenTyp ,string Name, string MitarbeiterNr) : base(PersonenTyp ,Name)
        {
            this.MitarbeiterNr = MitarbeiterNr;
        }

        public Mitarbeiter(string Name, string MitarbeiterNr) : base(Name)
        {
            this.MitarbeiterNr = MitarbeiterNr;
            PersonenTyp = "M";

        }
        #endregion

        public override string toString()
        {
            return base.toString() + toMitarbeiternummer() + " ";
        }

        public override string ToStringCSV()
        {
            return "M;" + ToCSVWithoutType();
        }

        protected string ToCSVWithoutType()
        {
            return base.ToStringCSV() + MitarbeiterNr + ";";
        }

        override public string toMitarbeiternummer()
        {
            return MitarbeiterNr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personen_Manager
{
    abstract class Person
    {
        #region Properties
        public string Name { get; }

        public string PersonenTyp { get; set; }
        #endregion

        #region Konstruktor(en)
        public Person(string Name)
        {
            this.Name = Name;
        }

        public Person(string PersonenTyp, string Name)
        {
            this.Name = Name;
            this.PersonenTyp = PersonenTyp;
        }
        #endregion

        public virtual string toString()
        {
            return PersonenTyp + " " + Name + " ";
        }

        public virtual string ToStringCSV()
        {
            return Name + ";";
        }

        virtual public string toPraemie()
        {
            return "";
        }

        virtual public string toMitarbeiternummer()
        {
            return "";
        }
    }
}

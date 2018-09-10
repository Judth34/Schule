using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personen_Manager
{
    class PersonenManager
    {
        #region Eignschaften
        private List<Person> allePersonen = new List<Person>();
        #endregion

        public void AddPerson(Person p)
        {
            allePersonen.Add(p);
        }

        public void PrintAll()
        {
            foreach(Person p in allePersonen)
            {
                Console.WriteLine(p.toString());
            }
        }

        public IList<Person> PersonenReadOnly()
        {
            return allePersonen.AsReadOnly();
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableProjectLIB
{
    public class HashTable
    {
        private int ASVGNr;

        private int[] persons;

        public HashTable(int personsSize, int aSVGNr)
        {
            persons = new int[personsSize];
        }

        public void AddPerson()
        {
            int key = 0;
            key = ASVGNr % persons.Count();

            while(persons[key] != null)
            {
                key++;
            }
            persons[key] = ASVGNr;
        }

        public void FindPerson()
        {

        }
    }
}

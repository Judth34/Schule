using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTableProjectLIB;

namespace HashTableProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                HashTable ht = new HashTable(700, 1234050698);
                ht.AddPerson();                
            }
            catch(Exception ex)
            {

            }
            
            
        }
    }
}

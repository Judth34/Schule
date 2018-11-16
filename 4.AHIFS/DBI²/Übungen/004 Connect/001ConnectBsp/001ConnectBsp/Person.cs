using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001ConnectBsp
{
    public class Person
    {
        public decimal nr { get; set; }
        public string Name { get; set; }
        public DateTime date { get; set; }
        public decimal gehalt { get; set; }

        public Person(decimal nr, string name, DateTime date, decimal gehalt)
        {
            this.nr = nr;
            this.Name = name;
            this.date = date;
            this.gehalt = gehalt;
        }

        override
        public string ToString()
        {
            return nr + " " + Name + " " + date.ToString() + " " + gehalt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PupilSorterLIB
{
    public class Schueler
    {
        public string Account { get; private set; }

        public string Name { get; private set; }

        public string Firstname { get; private set; }

        public string Gender { get; private set; }

        public string Klasse { get; private set; }

        public Schueler(string account, string name, string vorname, string gender, string klasse)
        {
            Account = account;
            Name = name;
            Firstname = vorname;
            Gender = gender;
            Klasse = klasse;
        }
    }
}

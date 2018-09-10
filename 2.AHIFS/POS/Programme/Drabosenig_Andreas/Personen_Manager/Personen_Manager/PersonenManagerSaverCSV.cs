using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personen_Manager
{
    class PersonenManagerSaverCSV : PersonenManagerSaver
    {
        public override PersonenManager Load()
        {
            PersonenManager pm = new PersonenManager();
            string[] persons = File.ReadAllLines(Filename);
            pm = StringToList(persons, pm);
            return pm;
        }

        private PersonenManager StringToList(string[] personen, PersonenManager pm)
        {           
            for (int i = 0; i < personen.Length; i++)
            {
                string[] Split = null;
                Split = personen[i].Split(';');
                
                switch (Split[0])
                {
                    case "M":                        
                        if (Split[3] != "")
                        {
                            throw new Exception("Ein Mitarbeiter hat keine Prämie!!!");
                        }
                        pm.AddPerson(new Mitarbeiter(Split[0], Split[1], Split[2]));
                        break;

                    case "V":
                        if (Split[3] == "")
                        {
                            throw new Exception("Ein Vorgesetzter hat eine Prämie!!!");
                        }
                        pm.AddPerson(new Vorgesetzter(Split[0] ,Split[1], Split[2], Convert.ToDouble(Split[3])));
                        break;
                }
            }
            return pm;
        }

        public override void Save(PersonenManager pm)
        {
            StreamWriter filewriter = null;
            try
            {
                filewriter = new StreamWriter(Filename);
                
                foreach (Person p in pm.PersonenReadOnly())
                {
                    filewriter.WriteLine(p.ToStringCSV());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler im WriteLine", ex);
            }
            finally
            {
                if (filewriter != null)
                    filewriter.Close();
            }
        }
    }
}

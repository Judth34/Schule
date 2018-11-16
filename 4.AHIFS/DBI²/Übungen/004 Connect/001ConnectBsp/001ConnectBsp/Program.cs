using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001ConnectBsp
{
    class Program
    {
        static Database db = new Database();
        static void Main(string[] args)
        {
            db.Connect();
            db.update_Person("update person set name = 'Marcel Judth' where nr = 2");

            printPersons();

            db.delete_Person("delete from person where nr = '1'");

            printPersons();

            db.insert_Person("insert into person values(1, 'Julian Blaschke', to_date('01-JAN-1998', 'DD-MON-YYYY'), 900)");

            printPersons();
        }

        private static void printPersons()
        {
            List<Person> persons = db.get_Person("select * from person");
            List<string> headers = db.get_Headers("select * from person");

            foreach (string p in headers)
                Console.Write(p.ToString() + "\t");
            Console.WriteLine("");

            foreach (Person p in persons)
            {
                Console.Write(p.nr + "\t" + p.Name + "\t" + p.date + "\t" + p.gehalt);
                Console.WriteLine("");
            }

        }
    }
}

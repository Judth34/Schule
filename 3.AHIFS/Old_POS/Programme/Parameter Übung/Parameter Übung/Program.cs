using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameter_Übung
{
    class Program
    {
        static void Main(string[] args)
        {
            string Anrede= "Herr";
            string Titel= "Dr. Dipl.Ing ";
            string VorundNachname = "Bernd Holger";
            string Text = "Geht in die HTL Villach";

            Eingangsparameter(Anrede);
            Console.WriteLine(Anrede);

            Ausgangsparameter(out Titel);
            Console.WriteLine(Titel);

            Referenzparameter(ref VorundNachname);
            Console.WriteLine(VorundNachname);

            Mehrfachparameter(Text);
            Console.WriteLine(Text);
        }

        static void Eingangsparameter(string AndereAnrede)
        {
            AndereAnrede = "Frau";
        }

        static void Ausgangsparameter(out string AndererTitel)
        {
            AndererTitel = "Kein Titel";
        }

        static void Referenzparameter(ref string AndererVorundNachname)
        {
            AndererVorundNachname = "Andreas Drabosenig";
        }

        static string[] Mehrfachparameter(params string[] AndererText)
        {
            AndererText = ["Besucht die 2AHIFS in der HTL Villach";
            return AndererText;
        }
    }
}

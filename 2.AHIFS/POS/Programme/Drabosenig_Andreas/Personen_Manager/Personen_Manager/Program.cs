using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personen_Manager
{
    class Program
    {

        static void Main(string[] args)
        {
            PersonenManagerSaverBinary pmsb = null;
            PersonenManagerSaverCSV pmsc = null;
            PersonenManager pm = null;
            try
            {
                string FileTyp;
                string FileName;
                char AuswahlSave = ' ';
                pm = new PersonenManager();
                Person p = null;

                #region Auswahl ob Mitarbeiter oder Vorgesetzter
                char AuswahlPerson = ' ';
                int Anzahl = 0;
                AuswahlPerson = GetAValidChar('M', 'V', "Wollen Sie Mitarbeiter(M) oder Vorgesetzte(V) erzeugen!");

                switch (AuswahlPerson)
                {
                    case 'M':
                        Anzahl = GetAValidNumber(1, 10, "Wie viele Mitarbeiter wollen Sie erstellen?");
                        ErstellenVonMitarbeiter(Anzahl, pm);
                        break;

                    case 'V':
                        Anzahl = GetAValidNumber(1, 10, "Wie viele Vorgesetzte wollen Sie erstellen?");
                        ErstellenVonVorgesetzten(Anzahl, pm);
                        pm.AddPerson(p);
                        break;
                }
                #endregion

                #region Auswahl ob Binär oder in Csv Format Speichern
                AuswahlSave = GetAValidChar('B', 'C', "Wollen Sie Binär(B) oder im CSV(C) Format speichern? ");
                switch (AuswahlSave)
                {
                    case 'B':
                        pmsb = new PersonenManagerSaverBinary();
                        Console.WriteLine("Wie soll das File heißen: ");
                        FileTyp = ".txt";
                        FileName = Console.ReadLine();
                        pmsb.Filename = FileName + FileTyp;
                        pmsb.Save(pm);
                        pm = pmsb.Load();
                        pm.PrintAll();
                        break;

                    case 'C':
                        pmsc = new PersonenManagerSaverCSV();
                        Console.WriteLine("Wie soll das File heißen: ");
                        FileTyp = ".csv";
                        FileName = Console.ReadLine();
                        pmsc.Filename = FileName + FileTyp;
                        pmsc.Save(pm);
                        pm = pmsc.Load();
                        pm.PrintAll();
                        break;
                }
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void ErstellenVonVorgesetzten(int anzahl, PersonenManager pm)
        {
            Vorgesetzter V = null;
            int counter = 0;
            while (counter < anzahl)
            {
                V = new Vorgesetzter(GetName(), GetMitarbeiterNr(), getPrämie());
                pm.AddPerson(V);
                counter++;
            }
        }

        static double getPrämie()
        {
            double Prämie;
            double PrämieMin = 0;
            double PrämieMax = 100000;
            Prämie = GetAValidDouble(PrämieMin, PrämieMax, "Geben Sie die Prämie des Vorgesetzten ein: ");
            return Prämie;
        }

        static void ErstellenVonMitarbeiter(int anzahl, PersonenManager pm)
        {
            Mitarbeiter M = null;
            int counter = 0;
            while (counter < anzahl)
            {
                M = new Mitarbeiter(GetName(), GetMitarbeiterNr());
                pm.AddPerson(M);
                counter++;
            }
        }

        static string GetMitarbeiterNr()
        {
            string mitarbeiterNr = "";
            Console.Write("Geben Sie die Mitarbeiternummer ein:");
            mitarbeiterNr = Console.ReadLine();
            return mitarbeiterNr;
        }

        static string GetName()
        {
            string name = "";
            Console.Write("Geben Sie den Namen ein:");
            name = Console.ReadLine();
            return name;
        }

        static int GetAValidNumber(int Min, int Max, string Eingabe)
        {
            int i;
            bool result;

            do
            {
                Console.WriteLine(Eingabe);
                result = int.TryParse(Console.ReadLine(), out i);
                if (i < Min || i > Max || result == false)
                {
                    Console.WriteLine("Falsche Eingabe!!!\n");
                }
            } while (i < Min || i > Max || result == false);
            return i;
        }

        static double GetAValidDouble(double Min, double Max, string Eingabe)
        {
            double i;
            bool result;

            do
            {
                Console.WriteLine(Eingabe);
                result = double.TryParse(Console.ReadLine(), out i);
                if (i < Min || i > Max || result == false)
                {
                    Console.WriteLine("Falsche Eingabe!!!\n");
                }
            } while (i < Min || i > Max || result == false);
            return i;
        }

        static char GetAValidChar(char Mitarbeiter, char Vorgessetzter, string Eingabe)
        {
            char i;
            bool result;
            do
            {
                Console.WriteLine(Eingabe);
                result = char.TryParse(Console.ReadLine(), out i);
                i = Char.ToUpper(i);
                if (i < Mitarbeiter || i > Vorgessetzter || result == false)
                {
                    Console.WriteLine("Falsche Eingabe!!!\n");
                }
            } while (i < Mitarbeiter || i > Vorgessetzter || result == false);
            return i;
        }
    }
}
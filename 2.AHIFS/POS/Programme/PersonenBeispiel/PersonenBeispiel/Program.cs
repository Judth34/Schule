using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonenBeispiel
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("123405051965");
            p.Vorname = "Herbert";
            p.Nachname = "Prohaska";
            Console.WriteLine(p.Vorname + " " + p.Nachname + "\nASVG Nummer: " + p.ASVGNr);

            Console.WriteLine("\n");

            Schueler s = new Schueler("123404021999");
            s.Vorname = "Julian";
            s.Nachname = "Blaschke";
            s.Klasse = "2AHIFS";
            s.Katalognummer = 3;
            Console.WriteLine("Name: " + s.Vorname + " " + s.Nachname + "\nKlasse: " + s.Klasse + "\nKatalognummer: " + s.Katalognummer + "\nASVG Nummer: " + s.ASVGNr);

            Console.WriteLine("\n");

            Lehrer l = new Lehrer("123415111977");
            l.Vorname = "Gerhard";
            l.Nachname = "Egger";
            l.Kuerzel = "EGG";
            Console.WriteLine("Name: " + l.Vorname + " " + l.Nachname + "\nKuerzel: " + l.Kuerzel + "\nASVG Nummer: " + l.ASVGNr);

            Console.WriteLine("\n");

            Klassenvorstand kv = new Klassenvorstand("123402081966");
            kv.Vorname = "Heidrun";
            kv.Nachname = "Mueller-Stegmueller";
            kv.Kuerzel = "MUH";
            kv.Klasse = "2AHIFS";
            Console.WriteLine("Name: " + kv.Vorname + " " + kv.Nachname + "\nKlasse: " + kv.Klasse + "\nKuerzel: " + kv.Kuerzel + "\nASVG Nummer: " + kv.ASVGNr);

            Console.WriteLine("\n");

            Abteilungsvorstand av = new Abteilungsvorstand("123406061975");
            av.Vorname = "Karl-Heinz";
            av.Nachname = "Eder";
            av.Kuerzel = "EDK";
            av.Datum = "21.10.2005";
            Console.WriteLine("Name: " + av.Vorname + " " + av.Nachname + "\nKuerzel: " + av.Kuerzel + "\nDatum Managmentkurs: " + av.Datum + "\nASVG Nummer: " + av.ASVGNr);

            Files.WriteLineLinePerLine("Textfile.txt", new string[] { p.Vorname, p.Nachname, p.ASVGNr, s.Vorname, s.Nachname, s.ASVGNr, s.Klasse, l.Vorname, l.Nachname, l.ASVGNr, l.Kuerzel, kv.Vorname, kv.Nachname, kv.ASVGNr, kv.Klasse, kv.Kuerzel, av.Vorname, av.Nachname, av.ASVGNr, av.Datum, av.Kuerzel });
        }
    }
}
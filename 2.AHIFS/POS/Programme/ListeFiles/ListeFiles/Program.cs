using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ListeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.) Benutzer liest so viele Werte ein bis der Benutzer Ende eingibt
            // 2.) In ein Array speichern und sortieren
            // 3.) Nach jedem Wert ein Semikolon eingeben
            // 4.) Speichern
            string[] AllValues = null;

            EinfuegenInListe(ref AllValues);

            Ordnen(ref AllValues);
            
            WriteTextFileLinePerLine(@"Textfile1.csv", AllValues);
        }

        public static void EinfuegenInListe(ref string[] AllValues)
        {
            string eingabe = "";
            SimpleList s = new SimpleList();

            eingabe = Console.ReadLine();
            while (eingabe.ToUpper() != "ENDE") 
            {
                s.Append(eingabe);
                eingabe = Console.ReadLine();
            }  

            AllValues = s.GetValues();
        }

        public static void Ordnen(ref string[] data)
        {
            string hilfsvariable = "";
            for (int stackdurchgelaufen = 0; stackdurchgelaufen < (data.Length - 1); stackdurchgelaufen++)
            {
                for (int idx = 0; idx < (data.Length - 1); idx++)
                {
                    if (data[idx].CompareTo(data[(idx + 1)]) > 0)
                    {
                        hilfsvariable = data[idx];
                        data[idx] = data[(idx + 1)];
                        data[(idx + 1)] = hilfsvariable;
                    }
                }
            }
        }

        public static void WriteTextFileLinePerLine(string Path, string[] lines)
        {
            StreamWriter filewriter = null;

            try
            {
                filewriter = new StreamWriter(Path);

                foreach (string line in lines)
                {
                    filewriter.WriteLine(line + ";");
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
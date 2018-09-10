using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Files_Demo
{
    static class FilesDemo
    {
        public static void PrintTextFile(string Path)
        {
            try
            {
                string[] lines = File.ReadAllLines(Path);

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File wurde nicht gefunden");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unbekannter Fehler: " + ex.Message);
            }
        }

        public static void PrintTextFileLinePerLine(string Path)
        {
            //Algorithmus
            //1. File öffnen
            //2. Solange Files auslesen solange Zeilen im File vorhanden sind
            //  Diese Zeile sofort ausgeben 
            //3. File schliessen

            try
            {
                StreamReader myFile = new StreamReader(Path);

                string line = myFile.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = myFile.ReadLine();
                }

                myFile.Close();
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File wurde nicht gefunden");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unbekannter Fehler: " + ex.Message);
            }
        }

        public static void WriteTectFileLinePerLine(string Path, string[] lines)
        {
            //Algorithmus
            //1. File öffnen
            //2. Solange Files schreiben solange Zeilen im lines Array  sind
            //3. File schliessen

            StreamWriter filewriter = null;
            try
            {
                filewriter = new StreamWriter(Path);

                foreach (string line in lines)
                {
                    //Gleiche wie unten Console.WriteLine(line);
                    filewriter.WriteLine(line);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Fehler im WriteLine" , ex);
            }
            finally
            {
                if(filewriter != null)
                    filewriter.Close();
            }
        }
    }
}
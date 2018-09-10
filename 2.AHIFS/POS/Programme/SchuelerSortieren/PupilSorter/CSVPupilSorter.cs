using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PupilSorterLIB
{
    public class CSVPupilSorter
    {
        public string SourceFile { get; set; }
        public string TargetFile { get; set; }
        public enum SchuelerSortBy { Name, Firstname, Klasse }


        public void GenerateSortedFile(SchuelerSortBy Auswahl)
        {
            string[] allPupils;
            string[] allPupilsSorted;
            allPupils = PrintTextFileLinePerLine(SourceFile);
            List<Schueler> Pupils = SplitAndAddToList(allPupils);
            Pupils = SortList(Pupils, Auswahl);
            allPupilsSorted = InArray(Pupils);
            WriteTectFileLinePerLine(TargetFile, allPupilsSorted);
        }

        public static string[] InArray(List<Schueler> Pupils)
        {
            string[] PupilsSorted = new string[Pupils.Count];

            for (int idx = 0; idx < PupilsSorted.Length; idx++)
            {
                PupilsSorted[idx] = Pupils[idx].Account + ";" + Pupils[idx].Name + ";" + Pupils[idx].Firstname + ";" + Pupils[idx].Gender + ";" + Pupils[idx].Klasse + ";";
            }

            return PupilsSorted;
        }

        public static List<Schueler> SortList(List<Schueler> UnsortedPupils, SchuelerSortBy Auswahl)
        {
            bool isSorted;
            do
            {
                isSorted = false;
                for (int idx = 1; idx < (UnsortedPupils.Count - 1); idx++)
                {
                    if(Auswahl == SchuelerSortBy.Name)
                    {
                        if (UnsortedPupils[idx].Name.CompareTo(UnsortedPupils[(idx + 1)].Name) > 0)
                        {
                            swap(UnsortedPupils, idx);
                            isSorted = true;
                        }
                    }
                    else
                    {
                        if(Auswahl == SchuelerSortBy.Firstname)
                        {
                            if (UnsortedPupils[idx].Firstname.CompareTo(UnsortedPupils[(idx + 1)].Firstname) > 0)
                            {
                                swap(UnsortedPupils, idx);
                                isSorted = true;
                            }
                        }
                        else
                        {
                            if(Auswahl == SchuelerSortBy.Klasse)
                            {
                                if (UnsortedPupils[idx].Klasse.CompareTo(UnsortedPupils[(idx + 1)].Klasse) > 0)
                                {
                                    swap(UnsortedPupils, idx);
                                    isSorted = true;
                                }
                            }
                        }
                    }
                   
                }
            } while (isSorted);
            return UnsortedPupils;
        }

        private static List<Schueler> swap(List<Schueler> UnsortedPupils, int idx)
        {
            Schueler help = UnsortedPupils[(idx + 1)];
            UnsortedPupils[(idx + 1)] = UnsortedPupils[idx];
            UnsortedPupils[idx] = help;
            return UnsortedPupils;
        }

        public static List<Schueler> SplitAndAddToList(string[] lines)
        {
            string[] Split;
            List<Schueler> Pupils = new List<Schueler>();

            for (int i = 0; i < (lines.Length - 1); i++)
            {
                Split = lines[i].Split(';');
                Pupils.Add(new Schueler(Split[0], Split[1], Split[2], Split[3], Split[4]));
            }

            return Pupils;
        }

        public static string[] PrintTextFileLinePerLine(string Path)
        {
            string[] allPupils = null;
            try
            {
                int capacity = 297;
                int counter = 0;
                StreamReader myFile = new StreamReader(Path);



                allPupils = new string[capacity];

                while (counter < allPupils.Length)
                {
                    allPupils[counter] = myFile.ReadLine();
                    counter++;
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

            return allPupils;
        }

        public static void WriteTectFileLinePerLine(string Path, string[] lines)
        {
            StreamWriter filewriter = null;

            try
            {
                filewriter = new StreamWriter(Path);

                foreach (string line in lines)
                {
                    filewriter.WriteLine(line);
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

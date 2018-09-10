using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PLF
{
    class PersonenManagerLoader
    {

       
        public List<int> allInts = new List<int>();
        public List<double> alldoubles = new List<double>();

        public class PersonenManagerLoaderCSV : PersonenManagerLoader
        {

            public string[] LoadCSVFile(string SourceFile)
            {
                StreamReader myReader = null;
                List<string> FileListe = new List<string>();
                string[] daten = null;
                try
                {
                    daten = File.ReadAllLines(SourceFile);

                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File wurde nicht gefunden");
                }
                catch (Exception)
                {
                    Console.WriteLine("Unbekannter Fehler");
                }
                finally
                {
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                }
                daten = split(daten);
                return daten;
            }
            public string[] split(string[] data)
            {
                string[] splittedData = null;
                for (int Idx = 0; Idx < data.Length; Idx++)
                {
                    splittedData = data[Idx].Split(';');
                    
                }
                return splittedData;
            }
        }
            public class PersonenManagerLoaderBin : PersonenManagerLoader
            {

                // KAA: Methode sinnlos
                public void LoadBinary(string path)
                {
                    GetAllTextFilesBin(path);
                }

                private void GetAllTextFilesBin(string SourceFile)
                {
                BinaryReader reader = new BinaryReader(File.Open(SourceFile, FileMode.Open));
                {
                    int intValue = 0;
                    double doubleValue = 0;

                    // KAA: in Listen zu laden ist ineffizient
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                        intValue = reader.ReadInt32();
                        doubleValue = reader.ReadDouble();
                        allInts.Add(intValue);
                        alldoubles.Add(doubleValue);

                        }
                    }
                }
            }
        }

      
    }

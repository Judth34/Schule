using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLernen
{
    class Program
    {
       static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch(); stopWatch.Start();
            List<int> Zahlen = Y(100);
            //Zahlen.ForEach(Console.WriteLine);
            CreateCSVFile(@"RandomNumbers.csv", Zahlen);
            List<string> ZahlenString = PrintTextFileLinePerLine(@"RandomNumbers.csv");
            List<int> listOfInts = ZahlenString.Select<string, int>(q => Convert.ToInt32(q));
            
            BinaryTree bt = new BinaryTree();
            foreach (int i in listOfInts)
            {
                bt.Add(i);
            }
            List<int> BinaryDataList = bt.PutBinaryTreeDataInList();
            BinaryDataList.ForEach(Console.WriteLine);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("DataFile successfully generated(with List). It took {0} milliseconds", ts);
        }

       static public List<int> Y(int NumberElements)
        {
            Random r = new Random();
            HashSet<int> _usedNumbers = new HashSet<int>();
            List<int> Zahlen = new List<int>();
            for (int i = 0; i < NumberElements; i++)
            {
                Zahlen.Add(GenerateNumber(_usedNumbers, NumberElements,r));
            }

            return Zahlen;
        }

      static  public int GenerateNumber(HashSet<int> _usedNumbers, int NumberElements, Random r)
        {
            int num = r.Next(1, (NumberElements + 1));

            if (_usedNumbers.Count == NumberElements)
                throw new Exception("I ran out of numbers :(");

            while (_usedNumbers.Add(num) == false) 
            {
                num = r.Next(1, (NumberElements + 1));
            }

            return num;
        }

        public static void CreateCSVFile(string Path,List<int> lines)
        {
            StreamWriter filewriter = null;

            try
            {
                filewriter = new StreamWriter(Path);

                foreach (int line in lines)
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

        public static List<string> PrintTextFileLinePerLine(string Path)
        {
            List<string> allPupils = new List<string>();
            try
            {
                StreamReader myFile = new StreamReader(Path);

                string line = myFile.ReadLine();

                while (line != null)
                {
                    allPupils.Add(line);
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

            return allPupils;
        }
    }
}
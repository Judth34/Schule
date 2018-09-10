using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataStructuresLIB;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Drabosenig_MyDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SimpleList sl = new SimpleList();
                
                List<int> BinaryTreeList = new List<int>();
                List<int> NumbersToFind = new List<int>();

                NumbersToFind = GetListWithRandomNumbers();

                BinaryTree bt = GetBinaryTreeWithData(@"randomNumbers.txt");

                BinaryTreeList = bt.PutBinaryTreeDataInList();
                
                CheckTree(BinaryTreeList, NumbersToFind);

                PutFileInSimpleList(sl, @"randomNumbers.txt");

                CheckList(sl, NumbersToFind);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<int> GetListWithRandomNumbers()
        {
            Random rnd = new Random();
            List<int> Werte = new List<int>();
            int NumbersCount = rnd.Next(1);
            for (int i = 0; i < NumbersCount; i++)
            {
                Werte.Add(rnd.Next(1, 2));
            }

            return Werte;
        }

        public static BinaryTree GetBinaryTreeWithData(string Path)
        {
            BinaryTree bt = null;
            try
            {
                StreamReader myFile = new StreamReader(Path);

                string line = myFile.ReadLine();
                bt = new BinaryTree(int.Parse(line));

                while (line != null)
                {
                    line = myFile.ReadLine();
                    if (line != null)
                    {
                        bt.Add(int.Parse(line));
                    }
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
            return bt;
        }

        public static void CheckTree(List<int> BinaryTreeList, List<int> NumbersToFind)
        {
           Stopwatch stopWatch = new Stopwatch(); stopWatch.Start();

            List<int> foundNumbers = new List<int>();
            for (int i = 0; i < NumbersToFind.Count; i++)
            {
                for (int j = 0; j < BinaryTreeList.Count; j++)
                {
                    
                    if (BinaryTreeList[j] == NumbersToFind[i])
                    {
                        foundNumbers.Add(NumbersToFind[i]);   
                    }
                }
            }
            if (foundNumbers.Count > 0)
            {
                Console.WriteLine("Gefundene Zahlen:");
                for (int i = 0; i < foundNumbers.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(foundNumbers[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("Es wurde nichts gefunden!!!");
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("TREE: It took {0} milliseconds", ts);
        }

        public static void PutFileInSimpleList(SimpleList sl, string Path)
        {
            try
            {
                StreamReader myFile = new StreamReader(Path);
                int i = 0;
                string line = myFile.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(i);
                    line = myFile.ReadLine();
                    if (line != null)
                    {
                        sl.Append(Convert.ToInt32(line));
                    }
                    i++;
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

        public static void CheckList(SimpleList sl, List<int> NumbersToFind)
        {
            Stopwatch stopWatch = new Stopwatch(); stopWatch.Start();

            List<int> foundNumbers = new List<int>();
            for (int i = 0; i < NumbersToFind.Count; i++)
            {
                Console.WriteLine(i);
                for (int j = 0; j < sl.Count(); j++)
                {
                    Console.WriteLine(j);
                    if (sl.GetValueAt(j) == NumbersToFind[i])
                    {
                        foundNumbers.Add(NumbersToFind[i]);
                    }
                }
            }
            if (foundNumbers.Count > 0)
            {
                Console.WriteLine("Gefundene Zahlen:");
                for (int i = 0; i < foundNumbers.Count; i++)
                {
                    Console.WriteLine(i);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(foundNumbers[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("Es wurde nichts gefunden!!!");
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("List: It took {0} milliseconds", ts);
        }
    }
}

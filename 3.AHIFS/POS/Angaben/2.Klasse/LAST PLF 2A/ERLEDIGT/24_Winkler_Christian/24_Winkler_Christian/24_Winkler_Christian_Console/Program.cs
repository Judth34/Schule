using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using _24_Winkler_Christian;

namespace _24_Winkler_Christian_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Vars
                string[] FileNames = readFileNames(@"Filenames.config");
                int[] IntData = null;
                double[] DoubleData = null;
                double DAverage = 0;
                double IAverage = 0;
                Simple_List MyList = null;
                BinarySearchTree MyTree = null;
                #endregion
                #region Calls
                ReadFiles(out IntData, out DoubleData, FileNames); //ohne out bleiben die Arrays auf null (werden in die Funktion kopiert)
                MyList = FillSList(DoubleData);
                MyTree = FillBSTree(IntData);
                DAverage = MyList.GetAverage();
                IAverage = MyTree.getAverage();
                #endregion
                #region Write
                Console.WriteLine("Double Durchschnitt = " + DAverage);
                Console.WriteLine("Integer Durchschnitt = " + IAverage);
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static string[] readFileNames(string path)
        {
            string[] CorrectFileNames = new string[3]; //Strichpunkt am Ende der .config Datei erstellt einen String ""
            if (File.Exists(path))
            {
                string[] allFileNames = null;
                int CorrectionIdx = 0;
                foreach (string line in File.ReadAllLines(path))
                {
                    allFileNames = line.Split(';');
                }
                foreach (string line in allFileNames)
                {
                    if (line.Contains(".") == true)
                    {
                        CorrectFileNames[CorrectionIdx] = line;
                    }
                    CorrectionIdx++;
                }
            }
            else throw new Exception("File does not Exist!");
            return CorrectFileNames;
        }
        static void ReadFiles (out int[] allInts, out double[] allDoubles, string[] allFileNames)
        {
            List<int> allIntsFromFile = new List<int>();
            List<double> allDoublesFromFile = new List<double>();
            foreach (string FileName in allFileNames)
            {
                if (File.Exists(FileName))
                {
                    BinaryReader br = new BinaryReader(File.Open(FileName, FileMode.Open));
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        allIntsFromFile.Add(br.ReadInt32());
                        if (br.BaseStream.Position != br.BaseStream.Length)
                        {
                            allDoublesFromFile.Add(br.ReadDouble());
                        }
                    }
                }
                else throw new Exception("File does not Exist!");
            }
            allInts = allIntsFromFile.ToArray();
            allDoubles = allDoublesFromFile.ToArray();
        }
        static BinarySearchTree FillBSTree (int[] values)
        {
            BinarySearchTree mytree = new BinarySearchTree();
            foreach(int value in values)
            {
                mytree.Append(value);
            }
            return mytree;
        }
        static Simple_List FillSList(double[] values)
        {
            Simple_List mylist = new Simple_List();
            foreach(double value in values)
            {
                mylist.Append(value);
            }
            return mylist;
        }
    }
}

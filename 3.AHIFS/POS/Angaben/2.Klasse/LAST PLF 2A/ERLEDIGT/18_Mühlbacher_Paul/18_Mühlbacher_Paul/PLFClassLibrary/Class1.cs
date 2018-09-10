using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace PLFClassLibrary
{
    public class Tree
    {
        class Node
        {
            public int Value { get; set; }
            public Node Right { get; set; }
            public Node Left { get; set; }

            public Node(int newValue)
            {
                Value = newValue;
            }

        }

        Node root = null;

        #region Methods
        public void Add(int newValue)
        {
            if (root == null)
            {
                root = new Node(newValue);
            }
            else
            {
                //if (Contains(newValue))
                //{
                //    throw new Exception("No duplicated values in Tree!");
                //}

                Node addAfter = getParent(newValue, root);

                if (newValue < addAfter.Value)
                {
                    addAfter.Left = new Node(newValue);
                }
                else
                {
                    addAfter.Right = new Node(newValue);
                }
            }
        }

        private Node getParent(int newValue, Node current)
        {
            Node result = null;

            if ((newValue < current.Value && current.Left == null) || (newValue > current.Value && current.Right == null))
            {
                return current;
            }

            if (newValue < current.Value)
            {
                result = getParent(newValue, current.Left);
            }
            else
            {
                result = getParent(newValue, current.Right);
            }
            
            return result;
        }

        public bool Contains(int valueToFind)
        {
            if (root == null)
            {
                throw new Exception("There are no values in the Tree!");
            }

            return contains(valueToFind, root);
        }

        private bool contains(int valueToFind, Node current)
        {
            bool result = false;

            if (current.Value == valueToFind)
            {
                return true;
            }
            if (valueToFind < current.Value && current.Left != null)
            {
                result = contains(valueToFind, current.Left);
            }
            if (valueToFind > current.Value && current.Right != null)
            {
                result = contains(valueToFind, current.Right);
            }

            return result;
        }

        public List<int> GetAllValues()
        {
            if (root == null)
            {
                throw new Exception("There are no values in the Tree!");
            }

            List<int> allValues = new List<int>();
            getAllValues(allValues, root);
            return allValues;
        }

        private void getAllValues(List<int> allValues, Node current)
        {
            if (current.Left != null)
            {
                getAllValues(allValues, current.Left);
            }

            allValues.Add(current.Value);

            if (current.Right != null)
            {
                getAllValues(allValues, current.Right);
            }
        }
        #endregion
    }

    public class IntAndDoubleFileLoader
    {
        public List<string> GetFileNames(string path)
        {
            List<string> files = new List<string>();
            List<string> seperatedFilesList = new List<string>();
            string[] seperatedFiles;

            StreamReader myReader = null;
            string line;

            try
            {
                myReader = new StreamReader(path);
                // KAA: nicht effizient
                while((line = myReader.ReadLine()) != null)
                {
                    files.Add(line);
                }

                foreach(string s in files)
                {
                    seperatedFiles = s.Split(';');

                    foreach(string s1 in seperatedFiles)
                    {
                        if(s1 != "")
                        {
                            seperatedFilesList.Add(s1);
                        }
                        
                    }
                }

                return seperatedFilesList;
            }
            catch (FileNotFoundException)
            {
                throw new Exception("File nicht gefunden!");
            }
            catch (Exception)
            {
                throw new Exception("Unbekannter Fehler");
            }

            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                }
            }
        }

        // KAA: Code ist redundant und nicht effizient 2x die Files zu lesen!
        public Tree SaveIntegersFromFileInTree(string filename)
        {
            Tree t = new Tree();

            using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    t.Add(br.ReadInt32());

                    if (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        br.ReadDouble();
                    }
                }
            }
            return t;
        }

        public List<double> SaveDoublesFromFileInList(string filename)
        {
            List<double> l = new List<double>();

            using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    br.ReadInt32();

                    if (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        l.Add(br.ReadDouble());
                    }
                }
            }

            return l;
        }

        
    }

    public class IntAndDoubleCalculator
    {
        public double GetAverageOfIntegersFromTree(Tree t)
        {
            // KAA: effizienter wäre gewesen dies über eine eigene Traversierung zu lösen
            List<int> l = t.GetAllValues();
            int sum = 0;
            double average;

            foreach (int i in l)
            {
                sum += i;
            }

            average = (double)sum / l.Count;

            return average;
        }

        public double GetAverageOfDoublesFromList(List<double> l)
        {
            double sum = 0;
            double average;

            foreach (double d in l)
            {
                sum += d;
            }

            average = sum / l.Count;

            return (double)average;
        }
    }
}

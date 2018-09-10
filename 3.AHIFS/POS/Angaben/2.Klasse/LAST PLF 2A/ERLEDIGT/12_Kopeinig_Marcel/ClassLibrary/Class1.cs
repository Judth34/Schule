using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SimpleTree
    {
        Node root;
        private List<double> Data;

        private class Node
        {
            public double value;
            public Node left;
            public Node right;

            public Node(double value)
            {
                this.value = value;
            }

        }

        public void Add(double value)
        {
            Addrekursive(value, ref root);
        }
        private void Addrekursive(double value, ref Node currntNode)
        {
            try
            {
                if (currntNode == null)
                {
                    currntNode = new Node(value);
                }
                else
                {
                    if (value < currntNode.value)
                    {
                        Addrekursive(value, ref currntNode.left);
                    }
                    else if (value > currntNode.value)
                    {
                        Addrekursive(value, ref currntNode.right);
                    }
                    else if (value == currntNode.value)
                    {
                        throw new Exception("Dieser Wert ist schon vorhanden!");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }


        public bool search(double value)
        {
            bool erg = false;
            erg = searchrekursive(value, root, erg);
            return erg;
        }
        private bool searchrekursive(double value, Node currntNode, bool erg)
        {
            if (currntNode == null)
            {
                erg = false;
            }
            else
            {
                if (currntNode.value == value)
                    return true;
                if (value < currntNode.value)
                {
                    erg = searchrekursive(value, currntNode.left, erg);
                }
                else if (value > currntNode.value)
                {
                    erg = searchrekursive(value, currntNode.right, erg);
                }
            }
            return erg;

        }


        public List<double> printall()
        {
            Data = new List<double>();
            return printallrekursive(root);
        }
        private List<double> printallrekursive(Node n)
        {
            if (n == null)
            {
                throw new Exception("Der Baum ist leer!");
            }
            if (n.left != null)
            {
                printallrekursive(n.left);
                Data.Add(n.value);
            }
            if (n.right != null)
            {
                printallrekursive(n.right);
            }
               
            return Data;
        }


    }
    public class LoadRekursiv
    {
        public SimpleTree LoadCSV(string path)
        {
            StreamReader Reader = new StreamReader(path);
            double result;
            string line = Reader.ReadLine();
            SimpleTree AllData = new SimpleTree();

            while (line != null)
            {
                if (!(double.TryParse(line, out result)))
                {
                    throw new Exception("Diese Datei besitzt leider nicht das richtige Format!");
                }
                AllData.Add(double.Parse(line));
                line = Reader.ReadLine();
            }
            return AllData;
        }

        public SimpleTree LoadBIN(string path)
        {
            SimpleTree st = new SimpleTree();
            double result;
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                int numberOfByte = br.ReadInt32();
                byte[] array = br.ReadBytes(numberOfByte);
                string s = ByteArrayToString(array);
                if (!(double.TryParse(s, out result)))
                {
                    throw new Exception("Diese Datei besitzt leider nicht das richtige Format!");
                }
                st.Add(double.Parse(s));
            }
            return st;
        }

        private string ByteArrayToString(byte[] data)
        {
            return Encoding.ASCII.GetString(data);
        }
    }
    
}

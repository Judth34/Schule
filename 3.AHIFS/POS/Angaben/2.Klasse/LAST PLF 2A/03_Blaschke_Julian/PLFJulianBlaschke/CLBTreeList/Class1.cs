using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLBTreeList
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
            #region tries
            //if (root == null)
            //{
            //    root = new Node(value);
            //}
            //else
            //{
            //    Node currentNode = root;
            //    while ((currentNode.left != null) && (currentNode.right != null))
            //    {
            //        if (value > currentNode.value)
            //        {
            //            currentNode = currentNode.right;
            //        }
            //        else
            //        {
            //            currentNode = currentNode.left;
            //        }
            //    }
            //    if (value > currentNode.value)
            //    {currentNode.right = new Node (value);}
            //    else
            //    { currentNode.left = new Node(value); }
            //}
            #endregion
            Addrekursive(value, ref root);

        }
        private void Addrekursive(double value, ref Node currntNode)
        {
            if (currntNode == null)
            {
                currntNode = new Node(value);
            }
            else
            {
                if (value < currntNode.value)
                { Addrekursive(value, ref currntNode.left); }
                else if (value > currntNode.value)
                { Addrekursive(value, ref currntNode.right); }
                else if (value == currntNode.value)
                { Addrekursive(value, ref currntNode.right); }
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
            { erg = false; }
            else
            {
                if (currntNode.value == value)
                    return true;
                if (value < currntNode.value)
                { erg = searchrekursive(value, currntNode.left, erg); }
                else if (value > currntNode.value)
                { erg = searchrekursive(value, currntNode.right, erg); }
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
                return Data;
            if (n.left != null)
                printallrekursive(n.left);
            Data.Add(n.value);
            if (n.right != null)
                printallrekursive(n.right);
            return Data;
        }

    }

    public class SimpleList
    {
        class Node
        {
            public double? value;
            public Node Next;

            public Node(double? value)
            {
                this.value = value;
            }

        }
        Node Head;

        public SimpleList()
        {
            Head = new Node(null);
        }
        public void Add(double? value)
        {
            if (Head.Next == null)
            {
                Head.Next = new Node(value);
            }
            else
            {
                Node currentnode = Head.Next;
                while (currentnode.Next != null)
                {
                    currentnode = currentnode.Next;
                }

                currentnode.Next = new Node(value);
            }
        }

        public double? Remove()
        {
            if (Head.Next == null)
            {
                throw new Exception("The list is emtpy");
            }
            Node currentnode = Head.Next;
            while (currentnode.Next != null)
            {
                currentnode = currentnode.Next;
            }
            double? erg = currentnode.value;
            currentnode = null;
            return erg;


        }

        public bool find(double? value)
        {
            bool erg = false;
            Node currentNode = Head;
            if (currentNode == null)
                erg = false;
            while (currentNode.Next != null)
            {
                if (currentNode.value == value)
                { erg = true; }
                currentNode = currentNode.Next;
            }
            if (currentNode.value == value)
            { erg = true; }
            return erg;
        }

        public List<double?> PrintAll()
        {
            List<double?> Data = new List<double?>();
            Node currentNode = Head;
            if (currentNode == null)
                return Data;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                Data.Add(currentNode.value);
            }
            return Data;
        }
    }



    public class LoadBinaryfile
    {
        
        private List<Int32> LoadInteger()
        {
            List<double> Doublevalues = new List<double>();
            List<Int32> Integervalues = new List<Int32>();
            using (StreamReader sr = new StreamReader(File.Open("Filenames.config", FileMode.Open)))
              {
                string filenames = sr.ReadLine();
                string[] fileenames = filenames.Split(';');

                for (int i = 0; i < 3; i++)
                {
                    using (BinaryReader br = new BinaryReader(File.Open(fileenames[i], FileMode.Open)))
                    {
                        
                        int pos = 0;
                        while (pos < (int)br.BaseStream.Length)
                        {


                            Integervalues.Add(br.ReadInt32());
                            pos += sizeof(Int32);

                            Doublevalues.Add(br.ReadDouble());
                            pos += sizeof(double);

                        }
                        
                    }
                }
                return Integervalues;
            }
            
        }
        private List<double> LoadDouble()
        {
            // KAA: Code besser auftrennen
            List<double> Doublevalues = new List<double>();
            List<Int32> Integervalues = new List<Int32>();
            using (StreamReader sr = new StreamReader(File.Open("Filenames.config", FileMode.Open)))
            {
                string filenames = sr.ReadLine();
                string[] fileenames = filenames.Split(';');

                for (int i = 0; i < 3; i++)
                {

                    using (BinaryReader br = new BinaryReader(File.Open(fileenames[i], FileMode.Open)))
                    {
                        
                        int pos = 0;
                        while (pos < (int)br.BaseStream.Length)
                        {


                            Integervalues.Add(br.ReadInt32());
                            pos += sizeof(Int32);

                            Doublevalues.Add(br.ReadDouble());
                            pos += sizeof(double);

                        }
                       
                    }
                }
                return Doublevalues;
            }

        }

        public SimpleTree createSimpleTree()
        {

            List<Int32> Data = LoadInteger();
            SimpleTree s = new SimpleTree();
            foreach (Int32 value in Data )
            {
                s.Add(value);
            }
            return s;
        }
        public SimpleList createSimpleList()
        {

            List<double> Data = LoadDouble();
            SimpleList l = new SimpleList();
            foreach (double value in Data)
            {
                l.Add(value);
            }
            return l;
        }

        // KAA: Schlechte Benennung von Methoden - Coderedundanz!!
        public double GetAverageInteger ()
        {
            SimpleTree s = createSimpleTree();
            List<double> l = s.printall();
            double sum =0;
            // KAA: Berechnung des Durchschnitts nicht effizient
            foreach(double value in l)
            {
                sum += value;
            }
            return sum / l.Count;

        }
        public double GetAverageDouble()
        {
            SimpleList s = createSimpleList();
            List<double?> l = s.PrintAll();
            double sum = 0;

            foreach (double value in l)
            {
                sum += value;
            }
            return sum / l.Count;
        }


    }
}



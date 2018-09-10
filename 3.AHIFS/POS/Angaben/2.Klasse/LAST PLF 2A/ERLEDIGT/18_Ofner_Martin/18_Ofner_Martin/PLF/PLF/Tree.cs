using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PLF
{
    class Tree
    {
        #region root
        Node root = null;
        #endregion
        #region Node
        public class Node
        {
            public int value { get; }
            internal Node left;
            internal Node right;

            public Node(int newvalue)
            {
                value = newvalue;
            }
        }
        #endregion
        #region PublicGetValues
        public List<int> GetValues()
        {
            List<int> allvalues = new List<int>();
            if (root != null)
                getValues(allvalues, root);
            else
                throw new Exception("Baum ist leer");
            return allvalues;

        }
        #endregion
        #region internal GetValues
        private List<int> getValues(List<int> allvalues, Node CurrentNode)
        {
            allvalues.Add(CurrentNode.value);
            if (CurrentNode.left != null)
            {
                allvalues = getValues(allvalues, CurrentNode.left);
            }
            if (CurrentNode.right != null)
            {
                allvalues = getValues(allvalues, CurrentNode.right);
            }

            return allvalues;
        }
        #endregion

        #region publicAppend
        public void Append(int newValue)
        {
            append(newValue, root);
        }
        #endregion
        #region internalAppend
        private void append(int newvalue, Node CurrentNode)
        {

            if (root == null && CurrentNode == null)
            {
                root = new Node(newvalue);
            }
            else if (newvalue == CurrentNode.value)
            {
                if (CurrentNode.left == null)
                {
                    CurrentNode.left = new Node(newvalue);
                }
                else
                {
                    append(newvalue, CurrentNode.left);
                }
            }
            else if (CurrentNode.value > newvalue)
            {
                if (CurrentNode.left == null)
                {
                    CurrentNode.left = new Node(newvalue);
                }
                else
                {
                    append(newvalue, CurrentNode.left);
                }
            }
            else if (CurrentNode.value < newvalue)
            {
                if (CurrentNode.right == null)
                {
                    CurrentNode.right = new Node(newvalue);
                }
                else
                {
                    append(newvalue, CurrentNode.right);
                }

            }
            else
            {
                throw new Exception("Undefined Error!!");
            }
        }
        #endregion

        #region public Search
        public bool Search(int SearchForThisValue)
        {

            if (root == null)
            {
                throw new Exception("Baum ist leer!");
            }
            if (root.value == SearchForThisValue)
            {
                return true;
            }


            return search(root, SearchForThisValue);
        }
        #endregion
        #region internal search
        private bool search(Node currentNode, int SearchForThisValue)
        {
            bool result = false;
            if (currentNode.value == SearchForThisValue)
            {
                return true;
            }
            if (currentNode == null)
            {
                return false;
            }
            else if (currentNode.left != null)
            {
                if (currentNode.value < SearchForThisValue)
                {

                    result = search(currentNode.right, SearchForThisValue);
                }
            }
            else if (currentNode.right != null)
            {
                if (currentNode.value > SearchForThisValue)
                {
                    result = search(currentNode.left, SearchForThisValue);
                }

            }
            return result;
        }
        #endregion

        #region Loads

        #region LoadTXT
        public List<int> Load(string path)
        {

            string[] allValues = null;
            List<int> AllValuesList = new List<int>();
            try
            {
                allValues = File.ReadAllLines(path);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("FIle nicht gefunden");
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            foreach (string line in allValues)
            {
                AllValuesList.Add(int.Parse(line));
            }

            return AllValuesList;
        }
        #endregion
        #region LoadBinary
        public List<int> LoadBinary(string path)
        {

            Stream s = File.Open(path, FileMode.Open);
            BinaryReader reader = new BinaryReader(s);
            List<int> AllValues = new List<int>();

            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                AllValues.Add(reader.ReadInt32());
            }
            return AllValues;
        }
        #endregion
        #endregion
    }
}

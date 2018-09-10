using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _24_Winkler_Christian
{
    public class BinarySearchTree
    {
        Node root = null;
        public class Node
        {
            public int Value { get; set; }
            public Node left { get; internal set; }
            public Node right { get; internal set; }
            public Node(int newValue)
            {
                Value = newValue;
            }
        }
        internal void Append(int newValue, Node CurrentNode)
        {
            if (CurrentNode == null && root == null)
            {
                root = new Node(newValue);
            }
            else if (newValue <= CurrentNode.Value)
            {
                if (CurrentNode.left == null)
                {
                    CurrentNode.left = new Node(newValue);
                }
                else
                {
                    Append(newValue, CurrentNode.left);
                }
            }
            else if (newValue > CurrentNode.Value)
            {
                if (CurrentNode.right == null)
                {
                    CurrentNode.right = new Node(newValue);
                }
                else
                {
                    Append(newValue, CurrentNode.right);
                }
            }
        }
        public double getAverage()
        {
            int idx = 0;
            int allIntValues = 0;
            List<int> allValues = getAllValues();
            foreach(int value in allValues)
            {
                allIntValues += value;
                idx++;
            }
            return (double)allIntValues / idx;
        }
        public void Append(int newValue)
        {
            Append(newValue, root);
        }
        public List<int> getAllValues()
        {
            if (root == null)
            {
                throw new Exception("Baum hat keine Blätter!");
            }
            List<int> allValues = new List<int>();
            return getAllValues(allValues, root);
        }
        private List<int> getAllValues(List<int> allValues, Node CurrentNode)
        {
            allValues.Add(CurrentNode.Value);
            if (CurrentNode.left != null)
            {
                allValues = getAllValues(allValues, CurrentNode.left);
            }
            if (CurrentNode.right != null)
            {
                allValues = getAllValues(allValues, CurrentNode.right);
            }
            return allValues;
        }
    }
    public class Simple_List
    {
        class Node
        {
            public double Value { get; set; }
            public Node Next { get; set; }
        }
        Node head;
        Node newNode;
        Node currentNode;
        int anzahlElemente;
        public Simple_List()
        {
            head = null;
            currentNode = head;
            anzahlElemente = 0;
        }
        public void Append(double NewValue)
        {
            newNode = new Node();
            newNode.Value = NewValue;
            if (IsEmpty())
            {
                insertOnHead();
            }
            else
            {
                currentNode = head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
                anzahlElemente++;
                //currentNode.Next = newNode;
                //currentNode = currentNode.Next;
                //anzahlElemente++;
            }
        }
        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void insertOnHead()
        {
            head = newNode;
            currentNode = head;
            anzahlElemente++;
        }
        public double GetAverage()
        {
            int idx = 0;
            double allValues = 0;
            newNode = head;
            for (; idx < anzahlElemente; idx++)
            {
                allValues += newNode.Value;
                newNode = newNode.Next;
            }
            return allValues / idx;
        }
    }
}

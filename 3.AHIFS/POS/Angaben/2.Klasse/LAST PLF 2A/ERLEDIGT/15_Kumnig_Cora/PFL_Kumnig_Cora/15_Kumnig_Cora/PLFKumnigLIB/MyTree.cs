using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFKumnigLIB
{
    public class MyTree
    {
        private class Node
        {
            public int Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node(int newValue)
            {
                Value = newValue;
            }
        }

        public int Count { get; set; }

        Node root = null;

        public void Appand(int newValue)
        {
            if (root == null)
            {
                root = new Node(newValue);
            }
            else
            {
                appand(root, newValue);
            }
        }
        private void appand(Node current, int newValue)
        {
            //if (current.Value == newValue)
            //{
            //    throw new Exception("Der Wert existiert bereits!");
            //}
            if (newValue < current.Value)
            {
                if (current.Left == null)
                {
                    current.Left = new Node(newValue);
                }
                else
                {
                    appand(current.Left, newValue);
                }
            }
            if (newValue > current.Value)
            {
                if (current.Right == null)
                {
                    current.Right = new Node(newValue);
                }
                else
                {
                    appand(current.Right, newValue);
                }
            }
        }
        public List<int> GetAllValues()
        {
            if (root == null)
            {
                throw new Exception("Der Baum verfügt über keine ELemente!");
            }
            List<int> values = new List<int>();
            getAllValues(values, root);
            return values;
        }
        private void getAllValues(List<int> values, Node current)
        {
            //IN-Order
            if (current.Left != null)
            {
                getAllValues(values, current.Left);
            }
            values.Add(current.Value);
            if (current.Right != null)
            {
                getAllValues(values, current.Right);
            }
        }

        public float GetDurchschnittTree()
        {
            int alleWerte = 0;
            foreach(int wert in GetAllValues())
            {
                alleWerte += wert;
            }

            // KAA: falscher Cast und nicht Modulo rechnen!!! 

            return (float)alleWerte % Count;
        }
    }
}

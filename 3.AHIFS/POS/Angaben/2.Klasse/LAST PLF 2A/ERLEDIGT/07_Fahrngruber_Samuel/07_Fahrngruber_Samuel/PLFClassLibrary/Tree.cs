using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFClassLibrary
{
    public class Tree
    {
        private class Node
        {
            public int Value;
            public Node Left;
            public Node Right;

            public Node(int val)
            {
                Value = val;
                Left = null;
                Right = null;
            }
        }

        private Node root;

        public Tree(int[] values)
        {
            root = null;
            foreach (int x in values)
            {
                Add(x);
            }
        }
        public Tree()
        {
            root = null;
        }
        public void Add(int value)
        {
            addAt(value, ref root);
        }
        public bool Contains(int value)
        {
            return containsAt(value, root);
        }
        public List<int> GetValues()
        {
            List<int> list = new List<int>();
            getAt(list, root);
            return list;
        }

        private void addAt(int value, ref Node node)
        {
            if (node == null)
            {
                node = new Node(value);
            }
            else if (value < node.Value)
            {
                addAt(value, ref node.Left);

            }
            else if (value >= node.Value) // ==
            {
                addAt(value, ref node.Right);

            }
            else if (value == node.Value)
            {
                //throw new Exception("Der Wert " + value + " existiert bereits!");
            }

        }
        private bool containsAt(int value, Node node)
        {
            if (node == null)
            {
                return false;
            }
            else if (value < node.Value)
            {
                return containsAt(value, node.Left);
            }
            else if (value > node.Value)
            {
                return containsAt(value, node.Right);
            }
            return true;

        }
        private void getAt(List<int> list, Node node)
        {
            if (node != null)
            {
                getAt(list, node.Left);
                list.Add(node.Value);
                getAt(list, node.Right);
            }
        }
    }
}

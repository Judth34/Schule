using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durchschnittsberechnung
{
    public class BinarySearchTree
    {
        private class Node
        {
            public int Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }

        Node root = null;
        public void Add(int Value)
        {
            if (root == null)
            {
                root = new Node(Value);
            }
            else
            {
                add(Value, root);
            }
        }

        private void add(int value, Node currentNode)
        {
            if (currentNode.Value == value)
            {
            //    throw new Exception("Element bereits im Baum!");
            }
            if (value < currentNode.Value)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = new Node(value);
                }
                else
                {
                    add(value, currentNode.Left);
                }
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = new Node(value);
                }
                else
                {
                    add(value, currentNode.Right);
                }
            }

        }

        public int[] GetAllValues()
        {
            List<int> myList = new List<int>();

            if (root != null)
            {
                getAllValues(root, myList);
            }

            return myList.ToArray();
        }

        private void getAllValues(Node currentNode, List<int> myList)
        {

            if (currentNode.Left != null)
            {
                getAllValues(currentNode.Left, myList);
            }
            myList.Add(currentNode.Value);
            if (currentNode.Right != null)
            {
                getAllValues(currentNode.Right, myList);
            }

        }
    }
}

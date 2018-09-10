using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF_Library
{
    public class SimpleTree
    {
        Node root = null;

        public bool Search(int Value)
        {
            Node currentNode = root;

            while (currentNode != null)
            {
                if (currentNode.Value == Value)
                {
                    return true;
                }
                else if (currentNode.Value > Value)
                {
                    currentNode = currentNode.FirstSibling;
                }
                else
                {
                    currentNode = currentNode.LastSibling;
                }
            }

            return false;
        }

        public void Add(int Value)
        {
            Node currentNode = root;

            if (root == null)
            {
                root = new Node(null, null, null, Value);
            }
            else
            {
                Add(root, Value);
            }
        }

        private void Add(Node SourceNode, int Value)
        {
            if (SourceNode.Value > Value)
            {
                if (SourceNode.FirstSibling == null)
                {
                    SourceNode.FirstSibling = new Node(SourceNode, null, null, Value);
                }
                else
                {
                    Add(SourceNode.FirstSibling, Value);
                }
            }
            else if (SourceNode.Value < Value)
            {
                if (SourceNode.LastSibling == null)
                {
                    SourceNode.LastSibling = new Node(SourceNode, null, null, Value);
                }
                else
                {
                    Add(SourceNode.LastSibling, Value);
                }
            }
        }
    }

    class Node
    {
        public int Value { private set; get; }
        public Node Before, FirstSibling, LastSibling;
        public Node(Node Before, Node FirstSibling, Node LastSibling, int Value)
        {
            this.Before = Before;
            this.FirstSibling = FirstSibling;
            this.LastSibling = LastSibling;
            this.Value = Value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLernen
{
    class BinaryTree
    {
        public class Node
        {
            public Node left;
            public Node right;
            public int Value;

            public Node(int newValue)
            {
                Value = newValue;
                left = null;
                right = null;
            }
        }
        #region Eigenschaften
        private Node root;
        private List<int> BinaryTreeData = new List<int>();
        #endregion

        #region Konstrukor
        public BinaryTree(int value)
        {
            root = new Node(value);
        }

        public BinaryTree()
        {
            root = null;
        }
        #endregion

        public void Add(int newValue)
        {
            add(newValue, root);
        }

        private void add(int newValue, Node currentNode)
        {
            if (root == null)
            {
                root = new Node(newValue);
            }
            //if (newValue == currentNode.Value)
            //{
            //    throw new Exception("Die Zahl " + newValue + " existiert bereits!!!");
            //}

            if (newValue < currentNode.Value)
            {
                if (currentNode.left == null)
                {
                    currentNode.left = new Node(newValue);
                }
                else
                {
                    add(newValue, currentNode.left);
                }
            }
            else
            {
                if (currentNode.right == null)
                {
                    currentNode.right = new Node(newValue);
                }
                else
                {
                    add(newValue, currentNode.right);
                }
            }
        }

        public List<int> PutBinaryTreeDataInList()
        {
            putBinaryTreeDataInList(root);
            return BinaryTreeData;
        }

        private void putBinaryTreeDataInList(Node currentNode)
        {
            if (currentNode.left != null)
            {
                putBinaryTreeDataInList(currentNode.left);
                BinaryTreeData.Add(currentNode.Value);
            }
            else
            {
                BinaryTreeData.Add(currentNode.Value);
            }

            if (currentNode.right != null)
            {
                putBinaryTreeDataInList(currentNode.right);
            }
        }
    }
}

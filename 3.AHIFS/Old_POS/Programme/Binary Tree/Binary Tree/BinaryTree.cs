using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
    class BinaryTree
    {
        #region Eigenschaften
        private bool found = false;
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
                currentNode = root;
            }
            else
            {
                if (newValue == currentNode.Value)
                {
                    throw new Exception("Die Zahl " + newValue + " existiert bereits!!!");
                }

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

            
        }

        public bool Contains(int Searchnumber)
        {
            contains(root, Searchnumber);
            return found;
        }

        private void contains(Node currentNode, int Searchnumber)
        {
            if (currentNode == null)
            {
                found = false;
            }

            if (Searchnumber == currentNode.Value)
            {
                found = true;
            }
            else
            {
                if (Searchnumber < currentNode.Value)
                {
                    currentNode = currentNode.left;
                    contains(currentNode, Searchnumber);
                }
                else
                {
                    if (Searchnumber > currentNode.Value)
                    {
                        currentNode = currentNode.right;
                        contains(currentNode, Searchnumber);
                    }
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

        public List<int> GetDataPostOrder()
        {
            return getDataPostOrder(new List<int>(), root);
        }

        private List<int> getDataPostOrder(List<int> list, Node currendNode)
        {
            if(currendNode.left != null)
            {
                getDataPostOrder(list, currendNode.left);
            }
            
            if(currendNode.right != null)
            {
                getDataPostOrder(list, currendNode.right);
            }

            list.Add(currendNode.Value);

            return list;
        }
    }
}

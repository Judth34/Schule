using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

   public class BinaryTree
    {
        private Node root = null;

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
            else
            {
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
    }

   
}

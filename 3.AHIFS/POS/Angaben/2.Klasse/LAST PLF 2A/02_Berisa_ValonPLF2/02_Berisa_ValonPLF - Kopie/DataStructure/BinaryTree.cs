using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Berisa_ValonPLF
{
    public class BinaryTree
    {
        public Node root;
        public int count { get; private set; }
        public BinaryTree()
        {
            root = null;
        }
        public BinaryTree(int initial)
        {
            root = new Node(initial);
        }

        public void Add(int value)
        {
            AddRc(ref root, value);
        }
        private void AddRc(ref Node N, int value)
        {
            if (N == null)
            {
                // root is still null, a node doesn't exist, create here...
                Node newNode = new Node(value);
                N = newNode;
                count++;
                return;
            }

            //if (value == N.value)
            //    throw new Exception("Number already exists ");

            if (value < N.value)
            {
                AddRc(ref N.left, value);
                return;
            }

            if (value >= N.value)
            {
                AddRc(ref N.right, value);
                return;
            }
        }

        public List<int> getValues()
        {
            List<int> data = new List<int>();
            data = getValuesRC(root, data);
            return data;
        }
        private List<int> getValuesRC(Node N, List<int> data)
        {
            //prints out the tree in sorted order to the string newString by using recursion

            if (N == null) throw new Exception("null");

            if (N.left != null)
            {
                getValuesRC(N.left, data);
                data.Add(N.value);
            }

            else
                data.Add(int.Parse(N.value.ToString()));

            if (N.right != null)
                getValuesRC(N.right, data);

            return data;
        }

        public int getAverage()
        {
            int average = 0;
            return getAverageRC(root, average) / count;
        }
        private int getAverageRC(Node N, int average)
        {
            if (N == null) throw new Exception("null");

            if (N.left != null)
            {
                getAverageRC(N.left, average);
                average += N.value;
            }

            else
                average += N.value;

            if (N.right != null)
                getAverageRC(N.right, average);

            return average;
        }

    }

    public class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int initial)
        {
            value = initial;
            left : right = null;
        }
    }

}

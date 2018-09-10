using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class BinarySearchTree
    {
        class Node
        {
            public int Value { get; set; }
            public Node Right { get; set; }
            public Node Left { get; set; }

            public Node(int newValue)
            {
                Value = newValue;
            }

        }

        Node root = null;


        #region Methoden

        public void Add(int newValue)
        {
            if (root == null)
            {
                root = new Node(newValue);
            }
            else
            {
                //if (Contains(newValue))
                //{
                //    throw new Exception("Jeder Wert darf nur einmal vorkommen!");
                //}

                Node addAfter = getParent(newValue, root);

                if (newValue <= addAfter.Value)
                {
                    addAfter.Left = new Node(newValue);
                }
                else
                {
                    addAfter.Right = new Node(newValue);
                }
            }
        }

        private Node getParent(int newValue, Node current)
        {
            Node result = null;

            if ((newValue < current.Value && current.Left == null) || (newValue > current.Value && current.Right == null))
            {
                return current;
            }

            if (newValue < current.Value)
            {
                result = getParent(newValue, current.Left);
            }
            else if (newValue > current.Value)
            {
                result = getParent(newValue, current.Right);
            }
            else
            {
                result = null;
            }

            return result;
        }

        public bool Contains(int valueToFind)
        {
            if (root == null)
            {
                throw new Exception("Es befinden sich keine Werte in der Liste!");
            }

            return contains(valueToFind, root);
        }

        private bool contains(int valueToFind, Node current)
        {
            bool result = false;

            if (current.Value == valueToFind)
            {
                return true;
            }
            if (valueToFind < current.Value && current.Left != null)
            {
                result = contains(valueToFind, current.Left);
            }
            if (valueToFind > current.Value && current.Right != null)
            {
                result = contains(valueToFind, current.Right);
            }

            return result;
        }

        public List<int> GetAllValues()
        {
            if (root == null)
            {
                throw new Exception("Es befinden sich keine Werte in der Liste!");
            }

            List<int> allValues = new List<int>();
            getAllValues(allValues, root);
            return allValues;
        }

        private void getAllValues(List<int> allValues, Node current)
        {
            if (current.Left != null)
            {
                getAllValues(allValues, current.Left);
            }

            allValues.Add(current.Value);

            if (current.Right != null)
            {
                getAllValues(allValues, current.Right);
            }
        }
        #endregion
    }
}

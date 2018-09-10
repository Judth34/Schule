using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Bugelnig_Melanie
{
    public class SimpleTree
    {
        #region Fields
        private Node Root;
        #endregion

        #region Eingebettete Klasse
        class Node
        {
            #region Eigneschaften
            public Node Left;
            public Node Right;
            public double value;
            #endregion

            #region konstruktor(en)
            public Node(double newValue)
            {
                value = newValue;
            }
            #endregion
        }
        #endregion

        #region Konstruktoren
        public SimpleTree()
        {

        }

        public SimpleTree(List<double> AllValues)
        {
            foreach (int i in AllValues)
            {
                AddValue(i);
            }
        }
        #endregion

        #region AddValue
        public void AddValue(double value)
        {
            Node newNode = new Node(value);
            if (Root == null) Root = newNode;
            else addValue(newNode, Root);
        }

        private void addValue(Node newNode, Node currentNode)
        {
            if (currentNode.value == newNode.value) throw new Exception("Doppelter Wert");

            if (newNode.value < currentNode.value)
            {
                if (currentNode.Left == null) currentNode.Left = newNode;
                else
                {
                    currentNode = currentNode.Left;
                    addValue(newNode, currentNode);
                }
            }
            else
            {
                if (currentNode.Right == null) currentNode.Right = newNode;
                else
                {
                    currentNode = currentNode.Right;
                    addValue(newNode, currentNode);
                }
            }
        }
        #endregion

        #region Contains
        public bool Contains(double Value)
        {
            return contains(Value, Root);
        }
        private bool contains(double value, Node currentNode)
        {
            if (currentNode == null) return false;
            if (currentNode.value == value) return true;
            if (value < currentNode.value) currentNode = currentNode.Left;
            else currentNode = currentNode.Right;
            return contains(value, currentNode);
        }
        #endregion
    }
}

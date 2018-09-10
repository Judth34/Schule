using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
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
            public int value;
            #endregion

            #region konstruktor(en)
            public Node(int newValue)
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

        public SimpleTree(List<int> AllValues)
        {
            foreach (int i in AllValues)
            {
                AddValue(i);
            }
        }
        #endregion

        #region AddValue
        public void AddValue(int value)
        {
            Node newNode = new Node(value);
            if (Root == null) Root = newNode;
            else addValue(newNode, Root);
        }

        private void addValue(Node newNode, Node currentNode)
        {
            if (currentNode.value == newNode.value)  //throw new Exception("Doppelter Wert");

            if (newNode.value <= currentNode.value) // <= für den doppelten Wert;
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
        public bool Contains(int Value)
        {
            return contains(Value, Root);
        }
        private bool contains(int value, Node currentNode)
        {
            if (currentNode == null) return false;
            if (currentNode.value == value) return true;
            if (value < currentNode.value) currentNode = currentNode.Left;
            else currentNode = currentNode.Right;
            return contains(value, currentNode);
        }
        #endregion

        #region 
        public double GetAverage()
        {
            // KAA: ineffizient!
            int rgw = 0;
            List<int> AllValues = getList(new List<int>(), Root);
            int counter = 0;
            foreach (int i in AllValues)
            {
                rgw += i;
                counter++;
            }
            return rgw / counter;
        }

        // KAA: Rekursion ist falsch - 
        private List<int> getList(List<int> AllValues,Node currentNode)
        {
            if (currentNode == null) return AllValues;
            if (currentNode.Left != null)
            {
                AllValues.Add(currentNode.value);
                return getList(AllValues, currentNode.Left);
            }
            if(currentNode.Right!=null)
            {
                AllValues.Add(currentNode.value);
                return getList(AllValues, currentNode.Right);
            }
            AllValues.Add(currentNode.value);
            return AllValues;
        }
        #endregion
    }
}

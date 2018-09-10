using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyTree
    {
        Node root = null;
        class Node
        {
            internal int Value { get; set; }
            internal Node Left;
            internal Node Right;

            public Node(int newValue)
            {
                Value = newValue;
            }
        }

        #region Public Methods
        public void Append(int newValue)
        {
            Node currentNode = root;

            if (root == null)
            {
                root = new Node(newValue);
            }
            else 
                  
                append(ref currentNode, newValue);
            
           
        }

        public double GetDurchschnitt()
        {
            return getValues();
        }

        #endregion

        #region Private Methods
        private void append(ref Node currentNode, int newValue)
        {
            if (currentNode != null)
            {
                if (newValue > currentNode.Value)
                    append(ref currentNode.Right, newValue);
                else
                    append(ref currentNode.Left, newValue);
            }
            else
                currentNode = new Node(newValue);
        }       
        private void getValues(Node currentNode, List<int> allValues)
        {
            if (currentNode == null)
            {
                throw new Exception("Get all Elements failed! Please check if You have append Values.");
            }

            allValues.Add(currentNode.Value);

            if (currentNode.Left != null)
                getValues(currentNode.Left, allValues);

            if (currentNode.Right != null)
                getValues(currentNode.Right, allValues);
        }
        private double getValues()
        {
            List<int> allValues = new List<int>();//Liste erzeugen
            getValues(root, allValues); //Werte bekommen
            return getSumOfGrades(allValues, allValues.Count - 1)/ allValues.Count; //returnen Summe/Counter
        }
        private double getSumOfGrades(List<int> allgrades, int idx)
        {
            if (idx >= 0)
                return allgrades[idx] + getSumOfGrades(allgrades, idx - 1);
            else
                return 0;
        }
        #endregion
    }
}

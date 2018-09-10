using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyList
    {
        private class Node
        {
            public Node(double NewValue)
            {
                Value = NewValue;
            }

            public double Value { get; set; }
            public Node Next { get; set; }
        }

        Node head;

        #region Konstruktoren
        public MyList()
        {
            head = null;
            Count = 0;
        }
        #endregion 

        #region Propertie/s

        public int Count { get; private set; }

        #endregion

        #region Öffentliche Methoden
        public void Append(double newValue)
        {
            Node NewNode = new Node(newValue);
            Count++;

            if (checkHead())
            {
                head = NewNode;
            }
            else
            {
                Node CurrentNode = head;

                while (CurrentNode.Next != null)
                {
                    CurrentNode = CurrentNode.Next;
                }
                CurrentNode.Next = NewNode;
            }
        }
        public double GetDurchschnitt()
        {
            double[] allValues = getValues();     
            return getSumOfGradesWithArray(allValues, allValues.Length - 1) / allValues.Length;
        } 
        #endregion

        #region Private Methoden
        private bool checkHead()
        {
            bool result = false;

            if (head == null)
            {
                result = true;
            }

            return result;
        }
        private double[] getValues()
        {
            int i = 0;
            double[] NodeArray = new double[Count];

            if (checkHead())
            {
                throw new Exception("Ausgabe fehlgeschlagen! Sie haben keine Liste erzeugt!");
            }

            Node CurrentNode = head;

            while (CurrentNode.Next != null)
            {
                NodeArray[i] = CurrentNode.Value;
                CurrentNode = CurrentNode.Next;
                i++;
            }
            NodeArray[i] = CurrentNode.Value;

            return NodeArray;
        }
        private double getSumOfGradesWithArray(double[] allgrades, int idx)
        {
            if (idx >= 0)
                return allgrades[idx] + getSumOfGradesWithArray(allgrades, idx - 1);
            else
                return 0;
        }
        #endregion
    }
}

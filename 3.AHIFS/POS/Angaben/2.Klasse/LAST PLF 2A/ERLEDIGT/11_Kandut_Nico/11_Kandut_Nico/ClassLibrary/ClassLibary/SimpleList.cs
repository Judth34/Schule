using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF_LIB
{
    public class SimpleList
    {
        #region Node-Klasse

        private class Node
        {
            #region Eigenschaften

            public double Value;
            public Node Next;

            #endregion

            #region Konstruktor

            public Node(double NewValue)
            {
                Value = NewValue;
            }

            #endregion
        }

        #endregion

        #region Eigenschaften

        Node head;
        public int Count { get; private set; }

        #endregion

        #region Konstruktoren

        public SimpleList()
        {
            Count = 0;
        }

        #endregion

        #region Public-Methods

        public void Add(double NewElement)
        {
            Node NewNode = new Node(NewElement);
            Node CurrentNode = head;

            if (Count == 0)
            {
                head = NewNode;
            }

            else
            {
                while (CurrentNode.Next != null)
                {
                    CurrentNode = CurrentNode.Next;
                }

                CurrentNode.Next = NewNode;
            }

            Count++;
        }  

        public double[] GetValues()
        {
            double[] result = new double[Count];
            Node CurrentNode = head;

            for (int counter = 0; counter < Count; counter++)
            {
                result[counter] = CurrentNode.Value;
                CurrentNode = CurrentNode.Next;
            }

            return result;
        }

        public double getAverage()
        {
            double total = 0;

            //Werte zusammenzählen
            foreach (double D in GetValues())
            {
                total += D;
            }

            return total / Count;
        }

        public override string ToString()
        {
            string result = "";
            Node CurrentNode = head;

            while (CurrentNode != null)
            {
                result += (CurrentNode.Value + "\n");
                CurrentNode = CurrentNode.Next;
            }

            return result;
        }    

        #endregion
    }
}

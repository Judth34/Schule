using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durchschnittsberechnung
{
    public class SimpleList
    {
        #region embedded class

        class Node // embedded class (eingebettete Klasse)
        {
            double value;
            Node next;

            public double Value { get { return value; } set { this.value = value; } }
            public Node Next { get { return next; } set { next = value; } }

            public Node(double newElement)
            {
                value = newElement;
            }
        }

        #endregion

        #region Daten

        Node head;
        int count;

        #endregion

        #region Konstruktor

        public SimpleList()
        {
            head = null;
            count = 0;
        }

        #endregion

        #region Public Methoden

        public void Append(double newElement)
        {
            Node currentNode;
            Node newNode = new Node(newElement);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                currentNode = head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
            }
            count++;
        }
        public double[] GetValues()
        {
            Node currentNode = head;
            double[] allListElements = new double[count];

            for (int counter = 0; counter < count; counter++)
            {
                allListElements[counter] = currentNode.Value;
                currentNode = currentNode.Next;
            }
            return allListElements;
        }

        #endregion

        #region Properties

        public int Count
        {
            private set { count = value; }
            get { return count; }
        }

        #endregion
    }
}
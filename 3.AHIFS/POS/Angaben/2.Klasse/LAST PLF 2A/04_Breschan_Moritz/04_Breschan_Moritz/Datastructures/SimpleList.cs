using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
{
    public class SimpleList
    {
        #region Eingebettete Klasse
        class Node
        {
            #region Eigneschaften
            public Node next;
            public double value;
            #endregion

            #region konstruktor(en)
            public Node(double newValue)
            {
                value = newValue;
                next = null;
            }
            #endregion
        }
        #endregion

        #region Fields(Eigenschaften)
        private Node head;
        private int length;
        private Node lastNode;
        #endregion

        #region Properties
        public double Count
        {
            get { return length; }
        }
        #endregion

        #region konstruktor(en)
        public SimpleList()
        {
            head = null;
        }
        public SimpleList(params double[] values)
        {
            for (int counter = 0; counter < values.Length; counter++)
            {
                Append(values[counter]);
            }
        }

        public SimpleList(List<double> values)
        {
            foreach (double i in values)
            {
                Append(i);
            }
        }
        #endregion

        #region PublicMethods
        public void Append(double newValue)
        {
            Node newNode = new Node(newValue);
            if (IsEmpty())
            {
                head = newNode;
                lastNode = head;
            }
            else
            {
                lastNode.next = newNode;
                lastNode = newNode;
            }
            length++;
        }

        public void Prepend(double newValue)
        {
            Node newNode = new Node(newValue);
            newNode.next = head;
            head = newNode;
            length++;
        }
        public double[] GetValues(bool inverted = false)
        {
            Node podoubleer = head;
            double[] data = new double[length];
            if (IsEmpty())
            {
                IsEmptyException();
            }
            for (int counter = 0; counter < length; counter++)
            {
                data[counter] = podoubleer.value;
                podoubleer = podoubleer.next;
            }
            if (inverted)
            {
                double[] tempdouble = new double[data.Length];
                for (int counter = 0; counter < data.Length; counter++)
                {
                    tempdouble[counter] = data[(data.Length - 1) - counter];
                }
                data = tempdouble;
            }
            return data;
        }
        public bool IsEmpty()
        {
            return head == null;
        }
        #endregion

        #region privateMethods
        private void IsEmptyException()
        {
            throw new Exception("Die Liste Ist Leer!");
        }
        #endregion
    }
}

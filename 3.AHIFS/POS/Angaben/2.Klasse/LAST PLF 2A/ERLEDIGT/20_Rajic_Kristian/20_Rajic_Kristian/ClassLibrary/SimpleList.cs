using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class SimpleList
    {

        private class Node
        {
            public double Value { get; set; }
            public Node Next { get; set; }
        }
        #region Objektvariablen

        private Node head;
        private int size;

        #endregion


        #region Konstruktor(en)
        public SimpleList()
        {
            head = null;
            size = 0;
        }

        #endregion

        #region Properties

        public int Count
        {
            get { return size; }
        }
        #endregion
        #region Methoden

        
        public void Append(double value)
        {
            Node newNode = new Node();
            newNode.Value = value;
            size++;

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node Current = head;
                while (Current.Next != null)
                {
                    Current = Current.Next;
                }

                Current.Next = newNode;
            }
        }


        public double[] GetValues()
        {
            Node current = head;
            double[] Elements = new double[size];
            int idx = 0;
            while (current != null)
            {
                Elements[idx] = current.Value;
                current = current.Next;
                idx++;
            }

            return Elements;
        }
        #endregion
    }
}

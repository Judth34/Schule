using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlinkte_Liste
{
    class SimpleList
    {
        #region Eigenschaften
        private Node head = new Node(null);
        private int counterNode;
        Node currentNode = null;
        #endregion

        #region Klasse Node
        class Node
        {
            public Node next;
            public string value;

            public Node(string NewValue)
            {
                value = NewValue;
                next = null;
            }
        }
    
        #endregion

        #region Konstruktor(en)
        public SimpleList()
        {
            head.next = null;
        }

        public SimpleList(string value1, string value2, string value3, string value4, string value5)
        {
            Append(value1);
            Append(value2);
            Append(value3);
            Append(value4);
            Append(value5);
        }

        public SimpleList(string value1, string value2)
        {
            Append(value1);
            Append(value2);
        }
        #endregion

        #region Öffentliche Methoden
        public void Append(string newValue)
        {
            if (head.next == null)
            {
                head.next = new Node(newValue);
            }
            else
            {
                currentNode = head.next;

                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }
                counterNode++;
                currentNode.next = new Node(newValue);
            }
        }

        public void Prepend(string newValue)
        {
            Node newNode = new Node(newValue);
            newNode.next = head.next;

            head.next = newNode;
            counterNode++;
        }

        public string[] GetValues()
        {
            string[] data = new string[(counterNode + 1)];
            int idx = 0;

            currentNode = head.next;

            while (currentNode != null)
            {
                data[idx] = currentNode.value;
                currentNode = currentNode.next;
                idx++;
            }

            return data;
        }

        public int Count()
        {
            int Count = 0;
            Node currentNode = head;

            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
                Count++;
            }

            return Count;
        }

        public string GetValueAt(int Position)
        {
            if((Position < 0) || (Position > (counterNode + 1)))
            {
                throw new Exception(" steht nichts!!!");
            }

            currentNode = head.next;

            int idx = 0;

            while (idx < (Position))
            {
                currentNode = currentNode.next;
                idx++;
            }

            return currentNode.value;
        }

        public string[] GetValues(bool sortiert)
        {
            string[] DataUmgekehrt = new string[(counterNode + 1)];
            int idx = counterNode;

            currentNode = head.next;

            while (currentNode != null)
            {
                DataUmgekehrt[idx] = currentNode.value;
                currentNode = currentNode.next;
                idx--;
            }
            sortiert = true;

            return DataUmgekehrt;
        }

        public void DeleteNode(int PositionDelete)
        {
            currentNode = head.next;
            int idx = 0;

            while (idx < (PositionDelete - 2))
            {
                currentNode = currentNode.next;
                idx++;
            }

            currentNode.next = currentNode.next.next;
            
            counterNode--;
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructuresLIB
{
    public class SimpleList
    {
        #region Eigenschaften
        private Node head = new Node(0);
        private int counterNode;
        Node currentNode = null;
        #endregion

        #region Klasse Node
        class Node
        {
            public Node next;
            public int value;

            public Node(int NewValue)
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

        public SimpleList(int value1, int value2, int value3, int value4, int value5)
        {
            Append(value1);
            Append(value2);
            Append(value3);
            Append(value4);
            Append(value5);
        }

        public SimpleList(int value1, int value2)
        {
            Append(value1);
            Append(value2);
        }
        #endregion

        #region Öffentliche Methoden
        public void Append(int newValue)
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

        public void Prepend(int newValue)
        {
            Node newNode = new Node(newValue);
            newNode.next = head.next;

            head.next = newNode;
            counterNode++;
        }

        public int[] GetValues()
        {
            int[] data = new int[(counterNode + 1)];
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

        public int GetValueAt(int Position)
        {
            if ((Position < 0) || (Position > (counterNode + 1)))
            {
                throw new Exception(" steht nichts!!!");
            }

            currentNode = head.next;

            int idx = 0;

            while (idx < (Position - 1))
            {
                currentNode = currentNode.next;
                idx++;
            }

            return currentNode.value;
        }

        public int[] GetValues(bool sortiert)
        {
            int[] DataUmgekehrt = new int[(counterNode + 1)];
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

        public bool ContainSimpleList(int Value)
        {
            bool found = false;
            currentNode = head.next;

            while (currentNode !=  null)
            {
                if (currentNode.value == Value)
                {
                    found = true;
                }
                currentNode = currentNode.next;
            }
            return found;
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


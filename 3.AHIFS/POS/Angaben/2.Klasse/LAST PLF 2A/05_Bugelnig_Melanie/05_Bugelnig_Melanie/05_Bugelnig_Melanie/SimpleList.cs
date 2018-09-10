using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _05_Bugelnig_Melanie
{
    public class SimpleList
    {
        #region Eingebettete Klasse
        class Node
        {
            #region Eigneschaften
            public Node next;
            public int value;
            #endregion

            #region konstruktor(en)
            public Node(int newValue)
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
        public int Count
        {
            get { return length; }
        }
        #endregion

        #region konstruktor(en)
        public SimpleList()
        {
            head = null;
        }
        public SimpleList(params int[] values)
        {
            for (int counter = 0; counter < values.Length; counter++)
            {
                Append(values[counter]);
            }
        }

        public SimpleList(List<int> values)
        {
            foreach (int i in values)
            {
                Append(i);
            }
        }
        #endregion

        #region PublicMethods
        public void Append(int newValue)
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

        public void Prepend(int newValue)
        {
            Node newNode = new Node(newValue);
            newNode.next = head;
            head = newNode;
            length++;
        }

        public int GetValueAt(int idx)
        {
            if (IsEmpty())
            {
                IsEmptyException();
            }
            Node currentNode = getReferenceAt(idx);
            return currentNode.value;
        }

        public int[] GetValues(bool inverted = false)
        {
            Node pointer = head;
            int[] data = new int[length];
            if (IsEmpty())
            {
                IsEmptyException();
            }
            for (int counter = 0; counter < length; counter++)
            {
                data[counter] = pointer.value;
                pointer = pointer.next;
            }
            if (inverted)
            {
                int[] tempint = new int[data.Length];
                for (int counter = 0; counter < data.Length; counter++)
                {
                    tempint[counter] = data[(data.Length - 1) - counter];
                }
                data = tempint;
            }
            return data;
        }

        public void DeleteNode(int idx)
        {
            if (IsEmpty())
            {
                IsEmptyException();
            }
            if (idx == 0)
            {
                head.next = head.next.next;
            }
            else
            {
                Node currentNode = getReferenceAt(idx - 1);
                currentNode.next = getReferenceAt(idx).next;
            }
            length--;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void InsertAt(int idx, int value)
        {
            if (idx > length || idx < 0)
            {
                throw new Exception("Der Index liegt auserhalb der Liste!");
            }
            if (idx == 0)
            {
                Prepend(value);
            }
            else if (idx < length)
            {
                Node newNode = new Node(value);
                newNode.next = getReferenceAt(idx);
                getReferenceAt(idx - 1).next = newNode;
                length++;
            }
            else
            {
                Append(value);
            }
        }
        #endregion
        

        #region privateMethods
        private Node getReferenceAt(int idx)
        {
            Node currentnode = head;
            if (IsEmpty())
            {
                IsEmptyException();
            }
            if (idx > Count)
            {
                throw new Exception("Der index ist größer als die Liste");
            }
            for (int counter = 0; counter < idx; counter++)
            {
                currentnode = currentnode.next;
            }
            return currentnode;
        }

        private void IsEmptyException()
        {
            throw new Exception("Die Liste Ist Leer!");
        }
        #endregion
    }
}

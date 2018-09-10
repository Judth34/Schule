using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Berisa_ValonPLF
{
    class SimpleList
    {
        #region Node
        private class Node
        {
            public Node(string NewValue)
            {
                Value = NewValue;
            }
            public string Value { get; set; }
            public Node Next { get; set; }
        }

        private Node currentNode;
        private Node head;

        #endregion

        #region Konstruktoren
        public SimpleList()
        {
            head = null;
            Count = 0;
        }
        public SimpleList(params string[] NodeArray)
        {
            head = null;
            Count = 0;

            int idx = 0;

            while (idx < NodeArray.Length)
            {
                Append(NodeArray[idx]);
                idx++;
            }
        }

        #endregion 

        #region Properties

        public int Count { get; private set; }

        #endregion

        #region Public Methods

        public void Append(string newValue)
        {
            Node NewNode = new Node(newValue);
            Count++;

            if (head == null)
            {
                head = NewNode;
            }
            else
            {
                Node Current = head;

                while (Current.Next != null)
                {
                    Current = Current.Next;
                }

                Current.Next = NewNode;
            }

        }
        public void Prepend(string newValue)
        {
            if (head == null)
            {
                throw new Exception("Keine Liste erzeugt!!");
            }

            Count++;
            Node NewNode = new Node(newValue);
            swap(NewNode);

        }
        public string[] GetValues(bool result)
        {
            int i = Count - 1;
            string[] data = new string[Count];
            currentNode = head;

            if (head == null)
            {
                throw new Exception("Liste ist leer ! ");
            }

            else if (result == false)
            {
                throw new Exception("Sie muessen true eingeben !");
            }

            else
            {
                while (currentNode.Next != null)
                {
                    data[i] = currentNode.Value;
                    currentNode = currentNode.Next;
                    i--;
                }

                data[i] = currentNode.Value;

            }

            return data;
        }            
        public string[] GetValues()
        {
            int i = 0;
            string[] Data = new string[Count];

            currentNode = head;
            while (currentNode.Next != null)
            {
                Data[i] = currentNode.Value;
                currentNode = currentNode.Next;
                i++;
            }

            Data[i] = currentNode.Value;
            return Data;
        }      
        private void swap(Node Element)
        {
            currentNode = Element;
            Node help = head;
            head = currentNode;
            currentNode.Next = help;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SimpleList
    {
        public class Node
        {
            public string Value { get; set; }
            public Node Next { get; set; }

            public Node(string Value)
            {
                this.Value = Value;
            }
        }

        Node head;

        public SimpleList()
        {
            head = null;
            Counter = 0;
        }

        public SimpleList(params string[] NumberOfElements)
        {
            head = null;
            Counter = 0;
        }

        public int Counter
        {
            get;
            private set;
        }

        public double GetAverage()
        {
            double summe = 0;
            float average;

            if(head == null)
            {
                throw new Exception("Keine Elemente in der Liste vorhanden");
            }
            else
            {
                Node currentNode = head;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                    summe = summe + Value;
                    Counter++;
                }

                average = (float)summe / Counter;
            }

            return average;
        }
    }
}

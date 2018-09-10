using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF_LIB
{
    public class SimpleTree
    {
        #region Eigenschaften

        private Node root;

        #endregion

        #region Private-Class Node

        private class Node
        {
            public int Value;
            public Node Left;
            public Node Right;

            public Node(int NewValue)
            {
                Value = NewValue;
            }
        }

        #endregion 

        #region Konstruktoren

        public SimpleTree()
        {
            root = null;
        }

        #endregion

        #region Public-Methods

        //Start-Funktionen
        public void Add(int value)
        {
            add(value, root);
        }
        public List<int> GetValues()
        {
            List<int> List = new List<int>();
            getValues(List, root);
            return List;
        }

        public double getAverage()
        {
            double total = 0;
            int Size = 0;

            //Werte zusammenzählen
            foreach (int I in GetValues())
            {
                Size++;
                total += I;
            }

            return total / Size;
        }

        #endregion

        #region Private-Methods

        private void add(int Value, Node CurrentNode)
        {
            //Leerer Baum
            if (root == null)
            { root = new Node(Value); }

            //Wert ist kleiner
            else if (Value < CurrentNode.Value)
            {
                if (CurrentNode.Left != null) //Umständlich
                { add(Value, CurrentNode.Left); }

                else
                { CurrentNode.Left = new Node(Value); }
            }

            //Wert ist größer
            else if (Value > CurrentNode.Value)
            {
                if (CurrentNode.Right == null)
                { CurrentNode.Right = new Node(Value); }

                else
                { add(Value, CurrentNode.Right); }
            }

            //Wert ist gleich
            else
            {
                if (CurrentNode.Right == null)
                { CurrentNode.Right = new Node(Value); }

                else
                { add(Value, CurrentNode.Right); }
            }
            //else if (Value > CurrentNode.Value)
            //{ throw new Exception("Der Wert existiert bereits!"); }
        }

        private void getValues(List<int> List, Node node) //In Order
        {
            if (node != null)
            {
                //Links
                getValues(List, node.Left);

                //Wert
                List.Add(node.Value);

                //Rechts
                getValues(List, node.Right);
            }
        }

        #endregion
    }
}

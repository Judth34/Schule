using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Binarytree
    {
        #region eingebettete Klasse
        class Element
        {
            public int value;
            public Element rightNext = null;
            public Element leftNext = null;

            public Element(int Newvalue)
            {
                value = Newvalue;
            }
        }
        #endregion

        #region Eigenschaften
        Element root = null;
        #endregion

        #region öffentliche Methoden
        public void Add(int NewValue)
        {
            if (root == null)
            {
                root = new Element(NewValue);
            }
            else add(NewValue, root);
        }

        public bool Search(int Value)
        {

            return search(Value, root);
        }

        public int PreOrder()
        {
            return preOrder(root, 0);
        }


        #endregion

        #region private Methoden
        private void add(int newValue, Element currendElement)
        {
            if (newValue <= currendElement.value)
            {
                if (currendElement.leftNext == null)
                {
                    currendElement.leftNext = new Element(newValue);
                }
                else
                    add(newValue, currendElement.leftNext);
            }
            else
                if (newValue > currendElement.value)
            {
                if (currendElement.rightNext == null)
                {
                    currendElement.rightNext = new Element(newValue);
                }
                else
                    add(newValue, currendElement.rightNext);
            }

        }
        private bool search(int value, Element currendElement)
        {
            if (value == currendElement.value) return true;
            if (value < currendElement.value && currendElement.leftNext != null) return search(value, currendElement.leftNext);
            if (value > currendElement.value && currendElement.rightNext != null) return search(value, currendElement.rightNext);

            return false;
        }

       private int preOrder(Element currendElement, int value)
        {
            if (currendElement != null)
            {
                value = preOrder(currendElement.leftNext, value);
                value = preOrder(currendElement.rightNext, value);
                value += currendElement.value;
            }
            return value;
        }

        
        }

        #endregion
    }


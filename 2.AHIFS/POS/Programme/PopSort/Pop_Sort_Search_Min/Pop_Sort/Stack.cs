using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pop_Sort
{
    class Stack
    {
        #region Eigenschaften
        int[] data = null;
        int stackSize = 0;
        int topOfStack = 0;
        static int StandardStackSize = 0;
        bool Geordnet = false;
        #endregion

        #region Kostruktor(en)
        public Stack(int Stacksize)
        {
            if (StackSize < 0)
            {
                throw new Exception("Stack Größe darf nicht < null sein");
            }
            else
            {
                stackSize = Stacksize;
                data = new int[stackSize];
            }
        }

        public Stack()
        {
            StandardStackSize = 6;
            data = new int[StandardStackSize];
        }
        #endregion

        #region Properties
        public int StackSize
        {
            private set
            {
                stackSize = value;
            }

            get
            {
                return stackSize;
            }
        }

        public object prop { get; private set; }
        public object proper { get; private set; }
        #endregion

        #region Öffentliche Methoden
        public bool IsFull()
        {
            return (topOfStack == stackSize);
        }

        public bool IsEmpty()
        {
            return (topOfStack == 0);
        }

        public void Push(int NewElement)
        {
            if (IsFull())
            {
                throw new Exception("Stack ist bereits voll");
            }

            data[topOfStack] = NewElement;
            topOfStack++;
            Geordnet = false;
        }

        public void Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack ist bereits leer");
            }

            if (Geordnet == false)
            {
                if (topOfStack >= 1)
                {
                    Ordnen();
                    Geordnet = true;
                }
            }

            data[(topOfStack - 1)] = 0;
            topOfStack--;
        }
        #endregion

        #region Private Methoden
        private void Ordnen()
        {
            int hilfsvariable = 0; 
            int counterKleinstesElementImStackSuchen = 0;
            int kleinstesElement = 0;
            int counterStackInsgesamtdurchlaufen = 0;
            
            while (counterStackInsgesamtdurchlaufen < (topOfStack - 1))
            {
                counterKleinstesElementImStackSuchen = (topOfStack - 1);
                kleinstesElement = data[counterKleinstesElementImStackSuchen];
                while (counterKleinstesElementImStackSuchen > (0 + counterStackInsgesamtdurchlaufen))
                {
                    if (data[counterKleinstesElementImStackSuchen - 1] < kleinstesElement)
                    {
                        hilfsvariable = kleinstesElement;
                        kleinstesElement = data[counterKleinstesElementImStackSuchen - 1];
                        data[counterKleinstesElementImStackSuchen - 1] = hilfsvariable;
                    }
                    counterKleinstesElementImStackSuchen--;
                }
                for(int idx = (topOfStack - 1); idx > (0 + counterStackInsgesamtdurchlaufen); idx--)
                {
                    data[idx] = data[idx - 1];
                }
                data[counterStackInsgesamtdurchlaufen] = kleinstesElement;
                counterStackInsgesamtdurchlaufen++;
            }
        }
        #endregion
    }
}
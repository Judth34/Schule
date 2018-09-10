using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedStack_Solition1
{
    class SortStack
    {
        #region Objektvariablen

        private int[] stack;
        private int topOfStack;
        private int size;  
        private static int sizeMin = 1;
        private static int sizeMax = 100;
        private static int standardSize = 20;
        private bool sorted = true; 
        #endregion

        #region Konstruktor(en)

        public SortStack()
        {
            craeteStack(standardSize);
        }

        public SortStack(int Size)
        {
            craeteStack(Size);
        }
        #endregion

        #region Properties

        public int Size
        {
            get { return Size; }
        }

        #endregion

        #region Methoden

        private void craeteStack(int Size)
        {
            if (Size < sizeMin || Size > sizeMax)
            {
                throw new Exception("Die Groesse ist Ausserhalb der gueltigen Wertebereichs ("+sizeMin+"-"+sizeMax+")");
            }

            stack = new int[Size];
            size = Size;
            topOfStack = - 1;
        }

        public bool IsFull()
        {
            bool Status = false;

            if(topOfStack == (size - 1))
            {
                Status = true;
            }

            return Status;
        }

        public bool IsEmpty()
        {
            bool Status = false;

            if (topOfStack == -1)
            {
                Status = true;
            }
            return Status;
        }

        public int Pop()
        {
            if(IsEmpty() == true)
            {
                throw new Exception("Der Stack ist leer du kannst nichts mehr entfernen");
            }
            int DeletedObject;
            DeletedObject = stack[topOfStack];
            stack[topOfStack] = 0;
            topOfStack--;
            return DeletedObject;
        }

        public int SortPopV1()
        {
            int DeletedElement;
            int Postion;
            if(IsEmpty() == true)
            {
                throw new Exception("Der Stack ist leer sie können kein weiteres Elemnt auf den Stack legen");
            }
            else if(sorted == true)
            {
                DeletedElement = stack[topOfStack];
                stack[topOfStack] = 0;
                topOfStack--;
            }
            else
            {
                for(int LastIdx = 0; LastIdx < topOfStack; LastIdx++)
                {
                    Postion = search(LastIdx);
                    swarp(Postion, LastIdx);
                }

                DeletedElement = stack[topOfStack];
                stack[topOfStack] = 0;
                topOfStack--;
                sorted = true;
            }

            return DeletedElement;
        }

        public int SortPopV2()
        {
            if (IsEmpty())
            {
                throw new Exception("Der Stack ist leer Sie können keine weiteren Elemente entfernen");
            }

            if (!sorted)
            {
                sortV2();
                sorted = true;
            }

            topOfStack--;
            return stack[topOfStack];
        }

        public void Push(int Wert)
        {
            if (IsFull())
            {
                throw new Exception("Der Stack ist voll, du kannst kein weiteres Element auf den Stack legen");
            }
            topOfStack++;
            stack[topOfStack] = Wert;

            if(stack[topOfStack] < stack[topOfStack-1])
            {
                sorted = false;
            }
            
        }

        public void SortPush(int Wert)
        {
            if(IsFull() == true)
            {
                throw new Exception("Der Stack ist voll sie können kein weiteres Elemnt drauf legen");
            }
            else
            {
                topOfStack++;
                stack[topOfStack] = Wert;

                for (int CounterIdx = topOfStack; CounterIdx > 0; CounterIdx--)
                {
                    if(stack[CounterIdx] < stack[CounterIdx - 1])
                    {
                        swarp(CounterIdx, (CounterIdx - 1));
                    }
                }
            }
        }

        private void swarp(int FirstIdx, int SecondIdx)
        {
            int Help;
            Help = stack[FirstIdx];
            stack[FirstIdx] = stack[SecondIdx];
            stack[SecondIdx] = Help;
        }

        public int search(int StartPosition)
        {
            int Position = StartPosition;
            for(int CounterIdx = StartPosition; CounterIdx < topOfStack; CounterIdx++)
            {
                if(stack[CounterIdx + 1] < stack[Position])
                {
                    Position = (CounterIdx + 1);
                }
            }
            return Position;
        }

        private void sortV2()
        {
            int CounterSwap;
            do
            {
                CounterSwap = 0;

                for (int CounterIdx = 0; CounterIdx < topOfStack; CounterIdx++)
                {
                    if (stack[CounterIdx] > stack[CounterIdx + 1])
                    {
                        swarp(CounterIdx, (CounterIdx + 1));
                        CounterSwap++;
                    }
                }
            } while (CounterSwap > 0);
        }
        #endregion
    }
}


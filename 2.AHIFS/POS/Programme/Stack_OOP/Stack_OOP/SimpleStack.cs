﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_OOP
{
    class SimpleStack
    {
        #region Eigenschaften
        int[] data;
        int stackSize;
        int topOfStack;
        int stackSizeMin;
        int stackSizeMax;
        #endregion

        #region Kostruktor(en)
        public SimpleStack(int StackSize)
        {
            stackSizeMin = 0;
            stackSizeMax = 20;
            stackSize = StackSize;
            topOfStack = 0;
            if (stackSize < stackSizeMin || stackSize > stackSizeMax)
            {
                throw new Exception(
                    String.Format("Ungueltiger Wert! Waehlen Sie einen Wert im Wertebereich [{0}, {1}]", stackSizeMin, stackSizeMax));
            }
            data = new int[stackSize];
        }

        public SimpleStack()
        {
            stackSize = 2;
            topOfStack = 0;
            data = new int[stackSize];
        }
        #endregion

        #region Properties
        public int SizeOfStack
        {
            get { return stackSize; }
            set
            {
                if (value > 0 && value < 20)
                {
                    stackSize = value;
                    data = new int[stackSize];
                }
            }
        }
        #endregion

        #region öffentliche Methoden
        public bool IsFull()
        {
            return (topOfStack == stackSize);
        }

        public bool IsEmpty()
        {
            return (topOfStack == 0);
        }

        public int GetElement()
        {
            return data[(topOfStack - 1)];
        }

        public void Push(int NewElement)
        {
            if (IsFull())
            {
                throw new Exception("Array zu klein!");
            }

            data[topOfStack] = NewElement;
            topOfStack++;
        }

        public void Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Alle Werte wurden bereits geloescht");
            }
            data[(topOfStack - 1)] = 0;
            topOfStack--;
        }

        public int Find(int SuchendeZahl)
        {
            int AnzahlDerZahl = 0;
            for (int counter = 0; counter < stackSize; counter++)
            {
                if (data[counter] == SuchendeZahl)
                {
                    AnzahlDerZahl++;
                }
            }
            return AnzahlDerZahl;
        }

        public int Resize(int Wert, int Wertaenderung)
        {
            if (Wert == 1)
            {
                stackSize -= Wertaenderung;
                if (stackSize < 0)
                {
                    throw new Exception(
                        String.Format("Array zu klein"));
                }
            }

            if (Wert == 0)
            {
                stackSize += Wertaenderung;
            }
            data = new int[stackSize];
            return stackSize;
        }

        public SimpleStack Copy()
        {
            int[] data2 = new int [stackSize];
            SimpleStack stackCopy = new SimpleStack(stackSize);

            for(int i = 0; i < stackSize; i++)
            {
                data2[i] = data[i];
                Console.WriteLine(data2[i]);
            }
            return stackCopy;
        }

        public SimpleStack Merge(SimpleStack Stack2)
        {
            SimpleStack MergeStack = null;
            int[] dataMerge = null;
            MergeStack = new SimpleStack((Stack2.SizeOfStack + SizeOfStack));
            dataMerge = new int[MergeStack.SizeOfStack];

            int IdxStack1 = 0;
            int IdxStack2 = 0;
            int IdxStackMerge = 0;

            while (IdxStack1 < data.Length)
            {
                if (data[IdxStack1] == 0)
                {
                    IdxStack1 = data.Length;
                }
                else
                {
                    if(data[IdxStack1] != 0)
                    {
                        dataMerge[IdxStackMerge] = data[IdxStack1];
                        IdxStack1++;
                        IdxStackMerge++;
                    }
                }
            }

            while(IdxStack2 < Stack2.data.Length)
            {
                dataMerge[IdxStackMerge] = Stack2.data[IdxStack2];
                IdxStackMerge++;
                IdxStack2++;
            }

            return MergeStack;  
        }
        #endregion
    }
}


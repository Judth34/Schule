using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testprogramm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Funktioniert die Methode IsFull()? " + TestCase_IsFull());
            Console.WriteLine("Funktioniert die Methode IsEmpty()? " + TestCase_IsEmpty());
            Console.WriteLine("Funktioniert die Methode Push()? " + TestCase_Push());
            Console.WriteLine("Funktioniert die Methode Pop()? " + TestCase_Pop());
            Console.WriteLine("Funktioniert die Methode GetElement()? " + TestCase_GetElement());
            Console.WriteLine("Funktioniert die Methode Copy()? " + TestCase_Copy());
            Console.WriteLine("Funktioniert die Methode Merge()? " + TestCase_Merge());
            Console.WriteLine("Funktioniert die Methode Find()? " + TestCase_Find());
            Console.WriteLine("Funktioniert die Methode Resize()? " + TestCase_Resize());
        }

        #region Testcases

        static bool TestCase_IsFull()       //Gragger Nicolas
        {
            SimpleStack stackIsFull = new SimpleStack(1);
            bool result = true;
            if (stackIsFull.IsFull())
            {
                result = false;
            }
            stackIsFull.Push(5);
            if (!stackIsFull.IsFull())
            {
                result = false;
            }
            return result;
        }

        static bool TestCase_IsEmpty()      //Drabosenig Andreas
        {
            bool result = false;
            SimpleStack s1 = new SimpleStack(10);
            if (s1.IsEmpty() == true)
            {
                result = true;
            }
            return result;
        }

        private static bool TestCase_Push()     //Valon Berisa
        {
            int pushElement = 7;
            SimpleStack s1 = new SimpleStack(5);

            s1.Push(pushElement);

            return (s1.GetElement() == pushElement);
        }

        static bool TestCase_Pop()          //Hebein Fabian
        {
            SimpleStack Stack1 = new SimpleStack(10);
            bool status = true;

            int zahl = 5;

            Stack1.Push(zahl);
            if (Stack1.Pop() != zahl)
                status = false;
            else
            {
                if (Stack1.IsEmpty())
                {
                    status = false;
                    try
                    {
                        Stack1.Pop();
                    }
                    catch
                    {
                        status = true;
                    }
                }
            }

            return status;

        }

        static bool TestCase_Find()         //Breschan Moritz
        {   //rgw gibt an wie viele Elemente gefunden wurde
            bool rgw = true;
            SimpleStack s1 = new SimpleStack(20);
            int counter = 0;
            for (counter = 0; counter < 10; counter++)
            {
                s1.Push(counter);
            }
            for (counter = 9; counter >= 0; counter--)
            {
                s1.Push(counter);
            }
            counter = 0;
            while (counter < 10 && rgw)
            {
                if (s1.Find(counter) != 2)
                {
                    rgw = false;
                }
                counter++;
            }
            return rgw;
        }

        static bool TestCase_Copy()         //Fahrngruber Samuel
        {
            int capacity = 100;
            int numberOfElements = 50;
            bool result = false;
            SimpleStack s1 = new SimpleStack(capacity);
            SimpleStack s2;
            int idx;
            for (idx = 0; idx < numberOfElements; idx++)
            {
                s1.Push(idx);
            }
            s2 = s1.Copy();
            if (s1 != s2)
            {
                result = true;
            }
            while (result == true && idx > 0)
            {
                try
                {
                    if (s1.Pop() != s2.Pop())
                    {
                        result = false;
                    }
                }
                catch
                {
                    result = false;
                }
                idx--;
            }
            return result;
        }

        static bool TestCase_Merge()        //Kandut Nico
        {   //der 2. Stack wird auf den 1. gesetzt
            bool result = true;
            int testwert;
            SimpleStack SimpleStack01;
            SimpleStack SimpleStack02;
            SimpleStack ResultingStack;
            int idxCounter = 0;

            testwert = 3;
            SimpleStack01 = new SimpleStack(testwert + 4);
            SimpleStack02 = new SimpleStack(testwert);

            for (idxCounter = 0; idxCounter < testwert - 1; idxCounter++)
            {
                SimpleStack01.Push(idxCounter);
                SimpleStack02.Push(idxCounter + 10);
            }

            ResultingStack = SimpleStack01.Merge(SimpleStack02);

            idxCounter = 0;

            try
            {
                while (result && idxCounter > testwert)
                {
                    if (ResultingStack.Pop() != SimpleStack02.Pop())
                    {
                        result = false;
                    }
                    idxCounter--;
                }

                while (result && idxCounter > 0)
                {

                    if (ResultingStack.Pop() != SimpleStack01.Pop())
                    {
                        result = false;
                    }
                    idxCounter--;
                }
            }
            catch
            {
                result = false;
            } 

            return result;
        }

        private static bool TestCase_Resize()     //Melanie Bugelnig
        {
            int newCapacity = 5;
            SimpleStack s1 = new SimpleStack(newCapacity);
            bool result = true;
            int counter;

            for (counter = 0; counter < newCapacity; counter++)
            {
                s1.Push(counter);
            }

            newCapacity = 10;

            s1.Resize(newCapacity);

            for (; counter < newCapacity; counter++)
            {
                s1.Push(counter);

            }

            counter--;

            if (s1.Pop() != counter)
            {
                result = false;
            }

            counter--;


            return result;
        }

        static bool TestCase_GetElement()   // Julian Blaschke
        {
            SimpleStack stack1 = new SimpleStack();

            stack1.Push(13);

            if (!(stack1.GetElement() == 13))
            {
                return false;
            }


            return true;
        }

        #endregion
    }
}

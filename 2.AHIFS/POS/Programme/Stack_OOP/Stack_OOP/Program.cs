using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Eigenschaften
            SimpleStack s1 = null;
            int StackSize = 0;
            int Auswahl = 0;
            int Element = 0;
            int SuchendesElement = 0;
            int GroesserOderKleinerer = 0;
            int Wertaenderung = 0;
            int AuswahlStack = 0;
            SimpleStack Stack2 = null;
            #endregion

          //  #region Tests
          //  Console.WriteLine("TestCase_IsFull" + TestCase_IsFull());
          //  Console.WriteLine("TestCase_IsEmpty" + TestCase_IsEmpty());
          //  Console.WriteLine("TestCase_GetElement" + TestCase_GetElement(s1));
          ////  Console.WriteLine("TestCasePop" + TestCasePop());
          //  Console.WriteLine("RunTestCasePush" + RunTestCasePush());
          //  Console.WriteLine("TestCaseFind" + TestCaseFind());
          ////  Console.WriteLine("TestCaseCopy" + TestCaseCopy());
          //  Console.WriteLine("Testcase_Merge" + Testcase_Merge());
          //  #endregion

            #region Erzeugen
            StackSize = GetAValid(1,20, "Welche Groesse soll Ihr Stack haben?");
            
            try
            {
                s1 = new SimpleStack(StackSize);
            }
            catch (Exception StackSizeFail)
            {
                Console.WriteLine("Fehler: " + StackSizeFail.Message);
            }

            StackSize = GetAValid(1, 20, "Welche Groesse soll Ihr 2.Stack haben?");
            try
            {
                Stack2 = new SimpleStack(StackSize);
            }
            catch (Exception StackSizeFail)
            {
                Console.WriteLine("Fehler: " + StackSizeFail.Message);
            }
            #endregion

            #region Menue
            do
            {
                Auswahl = GetAValid(0, 9, "Push = 1\nPop = 2\nFind = 3\nGetElement = 4\nResize = 5\nCopy = 6\nMerge = 7\nIs Full = 8\nIs Empty = 9");
                switch (Auswahl)
                {
                    #region Push
                    case 1:
                        try
                        {
                            AuswahlStack = GetAValid(1, 2, "1. oder 2. Stack");
                            Element = GetAValid(1, 100, "Welche Zahl moechtest du hinzufuegen?");
                            if(AuswahlStack == 1)
                            {
                                s1.Push(Element);
                                Console.WriteLine("Element " + Element + " wurde zum 1.Stack hinzugefuegt");
                            }
                            else
                            {
                                if (AuswahlStack == 2)
                                {
                                    Stack2.Push(Element);
                                    Console.WriteLine("Element " + Element + " wurde zum 2.Stack hinzugefuegt");
                                }
                            }
                           
                            Console.WriteLine("Klicken um fortzufahren!");
                            Console.ReadLine();
                        }
                        catch (IndexOutOfRangeException StackFail2)
                        {
                            Console.WriteLine("Fehler: " + StackFail2.Message);
                        }
                        
                        break;
                    #endregion
                    #region Pop
                    case 2:
                        try
                        {
                            AuswahlStack = GetAValid(1, 2, "1. oder 2. Stack");
                            if (AuswahlStack == 1)
                            {
                                s1.Pop();
                                Console.WriteLine("Element wurde aus 1.Stack geloescht!");
                            }
                            else
                            {
                                if (AuswahlStack == 2)
                                {
                                    Stack2.Pop();
                                    Console.WriteLine("Element wurde aus 2.Stack geloescht!");
                                }
                            }

                            Console.WriteLine("Klicken um fortzufahren!");
                            Console.ReadLine();
                        }
                        catch (IndexOutOfRangeException StackFail3)
                        {
                            Console.WriteLine("Fehler: " + StackFail3.Message);
                        }
                        break;
                    #endregion
                    #region Find
                    case 3:
                        AuswahlStack = GetAValid(1, 2, "1. oder 2. Stack");
                        SuchendesElement = GetAValid(1, 100, "Welche Zahl willst du suchen?");
                        if (AuswahlStack == 1)
                        {
                            Console.WriteLine("Die Zahl wurde " + s1.Find(SuchendesElement) + "-mal im 1.Stack gefunden.");
                        }
                        else
                        {
                            if (AuswahlStack == 2)
                            {
                                Console.WriteLine("Die Zahl wurde " + Stack2.Find(SuchendesElement) + "-mal im 2.Stack gefunden");
                            }
                        }                   
                        
                        Console.WriteLine("Klicken um fortzufahren!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region GetElement
                    case 4:
                        AuswahlStack = GetAValid(1, 2, "1. oder 2. Stack");
                        if (AuswahlStack == 1)
                        {
                            Console.WriteLine("Letztes Element (1.Stack) = " + s1.GetElement());
                        }
                        else
                        {
                            if (AuswahlStack == 2)
                            {
                                Console.WriteLine("Letztes Element (2. Stack) = " + Stack2.GetElement());
                            }
                        }                      
                        
                        Console.WriteLine("Klicken um fortzufahren!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Resize
                    case 5:
                        AuswahlStack = GetAValid(1, 2, "1. oder 2. Stack");
                        if (AuswahlStack == 1)
                        {
                            GroesserOderKleinerer = GetAValid(0, 1, "Moechtest du den 1.Stack vergroessern(0) oder verkleinern(1)");
                            Wertaenderung = GetAValid(1, 10, "Um wie viel moechten Sie den 1.Stack vergroessern bzw. verkleinern");
                            Console.WriteLine("Neue Groesse (1.Stack) = " + s1.Resize(GroesserOderKleinerer, Wertaenderung));
                        }
                        else
                        {
                            if (AuswahlStack == 2)
                            {
                                GroesserOderKleinerer = GetAValid(0, 1, "Moechtest du den 2.Stack vergroessern(0) oder verkleinern(1)");
                                Wertaenderung = GetAValid(1, 10, "Um wie viel moechten Sie den 2.Stack vergroessern bzw. verkleinern");
                                Console.WriteLine("Neue Groesse (2.Stack) = " + Stack2.Resize(GroesserOderKleinerer, Wertaenderung));
                            }
                        }
                        
                        
                            Console.WriteLine("Klicken um fortzufahren!");
                            Console.ReadLine();
                            break;
                    #endregion
                    #region Copy
                    case 6:
                        AuswahlStack = GetAValid(1, 2, "1. oder 2. Stack");
                        SimpleStack StackCopy = null;
                        if (AuswahlStack == 1)
                        {
                            StackCopy = new SimpleStack(s1.SizeOfStack);
                            s1.Copy();
                            
                        }
                        else
                        {
                            if (AuswahlStack == 2)
                            {
                                StackCopy = new SimpleStack(s1.SizeOfStack);
                                Stack2.Copy();
                            }
                        }
                       
                        Console.WriteLine("Klicken um fortzufahren!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Merge
                    case 7:
                        s1.Merge(Stack2);
                        Console.WriteLine("Klicken um fortzufahren!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region IsFull
                    case 8:
                        AuswahlStack = GetAValid(1, 2, "1. oder 2. Stack");
                        if (AuswahlStack == 1)
                        {
                            Console.WriteLine("Is Stack1 Full? = " + s1.IsFull());
                        }
                        else
                        {
                            if (AuswahlStack == 2)
                            {
                                Console.WriteLine("Is Stack2 Full? = " + Stack2.IsFull());
                            }
                        }

                        Console.WriteLine("Klicken um fortzufahren!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region IsEmpty
                    case 9:
                        AuswahlStack = GetAValid(1, 2, "1. oder 2. Stack");
                        if (AuswahlStack == 1)
                        {
                            Console.WriteLine("Is Stack1 Empty? = " + s1.IsEmpty());
                        }
                        else
                        {
                            if (AuswahlStack == 2)
                            {
                                Console.WriteLine("Is Stack2 Empty? = " + Stack2.IsEmpty());
                            }
                        }

                        Console.WriteLine("Klicken um fortzufahren!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Default
                    default:
                        break;
                        #endregion
                }
                Console.Clear();
            } while (Auswahl != 0);
            #endregion

            Console.WriteLine("Beendet");
        }
        static int GetAValid(int min, int max, string Eingabe)
        {
            int i;
            bool result;

            do
            {
                Console.WriteLine(Eingabe);
                result = int.TryParse(Console.ReadLine(), out i);

            } while (i < min || i > max || result == false);
            return i;

        }

        //static bool TestCaseCopy()
        //{
        //    int capacity = 100;
        //    int numberOfElements = 50;
        //    bool result = false;
        //    SimpleStack s1 = new SimpleStack(capacity);
        //    SimpleStack s2;
        //    int idx;
        //    for (idx = 0; idx < numberOfElements; idx++)
        //    {
        //        s1.Push(idx);
        //    }
        //    s2 = s1.Copy();
        //    if (s1 != s2)
        //    {
        //        result = true;
        //    }
        //    while (result == true && idx > 0)
        //    {
        //        try
        //        {
        //            if (s1.Pop() != s2.Pop())
        //            {
        //                result = false;
        //            }
        //        }
        //        catch
        //        {
        //            result = false;
        //        }
        //        idx--;
        //    }
        //    return result;
        //}

        //static bool TestCaseFind()  //Moritz Breschan
        //{
        //    bool rgw = true;
        //    SimpleStack s1 = new SimpleStack(20);
        //    int counter = 0;
        //    for (counter = 0; counter < 10; counter++)
        //    {
        //        s1.Push(counter);
        //    }
        //    for (counter = 9; counter >= 0; counter--)
        //    {
        //        s1.Push(counter);
        //    }
        //    counter = 0;
        //    while (counter < 10 && rgw)
        //    {
        //        if (s1.Find(counter) != 2)
        //        {
        //            rgw = false;
        //        }
        //        counter++;
        //    }
        //    return rgw;
        //}

        //static bool TestCase_GetElement(SimpleStack stack1) // Julian Blaschke
        //{
        //    if ((stack1.IsEmpty() == true) && (stack1.GetElement() != 0))
        //    {
        //        return false;

        //    }

        //    stack1.Push(13);

        //    if (!(stack1.GetElement() == 13))
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        //static bool TestCase_IsEmpty()  //Andreas Drabosenig
        //{
        //    bool result = false;
        //    SimpleStack s1 = new SimpleStack();
        //    if (s1.IsEmpty() == true)
        //    {
        //        result = true;
        //    }
        //    return result;
        //}

        //static bool TestCase_IsFull()   //Gragger Nicolas
        //{
        //    SimpleStack stackIsFull = new SimpleStack(1);
        //    bool result = true;
        //    if (stackIsFull.IsFull())
        //    {
        //        result = false;
        //    }
        //    stackIsFull.Push(5);
        //    if (!stackIsFull.IsFull())
        //    {
        //        result = false;
        //    }
        //    return result;
        //}

        //static bool Testcase_Merge() //Kandut Nico
        //{
        //    bool result = true;
        //    int testwert;
        //    SimpleStack SimpleStack01;
        //    SimpleStack SimpleStack02;
        //    SimpleStack ResultingStack;
        //    int idxCounter = 0;

        //    testwert = 3;
        //    SimpleStack01 = new SimpleStack(testwert + 4);
        //    SimpleStack02 = new SimpleStack(testwert);

        //    for (idxCounter = 0; idxCounter < testwert - 1; idxCounter++)
        //    {
        //        SimpleStack01.Push(idxCounter);
        //        SimpleStack02.Push(idxCounter + 10);
        //    }

        //    ResultingStack = SimpleStack01.Merge(SimpleStack02);

        //    idxCounter = 0;

        //    try
        //    {
        //        while (result && idxCounter > testwert)
        //        {
        //            if (ResultingStack.Pop() != SimpleStack02.Pop())
        //            {
        //                result = false;
        //            }
        //            idxCounter--;
        //        }

        //        while (result && idxCounter > 0)
        //        {

        //            if (ResultingStack.Pop() != SimpleStack01.Pop())
        //            {
        //                result = false;
        //            }
        //            idxCounter--;
        //        }
        //    }
        //    catch
        //    {
        //        result = false;
        //    }

        //    return result;
        //}

        //static bool TestCasePop()            //Hebein Fabian
        //{
        //    int zahl = 5;
        //    int stacksize = 20;
        //    SimpleStack TestStack = new SimpleStack(stacksize);
        //    bool status = true;

        //    TestStack.Push(zahl);
        //    if (TestStack.Pop() != zahl)
        //        status = false;
        //    else
        //    {
        //        if (TestStack.IsEmpty())
        //        {
        //            status = false;
        //            try
        //            {
        //                TestStack.Pop();
        //            }
        //            catch
        //            {
        //                status = true;
        //            }
        //        }
        //    }

        //    return status;

        //}

        //static bool RunTestCasePush()     //Valon Berisa
        //{         //    int pushElement = 7;         //    SimpleStack s1 = new SimpleStack(5);          //    s1.Push(pushElement);          //    return (s1.GetElement() == pushElement);
        //}

        //static bool RunTestCaseResize()     //Melanie Bugelnig
        //{
        //    int newCapacity = 5;
        //    SimpleStack s1 = new SimpleStack(newCapacity);
        //    bool result = true;
        //    int counter;

        //    for (counter = 0; counter < newCapacity; counter++)
        //    {
        //        s1.Push(counter);
        //    }

        //    newCapacity = 10;

        //    s1.Resize(newCapacity);

        //    for (; counter < newCapacity; counter++)
        //    {
        //        s1.Push(counter);

        //    }

        //    counter--;

        //    if (s1.Pop() != counter)
        //    {
        //        result = false;
        //    }

        //    counter--;


        //    return result;
        //}
    }
}
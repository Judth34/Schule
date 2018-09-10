using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Eigenschaften
            SimpleQueue s1 = null;
            SimpleQueue s2 = null;
            int StackSize = 0;
            int Auswahl = 0;
            int Element = 0;
            int SuchendesElement = 0;
            int GroesserOderKleinerer = 0;
            int Wertaenderung = 0;
            int AuswahlStack = 0;
            #endregion

            #region Tests

            #endregion

            #region Erzeugen
            StackSize = GetAValid(1, 20, "Welche Groesse soll Ihr Stack haben?");

            try
            {
                s1 = new SimpleQueue(StackSize);
            }
            catch (Exception StackSizeFail)
            {
                Console.WriteLine("Fehler: " + StackSizeFail.Message);
            }

            StackSize = GetAValid(1, 20, "Welche Groesse soll Ihr 2.Stack haben?");
            try
            {
                s2 = new SimpleQueue(StackSize);
            }
            catch (Exception StackSizeFail)
            {
                Console.WriteLine("Fehler: " + StackSizeFail.Message);
            }
            #endregion

            #region Menue
            do
            {
                Auswahl = GetAValid(0, 9, "Enqueue = 1\nDequeue = 2\nFind = 3\nGetElement = 4\nResize = 5\nCopy = 6\nMerge = 7\nIs Full = 8\nIs Empty = 9");
                switch (Auswahl)
                {
                    #region Enqueue
                    case 1:
                        try
                        {
                            AuswahlStack = GetAValid(1, 2, "1. oder 2. Stack");
                            Element = GetAValid(1, 100, "Welche Zahl moechtest du hinzufuegen?");
                            if (AuswahlStack == 1)
                            {
                                s1.Enqueue(Element);
                                Console.WriteLine("Element " + Element + " wurde zum 1.Stack hinzugefuegt");
                            }
                            else
                            {
                                if (AuswahlStack == 2)
                                {
                                    s2.Enqueue(Element);
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
                    #region Dequeue
                    case 2:
                        try
                        {
                            AuswahlStack = GetAValid(1, 2, "1. oder 2. Stack");
                            if (AuswahlStack == 1)
                            {
                                s1.Dequeue();
                                Console.WriteLine("Element wurde aus 1.Stack geloescht!");
                            }
                            else
                            {
                                if (AuswahlStack == 2)
                                {
                                    s2.Dequeue();
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
                                Console.WriteLine("Die Zahl wurde " + s2.Find(SuchendesElement) + "-mal im 2.Stack gefunden");
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
                                Console.WriteLine("Letztes Element (2. Stack) = " + s2.GetElement());
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
                                Console.WriteLine("Neue Groesse (2.Stack) = " + s2.Resize(GroesserOderKleinerer, Wertaenderung));
                            }
                        }


                        Console.WriteLine("Klicken um fortzufahren!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Copy
                    case 6:
                        AuswahlStack = GetAValid(1, 2, "1. oder 2. Stack");
                        SimpleQueue StackCopy = null;
                        if (AuswahlStack == 1)
                        {
                            StackCopy = new SimpleQueue(s1.SizeOfStack);
                            s1.Copy();
                        }
                        else
                        {
                            if (AuswahlStack == 2)
                            {
                                StackCopy = new SimpleQueue(s1.SizeOfStack);
                                s2.Copy();
                            }
                        }

                        Console.WriteLine("Klicken um fortzufahren!");
                        Console.ReadLine();
                        break;
                    #endregion
                    #region Merge
                    case 7:
                        s1.Merge(s2);
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
                                Console.WriteLine("Is Stack2 Full? = " + s2.IsFull());
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
                                Console.WriteLine("Is Stack2 Empty? = " + s2.IsEmpty());
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

        static bool TestCase_IsEmpty() //Andreas Drabosenig
        {
            bool result = false;
            SimpleQueue s1 = new SimpleQueue();

            if(s1.IsEmpty())
            {
                result = true;
            }

            return result;
        }
    }
}

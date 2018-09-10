using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedStack_Solition1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {


                SortStack Test = new SortStack(10);
                Console.WriteLine("Sort by Push: " + TestFall_SortPush(Test));

                Test = new SortStack(10);
                Console.WriteLine("Sort by PopV1: " + TestFall_SortPush(Test));

                Test = new SortStack(10);
                Console.WriteLine("Sort by PopV2: " + TestFall_SortPush(Test));

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            }

        static bool TestFall_SortPush(SortStack Test)
        {
            bool erg = false;
            Test.SortPush(12);
            Test.SortPush(6);
            Test.SortPush(3);
            Test.SortPush(22);
            Test.SortPush(1);
            Test.Pop();
            Test.Pop();

            if(Test.Pop() == 6)
            {
                if(Test.Pop() == 3)
                {
                    if(Test.Pop() == 1)
                    {
                        erg = true;
                    }
                }
            }

            return erg;
        }

        static bool TestFall_SortPopV1(SortStack Test)
        {
            bool erg = false;
            Test.Push(12);
            Test.Push(6);
            Test.Push(3);
            Test.Push(22);
            Test.Push(1);
            Test.SortPopV1();
            Test.SortPopV1();

            if (Test.Pop() == 6)
            {
                if (Test.Pop() == 3)
                {
                    if (Test.Pop() == 1)
                    {
                        erg = true;
                    }
                }
            }

            return erg;
        }

        static bool TestFall_SortPopV2(SortStack Test)
        {
            bool erg = false;
            Test.Push(12);
            Test.Push(6);
            Test.Push(3);
            Test.Push(22);
            Test.Push(1);
            Test.SortPopV2();
            Test.SortPopV2();

            if (Test.Pop() == 6)
            {
                if (Test.Pop() == 3)
                {
                    if (Test.Pop() == 1)
                    {
                        erg = true;
                    }
                }
            }

            return erg;
        }
    }
}

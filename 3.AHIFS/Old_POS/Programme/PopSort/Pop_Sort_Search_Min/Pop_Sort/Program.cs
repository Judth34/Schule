using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pop_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int StackSize = 4;
            Stack Speicher = null;

            #region Erzeugung
            try
            {
                Speicher = new Stack(StackSize);
            }
            catch (Exception KonstruktorEx)
            {
                Console.WriteLine(KonstruktorEx.Message);
            }
            #endregion

            #region Push
            try
            {
                Speicher.Push(2);
                Speicher.Push(6);
                Speicher.Push(24);
                Speicher.Push(5);
            }
            catch (Exception PushEx)
            {
                Console.WriteLine(PushEx.Message);
            }
            #endregion

            #region Pop
            try
            {
                Speicher.Pop();
                Speicher.Pop();
                Speicher.Pop();
                Speicher.Pop();
            }
            catch (Exception PopEx)
            {
                Console.WriteLine(PopEx.Message);
            }
            #endregion
        }
    }
}

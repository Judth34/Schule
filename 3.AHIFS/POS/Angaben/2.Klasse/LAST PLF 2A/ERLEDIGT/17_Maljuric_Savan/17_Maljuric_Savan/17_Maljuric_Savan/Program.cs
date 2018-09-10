using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Files;
using DataStructures;

namespace _17_Maljuric_Savan
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFile m1 = new MyFile();
            MyTree t1 =  new MyTree();
            MyList m2 = new MyList();
            string[] filesArray;
            try
            {
                filesArray = m1.GetBinaryFiles();
                m1.SaveFileData(filesArray,t1,m2);
                Console.WriteLine(t1.GetDurchschnitt());
                Console.WriteLine(m2.GetDurchschnitt());
                //Ich habe bei der Liste Standart double benutzt, damit ich nicht carsten muss;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

          
        }
    }
}

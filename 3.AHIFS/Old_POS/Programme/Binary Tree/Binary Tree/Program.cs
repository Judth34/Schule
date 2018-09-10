using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BinaryTree tree = new BinaryTree();
                tree.Add(12);
                tree.Add(23);
                tree.Add(15);
                tree.Add(1);
                tree.Add(5);
                tree.Add(37);
                tree.Add(20);
                tree.Add(4);

                List<int> list = tree.GetDataPostOrder();
                foreach(int value in list)
                {
                    Console.WriteLine(value);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

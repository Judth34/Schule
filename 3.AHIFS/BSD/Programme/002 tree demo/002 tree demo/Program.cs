using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_tree_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //FirstDemo();
            TreeNode rootFolder = DirectoryExplorer.GetFolderStructure(@"C:\Root");
            printTree(rootFolder, " ");
        }

        private static void FirstDemo()
        {
            //TreeNode root = new TreeNode("rootFolder");
            //TreeNode f1 = new TreeNode("F1");

            //root.Append(f1).Append("F11");
            //f1.Append("F12");

            //root.Append("F2").Append("F21");

            //root.Append("F3");

            //TreeNode f4 = new TreeNode("F4");
            //root.Append(f4).Append("F41");
            //f4.Append("F42");

            //printTree(root, "");
        }

        //1. HÜ Aufzählungstyp für Pre- und Postorder integrieren und printTree generieren

        private static void printTree(TreeNode currentNode, string tab)
        {
            if(currentNode.ValueType == "DIR")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine(tab + currentNode.value);

            foreach(TreeNode tn in currentNode.ChildNodes)
            {
                printTree(tn, tab + " ");
            }
            
        }

        private static void Generate()
        {

        }


    }
}

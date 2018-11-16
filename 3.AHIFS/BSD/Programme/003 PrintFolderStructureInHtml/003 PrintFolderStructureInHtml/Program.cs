using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeLib;
using System.IO;
namespace _003_PrintFolderStructureInHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode rootFolder = DirectoryExplorerLib.DirectoryExplorer.GetFolderStructure(@"C:\Root");

            File.WriteAllText(@".\Seite.html", printTreeV3(rootFolder, ""));
            //printTreeV1(rootFolder, " ");
            Console.WriteLine(printTreeV3(rootFolder, ""));
        }

        private static string printTreeV3(TreeNode currentNode, string HtmlDoc)
        {
            string innerHtml = "";
            HtmlDoc += "<ul>\n<li>" + currentNode.value;
            foreach (TreeNode tn in currentNode.ChildNodes)
            {
                innerHtml = printTreeV3(tn, innerHtml);
            }
            HtmlDoc += innerHtml + "</ul>\n</li>";

           return HtmlDoc;
        }

        private static string printTreeV2(TreeNode currentNode, string HtmlDoc)
        {
            if (currentNode.ValueType == "DIR")
            {
                HtmlDoc += "<ul>" + currentNode.value + "</ul>";
            }
            else
            {
                HtmlDoc += "<li>" + currentNode.value + "</li>";
            }

            foreach (TreeNode tn in currentNode.ChildNodes)
            {
                HtmlDoc = printTreeV2(tn, HtmlDoc + "\n");
            }
            return HtmlDoc;
        }

        private static void printTreeV1(TreeNode currentNode, string tab)
        {

            if (currentNode.ValueType == "DIR")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine(tab + currentNode.value);

            foreach (TreeNode tn in currentNode.ChildNodes)
            {
                printTreeV1(tn, tab + " ");
            }
        }
    }
}

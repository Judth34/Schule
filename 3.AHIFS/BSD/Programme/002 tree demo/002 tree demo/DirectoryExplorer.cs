using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_tree_demo
{
    public static class DirectoryExplorer
    {
        static public TreeNode GetFolderStructure(string currentpath)
        {
            int idx = currentpath.LastIndexOf("\\");
            string relativeDirName = currentpath.Substring(idx, currentpath.Length - idx);
            TreeNode result = new TreeNode(currentpath, "DIR");

            foreach (string file in Directory.GetFiles(currentpath))
            {
                result.Append(file, "FILE");
            }

            //an alle 'child elements' im directory zu kommen
            foreach (string subDirectory in Directory.GetDirectories(currentpath))
            {
                result.Append(GetFolderStructure(subDirectory));
            }

            return result;
        }
        
    }
}

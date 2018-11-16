using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Judth_Marcel_PLF01_Lib
{
    public class TreeNode
    {
        private List<TreeNode> childNodes = new List<TreeNode>();
        public string ValueType { get; private set; }
        public IList<TreeNode> ChildNodes { get { return childNodes.AsReadOnly(); } }

        public TreeNode(string NewValueType)
        {
            ValueType = NewValueType;
        }

        public TreeNode Append(TreeNode newNode)
        {
            //Überprüfungen auf Gültigkeit des neuen Knotens können hier gemacht werden
            childNodes.Add(newNode);
            return newNode;
        }

        public TreeNode Append(string NewValueType)
        {
            TreeNode newNode = new TreeNode(NewValueType);
            //Überprüfungen auf Gültigkeit des neuen Knotens können hier gemacht werden
            return Append(newNode);
        }
    }
}

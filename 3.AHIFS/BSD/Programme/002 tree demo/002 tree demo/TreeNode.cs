using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_tree_demo
{
    public class TreeNode
    {
        private List<TreeNode> childNodes = new List<TreeNode>();
        public string value { get; private set; }
        public string ValueType { get; private set; }
        public IList<TreeNode> ChildNodes { get { return childNodes.AsReadOnly(); } }

        public TreeNode(string NewValue, string NewValueType)
        {
            value = NewValue;
            ValueType = NewValueType;
        }

        public TreeNode Append(TreeNode newNode)
        {
            //Überprüfungen auf Gültigkeit des neuen Knotens können hier gemacht werden
            childNodes.Add(newNode);
            return newNode;
        }

        public TreeNode Append(string newValue, string NewValueType)
        {
            TreeNode newNode = new TreeNode(newValue, NewValueType);
            //Überprüfungen auf Gültigkeit des neuen Knotens können hier gemacht werden
            return Append(newNode);
        }
    }
}

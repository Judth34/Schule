using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructuresLIB
{
    public class Node
    {
        public Node left;
        public Node right;
        public int Value;

        public Node(int newValue)
        {
            Value = newValue;
            left = null;
            right = null;
        }
    }
}

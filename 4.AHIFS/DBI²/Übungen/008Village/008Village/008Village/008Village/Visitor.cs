using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _008Village
{
    class Visitor
    {
        public int Id { get; private set; }
        public Point coordinate { get; private set; }


        public Visitor(int Id, Point p)
        {
            this.Id = Id;
            coordinate = p;
        }

        public override string ToString()
        {
            return "Visitor: " + "Id, " + "coordinate : " + coordinate;
        }
    }
}


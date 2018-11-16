using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _008Village
{
    class Stand
    {
        public int nr { get; set; }
        public Point position { get; set; }
        public string name { get; set; }

        public Stand(int nr, Point position, string name)
        {
            this.nr = nr;
            this.position = position;
            this.name = name;
        }

        override
        public string ToString()
        {
            return nr + ", " + position.ToString() + ", " + name;
        }
    }
}

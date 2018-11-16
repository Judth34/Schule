using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StraßenNetzLib
{
    public class Point
    {
        public int xCoo { get; set; }
        public int yCoo { get; set; }

        public Point(int xCoo, int yCoo)
        {
            this.xCoo = xCoo;
            this.yCoo = yCoo;
        }

        override
        public string ToString()
        {
            return "Point{xCoo:" + xCoo + ", yCoo:" + yCoo + "}";
        }
    }
}

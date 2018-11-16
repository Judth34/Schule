using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StraßenNetzLib
{
    public class Teilstrecke
    {
        public Point startPoint { get; set; }
        public Point endPoint { get; set; }
        public string name { get; set; }

        public Teilstrecke(string name, Point start, Point end)
        {
            this.startPoint = start;
            this.endPoint = end;
            this.name = name;
        }

        public double getLength()
        {
            return Math.Round(Math.Sqrt((endPoint.xCoo - startPoint.xCoo) * (endPoint.xCoo - startPoint.xCoo) + (endPoint.yCoo - startPoint.yCoo) * (endPoint.yCoo - startPoint.yCoo)), 2);
        }

        override
        public string ToString()
        {
            return "name: " + name  + " length: " + getLength() + "km";
        }
    }
}

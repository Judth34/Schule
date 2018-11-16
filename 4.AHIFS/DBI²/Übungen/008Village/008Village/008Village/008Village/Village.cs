using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace _008Village
{
    class Village
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public int visitors { get; private set; }
        public PointCollection coordinates { get; private set; }

        public Village(int id, string name, int visitors)
        {
            this.id = id;
            this.name = name;
            this.visitors = visitors;
            this.coordinates = new PointCollection();
        }

        public void addPoint(int xCoo, int yCoo)
        {
            this.coordinates.Add(new Point(xCoo, yCoo));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SPO_Geometry
{
    public class Building
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int NumberOfVisitors { get; private set; }
        public PointCollection Coordinates { get; private set; }
        public List<Visitor> allVisitors { get; set; }

        public Building(int Id, string Name, int NumberOfVisitors, PointCollection Coordinates)
        {
            this.Id = Id;
            this.Name = Name;
            this.NumberOfVisitors = NumberOfVisitors;
            this.Coordinates = Coordinates;
            this.allVisitors = new List<Visitor>();
        }

        public override string ToString()
        {
            return "Building: " + "Id, " + "name : " + Name;
        }
    }
}

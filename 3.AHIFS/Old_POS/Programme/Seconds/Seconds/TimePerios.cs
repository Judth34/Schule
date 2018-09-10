using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seconds
{
    class TimePeriod
    {
        private double seconds;

        public double Hours
        {
            get { return seconds / 3600; }
            set { seconds = value * 3600; }
        }
    }
}

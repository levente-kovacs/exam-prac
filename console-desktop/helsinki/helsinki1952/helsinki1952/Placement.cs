using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helsinki1952
{
    public class Placement
    {
        public int Placement_ { get; private set; }
        public int TeamSize { get; private set; }
        public string Sport { get; private set; }
        public string Event { get; private set; }

        public Placement(string line)
        {
            string[] lineParts = line.Split(' ');
            Placement_ = int.Parse(lineParts[0]);
            TeamSize = int.Parse(lineParts[1]);
            Sport = lineParts[2];
            Event = lineParts[3];
        }
    }
}

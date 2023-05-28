using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelsinkiWPF
{
    class Placement
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
        public static int PlacementToPoints(int placement)
        {
            if (placement == 1)
            {
                return 7;
            }
            else if (placement > 1 && placement < 7)
            {
                return 7 - placement;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return $"{Placement_} {TeamSize} {Sport} {Event} {PlacementToPoints(Placement_)}";
        }


    }
}

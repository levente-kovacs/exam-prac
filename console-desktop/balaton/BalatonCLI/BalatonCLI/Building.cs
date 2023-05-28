using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI
{
    public class Building
    {
        public int Id { get; private set; }
        public string TaxNumber { get; private set; }
        public string Street { get; private set; }
        public string HouseNumber { get; private set; }
        public string Type { get; private set; }
        public int Area { get; private set; }

        public Building(string line)
        {
            string[] lineParts = line.Split(' ');

            TaxNumber = lineParts[0];
            Street = lineParts[1];
            HouseNumber = lineParts[2];
            Type = lineParts[3];
            Area = int.Parse(lineParts[4]);
        }
    }
}

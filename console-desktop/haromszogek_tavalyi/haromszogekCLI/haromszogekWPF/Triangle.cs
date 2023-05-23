using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haromszogekWPF
{
    class Triangle
    {
        public int A { get; private set; }
        public int B { get; private set; }
        public int C { get; private set; }

        public Triangle(string line)
        {
            string[] lineParts = line.Split(' ');
            A = int.Parse(lineParts[0]);
            B = int.Parse(lineParts[1]);
            C = int.Parse(lineParts[2]);
        }

        public override string ToString()
        {
            return $"a: {A} b: {B} c: {C}";
        }
    }
}

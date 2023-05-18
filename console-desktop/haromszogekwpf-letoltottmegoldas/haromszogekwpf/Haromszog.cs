using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haromszogekwpf
{
    internal class Haromszog
    {
        public int a { get; private set; }
        public int b { get; private set; }
        public int c { get; private set; }

        public Haromszog(string sor)
        {
            this.a = int.Parse(sor.Split(' ')[0]);
            this.b = int.Parse(sor.Split(' ')[1]);
            this.c = int.Parse(sor.Split(' ')[2]);
        }

        public Haromszog(int a, int b, int c)
        {
            List<int> list = new List<int>();
            list.Add(a);
            list.Add(b);
            list.Add(c);
            list.Sort();

            this.a = list[0];
            this.b = list[1];
            this.c = list[2];
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IskolaWPF
{
    class Student
    {
        public int StartYear { get; private set; }
        public string ClassLetter { get; private set; }
        public string Name { get; private set; }

        public Student(string row)
        {
            string[] rowParts = row.Split(';');

            StartYear = int.Parse(rowParts[0]);
            ClassLetter = rowParts[1];
            Name = rowParts[2];
        }

        public override string ToString()
        {
            return $"{StartYear};{ClassLetter};{Name}";
        }
    }
}

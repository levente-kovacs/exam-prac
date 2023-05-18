using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IskolaWPF
{
    class Student
    {
        public int Year { get; private set; }
        public char ClassChar { get; private set; }
        public string Name { get; private set; }
        

        public Student(int year, char classChar, string name)
        {
            Year = year;
            ClassChar = classChar;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Year} {ClassChar} {Name}";
        }

    }
}

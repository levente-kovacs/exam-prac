using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Iskola_vizsgagyakorlas
{
    public class Iskola
    {
        public static List<Student> students = new List<Student>();

        public static string idGenerator(Student student)
        {
            char lastCharOfYear = char.Parse((student.Year % 10).ToString());
            string[] namesSeparated = student.Name.Split(' ');
            string nameCode = namesSeparated[0].Substring(0, 3) + namesSeparated[1].Substring(0, 3);
            string id = $"{lastCharOfYear}{student.ClassChar}{nameCode}".ToLower();
            return id;
        }

        static void Main(string[] args)
        {
            // adatok beolvasása
            StreamReader reader = new StreamReader("nevek.txt");
            while(!reader.EndOfStream)
            {
                string[] dataInRow = reader.ReadLine().Split(';');
                Student student = new Student(int.Parse(dataInRow[0]), char.Parse(dataInRow[1]), dataInRow[2]);
                students.Add(student);
            }
            reader.Close();

            // 3. feladat - adatok kiírása
            Console.WriteLine("3. feladat");
            foreach(Student student in students)
            {
                Console.WriteLine($"{student.Year} {student.ClassChar} {student.Name}");
            }
            Console.WriteLine($"Az iskolába {students.Count} tanuló jár.");

            // 4. feladat
            Console.WriteLine("\n4. feladat");
            Console.WriteLine(idGenerator(students[0]));
            Console.WriteLine(idGenerator(students[students.Count-1]));

            // nevek és azonosítók fájlba írása
            StreamWriter writer = new StreamWriter("azonositok.txt");
            foreach (Student student in students)
            {
                writer.WriteLine($"{student.Name} {idGenerator(student)}");
            }
            writer.Close();

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola
{
    public class Iskola
    {
        public static List<Student> students = new List<Student>();

        // kódgenerátor
        public static string GenerateCode(Student student)
        {
            string code = "";
            code += student.StartYear % 10;
            code += student.ClassLetter;
            string[] nameParts = student.Name.ToLower().Split(' ');
            code += nameParts[0].Substring(0,3);
            code += nameParts[1].Substring(0,3);
            return code;
        }

        static void Main(string[] args)
        {
            // nevek.txt beolvasása
            StreamReader reader = new StreamReader("nevek.txt");
            while(!reader.EndOfStream)
            {
                Student student = new Student(reader.ReadLine());
                students.Add(student);
            }
            reader.Close();

            // 3. feladat
            Console.WriteLine("3. feladat");
            foreach(Student student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine($"Az iskolába {students.Count} tanuló jár.");

            // 4. feladat
            Console.WriteLine("\n4. feladat");
            Console.WriteLine($"Az első tanuló azonosítója: {GenerateCode(students[0])}");
            Console.WriteLine($"Az utolsó tanuló azonosítója: {GenerateCode(students[students.Count-1])}");

            // 6. feladat
            StreamWriter writer = new StreamWriter("azonositok.txt");
            foreach(Student student in students)
            {
                writer.WriteLine($"{student.Name} - {GenerateCode(student)}");
            }
            writer.Close();

            Console.ReadKey();
        }
    }
}

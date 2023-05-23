using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haromszogekCLI
{
    public class haromszogekCLI
    {
        public static List<Triangle> triangles = new List<Triangle>();

        // Derékszögű e az adott háromszög?
        public static bool IsRightAngled(Triangle triangle)
        {
            if (triangle.A * triangle.A + triangle.B * triangle.B == triangle.C * triangle.C)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            // forrásállomány beolvasása
            StreamReader reader = new StreamReader("haromszogek.csv");
            while (!reader.EndOfStream)
            {
                Triangle triangle = new Triangle(reader.ReadLine());
                triangles.Add(triangle);
            }
            reader.Close();

            // 10. feladat
            int largestArea = 0;
            Triangle largestRATriangle = triangles[0];
            foreach (Triangle triangle in triangles)
            {
                if (IsRightAngled(triangle))
                {
                    int area = (triangle.A * triangle.B) / 2;
                    if (area > largestArea)
                    {
                        largestArea = area;
                        largestRATriangle = triangle;
                    }
                    Console.WriteLine(triangle.ToString());
                }
            }

            // 11. feladat
            Console.WriteLine("\nA legnagyobb területű derékszögű háromszög adatai:");
            Console.WriteLine(largestRATriangle.ToString());

            Console.ReadKey();
        }
    }
}

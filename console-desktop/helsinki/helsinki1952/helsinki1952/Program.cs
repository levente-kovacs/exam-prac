using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helsinki1952
{
    public class Program
    {
        public static List<Placement> placements = new List<Placement>();

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

        static void Main(string[] args)
        {
            // forrásállomány beolvasása
            StreamReader reader = new StreamReader("helsinki.txt");
            while (!reader.EndOfStream)
            {
                Placement placement = new Placement(reader.ReadLine());
                placements.Add(placement);
            }
            reader.Close();

            Console.WriteLine("3. feladat:");
            Console.WriteLine($"A magyar olimpikonok {placements.Count} pontszerző helyezést értek el.");


            // 5. feladat
            int hunGymnasticsPoints = 0;
            foreach (Placement placement in placements)
            {
                if (placement.Sport == "torna")
                {
                    hunGymnasticsPoints += PlacementToPoints(placement.Placement_);
                }
            }
            Console.WriteLine("\n5. feladat:");
            Console.WriteLine($"A magyar sportolók torna sportágban összesen {hunGymnasticsPoints} pontot szereztek.");

            // 7. feladat
            int competitorsCount = 0;
            foreach(Placement placement in placements)
            {
                competitorsCount += placement.TeamSize;
            }
            StreamWriter writer = new StreamWriter("foglalas.txt");
            writer.WriteLine($"Szeretnék asztalokat foglalni {competitorsCount} főre!");
            writer.Close();

            Console.ReadKey();
        }
    }
}

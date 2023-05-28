using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI
{
    public class BalatonCLI
    {
        static List<Building> buildings = new List<Building>();
        public static List<int> prices = new List<int>();

        public static int Ado(string type, int area)
        {
            int tax = 0;
            switch (type)
            {
                case "A":
                    tax = 800 * area;
                    break;
                case "B":
                    tax = 600 * area;
                    break;
                case "C":
                    tax = 100 * area;
                    break;
            }

            if (tax >= 10000)
            {
                return tax;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            // forrásállomány beolvasása
            StreamReader reader = new StreamReader("utca.txt");

            string[] priceLineParts = reader.ReadLine().Split(' ');
            foreach(string price in priceLineParts)
            {
                prices.Add(int.Parse(price));
            }

            while (!reader.EndOfStream)
            {
                Building building = new Building(reader.ReadLine());
                buildings.Add(building);
            }
            reader.Close();

            // 2. feladat
            Console.WriteLine($"2. feladat. A mintában {buildings.Count} telek szerepel.");

            // 3. feladat
            Console.Write("3. feladat. Egy tulajdonos adószáma: ");
            string gotTaxNumber = Console.ReadLine();
            bool isValid = false;
            foreach(Building building in buildings)
            {
                if (gotTaxNumber == building.TaxNumber)
                {
                    isValid = true;
                    Console.WriteLine($"{building.Street} utca {building.HouseNumber}");
                }
            }
            if (!isValid)
            {
                Console.WriteLine("Nem szerepel az adatállományban.");
            }


            // 5. feladat
            Console.WriteLine("5. feladat");
            int ATypeCount = 0;
            int ATypePrice = 0;
            int BTypeCount = 0;
            int BTypePrice = 0;
            int CTypeCount = 0;
            int CTypePrice = 0;

            foreach(Building building in buildings)
            {
                switch (building.Type)
                {
                    case "A":
                        ATypeCount++;
                        ATypePrice += Ado(building.Type, building.Area);
                        break;
                    case "B":
                        BTypeCount++;
                        BTypePrice += Ado(building.Type, building.Area);
                        break;
                    case "C":
                        CTypeCount++;
                        CTypePrice += Ado(building.Type, building.Area);
                        break;
                }
            }

            Console.WriteLine($"A sávba {ATypeCount} telek esik, az adó {ATypePrice} Ft.");
            Console.WriteLine($"B sávba {BTypeCount} telek esik, az adó {BTypePrice} Ft.");
            Console.WriteLine($"C sávba {CTypeCount} telek esik, az adó {CTypePrice} Ft.");

            // 6. feladat
            StreamWriter writer = new StreamWriter("teljes.txt");
            foreach(Building building in buildings)
            {
                writer.WriteLine($"{building.TaxNumber} {building.Street} {building.HouseNumber} {building.Type} {building.Area} {Ado(building.Type, building.Area)}");
            }


            Console.ReadKey();
        }
    }
}

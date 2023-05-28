using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    internal class Program
    {
        static double DistanceTo(double x, double y, double compareX, double compareY)
        {
            double a = Math.Abs(x - compareX);
            double b = Math.Abs(y - compareY);
            return Math.Sqrt(a * a + b * b);
        }

        static void Main(string[] args)
        {
            List<Ad> ads = Ad.LoadFromCsv("realestates.csv");
            Console.WriteLine("6. feladat:");
            int groundFloorsCount = 0;
            float groundFloorsArea = 0;
            foreach (Ad ad in ads)
            {
                if (ad.Floors == 0)
                {
                    groundFloorsCount++;
                    groundFloorsArea += ad.Area;
                }
            }
            Console.WriteLine($"1. Földszinti angatlanok átlagos alapterülete: {Math.Round(groundFloorsArea/groundFloorsCount, 2)} m2");

            Console.WriteLine("\n8. feladat:");
            Ad closestRealEstate = ads[0];
            double closestDistance = double.MaxValue;
            double mesevarX = 47.4164220114023;
            double mesevarY = 19.066342425796986;
            foreach (Ad ad in ads)
            {
                if (ad.FreeOfCharge)
                {
                    string[] latLongParts = ad.LatLong.Split(',');
                    double adX = double.Parse(latLongParts[0].Replace('.', ','));
                    double adY = double.Parse(latLongParts[1].Replace('.', ','));
                    double distance = DistanceTo(adX, adY, mesevarX, mesevarY);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestRealEstate = ad;
                    }
                }
            }
            Console.WriteLine($"2. Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai:");
            Console.WriteLine(closestRealEstate.ToString());


            Console.ReadKey();
        }
    }
}

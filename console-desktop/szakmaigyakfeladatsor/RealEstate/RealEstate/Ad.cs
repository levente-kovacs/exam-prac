using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    internal class Ad
    {
        public int Id { get; set; }
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOfCharge { get; set; }
        public string ImgUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }

        public Ad(string line)
        {
            string[] lineParts = line.Split(';');
            Id = int.Parse(lineParts[0]);
            Rooms = int.Parse(lineParts[1]);
            LatLong = lineParts[2];
            Floors = int.Parse(lineParts[3]);
            Area = int.Parse(lineParts[4]);
            Description = lineParts[5];
            if (int.Parse(lineParts[6]) == 1)
            {
                FreeOfCharge = true;
            }
            else
            {
                FreeOfCharge = false;
            }
            ImgUrl = lineParts[7];
            CreateAt = DateTime.Parse(lineParts[8]);
            Seller = new Seller(int.Parse(lineParts[9]), lineParts[10], lineParts[11]);
            Category = new Category(int.Parse(lineParts[12]), lineParts[13]);
        }

        public override string ToString()
        {
            return $"\tEladó neve\t: {Seller.Name}\n\tEladó telefonja\t: {Seller.Phone}\n\tAlapterület\t: {Area}\n\tSzobák száma\t: {Rooms}";
        }

        public static List<Ad> LoadFromCsv(string RealEstateSCV)
        {
            List<Ad> ads = new List<Ad>();
            StreamReader reader = new StreamReader(RealEstateSCV);
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                Ad ad = new Ad(reader.ReadLine());
                ads.Add(ad);
            }
            reader.Close();

            return ads;
        }

    }
}

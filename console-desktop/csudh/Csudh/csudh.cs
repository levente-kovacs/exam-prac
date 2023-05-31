using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Csudh
{
    public class csudh
    {
        public static string Domain(int level, IpAddress ipAddress)
        {
            string[] ipAddressParts = ipAddress.DomainName.Split('.');
            if (level > ipAddressParts.Length)
            {
                return "nincs";
            }
            return ipAddressParts.Reverse().ToArray()[level - 1];
        }

        public static List<IpAddress> IpAddresses = new List<IpAddress>();

        static void Main(string[] args)
        {
            // filebeolvasás
            StreamReader reader = new StreamReader("csudh.txt");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                IpAddress IpAddress = new IpAddress(reader.ReadLine());
                IpAddresses.Add(IpAddress);
            }
            reader.Close();

            // 3. feladat
            Console.WriteLine("3. feladat:");
            foreach (IpAddress IpAddress in IpAddresses)
            {
                Console.WriteLine(IpAddress.ToString());
            }
            Console.WriteLine($"A listában {IpAddresses.Count} ip cím van a listában.");

            // 5. feladat
            Console.WriteLine("5. feladat:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{i}. szint: {Domain(i, IpAddresses[0])}");
            }



            Console.ReadKey();
        }
    }
}

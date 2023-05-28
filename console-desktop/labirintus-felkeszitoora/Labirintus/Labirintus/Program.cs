using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirintus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LabSim labSim = new LabSim("Lab1.txt");

            Console.WriteLine("5. feladat: Labirintus adatai");
            Console.WriteLine(labSim.ToString());

            Console.WriteLine("6. feladat: A labirintus");
            labSim.KiirLab();

            Console.Clear();
            Console.CursorVisible = false;
            labSim.Urkereses();

            Console.ReadKey();
        }
    }
}

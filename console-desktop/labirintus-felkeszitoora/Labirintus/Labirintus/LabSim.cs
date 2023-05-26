using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirintus
{
    internal class LabSim
    {
        private List<string> Adatsorok = new List<string>();
        private char[,] Lab;

        public bool KeresesKesz { get; set; }
        public int KijaratOszlopIndex { get; }
        public int KijaratSorIndex { get; }
        public bool NincsMegoldas { get; set; }
        public int OszlopokSzama { get; }
        public int SorokSzama { get; }

        public LabSim(string forras)
        {
            BeolvasAdatsorok(forras);

            OszlopokSzama = Adatsorok.Count;
            SorokSzama = Adatsorok[0].ToCharArray().Length;
            KijaratOszlopIndex = OszlopokSzama - 1;
            KijaratSorIndex = SorokSzama - 2;

            Lab = new char[SorokSzama, OszlopokSzama];
            FeltoltLab();

        }

        public override string ToString()
        {
            return $"\tSorok száma: {SorokSzama}\n\tOszlopok száma: {OszlopokSzama}\n\tKijárat indexe: sor: {KijaratSorIndex} oszlop: {KijaratOszlopIndex}";
        }

        private void BeolvasAdatsorok(string forras)
        {
            StreamReader reader = new StreamReader(forras);
            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                Adatsorok.Add(line);
            }
            reader.Close();
        }

        private void FeltoltLab()
        {
            for (int i = 0; i < OszlopokSzama; i++)
            {
                for (int j = 0; j < SorokSzama; j++)
                {
                    Lab[i, j] = Adatsorok[i].ToCharArray()[j];
                }
            }
        }

        public void KiirLab()
        {
            for (int i = 0; i < OszlopokSzama; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < SorokSzama; j++)
                {
                    Console.Write(Lab[i, j]);
                }
            }

        }

        public void Urkereses()
        {
            bool keresesKesz = false;
            bool nincsMegoldas = false;
            int r = 1;
            int c = 0;

            while (!this.KeresesKesz && !this.NincsMegoldas)
            {
                Lab[r, c] = 'O';
                if (Lab[r, c + 1] == ' ')
                {
                    c++;
                }
                else if (Lab[r + 1, c] == ' ')
                {
                    r++;
                }
                else
                {
                    Lab[r, c] = '-';
                    if (Lab[r, c - 1] == 'O')
                    {
                        c--;
                    }
                    else
                    {
                        r--;
                    }
                }
                this.KeresesKesz = (r == this.KijaratSorIndex && c == this.KijaratOszlopIndex);
                if (this.KeresesKesz)
                {
                    Lab[r, c] = 'O';
                }
                this.NincsMegoldas = (r == 1 && c == 0);
                KiirLab();
                System.Threading.Thread.Sleep(100);
                if (!KeresesKesz && !NincsMegoldas)
                {
                    Console.SetCursorPosition(0, 0);
                    //Console.Clear();
                }
            }

        }
    }
}

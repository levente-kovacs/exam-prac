using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SuliVerseny.Models
{
    public partial class Iskolak
    {
        public Iskolak()
        {
            Felhasznaloks = new HashSet<Felhasznalok>();
        }

        public int Id { get; set; }
        public int IskolaId { get; set; }
        public string Nev { get; set; }

        public virtual Iskolalogok Iskolalogok { get; set; }
        public virtual ICollection<Felhasznalok> Felhasznaloks { get; set; }
    }
}

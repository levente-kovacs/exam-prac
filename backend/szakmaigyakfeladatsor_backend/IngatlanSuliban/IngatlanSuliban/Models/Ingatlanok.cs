using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IngatlanSuliban.Models
{
    public partial class Ingatlanok
    {
        public int Id { get; set; }
        public int Kategoria { get; set; }
        public string Leiras { get; set; } = null!;
        public DateTime HirdetesDatuma { get; set; }
        public bool Tehermentes { get; set; }
        public int Ar { get; set; }
        public string KepUrl { get; set; } = null!;

        public virtual Kategoriak? KategoriaNavigation { get; set; } = null!;
    }
}

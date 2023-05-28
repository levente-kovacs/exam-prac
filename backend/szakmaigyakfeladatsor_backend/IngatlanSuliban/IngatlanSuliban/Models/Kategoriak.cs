using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IngatlanSuliban.Models
{
    public partial class Kategoriak
    {
        public Kategoriak()
        {
            Ingatlanoks = new HashSet<Ingatlanok>();
        }

        public int Id { get; set; }
        public string Nev { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Ingatlanok> Ingatlanoks { get; set; }
    }
}

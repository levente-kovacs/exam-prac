using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SuliVerseny.Models
{
    public partial class Iskolalogok
    {
        public int Id { get; set; }
        public int IskolaId { get; set; }
        public byte[] Logo { get; set; }

        [JsonIgnore]
        public virtual Iskolak Iskola { get; set; }
    }
}

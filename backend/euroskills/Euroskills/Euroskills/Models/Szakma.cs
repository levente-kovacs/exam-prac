using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Euroskills.Models
{
    public partial class Szakma
    {
        public Szakma()
        {
            Versenyzos = new HashSet<Versenyzo>();
        }

        public string Id { get; set; } = null!;
        public string SzakmaNev { get; set; } = null!;

        public virtual ICollection<Versenyzo> Versenyzos { get; set; }
    }
}

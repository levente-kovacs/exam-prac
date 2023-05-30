﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Euroskills.Models
{
    public partial class Orszag
    {
        public Orszag()
        {
            Versenyzos = new HashSet<Versenyzo>();
        }

        public string Id { get; set; } = null!;
        public string OrszagNev { get; set; } = null!;

        public virtual ICollection<Versenyzo> Versenyzos { get; set; }
    }
}

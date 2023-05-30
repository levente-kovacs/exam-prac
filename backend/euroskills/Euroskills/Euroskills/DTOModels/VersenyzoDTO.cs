using Euroskills.Models;
using System.Text.Json.Serialization;

namespace Euroskills.DTOModels
{
    public class VersenyzoDTO
    {
        public string OrszagNev { get; set; } = null!;
        public string Nev { get; set; } = null!;
        public int Pont { get; set; }
        //public virtual Szakma Szakma { get; set; } = null!;

    }
}

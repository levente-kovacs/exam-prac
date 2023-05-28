using IngatlanSuliban.Models;

namespace IngatlanSuliban.DTOs
{
    public class IngatlanDTO
    {
        public int Id { get; set; }
        public string Kategoria { get; set; } = null!;
        public string Leiras { get; set; } = null!;
        public DateTime HirdetesDatuma { get; set; }
        public bool Tehermentes { get; set; }
        public int Ar { get; set; }
        public string KepUrl { get; set; } = null!;


    }
}

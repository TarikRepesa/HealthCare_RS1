using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Models
{
    [Table("Korisnik")]
    public class Korisnik
    {
        [Key]
        public string Id { get; set; }
        [JsonIgnore]
        public string KorisnickoIme { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public byte[]? slika { get; set; }

        public ICollection<Uloga> Uloge { get; set; } = new List<Uloga>();
        public bool IsEnabled2FA { get; set; }
        public string? VerificationCode { get; set; }
    }
}

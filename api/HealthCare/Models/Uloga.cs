using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class Uloga
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Korisnik> Korisnici { get; set; }
    }
}

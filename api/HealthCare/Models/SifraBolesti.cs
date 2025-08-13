using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class SifraBolesti
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Sifra mora biti veci od 5 a manji od 50 slova.", MinimumLength = 5)]
        public string Sifra { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Naziv mora biti veci od 5 a manji od 50 slova.", MinimumLength = 5)]
        public string Naziv { get; set; }
    }
}

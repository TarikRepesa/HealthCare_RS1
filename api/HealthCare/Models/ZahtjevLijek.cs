using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class ZahtjevLijek
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Naziv mora biti veci od 2 a manji od 25 slova.", MinimumLength = 2)]
        public string Naziv { get; set; }
        [Required]
        [Range(1, 200, ErrorMessage = "Kolicina mora biti izmedju 0-200!")]
        public double Kolicina { get; set; }

        [ForeignKey(nameof(ApotekaId))]
        public Apoteka Apoteka { get; set; }
        public int ApotekaId { get; set; }
        [ForeignKey(nameof(LjekarId))]
        public Ljekar Ljekar { get; set; }
        public string LjekarId { get; set; }
        public bool? Odobren { get; set;  }
    }
}

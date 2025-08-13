using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class Odjeljenje
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Naziv mora biti veci od 5 a manji od 25 slova.", MinimumLength = 5)]
        public string Naziv { get; set; }
        [Required]
        public string Vrsta { get; set; }

        public ICollection<Osoblje> Osoblje { get; set; }

        [ForeignKey(nameof(BolnicaId))]
        public Bolnica Bolnica { get; set; }
        public int BolnicaId { get; set; }
    }
}

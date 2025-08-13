using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class Odsjek
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Naziv mora biti veci od 5 a manji od 50 slova.", MinimumLength = 5)]
        public string Naziv { get; set; }

        [ForeignKey(nameof(OdjeljenjeId))]
        public Odjeljenje Odjeljenje { get; set; }
        public int OdjeljenjeId { get; set; }
    }
}

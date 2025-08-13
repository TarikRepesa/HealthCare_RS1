using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    [Table("Osoblje")]
    public class Osoblje : Korisnik
    {
        [Required]
        [Range(1, 30)]
        public int GodineIskustva { get; set; }

        [ForeignKey(nameof(OdjeljenjeId))]
        [Required]
        public Odjeljenje Odjeljenje { get; set; }
        public int OdjeljenjeId { get; set; }

        public ICollection<Ambulanta> Ambulante { get; set; }
        public ICollection<Obavijesti> Obavijesti { get; set; }
    }
}

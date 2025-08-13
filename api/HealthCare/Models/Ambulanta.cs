using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class Ambulanta
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Vrsta { get; set; }

        [ForeignKey(nameof(BolnicaId))]
        public Bolnica Bolnica { get; set; }
        public int BolnicaId { get; set; }

        public ICollection<Osoblje> Osoblja { get; set; }
        public ICollection<Termin> Termini { get; set; }

    }
}

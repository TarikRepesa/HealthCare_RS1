using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class Apoteka
    {
        [Key]
        public int Id { get; set; }
        public string Vrsta { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public ICollection<Farmaceut> Farmaceuti { get; set; }
        public ICollection<Lijek> Lijekovi { get; set; }

        [ForeignKey(nameof(BolnicaId))]
        public Bolnica Bolnica { get; set; }
        public int BolnicaId { get; set; }
    }
}

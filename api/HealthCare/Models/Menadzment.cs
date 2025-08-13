using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class Menadzment
    {
        [Key]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Uloga { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        [ForeignKey(nameof(BolnicaId))]
        public Bolnica Bolnica { get; set; }
        public int BolnicaId { get; set; }
    }
}

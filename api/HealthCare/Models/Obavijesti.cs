using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class Obavijesti
    {
        [Key]
        public int Id { get; set; }
        public string Poruka { get; set; }
        public DateTime DatumVrijemeSlanja { get; set; }

        [ForeignKey(nameof(OsobljeId))]
        public Osoblje Osoblje { get; set; }
        public string OsobljeId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    [Table("Farmaceut")]
    public class Farmaceut : Osoblje
    {
        public string Radnik { get; set; }

        [ForeignKey(nameof(ApotekaId))]
        public Apoteka Apoteka { get; set; }
        public int ApotekaId { get; set; }
    }
}

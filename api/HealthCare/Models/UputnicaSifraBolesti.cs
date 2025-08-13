using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class UputnicaSifraBolesti
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(UputnicaId))]
        public Uputnica Uputnica { get; set; }
        public int UputnicaId { get; set; }

        [ForeignKey(nameof(SifraBolestiId))]
        public SifraBolesti SifraBolesti { get; set; }
        public int SifraBolestiId { get; set; }
    }
}

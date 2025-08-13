using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    [Table("Pacijent")]
    public class Pacijent : Korisnik
    {
        public DateTime DatumRodenja { get; set; }
        public string MjestoRodenja { get; set; }

        public ZdravstvenaLegitimacija ZdravstvenaLegitimacija { get; set; }
        public Karton Karton { get; set; }
        public ICollection<Nalaz> Nalazi { get; set; }
        public ICollection<Uputnica> Uputnice { get; set; }
        public ICollection<Termin> Termini { get; set; }
        public ICollection<Recept> Recepti { get; set; }

    }
}

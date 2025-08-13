using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    [Table("Ljekar")]
    public class Ljekar : Osoblje
    {
        public string Sifra { get; set; }
        public string Specjalizacija { get; set; }
        public string Specifikacija { get; set; }

        public ICollection<Karton> Kartoni { get; set; }
        public ICollection<Nalaz> Nalazi { get; set; }
        public ICollection<Uputnica> Uputnice { get; set; }
        public ICollection<Recept> Recepti { get; set; }
        public ICollection<Termin> Termini { get; set; }

    }
}

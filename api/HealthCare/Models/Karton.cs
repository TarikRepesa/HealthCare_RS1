using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class Karton
    {
        [Key]
        public int Id { get; set; }
        public string Sifra { get; set; }

        public ICollection<Ljekar> Ljekari { get; set; }

        public string PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }

    }
}

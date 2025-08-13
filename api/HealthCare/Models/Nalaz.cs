using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class Nalaz
    {
        [Key]
        public int Id { get; set; }
        public string Vrsta { get; set; }
        public string Prioritet { get; set; }

        [ForeignKey(nameof(PacijentId))]
        public Pacijent Pacijent { get; set; }
        public string PacijentId { get; set; }

        [ForeignKey(nameof(LjekarId))]
        public Ljekar Ljekar { get; set; }
        public string LjekarId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class Recept
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public string Doza { get; set; }
        public string Napomena { get; set; }
        public string SifraBolesti { get; set; }


        [ForeignKey(nameof(PacijentId))]
        public Pacijent Pacijent { get; set; }
        public string PacijentId { get; set; }


        [ForeignKey(nameof(LjekarId))]
        public Ljekar Ljekar { get; set; }
        public string LjekarId { get; set; }

        public ICollection<Lijek> Lijekovi { get; set; }
    }
}

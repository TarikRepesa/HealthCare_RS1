using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class Proizvodjac
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public ICollection<Lijek> Lijekovi { get; set; }
    }
}

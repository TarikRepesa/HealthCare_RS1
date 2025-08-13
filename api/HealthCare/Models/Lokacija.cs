using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class Lokacija
    {
        [Key]
        public int Id { get; set; }
        public string Grad { get; set; }
        public string Opstina { get; set; }
        public string Ulica { get; set; }

        public int BolnicaId { get; set; }
        public Bolnica Bolnica { get; set; }
    }
}

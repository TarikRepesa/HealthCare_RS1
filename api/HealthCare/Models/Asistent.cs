using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    [Table("Asistent")]
    public class Asistent : Osoblje
    {
        public string Specijalizacija { get; set; }
        public string Kvalifikacija { get; set; }
    }
}

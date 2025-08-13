using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    [Table("Tehnicar")]
    public class Tehnicar : Osoblje
    {
        public string Specijalizacija { get; set; }
        public string Kvalifikacija { get; set; }

    }
}

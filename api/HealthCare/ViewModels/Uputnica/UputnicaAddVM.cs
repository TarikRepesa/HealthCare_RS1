using System.ComponentModel.DataAnnotations;

namespace HealthCare.ViewModels.Uputnica
{
    public class UputnicaAddVM
    {
        [Required(ErrorMessage = "Obavezno polje!")]
        public int odjeljenjeId { get; set; }
        [Required(ErrorMessage = "Obavezno polje!")]
        public int odsjekId { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [StringLength(50, ErrorMessage = "Minimalna duzina slova je 2, maksimalna duzina slova je 50!", MinimumLength = 2)]
        public string dijagnoza { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public string ljekarId { get; set; }
        [StringLength(100, ErrorMessage = "Maksimalna duzina slova je 100!")]
        public string primjedba { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public List<int> sifreBolestiId { get; set; }
    }
}

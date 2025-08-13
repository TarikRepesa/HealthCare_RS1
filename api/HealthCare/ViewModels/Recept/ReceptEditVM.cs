using System.ComponentModel.DataAnnotations;

namespace HealthCare.ViewModels.Recept
{
    public class ReceptEditVM
    {
        [Required(ErrorMessage = "Obavezno polje!")]
        [StringLength(10, ErrorMessage = "Minimalna duzina slova je 2, maksimalna duzina slova je 10!", MinimumLength = 2)]
        public string doza { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [StringLength(500, ErrorMessage = "Minimalna duzina slova je 2, maksimalna duzina slova je 500!", MinimumLength = 2)]
        public string napomena { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [RegularExpression(@"[A-Z][0-9]{2} [A-Z][0-9]{2}$", ErrorMessage = "Unesite ispravan unos (Example: A00 A89)!")]
        public string sifraBolesti { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public string ljekarId { get; set; }
    }
}

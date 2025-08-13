using System.ComponentModel.DataAnnotations;

namespace HealthCare.ViewModels.Nalaz
{
    public class NalazAddVM
    {

        [Required(ErrorMessage = "Obavezno polje!")]
        [StringLength(50, ErrorMessage = "Minimalna duzina slova je 2, maksimalna duzina slova je 50!", MinimumLength = 2)]
        public string prioritet { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [StringLength(50, ErrorMessage = "Minimalna duzina slova je 2, maksimalna duzina slova je 50!", MinimumLength = 2)]
        public string vrsta { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public string ljekarId { get; set; }
    }
}

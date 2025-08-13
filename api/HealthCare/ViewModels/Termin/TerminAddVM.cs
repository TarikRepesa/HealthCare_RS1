using System.ComponentModel.DataAnnotations;

namespace HealthCare.ViewModels.Termin
{
    public class TerminAddVM
    {
        [Required(ErrorMessage = "Obavezno polje!")]
        public DateTime vrijemeOd { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public DateTime? vrijemeDo { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [StringLength(100, ErrorMessage = "Minimalna duzina slova je 2, maksimalna duzina slova je 100!", MinimumLength = 2)]
        public string vrsta { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [StringLength(100, ErrorMessage = "Minimalna duzina slova je 2, maksimalna duzina slova je 100!", MinimumLength = 2)]
        public string prioritet { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public string ljekarId { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public int ambulantaId { get; set; }
    }
}

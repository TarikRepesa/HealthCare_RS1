using System.ComponentModel.DataAnnotations;

namespace HealthCare.ViewModels.Pacijent
{
    public class PacijentEditVM
    {
        [Required(ErrorMessage = "Obavezno polje!")]
        [StringLength(30, ErrorMessage = "Ime mora biti veci od 2 a manji od 30 slova", MinimumLength = 2)]
        [RegularExpression(@"^[A-Z][a-z_\\-]+$", ErrorMessage = "Ime mora poceti sa velikim slovom, bez specijalnih znakova!")]
        public string ime { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [StringLength(30, ErrorMessage = "Prezime mora biti veci od 2 a manji od 30 slova", MinimumLength = 2)]
        [RegularExpression(@"^[A-Z][a-z_\\-]+$", ErrorMessage = "Prezime mora poceti sa velikim slovom, bez specijalnih znakova!")]
        public string prezime { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3,4}[)]?[-\s\/]?[0-9]{3}[-\s]?[0-9]{3,6}$", ErrorMessage = "Unesite ispravan unos (Example: 061/111-222)!")]
        public string brojTelefona { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Unesite ispravan email (Example: name.surname@gmail.com OR name@gmail.com)!")]
        public string email { get; set; }

        public string? slika_korisnika { get; set; }

    }
}

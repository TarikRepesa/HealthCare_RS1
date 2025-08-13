using System.ComponentModel.DataAnnotations;

namespace HealthCare.ViewModels.Osoblje
{
    public class OsobljeAddVM
    {
        [Required(ErrorMessage = "Obavezno polje!")]
        [StringLength(30, ErrorMessage = "Ime mora biti veci od 2 a manji od 30 slova", MinimumLength = 2)]
        [RegularExpression(@"^[A-Z][a-z_\\-]+$", ErrorMessage = "Ime mora poceti sa velikim slovom, bez specijalnih znakova!")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [StringLength(30, ErrorMessage = "Prezime mora biti veci od 2 a manji od 30 slova", MinimumLength = 2)]
        [RegularExpression(@"^[A-Z][a-z_\\-]+$", ErrorMessage = "Prezime mora poceti sa velikim slovom, bez specijalnih znakova!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Unesite ispravan email (Example: name.surname@gmail.com OR name@gmail.com)!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3,4}[)]?[-\s\/]?[0-9]{3}[-\s]?[0-9]{3,6}$", ErrorMessage = "Unesite ispravan unos (Example: 061/111-222)!")]
        public string BrojTelefona { get; set; }

        public int GodineIskustva { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public int OdjeljenjeId { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public string Uloga { get; set; }

        public string? Slika { get; set; }

        public bool Enable2FA { get; set; }

        public string? Specijalizacija { get; set; }
        public string? Kvalifikacija { get; set; }
        public int? ApotekaId { get; set; }
        public string? Sifra { get; set; }
        public string? Specifikacija { get; set; }
    }
}

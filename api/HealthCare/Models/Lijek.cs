using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class Lijek
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Naziv mora biti veci od 2 a manji od 25 slova.", MinimumLength = 2)]
        public string Naziv { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Naziv mora biti veci od 2 a manji od 25 slova.", MinimumLength = 2)]
        public string Vrsta { get; set; }
        [Required]
        [Range(1, 200, ErrorMessage = "Kolicina na stanju mora biti izmedju 0-200!")]
        public double KolicinaNaStanju { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Nacin upotrebe mora biti veci od 10 a manji od 500 slova.", MinimumLength = 10)]
        public string NacinUpotrebe { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Nuspojave moraju biti vece od 10 a manje od 500 slova.", MinimumLength = 10)]
        public string Nuspojave { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Upozorenje mora biti vece od 10 a manje od 500 slova.", MinimumLength = 10)]
        public string Upozorenja { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+\.[0-9]{2}$", ErrorMessage = "Molimo unesite validnu cijenu")]
        public double Cijena { get; set; }

        public ICollection<Recept> Recept { get; set; }

        [ForeignKey(nameof(ProizvodjacId))]
        public Proizvodjac Proizvodjac { get; set; }
        public int ProizvodjacId { get; set; }

        [ForeignKey(nameof(ApotekaId))]
        public Apoteka Apoteka { get; set; }
        public int ApotekaId { get; set; }

    }
}

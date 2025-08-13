using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class Bolnica
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public ICollection<Ambulanta> Ambulante { get; set; }
        public ICollection<Menadzment> Menadzmenti { get; set; }
        public ICollection<Odjeljenje> Odjeljenja { get; set; }
        public ICollection<Apoteka> Apoteke { get; set; }

        public Lokacija Lokacija { get; set; }
    }
}

using HealthCare.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.WebAPI.Models
{
    public class AuthToken
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        [ForeignKey(nameof(Korisnik))]
        public string KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }
        public bool IsAllowed2FA { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
        public string IpAdresa { get; set; } = "0.0.0.0";

    }
}

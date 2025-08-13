using HealthCare.Data;
using HealthCare.ViewModels.Karton;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class KartonController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KartonController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var pacijent = _dbContext.Pacijent.Find(id);

            if (pacijent == null)
                return BadRequest("Pacijent ne postoji u bazi!");

            var zdravstvenaLegimitacija = _dbContext.ZdravstvenaLegitimacija.Where(x => x.PacijentId == id).FirstOrDefault();

            if (zdravstvenaLegimitacija == null)
                return BadRequest();

            var kartonPacijenta = _dbContext.Karton.Where(k => k.PacijentId == id).FirstOrDefault();

            if (kartonPacijenta == null)
                return BadRequest();

            var result = new KartonPrikazVM()
            {
                pacijentId = pacijent.Id,
                ime = pacijent.Ime,
                prezime = pacijent.Prezime,
                datum_rodenja = pacijent.DatumRodenja.ToString("dd/MM/yyyy"),
                mjesto_rodenja = pacijent.MjestoRodenja,
                email = pacijent.Email,
                brojTelefona = pacijent.BrojTelefona,
                slika_korisnika = pacijent.slika,
                zdravstvenaLegitimacija = new ZdravstvenaLegitimacijaVM()
                {
                    zdravstvenaLegitimacijaId = zdravstvenaLegimitacija.Id,
                    jmbg = zdravstvenaLegimitacija.JMBG,
                    datum_izdavanja = zdravstvenaLegimitacija.DatumIzdavanja,
                    dopunsko_osiguranje = zdravstvenaLegimitacija.DopunskoOsiguranje,
                    srodstvo_osiguranika = zdravstvenaLegimitacija.SrodstvoOsiguranika
                },
                karton = new KartonPacijentaVM()
                {
                    kartonId = kartonPacijenta.Id,
                    sifra_kartona = kartonPacijenta.Sifra
                }
            };

            return Ok(result);
        }

    }
}

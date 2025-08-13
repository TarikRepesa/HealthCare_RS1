using HealthCare.Data;
using HealthCare.Helper;
using HealthCare.Helper.Auth;
using HealthCare.Models;
using HealthCare.ViewModels.Pacijent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Autorizacija(admin: true, ljekar: true, farmaceut: true, asistent: true)]
    public class PacijentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PacijentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{pacijentId}")]
        public ActionResult GetById(string pacijentId)
        {
            var pacijent = _dbContext.Pacijent.Where(x => x.Id == pacijentId).FirstOrDefault();

            if (pacijent == null)
                return BadRequest("Pacijent ne postoji!");

            return Ok(pacijent);
        }

        [HttpGet]
        public ActionResult GetAll(string? ime_prezime, string? mjesto_rodenja, string? jmbg, int pageNumber = 1, int pageSize = 10)
        {
            var data = _dbContext.Pacijent
                .Include(z => z.ZdravstvenaLegitimacija)
                .Where(x => (ime_prezime == null || (x.Ime + " " + x.Prezime).ToLower().StartsWith(ime_prezime.ToLower()) || (x.Prezime + " " + x.Ime).ToLower().StartsWith(ime_prezime.ToLower()))
                && (mjesto_rodenja == null || (x.MjestoRodenja.ToLower().StartsWith(mjesto_rodenja.ToLower())))
                && (jmbg == null || (x.ZdravstvenaLegitimacija.JMBG.StartsWith(jmbg))))
                .Select(x => new Pacijent()
                {
                    Id = x.Id,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Email = x.Email,
                    BrojTelefona = x.BrojTelefona,
                    DatumRodenja = x.DatumRodenja,
                    MjestoRodenja = x.MjestoRodenja,
                    slika = x.slika,
                    ZdravstvenaLegitimacija = x.ZdravstvenaLegitimacija,
                    Karton = x.Karton,
                }).OrderBy(p => p.Ime)
            .AsQueryable();

            return Ok(PagedList<Pacijent>.Create(data, pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Add([FromBody] PacijentAddVM x)
        {
            var zdravstvenaLegitimacija = new ZdravstvenaLegitimacija
            {
                JMBG = x.jmbg,
                DatumIzdavanja = x.datumIzdavanja,
                DopunskoOsiguranje = x.dopunskoOsiguranje,
                SrodstvoOsiguranika = x.srodstvoOsiguranika
            };

            var karton = new Karton
            {
                Sifra = Generator.GenerateSifra()
            };

            var newPacijent = new Pacijent
            {
                Id = Generator.GenerateStringId(),
                Ime = x.ime,
                Prezime = x.prezime,
                Email = x.email,
                BrojTelefona = x.brojTelefona,
                DatumRodenja = x.datumRodenja,
                MjestoRodenja = x.mjestoRodenja,
                KorisnickoIme = x.ime.ToLower(),
                Password = x.ime + "_testPacijent",
            };

            if (!string.IsNullOrEmpty(x.slika_korisnika))
            {
                byte[]? slika_bajtovi = x.slika_korisnika?.ParsirajBase64();

                if (slika_bajtovi == null)
                    return BadRequest("Format slike nije Base64!");

                newPacijent.slika = slika_bajtovi;
            }

            newPacijent.ZdravstvenaLegitimacija = zdravstvenaLegitimacija;
            newPacijent.Karton = karton;

            _dbContext.Pacijent.Add(newPacijent);
            _dbContext.SaveChanges();

            return Ok(newPacijent);
        }

        [HttpPut("{pacijentId}")]
        public ActionResult Edit(string pacijentId, [FromBody] PacijentEditVM x)
        {
            var pacijent = _dbContext.Pacijent.Where(p => p.Id == pacijentId).FirstOrDefault();

            if (pacijent == null)
                return BadRequest("Pacijent ne postoji!");

            pacijent.Ime = x.ime;
            pacijent.Prezime = x.prezime;
            pacijent.BrojTelefona = x.brojTelefona;
            pacijent.Email = x.email;

            if (!string.IsNullOrEmpty(x.slika_korisnika))
            {
                byte[]? slika_bajtovi = x.slika_korisnika?.ParsirajBase64();

                if (slika_bajtovi == null)
                    return BadRequest("Format slike nije Base64!");

                pacijent.slika = slika_bajtovi;
            }

            _dbContext.SaveChanges();

            return Ok(pacijent);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var pacijent = _dbContext.Pacijent
                .Include(k => k.Karton)
                .Include(z => z.ZdravstvenaLegitimacija)
                .Include(n => n.Nalazi)
                .Include(u => u.Uputnice)
                .Include(t => t.Termini)
                .Include(r => r.Recepti).ThenInclude(l => l.Lijekovi)
                .SingleOrDefault(x => x.Id == id);

            if (pacijent == null)
                return BadRequest("Pacijent ne postoji!");

            _dbContext.Remove(pacijent);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}

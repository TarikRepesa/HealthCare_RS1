using HealthCare.Data;
using HealthCare.ViewModels.Karton;
using HealthCare.Helper;
using HealthCare.Models;
using HealthCare.ViewModels.Ljekar;
using HealthCare.ViewModels.Uputnica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthCare.ViewModels.Nalaz;

namespace HealthCare.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UputnicaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UputnicaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult GetByPacijentId(string id, string? dijagnoza, int pageNumber = 1, int pageSize = 10)
        {
            var pacijent = _dbContext.Pacijent.Find(id);

            if (pacijent == null)
                return BadRequest("Pacijent ne postoji u bazi!");

            var result = _dbContext.Uputnica
                 .Include(x => x.Odjeljenje)
                 .Include(x => x.Odsjek)
                 .Include("UputnicaSifraBolesti.SifraBolesti")
                 .Where(p => p.PacijentId == id && (dijagnoza == null || (p.Dijagnoza.ToLower().Contains(dijagnoza.ToLower()))))
                 .Select(x => new UputnicaPrikazVM
                 {
                     uputnicaId = x.Id,
                     odjeljenje = x.Odjeljenje.Naziv,
                     odsjek = x.Odsjek.Naziv,
                     dijagnoza = x.Dijagnoza,
                     datum_izdavanja = x.DatumIzdavanja.ToString("dd/MM/yyyy"),
                     datum_vazenja = x.DatumVazenja.ToString("dd/MM/yyyy"),
                     izdaoLjekar = x.Ljekar.Ime + " " + x.Ljekar.Prezime,
                     specijalizacija_ljekara = x.Ljekar.Specjalizacija,
                     primjedba = x.Primjedba,
                     sifreBolesti = x.UputnicaSifraBolesti.Select(x => x.SifraBolesti.Sifra).ToList(),
                     sifreBolestiId = x.UputnicaSifraBolesti.Select(x => x.SifraBolestiId).ToList(),
                 })
                 .OrderByDescending(r => r.uputnicaId)
                 .AsQueryable();

            return Ok(PagedList<UputnicaPrikazVM>.Create(result, pageNumber, pageSize));
        }

        [HttpGet("{uputnicaId}")]
        public ActionResult getById(int uputnicaId)
        {
            var uputnica = _dbContext.Uputnica
                .Include(lj => lj.Ljekar)
                .Include(x => x.Odjeljenje)
                .Include(x => x.Odsjek)
                .Include("UputnicaSifraBolesti.SifraBolesti")
                .Where(x => x.Id == uputnicaId).FirstOrDefault();

            if (uputnica == null)
                return BadRequest("Uputnica nije pronadena!");

            var result = new UputnicaPrikazVM()
            {
                uputnicaId = uputnica.Id,
                odjeljenjeId = uputnica.OdjeljenjeId,
                odjeljenje = uputnica.Odjeljenje.Naziv,
                odsjekId = uputnica.OdsjekId,
                odsjek = uputnica.Odsjek.Naziv,
                dijagnoza = uputnica.Dijagnoza,
                datum_izdavanja = uputnica.DatumIzdavanja.ToString("dd/MM/yyyy"),
                datum_vazenja = uputnica.DatumVazenja.ToString("dd/MM/yyyy"),
                izdaoLjekar = uputnica.Ljekar.Ime + " " + uputnica.Ljekar.Prezime,
                ljekarId = uputnica.LjekarId,
                specijalizacija_ljekara = uputnica.Ljekar.Specjalizacija,
                primjedba = uputnica.Primjedba,
                sifreBolestiId = uputnica.UputnicaSifraBolesti.Select(x => x.SifraBolestiId).ToList(),
            };

            return Ok(result);
        }


        [HttpPost("{id}")]
        public ActionResult Add(string id, [FromBody] UputnicaAddVM x)
        {
            var pacijent = _dbContext.Pacijent.Where(x => x.Id == id).FirstOrDefault();

            if (pacijent == null)
                return BadRequest("Pacijent nije pronađen u bazi!");

            var ljekar = _dbContext.Ljekar.Where(z => z.Id == x.ljekarId).FirstOrDefault();

            if (ljekar == null)
                return BadRequest("Ljekar nije pronađen u bazi!");

            var odjeljenje = _dbContext.Odjeljenje.Find(x.odjeljenjeId);

            if (odjeljenje == null)
                return BadRequest("Odjeljenje nije pronađeno u bazi!");

            var odsjek = _dbContext.Odsjek.Find(x.odsjekId);

            if (odsjek == null)
                return BadRequest("Odsjek nije pronađen u bazi!");

            var sifreBolestiId = x.sifreBolestiId;
            if (sifreBolestiId.Count == 0)
            {
                return BadRequest("Sifre bolesti su obavezno polje!");
            }

            var newUputnica = new Uputnica()
            {
                OdjeljenjeId = x.odjeljenjeId,
                OdsjekId = x.odsjekId,
                Dijagnoza = x.dijagnoza,
                PacijentId = pacijent.Id,
                Pacijent = pacijent,
                LjekarId = ljekar.Id,
                Ljekar = ljekar,
                Primjedba = x.primjedba,
                DatumIzdavanja = DateTime.Now,
                DatumVazenja = DateTime.Now.AddMonths(2)
            };

            foreach (var sifraBolestiId in sifreBolestiId)
            {
                var sifra = _dbContext.SifraBolesti.Find(sifraBolestiId);
                if (sifra == null)
                {
                    return BadRequest("Sifra bolesti nije pronađena u bazi!");
                }

                newUputnica.UputnicaSifraBolesti.Add(new UputnicaSifraBolesti
                {
                    SifraBolesti = sifra
                });
            }

            _dbContext.Uputnica.Add(newUputnica);
            _dbContext.SaveChanges();

            return Ok(newUputnica);
        }

        [HttpGet]
        public ActionResult GetLjekarByNameSurname()
        {
            var result = _dbContext.Ljekar.Select(x => new LjekarImePrezimeVM()
            {
                id = x.Id,
                ImePrezime = x.Ime + " " + x.Prezime
            }).OrderByDescending(x => x.id).ToList();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] UputnicaEditVM x)
        {
            var uputnica = _dbContext.Uputnica
                .Include(x => x.UputnicaSifraBolesti)
                .Where(x => x.Id == id).FirstOrDefault();

            if (uputnica == null)
                return BadRequest("Uputnica nije pronadjena!");

            var ljekar = _dbContext.Ljekar.Where(ljekar => ljekar.Id == x.ljekarId).FirstOrDefault();

            if (ljekar == null)
                return BadRequest("Ljekar nije pronadjen!");

            var odjeljenje = _dbContext.Odjeljenje.Find(x.odjeljenjeId);

            if (odjeljenje == null)
                return BadRequest("Odjeljenje nije pronađeno u bazi!");

            var odsjek = _dbContext.Odsjek.Find(x.odsjekId);

            if (odsjek == null)
                return BadRequest("Odsjek nije pronađen u bazi!");

            uputnica.OdjeljenjeId = x.odjeljenjeId;
            uputnica.OdsjekId = x.odsjekId;
            uputnica.Dijagnoza = x.dijagnoza;
            uputnica.Primjedba = x.primjedba;
            uputnica.LjekarId = x.ljekarId;

            uputnica.UputnicaSifraBolesti.Clear();
            foreach (var sifraBolestiId in x.sifreBolestiId)
            {
                uputnica.UputnicaSifraBolesti.Add(new UputnicaSifraBolesti
                {
                    SifraBolestiId = sifraBolestiId
                });
            }

            _dbContext.SaveChanges();

            return Ok(uputnica);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var uputnica = _dbContext.Uputnica.Find(id);

            if (uputnica == null)
                return BadRequest("Uputnica nije pronadena!");

            _dbContext.Remove(uputnica);
            _dbContext.SaveChanges();

            return Ok();
        }

    }
}


using HealthCare.Data;
using HealthCare.Helper;
using HealthCare.Helper.Auth;
using HealthCare.Models;
using HealthCare.ViewModels.Apoteka;
using HealthCare.ViewModels.ZahtjevLijek;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ZahtjevLijekController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ZahtjevLijekController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        [Autorizacija(farmaceut: true, admin: true, ljekar: true)]
        public ActionResult Get(int id)
        {
            return Ok(_dbContext.ZahtjevLijekovi.FirstOrDefault(m => m.Id == id));
        }

        [Autorizacija(farmaceut: true, admin: true, ljekar: true)]
        [HttpGet]
        public IActionResult GetAll(string? naziv, int pageNumber = 1, int pageSize = 10)
        {
            var data = _dbContext.ZahtjevLijekovi
                .Where(x => (naziv == null || x.Naziv.ToLower().StartsWith(naziv.ToLower())))
                .Select(s => new ZahtjevLijek()
                {
                    Id = s.Id,
                    Naziv = s.Naziv,
                    Kolicina = s.Kolicina,
                    Apoteka = s.Apoteka,
                    ApotekaId = s.ApotekaId,
                    Ljekar = s.Ljekar,
                    LjekarId = s.LjekarId,
                    Odobren = s.Odobren
                })
                .OrderByDescending(p => p.Id)
                .AsQueryable();

            return Ok(PagedList<ZahtjevLijek>.Create(data, pageNumber, pageSize));
        }

        [Autorizacija(ljekar: true)]
        [HttpPost]
        public ActionResult Add([FromBody] ZahtjevLijekAddVM l)
        {
            var loginInformacije = HttpContext.GetLoginInfo();
            var apoteka = _dbContext.Apoteka.Where(x => x.Id == l.ApotekaId).FirstOrDefault();

            if (apoteka == null)
                return BadRequest("Apoteka nije pronađen u bazi!");

            var newLijek = new ZahtjevLijek
            {
                Naziv = l.Naziv,
                Kolicina = l.Kolicina,
                ApotekaId = apoteka.Id,
                LjekarId = loginInformacije.Korisnik.Id,
            };

            _dbContext.Add(newLijek);
            _dbContext.SaveChanges();
            return Ok(newLijek);
        }

        [HttpGet]
        public ActionResult GetApoteka()
        {
            var result = _dbContext.Apoteka.Select(x => new ApotekaVrstaVM()
            {
                id = x.Id,
                Vrsta = x.Vrsta
            }).OrderByDescending(x => x.id).ToList();

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            var zahtjev = _dbContext.ZahtjevLijekovi.Find(id);

            if (zahtjev == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(zahtjev);
            _dbContext.SaveChanges();
            return Ok(zahtjev);
        }

        [HttpPatch("{Id}")]
        public IActionResult Odobri(int id)
        {
            var zahtjev = _dbContext.ZahtjevLijekovi.Find(id);

            if (zahtjev == null)
                return BadRequest("pogresan ID");

            zahtjev.Odobren = true;
            _dbContext.SaveChanges();
            return Ok(zahtjev);
        }
        [HttpPatch("{Id}")]
        public IActionResult Odbij(int id)
        {
            var zahtjev = _dbContext.ZahtjevLijekovi.Find(id);

            if (zahtjev == null)
                return BadRequest("pogresan ID");

            zahtjev.Odobren = false;
            _dbContext.SaveChanges();
            return Ok(zahtjev);
        }
    }
}

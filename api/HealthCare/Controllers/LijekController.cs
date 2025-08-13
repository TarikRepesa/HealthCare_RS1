using HealthCare.Data;
using HealthCare.Helper;
using HealthCare.Helper.Auth;
using HealthCare.Models;
using HealthCare.ViewModels.Apoteka;
using HealthCare.ViewModels.Lijek;
using HealthCare.ViewModels.Proizvodjac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LijekController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public LijekController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            return Ok(_dbContext.Lijek.FirstOrDefault(m => m.Id == id));
        }

        [Autorizacija(farmaceut: true, admin: true, ljekar: true)]
        [HttpGet]
        public IActionResult GetAll(string? naziv, string? vrsta, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var data = _dbContext.Lijek.Where(x => (naziv == null || (x.Naziv).ToLower().StartsWith(naziv.ToLower()))
                && (vrsta == null || (x.Vrsta).ToLower().StartsWith(vrsta.ToLower()))).Select(s => new Lijek()
                {
                    Id = s.Id,
                    Naziv = s.Naziv,
                    Vrsta = s.Vrsta,
                    KolicinaNaStanju = s.KolicinaNaStanju,
                    NacinUpotrebe = s.NacinUpotrebe,
                    Nuspojave = s.Nuspojave,
                    Upozorenja = s.Upozorenja,
                    Cijena = s.Cijena

                }).OrderByDescending(p => p.Id).AsQueryable();
                return Ok(PagedList<Lijek>.Create(data, pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] Lijek m)
        {
            Lijek lijek = _dbContext.Lijek.FirstOrDefault(m => m.Id == id); ;

            if (lijek == null)
                return BadRequest("Lijek ne postoji u bazi!");


            lijek.Naziv = m.Naziv;
            lijek.Vrsta = m.Vrsta;
            lijek.KolicinaNaStanju = m.KolicinaNaStanju;
            lijek.NacinUpotrebe = m.NacinUpotrebe;
            lijek.Nuspojave = m.Nuspojave;
            lijek.Upozorenja = m.Upozorenja;
            lijek.Cijena = m.Cijena;

            _dbContext.SaveChanges();
            return Get(lijek.Id);
        }

        [HttpPost]
        public ActionResult Add([FromBody] LijekAddVM l)
        {
            var lijek = _dbContext.Lijek.Where(x => x.Naziv == l.Naziv).FirstOrDefault();

            if (lijek != null)
                return BadRequest("Lijek sa tim nazivom vec postoji u bazi!");

            var apoteka = _dbContext.Apoteka.Where(x => x.Id == l.ApotekaId).FirstOrDefault();

            if (apoteka == null)
                return BadRequest("Apoteka nije pronađen u bazi!");

            var proizvodjac = _dbContext.Proizvodjac.Where(z => z.Id == l.ProizvodjacId).FirstOrDefault();

            if (proizvodjac == null)
                return BadRequest("Proizvodjac nije pronađen u bazi!");
            var newLijek = new Lijek
            {
                Naziv = l.Naziv,
                Vrsta = l.Vrsta,
                KolicinaNaStanju = l.KolicinaNaStanju,
                NacinUpotrebe = l.NacinUpotrebe,
                Nuspojave = l.Nuspojave,
                Upozorenja = l.Upozorenja,
                Cijena = l.Cijena,
                ApotekaId = apoteka.Id,
                Apoteka = apoteka,
                ProizvodjacId = proizvodjac.Id,
                Proizvodjac = proizvodjac
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

        [HttpGet]
        public ActionResult GetProizvodjac()
        {
            var result = _dbContext.Proizvodjac.Select(x => new ProizvodjacNazivVM()
            {
                id = x.Id,
                Naziv = x.Naziv
            }).OrderByDescending(x => x.id).ToList();

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            Lijek lijek = _dbContext.Lijek.Find(id);

            if (lijek == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(lijek);
            _dbContext.SaveChanges();
            return Ok(lijek);
        }
    }
}

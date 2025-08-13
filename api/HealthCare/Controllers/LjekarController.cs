using HealthCare.Data;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LjekarController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public LjekarController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Get(string id)
        {
            return Ok(_dbContext.Ljekar.FirstOrDefault(m => m.Id == id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _dbContext.Ljekar.OrderBy(s => s.Sifra).Select(s => new Ljekar()
                {
                    Id = s.Id,
                    Email = s.Email,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    BrojTelefona = s.BrojTelefona,
                    GodineIskustva = s.GodineIskustva,
                    slika = s.slika,
                    Sifra = s.Sifra,
                    Specjalizacija = s.Specjalizacija,
                    Specifikacija = s.Specifikacija
                }).AsQueryable();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{id}")]
        public ActionResult Update(string id, [FromBody] Ljekar l)
        {
            Ljekar ljekar;

            if (id == null)
            {
                ljekar = new Ljekar { };
                _dbContext.Add(ljekar);
            }
            else
            {
                ljekar = _dbContext.Ljekar.FirstOrDefault(l => l.Id == id);
                if (ljekar == null)
                    return BadRequest("pogresan ID");
            }

            ljekar.Sifra = l.Sifra;
            ljekar.Specjalizacija = l.Specjalizacija;
            ljekar.Specifikacija = l.Specifikacija;

            _dbContext.SaveChanges();
            return Get(ljekar.Id);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Ljekar x)
        {
            var newLjekar = new Ljekar
            {
                Sifra = x.Sifra,
                Specjalizacija = x.Specjalizacija,
                Specifikacija = x.Specifikacija
            };

            _dbContext.Add(newLjekar);
            _dbContext.SaveChanges();
            return Ok(newLjekar);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(string id)
        {
            Ljekar ljekar = _dbContext.Ljekar.Find(id);

            if (ljekar == null || id == "")
                return BadRequest("pogresan ID");

            _dbContext.Remove(ljekar);
            _dbContext.SaveChanges();
            return Ok(ljekar);
        }
    }
}

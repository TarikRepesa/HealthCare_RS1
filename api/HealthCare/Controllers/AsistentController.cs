using HealthCare.Data;
using HealthCare.Models;
using HealthCare.ViewModels.Asistent;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AsistentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AsistentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Asistent>> GetAll()
        {
            var data = _dbContext.Asistent.Select(x => new Asistent()
            {
                Id = x.Id,
                Email = x.Email,
                Ime = x.Ime,
                Prezime = x.Prezime,
                BrojTelefona = x.BrojTelefona,
                GodineIskustva = x.GodineIskustva,
                slika = x.slika,
                Specijalizacija = x.Specijalizacija,
                Kvalifikacija = x.Kvalifikacija
            }).AsQueryable();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var asistent = _dbContext.Asistent.Where(x => x.Id == id).FirstOrDefault();

            if (asistent == null)
                return BadRequest("Asistent nije pronaden u bazi!");

            var result = new AsistentPrikazVM()
            {
                asistentId = asistent.Id,
                ime = asistent.Ime,
                prezime = asistent.Prezime,
                email = asistent.Email,
                brojTelefona = asistent.BrojTelefona,
                specijalizacija = asistent.Specijalizacija,
                kvalifikacija = asistent.Kvalifikacija,
                slika_korisnika = asistent.slika
            };

            return Ok(result);
        }
    }
}

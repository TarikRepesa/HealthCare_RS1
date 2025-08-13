using HealthCare.Data;
using HealthCare.Models;
using HealthCare.ViewModels.Farmaceut;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FarmaceutController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public FarmaceutController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Farmaceut>> GetAll()
        {
            var data = _dbContext.Farmaceut.Select(x => new Farmaceut()
            {
                Id = x.Id,
                Email = x.Email,
                Ime = x.Ime,
                Prezime = x.Prezime,
                BrojTelefona = x.BrojTelefona,
                GodineIskustva = x.GodineIskustva,
                slika = x.slika,
                Radnik = x.Radnik,
                Apoteka = x.Apoteka
            }).AsQueryable();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var farmaceut = _dbContext.Farmaceut.Where(x => x.Id == id).FirstOrDefault();

            if (farmaceut == null)
                return BadRequest("Asistent nije pronaden u bazi!");

            var result = new FarmaceutPrikazVM()
            {
                farmaceutId = farmaceut.Id,
                ime = farmaceut.Ime,
                prezime = farmaceut.Prezime,
                email = farmaceut.Email,
                brojTelefona = farmaceut.BrojTelefona,
                slika_korisnika = farmaceut.slika,
                radnik = farmaceut.Radnik
            };

            return Ok(result);
        }
    }
}

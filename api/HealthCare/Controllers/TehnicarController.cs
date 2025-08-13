using HealthCare.Data;
using HealthCare.Models;
using HealthCare.ViewModels.Tehnicar;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TehnicarController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TehnicarController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Tehnicar>> GetAll()
        {
            var data = _dbContext.Tehnicar.Select(x => new Tehnicar()
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
            var tehnicar = _dbContext.Tehnicar.Where(x => x.Id == id).FirstOrDefault();

            if (tehnicar == null)
                return BadRequest("Tehnicar nije pronaden u bazi!");

            var result = new TehnicarPrikazVM()
            {
                tehnicarId = tehnicar.Id,
                ime = tehnicar.Ime,
                prezime = tehnicar.Prezime,
                email = tehnicar.Email,
                brojTelefona = tehnicar.BrojTelefona,
                slika_korisnika = tehnicar.slika,
                specijalizacija = tehnicar.Specijalizacija,
                kvalifikacija = tehnicar.Kvalifikacija
            };

            return Ok(result);
        }
    }
}

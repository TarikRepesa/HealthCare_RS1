using HealthCare.Data;
using HealthCare.Helper.Auth;
using HealthCare.ViewModels.SifraBolesti;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SifraBolestiController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public SifraBolestiController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [Autorizacija(admin: true, ljekar: true)]
        [HttpGet]
        public ActionResult Get(int id)
        {
            return Ok(_dbContext.SifraBolesti.FirstOrDefault(m => m.Id == id));
        }

        [Autorizacija(admin: true, ljekar: true)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _dbContext.SifraBolesti
                    .OrderBy(s => s.Id).Select(od =>
                    new SifraBolestiVM()
                    {
                        Id = od.Id,
                        Sifra = od.Sifra,
                        Naziv = od.Naziv,
                    }).AsQueryable();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}

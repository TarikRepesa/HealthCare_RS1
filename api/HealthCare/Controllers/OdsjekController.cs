using HealthCare.Data;
using HealthCare.Helper.Auth;
using HealthCare.ViewModels.Odsjek;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OdsjekController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public OdsjekController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [Autorizacija(admin: true, ljekar: true)]
        [HttpGet]
        public ActionResult Get(int id)
        {
            return Ok(_dbContext.Odsjek.FirstOrDefault(m => m.Id == id));
        }

        [Autorizacija(admin: true, ljekar: true)]
        [HttpGet]
        public IActionResult GetAll(int? odjeljenjeId = null)
        {
            try
            {
                var data = _dbContext.Odsjek
                    .Where(x => odjeljenjeId == null || x.OdjeljenjeId == odjeljenjeId)
                    .OrderBy(s => s.Id).Select(od =>
                    new OdsjekVM()
                    {
                        Id = od.Id,
                        Naziv = od.Naziv,
                        OdjeljenjeId = od.Odjeljenje.Id
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

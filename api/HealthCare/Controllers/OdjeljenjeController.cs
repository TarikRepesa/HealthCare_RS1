using HealthCare.Data;
using HealthCare.Helper.Auth;
using HealthCare.Models;
using HealthCare.ViewModels.Bolnica;
using HealthCare.ViewModels.Odjeljenje;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OdjeljenjeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public OdjeljenjeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [Autorizacija(admin: true, ljekar: true)]
        [HttpGet]
        public ActionResult Get(int id)
        {
            return Ok(_dbContext.Odjeljenje.FirstOrDefault(m => m.Id == id));
        }

        [Autorizacija(admin: true, ljekar: true)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _dbContext.Odjeljenje.OrderBy(s => s.Id).Select(od => new OdjeljenjeVM()
                {
                    Id = od.Id,
                    Naziv = od.Naziv,
                    BrojOsoblja = _dbContext.Osoblje.Count(os=>os.OdjeljenjeId == od.Id),
                    Vrsta = od.Vrsta
                }).AsQueryable();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] OdjeljenjeEditVM o)
        {
            Odjeljenje odjeljenje = _dbContext.Odjeljenje.Where(x => x.Id == id).FirstOrDefault();

            if (odjeljenje == null)
                return BadRequest("Odjeljenje ne postoji!");

            odjeljenje.Naziv = o.Naziv;
            odjeljenje.Vrsta = o.Vrsta;

            _dbContext.SaveChanges();
            return Ok(odjeljenje);
        }

        [HttpPost]
        public ActionResult Add([FromBody] OdjeljenjeAddVM o)
        {
            var odjeljenje = _dbContext.Odjeljenje.Where(x => x.Naziv == o.Naziv).FirstOrDefault();

            if (odjeljenje != null)
                return BadRequest("Ovo odjeljenje vec postoji u bazi!");

            var bolnica = _dbContext.Bolnica.Where(x => x.Id == o.BolnicaId).FirstOrDefault();

            if (bolnica == null)
                return BadRequest("Bolnica nije pronađen u bazi!");

            var newOdjeljenje = new Odjeljenje
            {
                Naziv = o.Naziv,
                Vrsta = o.Vrsta,
                BolnicaId = bolnica.Id,
                Bolnica = bolnica
            };

            _dbContext.Add(newOdjeljenje);
            _dbContext.SaveChanges();
            return Ok(newOdjeljenje);
        }

        [HttpGet]
        public ActionResult GetBolnice()
        {
            var result = _dbContext.Bolnica.Select(x => new BolnicaVrstaVM()
            {
                Id = x.Id,
                Naziv = x.Naziv
            }).OrderByDescending(x => x.Id).ToList();

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            Odjeljenje odjeljenje = _dbContext.Odjeljenje.Find(id);

            if (odjeljenje == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(odjeljenje);
            _dbContext.SaveChanges();
            return Ok(odjeljenje);
        }
    }
}

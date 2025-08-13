using HealthCare.Data;
using HealthCare.Helper;
using HealthCare.Helper.Auth;
using HealthCare.ViewModels.NalazPregled;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NalazPregledController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public NalazPregledController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Autorizacija(pacijent: true)]
        public ActionResult GetByPacijentId(string id, int pageNumber = 1, int pageSize = 10)
        {
            var pacijent = _dbContext.Pacijent.Find(id);

            if (pacijent == null)
                return BadRequest("Pacijent ne postoji u bazi!");

            var result = _dbContext.Nalaz.Where(p => p.PacijentId == id)
                .Select(x => new NalazPregledPrikazVM
                {
                   nalazId = x.Id,
                   vrsta = x.Vrsta,
                   prioritet = x.Prioritet,
                   izdaoLjekar = x.Ljekar.Ime + " " + x.Ljekar.Prezime,
                   specijalizacija_ljekara = x.Ljekar.Specjalizacija
                })
                .OrderByDescending(r => r.nalazId)
                .AsQueryable();

            return Ok(PagedList<NalazPregledPrikazVM>.Create(result, pageNumber, pageSize));
        }
    }
}

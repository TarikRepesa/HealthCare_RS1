using HealthCare.Data;
using HealthCare.Helper;
using HealthCare.Models;
using HealthCare.ViewModels.Ljekar;
using HealthCare.ViewModels.Nalaz;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NalazController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public NalazController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult GetByPacijentId(string id, string? vrsta, int pageNumber = 1, int pageSize = 10)
        {
            var pacijent = _dbContext.Pacijent.Find(id);

            if (pacijent == null)
                return BadRequest("Pacijent ne postoji u bazi!");

            var result = _dbContext.Nalaz.Where(p => p.PacijentId == id && (vrsta== null || (p.Vrsta.ToLower().Contains(vrsta.ToLower()))))
                .Select(x => new NalazPrikazVM
                {
                    nalazId = x.Id,
                    vrsta = x.Vrsta,
                    prioritet = x.Prioritet,
                    izdaoLjekar = x.Ljekar.Ime + " " + x.Ljekar.Prezime,
                    specijalizacija_ljekara = x.Ljekar.Specjalizacija
                })
                .OrderByDescending(r => r.nalazId)
                .AsQueryable();

            return Ok(PagedList<NalazPrikazVM>.Create(result, pageNumber, pageSize));
        }

        [HttpGet("{nalazId}")]
        public ActionResult GetById(int nalazId)
        {
            var nalaz = _dbContext.Nalaz
                .Include(lj => lj.Ljekar)
                .Where(x => x.Id == nalazId).FirstOrDefault();

            if (nalaz == null)
                return BadRequest("Nalaz nije pronaden!");

            var result = new NalazPrikazVM()
            {
                nalazId = nalaz.Id,
                vrsta = nalaz.Vrsta,
                prioritet = nalaz.Prioritet,
                izdaoLjekar = nalaz.Ljekar.Ime + " " + nalaz.Ljekar.Prezime,
                ljekarId = nalaz.LjekarId,
                specijalizacija_ljekara = nalaz.Ljekar.Specjalizacija
            };

            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetLjekarByNameSurname()
        {
            var result = _dbContext.Ljekar.Select(x => new LjekarImePrezimeVM()
            {
                id = x.Id,
                ImePrezime = x.Ime + " " + x.Prezime
            }).OrderByDescending(x => x.id).ToList();

            return Ok(result);
        }

        [HttpPost("{id}")]
        public ActionResult Add(string id, [FromBody] NalazAddVM x)
        {
            var pacijent = _dbContext.Pacijent.Where(x => x.Id == id).FirstOrDefault();

            if (pacijent == null)
                return BadRequest("Pacijent nije pronađen u bazi!");

            var ljekar = _dbContext.Ljekar.Where(z => z.Id == x.ljekarId).FirstOrDefault();

            if (ljekar == null)
                return BadRequest("Ljekar nije pronađen u bazi!");

            var newNalaz = new Nalaz()
            {
                Prioritet = x.prioritet,
                Vrsta = x.vrsta,
                PacijentId = pacijent.Id,
                Pacijent = pacijent,
                LjekarId = ljekar.Id,
                Ljekar = ljekar
            };

            _dbContext.Nalaz.Add(newNalaz);
            _dbContext.SaveChanges();

            return Ok(newNalaz);
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] NalazEditVM x)
        {
            var nalaz = _dbContext.Nalaz.Where(x => x.Id == id).FirstOrDefault();

            if (nalaz == null)
                return BadRequest("Nalaz nije pronaden!");

            var ljekar = _dbContext.Ljekar.Where(ljekar => ljekar.Id == x.ljekarId).FirstOrDefault();

            if (ljekar == null)
                return BadRequest("Ljekar nije pronaden!");

            nalaz.Prioritet = x.prioritet;
            nalaz.Vrsta = x.vrsta;
            nalaz.LjekarId = ljekar.Id;

            _dbContext.SaveChanges();

            return Ok(nalaz);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var nalaz = _dbContext.Nalaz.Find(id);

            if (nalaz == null)
                return BadRequest("Nalaz nije pronaden!");

            _dbContext.Remove(nalaz);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}

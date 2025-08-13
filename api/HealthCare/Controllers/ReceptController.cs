using HealthCare.Data;
using HealthCare.Helper;
using HealthCare.Helper.Auth;
using HealthCare.Models;
using HealthCare.ViewModels.Ljekar;
using HealthCare.ViewModels.Recept;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Autorizacija(admin: true, ljekar: true, farmaceut: true, asistent: true)]
    public class ReceptController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ReceptController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Recept>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var data = _dbContext.Recept
                .Select(x => new Recept()
                {
                    Id = x.Id,
                    DatumIzdavanja = x.DatumIzdavanja,
                    Doza = x.Doza,
                    Napomena = x.Napomena,
                    SifraBolesti = x.SifraBolesti,
                    Ljekar = x.Ljekar,
                    PacijentId = x.PacijentId
                }).AsQueryable();

            return Ok(PagedList<Recept>.Create(data, pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public ActionResult GetByPacijentId(string id, string? sifraBolesti, int pageNumber = 1, int pageSize = 10)
        {
            var pacijent = _dbContext.Pacijent.Find(id);

            if (pacijent == null)
                return BadRequest("Pacijent nije pronaden u bazi!");

            var result = _dbContext.Recept.Where(r => r.PacijentId == id && (sifraBolesti == null || (r.SifraBolesti.ToLower().Contains(sifraBolesti.ToLower()))))
                .Select(x => new ReceptiPrikazVM()
                {
                    receptId = x.Id,
                    datumIzdavanja = x.DatumIzdavanja,
                    doza = x.Doza,
                    napomena = x.Napomena,
                    sifraBolesti = x.SifraBolesti,
                    imePrezime_ljekara = x.Ljekar.Ime + " " + x.Ljekar.Prezime,
                    specijalizacija_ljekara = x.Ljekar.Specjalizacija
                })
                .OrderByDescending(r => r.receptId)
                .AsQueryable();


            return Ok(PagedList<ReceptiPrikazVM>.Create(result, pageNumber, pageSize));
        }

        [HttpGet("{receptId}")]
        public ActionResult GetById(int receptId)
        {
            var recept = _dbContext.Recept
                .Include(lj => lj.Ljekar)
                .Include(p => p.Pacijent)
                .Where(x => x.Id == receptId).FirstOrDefault();

            if (recept == null)
                return BadRequest("Recept nije pronaden!");

            var result = new ReceptiPrikazVM()
            {
                receptId = recept.Id,
                datumIzdavanja = recept.DatumIzdavanja,
                doza = recept.Doza,
                napomena = recept.Napomena,
                sifraBolesti = recept.SifraBolesti,
                ljekarId = recept.LjekarId,
                imePrezime_ljekara = recept.Ljekar.Ime + " " + recept.Ljekar.Prezime,
                specijalizacija_ljekara = recept.Ljekar.Specjalizacija
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
        public ActionResult Add(string id, [FromBody] ReceptAddVM x)
        {
            var pacijent = _dbContext.Pacijent.Where(x => x.Id == id).FirstOrDefault();

            if (pacijent == null)
                return BadRequest("Pacijent nije pronađen u bazi!");

            var ljekar = _dbContext.Ljekar.Where(z => z.Id == x.ljekarId).FirstOrDefault();

            if (ljekar == null)
                return BadRequest("Ljekar nije pronađen u bazi!");

            var newRecept = new Recept()
            {
                DatumIzdavanja = x.datumIzdavanja,
                Doza = x.doza,
                Napomena = x.napomena,
                SifraBolesti = x.sifraBolesti,
                PacijentId = pacijent.Id,
                Pacijent = pacijent,
                LjekarId = ljekar.Id,
                Ljekar = ljekar
            };

            _dbContext.Recept.Add(newRecept);
            _dbContext.SaveChanges();

            return Ok(newRecept);
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] ReceptEditVM x)
        {
            var recept = _dbContext.Recept.Where(x => x.Id == id).FirstOrDefault();

            if (recept == null)
                return BadRequest("Recept nije pronaden!");

            var ljekar = _dbContext.Ljekar.Where(ljekar => ljekar.Id == x.ljekarId).FirstOrDefault();

            if (ljekar == null)
                return BadRequest("Ljekar nije pronaden!");

            recept.Doza = x.doza;
            recept.Napomena = x.napomena;
            recept.SifraBolesti = x.sifraBolesti;
            recept.LjekarId = ljekar.Id;

            _dbContext.SaveChanges();

            return Ok(recept);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var recept = _dbContext.Recept.Find(id);

            if (recept == null)
                return BadRequest("Recept nije pronaden!");

            _dbContext.Recept.Remove(recept);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}

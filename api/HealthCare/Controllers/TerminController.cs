using HealthCare.Data;
using HealthCare.Helper;
using HealthCare.Helper.Auth;
using HealthCare.Models;
using HealthCare.ViewModels.Karton;
using HealthCare.ViewModels.Ljekar;
using HealthCare.ViewModels.Termin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HealthCare.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Autorizacija(admin: true, ljekar: true, pacijent: true)]
    public class TerminController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TerminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<TerminGetAllVM>> GetAll()
        {
            var data = _dbContext.Termin
                .Include(p => p.Pacijent)
                .Include(a => a.Ambulanta)
                .Include(lj => lj.Ljekar)
                .Select(x => new TerminGetAllVM()
                {
                    terminId = x.Id,
                    vrijemeOd = x.VrijemeOd,
                    vrijemeDo = x.VrijemeDo,
                    vrsta = x.Vrsta,
                    prioritet = x.Prioritet,
                    imePrezime_pacijenta = x.Pacijent.Ime + " " + x.Pacijent.Prezime,
                    datumRodenja_pacijenta = x.Pacijent.DatumRodenja.ToString(),
                    mjestoRodenja_pacijenta = x.Pacijent.MjestoRodenja,
                    brojTelefona_pacijenta = x.Pacijent.BrojTelefona,
                    naziv_ambulante = x.Ambulanta.Naziv
                }).ToList();

            return Ok(data);
        }

        [HttpGet("{terminId}")]
        public ActionResult GetById(int terminId)
        {
            var termin = _dbContext.Termin
                .Include(p => p.Pacijent)
                .Include(a => a.Ambulanta)
                .Include(lj => lj.Ljekar)
                .Where(x => x.Id == terminId).FirstOrDefault();

            if (termin == null)
                return BadRequest("Termin nije pronaden u bazi!");

            var resultVM = new TerminGetByIdVM()
            {
                terminId = terminId,
                pocetakPosjete = termin.VrijemeOd,
                krajPosjete = termin.VrijemeDo,
                vrsta = termin.Vrsta,
                prioritet = termin.Prioritet,
                imePacijenta = termin.Pacijent.Ime,
                prezimePacijenta = termin.Pacijent.Prezime,
                datumRodenjaPacijenta = termin.Pacijent.DatumRodenja,
                mjestoRodenjaPacijenta = termin.Pacijent.MjestoRodenja,
                brojTelefonaPacijenta = termin.Pacijent.BrojTelefona,
                emailPacijenta = termin.Pacijent.Email,
                nazivAmbulante = termin.Ambulanta.Naziv,
                imeLjekara = termin.Ljekar.Ime,
                prezimeLjekara = termin.Ljekar.Prezime,
                brojTelefonaLjekara = termin.Ljekar.BrojTelefona,
                emailLjekara = termin.Ljekar.Email
            };

            return Ok(resultVM);
        }

        [HttpGet("{id}")]
        public ActionResult GetByPacijentId(string id, DateTime? datumPosjete, int pageNumber = 1, int pageSize = 10)
        {
            var pacijent = _dbContext.Pacijent.Find(id);

            if (pacijent == null)
                return BadRequest("Pacijent ne postoji u bazi!");

            var result = _dbContext.Termin.Where(p => p.PacijentId == id && (datumPosjete == null || (p.VrijemeOd.Date == datumPosjete)))
                .Select(x => new TerminiVM()
                {
                    terminId = x.Id,
                    vrijemeOd = x.VrijemeOd,
                    vrijemeDo = x.VrijemeDo,
                    vrsta = x.Vrsta,
                    prioritet = x.Prioritet,
                    ambulanta_naziv = x.Ambulanta.Naziv
                })
                .OrderByDescending(t => t.terminId)
                .AsQueryable();

            return Ok(PagedList<TerminiVM>.Create(result, pageNumber, pageSize));
        }

        [Autorizacija(admin: true, ljekar: true)]
        [HttpGet]
        public ActionResult GetTerminiByLjekar(DateTime? datum, int pageNumber = 1, int pageSize = 10)
        {
            var loginInformacije = HttpContext.GetLoginInfo();
            Korisnik logiraniKorisnik = loginInformacije.Korisnik;

            var userId = logiraniKorisnik.Id;

            if (userId != null)
            {
                var termini = _dbContext.Termin
                    .Include(p => p.Pacijent)
                    .Include(lj => lj.Ljekar)
                    .Include(a => a.Ambulanta)
                    .Where(x => x.LjekarId == userId && (datum == null || (x.VrijemeOd.Date == datum)))
                    .Select(termin => new TerminiGetByLjekar()
                    {
                        terminId = termin.Id,
                        vrijemeOd = termin.VrijemeOd,
                        vrijemeDo = termin.VrijemeDo,
                        vrsta = termin.Vrsta,
                        prioritet = termin.Prioritet,
                        ime_pacijenta = termin.Pacijent.Ime,
                        prezime_pacijenta = termin.Pacijent.Prezime,
                        datumRodenja_pacijenta = termin.Pacijent.DatumRodenja,
                        mjestoRodenja_pacijenta = termin.Pacijent.MjestoRodenja,
                    })
                    .OrderBy(y => y.vrijemeOd)
                    .AsQueryable();

                return Ok(PagedList<TerminiGetByLjekar>.Create(termini, pageNumber, pageSize));
            }

            return BadRequest();
        }

        [HttpGet]
        public ActionResult GetLjekarByNameSurname()
        {
            var reuslt = _dbContext.Ljekar.Select(x => new LjekarImePrezimeVM()
            {
                id = x.Id,
                ImePrezime = x.Ime + " " + x.Prezime + " -> " + x.Specjalizacija
            }).ToList();

            return Ok(reuslt);
        }

        [HttpGet]
        public ActionResult GetAmbulanteByNaziv()
        {
            var reuslt = _dbContext.Ambulanta.Select(x => new CmbStavke()
            {
                id = x.Id,
                opis = x.Naziv
            }).ToList();

            return Ok(reuslt);
        }

        [Autorizacija(pacijent: true)]
        [HttpPost]
        public ActionResult Add([FromBody] TerminAddVM x)
        {
            var loginInformacije = HttpContext.GetLoginInfo();
            Korisnik logiraniKorisnik = loginInformacije.Korisnik;

            var userId = logiraniKorisnik.Id;

            if (IsTerminValid(x.vrijemeOd, x.vrijemeDo))
            {
                var pacijent = _dbContext.Pacijent.Where(p => p.Id == userId).FirstOrDefault();

                if (pacijent == null)
                    return BadRequest("Pacijent ne postoji!");

                var ambulanta = _dbContext.Ambulanta.Where(a => a.Id == x.ambulantaId).FirstOrDefault();

                if (ambulanta == null)
                    return BadRequest("Ambulanta ne postoji!");

                var ljekar = _dbContext.Ljekar.Where(lj => lj.Id == x.ljekarId).FirstOrDefault();

                if (ljekar == null)
                    return BadRequest("Ljekar ne postoji!");

                var newTermin = new Termin()
                {
                    VrijemeOd = x.vrijemeOd,
                    VrijemeDo = x.vrijemeDo,
                    Vrsta = x.vrsta,
                    Prioritet = x.prioritet,
                    PacijentId = pacijent.Id,
                    Pacijent = pacijent,
                    AmbulantaId = ambulanta.Id,
                    Ambulanta = ambulanta,
                    LjekarId = ljekar.Id,
                    Ljekar = ljekar
                };

                _dbContext.Termin.Add(newTermin);
                _dbContext.SaveChanges();

                return Ok(newTermin);
            }

            return BadRequest("Uneseni termin nije validan!");
        }

        [Autorizacija(pacijent: true)]
        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] TerminUpdateVM x)
        {
            var loginInformacije = HttpContext.GetLoginInfo();
            Korisnik logiraniKorisnik = loginInformacije.Korisnik;

            var userId = logiraniKorisnik.Id;

            var termin_pacijenta = _dbContext.Termin.Where(p => p.Id == id && p.PacijentId == userId).FirstOrDefault();

            if (termin_pacijenta != null)
            {
                if (IsTerminValid(x.pocetakPosjete, x.krajPosjete))
                {
                    termin_pacijenta.VrijemeOd = x.pocetakPosjete;
                    termin_pacijenta.VrijemeDo = x.krajPosjete;

                    _dbContext.SaveChanges();

                    return Ok(termin_pacijenta);
                }
                else
                {
                    return BadRequest("Uneseni termin nije validan!");
                }
            }

            return BadRequest("Nije moguce pomjeriti termin drugog pacijenta!");
        }

        [Autorizacija(pacijent: true)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var loginInformacije = HttpContext.GetLoginInfo();
            Korisnik logiraniKorisnik = loginInformacije.Korisnik;

            var userId = logiraniKorisnik.Id;

            var termin_pacijenta = _dbContext.Termin.Where(p => p.Id == id && p.PacijentId == userId).FirstOrDefault();

            if (termin_pacijenta != null)
            {
                _dbContext.Termin.Remove(termin_pacijenta);
                _dbContext.SaveChanges();

                return Ok();
            }

            return BadRequest("Nije moguce otkazati termin drugog pacijenta!");
        }

        private bool IsTerminValid(DateTime startDate, DateTime? endDate)
        {
            var getDayStartDate = startDate.DayOfWeek.ToString();
            var getDayEndDate = endDate?.DayOfWeek.ToString();

            if (startDate >= endDate || getDayStartDate == "Sunday"
                || getDayEndDate == "Sunday")
            {
                return false;
            }

            var terminiDb = _dbContext.Termin.ToList();

            foreach (var x in terminiDb)
            {
                if (startDate <= x.VrijemeDo && endDate >= x.VrijemeOd)
                {
                    return false;
                }
            }

            return true;
        }

    }
}